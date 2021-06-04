using ProjectReseller.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectReseller.Controllers
{
    public class UserController : Controller
    {
        private ResellerEntities1 _db = new ResellerEntities1();
        // GET: User
        public ActionResult Index()
        {
            return View(_db.users.ToList());
        }

        // GET: User/Details/5
        public ActionResult Details(int id)
        {
            ViewData["Items"] = _db.item.Where(x => x.users_id == id);
            return View(_db.users.Find(id));
        }

        

        // GET: User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        [HttpPost]
        public ActionResult Create(users collection)
        {
            try
            {
                _db.users.Add(collection);
                _db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View(collection);
            }
        }

        // GET: User/Login
        public ActionResult Login() {
            return View();
        }

        // POST: User/Login
        [HttpPost]
        public ActionResult Login(users user) {
            try {
                users existingUser = _db.users.First(x => x.name == user.name);
                if (existingUser != null) {
                    if (existingUser.password == user.password) {
                        existingUser.password = "";
                        Session["user"] = existingUser;
                        return RedirectToAction("Index", "Home");
                    }
                }
                ViewBag.Message = "Nieprawidłowe dane logowania";
                return View();
            }
            catch {
                ViewBag.Message = "Nieprawidłowe dane logowania";
                return View();
            }
        }

        // GET: User/Logout
        public ActionResult Logout() {
            if (Session["user"] != null) {
                Session["user"] = null;
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Index", "Home");
        }

        // GET: User/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_db.users.Find(id));
        }

        // POST: User/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            var oldCollection = _db.users.Find(id);
            try
            {
                if(TryUpdateModel(oldCollection, new string [] {"name", "password", "city", "postcode", "phone", "account_type"})) {
                    _db.SaveChanges();
                }
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View(collection);
            }
        }

        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: User/Delete/5
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
