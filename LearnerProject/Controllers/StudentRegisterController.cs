using LearnerProject.Models.Context;
using LearnerProject.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LearnerProject.Controllers
{
    public class StudentRegisterController : Controller
    {
        // GET: StudentRegister
        LearnerContext context = new LearnerContext();
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Student student) // student registration operation has been completed
        {
            context.Students.Add(student); // Add the new student to the database
            student.Status = true; // New students are active by default
            context.SaveChanges(); // Save changes to the database
            return RedirectToAction("Index", "StudentLogin"); // Redirect to the StudentLogin controller's Index action after successful registration
        }
    }
}