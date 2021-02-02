using DojoApplicationServices.Models;
using System.Collections.Generic;

namespace DojoApplicationServices.Response
{
    public sealed class MiembrosResponse : BaseGatewayResponse
    {
        public List<MiembroModel> Miembro { get; set; }

        public MiembrosResponse(List<MiembroModel> miembroModel, bool success = false, IEnumerable<Mensaje> mensajes = null) : base(success, mensajes)
        {
            Miembro = miembroModel;
        }
    }

    public sealed class MiembroResponse : BaseGatewayResponse
    {
        public MiembroModel Miembro { get; set; }

        public MiembroResponse(MiembroModel miembroModel, bool success = false, IEnumerable<Mensaje> mensajes = null) : base(success, mensajes)
        {
            Miembro = miembroModel;
        }
    }
}
