using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
//agregar
using RentaCars.EN;
using RentaCars.BL;
using System.Web.Http.Cors;

namespace WebAPI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]

    public class RentaController : ApiController
    {
        
        private RentaBL renta = new RentaBL();
        // GET: api/Renta
        public IEnumerable<Renta> Get()
        {
            return renta.ListRenta("Activo");
        }
        // GET: api/Renta/5

        public Renta Get(int id)
        {
            Renta rent = renta.findRenta(id);
            if (renta == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NoContent));
            }
            return renta.findRenta(id);
        }

        // POST: api/Renta
        public HttpResponseMessage Post([FromBody] Renta rent)
        {
            if (ModelState.IsValid)
            {
                renta.agregarrenta(rent);
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, renta);
                response.Headers.Location = new Uri(Url.Link("DefauldtApi", new { id = rent.RentaID }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }
        // PUT: api/Renta/5
        public HttpResponseMessage Put(int id, [FromBody] Renta rent)
        {
            if (ModelState.IsValid)
            {
                if (id > 0)
                {
                    rent.RentaID = id;
                    renta.ModificarRenta(rent);
                    return Request.CreateResponse(HttpStatusCode.OK);
                }
                else
                {
                    throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotModified));
                }
            }
            else
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.BadRequest));
            }
        }

        // DELETE: api/Renta/5
        public HttpResponseMessage Delete(int id)
        {
            if (ModelState.IsValid)
            {
                renta.DeleteRenta(id);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.BadRequest));
            }
        }
    }
}