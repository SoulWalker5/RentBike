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
    public class RentStateController : ApiController
    {
        private BikeContext db = new BikeContext();

        // GET: api/RentState
        public IQueryable<RentState> GetRentStates()
        {
            return db.RentStates;
        }

        // GET: api/RentState/5
        [ResponseType(typeof(RentState))]
        public async Task<IHttpActionResult> GetRentState(int id)
        {
            RentState rentState = await db.RentStates.FindAsync(id);
            if (rentState == null)
            {
                return NotFound();
            }

            return Ok(rentState);
        }

        // PUT: api/RentState/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutRentState(int id, RentState rentState)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != rentState.RentStateId)
            {
                return BadRequest();
            }

            db.Entry(rentState).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RentStateExists(id))
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

        // POST: api/RentState
        [ResponseType(typeof(RentState))]
        public async Task<IHttpActionResult> PostRentState(RentState rentState)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.RentStates.Add(rentState);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = rentState.RentStateId }, rentState);
        }

        // DELETE: api/RentState/5
        [ResponseType(typeof(RentState))]
        public async Task<IHttpActionResult> DeleteRentState(int id)
        {
            RentState rentState = await db.RentStates.FindAsync(id);
            if (rentState == null)
            {
                return NotFound();
            }

            db.RentStates.Remove(rentState);
            await db.SaveChangesAsync();

            return Ok(rentState);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RentStateExists(int id)
        {
            return db.RentStates.Count(e => e.RentStateId == id) > 0;
        }
    }
}