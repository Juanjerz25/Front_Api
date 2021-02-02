using System.Collections.Generic;

namespace DojoApplicationWeb.Response
{
    public abstract class BaseGatewayResponse
    {
        public bool Success { get; }
        public IEnumerable<Mensaje> Mensajes { get; }

        protected BaseGatewayResponse(bool success = false, IEnumerable<Mensaje> mensajes = null)
        {
            Success = success;
            Mensajes = mensajes;
        }
    }
}
