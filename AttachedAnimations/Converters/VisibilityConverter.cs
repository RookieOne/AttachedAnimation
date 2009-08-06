using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace AttachedAnimations.Converters
{
    public class VisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool result = System.Convert.ToBoolean(value);

            return result
                       ? Visibility.Visible
                       : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}