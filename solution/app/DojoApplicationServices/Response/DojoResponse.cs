using DojoApplicationServices.Models;
using System.Collections.Generic;

namespace DojoApplicationServices.Response
{
    public sealed class DojosResponse : BaseGatewayResponse
    {
        public List<DojoModel> Dojo { get; set; }

        public DojosResponse(List<DojoModel> dojoModel, bool success = false, IEnumerable<Mensaje> mensajes = null) : base(success, mensajes)
        {
            Dojo = dojoModel;
        }
    }

    public sealed class DojoResponse : BaseGatewayResponse
    {
        public DojoModel Dojo { get; set; }

        public DojoResponse(DojoModel dojoModel, bool success = false, IEnumerable<Mensaje> mensajes = null) : base(success, mensajes)
        {
            Dojo = dojoModel;
        }
    }
}
