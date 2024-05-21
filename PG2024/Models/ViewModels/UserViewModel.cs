using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PG2024.Models.ViewModels
{
    public class UserViewModel
    {

        [Required]
        [Display(Name ="Usuario")]
        public string Nombre { get; set; }


        [Required]
        [Display(Name = "Contraseña")]
        [DataType(DataType.Password)]
        public string Contraseña { get; set; }


        
        [Display(Name = "Confirmar Contraseña")]
        [DataType(DataType.Password)]
        [Compare("Contraseña", ErrorMessage = "Las contraseñas no son iguales")]
        public string ConfirmarContraseña { get; set; }
       
        [Required]
        [Display(Name = "Tipo Usuario")]
        public int TipoUsuarioID { get; set; }
        [Required]
        [Display(Name = "Tienda")]
        public int TiendaID { get; set; }
    }



    public class EditUserViewModel
    {
        public int UsuarioID { get; set; }

        [Required]
        [Display(Name = "Usuario")]
        public string Nombre { get; set; }


       
        [Display(Name = "Contraseña")]
        [DataType(DataType.Password)]
        public string Contraseña { get; set; }



        [Display(Name = "Confirmar Contraseña")]
        [DataType(DataType.Password)]
        [Compare("Contraseña", ErrorMessage = "Las contraseñas no son iguales")]
        public string ConfirmarContraseña { get; set; }

        [Required]
        [Display(Name = "Tipo Usuario")]
        public int TipoUsuarioID { get; set; }
        [Required]
        [Display(Name = "Tienda")]
        public int TiendaID { get; set; }
    }
}