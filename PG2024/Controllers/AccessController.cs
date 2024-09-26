using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PG2024.Models;


namespace PG2024.Controllers
{
    public class AccessController : Controller
    {
        // GET: Access
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Enter(string user, string password)
        {
            try
            {
                using (BoutiqueMEEntities db = new BoutiqueMEEntities())
                {
                    var lst = from d in db.Usuario
                              where d.Nombre == user && d.Contraseña == password
                              select d;

                    if (lst.Any())
                    {
                        // Obtenemos el primer usuario que cumple con las condiciones
                        Usuario oUser = lst.First();

                        // Guardamos el usuario en la sesión
                        Session["User"] = oUser;

                        // Obtenemos el rol del usuario desde TipoUsuario
                        var userRole = (from r in db.TipoUsuario
                                        where r.TipoUsuarioID == oUser.TipoUsuarioID
                                        select r.Tipo).FirstOrDefault();

                        // Guardamos el rol del usuario en la sesión
                        Session["UserRole"] = userRole;  // Guardar el rol

                        return Content("1");  // Inicia sesión correctamente
                    }
                    else
                    {
                        return Content("Usuario Inválido");
                    }
                }
            }
            catch (Exception ex)
            {
                return Content("No se puede iniciar sesión: " + ex.Message);
            }
        }
    }
}
