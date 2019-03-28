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
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ReservaController : ApiController
    {
       
        private ReservaBL RBL = new ReservaBL();
        // GET: api/Reserva
        public IEnumerable<Reserva> Get()
        {
            return RBL.ReservaList("Activo");
        }

        // GET: api/Reserva/5
        public Reserva Get(int id)
        {
            return RBL.FindReserva(id);
        }

        // POST: api/Reserva
        public void Post([FromBody]Reserva re )
        {
            RBL.AddReserva(re);
        }

        // PUT: api/Reserva/5
        public void Put(int id, [FromBody]Reserva re)
        {
            re.EstadoID = id;
            RBL.UpdateReserva(re);
        }

        // DELETE: api/Reserva/5
        public void Delete(int id)
        {
            RBL.DeleteReserva(id);
        }
    }
}
