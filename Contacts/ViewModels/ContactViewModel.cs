using Contacts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Contacts.ViewModels
{
    public class ContactViewModel
    {
        public List<Contact> Contacts { get; set; }
        public List<ContactType> ContactTypes { get; set; }
    }
}