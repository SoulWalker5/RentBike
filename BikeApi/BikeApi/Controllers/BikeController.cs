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
    public class BikeController : ApiController
    {
        private BikeContext db = new BikeContext();

        // GET: api/Bike
        public IQueryable<Bike> GetBikes()
        {
            return db.Bikes;
        }

        // GET: api/Bike/RentedBike
        [Route("api/Bike/RentedBike")]
        [HttpGet]
        public async Task<IEnumerable<Bike>> GetRentedBikes()
        {
            return await db.Bikes.Where(b => b.RentStateId == 1).ToListAsync();
        }

        // GET: api/Bike/FreeBike
        [Route("api/Bike/FreeBike")]
        [HttpGet]
        public async Task<IEnumerable<Bike>> GetFreeBikes()
        {
            return await db.Bikes.Where(b => b.RentStateId == 2).ToListAsync();
        }

        // GET: api/Bike/5
        [ResponseType(typeof(Bike))]
        public async Task<IHttpActionResult> GetBike(int id)
        {
            Bike bike = await db.Bikes.FindAsync(id);
            if (bike == null)
            {
                return NotFound();
            }

            return Ok(bike);
        }

        // PUT: api/Bike/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutBike(int id, Bike bike)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != bike.BikeId)
            {
                return BadRequest();
            }

            db.Entry(bike).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BikeExists(id))
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

        // POST: api/Bike
        [ResponseType(typeof(Bike))]
        public async Task<IHttpActionResult> PostBike(Bike bike)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Bikes.Add(bike);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = bike.BikeId }, bike);
        }

        // DELETE: api/Bike/5
        [ResponseType(typeof(Bike))]
        public async Task<IHttpActionResult> DeleteBike(int id)
        {
            Bike bike = await db.Bikes.FindAsync(id);
            if (bike == null)
            {
                return NotFound();
            }

            db.Bikes.Remove(bike);
            await db.SaveChangesAsync();

            return Ok(bike);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BikeExists(int id)
        {
            return db.Bikes.Count(e => e.BikeId == id) > 0;
        }
    }
}