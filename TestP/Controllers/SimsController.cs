using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TestP.Models;

namespace TestP.Controllers
{
    public class SimsController : ApiController
    {

        SimsRepository simRep = new SimsRepository();
        // GET: api/Sims
        public IEnumerable<SimsC> Get()
        {
            return simRep.findAll();
        }

        // GET: api/Sims/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Sims
        public string Post([FromBody]SimsC sim)
        {
            simRep.Save(sim);
            return sim.message;
        }

        // PUT: api/Sims/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Sims/5
        public void Delete(int id)
        {
        }
    }
}
