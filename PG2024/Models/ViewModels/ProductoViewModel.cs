using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PG2024.Models.ViewModels
{
    public class ProductoViewModel
    {

        [Required]
        [Display(Name = "CodigoBarra")]
        public string CodigoBarra { get; set; }
        [Required]
        [Display(Name = "Nombre del Producto")]
        public string Nombre { get; set; }
        [Required]
        [Display(Name = "Precio")]
        public decimal Precio { get; set; }
        [Required]
        [Display(Name = "CategoriaID")]
        public int CategoriaID { get; set; }

        [Display(Name = "Categoria")]
        public string NombreCategoria { get; set; }

    }


    public class EditProductoViewModel
    {
        public int ProductoID { get; set; }
        [Required]
        [Display(Name = "CodigoBarra")]
        public string CodigoBarra { get; set; }
        [Required]
        [Display(Name = "Nombre del Producto")]
        public string Nombre { get; set; }
        [Required]
        [Display(Name = "Precio")]
        public decimal Precio { get; set; }
        [Required]
        [Display(Name = "CategoriaID")]
        public int? CategoriaID { get; set; }

        [Display(Name = "Categoria")]
        public string NombreCategoria { get; set; }

    }
}