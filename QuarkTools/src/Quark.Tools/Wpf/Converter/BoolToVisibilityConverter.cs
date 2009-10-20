using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Quark.Tools.Wpf.Converter
{
    public class BoolToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
            {
                return Binding.DoNothing;
            }

            bool input;
            Boolean.TryParse(value.ToString(), out input);

            return input ? Visibility.Visible : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}