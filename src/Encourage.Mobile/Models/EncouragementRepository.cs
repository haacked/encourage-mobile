using System;
using System.Collections.Generic;

namespace Encourage.Mobile.Models
{
    public class EncouragementRepository
    {
        static readonly Random _random = new Random();

        readonly Dictionary<string, List<Encouragement>> _encouragements
            = new Dictionary<string, List<Encouragement>>
        {
            {
                "Sad",
                new List<Encouragement>
                {
                    new Encouragement { Message = "It's ok to feel sad. Know that people love you." },
                    new Encouragement { Message = "Sometimes I feel sad, then I fart and I'm not so sad." },
                    new Encouragement { Message = "You can get through it!" },
                    new Encouragement { Message = "You're really wonderful!" },
                    new Encouragement { Message = "Sorry to hear it, you good looking friend!" },
                    new Encouragement { Message = "Everyone gets sad from time to time, even wonderful people like you!" }
                }
            },
            {
                "Bored",
                new List<Encouragement>
                {
                    new Encouragement { Message = "It sucks to be bored. Hope you find something fun to do." },
                    new Encouragement { Message = "You can get through it!" },
                    new Encouragement { Message = "Maybe play a game?" },
                    new Encouragement { Message = "When I'm bored I go read a book." }
                }
            },
            {
                "Frustrated",
                new List<Encouragement>
                {
                    new Encouragement { Message = "I know it's frustrating, but you can do it!" },
                    new Encouragement { Message = "I know it's frustrating, but I believe in you!" },
                    new Encouragement { Message = "Well you're still pretty awesome" },
                    new Encouragement { Message = "You're cool!" }
                }
            },
            {
                "Angry",
                new List<Encouragement>
                {
                    new Encouragement { Message = "Grrr! I'll be angry with you." },
                    new Encouragement { Message = "Take a deep breath. Ok, breathe it out." },
                    new Encouragement { Message = "Need me to hurt someone for you?" },
                    new Encouragement { Message = "Want a hug? If I had arms I would hug you." },
                    new Encouragement { Message = "Poop" }
                }
            },
            {
                "Happy",
                new List<Encouragement>
                {
                    new Encouragement { Message = "Yay! You're the best!" },
                    new Encouragement { Message = "So am I! Feels good, right?" },
                    new Encouragement { Message = "That's great! And so are you!" },
                    new Encouragement { Message = "Nice job!" },
                    new Encouragement { Message = "Way to go!" },
                    new Encouragement { Message = "You rock!" },
                    new Encouragement { Message = "FTW!" },
                    new Encouragement { Message = "Nailed it!" },
                    new Encouragement { Message = "Great job good looking!" }
                }
            },

        };

        public Encouragement GetRandomEncouragemnt(string mood)
        {
            if (_encouragements.TryGetValue(mood, out var messages))
            {
                var randomIndex = _random.Next(0, messages.Count);
                return messages[randomIndex];
            }
            return new Encouragement
            {
                Message = "You're great, but the developer of this app made a mistake. "
            };
        }
    }
}
