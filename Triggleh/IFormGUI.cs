using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Triggleh
{
    public interface IFormGUI
    {
        void register(FormPresenter FM);
        string triggerName { get; set; }
        bool bitsEnabled { get; set; }
        int bitsCondition { get; set; }
        bool bitsConditionEnabled { get; set; }
        int bitsAmount1 { get; set; }
        bool bitsAmount1Enabled { get; set; }
        int bitsAmount2 { get; set; }
        bool bitsAmount2Visible { get; set; }
        string bitsInfo1 { get; set; }
        bool bitsInfo2 { get; set; }
        bool userlevelEveryone { get; set; }
        bool userlevelSubs { get; set; }
        bool userlevelMods { get; set; }
        int AddKeyword(string keyword);
        void RemoveKeyword(int index);
        string charanimTriggerKey { get; set; }

        void ResetDetails();


    }
}
