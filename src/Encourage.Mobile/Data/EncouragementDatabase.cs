using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Encourage.Mobile.Models;
using SQLite;

namespace Encourage.Mobile.Data
{
    public class EncouragementDatabase
    {
        readonly SQLiteAsyncConnection _database;

        public EncouragementDatabase(string databasePath)
        {
            _database = new SQLiteAsyncConnection(databasePath);
            var result = _database.CreateTableAsync<Encouragement>().Result;
            if (result == CreateTableResult.Created)
            {
                // Populate data the first time.
                foreach (var mood in _defaultEncouragements.Keys)
                {
                    foreach (var encouragement in _defaultEncouragements[mood])
                    {
                        encouragement.Mood = mood;
                        SaveEncouragementAsync(encouragement).Wait();
                    }
                }
            }
        }

        public Task<List<Encouragement>> GetEncouragementsAsync()
        {
            return _database.Table<Encouragement>().ToListAsync();
        }

        public Task<List<Encouragement>> GetEncouragementsAsync(string mood)
        {
            return _database.Table<Encouragement>()
                            .Where(i => i.Mood == mood)
                            .ToListAsync();
        }

        public Task<Encouragement> GetEncouragmentAsync(int id)
        {
            return _database.Table<Encouragement>()
                            .Where(i => i.Id == id)
                            .FirstOrDefaultAsync();
        }

        public Task<int> SaveEncouragementAsync(Encouragement encouragment)
        {
            return encouragment.Id == 0
                ? _database.InsertAsync(encouragment)
                : _database.UpdateAsync(encouragment);
        }

        public Task<int> DeleteEncouragmentAsync(Encouragement encouragement)
        {
            return _database.DeleteAsync(encouragement);
        }


