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
    public class ContactsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Contacts
        public ActionResult Index(string sortOrder, string searchString)
        {
            //This is used to remove extra whitespace
            ModelBinders.Binders.DefaultBinder = new TrimModelBinder();

            //Passing SearchString To View
            ViewData["Search"] = "\"" + searchString + "\"";

            ViewBag.FNameSortParm = sortOrder == "FName" ? "fname_desc" : "FName";
            ViewBag.LNameSortParm = sortOrder == "LName" ? "lname_desc" : "LName";
            ViewBag.PositionSortParm = sortOrder == "Position" ? "Position_desc" : "Position";
            var contacts = from s in db.Contacts
                           select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                contacts = contacts.Where(s => s.LastName.Contains(searchString)
                                       || s.FirstName.Contains(searchString) || s.Position.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "FName":
                    contacts = contacts.OrderBy(s => s.FirstName);
                    break;
                case "fname_desc":
                    contacts = contacts.OrderByDescending(s => s.FirstName);
                    break;
                case "LName":
                    contacts = contacts.OrderBy(s => s.LastName);
                    break;
                case "lname_desc":
                    contacts = contacts.OrderByDescending(s => s.LastName);
                    break;
                case "Position":
                    contacts = contacts.OrderBy(s => s.Position);
                    break;
                case "Position_desc":
                    contacts = contacts.OrderByDescending(s => s.Position);
                    break;
                default:
                    contacts = contacts.OrderBy(s => s.FirstName);
                    break;
            }

            return View(contacts.ToList());
        }

        // GET: Contacts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contact contact = db.Contacts.Find(id);
            if (contact == null)
            {
                return HttpNotFound();
            }
            return View(contact);
        }

        // GET: Contacts/Create
        public ActionResult Create()
        {
            ModelBinders.Binders.DefaultBinder = new TrimModelBinder();
            return View();
        }

        // POST: Contacts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,FirstName,LastName,Position,Phone,EXT")] Contact contact)
        {
            ModelBinders.Binders.DefaultBinder = new TrimModelBinder();
            if (ModelState.IsValid)
            {
                db.Contacts.Add(contact);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(contact);
        }

        // GET: Contacts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contact contact = db.Contacts.Find(id);
            if (contact == null)
            {
                return HttpNotFound();
            }
            return View(contact);
        }

        // POST: Contacts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,FirstName,LastName,Position,Phone,EXT")] Contact contact)
        {
            ModelBinders.Binders.DefaultBinder = new TrimModelBinder();
            if (ModelState.IsValid)
            {
                db.Entry(contact).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(contact);
        }

        // GET: Contacts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contact contact = db.Contacts.Find(id);
            if (contact == null)
            {
                return HttpNotFound();
            }
            return View(contact);
        }

        // POST: Contacts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Contact contact = db.Contacts.Find(id);
            db.Contacts.Remove(contact);
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
    public class TrimModelBinder : DefaultModelBinder
    {
        protected override void SetProperty(ControllerContext controllerContext,
          ModelBindingContext bindingContext,
          System.ComponentModel.PropertyDescriptor propertyDescriptor, object value)
        {
            if (propertyDescriptor.PropertyType == typeof(string))
            {
                var stringValue = (string)value;
                if (!string.IsNullOrEmpty(stringValue))
                    stringValue = stringValue.Trim();

                value = stringValue;
            }

            base.SetProperty(controllerContext, bindingContext,
                                propertyDescriptor, value);
        }
    }
}
