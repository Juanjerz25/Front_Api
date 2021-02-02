using DojoApplicationWeb.ConsumpoApi;
using DojoApplicationWeb.Models;
using DojoApplicationWeb.Response;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace DojoApplicationWeb.Controllers
{
    public class BaseController : Controller
    {
        public async Task<DojosResponse> ObtenerDojos()
        {
            HttpServiceModel httpServiceModel = new HttpServiceModel();
            httpServiceModel.Controlador = "Dojo";
            httpServiceModel.Accion = "ObtenerDojos";
            httpServiceModel.Parametros = new DojoModel();
            var result = await ConexionApi.PostItem(httpServiceModel);
            var entidad = JsonConvert.DeserializeObject<DojosResponse>(result);

            return entidad;
        }

        public async Task<DojoResponse> CrearDojo(DojoModel dojo)
        {
            HttpServiceModel httpServiceModel = new HttpServiceModel();
            httpServiceModel.Controlador = "Dojo";
            httpServiceModel.Accion = "CrearDojo";
            httpServiceModel.Parametros = dojo;
            var result = await ConexionApi.PostItem(httpServiceModel);
            var entidad = JsonConvert.DeserializeObject<DojoResponse>(result);
            return entidad;
        }

        public async Task<DojoResponse> ModificarDojo(DojoModel dojo)
        {
            HttpServiceModel httpServiceModel = new HttpServiceModel();
            httpServiceModel.Controlador = "Dojo";
            httpServiceModel.Accion = "EditarDojo";
            httpServiceModel.Parametros = dojo;
            var result = await ConexionApi.PostItem(httpServiceModel);
            var entidad = JsonConvert.DeserializeObject<DojoResponse>(result);
            return entidad;
        }

        public async Task<DojoResponse> EliminarDojo(DojoModel dojo)
        {
            HttpServiceModel httpServiceModel = new HttpServiceModel();
            httpServiceModel.Controlador = "Dojo";
            httpServiceModel.Accion = "EliminarDojo";
            httpServiceModel.Parametros = dojo;
            var result = await ConexionApi.PostItem(httpServiceModel);
            var entidad = JsonConvert.DeserializeObject<DojoResponse>(result);
            return entidad;
        }

        public async Task<DojoMiembrosResponse> ObtenerDojoMiembros()
        {
            HttpServiceModel httpServiceModel = new HttpServiceModel();
            httpServiceModel.Controlador = "Dojo";
            httpServiceModel.Accion = "ObtenerDojoMiembros";
            httpServiceModel.Parametros = null;
            var result = await ConexionApi.PostItem(httpServiceModel);
            var entidad = JsonConvert.DeserializeObject<DojoMiembrosResponse>(result);
            return entidad;
        }

        public async Task<DojoMiembroResponse> AsignarDojoMiembro(DojoMiembroModel dojoMiembroModel)
        {
            HttpServiceModel httpServiceModel = new HttpServiceModel();
            httpServiceModel.Controlador = "Dojo";
            httpServiceModel.Accion = "CrearDojoMiembro";
            httpServiceModel.Parametros = dojoMiembroModel;
            var result = await ConexionApi.PostItem(httpServiceModel);
            var entidad = JsonConvert.DeserializeObject<DojoMiembroResponse>(result);
            return entidad;
        }

        public async Task<DojoMiembroResponse> EliminarDojoMiembro(DojoMiembroModel dojoMiembroModel)
        {
            HttpServiceModel httpServiceModel = new HttpServiceModel();
            httpServiceModel.Controlador = "Dojo";
            httpServiceModel.Accion = "EliminarDojoMiembro";
            httpServiceModel.Parametros = dojoMiembroModel;
            var result = await ConexionApi.PostItem(httpServiceModel);
            var entidad = JsonConvert.DeserializeObject<DojoMiembroResponse>(result);
            return entidad;
        }

        public async Task<MiembrosResponse> ObtenerMiembros()
        {
            HttpServiceModel httpServiceModel = new HttpServiceModel();
            httpServiceModel.Controlador = "Dojo";
            httpServiceModel.Accion = "ObtenerMiembros";
            httpServiceModel.Parametros = null;
            var result = await ConexionApi.PostItem(httpServiceModel);
            var entidad = JsonConvert.DeserializeObject<MiembrosResponse>(result);
            return entidad;
        }

        public async Task<RetosResponse> ObtenerRetos()
        {
            HttpServiceModel httpServiceModel = new HttpServiceModel();
            httpServiceModel.Controlador = "Reto";
            httpServiceModel.Accion = "ObtenerRetos";
            httpServiceModel.Parametros = null;
            var result = await ConexionApi.PostItem(httpServiceModel);
            var entidad = JsonConvert.DeserializeObject<RetosResponse>(result);
            return entidad;
        }

        public async Task<RetoResponse> CrearReto(RetoModel retoModel)
        {
            HttpServiceModel httpServiceModel = new HttpServiceModel();
            httpServiceModel.Controlador = "Reto";
            httpServiceModel.Accion = "CrearReto";
            httpServiceModel.Parametros = retoModel;
            var result = await ConexionApi.PostItem(httpServiceModel);
            var entidad = JsonConvert.DeserializeObject<RetoResponse>(result);
            return entidad;
        }

        public async Task<RetoResponse> EliminarReto(RetoModel retoModel)
        {
            HttpServiceModel httpServiceModel = new HttpServiceModel();
            httpServiceModel.Controlador = "Reto";
            httpServiceModel.Accion = "EliminarReto";
            httpServiceModel.Parametros = retoModel;
            var result = await ConexionApi.PostItem(httpServiceModel);
            var entidad = JsonConvert.DeserializeObject<RetoResponse>(result);
            return entidad;
        }
        public async Task<RetoMiembrosResponse> ObtenerRetoMiembros()
        {
            HttpServiceModel httpServiceModel = new HttpServiceModel();
            httpServiceModel.Controlador = "Reto";
            httpServiceModel.Accion = "ObtenerRetoMiembros";
            httpServiceModel.Parametros = null;
            var result = await ConexionApi.PostItem(httpServiceModel);
            var entidad = JsonConvert.DeserializeObject<RetoMiembrosResponse>(result);
            return entidad;
        }

        public async Task<RetoMiembroResponse> CrearRetoMiembro(RetoMiembroModel retoMiembroModel)
        {
            HttpServiceModel httpServiceModel = new HttpServiceModel();
            httpServiceModel.Controlador = "Reto";
            httpServiceModel.Accion = "CrearRetoMiembro";
            httpServiceModel.Parametros = retoMiembroModel;
            var result = await ConexionApi.PostItem(httpServiceModel);
            var entidad = JsonConvert.DeserializeObject<RetoMiembroResponse>(result);
            return entidad;
        }

        public async Task<RetoMiembroResponse> EliminarRetoMiembro(RetoMiembroModel retoMiembroModel)
        {
            HttpServiceModel httpServiceModel = new HttpServiceModel();
            httpServiceModel.Controlador = "Reto";
            httpServiceModel.Accion = "EliminarRetoMiembro";
            httpServiceModel.Parametros = retoMiembroModel;
            var result = await ConexionApi.PostItem(httpServiceModel);
            var entidad = JsonConvert.DeserializeObject<RetoMiembroResponse>(result);
            return entidad;
        }

        public async Task<MiembroResponse> CrearMiembro(MiembroModel miembroModel)
        {
            HttpServiceModel httpServiceModel = new HttpServiceModel();
            httpServiceModel.Controlador = "Dojo";
            httpServiceModel.Accion = "CrearMiembro";
            httpServiceModel.Parametros = miembroModel;
            var result = await ConexionApi.PostItem(httpServiceModel);
            var entidad = JsonConvert.DeserializeObject<MiembroResponse>(result);
            return entidad;
        }

        public async Task<PuntajesResponse> ObtenerPuntajes()
        {
            HttpServiceModel httpServiceModel = new HttpServiceModel();
            httpServiceModel.Controlador = "Reto";
            httpServiceModel.Accion = "ObtenerPuntajes";
            httpServiceModel.Parametros = null;
            var result = await ConexionApi.PostItem(httpServiceModel);
            var entidad = JsonConvert.DeserializeObject<PuntajesResponse>(result);
            return entidad;
        }
    }
}