        readonly Dictionary<string, List<Encouragement>> _defaultEncouragements
            = new Dictionary<string, List<Encouragement>>
        {
            {
                "Sad",
                new List<Encouragement>
                {
                    new Encouragement
                    {
                        Message = "It's ok to feel sad. Know that people love you.",
                        ImageUrl = "https://i.redd.it/yfi3lroun8zz.jpg"
                    },
                    new Encouragement
                    {
                        Message = "Sometimes I feel sad, then I fart and I'm not so sad.",
                        ImageUrl = "https://user-images.githubusercontent.com/19977/71918429-1005cf80-3137-11ea-8605-67a24089aacb.png"
                    },
                    new Encouragement
                    {
                        Message = "You can get through it!",
                        ImageUrl = "https://user-images.githubusercontent.com/19977/71918534-53603e00-3137-11ea-843e-4a30ef792391.png"
                    },
                    new Encouragement
                    {
                        Message = "You're really wonderful!",
                        ImageUrl = "https://user-images.githubusercontent.com/19977/71918622-8571a000-3137-11ea-9a8d-3a085de44d64.jpg"
                    },
                    new Encouragement
                    {
                        Message = "Sorry to hear it, you good looking friend!",
                        ImageUrl = "https://user-images.githubusercontent.com/19977/71918781-e26d5600-3137-11ea-8ad4-d1b34614b018.jpg"
                    },
                    new Encouragement
                    {
                        Message = "Everyone gets sad from time to time, even wonderful people like you!",
                        ImageUrl = "https://user-images.githubusercontent.com/19977/71918848-15afe500-3138-11ea-8967-32dcf95c6edd.jpg"
                    }
                }
            },
            {
                "Bored",
                new List<Encouragement>
                {
                    new Encouragement
                    {
                        Message = "It sucks to be bored. Hope you find something fun to do.",
                        ImageUrl = "https://i.redd.it/j2v898wr3e941.jpg"
                    },
                    new Encouragement
                    {
                        Message = "You can get through it!",
                        ImageUrl = "https://user-images.githubusercontent.com/19977/71919771-4d1f9100-313a-11ea-92c9-1b2d4f64b0e3.jpg"
                    },
                    new Encouragement
                    {
                        Message = "Maybe play a game? Or pick your nose. Whatever.",
                        ImageUrl = "https://i.pinimg.com/736x/8a/3f/98/8a3f9899042e68398d18f9c832fe3e34.jpg"
                    },
                    new Encouragement
                    {
                        Message = "When I'm bored I go read a book.",
                        ImageUrl = "https://user-images.githubusercontent.com/19977/71919664-0e89d680-313a-11ea-8e8d-0c44528a1d93.jpg"
                    }
                }
            },
            {
                "Frustrated",
                new List<Encouragement>
                {
                    new Encouragement
                    {
                        Message = "I know it's frustrating, but you can do it!",
                        ImageUrl = "https://user-images.githubusercontent.com/19977/71918534-53603e00-3137-11ea-843e-4a30ef792391.png"
                    },
                    new Encouragement
                    {
                        Message = "I know it's frustrating, but I believe in you!",
                        ImageUrl = "https://i.redd.it/yfi3lroun8zz.jpg"
                    },
                    new Encouragement
                    {
                        Message = "Well you're still pretty awesome!",
                        ImageUrl = "https://user-images.githubusercontent.com/19977/71920288-4b0a0200-313b-11ea-851d-b361e60de9cd.png"
                    },
                    new Encouragement
                    {
                        Message = "You're cool!",
                        ImageUrl = "https://user-images.githubusercontent.com/19977/71920377-6ecd4800-313b-11ea-9dc4-9c47d12a3fc7.jpg"
                    }
                }
            },
            {
                "Angry",
                new List<Encouragement>
                {
                    new Encouragement
                    {
                        Message = "Grrr! I'll be angry with you.",
                        ImageUrl = "https://pbs.twimg.com/profile_images/748180229311578113/iHN3H9mf.jpg"
                    },
                    new Encouragement
                    {
                        Message = "Take a deep breath. Ok, breathe it out.",
                        ImageUrl = "https://user-images.githubusercontent.com/19977/71919909-940d8680-313a-11ea-8e09-7c337e38284d.jpg"
                    },
                    new Encouragement
                    {
                        Message = "Need me to hurt someone for you?",
                        ImageUrl = "https://user-images.githubusercontent.com/19977/71920031-d040e700-313a-11ea-9d75-fc49cff45f98.jpg"
                    },
                    new Encouragement
                    {
                        Message = "Want a hug? If I had arms I would hug you.",
                        ImageUrl = "https://i.imgur.com/ustd8Sq.jpg"
                    },
                    new Encouragement
                    {
                        Message = "Poop",
                        ImageUrl = "https://i.imgur.com/5PwlXoT.jpg"
                    }
                }
            },
            {
                "Happy",
                new List<Encouragement>
                {
                    new Encouragement
                    {
                        Message = "Yay! You're the best!",
                        ImageUrl = "https://user-images.githubusercontent.com/19977/71920377-6ecd4800-313b-11ea-9dc4-9c47d12a3fc7.jpg"
                    },
                    new Encouragement
                    {
                        Message = "So am I! Feels good, right?",
                        ImageUrl = "https://user-images.githubusercontent.com/19977/71920506-c4095980-313b-11ea-9257-31a6889ec65c.jpg"
                    },
                    new Encouragement
                    {
                        Message = "That's great! And so are you!",
                        ImageUrl = "https://user-images.githubusercontent.com/19977/71920589-f024da80-313b-11ea-9a58-1bd6f42a5edb.jpg"
                    },
                    new Encouragement
                    {
                        Message = "Nice job!",
                        ImageUrl = "https://user-images.githubusercontent.com/19977/71920668-22ced300-313c-11ea-9a7a-b58b0dc5da7a.jpg"
                    },
                    new Encouragement
                    {
                        Message = "Way to go!",
                        ImageUrl = "https://user-images.githubusercontent.com/19977/71920668-22ced300-313c-11ea-9a7a-b58b0dc5da7a.jpg"
                    },
                    new Encouragement
                    {
                        Message = "You rock!",
                        ImageUrl = "https://user-images.githubusercontent.com/19977/71920766-57db2580-313c-11ea-9b1a-aafc0f8d2db2.jpeg"
                    },
                    new Encouragement
                    {
                        Message = "Nailed it!",
                        ImageUrl = "https://user-images.githubusercontent.com/19977/71920876-92dd5900-313c-11ea-90ae-7367b2e7fd4b.png"
                    },
                    new Encouragement
                    {
                        Message = "Great job good looking!",
                        ImageUrl = "https://user-images.githubusercontent.com/19977/71920981-cb7d3280-313c-11ea-8370-1109524ecfed.jpg"
                    }
                }
            },

        };
    }
}
