using DojoApplicationWeb.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace DojoApplicationWeb.Controllers
{
    public class PuntajeController : BaseController
    {
        public class Resultado
        {
            [Display(Name = "Nombre Miembro")]
            public string Nombre { get; set; }
            [Display(Name = "Puntaje")]
            public int Puntaje { get; set; }
        }
        // GET: Puntaje
        public async Task<ActionResult> Index()
        {
            var puntajes = await ObtenerPuntajes();
            var miembros = await ObtenerMiembros();
            var retoMiembro = await ObtenerRetoMiembros();          
            
            return View();
        }
    }
}