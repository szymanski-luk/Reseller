using ProjectReseller.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectReseller.Views
{
    public class ItemController : Controller
    {
        private ResellerEntities1 _db = new ResellerEntities1();
        // GET: Item
        public ActionResult Index()
        {
            return View(_db.item.ToList());
        }

        // GET: Item/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Item/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Item/Create
        [HttpPost]
        public ActionResult Create(item newItem)
        {
            try
            {
                string fileName = Path.GetFileNameWithoutExtension(newItem.ImageFile.FileName);
                string extension = Path.GetExtension(newItem.ImageFile.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                newItem.image = fileName;
                fileName = Path.Combine(Server.MapPath("~/images/"), fileName);
                newItem.ImageFile.SaveAs(fileName);
                newItem.category_id = 1;
                newItem.users_id = 1;
                newItem.sold = false;

                _db.item.Add(newItem);
                _db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View(newItem);
            }
        }

        // GET: Item/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Item/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Item/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Item/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
