using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AdviserListWebApplication.Models;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace AdviserListWebApplication.Controllers
{
    public class AdvisersController : Controller
    {
        private AdviserListDBEntities db = new AdviserListDBEntities();

        private const string GET_POIS = "http://localhost:50201/api/advisers/";
        List<Adviser> adviserListData = null;

        // GET: Advisers
        public ActionResult Index()
        {
            return View(db.Advisers.Where(a => a.activeFlag == true).ToList());
        }

        //public async Task<ActionResult> Index()
        //{
        //    HttpClient httpClient = new HttpClient();
        //    httpClient.DefaultRequestHeaders.Accept.Add(
        //        new MediaTypeWithQualityHeaderValue("application/json"));
        //    HttpResponseMessage response = await httpClient.GetAsync(GET_POIS);
        //    if (response != null || response.IsSuccessStatusCode)
        //    {
        //        string content = await response.Content.ReadAsStringAsync();
        //        Console.Out.WriteLine("Response Body: \r\n {0}", content);

        //        adviserListData = new List<Adviser>();

        //        JArray jsonResponse = JArray.Parse(content);

        //        IList <JToken> results = jsonResponse.ToList();
        //        foreach (JToken token in results)
        //        {
        //            Adviser adviser = token.ToObject<Adviser>();
        //            adviserListData.Add(adviser);
        //        }
        //        return View(adviserListData);
        //    }
        //    else
        //    {
        //        Console.Out.WriteLine("Failed to fetch data. Try again later!");
        //        return null;
        //    }
        //}

        // GET: Advisers/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Adviser adviser = db.Advisers.Where(a => a.activeFlag == true
                                                && a.adviserId == id).FirstOrDefault();
            if (adviser == null)
            {
                return HttpNotFound();
            }
            return View(adviser);
        }

        // GET: Advisers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Advisers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "adviserId,fullName,displayName,nric, rns,dateOfBirth,contactNumber,email,address,aboutMeShort,aboutMe,creditCardNumber,creditCardExpire,password")] Adviser adviser, HttpPostedFileBase profilePhoto)
        {
            if (ModelState.IsValid)
            {
                //adviser.adviserId = Guid.NewGuid();
                var photo = new AdviserPhoto();
                if (profilePhoto != null && profilePhoto.ContentLength > 0)
                {
                    photo.name = Path.GetFileNameWithoutExtension(profilePhoto.FileName);
                    photo.type = Path.GetExtension(profilePhoto.FileName);
                    photo.profileFlag = true;
                    photo.activeFlag = true;
                    photo.location = "~/images/Profiles/";

                    adviser.AdviserPhotoes = new List<AdviserPhoto>();
                    adviser.AdviserPhotoes.Add(photo);
                }

                adviser.activeFlag = true;
                adviser.updatedDate = null;

                db.Advisers.Add(adviser);
                db.SaveChanges();

                if (profilePhoto != null && profilePhoto.ContentLength > 0)
                {
                    var path = Server.MapPath(Path.Combine(photo.location, adviser.adviserId.ToString().ToUpper()));
                    var directory = new DirectoryInfo(path);
                    if (directory.Exists == false)
                    {
                        directory.Create();
                    }

                    profilePhoto.SaveAs(Path.Combine(path, Path.GetFileName(profilePhoto.FileName)));
                }

                return RedirectToAction("Index");
            }

            return View(adviser);
        }

        // GET: Advisers/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Adviser adviser = db.Advisers.Find(id);
            if (adviser == null)
            {
                return HttpNotFound();
            }
            return View(adviser);
        }

        // POST: Advisers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "adviserId,fullName,displayName,nric,rns,dob,contactNumber,email,address,aboutMeShort,aboutMe,creditCardNumber,creditCardExpire,password,createdDate,updatedDate,viewCount,activeFlag")] Adviser adviser)
        {
            if (ModelState.IsValid)
            {
                db.Entry(adviser).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(adviser);
        }

        // GET: Advisers/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Adviser adviser = db.Advisers.Find(id);
            if (adviser == null)
            {
                return HttpNotFound();
            }
            return View(adviser);
        }

        // POST: Advisers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Adviser adviser = db.Advisers.Find(id);
            db.Advisers.Remove(adviser);
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
