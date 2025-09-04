using LearnerProject.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
    }
}