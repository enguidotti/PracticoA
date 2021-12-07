using PracticoA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PracticoA.Controllers
{
    public class AutosController : Controller
    {
        private practico1Entities db = new practico1Entities();
        // GET: Autos
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Create()
        {
            ViewBag.id_marca = new SelectList(db.Marca.OrderBy(m=>m.nombre), "id_marca", "nombre");
            return View();
        }
    }
}