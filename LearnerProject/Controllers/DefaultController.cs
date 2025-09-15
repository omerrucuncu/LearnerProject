using LearnerProject.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LearnerProject.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        LearnerContext context = new LearnerContext();
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult DefaultCoursePartial()
        {
            var courses = context.Courses.Take(4).ToList();
            return PartialView(courses);
        }
    }
}