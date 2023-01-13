using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace XamarinForm
{
    internal class BooleanToContentConverter: IValueConverter
    {
        public string Content { get; set; }
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string stringValue = "";
            if (value != null)
            {
                if ((bool)value)
                {
                    stringValue= Content;
                }
            }
            return stringValue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
