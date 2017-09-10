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
    
    public partial class RechargeSim
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public RechargeSim()
        {
            this.BonusGranted = new HashSet<BonusGranted>();
        }
    
        public int Id { get; set; }
        public double Amount { get; set; }
        public int IdSim { get; set; }
        public int IdRechargeConfig { get; set; }
        public System.DateTime Date { get; set; }
        public string Status { get; set; }
        public int Minutes { get; set; }
        public Nullable<int> Bonus { get; set; }
        public Nullable<int> BonusMin { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BonusGranted> BonusGranted { get; set; }
        public virtual RechargeConfig RechargeConfig { get; set; }
        public virtual Sims Sims { get; set; }
    }
}
