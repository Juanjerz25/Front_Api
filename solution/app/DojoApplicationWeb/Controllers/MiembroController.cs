using DojoApplicationWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace DojoApplicationWeb.Controllers
{
    public class MiembroController : BaseController
    {
        // GET: Miembro
        public async Task<ActionResult> Index()
        {
            var response = await ObtenerMiembros();
            var miembros = response.Miembro;
            return View(miembros);
        }
        public ActionResult AgregarMiembro()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> AgregarMiembro(MiembroModel miembro)
        {
            await CrearMiembro(miembro);
            return RedirectToAction("Index");
        }
    }
}