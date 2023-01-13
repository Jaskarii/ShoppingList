using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace XamarinForm
{
    public class BooleanToColorConverter : IValueConverter
    {
        public Color TrueColor { get; set; } = Color.Green;

        public Color FalseColor { get; set; } = Color.Red;

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null && (bool)value)
            {
                return TrueColor;
            }
            return FalseColor;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
