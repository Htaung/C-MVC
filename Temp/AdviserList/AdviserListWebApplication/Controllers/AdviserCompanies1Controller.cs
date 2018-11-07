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
            var adviserCompanies = db.AdviserCompanies.Include(a => a.Adviser).Include(a => a.Company);
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
        public ActionResult Create([Bind(Include = "adviserId,companyId,designation,contactNumber,email,primaryFlag")] AdviserCompany adviserCompany)
        {
            if (ModelState.IsValid)
            {
                //adviserCompany.id = Guid.NewGuid();
                db.AdviserCompanies.Add(adviserCompany);
                //try
                //{
                    db.SaveChanges();
                //}
                //catch (System.Data.Entity.Infrastructure.DbUpdateException upEx)
                //{
                //    if (upEx.Entries != null && upEx.Entries.Any())
                //    {
                //        //Logger.Debug("DbUpdateException contained '{0}' entries:", upEx.Entries.Count());

                //        // get info about the Entity that produced the error
                //        foreach (var dbEntityEntry in upEx.Entries)
                //        {
                //            if (dbEntityEntry.Entity != null)
                //            {
                //                var entityType = dbEntityEntry.Entity.GetType();
                //                try
                //                {
                //                    var id = entityType.GetProperty("Id").GetValue(dbEntityEntry.Entity, null);
                //                    //Logger.Debug("DbUpdateException contains DbEntityEntry - Type: '{0}', Id: '{1}', State: '{2}'", entityType.Name, id, dbEntityEntry.State.ToString("G"));
                //                }
                //                catch (Exception)
                //                {
                //                    //Logger.Debug("DbUpdateException contains DbEntityEntry - Type '{0}', Id: unknown, State: '{2}'", entityType.Name, dbEntityEntry.State.ToString("G"));
                //                }
                //            }
                //        }
                //    }
                //}
                
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
            AdviserCompany adviserCompany = db.AdviserCompanies.Find(id);
            db.AdviserCompanies.Remove(adviserCompany);
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
