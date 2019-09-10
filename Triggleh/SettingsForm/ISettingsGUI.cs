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

        string Application { get; }
        string Username { get; set; }
        bool LoggingEnabled { get; set; }
        int ApplicationsIndexOrLength { get; set; }

        void ShowError(bool showing);
        void CloseForm();
        void ClearApplications();
        void AddApplication(string name);
        int GetApplicationIndex(string name);
    }
}
