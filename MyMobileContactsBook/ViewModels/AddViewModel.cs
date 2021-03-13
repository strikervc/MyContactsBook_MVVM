using MyMobileContactsBook.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace MyMobileContactsBook.ViewModels
{
    public class AddViewModel
    {
		public ICommand AddCommand { get; set; }


		Contact contact;
		public Contact NewContact
		{
			get
			{
				return contact;
			}
			set
			{
				contact = value;
				if (contact != null)
				return;
			}
		}

		public AddViewModel(ObservableCollection<Contact> contacts)
		{
			
			AddCommand = new Command(async () =>
			{
				contacts.Add(new Contact(NewContact.Name, NewContact.Phone));
				await App.Current.MainPage.Navigation.PopAsync();
			});	
			
		}

		public AddViewModel(ObservableCollection<Contact> contacts, Contact _selected)
		{
			NewContact = _selected;
			AddCommand = new Command(async () => {
				contacts.Add(_selected);
				await App.Current.MainPage.Navigation.PopAsync();
			});
		}			
		
	}

}

