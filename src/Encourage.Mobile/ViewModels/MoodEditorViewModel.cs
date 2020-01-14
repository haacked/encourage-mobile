using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Encourage.Mobile.Data;
using Encourage.Mobile.Models;

namespace Encourage.Mobile.ViewModels
{
	public class MoodEditorViewModel : ViewModel, INotifyPropertyChanged
	{
		private readonly EncouragementDatabase _encouragementDatabase;

		public MoodEditorViewModel(Mood mood, EncouragementDatabase encouragementDatabase)
		{
			Mood = mood;
			_encouragementDatabase = encouragementDatabase;
			InitializePropertiesAsync();
		}

		public Mood Mood { get; }

		public bool IsEditing => Mood.Id != 0;

		public string TitleMessage => IsEditing
			? "Edit Mood"
			: "Create Mood";

		public string EncouragementCountLabel { get; private set; } = "Placeholder until things are loaded";

		public List<Encouragement> Encouragements { get; private set; } = null!;

		public Task<int> SaveMoodAsync()
		{
			return _encouragementDatabase.SaveMoodAsync(Mood);
		}

		public Task<int> DeleteMoodAsync()
		{
			return _encouragementDatabase.DeleteMoodAsync(Mood);
		}

		async void InitializePropertiesAsync()
		{
			Encouragements = await _encouragementDatabase.GetEncouragementsForMoodAsync(Mood.Id);
			NotifyPropertyChange(nameof(Encouragements));
			EncouragementCountLabel = $"This mood has {Encouragements.Count} encouragements";
			NotifyPropertyChange(nameof(EncouragementCountLabel));
		}
	}
}
