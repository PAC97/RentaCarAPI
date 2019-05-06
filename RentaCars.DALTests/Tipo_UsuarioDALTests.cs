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
    public class Tipo_UsuarioDALTests
    {
        Tipo_UsuarioDAL TUDAL = new Tipo_UsuarioDAL();
        [TestMethod()]

        public void AddTipo_UsuarioTest()
        {
            TipoUsuario tu = new TipoUsuario { Nombre = "User", EstadoID = 1 };
            int r = TUDAL.AddTipo_Usuario(tu);
            List<TipoUsuario> tipoUsuarios = TUDAL.Tipo_UsuarioList("Activo");
            TipoUsuario tu1 = tipoUsuarios.OrderByDescending(tur => tur.TipoUsuarioID).FirstOrDefault();
            Assert.IsTrue(r > 0 && tu.Nombre == tu1.Nombre && tu.EstadoID == tu1.EstadoID);
        }

        [TestMethod()]
        public void Tipo_UsuarioListTest()
        {
            TUDAL.AddTipo_Usuario(new TipoUsuario { Nombre = "PendientePrueba", EstadoID = 1 });
            List<TipoUsuario> tipoUsuarios = TUDAL.Tipo_UsuarioList("Activo");
            Console.Write("Datos encontrados en la base de datos {0}", tipoUsuarios.Count);
            Assert.IsTrue(tipoUsuarios.Count > 0);
        }

        [TestMethod()]
        public void UpdateTipo_UsuarioTest()
        {
            TUDAL.AddTipo_Usuario(new TipoUsuario { Nombre = "PedientePrueba2", EstadoID = 1 });
            List<TipoUsuario> tipoUsuarios = TUDAL.Tipo_UsuarioList("Activo");
            TipoUsuario tu = tipoUsuarios.OrderByDescending(tur => tur.TipoUsuarioID).FirstOrDefault();
            tu.Nombre = "PendientePrueba3";
            int r = TUDAL.UpdateTipo_Usuario(tu);
            Assert.IsTrue(r > 0);
        }

        [TestMethod()]
        public void DeleteTipo_UsuarioTest()
        {
            TUDAL.AddTipo_Usuario(new TipoUsuario { Nombre = "Prueba4", EstadoID = 1 });
            List<TipoUsuario> tipoUsuarios = TUDAL.Tipo_UsuarioList("Activo");
            TipoUsuario tu = tipoUsuarios.OrderByDescending(tur => tur.TipoUsuarioID).FirstOrDefault();
            int r = TUDAL.DeleteTipo_Usuario(tu.TipoUsuarioID);
            Assert.IsTrue(r > 0);
        }

        [TestMethod()]
        public void FindTipo_UsuarioTest()
        {
            TUDAL.AddTipo_Usuario(new TipoUsuario { Nombre = "Prueba5", EstadoID = 1 });
            List<TipoUsuario> tipoUsuarios = TUDAL.Tipo_UsuarioList("Activo");
            TipoUsuario tu = tipoUsuarios.OrderByDescending(tur => tur.EstadoID).FirstOrDefault();
            TipoUsuario tuID = TUDAL.FindTipo_Usuario(tu.EstadoID);
            Assert.IsTrue(tuID.TipoUsuarioID > 0 && tu.Nombre == tuID.Nombre && tu.EstadoID == tuID.EstadoID);
        }
    }
}