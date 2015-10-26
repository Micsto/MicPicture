using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
namespace MicPicture.Common.Converters
{
	public sealed class BooleanToVisibilityConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo ci)
		{
			return ((value is bool && (bool)value) ^ parameter != null) ? Visibility.Visible : Visibility.Collapsed;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo ci)
		{
			return (value is Visibility && (Visibility)value == Visibility.Visible) ^ parameter != null;
		}
	}
}
