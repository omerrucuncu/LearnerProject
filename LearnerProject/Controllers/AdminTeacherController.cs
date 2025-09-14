using LearnerProject.Models.Context;
using LearnerProject.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LearnerProject.Controllers
{
    public class AdminTeacherController : Controller
    {
        // GET: AdminTeacher
        LearnerContext context = new LearnerContext();
        public ActionResult Index() // teacher listing operations have been completed
        {
            var teachers = context.Teachers.ToList();
            return View(teachers);
        }
        [HttpGet]
        public ActionResult AddTeacher() // teacher add page loading has been completed
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddTeacher(Teacher teacher) // teacher add operation has been completed
        {
            context.Teachers.Add(teacher);
            teacher.Status = true;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateTeacher(int id) // teacher listing operation has been completed
        {
            var teacher = context.Teachers.Find(id);
            if (teacher == null)
            {
                return HttpNotFound();
            }
            return View(teacher);
        }
        [HttpPost]
        public ActionResult UpdateTeacher(Teacher teacher) // teacher update operation has been completed
        {
            var existingTeacher = context.Teachers.Find(teacher.TeacherId); // Find the existing teacher in the database using the provided TeacherId
            if (existingTeacher == null)
            {
                return HttpNotFound();
            }
            existingTeacher.NameSurname = teacher.NameSurname; 
            existingTeacher.UserName = teacher.UserName;
            existingTeacher.Password = teacher.Password;
            existingTeacher.ImageUrl = teacher.ImageUrl;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult ChangeStatus(int id) // teacher status change operation has been completed
        {
            var teacher = context.Teachers.Find(id); 
            if (teacher == null) 
            {
                return HttpNotFound(); 
            }
            teacher.Status = !teacher.Status; // Toggle the status
            context.SaveChanges(); 
            return RedirectToAction("Index"); 
        }

    }
}