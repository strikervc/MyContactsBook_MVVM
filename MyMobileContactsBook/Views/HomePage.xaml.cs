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
    public partial class HomePage : ContentPage
    {
        public HomePage(ObservableCollection<Contact> contacts)
        {
            InitializeComponent();
            BindingContext = new HomeViewModel(contacts);

        }
    }
}