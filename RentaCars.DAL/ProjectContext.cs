using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Agragar
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity;
using RentaCars.EN;
using System.Data.Entity.SqlServer;

namespace RentaCars.DAL
{
    public class ProjectContext : DbContext
    {
        const string ConnString = "workstation id=RentaCars.mssql.somee.com;packet size=4096;user id=PAC97_SQLLogin_1;pwd=w1rvffqbsi;data source=RentaCars.mssql.somee.com;persist security info=False;initial catalog=RentaCars";
        //const string ConnString = "Data Source=.; initial Catalog=RentaCars; Integrated Security=True";
        public ProjectContext() : base(ConnString)
        {
            var ensureDLLIsCopied = SqlProviderServices.Instance;
        }
        
        public DbSet<Vehiculo> Vehiculos { get; set; }
        public DbSet<TipoUsuario> TipoUsuario { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        
        public DbSet<Estado> Estado { get; set; }
        public DbSet<Reserva> Reserva { get; set; }

        public DbSet<Renta> Renta { get; set; }
        

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }
    }
}
