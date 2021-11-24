using PracticoA.Models;
using System;
using System.Collections.Generic;
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
            return View(db.Marca.ToList().OrderBy(m=>m.nombre));
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
                db.Marca.Add(marca);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return PartialView("_ModalMarca", marca);
        }
    }
}
