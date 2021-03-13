using System;
using System.Collections.Generic;
using System.Text;

namespace MyMobileContactsBook.Models
{
    public class Contact
    {
        public Contact(string name, string phone)
        {
            Name = name;
            Phone = phone;
        }
        public string Name { get; set; }
        public string Phone { get; set; }
    }
}
