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

        string Username { get; set; }
        bool LoggingEnabled { get; set; }
    }
}
