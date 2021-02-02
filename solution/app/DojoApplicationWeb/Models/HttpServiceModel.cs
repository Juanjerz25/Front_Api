using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DojoApplicationWeb.Models
{
    public class HttpServiceModel
    {
        public object Parametros { get; set; }
        public string Controlador { get; set; }
        public string Accion { get; set; }
    }
}