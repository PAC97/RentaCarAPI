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
    public class ReservaDALTests
    {
        ReservaDAL rDAL = new ReservaDAL();
        [TestMethod()]
        public void AddReservaTest()
        {
            Reserva reserva = new Reserva { VehiculoID = 2, FechaEn = Convert.ToDateTime("2019/05/06"), FechaDev = Convert.ToDateTime("2019/05/06"), HoraDev = ("8:00"), EstadoID = 1 };
            int r = rDAL.AddReserva(reserva);
            List<Reserva> reservas = rDAL.ReservaList("Activo");
            Reserva re = reservas.OrderByDescending(rr => rr.ReservaID).FirstOrDefault();
            Assert.IsTrue(r > 0 && reserva.VehiculoID == re.VehiculoID && reserva.FechaEn == re.FechaEn && reserva.FechaDev == re.FechaDev && reserva.HoraDev == re.HoraDev && reserva.EstadoID == re.EstadoID);
        }

        [TestMethod()]
        public void ReservaListTest()
        {
            List<Reserva> reservas = rDAL.ReservaList("Activo");
            Console.WriteLine("Datos encontrados en la base de datos {0}", reservas.Count);
            Assert.IsTrue(reservas.Count > 0);
        }

        [TestMethod()]
        public void UpdateReservaTest()
        {
            List<Reserva> reservas = rDAL.ReservaList("Activo");
            Reserva reserva = reservas.OrderByDescending(rr => rr.ReservaID).FirstOrDefault();
            reserva.HoraDev = "22:00";
            int r = rDAL.UpdateReserva(reserva);
            Assert.IsTrue(r > 0);
        }

        [TestMethod()]
        public void DeleteReservaTest()
        {
            List<Reserva> reservas = rDAL.ReservaList("Activo");
            Reserva reserva = reservas.OrderByDescending(rr => rr.ReservaID).FirstOrDefault();
            int r = rDAL.DeleteReserva(reserva.ReservaID);
            Assert.IsTrue(r > 0);
        }

        [TestMethod()]
        public void FindReservaTest()
        {
            rDAL.AddReserva(new Reserva { VehiculoID = 2, FechaEn = Convert.ToDateTime("2019/05/06"), FechaDev = Convert.ToDateTime("2019/05/06"), HoraDev = ("8:00"), EstadoID = 1 });
            List<Reserva> reservas = rDAL.ReservaList("Activo");
            Reserva reserva = reservas.OrderByDescending(rr => rr.ReservaID).FirstOrDefault();
            Reserva re = rDAL.FindReserva(reserva.ReservaID);
            Assert.IsTrue(re.ReservaID > 0 && reserva.VehiculoID == re.VehiculoID && reserva.FechaEn == re.FechaEn && reserva.FechaDev == re.FechaDev && reserva.HoraDev == re.HoraDev && reserva.EstadoID == re.EstadoID);
        }
    }
}