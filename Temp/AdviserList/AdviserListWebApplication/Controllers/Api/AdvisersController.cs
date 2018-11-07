using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using AdviserListWebApplication.Models;
using Newtonsoft.Json;
using System.Web;
using System.IO;
using System.Net.Http.Headers;

namespace AdviserListWebApplication.Controllers.Api
{
    public class AdvisersController : ApiController
    {
        private AdviserListDBEntities db = new AdviserListDBEntities();

        // GET: api/Advisers/Test
        //public IEnumerable<string> Test()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET: api/Advisers/GetAdvisersJSON
        public HttpResponseMessage GetAdvisersJSON()
        {
            IQueryable<Adviser> advisers = db.Advisers.Where(a => a.activeFlag == true);
            
            var resp = JsonConvert.SerializeObject(advisers, Formatting.Indented,
                new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });
            var response = Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StringContent(resp, System.Text.Encoding.UTF8, "application/json");
            return response;
        }



        // GET: api/Advisers/GetAdvisers
        public IQueryable<Adviser> GetAdvisers()
        {
            return db.Advisers;
        }

        // GET: api/Advisers/GetAdviser/5
        [ResponseType(typeof(Adviser))]
        public async Task<IHttpActionResult> GetAdviser(Guid id)
        {
            Adviser adviser = await db.Advisers.FindAsync(id);
            if (adviser == null)
            {
                return NotFound();
            }

            return Ok(adviser);
        }

        // PUT: api/Advisers/PutAdviser/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutAdviser(Guid id, Adviser adviser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != adviser.adviserId)
            {
                return BadRequest();
            }

            db.Entry(adviser).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdviserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Advisers/PostAdviser
        [ResponseType(typeof(Adviser))]
        public async Task<IHttpActionResult> PostAdviser(Adviser adviser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Advisers.Add(adviser);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (AdviserExists(adviser.adviserId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = adviser.adviserId }, adviser);
        }

        // DELETE: api/Advisers/DeleteAdviser/5
        [ResponseType(typeof(Adviser))]
        public async Task<IHttpActionResult> DeleteAdviser(Guid id)
        {
            Adviser adviser = await db.Advisers.FindAsync(id);
            if (adviser == null)
            {
                return NotFound();
            }

            db.Advisers.Remove(adviser);
            await db.SaveChangesAsync();

            return Ok(adviser);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AdviserExists(Guid id)
        {
            return db.Advisers.Count(e => e.adviserId == id && e.activeFlag == true) > 0;
        }

        //private MemoryStream CopyFileToMemory(string path)
        //{
        //    MemoryStream ms = new MemoryStream();
        //    FileStream fs = new FileStream(path, FileMode.Open);
        //    fs.Position = 0;
        //    fs.CopyTo(ms);
        //    fs.Close();
        //    fs.Dispose();
        //    return ms;
        //}
        //public HttpResponseMessage GetImage(string path)
        //{
        //    MemoryStream ms = null;
        //    HttpContext context = HttpContext.Current;
        //    string filePath = context.Server.MapPath(path);
        //    string extension = Path.GetExtension(filePath);
        //    if (File.Exists(filePath))
        //    {
        //        ms = CopyFileToMemory(filePath);
        //    }

        //    HttpResponseMessage result = new HttpResponseMessage(HttpStatusCode.OK);
        //    result.Content = new ByteArrayContent(ms.ToArray());
        //    result.Content.Headers.ContentType = new MediaTypeHeaderValue(string.Format("image/{0}", extension));
        //    return result;
        //}
    }
}