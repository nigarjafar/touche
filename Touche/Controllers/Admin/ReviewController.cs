using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ObjectDumper;
using Touche.Models;

namespace Touche.Controllers.Admin
{
    public class ReviewController : Controller
    {
        private ApplicationDbContext _context;

        public ReviewController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: Review
        public ActionResult Index()
        {
            var reviews = _context.Reviews;

            return View("~/Views/Admin/Review/Index.cshtml", reviews);
        }


        public ActionResult Delete(int id)
        {
            var reviewInDb = _context.Reviews.SingleOrDefault(c => c.Id == id);
            _context.Reviews.Remove(reviewInDb);
            _context.SaveChanges();
            return Content("success");

        }

        public ActionResult Details(int id)
        {
            Review review = _context.Reviews.Single(r => r.Id == id);
            return View("~/Views/Admin/Review/View.cshtml", review);
        }




    }
}