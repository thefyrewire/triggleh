using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Triggleh
{
    public class FormPresenter
    {
        private readonly IFormGUI screen;
        readonly ModelRepository repository = new ModelRepository();

        public FormPresenter(IFormGUI screen)
        {
            this.screen = screen;
            screen.Register(this);
            InitialiseForm();
        }

        private void InitialiseForm()
        {
            UpdateView();
        }

        public void UpdateView()
        {
            screen.ClearTriggers();

            List<Trigger> triggers = repository.GetTriggers();
            if (triggers.Count > 0)
            {
                foreach (Trigger trigger in triggers)
                    screen.PopulateTrigger(trigger);

                Console.WriteLine(screen.GetNumberRows());

                // screen.PopulateTriggerDetails(triggers[screen.Dgv_CurrentRow]);

                screen.SetSelectedTrigger(screen.Dgv_CurrentRow);
                screen.PopulateTriggerDetails(triggers[screen.Dgv_CurrentRow]);
            }
            else
            {
                screen.ResetDetails();
            }
        }

        public bool ValidateTrigger()
        {
            bool valid = true;

            if (string.IsNullOrEmpty(screen.TriggerName.Trim()))
            {
                screen.ShowError("name", true);
                valid = false;
            }
            else screen.ShowError("name", false);

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

            /*if (screen.GetKeywords().Length <= 2)
            {
                screen.ShowError("keywords", true);
                valid = false;
            }
            else screen.ShowError("keywords", false);*/

            if (screen.CharAnimTriggerKeyChar == "None" || screen.CharAnimTriggerKeyValue == -1)
            {
                screen.ShowError("chtrigger", true);
                valid = false;
            }
            else screen.ShowError("chtrigger", false);

            return valid;
        }

        public void SaveTrigger()
        {
            Trigger triggerToSave = new Trigger();
            triggerToSave.Name = screen.TriggerName.Trim();
            triggerToSave.BitsEnabled = screen.BitsEnabled;
            triggerToSave.BitsCondition = screen.BitsCondition;
            triggerToSave.BitsAmount = screen.BitsAmount1;
            triggerToSave.BitsAmount2 = screen.BitsAmount2;
            triggerToSave.UserLevelEveryone = screen.UserLevelEveryone;
            triggerToSave.UserLevelSubs = screen.UserLevelSubs;
            triggerToSave.UserLevelMods = screen.UserLevelMods;
            triggerToSave.Keywords = screen.GetKeywords();
            triggerToSave.CharAnimTriggerKeyChar = screen.CharAnimTriggerKeyChar;
            triggerToSave.CharAnimTriggerKeyValue = screen.CharAnimTriggerKeyValue;

            Trigger triggerExists = repository.GetTriggerByName(screen.TriggerName);
            if (triggerExists != null)
            {
                Console.WriteLine("Trigger already exists... updating");
                repository.UpdateTrigger(screen.TriggerName, triggerToSave);
                /*UpdateView();
                screen.SetSelectedTrigger(screen.Dgv_CurrentRow);*/
            }
            else
            {
                Console.WriteLine("Trigger doesn't exist... adding");
                repository.AddTrigger(triggerToSave);
                screen.Dgv_CurrentRow = screen.GetNumberRows();
                /*UpdateView();
                screen.Dgv_CurrentRow = screen.GetNumberRows();
                screen.SetSelectedTrigger(screen.GetNumberRows() - 1);*/
            }

            UpdateView();
            /*screen.SetSelectedTrigger(screen.Dgv_CurrentRow);
            List<Trigger> triggers = repository.GetTriggers();
            screen.PopulateTriggerDetails(triggers[screen.Dgv_CurrentRow]);*/
        }

        public void Chk_Bits_CheckedChanged()
        {
            screen.EnableBits(screen.BitsEnabled);
        }

        public void Cmb_Bits_SelectedIndexChanged()
        {
            screen.EnableBitsBetween(screen.BitsCondition == 3);
        }

        public void Chk_ULEveryone_CheckedChanged()
        {
            screen.AllowSubsMods(!screen.UserLevelEveryone);
        }

        public void Txt_Keywords_Enter()
        {
            screen.SetAddKeywordAccept();
        }

        public void Btn_AddKeyword_Click()
        {
            if (screen.Keyword.Length == 0 || screen.HasKeyword(screen.Keyword)) return;

            int index = screen.AddKeyword(screen.Keyword);
            screen.KeywordsIndex = index;
        }

        public void Btn_RemoveKeyword_Click()
        {
            if (screen.KeywordsIndex == -1) return;

            screen.RemoveKeyword(screen.KeywordsIndex);
        }

        public void Btn_RecordTrigger_Click()
        {
            screen.StartRecordingTrigger();
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
    }
}
