using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Touche.Models;

namespace Touche.Controllers.Admin
{
    public class SliderController : Controller
    {
        ApplicationDbContext _context;
        public SliderController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: Slider
        public ActionResult Index()
        {
            var slider = _context.Slider.SingleOrDefault(c => c.Id == 1);
            return View("~/Views/Admin/Slider/Index.cshtml", slider);
        }

        public ActionResult Save(Slider slider, HttpPostedFileBase file)
        {
            if (file != null)
            {
                //Filename
                var name = DateTime.Now.ToString("yyyyMMddHHmmssfff");
                var extension = Path.GetExtension(file.FileName);
              
                file.SaveAs(HttpContext.Server.MapPath("~/Content/images/slider/") + name + extension);

                var sliderInDb = _context.Slider.SingleOrDefault(c => c.Id == 1);
                sliderInDb.Image = "slider/" + name + extension;

                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}