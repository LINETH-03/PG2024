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
    
    public partial class TrasladoProducto
    {
        public int TrasladoID { get; set; }
        public int ProductoID { get; set; }
        public Nullable<int> Cantidad { get; set; }
    
        public virtual Producto Producto { get; set; }
        public virtual Traslado Traslado { get; set; }
    }
}
