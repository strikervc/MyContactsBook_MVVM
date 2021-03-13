using MyMobileContactsBook.Models;
using MyMobileContactsBook.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace MyMobileContactsBook.ViewModels
{
    public class HomeViewModel
    {
        public ObservableCollection<Contact> ContactsList { get; set; } = new ObservableCollection<Contact>();
        public ICommand AddCommand { get; set; }

        public ICommand DeleteCommand { get; set; }

        public ICommand MoreCommand { get; set; }


        public HomeViewModel(ObservableCollection<Contact> contacts)
        {
            ContactsList.Add(new Contact("Maria Pi", "809232323"));
            ContactsList.Add(new Contact("Charlin Agramonte", "809232323"));
                
    
            AddCommand = new Command(OnAddContact);
            MoreCommand = new Command<Contact>(OnMoreCommand);
            DeleteCommand = new Command<Contact>(OnDeleteCommand);
        }

        private async void OnMoreCommand(Contact contact)
        {

            var selectedAction = await App.Current.MainPage.DisplayActionSheet(null, "", "Cancel", null, $"Call +{contact.Phone}", "Edit");

            
            if (selectedAction == "Cancel")
            {
                
            }
            else if (selectedAction == $"Call +{contact.Phone}")
            {
                PlacePhoneCall(contact.Phone);
            }
        }

        public void PlacePhoneCall(string number)
        {
            try
            {
                PhoneDialer.Open(number);
            }
            catch (ArgumentNullException anEx)
            {
                // Number was null or white space
            }
            catch (FeatureNotSupportedException ex)
            {
                // Phone Dialer is not supported on this device.
            }
            catch (Exception ex)
            {
                // Other error has occurred.
            }
        }

        private void OnDeleteCommand(Contact contact)
        {

            if (ContactsList.Contains(contact))
            {
                ContactsList.Remove(contact);
            }
        }

        private async void OnAddContact()
        {
            await App.Current.MainPage.Navigation.PushAsync(new AddContactPage(ContactsList));
        }
    }
}
