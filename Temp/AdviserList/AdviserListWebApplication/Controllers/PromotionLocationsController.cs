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
    public class PromotionLocationsController : Controller
    {
        private AdviserListDBEntities db = new AdviserListDBEntities();

        // GET: PromotionLocations
        public ActionResult Index()
        {
            var promotionLocations = db.PromotionLocations.Include(p => p.Adviser);
            return View(promotionLocations.ToList());
        }

        // GET: PromotionLocations/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PromotionLocation promotionLocation = db.PromotionLocations.Find(id);
            if (promotionLocation == null)
            {
                return HttpNotFound();
            }
            return View(promotionLocation);
        }

        // GET: PromotionLocations/Create
        public ActionResult Create()
        {
            ViewBag.adviserId = new SelectList(db.Advisers, "adviserId", "fullName");
            ViewBag.stateId = new SelectList(db.States, "stateId", "name");
            ViewBag.cityId = new SelectList(db.Cities, "cityId", "name");
            return View();
        }

        // POST: PromotionLocations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "promotionLocationId,adviserId, cityId, locationAddress, effectiveDate,effectiveTime,expireDate,expireTime,description")] PromotionLocation promotionLocation)
        {
            if (ModelState.IsValid)
            {
                promotionLocation.id = Guid.NewGuid();
                db.PromotionLocationInsert(promotionLocation.adviserId, promotionLocation.cityId, 
                    promotionLocation.locationAddress, promotionLocation.latitude, promotionLocation.longitude, 
                    promotionLocation.effectiveDate, promotionLocation.expireDate, promotionLocation.effectiveTime, 
                    promotionLocation.expireTime, promotionLocation.description);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.adviserId = new SelectList(db.Advisers, "adviserId", "fullName", promotionLocation.adviserId);
            ViewBag.cityId = new SelectList(db.Cities, "cityId", "name", promotionLocation.cityId);
            return View(promotionLocation);
        }

        // GET: PromotionLocations/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PromotionLocation promotionLocation = db.PromotionLocations.Find(id);
            if (promotionLocation == null)
            {
                return HttpNotFound();
            }
            ViewBag.adviserId = new SelectList(db.Advisers, "adviserId", "fullName", promotionLocation.adviserId);
            ViewBag.cityId = new SelectList(db.Cities, "cityId", "name", promotionLocation.cityId);
            return View(promotionLocation);
        }

        // POST: PromotionLocations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,adviserId,cityId,locationAddress,latitude,longitude,effectiveDate,effectiveTime,expireDate,expireTime,description")] PromotionLocation promotionLocation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(promotionLocation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.adviserId = new SelectList(db.Advisers, "adviserId", "fullName", promotionLocation.adviserId);
            return View(promotionLocation);
        }

        // GET: PromotionLocations/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PromotionLocation promotionLocation = db.PromotionLocations.Find(id);
            if (promotionLocation == null)
            {
                return HttpNotFound();
            }
            return View(promotionLocation);
        }

        // POST: PromotionLocations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            PromotionLocation promotionLocation = db.PromotionLocations.Find(id);
            db.PromotionLocations.Remove(promotionLocation);
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
