using DojoApplicationWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace DojoApplicationWeb.Controllers
{
    public class HomeController : BaseController
    {
        public async Task<ActionResult> Index()
        {
            var responseDojo = await ObtenerDojos();
            List<DojoModel> listaDojo = responseDojo.Dojo;
            return View(listaDojo);
        }

        public ActionResult AgregarDojo()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> AgregarDojo(DojoModel dojo)
        {
            if (!ModelState.IsValid)
            {
                return View(dojo);
            }
            else
            {
                await CrearDojo(dojo);

                return RedirectToAction("Index");
            }
        }
        public async Task<ActionResult> EditarDojo(DojoModel dojo)
        {
            var dojoMiembro = await ObtenerDojoMiembros();
            var retos = await ObtenerRetos();
            if (dojoMiembro.DojoMiembroModel != null)
            {
                ViewBag.ListaDojoMiembro = dojoMiembro.DojoMiembroModel.Where(x => x.DojoModel.Id == dojo.Id).Select(x => x.MiembroModel).ToList();
            }
            else
            {
                ViewBag.ListaDojoMiembro = new List<DojoMiembroModel>();
            }
            if(retos.Reto != null)
            {
                ViewBag.ListaRetos = retos.Reto.Where(x => x.DojoId == dojo.Id).ToList();
            }
            else
            {
                ViewBag.ListaRetos = new List<RetoModel>();
            }
            
            
            return View(dojo);
        }

        [HttpPost]
        public async Task<ActionResult> EditarRegistroDojo(DojoModel dojo)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("EditarDojo");
            }
            await ModificarDojo(dojo);
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> EliminarDojoFront(DojoModel dojo)
        {
            await EliminarDojo(dojo);
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> crearDojoMiembro(DojoModel dojoModel)
        {
            List<SelectListItem> listaMiembros;
            var miembros = await ObtenerMiembros();
            listaMiembros = (from item in miembros.Miembro
                             select new SelectListItem
                             {
                                 Text = item.Nombre,
                                 Value = item.Id.ToString()
                             }).ToList();
            listaMiembros.Insert(0, new SelectListItem { Text = "--Seleccione", Value = "" });
            ViewBag.listaMiembros = listaMiembros;
            DojoMiembroModel dojoMiembroModel = new DojoMiembroModel();
            MiembroModel miembroModel = new MiembroModel();
            miembroModel.Nombre = "-";
            dojoMiembroModel.DojoModel = dojoModel;
            dojoMiembroModel.MiembroModel= miembroModel;
            return View(dojoMiembroModel);

        }
        public async Task<ActionResult> EliminarDojoMiembroFront(int miembroId, int dojoId)
        {
            var dojoMiembro = await ObtenerDojoMiembros();
            var dojoMiembroModel = dojoMiembro.DojoMiembroModel.Where(x => x.MiembroModel.Id == miembroId && x.DojoModel.Id == dojoId).FirstOrDefault();
            await EliminarDojoMiembro(dojoMiembroModel);
            return RedirectToAction("EditarDojo","Home",dojoMiembroModel.DojoModel);
        }
        [HttpPost]
        public async Task<ActionResult> crearDojoMiembroFront(DojoMiembroModel dojoMiembroModel)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("crearDojoMiembro", "Home", dojoMiembroModel.DojoModel);
            }
            var response = await AsignarDojoMiembro(dojoMiembroModel);
            if (!response.Success)
            {
                return RedirectToAction("crearDojoMiembro", "Home", dojoMiembroModel.DojoModel);
            }
            return RedirectToAction("EditarDojo","Home",dojoMiembroModel.DojoModel);
        }

        public ActionResult AgregarReto(DojoModel dojoModel)
        {
            RetoModel retoModel = new RetoModel();
            List<SelectListItem> listaDias = new List<SelectListItem>();
            listaDias.Insert(0, new SelectListItem { Text = "--Seleccione", Value = "" });
            for (int i = 1; i <= 60; i++)
            {
                SelectListItem item = new SelectListItem();
                item.Text = i.ToString();
                item.Value = i.ToString();
                listaDias.Add(item);
            }
            ViewBag.ListaDias = listaDias;
            ViewBag.DojoModel = dojoModel;
            retoModel.DojoId = dojoModel.Id;

            return View(retoModel);
        }

        [HttpPost]
        public async Task<ActionResult> AgregarRetoFront(RetoModel retoModel)
        {
            var responseDojo = await ObtenerDojos();
            var dojoModel = responseDojo.Dojo.Where(x=> x.Id==retoModel.DojoId).FirstOrDefault();
            if (!ModelState.IsValid)
            {
                return RedirectToAction("AgregarReto", "Home", dojoModel);
            }

            var response = await CrearReto(retoModel);
            if (!response.Success)
            {
                return RedirectToAction("AgregarReto", "Home", dojoModel);
            }
            return RedirectToAction("EditarDojo", "Home", dojoModel);
        }

        public async Task<ActionResult> EliminarRetoFront(RetoModel retoModel)
        {
            var responseDojo = await ObtenerDojos();
            var dojoModel = responseDojo.Dojo.Where(x => x.Id == retoModel.DojoId).FirstOrDefault();
            await EliminarReto(retoModel);
            return RedirectToAction("EditarDojo", "Home", dojoModel);
        }

        public async Task<ActionResult> EditarReto(RetoModel retoModel)
        {
            var responseReto = await ObtenerRetos();
            var responseDogo = await ObtenerDojos();
            var dojoModel = responseDogo.Dojo.Where(x => x.Id == retoModel.DojoId).FirstOrDefault();
            var reto = responseReto.Reto.Where(x => x.Id == retoModel.Id).FirstOrDefault();
            List<SelectListItem> listaDias = new List<SelectListItem>();
            listaDias.Insert(0, new SelectListItem { Text = "--Seleccione", Value = "" });
            for (int i = 1; i <= 60; i++)
            {
                SelectListItem item = new SelectListItem();
                item.Text = i.ToString();
                item.Value = i.ToString();
                listaDias.Add(item);
            }
            var retoMiembros = await ObtenerRetoMiembros();
            if (retoMiembros.RetoMiembro != null)
            {
                ViewBag.ListaRetoMiembro = retoMiembros.RetoMiembro.Where(x => x.RetoModel.Id == retoModel.Id).ToList();
            }
            else
            {
                ViewBag.ListaRetoMiembro = new List<RetoMiembroModel>();
            }
            
            ViewBag.ListaDias = listaDias;
            ViewBag.DojoModel = dojoModel;
            ViewBag.RetoModel = reto;
            return View(retoModel);
        }

        public async Task<ActionResult> AsignarRetoMiembro(RetoModel retoModel)
        {
            List<SelectListItem> listaMiembros;
            var dojoMiembros = await ObtenerDojoMiembros();
            var retoMiembros = await ObtenerRetoMiembros();
            var miembros = dojoMiembros.DojoMiembroModel.Where(x => x.DojoModel.Id == retoModel.DojoId).Select(x => x.MiembroModel);
            var miembroFiltrado = miembros.Where(x => !retoMiembros.RetoMiembro.Exists(y => x.Id == y.MiembroModel.Id)).ToList();
            listaMiembros = (from item in miembroFiltrado
                             select new SelectListItem
                             {
                                 Text = item.Nombre,
                                 Value = item.Id.ToString()
                             }).ToList();
            listaMiembros.Insert(0, new SelectListItem { Text = "--Seleccione", Value = "" });
            ViewBag.listaMiembros = listaMiembros;
            RetoMiembroModel retoMiembroModel = new RetoMiembroModel();
            MiembroModel miembroModel = new MiembroModel();
            miembroModel.Nombre = "-";
            retoMiembroModel.RetoModel= retoModel;
            retoMiembroModel.MiembroModel = miembroModel;
            DateTime fecha = DateTime.Now.AddDays((double)retoModel.DiasTiempoLimite);
            retoMiembroModel.TiempoLimite = fecha;
            return View(retoMiembroModel);
        }

        [HttpPost]
        public async Task<ActionResult> crearRetoMiembroFront(RetoMiembroModel retoMiembroModel)
        {
            var response = await CrearRetoMiembro(retoMiembroModel);
            if (!response.Success)
            {
                return RedirectToAction("AsignarRetoMiembro", "Home", retoMiembroModel.RetoModel);
            }
            return RedirectToAction("EditarReto", "Home", retoMiembroModel.RetoModel);
        }

        public async Task<ActionResult> EliminarRetoMiembroFront(int retoId, int miembroId)
        {
            var retoMiembro = await ObtenerRetoMiembros();
            var dojoMiembroModel = retoMiembro.RetoMiembro.Where(x => x.MiembroModel.Id == miembroId && x.RetoModel.Id == retoId).FirstOrDefault();
            await EliminarRetoMiembro(dojoMiembroModel);
            return RedirectToAction("EditarReto", "Home", dojoMiembroModel.RetoModel);
        }



        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}