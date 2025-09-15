using LearnerProject.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace LearnerProject.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        LearnerContext context = new LearnerContext();
        public ActionResult Index()
        {
            ViewBag.v1 = context.Courses.Count();
            ViewBag.v2 = context.Students.Count();
            ViewBag.v3 = context.Teachers.Count();
            ViewBag.v4 = context.Categories.Count();
            return View();
        }

        public PartialViewResult DefaultCoursePartial()
        {
            ViewBag.CourseCount = context.Courses.Count(); // Total number of courses 

            var values = context.Courses // Access the Courses DbSet from the context 
                .Include("Reviews") // Use string overload for Include
                .OrderByDescending(x => x.CourseId) 
                .Take(6) // Take the latest 6 courses
                .ToList();
            //var courses = context.Courses.Take(4).ToList();
            return PartialView(values);
        }

        public PartialViewResult DefaultTestimonialPartial()
        {
            var values = context.Testimonials.ToList();
            return PartialView(values);
        }

        public PartialViewResult DefaultCategoryPartial()
        {
            ViewBag.v1 = context.Courses.Where(x => x.Category.CategoryName == "Kodlama").Count();  // Number of courses in the "Kodlama" category


            var values = context.Categories.Where(x => x.Status == true).ToList();
            return PartialView(values);
        }

        public PartialViewResult DefaultClubPartial()
        {
            var values = context.Clubs.Where(x => x.Status == true).OrderByDescending(x => x.ClubId).Take(6).ToList();
            return PartialView(values);
        }
        public PartialViewResult DefaultAboutPartial()
        {

            var values = context.Abouts.Where(x => x.Status == true).ToList();
            return PartialView(values);
        }
        public PartialViewResult DefaultTeacherPartial()
        {
            var values = context.Teachers.Where(x => x.Status == true).OrderByDescending(x => x.TeacherId).Take(6).ToList();
            return PartialView(values);
        }

        public PartialViewResult DefaultFAQPartial()
        {
            //var values = context.FAQS.ToList();
            var values = context.FAQs.Where(x => x.Status == true).OrderByDescending(x => x.FAQId).Take(8).ToList();

            return PartialView(values);
        }

    }
}