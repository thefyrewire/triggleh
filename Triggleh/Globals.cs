using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Triggleh
{
    public static class Globals
    {
        public static readonly string HOST = "thefyrewire.com";
        public static readonly string AUTH_URL = "https://" + HOST + "/auth/triggleh?force_verify=true";
    }

    public enum CooldownUnits : int
    {
        Seconds = 0,
        Minutes = 1,
        Hours = 2
    }
}
