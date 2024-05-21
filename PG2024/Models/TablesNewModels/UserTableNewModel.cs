using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PG2024.Models.TablesNewModels
{
    public class UserTableNewModel
    {
        public int UsuarioID { get; set; }
        public string Nombre { get; set; }
        public int? TipoUsuarioID { get; set; }
        
        public string TipoUsuario { get; set; }

        public int? TiendaID { get; set; }
     
        public string NombreTienda { get; set; }




    }
}