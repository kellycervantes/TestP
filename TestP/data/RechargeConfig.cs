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
    
    public partial class RechargeConfig
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public RechargeConfig()
        {
            this.RechargeSim = new HashSet<RechargeSim>();
        }
    
        public int Id { get; set; }
        public int Amount { get; set; }
        public int PriceperMinute { get; set; }
        public int Minutes { get; set; }
        public string Status { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RechargeSim> RechargeSim { get; set; }
    }
}