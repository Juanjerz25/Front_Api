using DojoApplicationServices.Models;
using System.Collections.Generic;

namespace DojoApplicationServices.Response
{
    public sealed class PuntajesResponse : BaseGatewayResponse
    {
        public List<PuntajeModel> Puntaje { get; set; }

        public PuntajesResponse(List<PuntajeModel> puntajeModel, bool success = false, IEnumerable<Mensaje> mensajes = null) : base(success, mensajes)
        {
            Puntaje = puntajeModel;
        }
    }

    public sealed class PuntajeResponse : BaseGatewayResponse
    {
        public PuntajeModel Puntaje { get; set; }

        public PuntajeResponse(PuntajeModel puntajeModel, bool success = false, IEnumerable<Mensaje> mensajes = null) : base(success, mensajes)
        {
            Puntaje = puntajeModel;
        }
    }
}
