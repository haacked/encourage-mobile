using System;
using System.ComponentModel;
using System.Globalization;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Encourage.Mobile.Converters
{
	public class ColorConverter : IValueConverter, IMarkupExtension
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			var converter = TypeDescriptor.GetConverter(typeof(System.Drawing.Color));
			try
			{
				return converter.ConvertFromString(value as string);
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				return System.Drawing.Color.AliceBlue;
			}
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return value;
		}

		public object ProvideValue(IServiceProvider serviceProvider)
		{
			return this;
		}
	}
}
