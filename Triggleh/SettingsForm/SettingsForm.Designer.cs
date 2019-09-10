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
            this.btn_Refresh = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbl_Username
            // 
            this.lbl_Username.AutoSize = true;
            this.lbl_Username.Location = new System.Drawing.Point(26, 115);
            this.lbl_Username.Name = "lbl_Username";
            this.lbl_Username.Size = new System.Drawing.Size(138, 23);
            this.lbl_Username.TabIndex = 0;
            this.lbl_Username.Text = "Twitch username";
            // 
            // txt_Username
            // 
            this.txt_Username.Location = new System.Drawing.Point(193, 112);
            this.txt_Username.MaxLength = 25;
            this.txt_Username.Name = "txt_Username";
            this.txt_Username.Size = new System.Drawing.Size(262, 30);
            this.txt_Username.TabIndex = 1;
            // 
            // chk_LoggingEnabled
            // 
            this.chk_LoggingEnabled.AutoSize = true;
            this.chk_LoggingEnabled.Checked = true;
            this.chk_LoggingEnabled.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_LoggingEnabled.Location = new System.Drawing.Point(30, 177);
            this.chk_LoggingEnabled.Name = "chk_LoggingEnabled";
            this.chk_LoggingEnabled.Size = new System.Drawing.Size(203, 27);
            this.chk_LoggingEnabled.TabIndex = 2;
            this.chk_LoggingEnabled.Text = "Log successful triggers";
            this.chk_LoggingEnabled.UseVisualStyleBackColor = true;
            // 
            // btn_SaveSettings
            // 
            this.btn_SaveSettings.Location = new System.Drawing.Point(357, 166);
            this.btn_SaveSettings.Name = "btn_SaveSettings";
            this.btn_SaveSettings.Size = new System.Drawing.Size(98, 43);
            this.btn_SaveSettings.TabIndex = 3;
            this.btn_SaveSettings.Text = "Save";
            this.btn_SaveSettings.UseVisualStyleBackColor = true;
            this.btn_SaveSettings.Click += new System.EventHandler(this.Btn_SaveSettings_Click);
            // 
            // cmb_Applications
            // 
            this.cmb_Applications.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_Applications.FormattingEnabled = true;
            this.cmb_Applications.Location = new System.Drawing.Point(193, 31);
            this.cmb_Applications.Name = "cmb_Applications";
            this.cmb_Applications.Size = new System.Drawing.Size(262, 31);
            this.cmb_Applications.TabIndex = 4;
            // 
            // btn_RefreshList
            // 
            this.btn_RefreshList.Location = new System.Drawing.Point(193, 62);
            this.btn_RefreshList.Name = "btn_RefreshList";
            this.btn_RefreshList.Size = new System.Drawing.Size(104, 25);
            this.btn_RefreshList.TabIndex = 5;
            this.btn_RefreshList.Text = "Refresh list";
            this.btn_RefreshList.UseVisualStyleBackColor = true;
            this.btn_RefreshList.Click += new System.EventHandler(this.Btn_RefreshList_Click);
            // 
            // lbl_Application
            // 
            this.lbl_Application.AutoSize = true;
            this.lbl_Application.Location = new System.Drawing.Point(26, 34);
            this.lbl_Application.Name = "lbl_Application";
            this.lbl_Application.Size = new System.Drawing.Size(146, 23);
            this.lbl_Application.TabIndex = 6;
            this.lbl_Application.Text = "Target application";
            // 
            // btn_Refresh
            // 
            this.btn_Refresh.Location = new System.Drawing.Point(318, 62);
            this.btn_Refresh.Name = "btn_Refresh";
            this.btn_Refresh.Size = new System.Drawing.Size(137, 25);
            this.btn_Refresh.TabIndex = 7;
            this.btn_Refresh.Text = "Refresh connection";
            this.btn_Refresh.UseVisualStyleBackColor = true;
            // 
            // SettingsForm
            // 
            this.AcceptButton = this.btn_SaveSettings;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(487, 233);
            this.Controls.Add(this.btn_Refresh);
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
        private System.Windows.Forms.Button btn_Refresh;
    }
}