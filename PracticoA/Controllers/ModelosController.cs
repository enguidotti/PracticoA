using PracticoA.Models;
using System;
using System.Collections.Generic;
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
    }
}