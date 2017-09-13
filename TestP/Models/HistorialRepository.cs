using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestP.data;

namespace TestP.Models
{
    public class HistorialRepository : IHistorial
    {

        private readonly TestEntities db = new TestEntities();

        /// <summary>
        /// Listar llamada
        /// </summary>
        /// <returns></returns>
        public List<HistorialC> findAll()
        {
            var records = (from p in db.Historial
                           select new HistorialC
                           {
                               ID = p.Id,
                               Number = p.Sims.Number,
                               MinutesConsumed = p.MinutesConsumed,
                               Date = p.Date
                           }).AsQueryable();

            return records.ToList();
        }


        /// <summary>
        /// Guardar llamada
        /// </summary>
        /// <param name="historial"></param>
        public void Save(HistorialC historial)
        {
            var countminuteConsumed = 0;
            var sumTotalMinutes = 0;
            var totalMinutes = 0;
            var found = 0;

            Sims searchSim = db.Sims.FirstOrDefault(x => x.Number == historial.Number);
            if (searchSim == null) {
                historial.message = "Mobile Number is not found";
                return;

            }
            found = searchsim(searchSim.Id);
            if (found == 0)
            {
                historial.message = "Mobile Number is not found";
                return;
            }


            countminuteConsumed = db.Historial.Where(x => x.IdSim == searchSim.Id).Count();
            if (countminuteConsumed != 0)
            {
                historial.minuteConsumedSum = db.Historial.Where(x => x.IdSim == searchSim.Id).Sum(x => x.MinutesConsumed);
            }
            sumTotalMinutes = historial.minuteConsumedSum + historial.MinutesConsumed;
            totalMinutes = db.RechargeSim.Where(x => x.Sims.Number == historial.Number).Sum(x => x.Minutes);

            if (sumTotalMinutes <= totalMinutes)
            {
                Historial nuevo = new Historial();
                nuevo.MinutesConsumed = historial.MinutesConsumed;
                nuevo.IdSim = searchSim.Id;
                nuevo.Date = DateTime.Now;
                db.Historial.Add(nuevo);
                db.SaveChanges();
                historial.message = "Record has been saved";
            }
            else
            {

                historial.message = "Please recharge you mobile";
            }




        }

        public int searchsim(long simId)
        {
            int findsim = db.Sims.Where(x => x.Id == simId).Count();
            return findsim;
        }




    }
}