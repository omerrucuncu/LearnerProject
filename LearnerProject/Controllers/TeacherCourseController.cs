using LearnerProject.Models.Context;
using LearnerProject.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LearnerProject.Controllers
{
    public class CourseController : Controller
    {
        // GET: Course
        LearnerContext context = new LearnerContext();
        public ActionResult Index() // teacher course listing operations have been completed
        {
            var teacherName = Session["TeacherName"] as string; // Get the teacher's name from the session
            var courses = context.Courses.Where(c => c.Teacher.NameSurname == teacherName).ToList(); // Retrieve courses associated with the logged-in teacher

            return View(courses); // Pass the list of courses to the view
        }

        [HttpGet]
        public ActionResult AddCourse() // course add page loading has been completed
        {
            // For the course addition page, we might want to provide a list of categories for the teacher to choose from.
            ViewBag.Categories = new SelectList((context.Categories.Where(c => c.Status)).ToList(), "CategoryId", "Name"); // Only active categories are shown // Pass categories to the view for dropdown 
            // Also, we can set the TeacherId for the new course based on the logged-in teacher
            var teacherName = Session["TeacherName"] as string; // Get the teacher's name from the session
            var teacher = context.Teachers.FirstOrDefault(t => t.NameSurname == teacherName); // Find the teacher entity based on the name
            ViewBag.TeacherId = teacher?.TeacherId; // Pass the TeacherId to the view

            

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
            existingCourse.Name = course.Name;
            existingCourse.Icon = course.Icon;
            existingCourse.Description = course.Description;
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