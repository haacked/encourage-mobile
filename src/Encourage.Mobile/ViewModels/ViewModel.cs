using System;
using System.ComponentModel;

namespace Encourage.Mobile.ViewModels
{
	public abstract class ViewModel : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler? PropertyChanged;

		protected void SetValue<T>(string propertyName, T newValue, ref T privateMember) where T : IEquatable<T>
		{
			if (newValue is object && !newValue.Equals(privateMember) || newValue is null && privateMember is object)
			{
				privateMember = newValue;
				NotifyPropertyChange(propertyName);
			}
		}

		protected void SetNullableValue<T>(string propertyName, T? newValue, ref T? privateMember) where T : class
		{
			if (!ReferenceEquals(newValue, privateMember))
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
