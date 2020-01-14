using System;
using System.IO;
using Encourage.Mobile.Data;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]

namespace Encourage
{
	public partial class App : Application
	{
		public App()
		{
			InitializeComponent();
			var database = new EncouragementDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Encouragements.db3"));
			MainPage = new NavigationPage(new MainPage(database));
		}

		protected override void OnStart()
		{
			// Handle when your app starts
		}

		protected override void OnSleep()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}
	}
}