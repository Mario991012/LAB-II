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
            return View(DataAlmacenada.Instancia.ListaMed); //Cargamos la lista 
        }

        // GET: Med/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Med/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Med/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
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

        // POST: Med/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Med/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Med/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
