using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AdviserListWebApplication.Models;

namespace AdviserListWebApplication.Controllers
{
    public class AdviserHistoriesController : Controller
    {
        private AdviserListDBEntities db = new AdviserListDBEntities();

        // GET: AdviserHistories
        public ActionResult Index()
        {
            var adviserHistories = db.AdviserHistories.Include(a => a.Adviser);
            return View(adviserHistories.ToList());
        }

        // GET: AdviserHistories/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdviserHistory adviserHistory = db.AdviserHistories.Find(id);
            if (adviserHistory == null)
            {
                return HttpNotFound();
            }
            return View(adviserHistory);
        }

        // GET: AdviserHistories/Create
        public ActionResult Create()
        {
            ViewBag.adviserId = new SelectList(db.Advisers, "adviserId", "fullName");
            return View();
        }

        // POST: AdviserHistories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "adviserHistoryId,adviserId,latitude,longitude,displayFlag,updatedDate")] AdviserHistory adviserHistory)
        {
            if (ModelState.IsValid)
            {
                adviserHistory.id = Guid.NewGuid();
                db.AdviserHistories.Add(adviserHistory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.adviserId = new SelectList(db.Advisers, "adviserId", "fullName", adviserHistory.adviserId);
            return View(adviserHistory);
        }

        // GET: AdviserHistories/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdviserHistory adviserHistory = db.AdviserHistories.Find(id);
            if (adviserHistory == null)
            {
                return HttpNotFound();
            }
            ViewBag.adviserId = new SelectList(db.Advisers, "adviserId", "fullName", adviserHistory.adviserId);
            return View(adviserHistory);
        }

        // POST: AdviserHistories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "adviserHistoryId,adviserId,latitude,longitude,displayFlag,updatedDate")] AdviserHistory adviserHistory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(adviserHistory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.adviserId = new SelectList(db.Advisers, "adviserId", "fullName", adviserHistory.adviserId);
            return View(adviserHistory);
        }

        // GET: AdviserHistories/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdviserHistory adviserHistory = db.AdviserHistories.Find(id);
            if (adviserHistory == null)
            {
                return HttpNotFound();
            }
            return View(adviserHistory);
        }

        // POST: AdviserHistories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            AdviserHistory adviserHistory = db.AdviserHistories.Find(id);
            db.AdviserHistories.Remove(adviserHistory);
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
