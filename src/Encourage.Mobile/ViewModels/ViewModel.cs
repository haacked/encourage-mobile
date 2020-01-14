using System;
using System.ComponentModel;

namespace Encourage.Mobile.ViewModels
{
	public abstract class ViewModel : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler? PropertyChanged;

		protected void SetValue<T>(string propertyName, T newValue, ref T privateMember)
		{
			if (!ReferenceEquals(privateMember, newValue))
			{
				privateMember = newValue;
				NotifyPropertyChange(propertyName);
			}
		}

		protected void NotifyPropertyChange(string propertyName)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
