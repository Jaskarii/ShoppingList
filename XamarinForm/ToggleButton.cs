using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace XamarinForm
{
    public class ToggleButton : Button, INotifyPropertyChanged
    {

        public static readonly BindableProperty IsCheckedProperty = BindableProperty.Create(nameof(IsChecked), typeof(bool), typeof(ContentPage), false);

        public bool IsChecked
        {
            get { return (bool)GetValue(IsCheckedProperty); }
            set { SetValue(IsCheckedProperty, value); }
        }
    }
}
