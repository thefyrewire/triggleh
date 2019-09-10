using System;
using System.Text.RegularExpressions;
using System.Linq;
using System.Net.Http;
using System.Diagnostics;
using Newtonsoft.Json.Linq;

namespace Triggleh
{
    public class SettingsPresenter
    {
        private readonly ISettingsGUI screen;
        private readonly ModelRepository repository = new ModelRepository();

        public SettingsPresenter(ISettingsGUI screen)
        {
            this.screen = screen;
            screen.Register(this);
            InitialiseForm();
        }

        private void InitialiseForm()
        {
            UpdateView();
        }

        private void UpdateView()
        {
            RefreshApplications();

            Setting settings = repository.LoadSettings();
            if (settings == null)
            {
                screen.Username = "";
                screen.LoggingEnabled = true;
                return;
            }
            else
            {
                screen.Username = settings.Username;
                screen.LoggingEnabled = settings.LoggingEnabled;
            }

            if (String.IsNullOrEmpty(settings.Application))
            {
                return;
            }

            int index = screen.GetApplicationIndex(settings.Application);
            if (index != -1)
            {
                screen.ApplicationsIndexOrLength = index;
            }

        }

        private JObject ValidateSettings()
        {
            if (screen.Username.Trim().Length == 0) return null;

            Regex regex = new Regex(@"\W+");
            MatchCollection matches = regex.Matches(screen.Username.Trim());
            if (matches.Count > 0) return null;

            HttpClient client = new HttpClient();
            HttpRequestMessage request = new HttpRequestMessage()
            {
                RequestUri = new Uri("https://api.twitch.tv/helix/users?login=" + screen.Username),
                Method = HttpMethod.Get
            };
            request.Headers.Add("Client-ID", "4svh28tgbd14fe4j5co9tuwjxbc0j7");

            HttpResponseMessage response = client.SendAsync(request).Result;
            JObject parsed = JObject.Parse(response.Content.ReadAsStringAsync().Result);

            return (parsed["data"].Count<JToken>() > 0) ? (JObject) parsed["data"][0] : null;
        }

        public void Btn_SaveSettings_Click()
        {
            JObject validate = ValidateSettings();
            // validate.Wait();
            if (validate != null || screen.Username.Trim().Length == 0)
            {
                screen.ShowError(false);
                screen.Username = (validate != null) ? validate["display_name"].ToString() : "";

                Setting settings = new Setting
                {
                    Application = screen.Application,
                    Username = screen.Username,
                    ProfilePicture = (validate != null) ? validate["profile_image_url"].ToString() : "https://static-cdn.jtvnw.net/jtv_user_pictures/twitch-profile_image-8a8c5be2e3b64a9a-300x300.png",
                    LoggingEnabled = screen.LoggingEnabled
                };

                repository.SaveSettings(settings);

                screen.CloseForm();
            }
            else screen.ShowError(true);
        }

        public void Btn_RefreshList_Click()
        {
            RefreshApplications();
        }

        private void RefreshApplications()
        {
            screen.ClearApplications();

            Process[] processes = Process.GetProcesses();
            foreach (Process p in processes)
            {
                if (!String.IsNullOrEmpty(p.MainWindowTitle))
                {
                    screen.AddApplication(p.ProcessName);
                }
            }
        }
    }
}
