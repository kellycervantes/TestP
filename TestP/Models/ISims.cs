using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestP.Models
{
    interface ISims
    {
        List<SimsC> findAll();
        void Save(SimsC sim);
        void Remove(int id);
    }
}
