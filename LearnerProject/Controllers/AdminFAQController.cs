using LearnerProject.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LearnerProject.Models.Entities;

namespace LearnerProject.Controllers
{
    public class AdminFAQController : Controller
    {
        LearnerContext context = new LearnerContext();
        // GET: AdminFAQ
        public ActionResult Index() // faq listing operations have been completed
        {
            var faqs = context.FAQs.ToList();
            return View(faqs);
        }

        [HttpGet]
        public ActionResult AddFAQ() // faq add page loading has been completed
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddFAQ(FAQ faq) // faq add operation has been completed
        {
            context.FAQs.Add(faq);
            faq.Status = true;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateFAQ(int id) // faq listing operation has been completed
        {
            var faq = context.FAQs.Find(id);
            if (faq == null)
            {
                return HttpNotFound();
            }
            return View(faq); // existing faq data is sent to the view
        }
        [HttpPost]
        public ActionResult UpdateFAQ(FAQ faq) // faq update operation has been completed
        {
            var existingFAQ = context.FAQs.Find(faq.FAQId);
            if (existingFAQ == null)
            {
                return HttpNotFound();
            }
            existingFAQ.Question = faq.Question;
            existingFAQ.Answer = faq.Answer;
            existingFAQ.ImageUrl = faq.ImageUrl;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteFAQ(int id) // faq delete operation has been completed
        {
            var faq = context.FAQs.Find(id);
            if (faq != null)
            {
                context.FAQs.Remove(faq);
                context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        public ActionResult MakeActive(int id) // faq activate operation has been completed
        {
            var faq = context.FAQs.Find(id);
            if (faq != null)
            {
                faq.Status = true; // Reactivate by setting status to true
                context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        public ActionResult MakeInactive(int id) // faq deactivate operation has been completed
        {
            var faq = context.FAQs.Find(id);
            if (faq != null)
            {
                faq.Status = false; // Soft delete by setting status to false
                context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

    }
}