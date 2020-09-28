using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Contacts.Models
{
    public class Contact
    {
        public int ID { get; set; }

        [Required]
        [Index(IsClustered = true)]
        public int ProfileID { get; set; }

        [Required]
        public int ContactTypeID { get; set; }

        [Required(ErrorMessage = "Данное поле необходимо заполнить.")]
        [StringLength(50, ErrorMessage = "Доступная длина не более 50 символов.")]
        [RegularExpression(@"^(\w|\s|[""'.@])*$", ErrorMessage = "Разрешены только алфавитно-цифровые и некоторые специальные символы.")]
        public string Value { get; set; }

        public virtual Profile Profile { get; set; }
        public virtual ContactType Type { get; set; }
    }
}