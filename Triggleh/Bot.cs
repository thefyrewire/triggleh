using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

using Newtonsoft.Json;

using TwitchLib.Client;
using TwitchLib.Client.Events;
using TwitchLib.Client.Models;
using TwitchLib.PubSub;
using TwitchLib.PubSub.Events;

namespace Triggleh
{
    class Bot
    {
        private readonly TwitchClient client;
        private readonly TwitchPubSub pubsub;

        private readonly ModelRepository repository = new ModelRepository();

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

            pubsub = new TwitchPubSub();
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

            if (message.Channel.ToLower() != settings.Username.ToLower())
            {
                Console.WriteLine("wrong timeline, friend");
                return;
            }
            
            if (String.IsNullOrEmpty(settings.Application))
            {
                Console.WriteLine("is there any point?");
                return;
            }

            if (IsOnCooldown(settings.GlobalLastTriggered, settings.GlobalCooldown, settings.GlobalCooldownUnit))
            {
                Console.WriteLine("trigger on global cooldown");
                return;
            }

            List<Trigger> triggers = repository.GetTriggers().Where(trigger => String.IsNullOrEmpty(trigger.RewardName)).ToList<Trigger>();
            foreach (Trigger trigger in triggers)
            {
                if (IsOnCooldown(trigger.LastTriggered, trigger.Cooldown, trigger.CooldownUnit))
                {
                    Console.WriteLine("trigger on cooldown");
                    continue;
                }

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

                if (message.IsBroadcaster == false && (trigger.UserLevelEveryone || (trigger.UserLevelSubs && message.IsSubscriber) || (trigger.UserLevelMods && message.IsModerator)) == false)
                {
                    Console.WriteLine("wrong userlevel");
                    continue;
                };

                if (!PassesKeywordCheck(trigger.Keywords, message.Message)) continue;

                Console.WriteLine("matched!!");
                SendKeystroke.Send(settings.Application, trigger.CharAnimTriggerKeyValue);

                DateTime triggeredAt = DateTime.Now;

                repository.UpdateTriggerUsage(trigger.Name, triggeredAt);

                BotTriggeredArgs args = new BotTriggeredArgs { TriggeredAt = triggeredAt };
                BotTriggered?.Invoke(this, args);

                if (settings.LoggingEnabled) Logger.Write(trigger.Name, message.DisplayName, message.Bits, message.Message);
            }
        }

        private bool IsOnCooldown(DateTime lastTriggered, int cooldown, int cooldownUnit)
        {
            TimeSpan difference = DateTime.Now - lastTriggered;
            switch (cooldownUnit)
            {
                case 1:
                    cooldown *= 60;
                    break;
                case 2:
                    cooldown *= 3600;
                    break;
            }

            return ((int)difference.TotalSeconds < cooldown && lastTriggered != DateTime.MinValue);
        }

        public void JoinChannel(string channel)
        {
            client.JoinChannel(channel);
        }

        public List<string> GetAllChannels()
        {
            List<string> channels = client.JoinedChannels.ToList().Select(c => c.Channel).ToList<string>();
            return channels;
        }

        public void LeaveAllChannels(string username)
        {
            List<JoinedChannel> channels = client.JoinedChannels.ToList();
            int totalChannels = channels.Count;
            int currentCount = 0;
            foreach (JoinedChannel c in channels)
            {
                client.LeaveChannel(c);
                currentCount++;
                if (currentCount >= totalChannels)
                {
                    client.JoinChannel(username);
                }
            }
        }

        public bool JoinedChannel(string channel)
        {
            return client.JoinedChannels.Where(c => c.Channel == channel).ToList().Count > 0;
        }


        // TWITCHPUBSUB - for rewards

        public void ConnectToPubSub(string userID)
        {
            Console.WriteLine("Connecting to PubSub...");
            pubsub.OnPubSubServiceConnected += PubSub_OnPubSubServiceConnected;
            pubsub.OnListenResponse += PubSub_OnListenResponse;
            pubsub.OnRewardRedeemed += PubSub_OnRewardRedeemed;

            pubsub.ListenToRewards(userID);

            pubsub.Connect();
        }

