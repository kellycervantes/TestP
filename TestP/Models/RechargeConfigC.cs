using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestP.Models
{
    public class RechargeConfigC
    {
        public int ID { get; set; }
        public int Amount { get; set; }
        public int PriceperMinute { get; set; }
        public int Minutes { get; set; }
        public string Status { get; set; }
        public string message { get; set; }
        //  public virtual ICollection<RechargeSim> RechargeSim { get; set; }
    }
}