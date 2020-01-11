using System;
using System.ComponentModel;
using Encourage.Mobile;
using Encourage.Mobile.Data;
using Encourage.Mobile.Models;
using Encourage.Mobile.ViewModels;
using Xamarin.Forms;

namespace Encourage
{
	public partial class MainPage : ContentPage
	{
		readonly EncouragementRepository _encouragementRepository;
		readonly EncouragementDatabase _database;
		readonly MainPageViewModel _viewModel;

		public MainPage(EncouragementDatabase database)
		{
			InitializeComponent();
			_database = database;
			_encouragementRepository = new EncouragementRepository(_database);
			_viewModel = BindingContext as MainPageViewModel ?? throw new InvalidOperationException("The binding context is not a MainPageViewModel.");
			_viewModel.PropertyChanged += OnPropertyChanged;
		}

		async void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			// TODO: Is navigation a view model or view concern? Don't care right now, but maybe revisit this later.
			if (e.PropertyName == nameof(_viewModel.CurrentEncouragement))
			{
				if (_viewModel.CurrentEncouragement is null)
					return;
				await Navigation.PushAsync(new EncouragementPage
				{
					BindingContext = _viewModel.CurrentEncouragement
				});
				_viewModel.CurrentEncouragement = null;
			}
			if (e.PropertyName == nameof(_viewModel.CurrentMood))
			{
				if (_viewModel.CurrentMood is null)
					return;

				await Navigation.PushAsync(new MoodEditor
				{
					BindingContext = _viewModel.CurrentMood
				});
				_viewModel.CurrentMood = null;
			}
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();

			BindableLayout.SetItemsSource(moodsLayout, _database.GetMoodsAsync().Result);
		}
	}
}