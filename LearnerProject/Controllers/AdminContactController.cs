using LearnerProject.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LearnerProject.Models.Entities;

namespace LearnerProject.Controllers
{
    public class AdminContactController : Controller
    {
        LearnerContext context = new LearnerContext();
        // GET: AdminContact
        public ActionResult Index() // contact listing operations have been completed
        {
            var contacts = context.Contacts.ToList();
            return View(contacts);
        }

        [HttpGet]
        public ActionResult AddContact() // contact add page loading has been completed
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddContact(Contact contact) // contact add operation has been completed
        {
            context.Contacts.Add(contact);
            contact.Status = true;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateContact(int id) // contact listing operation has been completed
        {
            var contact = context.Contacts.Find(id);
            if (contact == null)
            {
                return HttpNotFound();
            }
            return View(contact); // existing contact data is sent to the view
        }
        [HttpPost]
        public ActionResult UpdateContact(Contact contact) // contact update operation has been completed
        {
            var existingContact = context.Contacts.Find(contact.ContactId);
            if (existingContact == null)
            {
                return HttpNotFound();
            }
            existingContact.Address = contact.Address;
            existingContact.OpenHours = contact.OpenHours;
            existingContact.Email = contact.Email;
            existingContact.Phone = contact.Phone;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteContact(int id) // contact delete operation has been completed
        {
            var contact = context.Contacts.Find(id);
            if (contact != null)
            {
                context.Contacts.Remove(contact);
                context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        public ActionResult MakeActive(int id) // contact activate operation has been completed
        {
            var contact = context.Contacts.Find(id);
            if (contact != null)
            {
                contact.Status = true; // Reactivate by setting status to true
                context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        public ActionResult MakeInactive(int id) // contact deactivate operation has been completed
        {
            var contact = context.Contacts.Find(id);
            if (contact != null)
            {
                contact.Status = false; // Soft delete by setting status to false
                context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

    }
}