using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GameStore2.Models;
namespace GameStore2.Controllers
{
    public class ProductoController : Controller
    {
        private GameStore2Entities2 db = new GameStore2Entities2();

 

        public ActionResult Index(string searchString)
        {
            //Barra De Busqueda 
            var producto = from p in db.Producto
                           select p;

            if (!string.IsNullOrEmpty(searchString))
            {
                producto = producto.Where(p => p.Nombre.Contains(searchString));
            }

            return View(producto.ToList().OrderBy(x => x.Nombre));
        }
    }
}