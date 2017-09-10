using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestP.Models
{
    public interface IRechargeSim
    {
        List<RechargeSimC> findAll();
        List<RechargeSimC> GetList();
        void Save(RechargeSimC sim);
        //void Remove(int id);
    }
}