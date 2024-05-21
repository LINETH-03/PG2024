using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PG2024.Models.TablesNewModels
{
    public class ProductoTablaNewModel
    {
        public int ProductoID { get; set; }
        public string CodigoBarra { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }

        public int CategoriaID { get; set; }
        public string NombreCategoria { get; set; }
    }





    
}