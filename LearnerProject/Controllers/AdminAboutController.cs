using LearnerProject.Models.Context;
using LearnerProject.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Mvc;

namespace LearnerProject.Controllers
{
    public class AdminAboutController : Controller
    {
        LearnerContext context = new LearnerContext();
        // GET: About
        public ActionResult Index()
        {
            var abouts = context.Abouts.ToList();
            return View(abouts);
        } 

        public ActionResult MakeActive(int id)
        {
            var about = context.Abouts.Find(id);
            if (about != null)
            {
                about.Status = true; // Set status to true to make it active
                context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public ActionResult MakeInactive(int id)
        {
            var about = context.Abouts.Find(id);
            if (about != null)
            {
                about.Status = false; // Set status to false to make it inactive
                context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateAbout(int id)
        {
            var about = context.Abouts.Find(id);
            if (about == null)
            {
                return HttpNotFound();
            }
            return View(about); // existing about data is sent to the view
        }
        [HttpPost]
        public ActionResult UpdateAbout(About about)
        {
            var existingAbout = context.Abouts.Find(about.AboutId); // existing about is fetched from the database
            if (existingAbout == null)
            {
                return HttpNotFound(); // if not found, return 404
            }
            existingAbout.Title = about.Title; // update the fields
            existingAbout.Description = about.Description; // update the fields
            existingAbout.ImageUrl = about.ImageUrl; // update the fields
            existingAbout.Item1 = about.Item1; // update the fields
            existingAbout.Item2 = about.Item2; // update the fields
            existingAbout.Item3 = about.Item3; // update the fields
            existingAbout.Status = true; // ensure the about remains active after update
            context.SaveChanges(); // save changes to the database
            return RedirectToAction("Index"); // redirect to the about list

           
        }

        [HttpGet]
        public ActionResult AddAbout() // about listing operation has been completed
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddAbout(About about)  // about add operation has been completed
        {
            about.Status = true; // New abouts are active by default
            context.Abouts.Add(about);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}