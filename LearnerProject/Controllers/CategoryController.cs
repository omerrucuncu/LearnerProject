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
            category.Status = true; // New categories are active by default
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
            return View(category); // existing category data is sent to the view
        }
        [HttpPost]
        public ActionResult UpdateCategory(Category category) // category update operation has been completed
        {
            var existingCategory = context.Categories.Find(category.CategoryId); // existing category is fetched from the database
            if (existingCategory == null)
            {
                return HttpNotFound(); // if not found, return 404
            }
            existingCategory.CategoryName = category.CategoryName; // update the fields
            existingCategory.Icon = category.Icon; // update the fields
            existingCategory.Status = true; // ensure the category remains active after update
            context.SaveChanges(); // save changes to the database
            return RedirectToAction("Index"); // redirect to the category list
        }

        public ActionResult MakeActive(int id) // category make active operation has been completed
        {
            var category = context.Categories.Find(id); // find the category by id
            if (category != null)
            {
                category.Status = true; // Set status to true to make it active
                context.SaveChanges(); // save changes to the database
            }
            return RedirectToAction("Index"); // redirect to the category list
        }

        public ActionResult MakeInactive(int id) // category make inactive operation has been completed
        {
            var category = context.Categories.Find(id); // find the category by id
            if (category != null)
            {
                category.Status = false; // Set status to false to make it inactive
                context.SaveChanges(); // save changes to the database
            }
            return RedirectToAction("Index"); // redirect to the category list
        }
    }
}