using LearnerProject.Models.Context;
using LearnerProject.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace LearnerProject.Controllers
{
    public class AdminLoginController : Controller
    {
        // GET: AdminLogin
        LearnerContext context = new LearnerContext();
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Admin admin)
        {
            var adminInfo = context.Admins.FirstOrDefault(a => a.UserName == admin.UserName && a.Password == admin.Password);
            if (adminInfo != null) // If a matching admin is found in the database 
            {
                FormsAuthentication.SetAuthCookie(adminInfo.UserName,false);                 
                Session["AdminName"] = adminInfo.NameSurname; // Store the admin's name in the session 
                return RedirectToAction("Index", "AdminCourse"); // Redirect to the AdminAdmin controller's Index action
            }
            else
            {
                ModelState.AddModelError("", "Invalid username or password"); // Add an error message to the model state 
                return View(); // Return to the login view 
            }
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut(); // Sign out the user
            Session.Clear(); // Clear the session data 
            /*Session.Abandon();*/ // Abandon the session
            return RedirectToAction("Index", "Default"); // Redirect to the default page after logout 

        }

    }
}