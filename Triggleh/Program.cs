using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Triggleh
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            // Application.Run(new Form1());

            Form1 f1 = new Form1();
            new FormPresenter(f1);
            Application.Run(f1);

            /*
             -- High DPI Support
                <System.Windows.Forms.ApplicationConfigurationSection>
                  <add key="DpiAwareness" value="PerMonitorV2" />
                </System.Windows.Forms.ApplicationConfigurationSection>
            */
        }
    }
}
