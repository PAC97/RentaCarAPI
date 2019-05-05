using Microsoft.VisualStudio.TestTools.UnitTesting;
using RentaCars.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentaCars.EN;

namespace RentaCars.DAL.Tests
{
    [TestClass()]
    public class EstadoDALTests
    {
        EstadoDAL EDAL = new EstadoDAL();
        [TestMethod()]
        public void AddEstadoTest()
        {
            Estado es = new Estado { Nombre = "Pendiente" };
            int r = EDAL.AddEstado(es);
            List<Estado> estados = EDAL.StateList();
            Estado es1 = estados.OrderByDescending(s => s.EstadoID).FirstOrDefault();
            Assert.IsTrue(r > 0 && es.Nombre == es1.Nombre);
        }

        [TestMethod()]
        public void StateListTest()
        {
            EDAL.AddEstado(new Estado { Nombre = "Aprobado" });
            List<Estado> estados = EDAL.StateList();
            Console.WriteLine("Datos encontrados en la base de datos {0}", estados.Count);
            Assert.IsTrue(estados.Count > 0);
        }

        [TestMethod()]
        public void UpdateStateTest()
        {
            EDAL.AddEstado(new Estado { Nombre = "Aprobado" });
            List<Estado> estados = EDAL.StateList();
            Estado es = estados.OrderByDescending(s => s.EstadoID).FirstOrDefault();
            es.Nombre = "Si aprobado";
            int r = EDAL.UpdateState(es);
            Assert.IsTrue(r > 0);
        }

        [TestMethod()]
        public void FindStateTest()
        {
            EDAL.AddEstado(new Estado { Nombre = "Rquerido" });
            List<Estado> estados = EDAL.StateList();
            Estado es = estados.OrderByDescending(s => s.EstadoID).FirstOrDefault();
            Estado esID = EDAL.FindState(es.EstadoID);
            Assert.IsTrue(esID.EstadoID > 0 && es.Nombre == esID.Nombre);
        }
    }
}