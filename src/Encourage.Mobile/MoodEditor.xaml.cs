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

		MoodEditorViewModel ViewModel => (MoodEditorViewModel)BindingContext;

		protected void OnMoodNameCompleted(object sender, EventArgs e)
		{
			var newMoodName = ((Entry)sender).Text;
			var vm = ViewModel;
			vm.Mood.Name = newMoodName;
		}

		protected void OnBackgroundColorCompleted(object sender, EventArgs e)
		{
			var newBackgroundColor = ((Entry)sender).Text;
			var vm = ViewModel;
			vm.Mood.BackgroundColor = newBackgroundColor;
		}

		protected async void OnSaveClicked(object sender, EventArgs e)
		{
			// TODO: Am I doing this right. This seems wonky. Look into 2-way data binding.
			((IEntryController)moodNameEntry).SendCompleted();
			((IEntryController)backgroundColorEntry).SendCompleted();

			await ViewModel.SaveMoodAsync();

			await Navigation.PopAsync();
		}

		protected async void OnDeleteMoodClicked(object sender, EventArgs e)
		{
			await ViewModel.DeleteMoodAsync();
			await Navigation.PopAsync();
		}

		protected void OnEditEncouragementClicked(object sender, EventArgs e)
		{
			var encouragement = GetBoundObject<EncouragementEditorViewModel>(sender);
			encouragement.IsEditing = true;
		}

		protected async void OnSaveEncouragementClicked(object sender, EventArgs e)
		{
			var encouragement = GetBoundObject<EncouragementEditorViewModel>(sender);
			await ViewModel.SaveEncouragementAsync(encouragement.Encouragement);
			encouragement.IsEditing = false;
		}

		protected void OnCancelClicked(object sender, EventArgs e)
		{
			var encouragement = GetBoundObject<EncouragementEditorViewModel>(sender);
			encouragement.IsEditing = false;
		}

		protected void OnDeleteEncouragementClicked(object sender, EventArgs e)
		{
			var encouragement = GetBoundObject<EncouragementEditorViewModel>(sender);
			ViewModel.Encouragements.Remove(encouragement);
		}

		static T GetBoundObject<T>(object sender)
		{
			return (T)((BindableObject)sender).BindingContext;
		}
	}
}
