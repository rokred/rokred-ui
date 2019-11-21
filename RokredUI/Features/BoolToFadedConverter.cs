using System;
using System.Globalization;
using Xamarin.Forms;

namespace RokredUI.Features
{
    public class BoolToFadedConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (double) ((bool)value ? 0.2f: 1f);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}