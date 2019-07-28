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

        public void register(FormPresenter FP)
        {
            presenter = FP;
        }

        public string triggerName
        {
            set { txt_TriggerName.Text = value; }
            get { return txt_TriggerName.Text; }
        }

        public bool bitsEnabled
        {
            set { chk_Bits.Checked = value; }
            get { return chk_Bits.Checked; }
        }

        public int bitsCondition
        {
            set { cmb_Bits.SelectedIndex = value; }
            get { return cmb_Bits.SelectedIndex; }
        }

        public bool bitsConditionEnabled
        {
            set { cmb_Bits.Enabled = value; }
            get { return cmb_Bits.Enabled; }
        }

        public int bitsAmount1
        {
            set { nud_Bits1.Value = value; }
            get { return (int) nud_Bits1.Value; }
        }

        public bool bitsAmount1Enabled
        {
            set { nud_Bits1.Enabled = value; }
            get { return nud_Bits1.Enabled; }
        }

        public int bitsAmount2
        {
            set { nud_Bits2.Value = value; }
            get { return (int) nud_Bits2.Value; }
        }

        public bool bitsAmount2Visible
        {
            set { nud_Bits2.Visible = value; }
            get { return nud_Bits2.Visible; }
        }

        public string bitsInfo1
        {
            set { lbl_BitsInfo1.Text = value; }
            get { return lbl_BitsInfo1.Text; }
        }

        public bool bitsInfo2
        {
            set { lbl_BitsInfo2.Visible = value; }
            get { return lbl_BitsInfo2.Visible; }
        }

        public bool userlevelEveryone
        {
            set { chk_ULEveryone.Checked = value; }
            get { return chk_ULEveryone.Checked; }
        }

        public bool userlevelSubs
        {
            set { chk_ULSubs.Checked = value; }
            get { return chk_ULSubs.Checked; }
        }

        public bool userlevelMods
        {
            set { chk_ULMods.Checked = value; }
            get { return chk_ULMods.Checked; }
        }

        public int AddKeyword(string keyword)
        {
            return lst_Keywords.Items.Add(keyword);
        }

        public void RemoveKeyword(int index)
        {
            lst_Keywords.Items.RemoveAt(index);
        }

        public void ClearKeywords()
        {
            txt_Keywords.Clear();
            lst_Keywords.Items.Clear();
        }

        public string charanimTriggerKey
        {
            set { lbl_CHTriggerKey.Text = value; }
            get { return lbl_CHTriggerKey.Text; }
        }

        public void ResetDetails()
        {
            triggerName = "";
            bitsEnabled = false;
            bitsCondition = -1;
            bitsConditionEnabled = false;
            bitsAmount1 = 0;
            bitsAmount1Enabled = false;
            bitsInfo1 = "bits";
            bitsAmount2 = 0;
            bitsAmount2Visible = false;
            bitsInfo2 = false;
            userlevelEveryone = true;
            userlevelSubs = false;
            userlevelMods = false;
            ClearKeywords();
            charanimTriggerKey = "None";
        }

        private void btn_SaveTrigger_Click(object sender, EventArgs e)
        {
            // save trigger
        }
    }
}
