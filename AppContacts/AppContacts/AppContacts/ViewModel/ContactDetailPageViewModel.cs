using AppContacts.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppContacts.ViewModel
{
    public class ContactDetailPageViewModel
    {
        
        public Contact CurrentsContacto { get; set; }
        public Command SaveContactCommand { get; set; }
        public Command DeleteContactCommand { get; set; }
        public INavigation Navigation { get; set; }

        public ContactDetailPageViewModel(INavigation navigation)
        {
            this.Navigation = navigation;
            CurrentsContacto = new Contact();
            SaveContactCommand = new Command(async () => await SaveContact());
            DeleteContactCommand = new Command(async () => await DeleteContact());
        }
        private async Task SaveContact()
        {
            await App.DataBase.SaveItemAsync(CurrentsContacto);
            await Navigation.PopToRootAsync();
        }

        public async Task DeleteContact()
        {
            await App.DataBase.DeleteItemAsync(CurrentsContacto);
            await Navigation.PopToRootAsync();
        }


    }
}
