using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestP.Models
{
    public class RechargeSimC
    {

        public int ID { get; set; }
        public double  Amount { get; set; }
        public long  Number{ get; set; }
        public int  IdRechargeConfig { get; set; }
        public DateTime  Date { get; set; }
        public string Status { get; set; }
        public int  Minutes { get; set; }
        public Nullable<int>  Bonus { get; set; }

        public int searchIdSim;
        public double countRecharge { get; set; }
        public int checkbonus { get; set; }
        public int priceperminutesearch { get; set; }
        public int rechargeAVGMin { get; set; }
        public double averageRecharge;
        public double rechargeMinimum;
        public int sumRecharge;
        public double averageRechargeMinimum;
        public string message { get; set; }
    }
}