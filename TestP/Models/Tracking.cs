using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestP.Models
{
    public class Tracking
    {
        public long Number { get; set; }
        public Nullable<int> TotalMinutes { get; set; }
        public Nullable<int>MinutesUsed { get; set; }
        public Nullable<int> MinutesLeft { get; set; }
    }
}