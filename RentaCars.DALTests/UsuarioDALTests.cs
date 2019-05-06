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
    public class UsuarioDALTests
    {
        UsuarioDAL uDAL = new UsuarioDAL();
        [TestMethod()]
        public void AddUsuarioTest()
        {
            Usuario usuario = new Usuario { TipoUsuarioID = 1, Nombre = "Juan", Apellido = "Perez", Direccion = "Sonsonate", Email = "abcd@gmail.com", Telefono = 123456789, NombreUser = "jp", Pass = "abcd", EstadoID = 1 };
            int r = uDAL.AddUsuario(usuario);
            List<Usuario> usuarios = uDAL.UsuarioList("Activo");
            Usuario user = usuarios.OrderByDescending(u => u.UsuarioID).FirstOrDefault();
            Assert.IsTrue(r > 0 && usuario.TipoUsuarioID == user.TipoUsuarioID && usuario.Nombre == user.Nombre && usuario.Apellido == user.Apellido && usuario.Direccion == user.Direccion && usuario.Email == user.Email && usuario.Telefono == user.Telefono && usuario.NombreUser == user.NombreUser && usuario.Pass == user.Pass && usuario.EstadoID == user.EstadoID);
        }

        [TestMethod()]
        public void UsuarioListTest()
        {
            uDAL.AddUsuario(new Usuario { TipoUsuarioID = 1, Nombre = "Porfirio", Apellido = "Perez", Direccion = "Sonsonate", Email = "abcd@gmail.com", Telefono = 123456789, NombreUser = "jp", Pass = "abcd", EstadoID = 1 });
            List<Usuario> usuarios = uDAL.UsuarioList("Activo");
            Console.WriteLine("Datos encontrados en la base de datos {0}", usuarios.Count);
            Assert.IsTrue(usuarios.Count > 0);
        }

        [TestMethod()]
        public void UpdateUsuarioTest()
        {
            uDAL.AddUsuario(new Usuario { TipoUsuarioID = 1, Nombre = "Juan", Apellido = "Perez", Direccion = "Sonsonate", Email = "abcd@gmail.com", Telefono = 123456789, NombreUser = "jp", Pass = "abcd", EstadoID = 1 });
            List<Usuario> usuarios = uDAL.UsuarioList("Activo");
            Usuario usuario = usuarios.OrderByDescending(ur => ur.UsuarioID).FirstOrDefault();
            usuario.Nombre = "Panfilo";
            int r = uDAL.UpdateUsuario(usuario);
            Assert.IsTrue(r > 0);
        }

        [TestMethod()]
        public void DeleteUsuarioTest()
        {
            uDAL.AddUsuario(new Usuario { TipoUsuarioID = 1, Nombre = "Miguel", Apellido = "Perez", Direccion = "Sonsonate", Email = "abcd@gmail.com", Telefono = 123456789, NombreUser = "jp", Pass = "abcd", EstadoID = 1 });
            List<Usuario> usuarios = uDAL.UsuarioList("Activo");
            Usuario user = usuarios.OrderByDescending(ur => ur.UsuarioID).FirstOrDefault();
            int r = uDAL.DeleteUsuario(user.UsuarioID);
            Assert.IsTrue(r > 0);
        }

        [TestMethod()]
        public void FindUsuarioTest()
        {
            uDAL.AddUsuario(new Usuario { TipoUsuarioID = 1, Nombre = "Miguel", Apellido = "Perez", Direccion = "Sonsonate", Email = "abcd@gmail.com", Telefono = 123456789, NombreUser = "jp", Pass = "abcd", EstadoID = 1 });
            List<Usuario> usuarios = uDAL.UsuarioList("Activo");
            Usuario usuario = usuarios.OrderByDescending(ur => ur.UsuarioID).FirstOrDefault();
            Usuario user = uDAL.FindUsuario(usuario.UsuarioID);
            Assert.IsTrue(user.UsuarioID > 0 && usuario.TipoUsuarioID == user.TipoUsuarioID && usuario.Nombre == user.Nombre && usuario.Apellido == user.Apellido && usuario.Direccion == user.Direccion && usuario.Email == user.Email && usuario.Telefono == user.Telefono && usuario.NombreUser == user.NombreUser && usuario.Pass == user.Pass && usuario.EstadoID == user.EstadoID);
        }
    }
}