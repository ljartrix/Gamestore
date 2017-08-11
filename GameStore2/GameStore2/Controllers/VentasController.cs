using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GameStore2.Models;
using System.Net;

namespace GameStore2.Controllers
{
    public class VentasController : Controller
    {

        private GameStore2Entities2 db = new GameStore2Entities2();
        // GET: Ventas
        public ActionResult Index()
        {
            return View(db.Venta.ToList());
        }


        public ActionResult ListaVentas(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
      
            return View(db.ListaVenta.Where(a=> a.VentaId == id));

        }
    }
}