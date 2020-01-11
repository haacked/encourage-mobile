using System;
using Encourage.Mobile;
using Encourage.Mobile.Data;
using Encourage.Mobile.Models;
using Xamarin.Forms;

namespace Encourage
{
	public partial class MainPage : ContentPage
	{
		readonly EncouragementRepository _encouragementRepository;
		readonly EncouragementDatabase _database;

		public MainPage(EncouragementDatabase database)
		{
			InitializeComponent();
			_database = database;
			_encouragementRepository = new EncouragementRepository(_database);
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();

			BindableLayout.SetItemsSource(moodsLayout, _database.GetMoodsAsync().Result);
		}

		async void OnButtonClicked(object sender, EventArgs args)
		{
			var button = sender as Button ?? throw new InvalidOperationException("A null button was somehow clicked.");
			var mood = button.BindingContext as Mood ?? throw new InvalidOperationException("A button with no mood was somehow clicked.");
			var encouragement = await _encouragementRepository.GetRandomEncouragement(mood);
			await Navigation.PushAsync(new EncouragementPage
			{
				BindingContext = encouragement
			});
		}
	}
}