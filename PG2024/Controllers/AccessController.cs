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
                    if(lst.Count()>0)
                    {
                        Usuario oUser = lst.First();
                        Session["User"] = oUser;
                        return Content("1");
                    }
                    else
                    {
                        return Content("Usuario Invalido");
                    }

                }
            }
            catch(Exception ex)
            {
                return Content("No se puede inciar sesion"+ex.Message);
            }

        }


       
    }
}