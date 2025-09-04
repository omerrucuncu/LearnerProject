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
        public ActionResult Index()
        {
            var clubs = context.Clubs.ToList();
            return View(clubs);
        }

        [HttpGet]
        public ActionResult AddClub()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddClub(Club club)
        {
            context.Clubs.Add(club);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateClub(int id)
        {
            var club = context.Clubs.Find(id);
            return View("UpdateClub", club);
        }
        [HttpPost]
        public ActionResult UpdateClub(Club club)
        {
            context.Entry(club).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteClub(int id)
        {
            var club = context.Clubs.Find(id);
            if (club != null)
            {
                context.Clubs.Remove(club);
                context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

    }
}