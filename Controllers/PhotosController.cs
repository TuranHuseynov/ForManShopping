using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using YeniShoppingProject.Models;

namespace YeniShoppingProject.Controllers
{
    public class PhotosController : Controller
    {
        private ShoppingNewEntities1 db = new ShoppingNewEntities1();

        // GET: Photos
        public ActionResult Index()
        {
            var photos = db.Photos.Include(p => p.Color).Include(p => p.Mallar).Include(p => p.PhotoType);
            return View(photos.ToList());
        }

        // GET: Photos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Photo photo = db.Photos.Find(id);
            if (photo == null)
            {
                return HttpNotFound();
            }
            return View(photo);
        }

        // GET: Photos/Create
        public ActionResult Create()
        {
            ViewBag.photo_color_id = new SelectList(db.Colors, "color_id", "color_name");
            ViewBag.photo_product_id = new SelectList(db.Mallars, "product_id", "product_name");
            ViewBag.photo_product_id = new SelectList(db.PhotoTypes, "photo_type_id", "photo_type_name");
            return View();
        }

        // POST: Photos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Photo photo,HttpPostedFileBase photo_name)
        {
            if (ModelState.IsValid)
            {
                var file_name = Path.GetFileName(photo_name.FileName);
                var src = Path.Combine(Server.MapPath("/Yuklenen"), file_name);
                photo_name.SaveAs(src);
                photo.photo_name = Path.GetFileName(photo_name.FileName);




                db.Photos.Add(photo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.photo_color_id = new SelectList(db.Colors, "color_id", "color_name", photo.photo_color_id);
            ViewBag.photo_product_id = new SelectList(db.Mallars, "product_id", "product_name", photo.photo_product_id);
            ViewBag.photo_product_id = new SelectList(db.PhotoTypes, "photo_type_id", "photo_type_name", photo.photo_product_id);
            return View(photo);
        }

        // GET: Photos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Photo photo = db.Photos.Find(id);
            if (photo == null)
            {
                return HttpNotFound();
            }
            ViewBag.photo_color_id = new SelectList(db.Colors, "color_id", "color_name", photo.photo_color_id);
            ViewBag.photo_product_id = new SelectList(db.Mallars, "product_id", "product_name", photo.photo_product_id);
            ViewBag.photo_product_id = new SelectList(db.PhotoTypes, "photo_type_id", "photo_type_name", photo.photo_product_id);
            return View(photo);
        }

        // POST: Photos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "photo_id,photo_name,photo_product_id,photo_color_id,photo_type_id")] Photo photo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(photo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.photo_color_id = new SelectList(db.Colors, "color_id", "color_name", photo.photo_color_id);
            ViewBag.photo_product_id = new SelectList(db.Mallars, "product_id", "product_name", photo.photo_product_id);
            ViewBag.photo_product_id = new SelectList(db.PhotoTypes, "photo_type_id", "photo_type_name", photo.photo_product_id);
            return View(photo);
        }

        // GET: Photos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Photo photo = db.Photos.Find(id);
            if (photo == null)
            {
                return HttpNotFound();
            }
            return View(photo);
        }

        // POST: Photos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Photo photo = db.Photos.Find(id);
            db.Photos.Remove(photo);
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
