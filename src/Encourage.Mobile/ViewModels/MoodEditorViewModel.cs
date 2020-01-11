using System.Windows.Input;
using Encourage.Mobile.Data;
using Encourage.Mobile.Models;
using Xamarin.Forms;

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

		public async void SaveMood()
		{
			await _encouragementDatabase.SaveMood(Mood);
		}
	}
}
