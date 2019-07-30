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
            this.lbl_Username = new System.Windows.Forms.Label();
            this.txt_Username = new System.Windows.Forms.TextBox();
            this.chk_LoggingEnabled = new System.Windows.Forms.CheckBox();
            this.btn_SaveSettings = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbl_Username
            // 
            this.lbl_Username.AutoSize = true;
            this.lbl_Username.Location = new System.Drawing.Point(26, 31);
            this.lbl_Username.Name = "lbl_Username";
            this.lbl_Username.Size = new System.Drawing.Size(140, 23);
            this.lbl_Username.TabIndex = 0;
            this.lbl_Username.Text = "Twitch Username";
            // 
            // txt_Username
            // 
            this.txt_Username.Location = new System.Drawing.Point(193, 28);
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
            this.chk_LoggingEnabled.Location = new System.Drawing.Point(30, 78);
            this.chk_LoggingEnabled.Name = "chk_LoggingEnabled";
            this.chk_LoggingEnabled.Size = new System.Drawing.Size(203, 27);
            this.chk_LoggingEnabled.TabIndex = 2;
            this.chk_LoggingEnabled.Text = "Log successful triggers";
            this.chk_LoggingEnabled.UseVisualStyleBackColor = true;
            // 
            // btn_SaveSettings
            // 
            this.btn_SaveSettings.Location = new System.Drawing.Point(307, 131);
            this.btn_SaveSettings.Name = "btn_SaveSettings";
            this.btn_SaveSettings.Size = new System.Drawing.Size(148, 45);
            this.btn_SaveSettings.TabIndex = 3;
            this.btn_SaveSettings.Text = "Save";
            this.btn_SaveSettings.UseVisualStyleBackColor = true;
            this.btn_SaveSettings.Click += new System.EventHandler(this.Btn_SaveSettings_Click);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(487, 197);
            this.Controls.Add(this.btn_SaveSettings);
            this.Controls.Add(this.chk_LoggingEnabled);
            this.Controls.Add(this.txt_Username);
            this.Controls.Add(this.lbl_Username);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "SettingsForm";
            this.Text = "Triggleh Settings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_Username;
        private System.Windows.Forms.TextBox txt_Username;
        private System.Windows.Forms.CheckBox chk_LoggingEnabled;
        private System.Windows.Forms.Button btn_SaveSettings;
    }
}