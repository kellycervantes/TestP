using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestP.Models
{
    interface IRechargeConfig
    {
        List<RechargeConfigC> findAll();
        void Save(RechargeConfigC sim);
        void Remove(int id);
    }
}
