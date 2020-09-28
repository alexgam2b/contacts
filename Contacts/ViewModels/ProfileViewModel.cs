using Contacts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Contacts.ViewModels
{
    public class ProfileViewModel
    {
        public Profile Profile { get; set; }
        public List<ContactType> ContactTypes { get; set; }
    }
}