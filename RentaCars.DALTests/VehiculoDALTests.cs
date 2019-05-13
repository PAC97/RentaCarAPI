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
    public class VehiculoDALTests
    {
        VehiculoDAL vDAL = new VehiculoDAL();
        [TestMethod()]
        public void AddVehiculoTest()
        {
            Vehiculo vehiculo = new Vehiculo
            {
                UsuarioID = 6,
                Placa = "1223s",
                Marca = "Pegeot",
                Modelo = "f50",
                Year = Convert.ToDateTime("2002/01/01"),
                Npuertas = 4,
                PrecioDiario = Convert.ToInt32(10),
                EstadoID = 1,
                imagen = "dfdfdfdfd"
            };

            int r = vDAL.AddVehiculo(vehiculo);

            List<Vehiculo> vehiculos = vDAL.VehiculoList("Activo");

            Vehiculo ve = vehiculos.OrderByDescending(v => v.VehiculoID).FirstOrDefault();

            Assert.IsTrue(
                r > 0 && vehiculo.UsuarioID == ve.UsuarioID &&
                vehiculo.Placa == ve.Placa && vehiculo.Marca == ve.Marca &&
                vehiculo.Modelo == ve.Modelo && vehiculo.Year == ve.Year &&
                vehiculo.Npuertas == ve.Npuertas &&
                vehiculo.PrecioDiario == ve.PrecioDiario &&
                vehiculo.EstadoID == ve.EstadoID &&
                vehiculo.imagen == ve.imagen);
        }

        [TestMethod()]
        public void VehiculoListTest()
        {
            List<Vehiculo> vehiculos = vDAL.VehiculoList("Activo");
            Console.WriteLine("Datos encontrados en la base de datos {0}", vehiculos.Count);
            Assert.IsTrue(vehiculos.Count > 0);
        }

        [TestMethod()]
        public void UpdateVehiculoTest()
        {
            List<Vehiculo> vehiculos = vDAL.VehiculoList("Activo");
            Vehiculo vehiculo = vehiculos.OrderByDescending(vr => vr.VehiculoID).FirstOrDefault();
            vehiculo.Modelo = "BMW";
            int r = vDAL.UpdateVehiculo(vehiculo);
            Assert.IsTrue(r > 0);
        }

        [TestMethod()]
        public void DeleteVehiculoTest()
        {
            List<Vehiculo> vehiculos = vDAL.VehiculoList("Activo");
            Vehiculo vehiculo = vehiculos.OrderByDescending(vr => vr.VehiculoID).FirstOrDefault();
            int r = vDAL.DeleteVehiculo(vehiculo.VehiculoID);
            Assert.IsTrue(r > 0);
        }

        [TestMethod()]
        public void FindVehiculoTest()
        {
            List<Vehiculo> vehiculos = vDAL.VehiculoList("Activo");
            Vehiculo vehiculo = vehiculos.OrderByDescending(vr => vr.VehiculoID).FirstOrDefault();
            Vehiculo veh = vDAL.FindVehiculo(vehiculo.VehiculoID);
            Assert.IsTrue(veh.VehiculoID > 0 && vehiculo.UsuarioID == veh.UsuarioID && vehiculo.Placa == veh.Placa && vehiculo.Marca == veh.Marca && vehiculo.Modelo == veh.Modelo && vehiculo.Year == veh.Year && vehiculo.Npuertas == veh.Npuertas && vehiculo.PrecioDiario == veh.PrecioDiario && vehiculo.EstadoID == veh.EstadoID && vehiculo.imagen == veh.imagen);
        }
    }
}