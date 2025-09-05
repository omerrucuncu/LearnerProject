using LearnerProject.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LearnerProject.Models.Entities;

namespace LearnerProject.Controllers
{
    public class AdminAdminController : Controller
    {
        LearnerContext context = new LearnerContext();
        // GET: AdminAdmin
        public ActionResult Index() // admin listing operations have been completed
        {
            var admins = context.Admins.ToList();
            return View(admins);
        }

        [HttpGet]
        public ActionResult AddAdmin() // admin add page loading has been completed
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddAdmin(Admin admin) // admin add operation has been completed
        {
            context.Admins.Add(admin);
            admin.Status = true;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateAdmin(int id) // admin listing operation has been completed
        {
            var admin = context.Admins.Find(id);
            if (admin == null)
            {
                return HttpNotFound();
            }
            return View(admin); // existing admin data is sent to the view
        }
        [HttpPost]
        public ActionResult UpdateAdmin(Admin admin) // admin update operation has been completed
        {
            var existingAdmin = context.Admins.Find(admin.AdminId);
            if (existingAdmin == null)
            {
                return HttpNotFound();
            }
            existingAdmin.NameSurname = admin.NameSurname;
            existingAdmin.UserName = admin.UserName;
            existingAdmin.Password = admin.Password;
            existingAdmin.ImageUrl = admin.ImageUrl;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteAdmin(int id) // admin delete operation has been completed
        {
            var admin = context.Admins.Find(id);
            if (admin != null)
            {
                context.Admins.Remove(admin);
                context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        public ActionResult MakeActive(int id) // admin activate operation has been completed
        {
            var admin = context.Admins.Find(id);
            if (admin != null)
            {
                admin.Status = true; // Reactivate by setting status to true
                context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        public ActionResult MakeInactive(int id) // admin deactivate operation has been completed
        {
            var admin = context.Admins.Find(id);
            if (admin != null)
            {
                admin.Status = false; // Soft delete by setting status to false
                context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

    }
}