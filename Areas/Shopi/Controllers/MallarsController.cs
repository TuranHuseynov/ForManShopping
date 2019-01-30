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
    public class MallarsController : Controller
    {
        private ShoppingNewEntities1 db = new ShoppingNewEntities1();

        // GET: Shopi/Mallars
        public ActionResult Index()
        {
            var mallars = db.Mallars.Include(m => m.Brand).Include(m => m.Category);
            return View(mallars.ToList());
        }

        // GET: Shopi/Mallars/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mallar mallar = db.Mallars.Find(id);
            if (mallar == null)
            {
                return HttpNotFound();
            }
            return View(mallar);
        }

        // GET: Shopi/Mallars/Create
        public ActionResult Create()
        {
            ViewBag.product_brand_id = new SelectList(db.Brands, "brand_id", "brand_name");
            ViewBag.product_category_id = new SelectList(db.Categories, "category_id", "category_name");
            return View();
        }

        // POST: Shopi/Mallars/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "product_id,product_name,product_info,product_price,product_count,product_brand_id,product_category_id")] Mallar mallar)
        {
            if (ModelState.IsValid)
            {
                db.Mallars.Add(mallar);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.product_brand_id = new SelectList(db.Brands, "brand_id", "brand_name", mallar.product_brand_id);
            ViewBag.product_category_id = new SelectList(db.Categories, "category_id", "category_name", mallar.product_category_id);
            return View(mallar);
        }

        // GET: Shopi/Mallars/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mallar mallar = db.Mallars.Find(id);
            if (mallar == null)
            {
                return HttpNotFound();
            }
            ViewBag.product_brand_id = new SelectList(db.Brands, "brand_id", "brand_name", mallar.product_brand_id);
            ViewBag.product_category_id = new SelectList(db.Categories, "category_id", "category_name", mallar.product_category_id);
            return View(mallar);
        }

        // POST: Shopi/Mallars/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "product_id,product_name,product_info,product_price,product_count,product_brand_id,product_category_id")] Mallar mallar)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mallar).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.product_brand_id = new SelectList(db.Brands, "brand_id", "brand_name", mallar.product_brand_id);
            ViewBag.product_category_id = new SelectList(db.Categories, "category_id", "category_name", mallar.product_category_id);
            return View(mallar);
        }

        // GET: Shopi/Mallars/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mallar mallar = db.Mallars.Find(id);
            if (mallar == null)
            {
                return HttpNotFound();
            }
            return View(mallar);
        }

        // POST: Shopi/Mallars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Mallar mallar = db.Mallars.Find(id);
            db.Mallars.Remove(mallar);
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
