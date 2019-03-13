using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BetaLabUnidad3.Singleton;
using BetaLabUnidad3.Models;

namespace BetaLabUnidad3.Controllers
{
    public class MedController : Controller
    {
        // GET: Med
        public ActionResult Index()
        {
            DataAlmacenada.Instancia.LecturaArchivo();
            return View(DataAlmacenada.Instancia.ListaMed); //Cargamos la lista 
        }


        // GET: Med/Create
        public ActionResult Create()
        {
            return RedirectToAction("CrearPedido", "Pedidos");
        }

        // POST: Med/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                return RedirectToAction("CrearPedido", "Pedidos");
            }
            catch
            {
                return View();
            }
        }

        // GET: Med/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }


    }
}
