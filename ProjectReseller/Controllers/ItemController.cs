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
            if (Session["user"] == null) {
                return RedirectToAction("Index");
            }
            

            ViewBag.Options = new SelectList(_db.category, "name", "name");
            return View();
        }

        // POST: Item/Create
        [HttpPost]
        public ActionResult Create(item newItem, FormCollection form)
        {
            try
            {
                string fileName = Path.GetFileNameWithoutExtension(newItem.ImageFile.FileName);
                string extension = Path.GetExtension(newItem.ImageFile.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                newItem.image = fileName;
                fileName = Path.Combine(Server.MapPath("~/images/"), fileName);
                newItem.ImageFile.SaveAs(fileName);
                newItem.sold = false;

                newItem.date = DateTime.Now;

                int userId = (Session["user"] as users).id;
                newItem.users_id = userId;

                string categoryName = form["categoryName"].ToString();
                int catId = _db.category.FirstOrDefault(x => x.name == categoryName).id;
                newItem.category_id = catId;


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
            if (Session["user"] == null) {
                return RedirectToAction("Index", "Home");
            }

            var itemToDelete = _db.item.FirstOrDefault(x => x.id == id);
            return View(itemToDelete);
        }

        // POST: Item/Delete/5
        [HttpPost]
        public ActionResult Delete(item itemToDelete)
        {
            try {
                var selItem = _db.item.FirstOrDefault(x => x.id == itemToDelete.id);
                var selReport = _db.report.Where(x => x.item_id == itemToDelete.id);

                foreach (var report in selReport) {
                    _db.report.Remove(report);
                }

                if (!ModelState.IsValid)
                    return View(selItem);
                _db.item.Remove(selItem);
                _db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            catch {
                return View(itemToDelete);
            }
        }
    }
}
