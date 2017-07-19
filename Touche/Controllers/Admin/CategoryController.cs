using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Touche.Models;

namespace Touche.Controllers.Admin
{
    public class CategoryController : Controller
    {
        // GET: Category
        private ApplicationDbContext _context;


        public CategoryController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: Category
        public ActionResult Index()
        {
            var categories = _context.Categories;
            return View("~/Views/Admin/Category/Index.cshtml", categories);
        }

        public ActionResult Create()
        {
            var Category = new Category();
            return View("~/Views/Admin/Category/Form.cshtml", Category);
        }

        public ActionResult Edit(int id)
        {
            var category = _context.Categories.SingleOrDefault(c => c.Id == id);
            return View("~/Views/Admin/Category/Form.cshtml", category);
        }

        public ActionResult Save(Category category, HttpPostedFileBase file)
        {

         
            if (category.Id == 0)
                _context.Categories.Add(category);
            else
            {
                var categoryInDb = _context.Categories.SingleOrDefault(c => c.Id == category.Id);
                categoryInDb.Name = category.Name;

            }

            _context.SaveChanges();
            return RedirectToAction("Index");
        }


        [HttpDelete]

        public ActionResult Delete(int id)
        {
            var categoryInDb = _context.Categories.SingleOrDefault(c => c.Id == id);
            _context.Categories.Remove(categoryInDb);
            _context.SaveChanges();
            return Content("success");

        }
    }
}