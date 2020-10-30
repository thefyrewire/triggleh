namespace Triggleh
{
    partial class LoginForm
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
            this.web_TrigglehLogin = new Microsoft.Toolkit.Forms.UI.Controls.WebView();
            ((System.ComponentModel.ISupportInitialize)(this.web_TrigglehLogin)).BeginInit();
            this.SuspendLayout();
            // 
            // web_TrigglehLogin
            // 
            this.web_TrigglehLogin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.web_TrigglehLogin.Location = new System.Drawing.Point(0, 0);
            this.web_TrigglehLogin.MinimumSize = new System.Drawing.Size(20, 20);
            this.web_TrigglehLogin.Name = "web_TrigglehLogin";
            this.web_TrigglehLogin.Size = new System.Drawing.Size(432, 553);
            this.web_TrigglehLogin.TabIndex = 0;
            this.web_TrigglehLogin.NavigationCompleted += new System.EventHandler<Microsoft.Toolkit.Win32.UI.Controls.Interop.WinRT.WebViewControlNavigationCompletedEventArgs>(this.Web_TrigglehLogin_NavigationCompleted);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(432, 553);
            this.Controls.Add(this.web_TrigglehLogin);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Triggleh Login";
            this.Load += new System.EventHandler(this.LoginForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.web_TrigglehLogin)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Toolkit.Forms.UI.Controls.WebView web_TrigglehLogin;
    }
}