using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PG2024.Models.TablesNewModels
{
    public class InventarioTableNewModel
    {
        public int InventarioID { get; set; }
        public int ProductoID { get; set; }
        public string NombreProducto { get; set; }
        public int TiendaID { get; set; }
        public string NombreTienda { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
    }
}