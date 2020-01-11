using System;
using Encourage.Mobile.ViewModels;
using Xamarin.Forms;

namespace Encourage.Mobile
{
	public partial class MoodEditor : ContentPage
	{
		public MoodEditor()
		{
			InitializeComponent();
		}

		protected void OnMoodNameCompleted(object sender, EventArgs e)
		{
			var newMoodName = ((Entry)sender).Text;
			var vm = (MoodEditorViewModel)BindingContext;
			vm.Mood.Name = newMoodName;
			vm.SaveMood();
		}

		protected void OnBackgroundColorCompleted(object sender, EventArgs e)
		{
			var newBackgroundColor = ((Entry)sender).Text;
			var vm = (MoodEditorViewModel)BindingContext;
			vm.Mood.BackgroundColor = newBackgroundColor;
			vm.SaveMood();
		}
	}
}
