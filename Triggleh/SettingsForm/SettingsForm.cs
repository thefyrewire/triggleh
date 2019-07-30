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
    public partial class SettingsForm : Form, ISettingsGUI
    {
        private SettingsPresenter presenter;
        public SettingsForm()
        {
            InitializeComponent();
        }

        public void Register(SettingsPresenter SP)
        {
            presenter = SP;
        }

        public string Username
        {
            get { return txt_Username.Text; }
            set { txt_Username.Text = value; }
        }

        public string ProfilePicture
        {
            get { return txt_Username.Text; }
            set { txt_Username.Text = value; }
        }

        public bool LoggingEnabled
        {
            get { return chk_LoggingEnabled.Checked; }
            set { chk_LoggingEnabled.Checked = value; }
        }

        public void ShowError(bool showing)
        {
            if (showing) lbl_Username.ForeColor = Color.Red;
            else lbl_Username.ForeColor = SystemColors.ControlText;
        }

        public void CloseForm()
        {
            Close();
        }

        private void Btn_SaveSettings_Click(object sender, EventArgs e)
        {
            presenter.Btn_SaveSettings_Click();
        }
    }
}
