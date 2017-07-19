using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Touche.Models;

namespace Touche.Controllers.Admin
{
    public class RestaurantController : Controller
    {
        private ApplicationDbContext _context;

        public RestaurantController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: Restaurant
        public ActionResult Index()
        {
            var restaurant = _context.Restaurant.Single(r=>r.Id==1);
            return View("~/Views/Admin/Restaurant/Index.cshtml", restaurant);
        }

        public ActionResult Edit()
        {
            var restaurant = _context.Restaurant.Single(r => r.Id == 1);
            return View("~/Views/Admin/Restaurant/Edit.cshtml", restaurant);
        }

        public ActionResult Save(Restaurant restaurant, HttpPostedFileBase file)
        {
            var restaurantInDb = _context.Restaurant.SingleOrDefault(c => c.Id == 1);
            if (file != null)
            {
                //Filename
                var name = DateTime.Now.ToString("yyyyMMddHHmmssfff");
                var extension = Path.GetExtension(file.FileName);

                file.SaveAs(HttpContext.Server.MapPath("~/Content/images/restaurant/") + name + extension);

               
                restaurantInDb.Image = "restaurant/" + name + extension;

                _context.SaveChanges();
            }

            restaurantInDb.About = restaurant.About;
            restaurantInDb.Address = restaurant.Address;
            restaurantInDb.Phone = restaurant.Phone;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}