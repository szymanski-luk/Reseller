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

        // GET: MyOrders
        public ActionResult MyOrders() {
            if (Session["user"] == null) {
                return RedirectToAction("Index", "Home");
            }

            int userId = (Session["user"] as users).id;
            var data = _db.delivery.Where(x => x.users_id == userId);

            return View(data);
        }


        public ActionResult Ordered() {
            if (Session["user"] == null) {
                return RedirectToAction("Index", "Home");
            }

            int userId = (Session["user"] as users).id;
            var data = _db.delivery.Where(x => x.item_users_id == userId);

            return View(data);
        }

        // GET: Delivery
        public ActionResult Index()
        {
            return View();
        }

        // GET: Delivery/Details/5
        public ActionResult Details(int id)
        {
            var item = _db.delivery.FirstOrDefault(x => x.id == id);
            return View(item);
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
            if (Session["user"] == null) {
                return RedirectToAction("Index", "Home");
            }

            ViewBag.Options = new SelectList(_db.delivery_status, "name", "name");

            var item = _db.delivery.FirstOrDefault(x => x.id == id);
            return View(item);
        }

        // POST: Delivery/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection form)
        {
            if (Session["user"] == null) {
                return RedirectToAction("Index", "Home");
            }

            try
            {
                var old = _db.delivery.FirstOrDefault(x => x.id == id);
                string status = form["deliveryStatus"].ToString();
                int statusId = _db.delivery_status.FirstOrDefault(x => x.name == status).id;
                var statusObj = _db.delivery_status.FirstOrDefault(x => x.name == status);

                _db.Database.ExecuteSqlCommand("UPDATE delivery SET delivery_status_id = {0} WHERE id = {1}", statusId, id);
                _db.SaveChanges();

                return RedirectToAction("Ordered", "Delivery");
            }
            catch
            {
                return RedirectToAction("Index", "Home");
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
