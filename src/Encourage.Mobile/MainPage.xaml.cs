using System;
using Encourage.Mobile;
using Encourage.Mobile.Models;
using Xamarin.Forms;

namespace Encourage
{
    public partial class MainPage : ContentPage
    {
        static readonly EncouragementRepository _encouragementRepository = new EncouragementRepository();
        
        public MainPage()
        {
            InitializeComponent();
        }

        async void OnButtonClicked(object sender, EventArgs args)
        {
            var mood = (sender as Button)?.Text ?? "unknown";
            var encouragement = _encouragementRepository.GetRandomEncouragemnt(mood);
            await Navigation.PushAsync(new EncouragementPage
            {
                BindingContext = encouragement
            });
        }
    }
}