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
using ServiciiREST.Models;

namespace ServiciiREST.Controllers
{
    public class RaportSpitaleController : ApiController
    {
        private PortalCasEntities db = new PortalCasEntities();

        // GET: api/RaportSpitale
        public IQueryable<DateRaportSpital> GetDateRaportSpital()
        {
            return db.DateRaportSpital;
        }

        // GET: api/RaportSpitale/5
        [ResponseType(typeof(DateRaportSpital))]
        public IHttpActionResult GetDateRaportSpital(string id)
        {
            DateRaportSpital dateRaportSpital = db.DateRaportSpital.Find(id);
            if (dateRaportSpital == null)
            {
                return NotFound();
            }

            return Ok(dateRaportSpital);
        }

        // POST: api/RaportSpitale
        [ResponseType(typeof(DateRaportSpital))]
        public IHttpActionResult PostDateRaportSpital(DateRaportSpital dateRaportSpital)
        {
            if (!ModelState.IsValid || DateRaportSpitalExists(dateRaportSpital))
            {
                return BadRequest(ModelState);
            }

            db.DateRaportSpital.Add(dateRaportSpital);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (DateRaportSpitalExists(dateRaportSpital))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }
            return CreatedAtRoute("DefaultApi", null, dateRaportSpital);
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DateRaportSpitalExists(DateRaportSpital data)
        {
            return db.DateRaportSpital.Count(e => e.NumarCaz == data.NumarCaz
            && e.CNP == data.CNP
            && e.CodDiagnosticPrincipal == data.CodDiagnosticPrincipal
            && e.CodInvestigatie == data.CodInvestigatie
            && e.CostAditionalInvestigatie == data.CostAditionalInvestigatie
            && e.CodServiciuMedical == data.CodServiciuMedical
            && e.CostAditionalServiciuMedical == data.CostAditionalServiciuMedical
            ) > 0; 
        }
    }
}