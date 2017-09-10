using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TestP.Models;

namespace TestP.Controllers
{
    public class TrackingController : ApiController
    {
        TrackingRepository trackingRep = new TrackingRepository();
        // GET: api/RechargeConfig
        public IEnumerable<Tracking> Get()
        {
            return trackingRep.findAll();
        }

        // PUT: api/RechargeConfig/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/RechargeConfig/5
        public void Delete(int id)
        {
        }
    }
}
