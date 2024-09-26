﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PG2024.Models;
using PG2024.Controllers;
using PG2024.Models.TablesNewModels;
using PG2024.Models.ViewModels;

namespace PG2024.Controllers
{
   
    public class InventarioController : Controller
    {
       
        // GET: Inventario
        public ActionResult Index()
        {
            List<InventarioTableNewModel> inventario = new List<InventarioTableNewModel>();

            using (BoutiqueMEEntities db = new BoutiqueMEEntities())
            {
                inventario = (from inv in db.Inventario
                              join prod in db.Producto on inv.ProductoID equals prod.ProductoID
                              join tienda in db.Tienda on inv.TiendaID equals tienda.TiendaID
                              select new InventarioTableNewModel
                              {
                                  InventarioID = inv.InventarioID,
                                  ProductoID = (int)inv.ProductoID,
                                  NombreProducto = prod.Nombre,
                                  TiendaID = (int)inv.TiendaID,
                                  NombreTienda = tienda.Nombre,
                                  Cantidad = (int)inv.Cantidad,
                                  Precio = (decimal)prod.Precio

                              }).ToList();
            }

            return View(inventario);
        }


        [HttpGet]
        public ActionResult Add()
        {
            var model = new AddInventarioViewModel
            {
                Productos = GetProductos(), 
                Tiendas = GetTiendas()  
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult Add(AddInventarioViewModel model)
        {
            if (ModelState.IsValid)
            {
                
                using (var db = new BoutiqueMEEntities())
                {
                    Inventario inventario = new Inventario
                    {
                        ProductoID = model.ProductoID,
                        TiendaID = model.TiendaID,
                        Cantidad = model.Cantidad
                    };

                    db.Inventario.Add(inventario);
                    db.SaveChanges();
                }

                return Redirect(Url.Content("~/Inventario/"));
            }

           
            model.Productos = GetProductos();
            model.Tiendas = GetTiendas();

            return View(model);
        }

        public ActionResult Edit(int InventarioID)
        {
            EditInventarioViewModel model = new EditInventarioViewModel();

            using (var db = new BoutiqueMEEntities())
            {
                var oUser = db.Inventario.Find(InventarioID);

             
                model.ProductoID = (int)oUser.ProductoID;
                model.Productos = GetProductos();
                model.TiendaID =(int) oUser.TiendaID;
                model.Tiendas = GetTiendas();
                model.Cantidad = (int)oUser.Cantidad;
              

              
            }

            return View(model);
        }





        [HttpPost]
        public ActionResult Edit(EditInventarioViewModel model)
        {
            if (!ModelState.IsValid)
            {
            
                model.Productos = GetProductos();
                model.Tiendas = GetTiendas();
                return View(model);
            }

            using (var db = new BoutiqueMEEntities())
            {
                var oUser = db.Inventario.Find(model.InventarioID);
                oUser.ProductoID = model.ProductoID;
                oUser.TiendaID = model.TiendaID;
                oUser.Cantidad = model.Cantidad;
               



                db.Entry(oUser).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }


            return Redirect(Url.Content("~/Inventario/"));
        }


        [HttpGet]
        public ActionResult AddUnits(int ProductoID, int TiendaID)
        {
            AddInventarioViewModel model = new AddInventarioViewModel
            {
                ProductoID = ProductoID,
                TiendaID = TiendaID,
                Productos = GetProductos(),
                Tiendas = GetTiendas(),
                Cantidad = 0 // Inicialmente vacío para que el usuario ingrese la cantidad
            };

            return View("AddUnits", model); // Reutilizamos la vista "Add" para aprovechar la estructura del formulario
        }

        [HttpPost]
        public ActionResult AddUnits(AddInventarioViewModel model)
        {
            if (ModelState.IsValid)
            {
                using (var db = new BoutiqueMEEntities())
                {
                  
                    var inventarioExistente = db.Inventario
                        .FirstOrDefault(inv => inv.ProductoID == model.ProductoID && inv.TiendaID == model.TiendaID);

                    if (inventarioExistente != null)
                    {
                    
                        inventarioExistente.Cantidad += model.Cantidad;

                        db.Entry(inventarioExistente).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                    }
                    else
                    {
                        ModelState.AddModelError("", "No se encontró el inventario para este producto y tienda.");
                    }
                }

                return Redirect(Url.Content("~/Inventario/"));
            }

          
            model.Productos = GetProductos();
            model.Tiendas = GetTiendas();

            return View("AddUnits", model);
        }





        [HttpPost]
        public ActionResult Delete(int InventarioID)
        {
            using (var db = new BoutiqueMEEntities())
            {
                var inventario = db.Inventario.Find(InventarioID);
                if (inventario != null)
                {
                    db.Inventario.Remove(inventario);
                    db.SaveChanges();
                }
            }

            return Redirect(Url.Content("~/Inventario/"));
        }





        private List<SelectListItem> GetProductos()
        {
            using (var db = new BoutiqueMEEntities())
            {
                return db.Producto.Select(p => new SelectListItem
                {
                    Value = p.ProductoID.ToString(),
                    Text = p.Nombre
                }).ToList();
            }
        }

        private List<SelectListItem> GetTiendas()
        {
            using (var db = new BoutiqueMEEntities())
            {
                return db.Tienda.Select(t => new SelectListItem
                {
                    Value = t.TiendaID.ToString(),
                    Text = t.Nombre
                }).ToList();
            }
        }
    }






   














    /*  [HttpGet]
      public ActionResult Add()
      {


          return View();

      }


      [HttpPost]
      public ActionResult Add(InventarioViewModel model)
      {
          if (!ModelState.IsValid)
          {

              return View(model);
          }

          using (var db = new BoutiqueMEEntities())
          {
              Inventario inventario  = new Inventario();
              inventario.ProductoID = model.ProductoID;
              inventario.TiendaID = model.TiendaID;
              inventario.Cantidad = model.Cantidad;


              db.Inventario.Add(inventario);
              db.SaveChanges();
          }

          return Redirect(Url.Content("~/Inventario/"));
      }*/
    /*
    public ActionResult Edit(int InventarioID)
        {
            EditInventarioViewModel model = new EditInventarioViewModel();

            using (var db = new BoutiqueMEEntities())
            {
                var oUser = db.Inventario.Find(InventarioID);

                model.ProductoID =(int) oUser.ProductoID;
                model.TiendaID = (int)oUser.TiendaID;
                model.Cantidad = (int)oUser.Cantidad;
              

            }

            return View(model);
        }




        [HttpPost]
        public ActionResult Edit(EditInventarioViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            using (var db = new BoutiqueMEEntities())
            {
                var oUser = db.Inventario.Find(model.InventarioID);
                oUser.ProductoID = model.ProductoID;
                oUser.TiendaID = model.TiendaID;
                oUser.Cantidad = model.Cantidad;



                db.Entry(oUser).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }


            return Redirect(Url.Content("~/Inventario/"));
        }





       









       /* private List<SelectListItem> ObtenerProductos()
        {
            using (var db = new BoutiqueMEEntities())
            {
                var productos = db.Producto.Select(c => new SelectListItem
                {
                    Value = c.ProductoID.ToString(),
                    Text = c.Nombre
                }).ToList();

                return productos;
            }
        }

        // Método privado para obtener las categorías disponibles
        private List<SelectListItem> ObtenerTiendas()
        {
            using (var db = new BoutiqueMEEntities())
            {
                return db.Tienda.Select(c => new SelectListItem
                {
                    Value = c.TiendaID.ToString(),
                    Text = c.Nombre
                    
                    
                }).ToList();
            }
        }
       */











}





