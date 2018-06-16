using System;
using System.Collections.Generic;
using System.Text;

namespace AppContacts.Data
{
    using AppContacts.Helpers;
    using AppContacts.Model;
    using SQLite;
    using System.Collections.ObjectModel;
    using System.Threading.Tasks;
    using System.Linq;

    public class ContactsDataBase
    {
       
        private readonly SQLiteAsyncConnection dataBase;
        public ContactsDataBase(string dbPath)
        {
            dataBase = new SQLiteAsyncConnection(dbPath);
            dataBase.CreateTableAsync<Contact>().Wait();
        }

        public async Task<List<Contact>> GetItemsAsycn()
        {
            var data = await dataBase.Table<Contact>().ToListAsync();
            return data;
        }

        public Task<Contact> GetItemAsycn(int ID)
        {
            return dataBase.Table<Contact>()
                               .Where(c => c.ID == ID)
                               .FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(Contact item)
        {
            if (item.ID != 0)
            {
                return dataBase.UpdateAsync(item);
            }
            else
            {
                return dataBase.InsertAsync(item);
            }
        }

        public Task<int> DeleteItemAsync(Contact item)
        {
            return dataBase.DeleteAsync(item);
        }

        public async
            Task<ObservableCollection
            <Grouping<string, Contact>>>
            GetAllGrouped()
        {
            IList<Contact> contacts = await App.DataBase.GetItemsAsycn();
            IEnumerable<Grouping<string, Contact>> sorted = new Grouping<string, Contact>[0];
            if (contacts != null)
            {
                sorted =
                from c in contacts
                orderby c.Nombre
                group c by c.Nombre[0].ToString()
                into theGroup
                select
                new Grouping<string, Contact>
                (theGroup.Key, theGroup);
            }
            return new
                ObservableCollection
                <Grouping<string, Contact>>(sorted);
        }
    }
}
