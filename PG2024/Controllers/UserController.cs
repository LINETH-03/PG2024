using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PG2024.Models;
using PG2024.Controllers;
using PG2024.Models.TablesNewModels;
using PG2024.Models.ViewModels;

namespace PG2024.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            List<UserTableNewModel> lst = null;
            using (BoutiqueMEEntities db = new BoutiqueMEEntities())
            {
                lst = (from u in db.Usuario
                       join t in db.TipoUsuario on u.TipoUsuarioID equals t.TipoUsuarioID
                       join ti in db.Tienda on u.TiendaID equals ti.TiendaID
                       select new UserTableNewModel
                       {
                           UsuarioID = u.UsuarioID,
                           Nombre = u.Nombre,
                           TipoUsuarioID = u.TipoUsuarioID,
                           TipoUsuario = t.Tipo,
                           TiendaID = u.TiendaID,
                           NombreTienda = ti.Nombre
                       }).ToList();
            }

            return View(lst);
        }

        [HttpGet]
        public ActionResult Add()
        {

            return View();

        }
        [HttpPost]
        public ActionResult Add(UserViewModel model)
        {

            if (!ModelState.IsValid)
            {
                return View(model);

            }

            using (var db = new BoutiqueMEEntities())
            {
                Usuario oUser = new Usuario();
                oUser.Nombre = model.Nombre;
                oUser.Contraseña = model.Contraseña;
                oUser.TipoUsuarioID = model.TipoUsuarioID;
                oUser.TiendaID = model.TiendaID;
                db.Usuario.Add(oUser);
                db.SaveChanges();
            }

            return Redirect(Url.Content("~/User/"));

        }



        public ActionResult Edit(int UsuarioID)
        {
            EditUserViewModel model = new EditUserViewModel();

            using (var db = new BoutiqueMEEntities())
            {
                var oUser = db.Usuario.Find(UsuarioID);

                model.Nombre = oUser.Nombre;
                model.TipoUsuarioID = (int)oUser.TipoUsuarioID;
                model.TiendaID = (int)oUser.TiendaID;
                model.UsuarioID = oUser.UsuarioID;





            }

            return View(model);
        }




        [HttpPost]
        public ActionResult Edit(EditUserViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            using (var db = new BoutiqueMEEntities())
            {
                var oUser = db.Usuario.Find(model.UsuarioID);
                oUser.Nombre = model.Nombre;
                oUser.TipoUsuarioID = model.TipoUsuarioID;
                oUser.TiendaID = model.TiendaID;
                oUser.UsuarioID = model.UsuarioID;

                // Verifica si se proporcionó una nueva contraseña
                if (!string.IsNullOrEmpty(model.Contraseña))
                {
                    oUser.Contraseña = model.Contraseña;
                }

                db.Entry(oUser).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }


            return Redirect(Url.Content("~/User/"));
        }



        [HttpPost]
        public ActionResult Delete(int UsuarioID)
        {
            using (var db = new BoutiqueMEEntities())
            {
                var oUser = db.Usuario.Find(UsuarioID);
                if (oUser != null)
                {
                    db.Usuario.Remove(oUser);
                    db.SaveChanges();
                }
            }

            return Redirect(Url.Content("~/User/"));
        }






    }
}



