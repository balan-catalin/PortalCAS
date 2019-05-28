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
    public class ConcediuMedicalController : ApiController
    {
        private PortalCasEntities db = new PortalCasEntities();

        // GET: api/ConcediuMedical
        //public IQueryable<ConcediuMedical> GetConcediuMedical()
        //{
         //   return db.ConcediuMedical;
        //}

        // GET: api/ConcediuMedical/5
        [HttpGet]
        public int NumarConcediiMedicale(string CNP)
        {
            int nrConcedii = 0;
            foreach (ConcediuMedical item in db.ConcediuMedical.Where(x => x.CNP.Equals(CNP)).ToList())
            {
                if(item.DataIncepu < DateTime.Today.AddYears(-1) && item.DataSfarsit > DateTime.Today.AddYears(-1))
                {
                    nrConcedii += (item.DataSfarsit - DateTime.Today.AddYears(-1)).Days;
                }
                else if(item.DataSfarsit > DateTime.Today.AddYears(-1))
                        nrConcedii += (item.DataSfarsit - item.DataIncepu).Days;
            }
            return nrConcedii;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ConcediuMedicalExists(string id)
        {
            return db.ConcediuMedical.Count(e => e.CNP == id) > 0;
        }
    }
}