// ModelRepository

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        // public void AddTrigger(string Name, bool BitsEnabled, int BitsCondition, int BitsAmount, int BitsAmount2, bool UserLevelEveryone, bool UserLevelSubs, bool UserLevelMods, string Keywords, string CharAnimTriggerKeyChar, int CharAnimTriggerKeyValue)
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
                    CharAnimTriggerKeyValue = trigger.CharAnimTriggerKeyValue
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
                // triggerToUpdate = triggerData;
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



        /*public void SetUsername(string username)
        {
            using (Model context = new Model())
            {
                context.Settings.First().Username = username;
                context.SaveChanges();
            }
        }*/

        public string Username
        {
            get { using (Model context = new Model()) return context.Settings.First().Username; }
            set
            {
                using (Model context = new Model())
                {
                    context.Settings.First().Username = value;
                    context.SaveChanges();
                }
            }
        }

        public bool LoggingEnabled
        {
            get { using (Model context = new Model()) return context.Settings.First().LoggingEnabled; }
            set
            {
                using (Model context = new Model())
                {
                    context.Settings.First().LoggingEnabled = value;
                    context.SaveChanges();
                }
            }
        }
    }
}
