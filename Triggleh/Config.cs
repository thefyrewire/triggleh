using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Triggleh
{
    public class Config
    {
        public Config()
        {
            string path = "./config.json";
            JObject data;
            if (File.Exists(path))
            {
                data = JObject.Parse(File.ReadAllText(path));
                Console.WriteLine(data["displayName"]);
            }
            else
            {
                Console.WriteLine("No config found...");
            }
        }
    }
}
