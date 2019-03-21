
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RentaCars.BL;
using RentaCars.EN;

namespace RentaCarsWEB.Controllers
{
    public class VehiculoController : Controller
    {
        VehiculoBL BL = new VehiculoBL();
        // GET: Vehiculo
        public ActionResult Index(string state)
        {
            return View(BL.VehiculoList(state));
        }
        //GET:Vehiculo cards
        public ActionResult VehiculosCard(string state)
        {
            return View(BL.VehiculoList(state));
        }
        // GET: Vehiculo/Details/5
        public ActionResult Details(int id)
        {
            return View(BL.FindVehiculo(id));
        }

        // GET: Vehiculo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Vehiculo/Create
        [HttpPost]
        public ActionResult Create(Vehiculo cat, string avatarCropped)
        {
            try
            {
                cat.imagen = avatarCropped;
                cat.EstadoID = 1;
                // TODO: Add insert logic here
                if (cat != null)
                {

                    BL.InserVehiculo(cat);
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // GET: Vehiculo/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Vehiculo/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Vehiculo car)
        {
            try
            {
                // TODO: Add update logic here
                BL.UpdateVehiculo(car);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Vehiculo/Delete/5
        public ActionResult Delete(int id)
        {
            return View(BL.FindVehiculo(id));
        }

        // POST: Vehiculo/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                BL.DeleteVehiculo(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}