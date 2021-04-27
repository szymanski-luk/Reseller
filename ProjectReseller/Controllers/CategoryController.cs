using ProjectReseller.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectReseller.Controllers
{
    public class CategoryController : Controller
    {
        private ResellerEntities1 _db = new ResellerEntities1();
        // GET: Category
        public ActionResult Index()
        {
            return View(_db.category.ToList());
        }

        // GET: Category/Details/5
        public ActionResult Details(int id)
        {
            return View(_db.category.Find(id));
        }

        // GET: Category/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Category/Create
        [HttpPost]
        public ActionResult Create(category collection)
        {
            try
            {
                _db.category.Add(collection);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View(collection);
            }
        }

        // GET: Category/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_db.category.Find(id));
        }

        // POST: Category/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, category collection)
        {
            var old = _db.category.Find(id);
            try
            {
                if(TryUpdateModel(old, new string[] { "name" })) {
                    _db.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View(collection);
            }
        }

        // GET: Category/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Category/Delete/5
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
