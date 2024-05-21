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
    public class CategoriaController : Controller
    {
        // GET: Categoria
        public ActionResult Index()
        {
            List<CategoriaTableNewModel> lst = null;
            using (BoutiqueMEEntities db = new BoutiqueMEEntities())
            {
                lst = (from d in db.Categoria
                       select new CategoriaTableNewModel
                       {
                           Nombre = d.Nombre,
                           CategoriaID=d.CategoriaID,

                       }).ToList();



            }
            return View(lst);
        }

        [HttpGet]
        public ActionResult Add()
        {

            return View();

        }

        public ActionResult Add(CategoriaViewModel model)
        {

            if (!ModelState.IsValid)
            {
                return View(model);

            }

            using (var db = new BoutiqueMEEntities())
            {
                Categoria oCat = new Categoria();
                oCat.Nombre = model.Nombre;

                db.Categoria.Add(oCat);
                db.SaveChanges();
            }

            return Redirect(Url.Content("~/Categoria/"));

        }


        public ActionResult Edit(int CategoriaID)
        {
            EditCategoriaViewModel model = new EditCategoriaViewModel();

            using (var db = new BoutiqueMEEntities())
            {
                var oCat = db.Categoria.Find(CategoriaID);

                if (oCat != null)
                {
                    model.Nombre = oCat.Nombre;
                    model.CategoriaID = oCat.CategoriaID;
                }
                else
                {
                    Console.Error.WriteLine("Se produjo un error: ");
                }
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(EditCategoriaViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            using (var db = new BoutiqueMEEntities())
            {
                var oUser = db.Categoria.Find(model.CategoriaID);

                if (oUser != null)
                {
                    oUser.Nombre = model.Nombre;
                    db.Entry(oUser).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
                else
                {
                    Console.Error.WriteLine("Se produjo un error: " );
                }
            }

            return Redirect(Url.Content("~/Categoria/"));
        }




        [HttpPost]
        public ActionResult Delete(int CategoriaID)
        {
            using (var db = new BoutiqueMEEntities())
            {
                var oUser = db.Categoria.Find(CategoriaID);
                if (oUser != null)
                {
                    db.Categoria.Remove(oUser);
                    db.SaveChanges();
                }
            }

            return Redirect(Url.Content("~/Categoria/"));
        }






    }



}
