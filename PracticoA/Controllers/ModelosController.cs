using PracticoA.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PracticoA.Controllers
{
    public class ModelosController : Controller
    {
        private practico1Entities db = new practico1Entities();
        // GET: Modelos
        public ActionResult Index()
        {
            return View(db.Modelo.ToList());
        }
        public ActionResult ModalModelo(int? id)
        {
            //si id distinto de nulo
            if (id != null)
            {
                //verifica los datos con id
                Modelo modelo = db.Modelo.Find(id);
                //select o ddl trae la marca seleccionada
                ViewBag.id_marca = new SelectList(db.Marca, "id_marca", "nombre", modelo.id_marca);
                //devolvemos la vista parcial cargada con los datos correspondientes
                return PartialView("_ModalModelo", modelo);
            }
            ViewBag.id_marca = new SelectList(db.Marca, "id_marca", "nombre");
            //retorno la vista sin datos para la creación 
            return PartialView("_ModalModelo");
        }
        [HttpPost]
        public ActionResult SaveModelo(Modelo modelo)
        {
            //si no trae id se agrega uno nuevo
            if (modelo.id_modelo == 0)
                db.Modelo.Add(modelo);
            //si trae id se modifica
            else
                db.Entry(modelo).State = EntityState.Modified;

            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult Delete(int? id)
        {
            if (id != null)
            {
                Modelo modelo = db.Modelo.Find(id);
                db.Modelo.Remove(modelo);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public JsonResult GetModeloByMarca(int? id)
        {
            if (id != null)
            {
                var modelo = (from m in db.Modelo
                              where m.id_marca == id
                              select new
                              {
                                  m.id_modelo,
                                  m.modelo1
                              });
                return Json(modelo.ToList(), JsonRequestBehavior.AllowGet);
            }
            return Json("");
        }
    }
}