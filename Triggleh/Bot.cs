using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

using Newtonsoft.Json;

using TwitchLib.Client;
using TwitchLib.Client.Events;
using TwitchLib.Client.Models;

namespace Triggleh
{
    class Bot
    {
        private readonly TwitchClient client;

        readonly ModelRepository repository = new ModelRepository();

        public event EventHandler BotConnected;
        public event EventHandler<BotDisconnectedArgs> BotDisconnected;
        public event EventHandler<BotTriggeredArgs> BotTriggered;

        public Bot()
        {
            ConnectionCredentials credentials = new ConnectionCredentials("justinfan42069", "password");

            client = new TwitchClient();
            client.Initialize(credentials);

            client.OnJoinedChannel += Client_OnJoinedChannel;
            client.OnLeftChannel += Client_OnLeftChannel;
            client.OnMessageReceived += Client_OnMessageReceived;

            client.Connect();
        }

        // TWITCHLIB - for chat

        private void Client_OnJoinedChannel(object sender, OnJoinedChannelArgs e)
        {
            Console.WriteLine("Just connected to " + e.Channel);
            BotConnected?.Invoke(this, e);
        }

        private void Client_OnLeftChannel(object sender, OnLeftChannelArgs e)
        {
            BotDisconnectedArgs args = new BotDisconnectedArgs { Channel = e.Channel };

            Console.WriteLine("Just left " + e.Channel);
            BotDisconnected?.Invoke(this, args);
        }

        private void Client_OnMessageReceived(object sender, OnMessageReceivedArgs e)
        {
            ChatMessage message = e.ChatMessage;

            Setting settings = repository.LoadSettings();

            List<Trigger> triggers = repository.GetTriggers();
            foreach (Trigger trigger in triggers)
            {
                TimeSpan difference = DateTime.Now - trigger.LastTriggered;
                int cooldown = trigger.Cooldown;
                switch (trigger.CooldownUnit)
                {
                    case 1:
                        cooldown *= 60;
                        break;
                    case 2:
                        cooldown *= 3600;
                        break;
                }
                if ((int) difference.TotalSeconds < cooldown && trigger.LastTriggered != DateTime.MinValue)
                {
                    Console.WriteLine("trigger on cooldown");
                    continue;
                };

                bool bitsRequired = (trigger.BitsEnabled && trigger.BitsAmount > 0);
                if (!bitsRequired && trigger.Keywords == "[]")
                {
                    Console.WriteLine("either bits or keywords needed");
                    continue;
                }

                if (bitsRequired && message.Bits == 0)
                {
                    Console.WriteLine("bits expected and none given");
                    continue;
                }

                bool validBits = false;
                switch (trigger.BitsCondition)
                {
                    case 0:
                        validBits = message.Bits >= trigger.BitsAmount;
                        break;
                    case 1:
                        validBits = message.Bits <= trigger.BitsAmount;
                        break;
                    case 2:
                        validBits = message.Bits == trigger.BitsAmount;
                        break;
                    case 3:
                        validBits = message.Bits >= trigger.BitsAmount && message.Bits <= trigger.BitsAmount2;
                        break;
                }

                if (!bitsRequired && trigger.Keywords != "[]")
                {
                    validBits = true;
                }

                if (!validBits)
                {
                    Console.WriteLine("not enough bits given");
                    continue;
                };

                if ((trigger.UserLevelEveryone || (trigger.UserLevelSubs && message.IsSubscriber) || (trigger.UserLevelMods && message.IsModerator)) == false)
                {
                    Console.WriteLine("wrong userlevel");
                    continue;
                };

                List<string> rawkeywords = JsonConvert.DeserializeObject<List<string>>(trigger.Keywords);
                MatchCollection matches = null;
                MatchCollection hmatches = null;

                if (message.Message.StartsWith("!"))
                {
                    List<string> commands = rawkeywords.Where(k => k.StartsWith("!")).Select(k => Regex.Escape(k.Substring(1))).ToList();
                    if (commands.Count == 0) continue; // no commands to look for
                    string commanded = string.Join("|", commands);
                    Regex regexCommands = new Regex(@"^!(" + commanded + @")$", RegexOptions.Compiled | RegexOptions.IgnoreCase);
                    matches = regexCommands.Matches(message.Message);
                    Console.WriteLine("commands:" + commanded);
                }
                else
                {
                    List<string> keywords = rawkeywords.Where(k => !k.StartsWith("!") && !k.StartsWith("#")).Select(k => Regex.Escape(k)).ToList();
                    List<string> hashtags = rawkeywords.Where(k => k.StartsWith("#")).Select(k => Regex.Escape(k.Substring(1))).ToList();

                    if (keywords.Count == 0 && hashtags.Count == 0) continue; // no keywords/hashtags to look for

                    if (keywords.Count > 0)
                    {
                        string keyworded = string.Join("|", keywords);
                        Regex regexKeywords = new Regex(@"\b(" + keyworded + @")\b", RegexOptions.Compiled | RegexOptions.IgnoreCase);
                        matches = regexKeywords.Matches(message.Message);
                        Console.WriteLine("keywords:" + keyworded);
                    }

                    if (hashtags.Count > 0)
                    {
                        string hashtagged = string.Join("|", hashtags);
                        Regex regexHashtags = new Regex(@"\B#(" + hashtagged + @")\b", RegexOptions.Compiled | RegexOptions.IgnoreCase);
                        hmatches = regexHashtags.Matches(message.Message);
                        Console.WriteLine("hashtags:" + hashtagged);
                    }
                }

                if ((matches == null || matches.Count == 0) && (hmatches == null || hmatches.Count == 0)) continue; // no keyword/command match

                Console.WriteLine("matched!!");
                SendKeystroke.Send(trigger.CharAnimTriggerKeyValue);

                DateTime triggeredAt = DateTime.Now;

                repository.UpdateTriggerUsage(trigger.Name, triggeredAt);

                BotTriggeredArgs args = new BotTriggeredArgs { TriggeredAt = triggeredAt };
                BotTriggered?.Invoke(this, args);

                if (settings.LoggingEnabled) Logger.Write(trigger.Name, message.DisplayName, message.Bits, message.Message);
            }
        }

        public void JoinChannel(string channel)
        {
            client.JoinChannel(channel);
        }

        public void LeaveAllChannels()
        {
            List<JoinedChannel> channels = client.JoinedChannels.ToList();
            foreach (JoinedChannel c in channels) client.LeaveChannel(c);
        }

        public bool JoinedChannel(string channel)
        {
            return client.JoinedChannels.Where(c => c.Channel == channel).ToList().Count > 0;
        }
    }

    public class BotDisconnectedArgs : EventArgs
    {
        public string Channel { get; set; }
    }

    public class BotTriggeredArgs : EventArgs
    {
        public DateTime TriggeredAt { get; set; }
    }
}