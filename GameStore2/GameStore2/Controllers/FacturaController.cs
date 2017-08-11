using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GameStore2.Models;

namespace GameStore2.Controllers
{
    public class FacturaController : Controller
    {
        private GameStore2Entities2 db = new GameStore2Entities2();

        // GET: Factura
        public ActionResult Index(int id)
        {
            //try
            //{
                var venta = db.Venta.Where(v => v.Id == id).FirstOrDefault();
                var listaVenta = db.ListaVenta.Where(lv => lv.VentaId == id).ToList();

                var detalleFactura = new ViewModelListaVentas_Ventas();

                detalleFactura.viewModelVenta = venta;

            foreach (var item in listaVenta)
            {
                detalleFactura.viewModelListaVenta.Add(new ListaVenta { Cantidad = item.Cantidad, Id = item.Id, ProductoId = item.ProductoId, Total = item.Total, VentaId = item.VentaId });
            }
            return View(detalleFactura);
            }
            //catch (Exception )
            //{
            //    return View();
            //}

            
        }
    }
