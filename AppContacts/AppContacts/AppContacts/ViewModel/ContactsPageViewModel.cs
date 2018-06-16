using AppContacts.Helpers;
using AppContacts.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using AppContacts.View;

namespace AppContacts.ViewModel
{
    public class ContactsPageViewModel
    {
        public INavigation Navigation { get; set; }
        public Command AddContactCommand { get; set; }
        public ObservableCollection<Grouping<string, Contact>> ContactsList { get; set; }

        public ContactsPageViewModel(INavigation Navigation)
        {
            Task.Run(async () => ContactsList = await App.DataBase.GetAllGrouped()).Wait();
            AddContactCommand = new Command(
                async () => await GoToDetailContact());
        }

        private async Task GoToDetailContact()
        {
            await Navigation.PushAsync(new ContactDetailPage());
        }
    }
}
