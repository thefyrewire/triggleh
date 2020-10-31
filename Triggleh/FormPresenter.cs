using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Triggleh
{
    public class FormPresenter
    {
        private readonly IFormGUI screen;
        private readonly ModelRepository repository = new ModelRepository();
        private readonly Bot bot = new Bot();

        public FormPresenter(IFormGUI screen)
        {
            this.screen = screen;
            screen.Register(this);
            InitialiseForm();
        }

        private void InitialiseForm()
        {
            screen.InitialiseForm();
            screen.RefreshCharAnimStatus();
            screen.UpdateChatStatus(0);
            UpdateView();
            bot.BotDisconnected += BotDisconnected;
            bot.BotConnected += BotConnected;
            bot.BotTriggered += BotTriggered;
            LoadFromSettings();
        }

        private void UpdateView()
        {
            screen.ClearTriggers();

            List<Trigger> triggers = repository.GetTriggers();
            if (triggers.Count > 0)
            {
                foreach (Trigger trigger in triggers)
                    screen.PopulateTrigger(trigger);

                screen.SetSelectedTrigger(screen.Dgv_CurrentRow);
                screen.PopulateTriggerDetails(triggers[screen.Dgv_CurrentRow]);
            }
            else
            {
                screen.ResetDetails();
            }
        }
        public void ForceUpdateView()
        {
            UpdateView();
        }

        public void LoadFromSettings()
        {
            Setting settings = repository.LoadSettings();
            if (settings == null || settings.Username == null || settings.Username.Length == 0 || settings.UserID == null)
            {
                bot.LeaveAllChannels("");
                screen.RefreshCharAnimStatus();
                screen.SetProfilePicture("https://static-cdn.jtvnw.net/jtv_user_pictures/twitch-profile_image-8a8c5be2e3b64a9a-300x300.png");
                screen.UpdateChatStatus(0);
                return;
            }

            screen.SetProfilePicture(settings.ProfilePicture);

            List<string> channels = bot.GetAllChannels();

            if (channels.IndexOf(settings.Username) != -1)
            {
                return;
            }
            else if (channels.Count > 0)
            {
                bot.LeaveAllChannels(settings.Username);
            }
            else
            {
                bot.JoinChannel(settings.Username);
                bot.ConnectToPubSub(settings.UserID);
            }
            
        }

        public void BotDisconnected(object sender, BotDisconnectedArgs e)
        {
            Console.WriteLine($"disconnected from {e.Channel}!");
            Setting settings = repository.LoadSettings();
            if (e.Channel.ToLower() == settings.Username.ToLower()) screen.UpdateChatStatus(0);
        }

        public void BotConnected(object sender, EventArgs e)
        {
            Console.WriteLine("connected!");
            screen.UpdateChatStatus(1);
        }

        public void BotTriggered(object sender, BotTriggeredArgs e)
        {
            screen.SetLastTriggered(e.TriggeredAt.ToString());
            screen.ResetButtonVisible(true);
        }

        private bool ValidateTrigger()
        {
            bool valid = true;

            if (string.IsNullOrEmpty(screen.TriggerName.Trim()))
            {
                screen.ShowError("name", true);
                valid = false;
            }
            else screen.ShowError("name", false);
            Regex regex = new Regex(@"\s{2,}");
            screen.TriggerName = regex.Replace(screen.TriggerName.Trim(), " ");

            if (screen.BitsCondition == 3 && screen.BitsAmount1 >= screen.BitsAmount2)
            {
                screen.ShowError("bits", true);
                valid = false;
            }
            else screen.ShowError("bits", false);

            if (!screen.UserLevelEveryone && !screen.UserLevelSubs && !screen.UserLevelMods)
            {
                screen.ShowError("userlevel", true);
                valid = false;
            }
            else screen.ShowError("userlevel", false);

            if (screen.GetKeywords().Length <= 2 && screen.BitsAmount1 == 0) // []
            {
                screen.ShowValidationError(true);
                valid = false;
            }
            else screen.ShowValidationError(false);

            if (screen.CharAnimTriggerKeyChar == "None" || screen.CharAnimTriggerKeyValue == -1)
            {
                screen.ShowError("chtrigger", true);
                valid = false;
            }
            else screen.ShowError("chtrigger", false);

            if (screen.RewardName.Length > 45)
            {
                screen.ShowError("rewardname", true);
                valid = false;
            }
            else screen.ShowError("rewardname", false);

            return valid;
        }

        private void SaveTrigger()
        {
            Trigger triggerToSave = new Trigger
            {
                Name = screen.TriggerName.Trim(),
                BitsEnabled = screen.BitsEnabled,
                BitsCondition = screen.BitsCondition,
                BitsAmount = screen.BitsAmount1,
                BitsAmount2 = screen.BitsAmount2,
                UserLevelEveryone = screen.UserLevelEveryone,
                UserLevelSubs = screen.UserLevelSubs,
                UserLevelMods = screen.UserLevelMods,
                Keywords = screen.GetKeywords(),
                CharAnimTriggerKeyChar = screen.CharAnimTriggerKeyChar,
                CharAnimTriggerKeyValue = screen.CharAnimTriggerKeyValue,
                Cooldown = screen.Cooldown,
                CooldownUnit = screen.CooldownUnit,
                RewardName = screen.RewardName.Trim()
            };

            Trigger triggerExists = repository.GetTriggerByName(screen.TriggerName.Trim());
            if (triggerExists != null)
            {
                Console.WriteLine("Trigger already exists... updating");
                repository.UpdateTrigger(screen.TriggerName.Trim(), triggerToSave);
            }
            else
            {
                Console.WriteLine("Trigger doesn't exist... adding");
                repository.AddTrigger(triggerToSave);
                screen.Dgv_CurrentRow = screen.GetNumberRows();
            }

            UpdateView();
        }

        public string GetApplicationName()
        {
            Setting settings = repository.LoadSettings();
            if (settings != null)
            {
                return settings.Application;
            }
            else
            {
                return "";
            }
        }

        public void Chk_Bits_CheckedChanged()
        {
            screen.EnableBits(screen.BitsEnabled);
            screen.ShowChangesMade(true);
        }

        public void Cmb_Bits_SelectedIndexChanged()
        {
            screen.EnableBitsBetween(screen.BitsCondition == 3);
            screen.ShowChangesMade(true);
        }

        public void Chk_ULEveryone_CheckedChanged()
        {
            screen.AllowSubsMods(!screen.UserLevelEveryone);
            screen.ShowChangesMade(true);
        }

        public void Txt_Keywords_Enter()
        {
            screen.SetAddKeywordAccept();
        }

        public void Btn_AddKeyword_Click()
        {
            if (screen.Keyword.Trim().Length == 0 || screen.HasKeyword(screen.Keyword.Trim()) || screen.Keyword.Trim() == "!") return;

            int index = screen.AddKeyword(screen.Keyword.Trim());
            screen.KeywordsIndex = index;
            screen.ShowChangesMade(true);
        }

        public void Btn_RemoveKeyword_Click()
        {
            if (screen.KeywordsIndex == -1) return;

            screen.RemoveKeyword(screen.KeywordsIndex);
            screen.ShowChangesMade(true);
        }

        public void Btn_RecordTrigger_Click()
        {
            screen.StartRecordingTrigger();
            screen.ShowChangesMade(true);
        }

        public void Btn_RecordTrigger_KeyDown(string keychar, int keyvalue)
        {
            screen.CharAnimTriggerKeyChar = keychar;
            screen.CharAnimTriggerKeyValue = keyvalue;
            Console.WriteLine($"Pressed {keychar} - Key value: {keyvalue}!");
            screen.StopRecordingTrigger();
        }

        public void Btn_SaveTrigger_Click()
        {
            bool valid = ValidateTrigger();
            if (!valid) return;

            screen.ShowChangesMade(false);
            SaveTrigger();
        }

        public void Dgv_Triggers_CellClick(string name)
        {
            Trigger trigger = repository.GetTriggerByName(name);
            screen.PopulateTriggerDetails(trigger);
        }

        public void Btn_AddTrigger_Click()
        {
            screen.SetSelectedTrigger(-1);
            screen.ResetDetails();
        }

        public void Btn_RemoveTrigger_Click(string name)
        {
            repository.RemoveTrigger(name);
            UpdateView();
        }

        public void Btn_Refresh_Click()
        {
            screen.RefreshCharAnimStatus();
        }

        public void Btn_Settings_Click()
        {
            screen.ShowSettingsForm();
        }

        public void Btn_ResetLastTriggered_Click()
        {
            if (screen.GetSelectedTrigger() == null) return;
            repository.UpdateTriggerUsage(screen.GetSelectedTrigger(), DateTime.MinValue);
            screen.LastTriggered = "Never";
            screen.ResetButtonVisible(false);
        }

        public void FormControls_ChangesMade()
        {
            screen.ShowChangesMade(true);
        }

        /*public void Form1_Resize()
        {
            screen.NotifyIconVisible = true;
        }*/

        /*public void Icn_Triggleh_LeftClick()
        {
            screen.NotifyIconVisible = false;
        }*/

        public void Txt_RewardName_KeyUp()
        {
            if (!String.IsNullOrEmpty(screen.RewardName.Trim()))
                screen.EnableAsReward();
            else
                screen.DisableAsReward();

            screen.ShowChangesMade(true);
        }
    }
}
