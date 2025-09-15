using LearnerProject.Models.Context;
using LearnerProject.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LearnerProject.Controllers
{
    public class StudentLoginController : Controller
    {
        // GET: StudentLogin
        LearnerContext context = new LearnerContext();
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Student student) // student login operation has been completed
        {
            var si = context.Students.FirstOrDefault(s => s.UserName == student.UserName && s.Password == student.Password); // Check if there is a student with the given username and password
            if (si != null) // If a matching student is found
            {
                Session["studentName"] = si.NameSurname; // Store the student's name in the session
                return RedirectToAction("Index", "StudentCourse"); // Redirect to the StudentCourse controller's Index action
            }
            else
            {
                ModelState.AddModelError("", "Invalid username or password"); // Add an error message to the model state
                return View(); // Return to the login view
            }
        }
        public ActionResult Logout() // student logout operation has been completed
        {
            Session.Clear(); // Clear the session
            return RedirectToAction("Index","Default"); // Redirect to the login page
        }
    }
}