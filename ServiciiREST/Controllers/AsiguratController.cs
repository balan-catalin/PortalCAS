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
    public class AsiguratController : ApiController
    {
        private PortalCasEntities db = new PortalCasEntities();

        // GET: api/Asigurat
        public IQueryable<Asigurat> GetAsigurat()
        {
            return db.Asigurat;
        }

        // GET: api/Asigurat/5
        [ResponseType(typeof(Asigurat))]
        public IHttpActionResult GetAsigurat(string id)
        {
            Asigurat asigurat = db.Asigurat.Find(id);
            if (asigurat == null)
            {
                return NotFound();
            }

            return Ok(asigurat);
        }
       
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AsiguratExists(string id)
        {
            return db.Asigurat.Count(e => e.CNP == id) > 0;
        }
    }
}