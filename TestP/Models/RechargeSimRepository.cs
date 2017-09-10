using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TestP.data;

namespace TestP.Models
{
    public class RechargeSimRepository
    {
        private readonly TestEntities db = new TestEntities();
        private HistorialRepository historial;
        public List<RechargeSimC> findAll()
        {

            var records = (from rs in db.RechargeSim
                           from s in db.Sims
                           where rs.IdSim == s.Id
                           select new RechargeSimC
                           {
                               ID = rs.Id,
                               Amount = rs.Amount,
                               Minutes = rs.Minutes,
                               Bonus = rs.Bonus,
                               Date = rs.Date,
                               Number = s.Number,
                               Status = rs.Status
                           }).AsQueryable();

            //if (!string.IsNullOrWhiteSpace(searchString))
            //{
            //    records = records.Where(p => p.Number.ToString().Contains(searchString) );
            //}

            //if (!string.IsNullOrEmpty(sortBy) && !string.IsNullOrEmpty(direction))
            //{
            //    if (direction.Trim().ToLower() == "asc")
            //    {
            //        records = SortHelper.OrderBy(records, sortBy);
            //    }
            //    else
            //    {
            //        records = SortHelper.OrderByDescending(records, sortBy);
            //    }
            //}

            //if (page.HasValue && limit.HasValue)
            //{
            //    int start = (page.Value - 1) * limit.Value;
            //    records = records.OrderBy(x => x.ID).Skip(start).Take(limit.Value);
            //}

            return records.ToList();
        }
        /// <summary>
        /// Listael historial de recargas
        /// </summary>
        /// <returns></returns>
        public List<RechargeConfigC> GetList()
        {

            var rechargeconflist = db.RechargeConfig.Where(x => x.Status == "A").ToList().Select(item => new RechargeConfigC
            {
                ID = item.Id,
                Amount = item.Amount
            }).AsQueryable();

            return rechargeconflist.ToList();
        }

        /// <summary>
        /// Guardar la recarga, si es mayor a el promedio, entonces agregar el 10% del valor que van a recargar
        /// </summary>
        /// <param name="rechargesim"></param>
        public void Save(RechargeSimC rechargesim)
        {
            var found = 0;
            try
            {

                found  = db.Sims.Where(x => x.Number == rechargesim.Number).Count();
               
                if (found == 0)
                {
                    rechargesim.message = "Mobile Number is not found";
                    return;
                }
                rechargesim.searchIdSim = db.Sims.FirstOrDefault(x => x.Number == rechargesim.Number).Id;


                rechargesim.countRecharge = db.RechargeSim.Where(x => x.IdSim == rechargesim.searchIdSim).Count();

                RechargeConfig searchConfig = db.RechargeConfig.FirstOrDefault(x => x.Id == rechargesim.IdRechargeConfig);
                if (rechargesim.countRecharge != 0)
                {
                    rechargesim.averageRecharge = db.RechargeSim.Where(x => x.IdSim == rechargesim.searchIdSim).Average(x => x.Amount);
                    rechargesim.rechargeMinimum = db.RechargeSim.Min(x=>x.RechargeConfig.Amount);
                    int days = DateTime.Now.DayOfWeek - DayOfWeek.Sunday;
                    DateTime weekStart = DateTime.Now.AddDays(-days);
                    DateTime weekEnd = weekStart.AddDays(6);
                    int cont = db.RechargeSim.Where(x => x.IdSim == rechargesim.searchIdSim && x.Amount == rechargesim.rechargeMinimum).Count();
                    if (cont != 0)
                    {
                        rechargesim.averageRechargeMinimum = Math.Round(db.RechargeSim.Where(x => x.IdSim == rechargesim.searchIdSim && x.Amount == rechargesim.rechargeMinimum && rechargesim.Date >= weekStart && rechargesim.Date <= weekEnd).Average(x => x.Amount));
                    }
                    rechargesim.checkbonus = db.BonusGranted.Where(x => DbFunctions.TruncateTime(x.Date) == DbFunctions.TruncateTime(DateTime.Now)).Count();
                    if (rechargesim.checkbonus == 0)
                    {
                        if (searchConfig.Amount > rechargesim.averageRecharge)
                        {
                            rechargesim.Bonus = Convert.ToInt32(Convert.ToDouble(searchConfig.Amount) * 0.1);
                        }
                    }
                }

                if (rechargesim.Bonus != 0)
                {
                    rechargesim.priceperminutesearch = db.RechargeConfig.FirstOrDefault(x => x.Id == rechargesim.IdRechargeConfig).PriceperMinute;
                }

                if (rechargesim.ID == 0)
                {
                    RechargeSim  xrechargesim = new RechargeSim();
                    xrechargesim.BonusMin = rechargesim.Bonus / rechargesim.priceperminutesearch;
                    xrechargesim.Minutes = searchConfig.Minutes + Convert.ToInt32(xrechargesim.BonusMin);
                    xrechargesim.Amount = searchConfig.Amount + Convert.ToInt32(rechargesim.Bonus); ;
                    xrechargesim.Date = DateTime.Now;
                    xrechargesim.IdSim = rechargesim.searchIdSim;
                    xrechargesim.Bonus = rechargesim.Bonus;
                    xrechargesim.IdRechargeConfig = rechargesim.IdRechargeConfig;
                    xrechargesim.Status = "A";
                    db.RechargeSim.Add(xrechargesim);
                    rechargesim.message = "Your recharge was successful!";
                }
               db.SaveChanges();
                if (rechargesim.Bonus != null)
                {
                    var bonusGranted = new BonusGranted();
                    bonusGranted.Date = DateTime.Now;
                    bonusGranted.IdRechargeSim = db.RechargeSim.Where(x => x.IdSim == rechargesim.searchIdSim).Select(x => x.Id).Max();
                    bonusGranted.BonusStatus = true;
                    db.BonusGranted.Add(bonusGranted);
                    db.SaveChanges();
                  
                }
            }
            catch (Exception ex){
                string error = "";
                error = ex.Message;
            }
        //}



        

    }
}
}