using LearnerProject.Models.Context;
using System.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LearnerProject.Controllers
{
    public class FullTeacherController : Controller
    {

        LearnerContext context = new LearnerContext();

        //[HttpGet]
        public ActionResult Index()
        {
            ViewBag.v1 = context.Teachers.Count();

            return View();
        }

        public PartialViewResult TeacherInfo()
        {
            ViewBag.v1 = context.Teachers.Count();
            var values = context.Teachers.ToList();

            //var values = context.Courses.Where(x => x.Status == true).ToList();
            return PartialView(values);
        }
    }
}