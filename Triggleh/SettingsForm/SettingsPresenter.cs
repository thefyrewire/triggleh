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
                screen.ProfilePicture = "https://static-cdn.jtvnw.net/jtv_user_pictures/twitch-profile_image-8a8c5be2e3b64a9a-300x300.png";
                screen.GlobalCooldown = 0;
                screen.GlobalCooldownUnit = (int) CooldownUnits.Seconds;
                screen.LoggingEnabled = true;
                return;
            }
            else
            {
                screen.Username = settings.Username;
                screen.UserID = settings.UserID;
                screen.ProfilePicture = settings.ProfilePicture;
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

            HttpClient client = new HttpClient();
            HttpRequestMessage request = new HttpRequestMessage()
            {
                RequestUri = new Uri("https://api.twitch.tv/helix/users?login=" + screen.Username),
                Method = HttpMethod.Get
            };
            request.Headers.Add("Client-ID", screen.ClientID);
            request.Headers.Add("Authorization", "Bearer " + screen.AccessToken);

            HttpResponseMessage response = client.SendAsync(request).Result;
            JObject parsed = JObject.Parse(response.Content.ReadAsStringAsync().Result);

            return (parsed["data"].Count<JToken>() > 0) ? (JObject) parsed["data"][0] : null;
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
            if (screen.DidAttemptLogin)
            {
                JObject validate = ValidateSettings();
                if (validate == null)
                {
                    screen.ShowError(true);
                    return;
                }
                else
                {
                    screen.ShowError(false);
                    screen.Username = validate["display_name"].ToString();
                    screen.UserID = validate["id"].ToString();
                    screen.ProfilePicture = validate["profile_image_url"].ToString();
                }
            }

            Setting settings = new Setting
            {
                Application = screen.Application,
                Username = screen.Username,
                UserID = screen.UserID,
                ProfilePicture = screen.ProfilePicture,
                GlobalCooldown = screen.GlobalCooldown,
                GlobalCooldownUnit = screen.GlobalCooldownUnit,
                LoggingEnabled = screen.LoggingEnabled
            };

            repository.SaveSettings(settings);

            screen.CloseForm();
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
