using Encourage.Mobile.Models;

namespace Encourage.Mobile.ViewModels
{
	public class EncouragementEditorViewModel : ViewModel
	{
		public EncouragementEditorViewModel(Encouragement encouragement)
		{
			Encouragement = encouragement;
		}

		public Encouragement Encouragement { get; }

		private bool _isEditing;
		public bool IsEditing
		{
			get { return _isEditing; }
			set { SetValue(nameof(IsEditing), value, ref _isEditing); }
		}
	}
}
