using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//Agregar
using RentaCars.EN;
using RentaCars.BL;

namespace RentaCars.WEB.Controllers
{
    public class Tipo_UsuarioController : Controller
    {
        private Tipo_UsuarioBL BL = new Tipo_UsuarioBL();
        // GET: Tipo_Usuario
        public ActionResult Index(string state)
        {
            ViewBag.Activo = String.IsNullOrEmpty(state) ? "Activo" : "";
            ViewBag.Inactivo = string.IsNullOrEmpty(state) ? "Inactivo" : "";
            return View(BL.Tipo_UsuarioList(state));
        }

        // GET: Tipo_Usuario/Details/5
        public ActionResult Details(int id)
        {
            return View(BL.FindTipo_Usuario(id));
        }

        // GET: Tipo_Usuario/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tipo_Usuario/Create
        [HttpPost]
        public ActionResult Create(TipoUsuario tipo)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    BL.InserTipo_Usuario(tipo);
                }
                return RedirectToAction("Index", "Tipo_Usuario");
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // GET: Tipo_Usuario/Edit/5
        public ActionResult Edit(int id)
        {
            return View(BL.FindTipo_Usuario(id));
        }

        // POST: Tipo_Usuario/Edit/5
        [HttpPost]
        public ActionResult Edit(TipoUsuario tipo)
        {
            try
            {
                // TODO: Add update logic here
                BL.UpdateTipo_Usuario(tipo);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Tipo_Usuario/Delete/5
        public ActionResult Delete(int id)
        {
            return View(BL.FindTipo_Usuario(id));
        }

        // POST: Tipo_Usuario/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                BL.DeleteTipo_Usuario(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult CerrarCesion()
        {
            Session.Clear();
            return RedirectToAction()
        }
    }
}
