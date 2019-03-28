using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using RentaCars.BL;
using RentaCars.EN;
using System.Web.Http.Cors;

namespace WebAPI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class UsuarioController : ApiController
    {
       
        private UsuarioBL Ubl = new UsuarioBL();//Instancia y objeto creado(Ubl)
        // GET: api/Usuario
        public IEnumerable<Usuario> Get()
        {
            return Ubl.UsuarioList("Activo");
        }

        // GET: api/Usuario/5
        public Usuario Get(int id)
        {
            return Ubl.FindUsuario(id);
        }

        // POST: api/Usuario
        public void Post([FromBody]Usuario user)
        {
            Ubl.InserUsuario(user);
        }

        // PUT: api/Usuario/5
        public void Put(int id, [FromBody]Usuario user)
        {
            user.UsuarioID = id;
            Ubl.UpdateUsuario(user);
        }

        // DELETE: api/Usuario/5
        public void Delete(int id)
        {
            Ubl.DeleteUsuario(id);
        }
    }
}
