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
    public class UsuarioController : Controller
    {
        private UsuarioBL BL = new UsuarioBL();
        // GET: Usuario
        public ActionResult Index(string state)
        {
            return View(BL.UsuarioList(state));
        }

        // GET: Usuario/Details/5
        public ActionResult Details(int id)
        {
            return View(BL.FindUsuario(id));
        }

        // GET: Usuario/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Usuario/Create
        [HttpPost]
        public ActionResult Create(Usuario User)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    BL.InserUsuario(User);
                }
                return RedirectToAction("Index", "Usuario");
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // GET: Usuario/Edit/5
        public ActionResult Edit(int id)
        {
            return View(BL.FindUsuario(id));
        }

        // POST: Usuario/Edit/5
        [HttpPost]
        public ActionResult Edit(Usuario User)
        {
            try
            {
                // TODO: Add update logic here
                BL.UpdateUsuario(User);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Usuario/Delete/5
        public ActionResult Delete(int id)
        {
            return View(BL.FindUsuario(id));
        }

        // POST: Usuario/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                BL.DeleteUsuario(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }

        }
        //public ActionResult Login (string NombreUser, string Pass)
        //{
        //    var r = BL.ComprobarUser(NombreUser, Pass)
        //       if (r = 1)
        //    {
        //        Redirect("index", "Home");
        //    }
        //    else
        //    {
        //        ViewBag.Msg = "Datos incorrectos";
        //    }
        //    return View();
        //}
    }
}
