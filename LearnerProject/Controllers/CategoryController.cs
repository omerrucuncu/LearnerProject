using LearnerProject.Models.Context;
using LearnerProject.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LearnerProject.Controllers
{
    public class CategoryController : Controller
    {
        LearnerContext context = new LearnerContext();
        // GET: Category
        public ActionResult Index() // category listing operations have been completed

        {
            var categories = context.Categories.ToList();
            return View(categories);
        }

        public ActionResult DeleteCategory(int id) // category delete operation has been completed
        {
            var category = context.Categories.Find(id);
            if (category != null)
            {
                category.Status = false; // Soft delete by setting status to false
                context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult AddCategory() // category listing operation has been completed
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddCategory(Category category)  // category add operation has been completed
        {
            context.Categories.Add(category);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateCategory(int id) // category listing operation has been completed
        {
            var category = context.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }
        [HttpPost]
        public ActionResult UpdateCategory(Category category) // category update operation has been completed
        {
            var existingCategory = context.Categories.Find(category.CategoryId);
            if (existingCategory == null)
            {
                return HttpNotFound();
            }
            existingCategory.CategoryName = category.CategoryName;
            existingCategory.Icon = category.Icon;
            existingCategory.Status = true; 
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult MakeActive(int id) // category make active operation has been completed
        {
            var category = context.Categories.Find(id);
            if (category != null)
            {
                category.Status = true; // Set status to true to make it active
                context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public ActionResult MakeInactive(int id) // category make inactive operation has been completed
        {
            var category = context.Categories.Find(id);
            if (category != null)
            {
                category.Status = false; // Set status to false to make it inactive
                context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}