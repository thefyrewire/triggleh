// FormPresenter

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

                screen.PopulateTriggerDetails(triggers[screen.GetNumberRows() - 1]);
            }
            else
            {
                screen.ResetDetails();
            }
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
            if (screen.Keyword.Length == 0) return;

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
            // SendKeystroke.Send(keyvalue);
            screen.StopRecordingTrigger();
        }

        public void Btn_SaveTrigger_Click()
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
                UpdateView();
                screen.SetSelectedTrigger(screen.Dgv_CurrentRow);
            }
            else
            {
                Console.WriteLine("Trigger doesn't exist... adding");
                repository.AddTrigger(triggerToSave);
                UpdateView();
                screen.SetSelectedTrigger(screen.GetNumberRows()-1);
            }

            /*repository.AddTrigger(
                screen.TriggerName,
                screen.BitsEnabled, screen.BitsCondition, screen.BitsAmount1, screen.BitsAmount2,
                screen.UserLevelEveryone, screen.UserLevelSubs, screen.UserLevelMods,
                screen.GetKeywords(),
                screen.CharAnimTriggerKeyChar, screen.CharAnimTriggerKeyValue
            );*/

            // UpdateView();
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
    }
}
