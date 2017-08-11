using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GameStore2.Models;
using System.IO;

namespace GameStore2.Controllers
{
    public class ProductosController : Controller
    {
        private GameStore2Entities2 db = new GameStore2Entities2();


        public ActionResult Index()
        {
            var producto = db.Producto.Include(p => p.Categoria);
            return View(producto.ToList().OrderBy(p => p.Nombre));
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Producto producto = db.Producto.Find(id);
            if (producto == null)
            {
                return HttpNotFound();
            }
            return View(producto);
        }

    
        public ActionResult Create()
        {
            ViewBag.CategoriaId = new SelectList(db.Categoria, "Id", "Genero");
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Producto producto, HttpPostedFileBase File)
        {
  

            if (File.ContentLength > 0)
            {
                var fileName = Path.GetFileName(File.FileName);
                var path = Path.Combine(Server.MapPath("~/Images/"), fileName);
                var path2 = "~" + "/Images/" + fileName;
                File.SaveAs(path);
                producto.Path = path2;
            }

           
            if (ModelState.IsValid)
            {
                db.Producto.Add(producto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoriaId = new SelectList(db.Categoria, "Id", "Genero", producto.CategoriaId);
            return View(producto);
        }

        public ActionResult Delete(int? id)
        {

            var item = db.Producto.Where(p => p.Id == id).First();
            db.Producto.Remove(item);
            db.SaveChanges();

            var Volver = db.Producto.ToList();
            return View("Index", Volver);
     
        }


        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Producto producto = db.Producto.Find(id);
            if (producto == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoriaId = new SelectList(db.Categoria, "Id", "Genero", producto.CategoriaId);
            return View(producto);


        }

 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( Producto producto, HttpPostedFileBase File)
        {
      
            if (ModelState.IsValid)
            {
                if (File.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(File.FileName);
                    var path = Path.Combine(Server.MapPath("~/Images/"), fileName);
                    var path2 = "~" + "/Images/" + fileName;
                    File.SaveAs(path);
                    producto.Path = path2;
                }else 
                {
                    producto.Path = producto.Path;
                }

                db.Entry(producto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoriaId = new SelectList(db.Categoria, "Id", "Genero", producto.CategoriaId);
            return View(producto);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Producto producto = db.Producto.Find(id);
            db.Producto.Remove(producto);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
