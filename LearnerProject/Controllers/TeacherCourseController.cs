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
            var teacherName = Session["TeacherName"].ToString(); // Get the teacher's name from the session
            var courses = context.Courses.Where(c => c.Teacher.NameSurname == teacherName).ToList(); // Retrieve courses associated with the logged-in teacher

            return View(courses); // Pass the list of courses to the view
        }

        [HttpGet]
        public ActionResult AddTeacherCourse() // course add page loading has been completed
        {
            // For the course addition page, we might want to provide a list of categories for the teacher to choose from.
            ViewBag.Categories = new SelectList((context.Categories.Where(c => c.Status)).ToList(), "CategoryId", "Name"); // Only active categories are shown // Pass categories to the view for dropdown 
            // Also, we can set the TeacherId for the new course based on the logged-in teacher
            var teacherName = Session["TeacherName"] as string; // Get the teacher's name from the session
            var teacher = context.Teachers.FirstOrDefault(t => t.NameSurname == teacherName); // Find the teacher entity based on the name
            ViewBag.TeacherId = teacher?.TeacherId; // Pass the TeacherId to the view /


             return View("~/Views/Course/AddTeacherCourse.cshtml");
        }
        [HttpPost]
        public ActionResult AddTeacherCourse(Course course) // course add operation has been completed
        {
            string teacherName = Session["TeacherName"] as string; // Get the teacher's name from the session
            var teacher = context.Teachers.Where(t => t.NameSurname == teacherName).Select(x => x.TeacherId).FirstOrDefault(); // Find the teacher entity based on the name
            context.Courses.Add(course); // Add the new course to the database
            course.Status = true; // New courses are active by default
            context.SaveChanges(); // Save changes to the database
            return RedirectToAction("Index"); // Redirect to the course listing page after adding the course
        }
        [HttpGet]
        public ActionResult UpdateTeacherCourse(int id) // course listing operation has been completed
        {
            var course = context.Courses.Find(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course); // existing course data is sent to the view
        }
        [HttpPost]
        public ActionResult UpdateTeacherCourse(Course course) // course update operation has been completed
        {
            var existingCourse = context.Courses.Find(course.CourseId);
            if (existingCourse == null)
            {
                return HttpNotFound();
            }
            existingCourse.ImageUrl = course.ImageUrl;
            existingCourse.CourseName = course.CourseName;
            existingCourse.Description = course.Description;
            existingCourse.Price = course.Price;
            existingCourse.Category.CategoryId = course.Category.CategoryId;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteTeacherCourse(int id) // course delete operation has been completed
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