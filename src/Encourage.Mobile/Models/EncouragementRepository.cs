using System;
using System.Threading.Tasks;
using Encourage.Mobile.Data;

namespace Encourage.Mobile.Models
{
    public class EncouragementRepository
    {
        static readonly Random _random = new Random();

        readonly EncouragementDatabase _database;

        public EncouragementRepository(EncouragementDatabase database)
        {
            _database = database;
        }

        public async Task<Encouragement> GetRandomEncouragement(string mood)
        {
            var encouragements = await _database.GetEncouragementsAsync(mood);
            if (encouragements.Count == 0)
            {
                return new Encouragement
                {
                    Message = "You're great, but the developer of this app made a mistake."
                };
            }
            var randomIndex = _random.Next(0, encouragements.Count);
            return encouragements[randomIndex];
        }
    }
}
