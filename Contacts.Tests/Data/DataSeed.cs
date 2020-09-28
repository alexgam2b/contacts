using System;
using System.Collections.Generic;
using System.Linq;
using Contacts.DAL;
using Contacts.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Data
{
    [TestClass]
    public class DataSeed
    {
        [TestMethod]
        public void Seed()
        {
            ContactsContext context = new ContactsContext();

            if (context.Profiles.Any())
            {
                Assert.IsTrue(true);
                return;
            }

            var profiles = new List<Profile>
            {
                new Profile
                {
                    LastName="Николаев",
                    FirstName="Александр",
                    MiddleName="Гаврилович",
                    BirthDate=new DateTime(1995, 8, 26),
                    Organization="Николаев и КО",
                    JobTitle="Руководитель"
                },
                new Profile
                {
                    LastName="Быков",
                    FirstName="Максим",
                    MiddleName="Иванович",
                    BirthDate=new DateTime(1989, 11, 1),
                    Organization="ГазНефть",
                    JobTitle="Инженер"
                },
                new Profile
                {
                    LastName="Никифоров",
                    FirstName="Артём",
                    MiddleName="",
                    BirthDate=new DateTime(1990, 5, 12),
                    Organization="МеталКопал",
                    JobTitle="Водитель"
                },
                new Profile
                {
                    LastName="Фролов",
                    FirstName="Михаил",
                    MiddleName="Владимирович",
                    BirthDate=new DateTime(1993, 9, 5),
                    Organization="Електромонтаж",
                    JobTitle="Электромонтажник"
                },
                new Profile
                {
                    LastName="Волков",
                    FirstName="Иван",
                    MiddleName="",
                    BirthDate=new DateTime(1990, 10, 12),
                    Organization="",
                    JobTitle="Адвокат"
                },
                new Profile
                {
                    LastName="Рябов",
                    FirstName="Дмитрий",
                    MiddleName="Михайлович",
                    BirthDate=new DateTime(2001, 8, 21),
                    Organization="",
                    JobTitle="Продавец"
                },
                new Profile
                {
                    LastName="Маслов",
                    FirstName="Кирилл",
                    MiddleName="Анатольевич",
                    BirthDate=new DateTime(1985, 10, 23),
                    Organization="ООО Тудей Банк",
                    JobTitle=""
                }
            };

            profiles.ForEach(prof => context.Profiles.Add(prof));
            context.SaveChanges();

            var contactData = new List<Contact>
            {
                new Contact
                {
                    ProfileID=1,
                    ContactTypeID=100,
                    Value="+7 747-528-5957"
                },
                new Contact
                {
                    ProfileID=1,
                    ContactTypeID=200,
                    Value="nikolaev@nikiko.ru"
                },
                new Contact
                {
                    ProfileID=1,
                    ContactTypeID=300,
                    Value="4909842975"
                },
                new Contact
                {
                    ProfileID=2,
                    ContactTypeID=200,
                    Value="bykov@gasoil.ru"
                },
                new Contact
                {
                    ProfileID=2,
                    ContactTypeID=300,
                    Value="bykov.mi@skype.com"
                },
                new Contact
                {
                    ProfileID=3,
                    ContactTypeID=100,
                    Value="+7 769-602-2202"
                },
                new Contact
                {
                    ProfileID=4,
                    ContactTypeID=100,
                    Value="+7 826-323-2544"
                },
                new Contact
                {
                    ProfileID=5,
                    ContactTypeID=100,
                    Value="+7 598-357-1363"
                },
                new Contact
                {
                    ProfileID=5,
                    ContactTypeID=200,
                    Value="volkov@advokaty.ru"
                },
                new Contact
                {
                    ProfileID=5,
                    ContactTypeID=1000,
                    Value="www.advokaty.ru"
                },
                new Contact
                {
                    ProfileID=6,
                    ContactTypeID=100,
                    Value="+7 140-428-5967"
                },
                new Contact
                {
                    ProfileID=7,
                    ContactTypeID=100,
                    Value="+7 638-823-1405"
                },
                new Contact
                {
                    ProfileID=7,
                    ContactTypeID=100,
                    Value="+7 906-351-7560"
                }
            };

            contactData.ForEach(cont => context.Contacts.Add(cont));
            context.SaveChanges();

            Assert.IsTrue(true);
        }
    }
}
