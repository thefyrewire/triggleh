using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace Triggleh
{
    class SendKeystroke
    {
        [DllImport("User32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int uMsg, int wParam, string lParam);

        const string processName = "Character Animator";

        public static void Send(int key) // Keys key
        {
            Process[] charAnimProcesses = Process.GetProcessesByName(processName);
            if (charAnimProcesses.Length == 0)
            {
                Console.WriteLine("Character Animator not running...");
            }
            else
            {
                Console.WriteLine($"{charAnimProcesses[0].ProcessName} - {charAnimProcesses[0].MainWindowTitle}");
                SendMessage(charAnimProcesses[0].MainWindowHandle, 0x0104, key, null);
            }
        }

        public static bool CharAnimRunning
        {
            get
            {
                Process[] charAnimProcesses = Process.GetProcessesByName(processName);
                return !(charAnimProcesses.Length == 0);
            }
            
        }
    }
}
