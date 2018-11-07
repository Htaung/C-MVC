using System;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using AdviserListWebApplication.Models;

namespace AdviserListWebApplication.Controllers.Api
{
    public class PromotionLocationsController : ApiController
    {
        private AdviserListDBEntities db = new AdviserListDBEntities();

        // GET: api/PromotionLocations/GetPromotionLocations
        public IQueryable<PromotionLocation> GetPromotionLocations()
        {
            return db.PromotionLocations;
        }

        // GET: api/PromotionLocations/GetPromotionLocationsByAdviserId/5
        public IQueryable<PromotionLocation> GetPromotionLocationsByAdviserId(Guid id)
        {
            return db.PromotionLocations.Where(x => x.adviserId == id);
        }

        // GET: api/PromotionLocations/GetPromotionLocation/5
        [ResponseType(typeof(PromotionLocation))]
        public async Task<IHttpActionResult> GetPromotionLocation(Guid id)
        {
            PromotionLocation promotionLocation = await db.PromotionLocations.FindAsync(id);
            if (promotionLocation == null)
            {
                return NotFound();
            }

            return Ok(promotionLocation);
        }

        // PUT: api/PromotionLocations/PutPromotionLocation/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutPromotionLocation(Guid id, PromotionLocation promotionLocation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != promotionLocation.id)
            {
                return BadRequest();
            }

            db.Entry(promotionLocation).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PromotionLocationExists(id))
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

        // POST: api/PromotionLocations
        [ResponseType(typeof(PromotionLocation))]
        public async Task<IHttpActionResult> PostPromotionLocation(PromotionLocation promotionLocation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PromotionLocations.Add(promotionLocation);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PromotionLocationExists(promotionLocation.id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = promotionLocation.id }, promotionLocation);
        }

        // DELETE: api/PromotionLocations/5
        [ResponseType(typeof(PromotionLocation))]
        public async Task<IHttpActionResult> DeletePromotionLocation(Guid id)
        {
            PromotionLocation promotionLocation = await db.PromotionLocations.FindAsync(id);
            if (promotionLocation == null)
            {
                return NotFound();
            }

            db.PromotionLocations.Remove(promotionLocation);
            await db.SaveChangesAsync();

            return Ok(promotionLocation);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PromotionLocationExists(Guid id)
        {
            return db.PromotionLocations.Count(e => e.id == id) > 0;
        }
    }
}