using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace XamarinForm
{
    public class Item
    {
        [PrimaryKey]
        [AutoIncrement]
        public int Id { get; set; }

        /// <summary>
        /// Name of the item
        /// </summary>
        public string Name { get; set; }


        private bool isChecked;
        public bool IsChecked
        {
            get
            {
                return isChecked;
            }
            set
            {
                if (isChecked != value)
                {
                    isChecked = value;
                    App.DataBase.UpdateItemAsync(this);
                }
            }
        }

        public void Remove()
        {
            App.DataBase.DeleteItemAsync(this);
        }
    }
}
