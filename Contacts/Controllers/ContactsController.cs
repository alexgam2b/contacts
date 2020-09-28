using Contacts.DAL;
using Contacts.Models;
using Contacts.ViewModels;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Web.Mvc;
using System.Web.UI.WebControls.WebParts;

namespace Contacts.Controllers
{
    public class ContactsController: Controller
    {
        ContactsContext context = new ContactsContext();

        public ActionResult Index(string filter)
        {
            var profiles = from p in context.Profiles
                           select p;

            if (!filter.IsNullOrWhiteSpace())
            {
                if (DateTime.TryParse(filter, out DateTime date))
                {
                    profiles = from p in profiles
                               where p.BirthDate == date
                               select p;
                }
                else
                {
                    profiles = from p in profiles
                               where p.FirstName.Contains(filter) ||
                                     p.LastName.Contains(filter) ||
                                     p.MiddleName.Contains(filter) ||
                                     p.Organization.Contains(filter) ||
                                     p.JobTitle.Contains(filter)
                               select p;
                }
            }

            profiles = from p in profiles
                       orderby p.LastName
                       select p;
            
            return View(profiles.ToList());
        }

        public ActionResult Details(int? id = -1)
        {
            Profile profile = context.Profiles.Find(id);

            if (profile == null)
            {
                return HttpNotFound();
            }
            return View(profile);
        }

        public ActionResult Create()
        {
            ProfileViewModel model = new ProfileViewModel();
            model.Profile = new Profile();
            model.Profile.Contacts = new List<Contact>();
            model.Profile.BirthDate = DateTime.Parse("2000-01-01");
            model.ContactTypes = PopulateContactTypeList();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LastName,FirstName,MiddleName,BirthDate,Organization,JobTitle,Contacts")] Profile profile, int indexToDelete = -1)
        {
            if (indexToDelete >= 0 && indexToDelete < profile.Contacts.Count)
            {
                profile.Contacts.RemoveAt(indexToDelete);
            }
            else if (ModelState.IsValid)
            {
                try
                {
                    context.Profiles.Add(profile);
                    context.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (DataException)
                {
                    ModelState.AddModelError("dataError", "Не удалось сохранить изменения. Попробуйте еще раз, и если проблема не исчезнет, ​​обратитесь к системному администратору.");
                }
            }

            ProfileViewModel model = new ProfileViewModel();
            model.Profile = profile;
            if (profile.Contacts == null)
            {
                profile.Contacts = new List<Contact>();
            }
            model.ContactTypes = PopulateContactTypeList();
            return View(model);
        }

        public ActionResult Edit(int? id = -1)
        {
            Profile profile = context.Profiles.Find(id);
            if (profile == null)
            {
                return HttpNotFound();
            }
            ProfileViewModel model = new ProfileViewModel();
            model.Profile = profile;
            if (profile.Contacts == null)
            {
                profile.Contacts = new List<Contact>();
            }
            model.ContactTypes = PopulateContactTypeList();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,LastName,FirstName,MiddleName,BirthDate,Organization,JobTitle,Contacts")] Profile profile, int indexToDelete = -1)
        {
            if (indexToDelete >= 0 && indexToDelete < profile.Contacts.Count)
            {
                if (ModelState.IsValid)
                {
                    context.Entry(profile.Contacts[indexToDelete]).State = EntityState.Deleted;
                    context.SaveChanges();
                }
                profile.Contacts.RemoveAt(indexToDelete);
            }
            else if (ModelState.IsValid)
            {
                try
                {
                    context.Entry(profile).State = EntityState.Modified;
                    if (profile.Contacts != null)
                    {
                        foreach (Contact contact in profile.Contacts)
                        {
                            if (contact.ID == 0)
                            {
                                context.Contacts.Add(contact);
                            }
                            else
                            {
                                context.Entry(contact).State = EntityState.Modified;
                            }
                        }
                    }
                    context.SaveChanges();
                    return RedirectToAction("Details", new { ID = profile.ID });
                }
                catch (DataException)
                {
                    ModelState.AddModelError("dataError", "Не удалось сохранить изменения. Попробуйте еще раз, и если проблема не исчезнет, ​​обратитесь к системному администратору.");
                }
            }

            ProfileViewModel model = new ProfileViewModel();
            model.Profile = profile;
            if (profile.Contacts == null)
            {
                profile.Contacts = new List<Contact>();
            }
            model.ContactTypes = PopulateContactTypeList();
            return View(model);
        }

        private List<ContactType> PopulateContactTypeList()
        {
            var contactTypes = from t in context.Types
                               orderby t.ID
                               select t;

            ViewBag.ContactTypes = contactTypes.ToList();
            return contactTypes.ToList();
        }

        public ActionResult Delete(bool? saveChangesError, int id = -1)
        {
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Не удалось удалить. Попробуйте еще раз, и если проблема не исчезнет, ​​обратитесь к системному администратору.";
            }
            Profile profile = context.Profiles.Find(id);
            if (profile == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }
            return View(profile);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                Profile profileToDelete = context.Profiles.Find(id);
                context.Profiles.Remove(profileToDelete);
                context.SaveChanges();
            }
            catch (DataException)
            {
                return RedirectToAction("Delete", new { ID = id, saveChangesError = true });
            }
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                context.Dispose();
            }

            base.Dispose(disposing);
        }
    }
}