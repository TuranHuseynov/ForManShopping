using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using YeniShoppingProject.Models;

namespace YeniShoppingProject.Areas.Shopi.Controllers
{
    public class PhotoTypesController : Controller
    {
        private ShoppingNewEntities1 db = new ShoppingNewEntities1();

        // GET: Shopi/PhotoTypes
        public ActionResult Index()
        {
            return View(db.PhotoTypes.ToList());
        }

        // GET: Shopi/PhotoTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhotoType photoType = db.PhotoTypes.Find(id);
            if (photoType == null)
            {
                return HttpNotFound();
            }
            return View(photoType);
        }

        // GET: Shopi/PhotoTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Shopi/PhotoTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "photo_type_id,photo_type_name")] PhotoType photoType)
        {
            if (ModelState.IsValid)
            {
                db.PhotoTypes.Add(photoType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(photoType);
        }

        // GET: Shopi/PhotoTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhotoType photoType = db.PhotoTypes.Find(id);
            if (photoType == null)
            {
                return HttpNotFound();
            }
            return View(photoType);
        }

        // POST: Shopi/PhotoTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "photo_type_id,photo_type_name")] PhotoType photoType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(photoType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(photoType);
        }

        // GET: Shopi/PhotoTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhotoType photoType = db.PhotoTypes.Find(id);
            if (photoType == null)
            {
                return HttpNotFound();
            }
            return View(photoType);
        }

        // POST: Shopi/PhotoTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PhotoType photoType = db.PhotoTypes.Find(id);
            db.PhotoTypes.Remove(photoType);
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
