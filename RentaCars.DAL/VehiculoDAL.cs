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
    public class VehiculoDAL
    {
        //Instancia a la clase Contexto del Proyecto
        private ProjectContext db = new ProjectContext();
        //Funcion de agregar
        public int AddVehiculo(Vehiculo Auto)
        {
            int r = 0;
            if (Auto != null)
            {
                db.Vehiculos.Add(Auto);
                r = db.SaveChanges();
            }
            return r;
        }
        //funcion que devuelver
        public List<Vehiculo> VehiculoList(string state)
        {
            var List = from auto
                       in db.Vehiculos
                       where auto.Estado.Nombre == "Activo"
                       select auto;
            return List.ToList();
        }
        //Funcion de modificar
        public int UpdateVehiculo(Vehiculo Auto)
        {
            int r = 0;
            if (Auto != null)
            {
                db.Entry(Auto).State = EntityState.Modified;
                r = db.SaveChanges();
            }
            return r;
        }
        //Funcion de eliminar
        public int DeleteVehiculo(int id)
        {
            int r = 0;
            Vehiculo auto = db.Vehiculos.Find(id);
            auto.EstadoID = 2;
            r = UpdateVehiculo(auto);
            return r;
        }
        //Buscar por ID
        public Vehiculo FindVehiculo(int id)
        {
            Vehiculo auto = db.Vehiculos.Find(id);
            return auto;
        }
    }
}
