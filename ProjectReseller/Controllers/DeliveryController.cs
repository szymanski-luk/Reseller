using ProjectReseller.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectReseller.Controllers
{
    public class DeliveryController : Controller
    {
        private ResellerEntities1 _db = new ResellerEntities1();

        // GET: Delivery/Order/5
        public ActionResult Order(int id) {
            if (Session["user"] == null) {
                return RedirectToAction("Index", "Home");
            }
            
            return View(_db.item.FirstOrDefault(x => x.id == id));
        }

        // GET: Delivery/OrderProduct/
        public ActionResult OrderProduct(int id) {
            if (Session["user"] == null) {
                return RedirectToAction("Index", "Home");
            }

            try {
                var item = _db.item.FirstOrDefault(x => x.id == id);
                item.sold = true;

                delivery newDelivery = new delivery();
                newDelivery.users_id = (Session["user"] as users).id;
                newDelivery.item = item;
                newDelivery.delivery_status_id = 1;
                _db.delivery.Add(newDelivery);
                _db.SaveChanges();

                return RedirectToAction("Index", "Home");
            }
            catch {
                return RedirectToAction("Index", "Home");
            }
        }

        // GET: Delivery
        public ActionResult Index()
        {
            return View();
        }

        // GET: Delivery/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Delivery/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Delivery/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Delivery/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Delivery/Edit/5
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

        // GET: Delivery/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Delivery/Delete/5
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
