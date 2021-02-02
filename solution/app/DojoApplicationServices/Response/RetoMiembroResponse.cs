using DojoApplicationServices.Models;
using System.Collections.Generic;

namespace DojoApplicationServices.Response
{
    public sealed class RetoMiembrosResponse : BaseGatewayResponse
    {
        public List<RetoMiembroModel> RetoMiembro { get; set; }

        public RetoMiembrosResponse(List<RetoMiembroModel> retoMiembro, bool success = false, IEnumerable<Mensaje> mensajes = null) : base(success, mensajes)
        {
            RetoMiembro = retoMiembro;
        }
    }

    public sealed class RetoMiembroResponse : BaseGatewayResponse
    {
        public RetoMiembroModel RetoMiembro { get; set; }

        public RetoMiembroResponse(RetoMiembroModel retoMiembro, bool success = false, IEnumerable<Mensaje> mensajes = null) : base(success, mensajes)
        {
            RetoMiembro = retoMiembro;
        }
    }
}
