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
    public class AdviserCompaniesController : Controller
    {
        private AdviserListDBEntities db = new AdviserListDBEntities();

        // GET: AdviserCompanies
        public ActionResult Index()
        {
            var adviserCompanies = db.AdviserCompanies.Include(a => a.Adviser).Include(a => a.Company).Where(a=>a.activeFlag==true);
            return View(adviserCompanies.ToList());
        }

        // GET: AdviserCompanies/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdviserCompany adviserCompany = db.AdviserCompanies.Find(id);
            if (adviserCompany == null)
            {
                return HttpNotFound();
            }
            return View(adviserCompany);
        }

        // GET: AdviserCompanies/Create
        public ActionResult Create()
        {
            ViewBag.adviserId = new SelectList(db.Advisers, "adviserId", "fullName");
            ViewBag.companyId = new SelectList(db.Companies, "companyId", "companyName");
            return View();
        }

        // POST: AdviserCompanies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,adviserId,companyId,designation,contactNumber,email,createdDate,primaryFlag,activeFlag")] AdviserCompany adviserCompany)
        {
            if (ModelState.IsValid)
            {
                adviserCompany.id = Guid.NewGuid();
                //db.AdviserCompanies.Add(adviserCompany);
                db.AdviserCompanyInsert(adviserCompany.adviserId, 
                    adviserCompany.companyId,
                    adviserCompany.designation, 
                    adviserCompany.contactNumber, 
                    adviserCompany.email, 
                    adviserCompany.primaryFlag);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.adviserId = new SelectList(db.Advisers, "adviserId", "fullName", adviserCompany.adviserId);
            ViewBag.companyId = new SelectList(db.Companies, "companyId", "companyName", adviserCompany.companyId);
            return View(adviserCompany);
        }

        // GET: AdviserCompanies/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdviserCompany adviserCompany = db.AdviserCompanies.Find(id);
            if (adviserCompany == null)
            {
                return HttpNotFound();
            }
            ViewBag.adviserId = new SelectList(db.Advisers, "adviserId", "fullName", adviserCompany.adviserId);
            ViewBag.companyId = new SelectList(db.Companies, "companyId", "companyName", adviserCompany.companyId);
            return View(adviserCompany);
        }

        // POST: AdviserCompanies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,adviserId,companyId,designation,contactNumber,email,createdDate,primaryFlag,activeFlag")] AdviserCompany adviserCompany)
        {
            if (ModelState.IsValid)
            {
                db.Entry(adviserCompany).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.adviserId = new SelectList(db.Advisers, "adviserId", "fullName", adviserCompany.adviserId);
            ViewBag.companyId = new SelectList(db.Companies, "companyId", "companyName", adviserCompany.companyId);
            return View(adviserCompany);
        }

        // GET: AdviserCompanies/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdviserCompany adviserCompany = db.AdviserCompanies.Find(id);
            if (adviserCompany == null)
            {
                return HttpNotFound();
            }
            return View(adviserCompany);
        }

        // POST: AdviserCompanies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            //AdviserCompany adviserCompany = db.AdviserCompanies.Find(id);
            //db.AdviserCompanies.Remove(adviserCompany);
            db.AdviserCompanyDelete(id);
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
