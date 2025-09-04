using LearnerProject.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LearnerProject.Models.Entities;

namespace LearnerProject.Controllers
{
    public class AdminClubController : Controller
    {
        LearnerContext context = new LearnerContext();
        // GET: AdminClub
        public ActionResult Index() // club listing operations have been completed
        {
            var clubs = context.Clubs.ToList();
            return View(clubs);
        }

        [HttpGet]
        public ActionResult AddClub() // club add page loading has been completed
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddClub(Club club) // club add operation has been completed
        {
            context.Clubs.Add(club);
            club.Status = true;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateClub(int id) // club listing operation has been completed
        {
            var club = context.Clubs.Find(id);
            if (club == null)
            {
                return HttpNotFound();
            }
            return View(club); // existing club data is sent to the view
        }
        [HttpPost]
        public ActionResult UpdateClub(Club club) // club update operation has been completed
        {
            var existingClub = context.Clubs.Find(club.ClubId);
            if (existingClub == null)
            {
                return HttpNotFound();
            }
            existingClub.Name = club.Name;
            existingClub.Icon = club.Icon;
            existingClub.Description = club.Description;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteClub(int id) // club delete operation has been completed
        {
            var club = context.Clubs.Find(id);
            if (club != null)
            {
                context.Clubs.Remove(club);
                context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        public ActionResult MakeActive(int id) // club activate operation has been completed
        {
            var club = context.Clubs.Find(id);
            if (club != null)
            {
                club.Status = true; // Reactivate by setting status to true
                context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        public ActionResult MakeInactive(int id) // club deactivate operation has been completed
        {
            var club = context.Clubs.Find(id);
            if (club != null)
            {
                club.Status = false; // Soft delete by setting status to false
                context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

    }
}