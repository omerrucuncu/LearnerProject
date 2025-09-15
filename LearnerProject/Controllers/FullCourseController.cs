using LearnerProject.Models.Context;
using LearnerProject.Models.Entities;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LearnerProject.Controllers
{
    public class FullCourseController : Controller
    {
        // GET: FullCourse
        LearnerContext context = new LearnerContext();

        //[HttpGet]
        public ActionResult Index()
        {
            ViewBag.v1 = context.Courses.Count();

            return View();
        }

        public PartialViewResult CourseInfo()
        {
            ViewBag.v1 = context.Courses.Count();
            var values = context.Courses.Include(x => x.Reviews).OrderByDescending(x => x.CourseId).ToList();

            //var values = context.Courses.Where(x => x.Status == true).ToList();
            return PartialView(values);
        }
    }
}