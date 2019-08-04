# Triggleh

> Like Scribbleh, but Triggleh.

A small app I threw together that allows chat to interact with character streamers. You can set up specific conditions for triggers to activate! This can provide sub-only incentives and reward subs with fun ways to affect the stream, increasing viewer interaction and bit revenue as a whole.

[![Everything Is AWESOME](https://img.youtube.com/vi/StTqXEQ2l-Y/0.jpg)](https://www.youtube.com/watch?v=StTqXEQ2l-Y "Everything Is AWESOME")

## Features
* Simple, unified interface to create and manage chat-activated puppet triggers
* Control specific conditions (bits/user level/message keywords) for activation
* Trigger cooldowns to prevent spam
* Logs to see which triggers are most popular and create the most revenue

## Options

### Bits
Add a condition that means it only triggers when someone cheers. There are four condition types:

* At least
* At most
* Exactly
* Between

For example, `At least 100 bits` or `Between 200 and 400 bits`.

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

A regular keyword trigger is just a plain old word. If this message is detected in chat and passes all the other conditions, then the trigger is activated. I recommend only using these in conjunction with the bits condition, to reduce the chances of accidental activation.

Hashtag keywords are essentially the same, but require the message to contain a hashtag. This might provide a more memorable and controlled experience for your viewers. For example, you may have a variety of costumes that are available to trigger and using a hashtag in your cheer message selects a certain outfit.

Command keywords use a slightly stricter detection method. The message **must** begin with an exclamation point (!) in order to be considered. Combined with a chat bot, this could be used to provide a bot response along with the trigger. Command triggers could be especially useful for free, subscriber-only commands.

### Cooldown
To prevent spam, each trigger can be configured with a cooldown in seconds, minutes or hours. If a cooldown is currently in progress, it can be forcefully reset by click the reset button.

### Character Animator Trigger
This is the keystroke that is sent to Character Animator if a message from chat passes all of the above conditions. Multiple triggers can share the same keystroke, allowing you to create variations of the same trigger. For example, you may have a free sub-only command that allows subs to change your costume and you can also have a version for everyone that allows them to use bits to do the same thing.

## Installation
* Download the [latest release](https://github.com/thefyrewire/triggleh/releases).
* Unzip it somewhere and run.
* In Settings, add your Twitch username to connect it to your chat. You only need to do this once.
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