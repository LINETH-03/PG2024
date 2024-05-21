using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PG2024.Models.ViewModels
{
    public class InventarioViewModel
    {
       
 
        [Required]
        [Display(Name = "ProductoID")]
        public int ProductoID { get; set; }

        [Required]
        [Display(Name = "NombreProducto")]
        public string NombreProducto { get; set; }

        [Required]
        [Display(Name = "TiendaID")]
        public int TiendaID { get; set; }
        [Required]
        [Display(Name = "NombredeTienda")]
        public string NombreTienda { get; set; }
        [Required]
        [Display(Name = "Cantidad")]
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }



    }

    public class AddInventarioViewModel
    {


        [Required]
        [Display(Name = "Producto")]
        public int ProductoID { get; set; }
        public IEnumerable<SelectListItem> Productos { get; set; } = new List<SelectListItem>();


        [Required]
        [Display(Name = "Tienda")]
        public int TiendaID { get; set; }


        public IEnumerable<SelectListItem> Tiendas { get; set; } = new List<SelectListItem>();

        [Required]
        [Display(Name = "Cantidad")]
       
        public int Cantidad { get; set; }
    



    }



    public class EditInventarioViewModel
    {

        public int InventarioID { get; set; }
        [Required]
        [Display(Name = "ProductoID")]
        public int ProductoID { get; set; }
        
        [Required]
        [Display(Name = "TiendaID")]
        public int TiendaID { get; set; }
       
        [Required]
        [Display(Name = "Cantidad")]
        public int Cantidad { get; set; }
        public IEnumerable<SelectListItem> Productos { get; set; } = new List<SelectListItem>();
        public IEnumerable<SelectListItem> Tiendas { get; set; } = new List<SelectListItem>();


    }
}