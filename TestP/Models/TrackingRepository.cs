using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestP.data;

namespace TestP.Models
{
    public class TrackingRepository
    {
        private readonly TestEntities db = new TestEntities();
        public List<Tracking> findAll()
        {

            var records = (from report in db.VwMinutesReport  
                           select new Tracking
                           {
                               Number= report.Number,
                               TotalMinutes = report.TotalMinutes,
                               MinutesUsed = report.MinutesConsumed, 
                                MinutesLeft = report.MinutesLeft
                           }).Distinct().AsQueryable();



            return records.ToList();
        }
    }
}