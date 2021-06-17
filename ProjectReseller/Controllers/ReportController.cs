using ProjectReseller.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectReseller.Controllers
{
    public class ReportController : Controller
    {
        private ResellerEntities1 _db = new ResellerEntities1();

        // GET: Report
        public ActionResult Index()
        {
            if (Session["user"] == null) {
                return RedirectToAction("Index");
            }
            else if ((Session["user"] as users).account_type == 0) {
                return RedirectToAction("Index", "Home");
            }

            var reports = _db.report.ToList();

            return View(reports);
        }

        public ActionResult RedirectTo(string actionName, string controllerName, int id) {
            return RedirectToAction(actionName, controllerName, new { id = id });
        }

        // GET: Report/Create/5
        public ActionResult Create(int id)
        {
            if (Session["user"] == null) {
                return RedirectToAction("Index", "Home");
            }
            try {
                
                var item = _db.item.FirstOrDefault(x => x.id == id);
                int userId = (Session["user"] as users).id;
                var user = _db.users.FirstOrDefault(x => x.id == userId);
                report newReport = new report();
                newReport.content = "Proszę sprawdzić ogłoszenie";
                newReport.item = item;
                newReport.users = user;
                newReport.verified = false;
                _db.report.Add(newReport);
                _db.SaveChanges();

                return View();
            }
            catch {
                return RedirectToAction("Details", "Home", new { id = id });
            }
        }


        // GET: Report/SetVerified/5
        public ActionResult SetVerified(int id) {
            if (Session["user"] == null) {
                return RedirectToAction("Index", "Home");
            }
            else if ((Session["user"] as users).account_type == 0) {
                return RedirectToAction("Index", "Home");
            }

            var report = _db.report.FirstOrDefault(x => x.id == id);
            report.verified = true;
            _db.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}
