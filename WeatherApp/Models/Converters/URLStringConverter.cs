using System;
using System.Globalization;
using Xamarin.Forms;

namespace WeatherApp.Models.Converters
{
    public class URLStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return "http:" + value as string;
            //return (int)value != 0;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (bool)value ? 1 : 0;
        }
    }
}
