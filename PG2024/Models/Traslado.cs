//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PG2024.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Traslado
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Traslado()
        {
            this.TrasladoProducto = new HashSet<TrasladoProducto>();
        }
    
        public int TrasladoID { get; set; }
        public Nullable<int> OrigenID { get; set; }
        public Nullable<int> DestinoID { get; set; }
        public Nullable<System.DateTime> Fecha { get; set; }
        public string Estado { get; set; }
    
        public virtual Tienda Tienda { get; set; }
        public virtual Tienda Tienda1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TrasladoProducto> TrasladoProducto { get; set; }
    }
}
