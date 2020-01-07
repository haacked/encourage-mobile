using System;
using System.Collections.Generic;
using Encourage.Mobile;
using Xamarin.Forms;

namespace Encourage
{
    public partial class MainPage : ContentPage
    {
        static readonly Random _random = new Random();
        static readonly Dictionary<string, List<string>> _encouragements = new Dictionary<string, List<string>>
        {
            {
                "Sad",
                new List<string>
                {
                    "It's ok to feel sad. Know that people love you.",
                    "Sometimes I feel sad, then I fart and I'm not so sad.",
                    "You can get through it!",
                    "You're really wonderful!",
                    "Sorry to hear it, you good looking friend!",
                    "Everyone gets sad from time to time, even wonderful people like you!"
                }
            },
            {
                "Bored",
                new List<string>
                {
                    "It sucks to be bored. Hope you find something fun to do.",
                    "You can get through it!",
                    "Maybe play a game?",
                    "When I'm bored I go read a book."
                }
            },
            {
                "Frustrated",
                new List<string>
                {
                    "I know it's frustrating, but you can do it!",
                    "I know it's frustrating, but I believe in you!",
                    "Well you're still pretty awesome",
                    "You're cool!"
                }
            },
            {
                "Angry",
                new List<string>
                {
                    "Grrr! I'll be angry with you.",
                    "Take a deep breath. Ok, breathe it out.",
                    "Need me to hurt someone for you?",
                    "Want a hug? If I had arms I would hug you.",
                    "Poop"
                }
            },
            {
                "Happy",
                new List<string>
                {
                    "Yay! You're the best!",
                    "So am I! Feels good, right?",
                    "That's great! And so are you!",
                    "Nice job!",
                    "Way to go!",
                    "You rock!",
                    "FTW!",
                    "Nailed it!",
                    "Great job good looking!"
                }
            },

        };

        public MainPage()
        {
            InitializeComponent();
        }

        async void OnButtonClicked(object sender, EventArgs args)
        {
            var encouragement = GetRandomMessage((sender as Button)?.Text);
            await Navigation.PushAsync(new EncouragementPage
            {
                BindingContext = encouragement
            });
        }

        string GetRandomMessage(string? mood)
        {
            if (mood is null) return "I got nothing";

            if (_encouragements.TryGetValue(mood, out var messages))
            {
                var randomIndex = _random.Next(0, messages.Count);
                return messages[randomIndex];
            }
            return "I got nothing";
        }
    }
}