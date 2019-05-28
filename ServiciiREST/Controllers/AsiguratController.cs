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

        // GET: api/GetStareByID/123456789
        [ResponseType(typeof(bool))]
        public bool GetStareByID(string CNP)
        {
            Asigurat asg = db.Asigurat.Where(x => x.CNP.Equals(CNP)).FirstOrDefault();
            if (asg == null) return false;
            else return asg.StareAsigurat;
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