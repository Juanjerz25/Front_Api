using DojoApplicationWeb.Models;
using System.Collections.Generic;

namespace DojoApplicationWeb.Response
{
    public sealed class RetosResponse : BaseGatewayResponse
    {
        public List<RetoModel> Reto { get; set; }

        public RetosResponse(List<RetoModel> retoModel, bool success = false, IEnumerable<Mensaje> mensajes = null) : base(success, mensajes)
        {
            Reto = retoModel;
        }
    }

    public sealed class RetoResponse : BaseGatewayResponse
    {
        public RetoModel Reto { get; set; }

        public RetoResponse(RetoModel retoModel, bool success = false, IEnumerable<Mensaje> mensajes = null) : base(success, mensajes)
        {
            Reto = retoModel;
        }
    }
}
