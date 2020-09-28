using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Contacts.Models
{
    public class Profile
    {
        public int ID { get; set; }

        [Required]
        [StringLength(25, ErrorMessage = "Доступная длина не более 25 символов.")]
        [Display(Name = "Фамилия")]
        [RegularExpression(@"^(\w|\s)*$", ErrorMessage = "Разрешены только алфавитно-цифровые символы и пробелы.")]
        public string LastName { get; set; }

        [Required]
        [StringLength(25, ErrorMessage = "Доступная длина не более 25 символов.")]
        [Display(Name = "Имя")]
        [RegularExpression(@"^(\w|\s)*$", ErrorMessage = "Разрешены только алфавитно-цифровые символы и пробелы.")]
        public string FirstName { get; set; }

        [StringLength(25, ErrorMessage = "Доступная длина не более 25 символов.")]
        [Display(Name = "Отчество")]
        [RegularExpression(@"^(\w|\s)*$", ErrorMessage = "Разрешены только алфавитно-цифровые символы и пробелы.")]
        public string MiddleName { get; set; }

        [Required]
        [DataType(DataType.Date)]
        // [Range(1900,2021, ErrorMessage = "Недопустимый год")]
        [Display(Name = "Дата рождения")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime BirthDate { get; set; }

        [StringLength(50, ErrorMessage = "Доступная длина не более 50 символов.")]
        [Display(Name = "Организация")]
        [RegularExpression(@"^(\w|\s|[""'])*$", ErrorMessage = "Разрешены только алфавитно-цифровые символы, пробелы или кавычки.")]
        public string Organization { get; set; }

        [StringLength(50, ErrorMessage = "Доступная длина не более 50 символов.")]
        [Display(Name = "Должность")]
        [RegularExpression(@"^(\w|\s|[""'])*$", ErrorMessage = "Разрешены только алфавитно-цифровые символы, пробелы или кавычки.")]
        public string JobTitle { get; set; }

        public virtual List<Contact> Contacts { get; set; }
    }
}