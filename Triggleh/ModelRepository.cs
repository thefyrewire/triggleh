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
                    UserLevelMods = trigger.UserLevelMods,
                    Keywords = trigger.Keywords,
                    CharAnimTriggerKeyChar = trigger.CharAnimTriggerKeyChar,
                    CharAnimTriggerKeyValue = trigger.CharAnimTriggerKeyValue,
                    Cooldown = trigger.Cooldown,
                    CooldownUnit = trigger.CooldownUnit
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
                triggerToUpdate.UserLevelMods = triggerData.UserLevelMods;
                triggerToUpdate.Keywords = triggerData.Keywords;
                triggerToUpdate.CharAnimTriggerKeyChar = triggerData.CharAnimTriggerKeyChar;
                triggerToUpdate.CharAnimTriggerKeyValue = triggerData.CharAnimTriggerKeyValue;
                triggerToUpdate.Cooldown = triggerData.Cooldown;
                triggerToUpdate.CooldownUnit = triggerData.CooldownUnit;

                // need to ensure trigger is updated
                context.SaveChanges();
            }
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
                        Username = settingToSet.Username,
                        ProfilePicture = settingToSet.ProfilePicture,
                        LoggingEnabled = settingToSet.LoggingEnabled
                    });
                }
                else
                {
                    Setting mainSettings = settings.First<Setting>();
                    mainSettings.Username = settingToSet.Username;
                    mainSettings.ProfilePicture = settingToSet.ProfilePicture;
                    mainSettings.LoggingEnabled = settingToSet.LoggingEnabled;
                }

                context.SaveChanges();
            }
        }
    }
}
