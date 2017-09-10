using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestP.Models
{
    interface ITracking
    {
        List<Tracking> findAll();  
    }
}
