using LearnerProject.Models.Context;
using LearnerProject.Models.Entities;
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
        public ActionResult Index() // Display the reviews of the logged-in student 
        {
            // List all reviews from the database and pass them to the view for display  
            string studentName = Session["studentName"] as string; // Get the student's name from the session
            var student = context.Students.Where(s => s.NameSurname == studentName).Select(x => x.StudentId).FirstOrDefault(); // Find the student entity based on the name
            var reviews = context.Reviews.Where(r => r.StudentId == student).ToList(); // Retrieve reviews associated with the logged-in student

            return View(reviews);
        }

        [HttpGet]
        public ActionResult AddStudentReview() // Load the page for adding a new review
        {
            // Provide a list of courses for the student to choose from when adding a review
            ViewBag.Courses = new SelectList((context.Courses.Where(c => c.Status)).ToList(), "CourseId", "CourseName"); // Only active courses are shown // Pass courses to the view for dropdown 
            return View();
        }
        [HttpPost]
        public ActionResult AddStudentReview(Review review) // Handle the submission of a new review
        {
            string studentName = Session["studentName"] as string; // Get the student's name from the session
            var student = context.Students.Where(s => s.NameSurname == studentName).Select(x => x.StudentId).FirstOrDefault(); // Find the student entity based on the name
            review.StudentId = student; // Set the StudentId for the new review
            /*review.Date = DateTime.Now;*/ // Set the current date for the review
            context.Reviews.Add(review); // Add the new review to the database
            review.Status = true; // New reviews are active by default
            context.SaveChanges(); // Save changes to the database
            return RedirectToAction("Index"); // Redirect to the review listing page after adding the review
        }
        [HttpGet]
        public ActionResult UpdateStudentReview(int id) // Load the page for updating an existing review
        {
            ViewBag.Courses = new SelectList((context.Courses.Where(c => c.Status)).ToList(), "CourseId", "CourseName"); // Only active courses are shown // Pass courses to the view for dropdown
            var review = context.Reviews.Find(id);
            if (review == null)
            {
                return HttpNotFound();
            }
            return View(review); // existing review data is sent to the view
        }
        [HttpPost]
        public ActionResult UpdateStudentReview(Review review) // Handle the submission of an updated review
        {
            string studentName = Session["studentName"] as string; // Get the student's name from the session
            review.StudentId = context.Students.Where(s => s.NameSurname == studentName).Select(x => x.StudentId).FirstOrDefault(); // Find the student entity based on the name
            var existingReview = context.Reviews.Find(review.ReviewId);
            if (existingReview == null)
            {
                return HttpNotFound();
            }
            existingReview.CourseId = review.CourseId;
            existingReview.ReviewValue = review.ReviewValue;
            existingReview.Comment = review.Comment;
            existingReview.StudentId = review.StudentId;
            context.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult ChangeStatus(int id) // Change the status of a review (active/inactive)
        {
            var review = context.Reviews.Find(id);
            if (review == null)
            {
                return HttpNotFound();
            }
            review.Status = !review.Status; // Toggle the status
            context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}