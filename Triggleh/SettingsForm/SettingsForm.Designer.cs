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
            this.lbl_Username = new System.Windows.Forms.Label();
            this.txt_Username = new System.Windows.Forms.TextBox();
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
            ((System.ComponentModel.ISupportInitialize)(this.nud_GlobalCooldown)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_Username
            // 
            this.lbl_Username.AutoSize = true;
            this.lbl_Username.Location = new System.Drawing.Point(26, 83);
            this.lbl_Username.Name = "lbl_Username";
            this.lbl_Username.Size = new System.Drawing.Size(138, 23);
            this.lbl_Username.TabIndex = 8;
            this.lbl_Username.Text = "Twitch username";
            // 
            // txt_Username
            // 
            this.txt_Username.Location = new System.Drawing.Point(193, 80);
            this.txt_Username.MaxLength = 25;
            this.txt_Username.Name = "txt_Username";
            this.txt_Username.Size = new System.Drawing.Size(262, 30);
            this.txt_Username.TabIndex = 2;
            // 
            // chk_LoggingEnabled
            // 
            this.chk_LoggingEnabled.AutoSize = true;
            this.chk_LoggingEnabled.Checked = true;
            this.chk_LoggingEnabled.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_LoggingEnabled.Location = new System.Drawing.Point(30, 196);
            this.chk_LoggingEnabled.Name = "chk_LoggingEnabled";
            this.chk_LoggingEnabled.Size = new System.Drawing.Size(203, 27);
            this.chk_LoggingEnabled.TabIndex = 11;
            this.chk_LoggingEnabled.Text = "Log successful triggers";
            this.chk_LoggingEnabled.UseVisualStyleBackColor = true;
            // 
            // btn_SaveSettings
            // 
            this.btn_SaveSettings.Location = new System.Drawing.Point(357, 185);
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
            // SettingsForm
            // 
            this.AcceptButton = this.btn_SaveSettings;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(487, 256);
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
            this.Controls.Add(this.lbl_Username);
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

        private System.Windows.Forms.Label lbl_Username;
        private System.Windows.Forms.TextBox txt_Username;
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
    }
}