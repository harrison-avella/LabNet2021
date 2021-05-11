using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Lab.EF.Data;
using Lab.EF.Entities;

namespace Lab.EF.WAPI.Controllers
{
    public class TerritoriesController : ApiController
    {
        private NorthwindContext db = new NorthwindContext();

        // GET: api/Territories
        public IQueryable<Territories> GetTerritories()
        {
            return db.Territories;
        }

        // GET: api/Territories/5
        [ResponseType(typeof(Territories))]
        public IHttpActionResult GetTerritories(string id)
        {
            Territories territories = db.Territories.Find(id);
            if (territories == null)
            {
                return NotFound();
            }

            return Ok(territories);
        }

        // PUT: api/Territories/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTerritories(string id, Territories territories)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != territories.TerritoryID)
            {
                return BadRequest();
            }

            db.Entry(territories).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TerritoriesExists(id))
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

        // POST: api/Territories
        [ResponseType(typeof(Territories))]
        public IHttpActionResult PostTerritories(Territories territories)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Territories.Add(territories);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (TerritoriesExists(territories.TerritoryID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = territories.TerritoryID }, territories);
        }

        // DELETE: api/Territories/5
        [ResponseType(typeof(Territories))]
        public IHttpActionResult DeleteTerritories(string id)
        {
            Territories territories = db.Territories.Find(id);
            if (territories == null)
            {
                return NotFound();
            }

            db.Territories.Remove(territories);
            db.SaveChanges();

            return Ok(territories);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TerritoriesExists(string id)
        {
            return db.Territories.Count(e => e.TerritoryID == id) > 0;
        }
    }
}