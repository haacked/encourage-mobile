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

		protected async void OnSaveClicked(object sender, EventArgs e)
		{
			await ViewModel.SaveMoodAsync();
			await Navigation.PopAsync();
		}

		protected async void OnDeleteMoodClicked(object sender, EventArgs e)
		{
			await ViewModel.DeleteMoodAsync();
			await Navigation.PopAsync();
		}

		protected void OnAddEncouragementClicked(object sender, EventArgs e)
		{
			ViewModel.AddEncouragement();
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

		protected void OnCancelEncouragementEditClicked(object sender, EventArgs e)
		{
			ViewModel.CancelEncouragementEdit();
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
