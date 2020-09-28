using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Contacts.Models
{
    public class ContactType
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        [Required]
        [Index(IsUnique = true)]
        [StringLength(25, ErrorMessage = "Contact type title cannot be longer than 25 characters.")]
        public string Title { get; set; }

        public virtual ICollection<Contact> Contacts { get; set; }
    }
}