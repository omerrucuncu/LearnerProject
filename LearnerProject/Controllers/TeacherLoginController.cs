using LearnerProject.Models.Context;
using LearnerProject.Models.Entities;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace LearnerProject.Controllers
{
    public class TeacherLoginController : Controller
    {
        LearnerContext context = new LearnerContext();
        // GET: TeacherLogin
        [HttpGet]
        public ActionResult Index() // teacher login page loading has been completed
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Teacher teacher) // teacher login operation has been completed
        {
            var ti = context.Teachers.FirstOrDefault(t => t.UserName == teacher.UserName && t.Password == teacher.Password); // Check if there is a teacher with the given username and password
            if (ti != null) // If a matching teacher is found
            {
                FormsAuthentication.SetAuthCookie(ti.UserName, false); // Set the authentication cookie for the teacher 
                Session["UserName"] = ti.UserName; // Store the username in the session
                return RedirectToAction("Index", "TeacherCourse"); // Redirect to the TeacherCourse controller's Index action
            }
            else
            {
                ModelState.AddModelError("", "Invalid username or password"); // Add an error message to the model state
                return View(); // Return to the login view
            }
        }
        
        public ActionResult Logout() // teacher logout operation has been completed
        {
            Session.Clear(); // Clear the session
            return RedirectToAction("Index"); // Redirect to the login page
        }



    }
}