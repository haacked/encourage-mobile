using System;
using Xamarin.Forms;

namespace Encourage.Mobile
{
	public partial class EncouragementPage : ContentPage
	{
		public EncouragementPage()
		{
			InitializeComponent();
		}

		async void OnNavigateBackClicked(object sender, EventArgs args)
			=> await Navigation.PopAsync();
	}
}
