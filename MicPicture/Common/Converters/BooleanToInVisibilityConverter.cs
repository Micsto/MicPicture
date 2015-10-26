using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace MicPicture.Common.Converters
{
	public sealed class BooleanToInVisibilityConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo ci)
		{
			return ((value is bool && (bool)value) ^ parameter != null) ? Visibility.Collapsed : Visibility.Visible;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo ci)
		{
			return (value is Visibility && (Visibility)value == Visibility.Collapsed) ^ parameter != null;
		}
	}
}
