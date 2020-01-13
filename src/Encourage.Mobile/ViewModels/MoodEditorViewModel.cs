using System.Threading.Tasks;
using Encourage.Mobile.Data;
using Encourage.Mobile.Models;

namespace Encourage.Mobile.ViewModels
{
	public class MoodEditorViewModel
	{
		private readonly EncouragementDatabase _encouragementDatabase;

		public MoodEditorViewModel(Mood mood, EncouragementDatabase encouragementDatabase)
		{
			Mood = mood;
			_encouragementDatabase = encouragementDatabase;
		}

		public Mood Mood { get; }

		public bool IsEditing => Mood.Id != 0;

		public string TitleMessage => IsEditing
			? "Edit Mood"
			: "Create Mood";

		public Task<int> SaveMoodAsync()
		{
			return _encouragementDatabase.SaveMoodAsync(Mood);
		}

		public Task<int> DeleteMoodAsync()
		{
			return _encouragementDatabase.DeleteMoodAsync(Mood);
		}
	}
}
