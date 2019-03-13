using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BetaLabUnidad3.Models;
using BetaLabUnidad3.Singleton;

namespace BetaLabUnidad3.Controllers
{
    public class PedidosController : Controller
    {
        // GET: Pedidos
        public ActionResult Index()
        {
            return View();
        }

        // GET: Pedidos/Create
        public ActionResult CrearPedido()
        {
            return View();
        }

        // POST: Pedidos/Create
        [HttpPost]
        public ActionResult CrearPedido(Pedidos pedido)
        {
            try
            {
                //var Nuevo = new Pedidos();
                //Nuevo.ClientName = collection["ClientName"];
                //Nuevo.nit = collection["nit"];
                //Nuevo.direccion = collection["direccion"];

                if(string.IsNullOrEmpty(pedido.ClientName) || string.IsNullOrEmpty(pedido.direccion) || string.IsNullOrEmpty(pedido.nit))
                {
                    ViewBag.Error = "Se necesita llenar todos los campos vacios";
                    return View(pedido);
                }
                DataAlmacenada.Instancia.ListaPedidos.Add(pedido);
                return RedirectToAction("AgregarMed");
            }
            catch
            {
                return View();
            }
        }


        // GET: Pedidos/AgregarMed
        public ActionResult AgregarMed()
        {
            return View(DataAlmacenada.Instancia.ListaMed);
        }

        // POST: Pedidos/Create
        [HttpPost]
        public ActionResult AgregarMed(FormCollection collection)
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

        // GET: Pedidos/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Pedidos/Edit/5
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

        // GET: Pedidos/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Pedidos/Delete/5
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
