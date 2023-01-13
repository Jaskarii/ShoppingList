using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace XamarinForm
{
    internal class DataViewModel: INotifyPropertyChanged
    {
        public ObservableCollection<Item> Items { get; set; }

        public Command<Item> UpdateCommand { get; private set; }

        public Command<Item> AddCommand { get; private set; }
        public DataViewModel() 
        {
            LoadData();

            InitCommands();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        private void InitCommands()
        {
            UpdateCommand = new Command<Item>(item => App.DataBase.UpdateItemAsync(item));
        }

        void LoadData()
        {
            List<Item> items = App.DataBase.GetPeople().OrderBy(x => x.IsChecked).ToList();

            Items = new ObservableCollection<Item>(items);
        }

        public async void AddItem(Item item)
        {
            Items.Add(item);
            await App.DataBase.SaveItemAsync(item);
        }
        
        public void UpdateList()
        {
            List<Item> asdf = Items.OrderBy(x => x.IsChecked).ToList();
            Items = new ObservableCollection<Item>(asdf);
            OnPropertyChanged("Items");
        }

        public async void RemoveItem(Item item)
        {
            Items.Remove(Items.First(x => x.Name== item.Name));
            await App.DataBase.DeleteItemAsync(item);
            OnPropertyChanged("Items");
        }
        
    }
}
