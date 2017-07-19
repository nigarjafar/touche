using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Touche.Models;
using System.Data.Entity;

namespace Touche.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext _context;
        private object newEntityModel;

        public HomeController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        public ActionResult Index()
        {
            ViewBag.MenuItems = _context.MenuItems.Include(m => m.Category).ToList();
            ViewBag.Categories = _context.Categories
                               .Include(c => c.MenuItems)
                               .ToList();
            ViewBag.Chefs = _context.Chefs;
            ViewBag.Slider = _context.Slider.Single(s => s.Id == 1);
            return View();
        }

        public ActionResult AddReview(Review review)
        {
            if(!ModelState.IsValid)
                return new HttpStatusCodeResult(400, "zəhmət olmasa, bütün xanaları doldurun"); // Bad Request

            _context.Reviews.Add(review);
            _context.SaveChanges();
            return new HttpStatusCodeResult(200); 
        }
    }
}