        private void PubSub_OnPubSubServiceConnected(object sender, EventArgs e)
        {
            pubsub.SendTopics();
        }

        private void PubSub_OnListenResponse(object sender, OnListenResponseArgs e)
        {
            if (e.Successful)
                Console.WriteLine("Listening to " + e.Topic + " successfully!");
            else
                Console.WriteLine("Couldn't start listening to " + e.Topic + "...");
        }

        private void PubSub_OnRewardRedeemed(object sender, OnRewardRedeemedArgs e)
        {
            Console.WriteLine(e.RewardTitle.Trim() + " was redeemed!");

            bool useKeywords = !String.IsNullOrEmpty(e.Message);

            Setting settings = repository.LoadSettings();

            if (String.IsNullOrEmpty(settings.Application))
            {
                Console.WriteLine("is there any point?");
                return;
            }

            List<Trigger> triggers = repository.GetTriggers().Where(trigger => !String.IsNullOrEmpty(trigger.RewardName)).ToList<Trigger>();
            foreach (Trigger trigger in triggers)
            {
                if (trigger.RewardName != e.RewardTitle.Trim())
                    continue;

                if (useKeywords)
                {
                    if (!PassesKeywordCheck(trigger.Keywords, e.Message)) continue;
                }

                Console.WriteLine("matched!!");
                SendKeystroke.Send(settings.Application, trigger.CharAnimTriggerKeyValue);

                DateTime triggeredAt = DateTime.Now;

                repository.UpdateTriggerUsage(trigger.Name, triggeredAt);

                BotTriggeredArgs args = new BotTriggeredArgs { TriggeredAt = triggeredAt };
                BotTriggered?.Invoke(this, args);

                if (settings.LoggingEnabled) Logger.Write($"{trigger.Name} (REWARD: {e.RewardTitle.Trim()})", e.DisplayName, e.RewardCost, e.Message);

                if (useKeywords)
                    break;
            }
        }

        private bool PassesKeywordCheck(string stringifiedkeywords, string message)
        {
            List<string> rawkeywords = JsonConvert.DeserializeObject<List<string>>(stringifiedkeywords);
            MatchCollection matches = null;
            MatchCollection hmatches = null;

            if (message.StartsWith("!"))
            {
                List<string> commands = rawkeywords.Where(k => k.StartsWith("!")).Select(k => Regex.Escape(k.Substring(1))).ToList();
                if (commands.Count == 0) return false; // no commands to look for
                string commanded = string.Join("|", commands);
                Regex regexCommands = new Regex(@"^!(" + commanded + @")$", RegexOptions.Compiled | RegexOptions.IgnoreCase);
                matches = regexCommands.Matches(message);
                Console.WriteLine("commands:" + commanded);
            }
            else
            {
                List<string> keywords = rawkeywords.Where(k => !k.StartsWith("!") && !k.StartsWith("#")).Select(k => Regex.Escape(k)).ToList();
                List<string> hashtags = rawkeywords.Where(k => k.StartsWith("#")).Select(k => Regex.Escape(k.Substring(1))).ToList();

                if (keywords.Count == 0 && hashtags.Count == 0) return false; // no keywords/hashtags to look for

                if (keywords.Count > 0)
                {
                    string keyworded = string.Join("|", keywords);
                    Regex regexKeywords = new Regex(@"\b(" + keyworded + @")\b", RegexOptions.Compiled | RegexOptions.IgnoreCase);
                    matches = regexKeywords.Matches(message);
                    Console.WriteLine("keywords:" + keyworded);
                }

                if (hashtags.Count > 0)
                {
                    string hashtagged = string.Join("|", hashtags);
                    Regex regexHashtags = new Regex(@"\B#(" + hashtagged + @")\b", RegexOptions.Compiled | RegexOptions.IgnoreCase);
                    hmatches = regexHashtags.Matches(message);
                    Console.WriteLine("hashtags:" + hashtagged);
                }
            }

            if ((matches == null || matches.Count == 0) && (hmatches == null || hmatches.Count == 0)) return false; // no keyword/command match

            return true;
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