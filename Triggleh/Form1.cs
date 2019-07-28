using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Triggleh
{
    public partial class Form1 : Form, IFormGUI
    {
        private FormPresenter presenter;

        public Form1()
        {
            InitializeComponent();

            // new Bot();
            // new Config();
        }

        public void Register(FormPresenter FP)
        {
            presenter = FP;
        }

        public string TriggerName
        {
            set { txt_TriggerName.Text = value; }
            get { return txt_TriggerName.Text; }
        }

        public bool BitsEnabled
        {
            set { chk_Bits.Checked = value; }
            get { return chk_Bits.Checked; }
        }

        public int BitsCondition
        {
            set { cmb_Bits.SelectedIndex = value; }
            get { return cmb_Bits.SelectedIndex; }
        }

        public bool BitsConditionEnabled
        {
            set { cmb_Bits.Enabled = value; }
            get { return cmb_Bits.Enabled; }
        }

        public int BitsAmount1
        {
            set { nud_Bits1.Value = value; }
            get { return (int) nud_Bits1.Value; }
        }

        public bool BitsAmount1Enabled
        {
            set { nud_Bits1.Enabled = value; }
            get { return nud_Bits1.Enabled; }
        }

        public int BitsAmount2
        {
            set { nud_Bits2.Value = value; }
            get { return (int) nud_Bits2.Value; }
        }

        public bool BitsAmount2Visible
        {
            set { nud_Bits2.Visible = value; }
            get { return nud_Bits2.Visible; }
        }

        public string BitsInfo1
        {
            set { lbl_BitsInfo1.Text = value; }
            get { return lbl_BitsInfo1.Text; }
        }

        public bool BitsInfo2
        {
            set { lbl_BitsInfo2.Visible = value; }
            get { return lbl_BitsInfo2.Visible; }
        }

        public bool UserLevelEveryone
        {
            set { chk_ULEveryone.Checked = value; }
            get { return chk_ULEveryone.Checked; }
        }

        public bool UserLevelSubs
        {
            set { chk_ULSubs.Checked = value; }
            get { return chk_ULSubs.Checked; }
        }
        public bool UserLevelSubsEnabled
        {
            set { chk_ULSubs.Enabled = value; }
            get { return chk_ULSubs.Enabled; }
        }

        public bool UserLevelMods
        {
            set { chk_ULMods.Checked = value; }
            get { return chk_ULMods.Checked; }
        }

        public bool UserLevelModsEnabled
        {
            set { chk_ULMods.Enabled = value; }
            get { return chk_ULMods.Enabled; }
        }

        public string Keyword
        {
            set { txt_Keywords.Text = value; }
            get { return txt_Keywords.Text; }
        }

        public int AddKeyword(string keyword)
        {
            txt_Keywords.Clear();
            return lst_Keywords.Items.Add(keyword);
        }

        public void RemoveKeyword(int index)
        {
            lst_Keywords.Items.RemoveAt(index);
            lst_Keywords.SelectedIndex = lst_Keywords.Items.Count - 1;
        }

        public void ClearKeywords()
        {
            txt_Keywords.Clear();
            lst_Keywords.Items.Clear();
        }

        public int KeywordsIndex
        {
            set { lst_Keywords.SelectedIndex = value; }
            get { return lst_Keywords.SelectedIndex; }
        }

        public string CharAnimTriggerKey
        {
            set { lbl_CHTriggerKey.Text = value; }
            get { return lbl_CHTriggerKey.Text; }
        }

        public void ResetDetails()
        {
            TriggerName = "";
            BitsEnabled = false;
            EnableBits(false);
            UserLevelEveryone = true;
            AllowSubsMods(false);
            ClearKeywords();
            CharAnimTriggerKey = "None";
        }

        public void EnableBits(bool enabled)
        {
            BitsCondition = (enabled) ? 0 : -1;
            BitsConditionEnabled = enabled;
            BitsAmount1 = 0;
            BitsAmount1Enabled = enabled;
            BitsInfo1 = "bits";
            BitsAmount2 = 0;
            BitsAmount2Visible = false;
            BitsInfo2 = false;
        }

        public void EnableBitsBetween(bool enabled)
        {
            BitsInfo1 = (enabled) ? "and" : "bits";
            BitsAmount2 = 0;
            BitsAmount2Visible = enabled;
            BitsInfo2 = enabled;
        }

        public void AllowSubsMods(bool allowed)
        {
            UserLevelSubs = false;
            UserLevelSubsEnabled = allowed;
            UserLevelMods = false;
            UserLevelModsEnabled = allowed;
        }

        public void SetKeywordIndex(int index)
        {
            lst_Keywords.SelectedIndex = index;
        }

        public void SetAddKeywordAccept()
        {
            ActiveForm.AcceptButton = btn_AddKeyword;
        }

        public bool RecordingTrigger { get; set; }

        public void StartRecordingTrigger()
        {
            if (RecordingTrigger)
            {
                StopRecordingTrigger();
                return;
            };

            RecordingTrigger = true;
            btn_RecordTrigger.Text = "Waiting...";
            btn_RecordTrigger.KeyDown += Btn_RecordTrigger_KeyDown;
        }

        public void StopRecordingTrigger()
        {
            btn_RecordTrigger.KeyDown -= Btn_RecordTrigger_KeyDown;
            btn_RecordTrigger.Text = "Record";
            RecordingTrigger = false;
        }

        private void Btn_SaveTrigger_Click(object sender, EventArgs e)
        {
            // save trigger
        }

        private void Chk_Bits_CheckedChanged(object sender, EventArgs e)
        {
            presenter.Chk_Bits_CheckedChanged();
        }

        private void Cmb_Bits_SelectedIndexChanged(object sender, EventArgs e)
        {
            presenter.Cmb_Bits_SelectedIndexChanged();
        }

        private void Chk_ULEveryone_CheckedChanged(object sender, EventArgs e)
        {
            presenter.Chk_ULEveryone_CheckedChanged();
        }

        private void Txt_Keywords_Enter(object sender, EventArgs e)
        {
            presenter.Txt_Keywords_Enter();
        }

        private void Btn_AddKeyword_Click(object sender, EventArgs e)
        {
            presenter.Btn_AddKeyword_Click();
        }

        private void Btn_RemoveKeyword_Click(object sender, EventArgs e)
        {
            presenter.Btn_RemoveKeyword_Click();
        }

        private void Btn_RecordTrigger_Click(object sender, EventArgs e)
        {
            presenter.Btn_RecordTrigger_Click();
        }

        private void Btn_RecordTrigger_KeyDown(object sender, KeyEventArgs e)
        {
            presenter.Btn_RecordTrigger_KeyDown(e.KeyCode.ToString(), e.KeyValue);
        }
    }
}
