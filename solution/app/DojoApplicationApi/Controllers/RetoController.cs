using DojoApplicationServices.Models;
using DojoApplicationServices.Services;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RetoApplicationApi.Controllers
{
    [Route("api/Reto/{action}", Name = "Reto")]
    public class RetoController : ApiController
    {
        [HttpPost]
        public HttpResponseMessage ObtenerRetos()
        {
            var response = RetoServices.ObtenerRetos();
            HttpResponseMessage result = Request.CreateResponse(HttpStatusCode.OK, response);
            return result;
        }
        [HttpPost]
        public HttpResponseMessage ObtenerRetoMiembros()
        {
            var response = RetoServices.ObtenerRetoMiembros();
            HttpResponseMessage result = Request.CreateResponse(HttpStatusCode.OK, response);
            return result;
        }
        [HttpPost]
        public HttpResponseMessage CrearReto([FromBody] RetoModel request)
        {
            var response = RetoServices.CrearReto(request);
            HttpResponseMessage result = Request.CreateResponse(HttpStatusCode.OK, response);
            return result;
        }
        [HttpPost]
        public HttpResponseMessage CrearRetoMiembro([FromBody] RetoMiembroModel request)
        {
            var response = RetoServices.CrearRetoMiembro(request);
            HttpResponseMessage result = Request.CreateResponse(HttpStatusCode.OK, response);
            return result;
        }
        [HttpPost]
        public HttpResponseMessage EliminarRetoMiembro([FromBody] RetoMiembroModel request)
        {
            var response = RetoServices.EliminarRetoMiembro(request);
            HttpResponseMessage result = Request.CreateResponse(HttpStatusCode.OK, response);
            return result;
        }
        [HttpPost]
        public HttpResponseMessage EliminarReto([FromBody] RetoModel request)
        {
            var response = RetoServices.EliminarReto(request);
            HttpResponseMessage result = Request.CreateResponse(HttpStatusCode.OK, response);
            return result;
        }
        [HttpPost]
        public HttpResponseMessage ObtenerPuntajes()
        {
            var response = RetoServices.ObtenerPuntajes();
            HttpResponseMessage result = Request.CreateResponse(HttpStatusCode.OK, response);
            return result;
        }
        [HttpPost]
        public HttpResponseMessage CrearPuntaje([FromBody] PuntajeModel request)
        {
            var response = RetoServices.CrearPuntaje(request);
            HttpResponseMessage result = Request.CreateResponse(HttpStatusCode.OK, response);
            return result;
        }
    }
}
