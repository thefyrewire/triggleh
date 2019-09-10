using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Triggleh
{
    public interface IModelRepository
    {
        void ResetDatabase();

        void AddTrigger(string Name, bool BitsEnabled, int BitsCondition, int BitsAmount, int BitsAmount2, bool UserLevelEveryone, bool UserLevelSubs, bool UserLevelMods, List<string> Keywords, string CharAnimTriggerKeyChar, int CharAnimTriggerKeyValue, int Cooldown, int CooldownUnit);
        List<Trigger> GetTriggers();
        Trigger GetTriggerByName(string triggerName);
        void UpdateTrigger(string triggerName, Trigger triggerData);
        void RemoveTrigger(string triggerName);
        void UpdateTriggerUsage(string triggerName);
        void ResetGlobalCooldown();

        void SaveSettings(Setting settings);
        void LoadSettings();
    }
}
