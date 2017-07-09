using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Touche.Models;

namespace Touche.Controllers.Admin
{
    public class ChefController : Controller
    {
        private ApplicationDbContext _context;
        private object newEntityModel;

        public object FileUploadControl { get; private set; }

        public ChefController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: Chef
        public ActionResult Index()
        {
            var chefs = _context.Chefs;
            return View("~/Views/Admin/Chef/Index.cshtml",chefs);
        }

        public ActionResult Create()
        {
            var chef =new Chef();
            return View("~/Views/Admin/Chef/Form.cshtml", chef);
        }

        public ActionResult Edit(int id)
        {
            var chef = _context.Chefs.SingleOrDefault(c => c.Id == id);
            return View("~/Views/Admin/Chef/Form.cshtml", chef);
        }

        public ActionResult Save(Chef chef, HttpPostedFileBase file)
        {

            if (file != null)
            {
                chef.Image = "team/"+file.FileName;
                file.SaveAs(HttpContext.Server.MapPath("~/Content/images/team/")+ file.FileName);
            }
       
            if (chef.Id == 0)
                 _context.Chefs.Add(chef);
            else
            {
                var chefInDb= _context.Chefs.SingleOrDefault(c => c.Id == chef.Id);
                chefInDb.Name = chef.Name;
                chefInDb.About = chef.About;
                if(chef.Image!=null)
                    chefInDb.Image = chef.Image;
               
            }

            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
