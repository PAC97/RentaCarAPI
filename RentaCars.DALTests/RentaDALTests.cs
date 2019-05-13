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
    public class RentaDALTests
    {
        RentaDAL rDAL = new RentaDAL();
        [TestMethod()]
        public void agregarrentaTest()
        {
            Renta renta = new Renta { UsuarioID = 1, ReservaID = 2, EstadoID = 1 };
            int r = rDAL.agregarrenta(renta);
            List<Renta> rentas = rDAL.ListRenta("Activo");
            Renta re = rentas.OrderByDescending(rr => rr.RentaID).FirstOrDefault();
            Assert.IsTrue(r > 0 && renta.UsuarioID == re.UsuarioID && renta.ReservaID == re.ReservaID && renta.EstadoID == re.EstadoID);
        }

        [TestMethod()]
        public void ListRentaTest()
        {
            List<Renta> rentas = rDAL.ListRenta("Activo");
            Console.WriteLine("Datos encontrados en la base de datos {0}", rentas.Count);
            Assert.IsTrue(rentas.Count > 0);
        }

        [TestMethod()]
        public void ModificarRentaTest()
        {
            rDAL.agregarrenta(new Renta { UsuarioID = 1, ReservaID = 2, EstadoID = 1 });
            List<Renta> rentas = rDAL.ListRenta("Activo");
            Renta renta = rentas.OrderByDescending(rr => rr.RentaID).FirstOrDefault();
            renta.ReservaID = 3;
            int r = rDAL.ModificarRenta(renta);
            Assert.IsTrue(r > 0);
        }

        [TestMethod()]
        public void DeleteRentaTest()
        {
            List<Renta> rentas = rDAL.ListRenta("Activo");
            Renta renta = rentas.OrderByDescending(rr => rr.RentaID).FirstOrDefault();
            int r = rDAL.DeleteRenta(renta.RentaID);
            Assert.IsTrue(r > 0);
        }

        [TestMethod()]
        public void findrentaTest()
        {
            rDAL.agregarrenta(new Renta { UsuarioID = 1, ReservaID = 2, EstadoID = 1 });
            List<Renta> rentas = rDAL.ListRenta("Activo");
            Renta renta = rentas.OrderByDescending(rr => rr.RentaID).FirstOrDefault();
            Renta re = rDAL.findrenta(renta.RentaID);
            Assert.IsTrue(renta.UsuarioID == re.UsuarioID && renta.ReservaID == re.ReservaID && renta.EstadoID == re.EstadoID);
        }
    }
}