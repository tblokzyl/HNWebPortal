using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HospiceWebPortal.Models;
using HNWebPortal.Models;

namespace HospiceWebPortal.Controllers
{

    public class DeathNotificationsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: DeathNotifications
        public ActionResult Index(string sortOrder, string searchString)
        {
            ViewData["Search"] = "\"" + searchString + "\"";

            ////Steph Change Start
            ViewBag.NameSortParm = sortOrder == "Name" ? "Name_desc" : "Name";
            ////Steph Change End
            ViewBag.DateSortParm = sortOrder == "Date" ? "Date_desc" : "Date";
            ////Steph Change Start
            ViewBag.LocationSortParm = sortOrder == "Location" ? "Location_desc" : "Location";
            ////Steph Change End
            var deathnot = from s in db.DeathNotifications
                           select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                deathnot = deathnot.Where(s => s.Name.Contains(searchString)
                                        || s.Location.Contains(searchString));
            }
            switch (sortOrder)
            {
                //Steph Changes Start
                case "Name":
                    deathnot = deathnot.OrderBy(s => s.Name);
                    break;
                case "Name_desc":
                    deathnot = deathnot.OrderByDescending(s => s.Name);
                    break;
                case "Date":
                    deathnot = deathnot.OrderBy(s => s.Date);
                    break;
                case "Date_desc":
                    deathnot = deathnot.OrderByDescending(s => s.Date);
                    break;
                case "Location":
                    deathnot = deathnot.OrderBy(s => s.Location);
                    break;
                case "Location_desc":
                    deathnot = deathnot.OrderByDescending(s => s.Location);
                    break;
                //Steph Changes End
                default:
                    deathnot = deathnot.OrderByDescending(s => s.Date);
                    break;
            }
            return View(deathnot.ToList());
        }

        // GET: DeathNotifications/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DeathNotification deathNotification = db.DeathNotifications.Find(id);
            if (deathNotification == null)
            {
                return HttpNotFound();
            }
            return View(deathNotification);
        }

        // GET: DeathNotifications/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DeathNotifications/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Date,Location,Notes")] DeathNotification deathNotification)
        {
            if (ModelState.IsValid)
            {
                db.DeathNotifications.Add(deathNotification);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(deathNotification);
        }

        // GET: DeathNotifications/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DeathNotification deathNotification = db.DeathNotifications.Find(id);
            if (deathNotification == null)
            {
                return HttpNotFound();
            }
            return View(deathNotification);
        }

        // POST: DeathNotifications/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Date,Location,Notes")] DeathNotification deathNotification)
        {
            if (ModelState.IsValid)
            {
                db.Entry(deathNotification).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(deathNotification);
        }

        // GET: DeathNotifications/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DeathNotification deathNotification = db.DeathNotifications.Find(id);
            if (deathNotification == null)
            {
                return HttpNotFound();
            }
            return View(deathNotification);
        }

        // POST: DeathNotifications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DeathNotification deathNotification = db.DeathNotifications.Find(id);
            db.DeathNotifications.Remove(deathNotification);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
