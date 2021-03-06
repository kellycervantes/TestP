﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TestP.Models;

namespace TestP.Controllers
{
    public class HistorialController : ApiController
    {
        HistorialRepository historialRep = new HistorialRepository();
        // GET: api/RechargeConfig
        public IEnumerable<HistorialC> Get()
        {
            return historialRep.findAll();
        }

        // GET: api/RechargeConfig/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/RechargeConfig
        public string Post([FromBody]HistorialC historial)
        {
            historialRep.Save(historial);

            return historial.message;
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
