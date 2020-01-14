using Encourage.Mobile.ViewModels;
using SQLite;

namespace Encourage.Mobile.Models
{
	public class Encouragement : ViewModel, IDatabaseEntity
	{
		[PrimaryKey, AutoIncrement]
		public int Id { get; set; }
		public int MoodId { get; set; }

		private string _message = null!;
		public string Message
		{
			get { return _message; }
			set { SetValue(nameof(Message), value, ref _message); }
		}

		private string _imageUrl = null!;
		public string ImageUrl
		{
			get { return _imageUrl; }
			set { SetValue(nameof(ImageUrl), value, ref _imageUrl); }
		}
	}
}
