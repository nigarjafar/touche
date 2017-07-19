using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Touche.Models;
using System.Data.Entity;

namespace Touche.Controllers.Admin
{
    public class MenuItemController : Controller
    {
        private ApplicationDbContext _context;


        public MenuItemController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: menuItem
        public ActionResult Index()
        {
            var menuItems = _context.MenuItems.Include(m => m.Category).ToList();
            return View("~/Views/Admin/menuItem/Index.cshtml", menuItems);
        }

        public ActionResult Create()
        {
            var menuItem = new MenuItem();
            ViewBag.Categories = _context.Categories.ToList();
            return View("~/Views/Admin/menuItem/Form.cshtml", menuItem);
        }

        public ActionResult Edit(int id)
        {
            var menuItem = _context.MenuItems.SingleOrDefault(c => c.Id == id);
            ViewBag.Categories = _context.Categories.ToList();
            return View("~/Views/Admin/menuItem/Form.cshtml", menuItem);
        }

        public ActionResult Save(MenuItem menuItem, HttpPostedFileBase file)
        {


            if (file != null)
            {
                //Filename
                var name = DateTime.Now.ToString("yyyyMMddHHmmssfff");
                var extension = Path.GetExtension(file.FileName);
                menuItem.Image = "menu/" + name + extension;
                file.SaveAs(HttpContext.Server.MapPath("~/Content/images/menu/") + name + extension);
            }

            if (menuItem.Id == 0)
                _context.MenuItems.Add(menuItem);
            else
            {
                var menuItemInDb = _context.MenuItems.SingleOrDefault(c => c.Id == menuItem.Id);
                menuItemInDb.Name = menuItem.Name;
                menuItemInDb.Description = menuItem.Description;
                menuItemInDb.Price = menuItem.Price;
                menuItemInDb.Category_Id = menuItem.Category_Id;

                if (menuItem.Image != null)
                    menuItemInDb.Image = menuItem.Image;

            }

            _context.SaveChanges();
            
            return RedirectToAction("Index");
        }


        [HttpDelete]

        public ActionResult Delete(int id)
        {
            var menuItemInDb = _context.MenuItems.SingleOrDefault(c => c.Id == id);
            _context.MenuItems.Remove(menuItemInDb);
            _context.SaveChanges();
            return Content("success");

        }
    }
}