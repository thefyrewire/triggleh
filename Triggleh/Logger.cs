using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Triggleh
{
    class Logger
    {
        private readonly static string path = $"./logs/triggleh-{DateTime.Now.Year}-{DateTime.Now.Month.ToString().PadLeft(2, '0')}.txt";

        public Logger()
        {
            Console.WriteLine(path);
            if (!Directory.Exists(path)) Directory.CreateDirectory(Path.GetDirectoryName(path));
        }

        public static void Write(string trigger, string user, int amount, string rawMessage)
        {
            string logMessage = $"[{DateTime.Now}] - {user} -> {trigger}{(amount > 0 ? $" ({amount})" : "")} - \"{rawMessage}\"\n";
            File.AppendAllText(path, logMessage);
        }
    }
}
