﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppContacts.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppContacts.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ContactsPage : ContentPage
	{
		public ContactsPage ()
		{
			InitializeComponent ();
            this.BindingContext = new ContactsPageViewModel(Navigation);
		}
	}
}