using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestP.data;

namespace TestP.Models
{
    public class RechargeConfigRepository
    {
        private readonly TestEntities db = new TestEntities();
        public List<RechargeConfigC> findAll()
        {
            var records = (from p in db.RechargeConfig
                           where p.Status == "E"
                           select new RechargeConfigC
                           {
                               ID = p.Id,
                               Amount = p.Amount,
                               Minutes = p.Minutes,
                               PriceperMinute = p.PriceperMinute,
                               Status = p.Status
                           }).AsQueryable();

            return records.ToList();
        }

        public void Save(RechargeConfigC rechargeconf)
        {

            if (rechargeconf.ID > 0 && rechargeconf.Amount != 0)
            {
                var xrechargeconf = (from p in db.RechargeConfig
                                     where p.Amount == rechargeconf.Amount && rechargeconf.Status == "D"
                                     select p).FirstOrDefault();
                if (xrechargeconf != null)
                {
                    addNewRecord(rechargeconf);
                    rechargeconf.message = "Record have been saved";
                }
                else
                {
                    if (rechargeconf.Amount != 0 && rechargeconf.PriceperMinute != 0)
                    {
                        addNewRecord(rechargeconf);
                        rechargeconf.message = "Record have been saved";
                    }
                    else
                    {
                        rechargeconf.message = " Record is already exists, Please disable current amount to change it";
                    }
                }

            }
            if (rechargeconf.ID == 0 && rechargeconf.Status == null)
            {
                var xrechargeconf = (from p in db.RechargeConfig
                                     where p.Amount == rechargeconf.Amount
                                     //&& rechargeconf.Status != "E"
                                     select p).FirstOrDefault();
                if (xrechargeconf == null)
                {
                    addNewRecord(rechargeconf);
                    rechargeconf.message = "Record have been saved";
                }
                else
                {
                    rechargeconf.message = " Record is already exists, Please disable current amount to change it";
                }

            }
            else
            {
                if (rechargeconf.Status == "D")
                {

                    RechargeConfig searchRecord = db.RechargeConfig.FirstOrDefault(x => x.Id == rechargeconf.ID);
                    searchRecord.Status = "D";
                    db.SaveChanges();

                    rechargeconf.message = "Record has been disabled";

                }
            }

        }

        public void addNewRecord(RechargeConfigC rechargeconf)
        {
            RechargeConfig newrecord = new RechargeConfig();
            newrecord.Minutes = rechargeconf.Amount / rechargeconf.PriceperMinute;
            newrecord.Amount = rechargeconf.Amount;
            newrecord.PriceperMinute = rechargeconf.PriceperMinute;
            newrecord.Status = "E";
            db.RechargeConfig.Add(newrecord);
            db.SaveChanges();
        }


    }
}
