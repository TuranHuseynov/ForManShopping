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
    public class MessageWantsController : Controller
    {
        private ShoppingNewEntities1 db = new ShoppingNewEntities1();

        // GET: Shopi/MessageWants
        public ActionResult Index()
        {
            return View(db.MessageWants.ToList());
        }

        // GET: Shopi/MessageWants/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MessageWant messageWant = db.MessageWants.Find(id);
            if (messageWant == null)
            {
                return HttpNotFound();
            }
            return View(messageWant);
        }

        // GET: Shopi/MessageWants/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Shopi/MessageWants/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "wantmessage_id,wantmessage_user_id,wantmessage_text")] MessageWant messageWant)
        {
            if (ModelState.IsValid)
            {
                db.MessageWants.Add(messageWant);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(messageWant);
        }

        // GET: Shopi/MessageWants/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MessageWant messageWant = db.MessageWants.Find(id);
            if (messageWant == null)
            {
                return HttpNotFound();
            }
            return View(messageWant);
        }

        // POST: Shopi/MessageWants/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "wantmessage_id,wantmessage_user_id,wantmessage_text")] MessageWant messageWant)
        {
            if (ModelState.IsValid)
            {
                db.Entry(messageWant).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(messageWant);
        }

        // GET: Shopi/MessageWants/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MessageWant messageWant = db.MessageWants.Find(id);
            if (messageWant == null)
            {
                return HttpNotFound();
            }
            return View(messageWant);
        }

        // POST: Shopi/MessageWants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MessageWant messageWant = db.MessageWants.Find(id);
            db.MessageWants.Remove(messageWant);
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
