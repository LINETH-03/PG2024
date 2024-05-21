using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PG2024.Models;
using PG2024.Controllers;
using PG2024.Models.TablesNewModels;
using PG2024.Models.ViewModels;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;

namespace PG2024.Controllers
{
    public class ProductoController : Controller
    {
        // GET: Producto
        public ActionResult Index()
        {
            List<ProductoTablaNewModel> lst = null;
            using (BoutiqueMEEntities db = new BoutiqueMEEntities())
            {
                lst = (from p in db.Producto
                       join c in db.Categoria on p.CategoriaID equals c.CategoriaID
                       select new ProductoTablaNewModel
                       {
                           ProductoID = p.ProductoID,
                           CodigoBarra = p.CodigoBarra,
                           Nombre = p.Nombre,
                           Precio = (decimal)p.Precio,
                           CategoriaID = (int)p.CategoriaID,
                           NombreCategoria = c.Nombre 
                       }).ToList();
            }
            return View(lst);
        }


        [HttpGet]
        public ActionResult Add()
        {
            
            ViewBag.Categorias = ObtenerCategorias();
            return View();
        }

        [HttpPost]
        public ActionResult Add(ProductoViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Categorias = ObtenerCategorias();
                return View(model);
            }

            using (var db = new BoutiqueMEEntities())
            {
                Producto producto = new Producto();
                producto.CodigoBarra = model.CodigoBarra;
                producto.Nombre = model.Nombre;
                producto.Precio = model.Precio;
                producto.CategoriaID = model.CategoriaID;

                db.Producto.Add(producto);
                db.SaveChanges();
            }

            return Redirect(Url.Content("~/Producto/"));
        }

        public ActionResult Edit(int ProductoID)
        {
            EditProductoViewModel model = new EditProductoViewModel();

            using (var db = new BoutiqueMEEntities())
            {
                var oUser = db.Producto.Find(ProductoID);

                model.CodigoBarra = oUser.CodigoBarra;
                model.Nombre = oUser.Nombre;
                model.Precio = (int)oUser.Precio;
                model.CategoriaID = oUser.CategoriaID;

                ViewBag.Categorias = ObtenerCategorias(); 
            }

            return View(model);
        }





        [HttpPost]
        public ActionResult Edit(EditProductoViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            using (var db = new BoutiqueMEEntities())
            {
                var oUser = db.Producto.Find(model.ProductoID);
                oUser.CodigoBarra = model.CodigoBarra;
                oUser.Nombre = model.Nombre;
                oUser.Precio = model.Precio;
                oUser.CategoriaID = model.CategoriaID;
           

         
                db.Entry(oUser).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }


            return Redirect(Url.Content("~/Producto/"));
             }





     
        [HttpPost]
        public ActionResult Delete(int ProductoID)
        {
            using (var db = new BoutiqueMEEntities())
            {
                try
                {
                    var producto = db.Producto.Find(ProductoID);
                    if (producto != null)
                    {
                        db.Producto.Remove(producto);
                        db.SaveChanges();
                    }
                    return Redirect(Url.Content("~/Producto/"));
                }
                catch (DbUpdateException ex)
                {
                    if (ex.InnerException is SqlException sqlEx && sqlEx.Message.Contains("FK__Inventari__Produ__2DE6D218"))
                    {
                        // Mostrar un mensaje de alerta al usuario
                        TempData["ErrorMessage"] = "No se puede eliminar el producto porque existen registros en el inventario que dependen de él.";
                    }
                    else
                    {
                        // Otro tipo de error, puedes manejarlo según tus necesidades
                        TempData["ErrorMessage"] = "Ocurrió un error al intentar eliminar el producto.";
                    }
                    return Redirect(Url.Content("~/Producto/"));
                }
            }
        }

        // Método privado para obtener las categorías disponibles
        private List<SelectListItem> ObtenerCategorias()
        {
            using (var db = new BoutiqueMEEntities())
            {
                return db.Categoria.Select(c => new SelectListItem
                {
                    Value = c.CategoriaID.ToString(),
                    Text = c.Nombre
                }).ToList();
            }
        }
    





}
}