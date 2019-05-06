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
    }
}