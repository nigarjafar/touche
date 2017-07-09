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


            ViewBag.menuItems = _context.MenuItems.Include(m => m.Category).ToList();
            ViewBag.Categories = _context.Categories
                               .Include(c => c.MenuItems)
                               .ToList();
            ViewBag.Chefs = _context.Chefs;
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}