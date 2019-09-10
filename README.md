# Triggleh

> Like Scribbleh, but Triggleh.

A small app I threw together that allows chat to interact with character streamers. You can set up specific conditions for triggers to activate! This can provide sub-only incentives and reward subs with fun ways to affect the stream, increasing viewer interaction and bit revenue as a whole.

Click below for a video demonstration of Triggleh, brought to you by the sexiest dog on Twitch, Cazzler (and Bradley).

[![Triggleh, with Cazzler](https://i.imgur.com/gHT6zXo.png)](https://youtu.be/yH8rP_X3qog "Triggleh, with Cazzler")

## Features
* Simple, unified interface to create and manage chat-activated puppet triggers
* Control specific conditions (bits/user level/message keywords) for activation
* Trigger cooldowns to prevent spam
* Monthly logs to see which triggers are most popular and create the most revenue

## Options

### Bits
Add a condition that means it only triggers when someone cheers. There are four condition types:

* At least
* At most
* Exactly
* Between

For example, `At least 100 bits` or `Between 200 and 400 bits` (inclusive).

### User Level
Restrict the trigger to a certain user rank:

* Everyone
* Subscriber
* Moderator

### Keywords
Specific keywords that can be used to activate the trigger. There are three types:

* Regular
* Hashtag
* Command

##### Regular
A regular keyword trigger is just a plain old word. If this message is detected in chat and passes all the other conditions, then the trigger is activated. I recommend only using these in conjunction with the bits condition, to reduce the chances of accidental activation.

##### Hashtag
Hashtag keywords are essentially the same, but require the message to contain a hashtag. This might provide a more memorable and controlled experience for your viewers. For example, you may have a variety of costumes that are available to trigger and using a hashtag in your cheer message selects a certain outfit.

##### Command
Command keywords use a slightly stricter detection method. The message **must** begin with an exclamation point (!) in order to be considered. Combined with a chatbot, this could be used to provide a bot response along with the trigger. Command triggers could be especially useful for free, subscriber-only commands.

### Cooldown
To prevent spam, each trigger can be configured with a cooldown in seconds, minutes or hours. If a cooldown is currently in progress, it can be forcefully reset by clicking the reset button.

##### Global Cooldown
This can be found in Settings. The global cooldown applies to *all* triggers. During this period, none of the triggers can be used. This is useful for preventing people from spamming multiple different triggers in a short period. Similar to the individual trigger cooldowns, it can be forcefully reset.

### Keystroke Trigger
This is the keystroke that is sent to Character Animator if a message from chat passes all of the above conditions. Multiple triggers can share the same keystroke, allowing you to create variations of the same trigger. For example, you may have a free sub-only command that allows subs to change your costume and you can also have a version for everyone that allows them to use bits to do the same thing.

## Installation
* Download the [latest release](https://github.com/thefyrewire/triggleh/releases).
* Unzip it somewhere and run.
* In Settings, add your Twitch username to connect it to your chat and select the target application (if it isn't running yet, start it and refresh the list). You only need to do this once. From now on, when starting Triggleh, it will automatically connect to your chat and attempt to detect the application.
* Start creating triggers!

## Links
* [Twitter](https://twitter.com/MikeyHay)
* [Twitch](https://twitch.tv/thefyrewire)
* [Discord](https://discord.thefyrewire.com)

### Special Thanks

#### Cazzler
* [Twitter](https://twitter.com/mrcazzler)
* [Twitch](https://twitch.tv/cazzler)

#### Scribbleh
* [Twitter](https://twitter.com/scribbleh)
* [Twitch](https://twitch.tv/scribbleh)

#### Grif_N_More
* [Twitter](https://twitter.com/GrifNMore)
* [Twitch](https://twitch.tv/grif_n_more)