using AppContacts.Helpers;
using AppContacts.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using AppContacts.View;
using AppContacts.Data;

namespace AppContacts.ViewModel
{
    public class ContactsPageViewModel
    {
        public INavigation Navigation { get; set; }
        public Command AddContactCommand { get; set; }
        public Contact CurrentContact { get; set; }
        public Command ItemTappedCommand { get; }
        public ObservableCollection<Grouping<string, Contact>> ContactsList { get; set; }

        
        public ContactsPageViewModel(INavigation navigation)
        {
            Navigation = navigation;
            Task.Run(async () =>  
            ContactsList = await App.DataBase.GetItemsGroupedAsync()).Wait();
            AddContactCommand = new Command(async () => await GoToDetailContact());
            ItemTappedCommand = new Command(async () => GoToDetailContact(CurrentContact));
        }

        private async Task GoToDetailContact(Contact contact= null)
        {
            if (contact == null)
                {
                await Navigation.PushAsync(new ContactDetailPage());
            }
            else
            {
                await Navigation.PushAsync(new ContactDetailPage(CurrentContact));
            }
            
        }

       
    }
}
