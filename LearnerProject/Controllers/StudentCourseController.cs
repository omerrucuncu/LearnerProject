using LearnerProject.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;

namespace LearnerProject.Controllers
{
    public class StudentCourseController : Controller
    {
        // GET: StudentCourse
        LearnerContext context = new LearnerContext();

        public ActionResult Index(int pageNumber = 1) // pageNumber parameter for pagination
        {
            string studentName = Session["studentName"].ToString(); // Get the logged-in student's name from the session
            var student = context.Students.Where(x => x.NameSurname == studentName).Select(x => x.StudentId).FirstOrDefault(); // Get the logged-in student's ID
            var values = context.CourseRegisters.Where(x => x.StudentId == student).ToList(); // Fetch courses registered by the logged-in student

            return View(values);
        }

        public ActionResult MyCourseList(int id, int pageNumber = 1) // id is course id 
        {
            var values = context.CourseVideos.Where(x => x.CourseId == id).ToList().ToPagedList(pageNumber, 2); // Paginate with 2 items per page 
            return View(values); // Return the paginated list to the view
        }
    }
}