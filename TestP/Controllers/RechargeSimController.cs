using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TestP.Models;

namespace TestP.Controllers
{
    public class RechargeSimController : ApiController
    {
        RechargeSimRepository rechargesimRep = new RechargeSimRepository();
        // GET: api/RechargeSim
        public IEnumerable<RechargeSimC> Get()
        {

            return rechargesimRep.findAll();
        }

        // POST: api/RechargeSim
        public string Post([FromBody]RechargeSimC rechargesim)
        {
            rechargesimRep.Save(rechargesim);
            return rechargesim.message;
        }


        // DELETE: api/RechargeSim/5
        public void Delete(int id)
        {
        }
    }
}
