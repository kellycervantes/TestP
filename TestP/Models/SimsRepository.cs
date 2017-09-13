using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestP.data;

namespace TestP.Models
{
    public class SimsRepository : ISims
    {

        private readonly TestEntities db = new TestEntities();
        /// <summary>
        /// Listas Sims registradas
        /// </summary>
        /// <returns></returns>
        public List<SimsC> findAll()
        {

            var records = (from p in db.Sims
                           select new SimsC
                           {
                               ID = p.Id,
                               Number = p.Number,
                               SerialNumber = p.SerialNumber
                           }).AsQueryable();


            return records.ToList();
        }

        /// <summary>
        /// Guardar Sims 
        /// </summary>
        /// <param name="sim"></param>
        public void Save(SimsC sim)
        {

            if (sim.ID > 0)
            {
                var xsim = (from p in db.Sims
                            where p.Id == sim.ID
                            select p).FirstOrDefault();
                if (xsim != null)
                {
                    xsim.Number = sim.Number;
                    xsim.SerialNumber = xsim.SerialNumber;

                }
            }
            else
            {
                var xsim = (from p in db.Sims
                            where p.Id == sim.ID
                            select p).FirstOrDefault();
                if (xsim != null)
                {
                    Sims nuevo = new Sims();
                    nuevo.Number = sim.Number;
                    nuevo.SerialNumber = sim.SerialNumber;

                    db.Sims.Add(nuevo);

                }

            }
            db.SaveChanges();
            sim.message = "Record have been saved";
        }


         

    }
}