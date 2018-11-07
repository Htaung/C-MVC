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
    public class AdviserCertificatesController : Controller
    {
        private AdviserListDBEntities db = new AdviserListDBEntities();

        // GET: AdviserCertificates
        public ActionResult Index()
        {
            var adviserCertificates = db.AdviserCertificates.Include(a => a.Adviser);
            return View(adviserCertificates.ToList());
        }

        // GET: AdviserCertificates/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdviserCertificate adviserCertificate = db.AdviserCertificates.Find(id);
            if (adviserCertificate == null)
            {
                return HttpNotFound();
            }
            return View(adviserCertificate);
        }

        // GET: AdviserCertificates/Create
        public ActionResult Create()
        {
            ViewBag.adviserId = new SelectList(db.Advisers, "adviserId", "fullName");
            return View();
        }

        // POST: AdviserCertificates/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "adviserCertificateId,adviserId,certificateName,certificateDescription,activeFlag")] AdviserCertificate adviserCertificate)
        {
            if (ModelState.IsValid)
            {
                adviserCertificate.id = Guid.NewGuid();
                db.AdviserCertificates.Add(adviserCertificate);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.adviserId = new SelectList(db.Advisers, "adviserId", "fullName", adviserCertificate.adviserId);
            return View(adviserCertificate);
        }

        // GET: AdviserCertificates/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdviserCertificate adviserCertificate = db.AdviserCertificates.Find(id);
            if (adviserCertificate == null)
            {
                return HttpNotFound();
            }
            ViewBag.adviserId = new SelectList(db.Advisers, "adviserId", "fullName", adviserCertificate.adviserId);
            return View(adviserCertificate);
        }

        // POST: AdviserCertificates/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "adviserCertificateId,adviserId,certificateName,certificateDescription,activeFlag")] AdviserCertificate adviserCertificate)
        {
            if (ModelState.IsValid)
            {
                db.Entry(adviserCertificate).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.adviserId = new SelectList(db.Advisers, "adviserId", "fullName", adviserCertificate.adviserId);
            return View(adviserCertificate);
        }

        // GET: AdviserCertificates/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdviserCertificate adviserCertificate = db.AdviserCertificates.Find(id);
            if (adviserCertificate == null)
            {
                return HttpNotFound();
            }
            return View(adviserCertificate);
        }

        // POST: AdviserCertificates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            AdviserCertificate adviserCertificate = db.AdviserCertificates.Find(id);
            db.AdviserCertificates.Remove(adviserCertificate);
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
