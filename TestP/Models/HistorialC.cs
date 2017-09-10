using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestP.Models
{
    public class HistorialC
    {
        public int ID { get; set; }
    //    public int RechargeSimId { get; set; }
        public long Number { get; set; }
        public int MinutesConsumed { get; set; }
        public string message { get; set; }
        public int  minuteConsumedSum { get; set; }
        public DateTime ? Date { get; set; }
    }
}