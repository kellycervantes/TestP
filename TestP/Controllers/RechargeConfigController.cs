using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TestP.Models;

namespace TestP.Controllers
{
    public class RechargeConfigController : ApiController
    {
        RechargeConfigRepository rechargeconfRep = new RechargeConfigRepository();
        // GET: api/RechargeConfig
        public IEnumerable<RechargeConfigC> Get()
        {
            return rechargeconfRep.findAll();
        }

        // GET: api/RechargeConfig/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/RechargeConfig
        public string Post([FromBody]RechargeConfigC rechargeconf)
        {
            rechargeconfRep.Save(rechargeconf);

            return rechargeconf.message;
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
