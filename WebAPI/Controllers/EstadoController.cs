using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using RentaCars.EN;
using RentaCars.BL;
using System.Web.Http.Cors;

namespace WebAPI.Controllers
{
    public class EstadoController : ApiController
    {
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        private EstadoBL EBL = new EstadoBL();
        // GET: api/Estado
        public IEnumerable<Estado> Get()
        {
            return EBL.StateList();
        }

        // GET: api/Estado/5
        public Estado Get(int id)
        {
            return EBL.FindState(id);
        }

        // POST: api/Estado
        public void Post([FromBody]Estado esta)
        {
            EBL.AddEstado(esta);
        }

        // PUT: api/Estado/5
        public void Put(int id, [FromBody]Estado esta)
        {
            esta.EstadoID = id;
            EBL.UpdateState(esta);
        }

        // DELETE: api/Estado/5
        public void Delete(int id)
        {

        }
    }
}
