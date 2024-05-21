using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PG2024.Models.ViewModels
{
    public class CategoriaViewModel
    {
        [Required]
        [Display(Name = "Categoria")]
        public string Nombre { get; set; }
        
    }

    public class EditCategoriaViewModel
    {
        public int CategoriaID { get; set; } 
        [Required]
        [Display(Name = "Categoria")]
        public string Nombre { get; set; }



    }
  }