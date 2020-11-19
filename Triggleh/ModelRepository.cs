// ModelRepository

using System;
using System.Collections.Generic;
using System.Linq;

namespace Triggleh
{
    public class ModelRepository
    {
        public void ResetDatabase()
        {
            using (Model context = new Model())
            {
                context.Triggers.RemoveRange(context.Triggers);
                context.SaveChanges();
            }
        }

        // TRIGGERS
        public void AddTrigger(Trigger trigger)
        {
            using (var context = new Model())
            {
                context.Triggers.Add(new Trigger()
                {
                    Name = trigger.Name,
                    CreatedAt = DateTime.Now,
                    BitsEnabled = trigger.BitsEnabled,
                    BitsCondition = trigger.BitsCondition,
                    BitsAmount = trigger.BitsAmount,
                    BitsAmount2 = trigger.BitsAmount2,
                    UserLevelEveryone = trigger.UserLevelEveryone,
                    UserLevelSubs = trigger.UserLevelSubs,
                    UserLevelVips = trigger.UserLevelVips,
                    UserLevelMods = trigger.UserLevelMods,
                    Keywords = trigger.Keywords,
                    CharAnimTriggerKeyChar = trigger.CharAnimTriggerKeyChar,
                    CharAnimTriggerKeyValue = trigger.CharAnimTriggerKeyValue,
                    Cooldown = trigger.Cooldown,
                    CooldownUnit = trigger.CooldownUnit,
                    RewardName = trigger.RewardName
            });

                context.SaveChanges();
            }
        }

        public List<Trigger> GetTriggers()
        {
            using (Model context = new Model())
            {
                List<Trigger> triggers = context.Triggers.ToList<Trigger>();
                return triggers;
            }
        }

        public Trigger GetTriggerByName(string triggerName)
        {
            using (Model context = new Model())
            {
                Trigger triggerToGet = context.Triggers.Where(trigger => trigger.Name.ToLower() == triggerName.ToLower()).FirstOrDefault<Trigger>();
                return triggerToGet;
            }
        }

        public void UpdateTrigger(string triggerName, Trigger triggerData)
        {
            using (Model context = new Model())
            {
                Trigger triggerToUpdate = context.Triggers.Where(trigger => trigger.Name.ToLower() == triggerName.ToLower()).FirstOrDefault<Trigger>();
                triggerToUpdate.Name = triggerData.Name;
                triggerToUpdate.BitsEnabled = triggerData.BitsEnabled;
                triggerToUpdate.BitsCondition = triggerData.BitsCondition;
                triggerToUpdate.BitsAmount = triggerData.BitsAmount;
                triggerToUpdate.BitsAmount2 = triggerData.BitsAmount2;
                triggerToUpdate.UserLevelEveryone = triggerData.UserLevelEveryone;
                triggerToUpdate.UserLevelSubs = triggerData.UserLevelSubs;
                triggerToUpdate.UserLevelVips = triggerData.UserLevelVips;
                triggerToUpdate.UserLevelMods = triggerData.UserLevelMods;
                triggerToUpdate.Keywords = triggerData.Keywords;
                triggerToUpdate.CharAnimTriggerKeyChar = triggerData.CharAnimTriggerKeyChar;
                triggerToUpdate.CharAnimTriggerKeyValue = triggerData.CharAnimTriggerKeyValue;
                triggerToUpdate.Cooldown = triggerData.Cooldown;
                triggerToUpdate.CooldownUnit = triggerData.CooldownUnit;
                triggerToUpdate.RewardName = triggerData.RewardName;

                // need to ensure trigger is updated
                context.SaveChanges();
            }
        }

        private Trigger PatchTrigger(Trigger trigger)
        {
            Trigger triggerExists = GetTriggerByName(trigger.Name);
            if (triggerExists != null)
            {
                int i = 1;
                while (GetTriggerByName(trigger.Name) != null)
                {
                    trigger.Name = $"{triggerExists.Name}_{i}";
                    i++;
                }
            }
            
            trigger.UserLevelVips = trigger.UserLevelVips ? trigger.UserLevelVips : false;
            trigger.RewardName = trigger.RewardName ?? "";
            return trigger;
        }

        public void RemoveTrigger(string triggerName)
        {
            using (Model context = new Model())
            {
                Trigger triggerToGet = context.Triggers.Where(trigger => trigger.Name.ToLower() == triggerName.ToLower()).FirstOrDefault<Trigger>();
                context.Triggers.Remove(triggerToGet);

                context.SaveChanges();
            }
        }

        public void UpdateTriggerUsage(string triggerName, DateTime time)
        {
            using (Model context = new Model())
            {
                Trigger triggerToUpdate = context.Triggers.Where(trigger => trigger.Name.ToLower() == triggerName.ToLower()).FirstOrDefault<Trigger>();
                triggerToUpdate.LastTriggered = time;
                Console.WriteLine($"updating last trigger usage... {time}");

                List<Setting> settings = context.Settings.ToList<Setting>();
                if (settings.Count > 0 && time != DateTime.MinValue)
                {
                    Setting mainSettings = settings.First<Setting>();
                    mainSettings.GlobalLastTriggered = time;
                    Console.WriteLine($"updating global last trigger usage... {time}");
                }

                context.SaveChanges();
            }
        }

        public void ResetGlobalCooldown()
        {
            using (Model context = new Model())
            {
                List<Setting> settings = context.Settings.ToList<Setting>();
                if (settings.Count > 0)
                {
                    Setting mainSettings = settings.First<Setting>();
                    mainSettings.GlobalLastTriggered = DateTime.MinValue;
                    Console.WriteLine($"updating global last trigger usage... {DateTime.MinValue}");
                }

                context.SaveChanges();
            }
        }

        public void ImportTriggers(List<Trigger> triggers)
        {
            using (Model context = new Model())
            {
                List<Trigger> patchedTriggers = triggers.Select(trigger => PatchTrigger(trigger)).ToList<Trigger>();
                context.Triggers.AddRange(patchedTriggers);
                context.SaveChanges();
            }
        }


        // SETTINGS

        public Setting LoadSettings()
        {
            using (Model context = new Model())
            {
                List<Setting> settings = context.Settings.ToList<Setting>();
                if (settings.Count == 0) return null;
                return settings.First<Setting>();
            }
        }

        public void SaveSettings(Setting settingToSet)
        {
            using (Model context = new Model())
            {
                List<Setting> settings = context.Settings.ToList<Setting>();
                if (settings.Count == 0)
                {
                    context.Settings.Add(new Setting()
                    {
                        Application = settingToSet.Application,
                        Username = settingToSet.Username,
                        UserID = settingToSet.UserID,
                        ProfilePicture = settingToSet.ProfilePicture,
                        GlobalCooldown = settingToSet.GlobalCooldown,
                        GlobalCooldownUnit = settingToSet.GlobalCooldownUnit,
                        LoggingEnabled = settingToSet.LoggingEnabled
                    });
                }
                else
                {
                    Setting mainSettings = settings.First<Setting>();
                    mainSettings.Application = settingToSet.Application;
                    mainSettings.Username = settingToSet.Username;
                    mainSettings.UserID = settingToSet.UserID;
                    mainSettings.ProfilePicture = settingToSet.ProfilePicture;
                    mainSettings.GlobalCooldown = settingToSet.GlobalCooldown;
                    mainSettings.GlobalCooldownUnit = settingToSet.GlobalCooldownUnit;
                    mainSettings.LoggingEnabled = settingToSet.LoggingEnabled;
                }

                context.SaveChanges();
            }
        }
    }
}
