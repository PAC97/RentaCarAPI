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
    public class Tipo_UsuarioDAL
    {
        //Instancia a la clase Contexto del Proyecto
        private ProjectContext db = new ProjectContext();
        //Funcion de agregar
        public int AddTipo_Usuario(TipoUsuario Tipo)
        {
            int r = 0;
            if (Tipo != null)
            {
                db.TipoUsuario.Add(Tipo);
                r = db.SaveChanges();
            }
            return r;
        }
        //funcion que devuelve datos
        public List<TipoUsuario> Tipo_UsuarioList(string state)
        {
            var List = db.TipoUsuario
                .Where(tu => tu.Estado.Nombre == state)
                .Include(tu => tu.Estado);
            return List.ToList();
        }
        //Funcion de modificacion
        public int UpdateTipo_Usuario(TipoUsuario Tipo)
        {
            int r = 0;
            if (Tipo != null)
            {
                db.Entry(Tipo).State = EntityState.Modified;
                r = db.SaveChanges();
            }
            return r;
        }
        //Funcion de eliminar
        public int DeleteTipo_Usuario(int id)
        {
            int r = 0;
            TipoUsuario tipo = db.TipoUsuario.Find(id);
            tipo.EstadoID = 2;
            r = UpdateTipo_Usuario(tipo);
            return r;
        }
        //Funcion de buscar por ID
        public TipoUsuario FindTipo_Usuario(int id)
        {
            TipoUsuario tipo = db.TipoUsuario.Find(id);
            return tipo;
        }
    }
}
