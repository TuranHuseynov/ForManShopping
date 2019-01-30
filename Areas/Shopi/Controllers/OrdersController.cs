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
    public class OrdersController : Controller
    {
        private ShoppingNewEntities1 db = new ShoppingNewEntities1();

        // GET: Shopi/Orders
        public ActionResult Index()
        {
            var orders = db.Orders.Include(o => o.OrderStatu).Include(o => o.User);
            return View(orders.ToList());
        }

        // GET: Shopi/Orders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // GET: Shopi/Orders/Create
        public ActionResult Create()
        {
            ViewBag.order_status_id = new SelectList(db.OrderStatus, "orderstatus_id", "orderstatus_name");
            ViewBag.order_user_id = new SelectList(db.Users, "user_id", "user_fullname");
            return View();
        }

        // POST: Shopi/Orders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "order_id,order_status_id,order_user_id,order_product,order_adress,order_count,order_time")] Order order)
        {
            if (ModelState.IsValid)
            {
                db.Orders.Add(order);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.order_status_id = new SelectList(db.OrderStatus, "orderstatus_id", "orderstatus_name", order.order_status_id);
            ViewBag.order_user_id = new SelectList(db.Users, "user_id", "user_fullname", order.order_user_id);
            return View(order);
        }

        // GET: Shopi/Orders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            ViewBag.order_status_id = new SelectList(db.OrderStatus, "orderstatus_id", "orderstatus_name", order.order_status_id);
            ViewBag.order_user_id = new SelectList(db.Users, "user_id", "user_fullname", order.order_user_id);
            return View(order);
        }

        // POST: Shopi/Orders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "order_id,order_status_id,order_user_id,order_product,order_adress,order_count,order_time")] Order order)
        {
            if (ModelState.IsValid)
            {
                db.Entry(order).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.order_status_id = new SelectList(db.OrderStatus, "orderstatus_id", "orderstatus_name", order.order_status_id);
            ViewBag.order_user_id = new SelectList(db.Users, "user_id", "user_fullname", order.order_user_id);
            return View(order);
        }

        // GET: Shopi/Orders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // POST: Shopi/Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Order order = db.Orders.Find(id);
            db.Orders.Remove(order);
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
