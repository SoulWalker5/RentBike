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
using BikeApi.Models;

namespace BikeApi.Controllers
{
    public class BikeTypeController : ApiController
    {
        private BikeContext db = new BikeContext();

        // GET: api/BikeType
        public IQueryable<BikeType> GetBikeTypes()
        {
            return db.BikeTypes;
        }

        // GET: api/BikeType/5
        [ResponseType(typeof(BikeType))]
        public async Task<IHttpActionResult> GetBikeType(int id)
        {
            BikeType bikeType = await db.BikeTypes.FindAsync(id);
            if (bikeType == null)
            {
                return NotFound();
            }

            return Ok(bikeType);
        }

        // PUT: api/BikeType/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutBikeType(int id, BikeType bikeType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != bikeType.BikeTypeId)
            {
                return BadRequest();
            }

            db.Entry(bikeType).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BikeTypeExists(id))
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

        // POST: api/BikeType
        [ResponseType(typeof(BikeType))]
        public async Task<IHttpActionResult> PostBikeType(BikeType bikeType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.BikeTypes.Add(bikeType);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = bikeType.BikeTypeId }, bikeType);
        }

        // DELETE: api/BikeType/5
        [ResponseType(typeof(BikeType))]
        public async Task<IHttpActionResult> DeleteBikeType(int id)
        {
            BikeType bikeType = await db.BikeTypes.FindAsync(id);
            if (bikeType == null)
            {
                return NotFound();
            }

            db.BikeTypes.Remove(bikeType);
            await db.SaveChangesAsync();

            return Ok(bikeType);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BikeTypeExists(int id)
        {
            return db.BikeTypes.Count(e => e.BikeTypeId == id) > 0;
        }
    }
}