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
    public class VehiculoController : ApiController
    {

        private VehiculoBL VBL = new VehiculoBL();
        // GET: api/Vehiculo
        public IEnumerable<Vehiculo> Get()
        {
            return VBL.VehiculoList("Activo");
        }

        // GET: api/Vehiculo/5
        public Vehiculo Get(int id)
        {
            Vehiculo car = VBL.FindVehiculo(id);
            if (car == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));

            }
            return VBL.FindVehiculo(id);
        }

        // POST: api/Vehiculo
        public HttpResponseMessage Post([FromBody]Vehiculo car)
        {
            if (ModelState.IsValid)
            {
                VBL.InserVehiculo(car);
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, car);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = car.VehiculoID }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // PUT: api/Vehiculo/5
        public HttpResponseMessage Put(int id, [FromBody]Vehiculo car)
        {
            if (ModelState.IsValid)
            {
                if (id > 0)
                {
                    car.VehiculoID = id;
                    VBL.UpdateVehiculo(car);
                    return Request.CreateResponse(HttpStatusCode.OK);

                }

                else
                {
                    throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
                }
            }
            else
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.BadRequest));
            }
        }

        // DELETE: api/Vehiculo/5
        public HttpResponseMessage Delete(int id)
        {
            if (ModelState.IsValid)
            {
                VBL.DeleteVehiculo(id);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.BadRequest));
            }
        }


    }
}

