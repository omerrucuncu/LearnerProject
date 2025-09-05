using LearnerProject.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LearnerProject.Models.Entities;

namespace LearnerProject.Controllers
{
    public class AdminBannerController : Controller
    {
        LearnerContext context = new LearnerContext();
        // GET: AdminBanner
        public ActionResult Index() // banner listing operations have been completed
        {
            var banners = context.Banners.ToList();
            return View(banners);
        }

        [HttpGet]
        public ActionResult AddBanner() // banner add page loading has been completed
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddBanner(Banner banner) // banner add operation has been completed
        {
            context.Banners.Add(banner);
            banner.Status = true;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateBanner(int id) // banner listing operation has been completed
        {
            var banner = context.Banners.Find(id);
            if (banner == null)
            {
                return HttpNotFound();
            }
            return View(banner); // existing banner data is sent to the view
        }
        [HttpPost]
        public ActionResult UpdateBanner(Banner banner) // banner update operation has been completed
        {
            var existingBanner = context.Banners.Find(banner.BannerId);
            if (existingBanner == null)
            {
                return HttpNotFound();
            }
            existingBanner.Title = banner.Title;            
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteBanner(int id) // banner delete operation has been completed
        {
            var banner = context.Banners.Find(id);
            if (banner != null)
            {
                context.Banners.Remove(banner);
                context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        public ActionResult MakeActive(int id) // banner activate operation has been completed
        {
            var banner = context.Banners.Find(id);
            if (banner != null)
            {
                banner.Status = true; // Reactivate by setting status to true
                context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        public ActionResult MakeInactive(int id) // banner deactivate operation has been completed
        {
            var banner = context.Banners.Find(id);
            if (banner != null)
            {
                banner.Status = false; // Soft delete by setting status to false
                context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

    }
}