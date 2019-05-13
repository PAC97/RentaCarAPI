using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Agregar
using RentaCars.EN;
using System.Data.Entity;

namespace RentaCars.DAL
{
    public class UsuarioDAL
    {
        //Instancia a la clase Contexto del Proyecto
        private ProjectContext db = new ProjectContext();
        //Funcion de agregar
        public int AddUsuario(Usuario User)
        {
            int r = 0;
            if (User != null)
            {
                db.Usuarios.Add(User);
                r = db.SaveChanges();
            }
            return r;
        }
        //funcion que devuelve datos
        public List<Usuario> UsuarioList(string state)
        {
            var List = from user
                       in db.Usuarios
                       where user.Estado.Nombre == "Activo"
                       select user;
            return List.ToList();
        }

        public List<Usuario> ConsultarUsuarioID(string nomUser, string pass)
        {
            var List = from user
                       in db.Usuarios
                       where user.NombreUser == nomUser && user.Pass == pass
                       select user;
            return List.ToList();
        }
        //Funcion de modificacion
        public int UpdateUsuario(Usuario User)
        {
            int r = 0;
            if (User != null)
            {
                db.Entry(User).State = EntityState.Modified;
                r = db.SaveChanges();
            }
            return r;
        }
        //Funcion de eliminar
        public int DeleteUsuario(int id)
        {
            int r = 0;
            Usuario user = db.Usuarios.Find(id);
            user.EstadoID = 2;
            r = UpdateUsuario(user);
            return r;
        }
        //Funcion de buscar por ID
        public Usuario FindUsuario(int id)
        {
            Usuario user = db.Usuarios.Find(id);
            return user;
        }
        //public List<Usuario> ComprobarUser(string NombreUser, string Pass)
        //{
        //    var login = from log
        //              in db.Usuarios
        //               where log.NombreUser == NombreUser
        //               where log.Pass == Pass
        //               select log;
        //    return login.ToList();
        //}
    }  
}
