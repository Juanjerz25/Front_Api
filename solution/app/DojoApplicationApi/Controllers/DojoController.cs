using DojoApplicationServices.Models;
using DojoApplicationServices.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DojoApplicationApi.Controllers
{
    [Route("api/Dojo/{action}", Name = "Dojo")]
    public class DojoController : ApiController
    {
        [HttpPost]
        public HttpResponseMessage ObtenerDojos()
        {
            var response = DojoServices.ObtenerDojos();
            HttpResponseMessage result = Request.CreateResponse(HttpStatusCode.OK, response);
            return result;
        }
        [HttpPost]
        public HttpResponseMessage ObtenerMiembros()
        {
            var response = DojoServices.ObtenerMiembros();
            HttpResponseMessage result = Request.CreateResponse(HttpStatusCode.OK, response);
            return result;
        }
        [HttpPost]
        public HttpResponseMessage CrearMiembro([FromBody] MiembroModel request)
        {
            var response = DojoServices.CrearMiembro(request);
            HttpResponseMessage result = Request.CreateResponse(HttpStatusCode.OK, response);
            return result;
        }
        [HttpPost]
        public HttpResponseMessage ObtenerDojoMiembros()
        {
            var response = DojoServices.ObtenerDojoMiembros();
            HttpResponseMessage result = Request.CreateResponse(HttpStatusCode.OK, response);
            return result;
        }
        [HttpPost]
        public HttpResponseMessage CrearDojo([FromBody] DojoModel request)
        {
            var response = DojoServices.CrearDojo(request);
            HttpResponseMessage result = Request.CreateResponse(HttpStatusCode.OK, response);
            return result;
        }
        [HttpPost]
        public HttpResponseMessage CrearDojoMiembro([FromBody] DojoMiembroModel request)
        {
            var response = DojoServices.CrearDojoMiembro(request);
            HttpResponseMessage result = Request.CreateResponse(HttpStatusCode.OK, response);
            return result;
        }

        [HttpPost]
        public HttpResponseMessage EliminarDojoMiembro([FromBody] DojoMiembroModel request)
        {
            var response = DojoServices.EliminarDojoMiembro(request);
            HttpResponseMessage result = Request.CreateResponse(HttpStatusCode.OK, response);
            return result;
        }

        [HttpPost]
        public HttpResponseMessage EditarDojo([FromBody] DojoModel request)
        {
            var response = DojoServices.EditarDojo(request);
            HttpResponseMessage result = Request.CreateResponse(HttpStatusCode.OK, response);
            return result;
        }

        [HttpPost]
        public HttpResponseMessage EliminarDojo([FromBody] DojoModel request)
        {
            var response = DojoServices.EliminarDojo(request);
            HttpResponseMessage result = Request.CreateResponse(HttpStatusCode.OK, response);
            return result;
        }
    }
}
