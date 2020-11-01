using System;
using System.Text.RegularExpressions;
using System.Linq;
using System.Net.Http;
using System.Diagnostics;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

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
            screen.InitialiseForm();
            UpdateView();
        }

        private void UpdateView()
        {
            RefreshApplications();

            Setting settings = repository.LoadSettings();
            if (settings == null)
            {
                screen.Username = "";
                screen.UserID = "";
                screen.GlobalCooldown = 0;
                screen.GlobalCooldownUnit = (int) CooldownUnits.Seconds;
                screen.LoggingEnabled = true;
                return;
            }
            else
            {
                screen.Username = settings.Username;
                screen.UserID = settings.UserID;
                screen.GlobalCooldown = settings.GlobalCooldown;
                screen.GlobalCooldownUnit = settings.GlobalCooldownUnit;
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

            string token = GetToken();

            HttpClient client = new HttpClient();
            HttpRequestMessage request = new HttpRequestMessage()
            {
                RequestUri = new Uri("https://api.twitch.tv/helix/users?login=" + screen.Username),
                Method = HttpMethod.Get
            };
            request.Headers.Add("Client-ID", "gp762nuuoqcoxypju8c569th9wz7q5");
            request.Headers.Add("Authorization", "Bearer " + token);

            HttpResponseMessage response = client.SendAsync(request).Result;
            JObject parsed = JObject.Parse(response.Content.ReadAsStringAsync().Result);

            return (parsed["data"].Count<JToken>() > 0) ? (JObject) parsed["data"][0] : null;
        }

        private string GetToken()
        {
            HttpClient client = new HttpClient();
            HttpRequestMessage request = new HttpRequestMessage()
            {
                RequestUri = new Uri("https://twitchtokengenerator.com/api/refresh/tdu1bo1vyaesiaghnxk5ezns6p6ttzdegno3h0ci3z3mq1yexq"),
                Method = HttpMethod.Get
            };
            HttpResponseMessage response = client.SendAsync(request).Result;
            JObject parsed = JObject.Parse(response.Content.ReadAsStringAsync().Result);

            return (string) parsed["token"];
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
                    UserID = screen.UserID,
                    ProfilePicture = (validate != null) ? validate["profile_image_url"].ToString() : "https://static-cdn.jtvnw.net/jtv_user_pictures/twitch-profile_image-8a8c5be2e3b64a9a-300x300.png",
                    GlobalCooldown = screen.GlobalCooldown,
                    GlobalCooldownUnit = screen.GlobalCooldownUnit,
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

        public void Btn_GlobalCooldownHelp_Click()
        {
            screen.ShowHelpMessage("The global cooldown applies to ALL triggers. During this period, none of the triggers can be used.\n\n" +
                "This is useful for preventing people from spamming multiple different triggers in a short period.",
                "Global cooldown"
            );
        }

        public void Btn_ResetGlobalLastTriggered_Click()
        {
            repository.ResetGlobalCooldown();
        }

        public void Btn_Export_Click()
        {
            List<Trigger> triggers = repository.GetTriggers();
            string stringified = JsonConvert.SerializeObject(triggers.ToArray(), Formatting.Indented);
            screen.ShowExportFileDialog(stringified);
        }

        public void Btn_Import_Click()
        {
            string data = screen.ShowImportFileDialog();
            List<Trigger> triggers = JsonConvert.DeserializeObject<List<Trigger>>(data);

            string replaceTriggers = screen.ShowImportConfirmation();

            if (replaceTriggers == "Yes" || replaceTriggers == "No")
            {
                if (replaceTriggers == "Yes")
                    repository.ResetDatabase(); // clear all triggers first

                repository.ImportTriggers(triggers);
                screen.SetRefreshView(true);
                screen.CloseForm();
            }
        }
    }
}
