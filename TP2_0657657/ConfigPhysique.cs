//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TP2_0657657
{
    using System;
    using System.Collections.Generic;
    
    public partial class ConfigPhysique
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ConfigPhysique()
        {
            this.Essaies = new HashSet<Essaie>();
            this.Buses = new HashSet<Buse>();
        }
    
        public int ID { get; set; }
        public Nullable<int> ImprimanteId { get; set; }
        public bool Active { get; set; }
        public string Description { get; set; }
    
        public virtual Imprimante Imprimante { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Essaie> Essaies { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Buse> Buses { get; set; }
    }
}
