//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TestP.data
{
    using System;
    using System.Collections.Generic;
    
    public partial class Historial
    {
        public int Id { get; set; }
        public int IdSim { get; set; }
        public int MinutesConsumed { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
    
        public virtual Sims Sims { get; set; }
    }
}
