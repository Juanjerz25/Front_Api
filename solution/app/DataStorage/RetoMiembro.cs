//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataStorage
{
    using System;
    using System.Collections.Generic;
    
    public partial class RetoMiembro
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public RetoMiembro()
        {
            this.Puntaje = new HashSet<Puntaje>();
        }
    
        public int Id { get; set; }
        public int RetoId { get; set; }
        public int MiembroId { get; set; }
        public System.DateTime TiempoLimite { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Puntaje> Puntaje { get; set; }
        public virtual Miembro Miembro { get; set; }
        public virtual Reto Reto { get; set; }
    }
}
