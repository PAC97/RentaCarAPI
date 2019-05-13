using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RentaCars.EN;
using RentaCars.BL;

namespace RentaCarsWEB.Controllers
{
    public class RentaController : Controller
    {
        private RentaBL rbl = new RentaBL();
        // GET: Renta
        public ActionResult Index(string state)
        {
            return View(rbl.ListRenta(state));
        }

        // GET: Renta/Details/5
        public ActionResult Details(int id)
        {
            return View(rbl.findRenta(id));
        }

        // GET: Renta/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Renta/Create
        [HttpPost]
        public ActionResult Create(Renta renta)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    rbl.agregarrenta(renta);
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // GET: Renta/Edit/5
        public ActionResult Edit(int id)
        {
            return View(rbl.findRenta(id));
        }

        // POST: Renta/Edit/5
        [HttpPost]
        public ActionResult Edit(Renta renta)
        {
            try
            {
                // TODO: Add update logic here
                rbl.ModificarRenta(renta);
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                return View();
            }
        }

        // GET: Renta/Delete/5
        public ActionResult Delete(int id)
        {
            return View(rbl.findRenta(id));
        }

        // POST: Renta/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                rbl.DeleteRenta(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
