using LearnerProject.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Web;
using System.Web.Mvc;

namespace LearnerProject.Controllers
{
    public class StudentReviewController : Controller
    {
        // GET: StudentReview
        LearnerContext context = new LearnerContext();
        public ActionResult Index()
        {
            // List all reviews from the database and pass them to the view for display  


            return View();
        }
    }
}