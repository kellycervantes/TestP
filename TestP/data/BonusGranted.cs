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
    
    public partial class BonusGranted
    {
        public int Id { get; set; }
        public System.DateTime Date { get; set; }
        public bool BonusStatus { get; set; }
        public int IdRechargeSim { get; set; }
    
        public virtual RechargeSim RechargeSim { get; set; }
    }
}
