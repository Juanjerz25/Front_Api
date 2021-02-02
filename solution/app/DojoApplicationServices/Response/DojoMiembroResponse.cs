using DojoApplicationServices.Models;
using System.Collections.Generic;

namespace DojoApplicationServices.Response
{
    public sealed class DojoMiembrosResponse : BaseGatewayResponse
    {
        public List<DojoMiembroModel> DojoMiembroModel { get; set; }

        public DojoMiembrosResponse(List<DojoMiembroModel> dojoMiembroModel, bool success = false, IEnumerable<Mensaje> mensajes = null) : base(success, mensajes)
        {
            DojoMiembroModel = dojoMiembroModel;
        }
    }

    public sealed class DojoMiembroResponse : BaseGatewayResponse
    {
        public DojoMiembroModel DojoMiembroModel { get; set; }

        public DojoMiembroResponse(DojoMiembroModel dojoMiembroModel, bool success = false, IEnumerable<Mensaje> mensajes = null) : base(success, mensajes)
        {
            DojoMiembroModel = dojoMiembroModel;
        }
    }
}
