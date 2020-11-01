namespace Triggleh
{
    partial class SettingsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.lbl_Account = new System.Windows.Forms.Label();
            this.chk_LoggingEnabled = new System.Windows.Forms.CheckBox();
            this.btn_SaveSettings = new System.Windows.Forms.Button();
            this.cmb_Applications = new System.Windows.Forms.ComboBox();
            this.btn_RefreshList = new System.Windows.Forms.Button();
            this.lbl_Application = new System.Windows.Forms.Label();
            this.cmb_GlobalCooldownUnit = new System.Windows.Forms.ComboBox();
            this.lbl_GlobalCooldown = new System.Windows.Forms.Label();
            this.nud_GlobalCooldown = new System.Windows.Forms.NumericUpDown();
            this.btn_GlobalCooldownHelp = new System.Windows.Forms.Button();
            this.btn_ResetGlobalLastTriggered = new System.Windows.Forms.Button();
            this.btn_Export = new System.Windows.Forms.Button();
            this.sfd_Export = new System.Windows.Forms.SaveFileDialog();
            this.btn_Import = new System.Windows.Forms.Button();
            this.ofd_Import = new System.Windows.Forms.OpenFileDialog();
            this.button1 = new System.Windows.Forms.Button();
            this.txt_Username = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.nud_GlobalCooldown)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_Account
            // 
            this.lbl_Account.AutoSize = true;
            this.lbl_Account.Location = new System.Drawing.Point(26, 83);
            this.lbl_Account.Name = "lbl_Account";
            this.lbl_Account.Size = new System.Drawing.Size(124, 23);
            this.lbl_Account.TabIndex = 8;
            this.lbl_Account.Text = "Twitch account";
            // 
            // chk_LoggingEnabled
            // 
            this.chk_LoggingEnabled.AutoSize = true;
            this.chk_LoggingEnabled.Checked = true;
            this.chk_LoggingEnabled.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_LoggingEnabled.Location = new System.Drawing.Point(30, 185);
            this.chk_LoggingEnabled.Name = "chk_LoggingEnabled";
            this.chk_LoggingEnabled.Size = new System.Drawing.Size(203, 27);
            this.chk_LoggingEnabled.TabIndex = 11;
            this.chk_LoggingEnabled.Text = "Log successful triggers";
            this.chk_LoggingEnabled.UseVisualStyleBackColor = true;
            // 
            // btn_SaveSettings
            // 
            this.btn_SaveSettings.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btn_SaveSettings.Location = new System.Drawing.Point(357, 214);
            this.btn_SaveSettings.Name = "btn_SaveSettings";
            this.btn_SaveSettings.Size = new System.Drawing.Size(98, 43);
            this.btn_SaveSettings.TabIndex = 5;
            this.btn_SaveSettings.Text = "Save";
            this.btn_SaveSettings.UseVisualStyleBackColor = true;
            this.btn_SaveSettings.Click += new System.EventHandler(this.Btn_SaveSettings_Click);
            // 
            // cmb_Applications
            // 
            this.cmb_Applications.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_Applications.FormattingEnabled = true;
            this.cmb_Applications.Location = new System.Drawing.Point(303, 31);
            this.cmb_Applications.Name = "cmb_Applications";
            this.cmb_Applications.Size = new System.Drawing.Size(152, 31);
            this.cmb_Applications.TabIndex = 1;
            // 
            // btn_RefreshList
            // 
            this.btn_RefreshList.Location = new System.Drawing.Point(193, 31);
            this.btn_RefreshList.Name = "btn_RefreshList";
            this.btn_RefreshList.Size = new System.Drawing.Size(104, 25);
            this.btn_RefreshList.TabIndex = 7;
            this.btn_RefreshList.Text = "Refresh list";
            this.btn_RefreshList.UseVisualStyleBackColor = true;
            this.btn_RefreshList.Click += new System.EventHandler(this.Btn_RefreshList_Click);
            // 
            // lbl_Application
            // 
            this.lbl_Application.AutoSize = true;
            this.lbl_Application.Location = new System.Drawing.Point(26, 35);
            this.lbl_Application.Name = "lbl_Application";
            this.lbl_Application.Size = new System.Drawing.Size(146, 23);
            this.lbl_Application.TabIndex = 6;
            this.lbl_Application.Text = "Target application";
            // 
            // cmb_GlobalCooldownUnit
            // 
            this.cmb_GlobalCooldownUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_GlobalCooldownUnit.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmb_GlobalCooldownUnit.FormattingEnabled = true;
            this.cmb_GlobalCooldownUnit.Items.AddRange(new object[] {
            "Seconds",
            "Minutes",
            "Hours"});
            this.cmb_GlobalCooldownUnit.Location = new System.Drawing.Point(274, 129);
            this.cmb_GlobalCooldownUnit.Name = "cmb_GlobalCooldownUnit";
            this.cmb_GlobalCooldownUnit.Size = new System.Drawing.Size(75, 31);
            this.cmb_GlobalCooldownUnit.TabIndex = 4;
            // 
            // lbl_GlobalCooldown
            // 
            this.lbl_GlobalCooldown.AutoSize = true;
            this.lbl_GlobalCooldown.Location = new System.Drawing.Point(26, 131);
            this.lbl_GlobalCooldown.Name = "lbl_GlobalCooldown";
            this.lbl_GlobalCooldown.Size = new System.Drawing.Size(138, 23);
            this.lbl_GlobalCooldown.TabIndex = 9;
            this.lbl_GlobalCooldown.Text = "Global cooldown";
            // 
            // nud_GlobalCooldown
            // 
            this.nud_GlobalCooldown.Location = new System.Drawing.Point(193, 129);
            this.nud_GlobalCooldown.Name = "nud_GlobalCooldown";
            this.nud_GlobalCooldown.Size = new System.Drawing.Size(75, 30);
            this.nud_GlobalCooldown.TabIndex = 3;
            // 
            // btn_GlobalCooldownHelp
            // 
            this.btn_GlobalCooldownHelp.Location = new System.Drawing.Point(430, 129);
            this.btn_GlobalCooldownHelp.Name = "btn_GlobalCooldownHelp";
            this.btn_GlobalCooldownHelp.Size = new System.Drawing.Size(25, 25);
            this.btn_GlobalCooldownHelp.TabIndex = 10;
            this.btn_GlobalCooldownHelp.Text = "?";
            this.btn_GlobalCooldownHelp.UseVisualStyleBackColor = true;
            this.btn_GlobalCooldownHelp.Click += new System.EventHandler(this.Btn_GlobalCooldownHelp_Click);
            // 
            // btn_ResetGlobalLastTriggered
            // 
            this.btn_ResetGlobalLastTriggered.Location = new System.Drawing.Point(355, 129);
            this.btn_ResetGlobalLastTriggered.Name = "btn_ResetGlobalLastTriggered";
            this.btn_ResetGlobalLastTriggered.Size = new System.Drawing.Size(69, 25);
            this.btn_ResetGlobalLastTriggered.TabIndex = 12;
            this.btn_ResetGlobalLastTriggered.Text = "Reset";
            this.btn_ResetGlobalLastTriggered.UseVisualStyleBackColor = true;
            this.btn_ResetGlobalLastTriggered.Click += new System.EventHandler(this.Btn_ResetGlobalLastTriggered_Click);
            // 
            // btn_Export
            // 
            this.btn_Export.Location = new System.Drawing.Point(30, 231);
            this.btn_Export.Name = "btn_Export";
            this.btn_Export.Size = new System.Drawing.Size(89, 26);
            this.btn_Export.TabIndex = 13;
            this.btn_Export.Text = "Export";
            this.btn_Export.UseVisualStyleBackColor = true;
            this.btn_Export.Click += new System.EventHandler(this.Btn_Export_Click);
            // 
            // sfd_Export
            // 
            this.sfd_Export.DefaultExt = "json";
            this.sfd_Export.FileName = "triggleh_export";
            this.sfd_Export.Filter = "JSON files (*.json)|*.json";
            this.sfd_Export.RestoreDirectory = true;
            this.sfd_Export.Title = "Export triggers to file...";
            // 
            // btn_Import
            // 
            this.btn_Import.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btn_Import.Location = new System.Drawing.Point(125, 231);
            this.btn_Import.Name = "btn_Import";
            this.btn_Import.Size = new System.Drawing.Size(89, 26);
            this.btn_Import.TabIndex = 14;
            this.btn_Import.Text = "Import";
            this.btn_Import.UseVisualStyleBackColor = true;
            this.btn_Import.Click += new System.EventHandler(this.Btn_Import_Click);
            // 
            // ofd_Import
            // 
            this.ofd_Import.DefaultExt = "json";
            this.ofd_Import.Filter = "JSON files (*.json)|*.json";
            this.ofd_Import.Title = "Import triggers from file...";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(357, 80);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(98, 26);
            this.button1.TabIndex = 15;
            this.button1.Text = "Login";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Btn_Login_Click);
            // 
            // txt_Username
            // 
            this.txt_Username.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.txt_Username.Enabled = false;
            this.txt_Username.Location = new System.Drawing.Point(193, 80);
            this.txt_Username.MaxLength = 25;
            this.txt_Username.Name = "txt_Username";
            this.txt_Username.ReadOnly = true;
            this.txt_Username.Size = new System.Drawing.Size(156, 30);
            this.txt_Username.TabIndex = 2;
            // 
            // SettingsForm
            // 
            this.AcceptButton = this.btn_SaveSettings;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(487, 274);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btn_Import);
            this.Controls.Add(this.btn_Export);
            this.Controls.Add(this.btn_ResetGlobalLastTriggered);
            this.Controls.Add(this.btn_GlobalCooldownHelp);
            this.Controls.Add(this.cmb_GlobalCooldownUnit);
            this.Controls.Add(this.lbl_GlobalCooldown);
            this.Controls.Add(this.nud_GlobalCooldown);
            this.Controls.Add(this.lbl_Application);
            this.Controls.Add(this.btn_RefreshList);
            this.Controls.Add(this.cmb_Applications);
            this.Controls.Add(this.btn_SaveSettings);
            this.Controls.Add(this.chk_LoggingEnabled);
            this.Controls.Add(this.txt_Username);
            this.Controls.Add(this.lbl_Account);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "SettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Triggleh Settings";
            ((System.ComponentModel.ISupportInitialize)(this.nud_GlobalCooldown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_Account;
        private System.Windows.Forms.CheckBox chk_LoggingEnabled;
        private System.Windows.Forms.Button btn_SaveSettings;
        private System.Windows.Forms.ComboBox cmb_Applications;
        private System.Windows.Forms.Button btn_RefreshList;
        private System.Windows.Forms.Label lbl_Application;
        private System.Windows.Forms.ComboBox cmb_GlobalCooldownUnit;
        private System.Windows.Forms.Label lbl_GlobalCooldown;
        private System.Windows.Forms.NumericUpDown nud_GlobalCooldown;
        private System.Windows.Forms.Button btn_GlobalCooldownHelp;
        private System.Windows.Forms.Button btn_ResetGlobalLastTriggered;
        private System.Windows.Forms.Button btn_Export;
        private System.Windows.Forms.SaveFileDialog sfd_Export;
        private System.Windows.Forms.Button btn_Import;
        private System.Windows.Forms.OpenFileDialog ofd_Import;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txt_Username;
    }
}