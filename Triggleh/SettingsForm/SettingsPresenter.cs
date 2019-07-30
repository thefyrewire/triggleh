using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json.Linq;

namespace Triggleh
{
    public class SettingsPresenter
    {
        private readonly ISettingsGUI screen;
        readonly ModelRepository repository = new ModelRepository();

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
            /*string username = repository.Username;
            screen.Username = (username != null) ? username : "";
            screen.LoggingEnabled = repository.LoggingEnabled;*/
            Setting settings = repository.LoadSettings();
            if (settings != null)
            {
                screen.Username = settings.Username;
                screen.LoggingEnabled = settings.LoggingEnabled;
            }
            else
            {
                screen.Username = "";
                screen.LoggingEnabled = true;
            }

        }

        private JObject ValidateSettings()
        {
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
            if (validate != null)
            {
                screen.ShowError(false);
                screen.Username = validate["display_name"].ToString();

                Setting settings = new Setting();
                settings.Username = screen.Username;
                settings.ProfilePicture = validate["profile_image_url"].ToString();
                settings.LoggingEnabled = screen.LoggingEnabled;

                repository.SaveSettings(settings);

                screen.CloseForm();
            }
            else screen.ShowError(true);
        }
    }
}
