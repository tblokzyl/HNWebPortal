using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HospiceWebPortal.Models;
using System.IO;
using HNWebPortal.Models;

namespace HospiceWebPortal.Controllers
{
    public class ResourcesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Resources
        public ActionResult Index(string sortOrder, string searchString)
        {
            ViewData["Search"] = "\"" + searchString + "\"";

            ViewBag.DescriptionSortParm = sortOrder == "Description" ? "Description_desc" : "Description";
            ViewBag.DateSortParm = sortOrder == "Date" ? "Date_desc" : "Date";
            ViewBag.FileNameSortParm = sortOrder == "FileName" ? "FileName_desc" : "FileName";
            var resources = from s in db.Resources
                            select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                resources = resources.Where(s => s.Description.Contains(searchString)
                                        || s.FileName.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "Description":
                    resources = resources.OrderBy(s => s.Description);
                    break;
                case "Description_desc":
                    resources = resources.OrderByDescending(s => s.Description);
                    break;
                case "Date":
                    resources = resources.OrderBy(s => s.CreatedOn);
                    break;
                case "Date_desc":
                    resources = resources.OrderByDescending(s => s.CreatedOn);
                    break;
                case "FileName":
                    resources = resources.OrderBy(s => s.FileName);
                    break;
                case "FileName_desc":
                    resources = resources.OrderByDescending(s => s.FileName);
                    break;
                default:
                    resources = resources.OrderByDescending(s => s.Description);
                    break;
            }
            return View(resources.ToList());
        }

        public FileContentResult Download(int id)
        {
            var theFile = db.Resources.Where(f => f.ID == id).SingleOrDefault();
            //theFile.Downloads++;
            //count++;
            //ViewData["Count"] = count;
            return File(theFile.FileContent, theFile.MimeType, theFile.FileName);
        }
        //int count = 0;
        [HttpPost]
        public ActionResult Index(string fileDescription)
        {
            string mimeType = Request.Files[0].ContentType;
            string fileName = Path.GetFileName(Request.Files[0].FileName);
            int fileLength = Request.Files[0].ContentLength;
            if (!(fileName == "" || fileLength == 0))
            {
                Stream fileStream = Request.Files[0].InputStream;
                byte[] fileData = new byte[fileLength];
                fileStream.Read(fileData, 0, fileLength);
                Resource newFile = new Resource
                {
                    FileContent = fileData,
                    MimeType = mimeType,
                    FileName = fileName,
                    //Downloads = 0,
                    Description = fileDescription,
                    CreatedOn = DateTime.Today
                };

                db.Resources.Add(newFile);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        // GET: Resources/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Resource resource = db.Resources.Find(id);
            if (resource == null)
            {
                return HttpNotFound();
            }
            return View(resource);
        }

        // GET: Resources/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Resources/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Description,CreatedOn,FileContent,MimeType,FileName")] Resource resource)
        {
            if (ModelState.IsValid)
            {
                db.Resources.Add(resource);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(resource);
        }

        // GET: Resources/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Resource resource = db.Resources.Find(id);
            if (resource == null)
            {
                return HttpNotFound();
            }
            return View(resource);
        }



        // POST: Resources/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Description,CreatedOn,FileContent,MimeType,FileName")] Resource resource)
        {
            Console.Write("Here1");
            if (ModelState.IsValid)
            {
                Console.Write("Here2");
                db.Entry(resource).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(resource);
        }

        // GET: Resources/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Resource resource = db.Resources.Find(id);
            if (resource == null)
            {
                return HttpNotFound();
            }
            return View(resource);
        }

        // POST: Resources/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Resource resource = db.Resources.Find(id);
            db.Resources.Remove(resource);
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
