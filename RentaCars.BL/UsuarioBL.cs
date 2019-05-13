using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Agregar
using RentaCars.EN;
using RentaCars.DAL;

namespace RentaCars.BL
{
    public class UsuarioBL
    {
        private UsuarioDAL DAL = new UsuarioDAL();

        public int InserUsuario(Usuario User)
        {
            return DAL.AddUsuario(User);
        }
        public List<Usuario> UsuarioList(string state)
        {
            return DAL.UsuarioList(state);
        }
        public List<Usuario> ConsultarUsuarioID(string nomUser, string pass)
        {
            return DAL.ConsultarUsuarioID(nomUser, pass);
        }
        public int UpdateUsuario(Usuario User)
        {
            return DAL.UpdateUsuario(User);
        }
        public int DeleteUsuario(int id)
        {
            return DAL.DeleteUsuario(id);
        }
        public Usuario FindUsuario(int id)
        {
            return DAL.FindUsuario(id);
        }
        //public List<Usuario> ComprobarUser(string NombreUser, string Pass)
        //{
        //    return DAL.ComprobarUser(NombreUser, Pass);
        //}
    }
}
