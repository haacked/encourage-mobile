using System;
using System.ComponentModel;
using System.IO;
using System.Windows.Input;
using Encourage.Mobile.Data;
using Encourage.Mobile.Models;
using Xamarin.Forms;

namespace Encourage.Mobile.ViewModels
{
	public class MainPageViewModel : ViewModel
	{
		readonly EncouragementDatabase _database = new EncouragementDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Encouragements.db3"));
		readonly EncouragementRepository _encouragementRepository;
		public ICommand ShowAlertCommand { get; }
		public ICommand ButtonPressedCommand { get; }

		public MainPageViewModel()
		{
			_encouragementRepository = new EncouragementRepository(_database);
			ShowAlertCommand = new Command(OnMoodSelected);
			ButtonPressedCommand = new Command(OnMoodEditing);
		}

		Encouragement? _currentEncouragement;
		public Encouragement? CurrentEncouragement
		{
			get
			{
				return _currentEncouragement;
			}
			set
			{
				SetValue(nameof(CurrentEncouragement), value, ref _currentEncouragement);
			}
		}

		Mood? _currentMood;
		public Mood? CurrentMood
		{
			get
			{
				return _currentMood;
			}
			set
			{
				SetValue(nameof(CurrentMood), value, ref _currentMood);
			}
		}

		async void OnMoodSelected(object obj)
		{
			var mood = obj as Mood ?? throw new InvalidOperationException("A null mood was clicked");
			CurrentEncouragement = await _encouragementRepository.GetRandomEncouragement(mood);
		}

		void OnMoodEditing(object obj)
		{
			var mood = obj as Mood ?? throw new InvalidOperationException("A null mood was clicked");
			CurrentMood = mood;
		}
	}
}
