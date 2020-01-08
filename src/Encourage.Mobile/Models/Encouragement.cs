using SQLite;

namespace Encourage.Mobile.Models
{
    public class Encouragement
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Mood { get; set; } = null!;
        public string Message { get; set; } = null!;
        public string? ImageUrl { get; set; }
    }
}
