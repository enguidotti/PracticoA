using PracticoA.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PracticoA.Controllers
{
    public class MarcasController : Controller
    {
        private practico1Entities db = new practico1Entities();
        // GET: Marcas
        public ActionResult Index()
        {
            return View(db.Marca.ToList().OrderBy(m => m.nombre));
        }
        public ActionResult ModalMarca()
        {
            return PartialView("_ModalMarca");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ModalMarca(Marca marca)
        {
            if (ModelState.IsValid)
            {
                var verifica = db.Marca.FirstOrDefault(m => m.nombre == marca.nombre);
                if (verifica == null)
                {
                    db.Marca.Add(marca);
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }
        public ActionResult Edit(int? id)
        {
            if (id != null)
            {
                Marca marca = db.Marca.Find(id);
                return PartialView("_Edit", marca);
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult Edit(Marca marca)
        {
            var verifica = db.Marca.FirstOrDefault(m => m.nombre == marca.nombre);
            if (verifica == null)
            {
                db.Entry(marca).State = EntityState.Modified;
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int? id)
        {
            if(id != null)
            {
                Marca marca = db.Marca.Find(id);
                db.Marca.Remove(marca);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
