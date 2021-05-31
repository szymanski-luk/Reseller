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
            if (Session["user"] == null) {
                return RedirectToAction("Index");
            }
            else if ((Session["user"] as users).account_type == 0) {
                return RedirectToAction("Index");
            }

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
            if (Session["user"] == null) {
                return RedirectToAction("Index");
            }
            else if ((Session["user"] as users).account_type == 0) {
                return RedirectToAction("Index");
            }

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
            if (Session["user"] == null) {
                return RedirectToAction("Index");
            }
            else if ((Session["user"] as users).account_type == 0) {
                return RedirectToAction("Index");
            }

            return View(_db.category.Find(id));
        }

        // POST: Category/Delete/5
        [HttpPost]
        public ActionResult Delete(category categoryToDelete)
        {
            try
            {
                var toDelete = _db.category.Find(categoryToDelete);

                if (!ModelState.IsValid) {
                    return View(toDelete);
                }
                else {
                    _db.category.Remove(toDelete);
                    _db.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View(categoryToDelete);
            }
        }

        // GET: Category/ItemList/5
        public ActionResult ItemList(int id) {
            ViewBag.CategoryName = _db.category.Find(id).name;
            return View(_db.item.Where(x => x.category_id == id));
        }
    }
}
