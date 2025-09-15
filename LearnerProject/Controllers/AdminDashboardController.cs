using LearnerProject.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LearnerProject.Controllers
{
    public class AdminDashboardController : Controller
    {
        // GET: AdminDashboard
        LearnerContext context = new LearnerContext();
        public ActionResult Index()
        {
            string adminName = Session["adminName"].ToString();
            var admin = context.Admins.Where(x => x.NameSurname == adminName).Select(x => x.AdminId).FirstOrDefault();
            ViewBag.v1 = context.Courses.Count();  // all courses count 
            ViewBag.v2 = context.Categories.Count(); // all categories count
            ViewBag.v3 = context.Clubs.Count(); // all clubs count
            ViewBag.v4 = context.Students.Count();
            ViewBag.v5 = context.Courses.OrderByDescending(x => x.Price).Select(x => x.CourseName).FirstOrDefault();  // the most expensive course name 
            ViewBag.v6 = context.Courses.Where(x => x.Category.CategoryName == "Coding").Count(); // number of courses in the "Kodlama" category
            ViewBag.v7 = context.Reviews.OrderByDescending(x => x.ReviewValue).Select(x => x.Course.CourseName).FirstOrDefault(); // course with the highest review score 
            ViewBag.v8 = context.Courses.Where(x => x.Category.CategoryName == "Music").Count(); // number of courses in the "Müzik" category
            ViewBag.v9 = context.Courses.Where(x => x.Category.CategoryName == "Sport").Count();
           
            var v10 = context.Reviews
                .GroupBy(r => r.CourseId)
                .OrderByDescending(g => g.Count())
                .Select(g => g.FirstOrDefault().Course.CourseName)
                .FirstOrDefault();
            ViewBag.v10 = v10; // course with the most reviews 


            var v11 = context.CourseRegisters
                .GroupBy(c => c.CourseId)
                .OrderByDescending(g => g.Count())
                .Select(g => g.FirstOrDefault().Course.CourseName)
                .FirstOrDefault(); // course with the most enrollments
            ViewBag.v11 = v11;

            return View();
        }
    }
}