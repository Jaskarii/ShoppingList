using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XamarinForm
{
    public class DataBase
    {
        private readonly SQLiteAsyncConnection database;

        public DataBase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<Item>();
        }

        public List<Item> GetPeople() 
        {   
            List<Item> list = database.Table<Item>().ToListAsync().Result;
            list.OrderBy(x => x.IsChecked).ToList();
            return list;
        } 

        public Task<int> SaveItemAsync(Item item) 
        {
            Task<int> temp = database.InsertAsync(item);

            return temp;
        }

        public Task<int> UpdateItemAsync(Item item)
        {
            Task<int> temp = database.UpdateAsync(item);

            return temp;
        }

        public Task<int> DeleteItemAsync(Item item)
        {
            Task<int> temp = database.DeleteAsync(item);
            return temp;
        }
    }
}
