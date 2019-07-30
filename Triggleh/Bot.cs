using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

using Newtonsoft.Json;

using TwitchLib.Client;
using TwitchLib.Client.Enums;
using TwitchLib.Client.Events;
using TwitchLib.Client.Extensions;
using TwitchLib.Client.Models;

namespace Triggleh
{
    class Bot
    {
        private readonly TwitchClient client;

        readonly ModelRepository repository = new ModelRepository();

        public event EventHandler BotConnected;
        public event EventHandler<BotDisconnectedArgs> BotDisconnected;

        public Bot()
        {
            ConnectionCredentials credentials = new ConnectionCredentials("justinfan42069", "password");

            client = new TwitchClient();
            client.Initialize(credentials); // username

            client.OnLog += Client_OnLog;
            client.OnJoinedChannel += Client_OnJoinedChannel;
            client.OnLeftChannel += Client_OnLeftChannel;
            client.OnMessageReceived += Client_OnMessageReceived;
            client.OnWhisperReceived += Client_OnWhisperReceived;
            client.OnNewSubscriber += Client_OnNewSubscriber;
            client.OnConnected += Client_OnConnected;
            client.OnDisconnected += Client_OnDisconnected;
            client.OnReSubscriber += Client_OnReSubscriber;

            client.Connect();
        }

        // TWITCHLIB - for chat
        private void Client_OnLog(object sender, OnLogArgs e)
        {
            // Console.WriteLine($"{e.DateTime.ToString()}: {e.BotPUsername} - {e.Data}");
        }

        private void Client_OnConnected(object sender, OnConnectedArgs e)
        {
            // Console.WriteLine($"Connected to {e.AutoJoinChannel}");
            // client.SendMessage(e.AutoJoinChannel, "-- Triggleh Bot v0.12a running! --");
        }

        private void Client_OnDisconnected(object sender, EventArgs e)
        {
            /*EventHandler handler = BotDisconnected;
            if (handler != null) handler(this, e);*/
        }

        private void Client_OnJoinedChannel(object sender, OnJoinedChannelArgs e)
        {
            // Console.WriteLine("Hey guys! I am a bot connected via TwitchLib!");
            // client.SendMessage(e.Channel, "Hey guys! I am a bot connected via TwitchLib!");
            Console.WriteLine("Just connected to " + e.Channel);
            BotConnected?.Invoke(this, e);
        }

        private void Client_OnLeftChannel(object sender, OnLeftChannelArgs e)
        {
            BotDisconnectedArgs args = new BotDisconnectedArgs();
            args.Channel = e.Channel;

            Console.WriteLine("Just left " + e.Channel);
            BotDisconnected?.Invoke(this, args);
        }

        private void Client_OnMessageReceived(object sender, OnMessageReceivedArgs e)
        {
            /*if (e.ChatMessage.Message.Contains("badword"))
                client.TimeoutUser(e.ChatMessage.Channel, e.ChatMessage.Username, TimeSpan.FromMinutes(30), "Bad word! 30 minute timeout!");*/

            // Console.WriteLine(e.ChatMessage.DisplayName + " said: " + e.ChatMessage.Message);

            /*Regex regex = new Regex(@"\bscribs\b", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            MatchCollection matches = regex.Matches(e.ChatMessage.Message);
            if (matches.Count > 0)
            {
                // SendKeystroke.Send(Keys.NumPad9);
            }*/

            ChatMessage message = e.ChatMessage;
            // Console.WriteLine("bits seen: " + e.ChatMessage.Bits); // <---- 
            // Console.WriteLine("msg received: " + e.ChatMessage.Bits);
            if (message.Bits > 0)
            {
                Console.WriteLine($"I see bits! {message.Bits} specifically");
            }

            Setting settings = repository.LoadSettings();

            // List<Trigger> chatTriggers = repository.GetChatTriggers();
            List<Trigger> triggers = repository.GetTriggers();
            foreach (Trigger trigger in triggers)
            {
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
                    List<string> keywords = rawkeywords.Where(k => !k.StartsWith("!")).Select(k => Regex.Escape(k)).ToList();
                    if (keywords.Count == 0) continue; // no keywords to look for
                    string keyworded = string.Join("|", keywords);
                    Regex regexKeywords = new Regex(@"\b(" + keyworded + @")\b", RegexOptions.Compiled | RegexOptions.IgnoreCase);
                    matches = regexKeywords.Matches(message.Message);
                    Console.WriteLine("keywords:" + keyworded);
                }

                if (matches.Count == 0) continue; // no keyword/command match

                Console.WriteLine("matched!!");
                SendKeystroke.Send(trigger.CharAnimTriggerKeyValue);

                if (settings.LoggingEnabled) Logger.Write(trigger.Name, message.DisplayName, message.Bits, message.Message);
            }
        }

        private void Client_OnWhisperReceived(object sender, OnWhisperReceivedArgs e)
        {
            /*if (e.WhisperMessage.Username == "my_friend")
                client.SendWhisper(e.WhisperMessage.Username, "Hey! Whispers are so cool!!");*/
        }

        private void Client_OnNewSubscriber(object sender, OnNewSubscriberArgs e)
        {
            /*if (e.Subscriber.SubscriptionPlan == SubscriptionPlan.Prime)
                client.SendMessage(e.Channel, $"Welcome {e.Subscriber.DisplayName} to the substers! You just earned 500 points! So kind of you to use your Twitch Prime on this channel!");
            else
                client.SendMessage(e.Channel, $"Welcome {e.Subscriber.DisplayName} to the substers! You just earned 500 points!");*/

            // Console.WriteLine($"Welcome back to {e.Subscriber.DisplayName} and thank you for the resubscription! Full message: {e.Subscriber.SystemMessageParsed}");
        }

        private void Client_OnReSubscriber(object sender, OnReSubscriberArgs e)
        {
            // Console.WriteLine($"Welcome back to {e.ReSubscriber.DisplayName} and thank you for the resubscription! {e.ReSubscriber.Months} months! Full message: {e.ReSubscriber.SystemMessageParsed}");
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
}
