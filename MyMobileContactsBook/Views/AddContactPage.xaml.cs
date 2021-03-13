using MyMobileContactsBook.Models;
using MyMobileContactsBook.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyMobileContactsBook.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddContactPage : ContentPage
    {
		public AddContactPage(ObservableCollection<Contact> contactsList)
		{
			InitializeComponent();
			BindingContext = new AddViewModel(contactsList);
		}

		public AddContactPage(ObservableCollection<Contact> contactsList, Contact selected)
		{
			InitializeComponent();
			BindingContext = new AddViewModel(contactsList, selected);
		}
	}
}