using AppContacts.Helpers;
using AppContacts.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace AppContacts.ViewModel
{
    public class ContactsPageViewModel
    {
        public ObservableCollection<Grouping<string, Contact>> ContactsList { get; set; }
        public ContactsPageViewModel()
        {
            Task.Run(async () => ContactsList = await App.DataBase.GetAllGrouped()).Wait();
        }

    }
}
