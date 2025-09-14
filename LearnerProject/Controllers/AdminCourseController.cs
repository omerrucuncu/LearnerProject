using LearnerProject.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LearnerProject.Models.Entities;
using System.Web.UI.WebControls;

namespace LearnerProject.Controllers
{
    public class AdminCourseController : Controller
    {
        LearnerContext context = new LearnerContext();
        // GET: AdminCourse
        public ActionResult Index() // course listing operations have been completed
        {
            var courses = context.Courses.ToList();
            DropDownList ddl = new DropDownList(); // Create a DropDownList for categories
            ddl.DataSource = context.Categories.ToList(); ddl.DataBind(); // Bind categories to the DropDownList
            ViewBag.Categories = ddl; // Pass the DropDownList to the view using ViewBag

            return View(courses);
        }

        [HttpGet]
        public ActionResult AddCourse() // course add page loading has been completed
        {
            ViewBag.Teachers = new SelectList(context.Teachers.ToList(), "TeacherId", "NameSurname"); // Pass teachers to the view for dropdown 
            ViewBag.Categories = new SelectList(context.Categories.ToList(), "CategoryId", "CategoryName"); // Pass categories to the view for dropdown

            return View();
        }
        [HttpPost]
        public ActionResult AddCourse(Course course) // course add operation has been completed
        {
            context.Courses.Add(course);
            course.Status = true;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateCourse(int id) // course listing operation has been completed
        {
            ViewBag.Teachers = new SelectList(context.Teachers.ToList(), "TeacherId", "NameSurname"); // Pass teachers to the view for dropdown 
            ViewBag.Categories = new SelectList(context.Categories.ToList(), "CategoryId", "CategoryName"); // Pass categories to the view for dropdown

            var course = context.Courses.Find(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course); // existing course data is sent to the view
        }
        [HttpPost]
        public ActionResult UpdateCourse(Course course) // course update operation has been completed
        {
            var existingCourse = context.Courses.Find(course.CourseId);
            if (existingCourse == null)
            {
                return HttpNotFound();
            }
            existingCourse.CourseName = course.CourseName; // Update course name
            existingCourse.ImageUrl = course.ImageUrl; // Update image URL
            existingCourse.Description = course.Description;
            existingCourse.Price = course.Price; // Update price
            existingCourse.CategoryId = course.CategoryId;  // Update category 
            existingCourse.TeacherId = course.TeacherId;  // Updat e teacher 
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteCourse(int id) // course delete operation has been completed
        {
            var course = context.Courses.Find(id);
            if (course != null)
            {
                context.Courses.Remove(course);
                context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        public ActionResult MakeActive(int id) // course activate operation has been completed
        {
            var course = context.Courses.Find(id);
            if (course != null)
            {
                course.Status = true; // Reactivate by setting status to true
                context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        public ActionResult MakeInactive(int id) // course deactivate operation has been completed
        {
            var course = context.Courses.Find(id);
            if (course != null)
            {
                course.Status = false; // Soft delete by setting status to false
                context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

    }
}