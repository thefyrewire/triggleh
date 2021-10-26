﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Triggleh
{
    public partial class SettingsForm : Form, ISettingsGUI
    {
        private SettingsPresenter presenter;
        public bool refreshView = false;
        public bool connectToChat = false;

        public string profilePicture = "https://static-cdn.jtvnw.net/jtv_user_pictures/twitch-profile_image-8a8c5be2e3b64a9a-300x300.png";
        public string accessToken = "";
        public string clientId = "";
        public bool didAttemptLogin = false;

        private string userID;

        public SettingsForm()
        {
            InitializeComponent();
        }

        public void Register(SettingsPresenter SP)
        {
            presenter = SP;
        }

        public void InitialiseForm()
        {
            nud_GlobalCooldown.Maximum = Decimal.MaxValue;
        }

        public string Application
        {
            get { return cmb_Applications.Text; }
        }

        public string Username
        {
            get { return txt_Username.Text; }
            set { txt_Username.Text = value; }
        }

        public string UserID
        {
            get { return userID; }
            set { userID = value; }
        }

        public string ProfilePicture
        {
            get { return profilePicture; }
            set { profilePicture = value; }
        }

        public string AccessToken
        {
            get { return accessToken; }
            set { accessToken = value; }
        }

        public string ClientID
        {
            get { return clientId; }
            set { clientId = value; }
        }

        public bool DidAttemptLogin
        {
            get { return didAttemptLogin; }
            set { didAttemptLogin = value; }
        }

        public int GlobalCooldown
        {
            set { nud_GlobalCooldown.Value = value; }
            get { return (int)nud_GlobalCooldown.Value; }
        }

        public int GlobalCooldownUnit
        {
            set { cmb_GlobalCooldownUnit.SelectedIndex = value; }
            get { return cmb_GlobalCooldownUnit.SelectedIndex; }
        }

        public bool LoggingEnabled
        {
            get { return chk_LoggingEnabled.Checked; }
            set { chk_LoggingEnabled.Checked = value; }
        }

        public int ApplicationsIndexOrLength
        {
            get { return cmb_Applications.Items.Count; }
            set { cmb_Applications.SelectedIndex = value; }
        }

        public void ShowError(bool showing)
        {
            if (showing) lbl_Account.ForeColor = Color.Red;
            else lbl_Account.ForeColor = SystemColors.ControlText;
        }

        public void CloseForm()
        {
            Close();
        }

        public void ClearApplications()
        {
            cmb_Applications.Items.Clear();
        }

        public void AddApplication(string name)
        {
            cmb_Applications.Items.Add(name);
        }

        public int GetApplicationIndex(string name)
        {
            return cmb_Applications.Items.IndexOf(name);
        }

        public void ShowHelpMessage(string message, string title)
        {
            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void ShowExportFileDialog(string data)
        {
            sfd_Export.FileName = "triggleh_export_" + DateTime.Now.ToString("yyyyMMdd");
            if (sfd_Export.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(sfd_Export.FileName, data);
            }
        }

        public string ShowImportFileDialog()
        {
            string data = "[]";

            if (ofd_Import.ShowDialog() == DialogResult.OK)
            {
                data = File.ReadAllText(ofd_Import.FileName);
            }

            return data;
        }

        public string ShowImportConfirmation()
        {
            DialogResult dialogResult = MessageBox.Show("Would you like to replace all existing triggers?\n\nSelecting no will merge in new triggers.", "Importing triggers...", MessageBoxButtons.YesNoCancel);
            return dialogResult.ToString();
        }

        public void SetRefreshView(bool refresh)
        {
            refreshView = refresh;
        }

        private void Btn_SaveSettings_Click(object sender, EventArgs e)
        {
            presenter.Btn_SaveSettings_Click();
        }

        private void Btn_RefreshList_Click(object sender, EventArgs e)
        {
            presenter.Btn_RefreshList_Click();
        }

        private void Btn_GlobalCooldownHelp_Click(object sender, EventArgs e)
        {
            presenter.Btn_GlobalCooldownHelp_Click();
        }

        private void Btn_ResetGlobalLastTriggered_Click(object sender, EventArgs e)
        {
            presenter.Btn_ResetGlobalLastTriggered_Click();
        }

        private void Btn_Export_Click(object sender, EventArgs e)
        {
            presenter.Btn_Export_Click();
        }

        private void Btn_Import_Click(object sender, EventArgs e)
        {
            presenter.Btn_Import_Click();
        }

        private void Btn_Login_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            if (loginForm.ShowDialog() == DialogResult.Cancel)
            {
                Username = loginForm.username;
                UserID = loginForm.user_id;
                AccessToken = loginForm.access_token;
                ClientID = loginForm.client_id;
                connectToChat = true;
                DidAttemptLogin = true;
            }
        }
    }
}
