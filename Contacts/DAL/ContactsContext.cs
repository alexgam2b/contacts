using Contacts.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Contacts.DAL
{
    public class ContactsContext: DbContext
    {
        public ContactsContext(): base("ContactsConnection") { }

        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<ContactType> Types { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contact>().HasKey(c => c.ID, config => config.IsClustered(false));
            base.OnModelCreating(modelBuilder);
        }
    }
}