using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Encourage.Mobile.Data;
using Encourage.Mobile.Models;

namespace Encourage.Mobile.ViewModels
{
	public class MoodEditorViewModel : ViewModel
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

		public ObservableCollection<EncouragementEditorViewModel> Encouragements { get; } = new ObservableCollection<EncouragementEditorViewModel>();

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
			var encouragements = await _encouragementDatabase.GetEncouragementsForMoodAsync(Mood.Id);
			foreach (var encouragement in encouragements)
			{
				Encouragements.Add(new EncouragementEditorViewModel(encouragement));
			}
			// We add the event handler AFTER we load the initial set of encouragements.
			Encouragements.CollectionChanged += async (s, e) =>
			{
				if (e.Action == NotifyCollectionChangedAction.Remove)
				{
					foreach (var removed in e.OldItems.Cast<EncouragementEditorViewModel>().Select(r => r.Encouragement))
					{
						await _encouragementDatabase.DeleteEncouragmentAsync(removed);
					}
				}
			};
			EncouragementCountLabel = $"This mood has {Encouragements.Count} encouragements";
			NotifyPropertyChange(nameof(EncouragementCountLabel));
		}

		public Task<int> SaveEncouragementAsync(Encouragement encouragement)
		{
			return _encouragementDatabase.SaveEncouragementAsync(encouragement);
		}
	}
}
