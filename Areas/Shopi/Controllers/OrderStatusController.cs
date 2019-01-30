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
    public class OrderStatusController : Controller
    {
        private ShoppingNewEntities1 db = new ShoppingNewEntities1();

        // GET: Shopi/OrderStatus
        public ActionResult Index()
        {
            return View(db.OrderStatus.ToList());
        }

        // GET: Shopi/OrderStatus/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderStatu orderStatu = db.OrderStatus.Find(id);
            if (orderStatu == null)
            {
                return HttpNotFound();
            }
            return View(orderStatu);
        }

        // GET: Shopi/OrderStatus/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Shopi/OrderStatus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "orderstatus_id,orderstatus_name")] OrderStatu orderStatu)
        {
            if (ModelState.IsValid)
            {
                db.OrderStatus.Add(orderStatu);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(orderStatu);
        }

        // GET: Shopi/OrderStatus/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderStatu orderStatu = db.OrderStatus.Find(id);
            if (orderStatu == null)
            {
                return HttpNotFound();
            }
            return View(orderStatu);
        }

        // POST: Shopi/OrderStatus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "orderstatus_id,orderstatus_name")] OrderStatu orderStatu)
        {
            if (ModelState.IsValid)
            {
                db.Entry(orderStatu).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(orderStatu);
        }

        // GET: Shopi/OrderStatus/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderStatu orderStatu = db.OrderStatus.Find(id);
            if (orderStatu == null)
            {
                return HttpNotFound();
            }
            return View(orderStatu);
        }

        // POST: Shopi/OrderStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OrderStatu orderStatu = db.OrderStatus.Find(id);
            db.OrderStatus.Remove(orderStatu);
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
