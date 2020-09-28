using Contacts.DAL;
using Contacts.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Contacts.App_Start
{
    public class DataInitializer: CreateDatabaseIfNotExists<ContactsContext>
    {
        protected override void Seed(ContactsContext context)
        {
            var contactTypes = new List<ContactType>
            {
                new ContactType { ID = 100, Title="Телефон" },
                new ContactType { ID = 200, Title="Email" },
                new ContactType { ID = 300, Title="Skype" },
                new ContactType { ID = 1000, Title="Другое" }
            };

            contactTypes.ForEach(t => context.Types.Add(t));

            base.Seed(context);
        }
    }
}