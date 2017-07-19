using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Touche.Models;

namespace Touche.Controllers.Admin
{
    public class ChefController : Controller
    {
        private ApplicationDbContext _context;
       

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
                //Filename
                var name = DateTime.Now.ToString("yyyyMMddHHmmssfff");
                var extension=Path.GetExtension(file.FileName);
                chef.Image = "team/"+name+extension;
                file.SaveAs(HttpContext.Server.MapPath("~/Content/images/team/")+ name + extension);
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


        [HttpDelete]
       
        public ActionResult Delete(int id)
        {
            var chefInDb = _context.Chefs.SingleOrDefault(c => c.Id == id);
            _context.Chefs.Remove(chefInDb);
            _context.SaveChanges();
            return Content("success");
           
        }
    }
}
