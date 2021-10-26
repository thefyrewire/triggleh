using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Triggleh
{
    public interface ISettingsGUI
    {
        void Register(SettingsPresenter SP);

        void InitialiseForm();

        string Application { get; }
        string Username { get; set; }
        string UserID { get; set; }
        string ProfilePicture { get; set; }
        string AccessToken { get; set; }
        string ClientID { get; set; }
        bool DidAttemptLogin { get; set; }
        int GlobalCooldown { get; set; }
        int GlobalCooldownUnit { get; set; }
        bool LoggingEnabled { get; set; }
        int ApplicationsIndexOrLength { get; set; }

        void ShowError(bool showing);
        void CloseForm();
        void ClearApplications();
        void AddApplication(string name);
        int GetApplicationIndex(string name);
        void ShowHelpMessage(string message, string title);
        void ShowExportFileDialog(string data);
        string ShowImportFileDialog();
        void SetRefreshView(bool refresh);
        string ShowImportConfirmation();
    }
}
