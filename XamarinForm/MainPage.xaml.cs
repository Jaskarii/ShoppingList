using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;

namespace XamarinForm
{
    public partial class MainPage : ContentPage
    {
        DataViewModel dataViewModel;
        public MainPage()
        {
            InitializeComponent();

            dataViewModel = new DataViewModel();
            BindingContext = dataViewModel;
        }


        async void add_Clicked(object sender, EventArgs e)
        {
            string entry = nameEntry.Text;

            if (string.IsNullOrEmpty(entry))
            {
                return;
            }

            nameEntry.Text = string.Empty;
            Item newItem = new Item() { IsChecked = false, Name = entry };
            dataViewModel.AddItem(newItem);
            dataViewModel.UpdateList(); 
            
        }


        private void button_Clicked(object sender, EventArgs e)
        {
            if (sender is ToggleButton btn)
            {
                btn.IsChecked = !btn.IsChecked;
            }
            dataViewModel.UpdateList();
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            if (sender is Frame frame)
            {
                if (frame.BindingContext is Item item)
                {
                    item.IsChecked = !item.IsChecked;
                    dataViewModel.UpdateList();
                } 
            }
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            if (sender is Button btn)
            {
                if (btn.BindingContext is Item item)
                {
                    dataViewModel.RemoveItem(item);
                }
            }
        }
    }
}
