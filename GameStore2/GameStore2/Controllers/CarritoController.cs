using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GameStore2.Models;
using System.Net;

namespace GameStore2.Controllers
{
    public class CarritoController : Controller
    {
        private GameStore2Entities2 db = new GameStore2Entities2();
        public ActionResult AgregarCarrito(int id)
        {
            if (Session["Carrito"] == null)
            {
                List<CarritoItems> Compras = new List<CarritoItems>();
                Compras.Add(new CarritoItems(db.Producto.Find(id), 1));
                Session["Carrito"] = Compras;

            }
            else {

                List<CarritoItems> Compras = (List<CarritoItems>)Session["Carrito"];
                int ProductoExistente = getIndex(id);
                if (ProductoExistente == -1)
                    Compras.Add(new CarritoItems(db.Producto.Find(id), 1));
                else
                    Compras[ProductoExistente].Cantidad++;
                Session["Carrito"] = Compras;
            }
            return View();
        }

        //Accion Eliminar 

            public ActionResult Delete (int id)
        {
            List<CarritoItems> Compras = (List<CarritoItems>)Session["Carrito"];
            Compras.RemoveAt(getIndex(id));
            return View("AgregarCarrito");
        }

        
        public ActionResult ConfirmarCompra()
        {
            List<CarritoItems> Compras = (List<CarritoItems>)Session["Carrito"];
            if (Compras != null && Compras.Count > 0)
            {
                Venta NuevaVenta = new Venta();
                NuevaVenta.DiaVenta = DateTime.Now;
                NuevaVenta.Subtotal = Compras.Sum(x => x.Producto.Precio * x.Cantidad);
                NuevaVenta.Itebis = NuevaVenta.Subtotal * 0.16;
                NuevaVenta.Total = NuevaVenta.Subtotal + NuevaVenta.Itebis;

                NuevaVenta.ListaVenta = (from item in Compras
                                         select new ListaVenta
                                         {
                                             Cantidad = item.Cantidad,
                                             ProductoId = item.Producto.Id,
                                             Total = ((double)item.Producto.Precio * item.Cantidad)
                                         }).ToList();

                db.Venta.Add(NuevaVenta);
                db.SaveChanges();

                ViewBag.venta = NuevaVenta.Id;

            }
            return View();

        }

        private int getIndex(int id)
        {
       
            List<CarritoItems> Compras = (List<CarritoItems>)Session["Carrito"];

            for (int i = 0; i < Compras.Count; i++)
            {

                if (Compras[i].Producto.Id == id)
                    return i;
            }
            return -1;
        }
    }

    



}