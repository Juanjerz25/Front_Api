using DataStorage;
using DataStorage.DataAccess;
using DojoApplicationServices.Models;
using DojoApplicationServices.Response;
using DojoApplicationServices.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DojoApplicationServices.Services
{
    public static class DojoServices
    {
        public static DojosResponse ObtenerDojos()
        {
            var mensajes = new List<Mensaje>();
            try
            {
                List<Dojo> dojos = DojoAccess.ObtenerDojos();
                List<DojoModel> dojosModel = ConfigAutomapper.mapper.Map<List<DojoModel>>(dojos);

                mensajes.Add(new Mensaje("1", "Consulta Realizada Correctamente"));

                return new DojosResponse(dojosModel, true, mensajes);

            }
            catch (Exception ex)
            {

                //Captura de errores
                mensajes.Add(new Mensaje(null, ex.Message));
                return new DojosResponse(null, false, mensajes);
            }
        }
        public static MiembrosResponse ObtenerMiembros()
        {
            var mensajes = new List<Mensaje>();
            try
            {
                List<Miembro> miembros = MiembroAccess.ObtenerMiembros();
                List<MiembroModel> miembrosModel = ConfigAutomapper.mapper.Map<List<MiembroModel>>(miembros);

                mensajes.Add(new Mensaje("1", "Consulta Realizada Correctamente"));

                return new MiembrosResponse(miembrosModel, true, mensajes);

            }
            catch (Exception ex)
            {

                //Captura de errores
                mensajes.Add(new Mensaje(null, ex.Message));
                return new MiembrosResponse(null, false, mensajes);
            }
        }

        public static MiembroResponse CrearMiembro(MiembroModel miembroModel)
        {
            var mensajes = new List<Mensaje>();
            try
            {
                Miembro miembro = ConfigAutomapper.mapper.Map<Miembro>(miembroModel);
                var miembroAccess = MiembroAccess.CrearMiembro(miembro);          
                mensajes.Add(new Mensaje("1", "Miembro Creado Correctamente"));

                return new MiembroResponse(miembroModel, miembroAccess, mensajes);

            }
            catch (Exception ex)
            {

                //Captura de errores
                mensajes.Add(new Mensaje(null, ex.Message));
                return new MiembroResponse(null, false, mensajes);
            }
        }
        public static DojoMiembrosResponse ObtenerDojoMiembros()
        {
            var mensajes = new List<Mensaje>();
            try
            {
                List<DojoMiembro> dojos = DojoMiembroAccess.ObtenerDojoMiembros();
                List<DojoMiembroModel> listaDojoMiembroModel = new List<DojoMiembroModel>();
                foreach (var item in dojos)
                {
                    DojoMiembroModel dojoMiembroModel = new DojoMiembroModel();
                    DojoModel dojoModel = ConfigAutomapper.mapper.Map<DojoModel>(item.Dojo);
                    MiembroModel miembroModel = ConfigAutomapper.mapper.Map<MiembroModel>(item.Miembro);
                    dojoMiembroModel.DojoModel = dojoModel;
                    dojoMiembroModel.MiembroModel = miembroModel;
                    listaDojoMiembroModel.Add(dojoMiembroModel);
                }               
                mensajes.Add(new Mensaje("1", "Consulta Realizada Correctamente"));
                return new DojoMiembrosResponse(listaDojoMiembroModel, true, mensajes);
            }
            catch (Exception ex)
            {

                //Captura de errores
                mensajes.Add(new Mensaje(null, ex.Message));
                return new DojoMiembrosResponse(null, false, mensajes);
            }
        }

        public static DojoResponse CrearDojo(DojoModel request)
        {
            var mensajes = new List<Mensaje>();
            try
            {
                Dojo dojo = ConfigAutomapper.mapper.Map<Dojo>(request);
                var dojos = DojoAccess.CrearDojo(dojo);

                mensajes.Add(new Mensaje("1", "Registro Creado Correctamente"));

                return new DojoResponse(request, dojos, mensajes);

            }
            catch (Exception ex)
            {

                //Captura de errores
                mensajes.Add(new Mensaje(null, ex.Message));
                return new DojoResponse(null, false, mensajes);
            }
        }
        public static DojoMiembroResponse CrearDojoMiembro(DojoMiembroModel request)
        {
            var mensajes = new List<Mensaje>();
            try
            {
                DojoMiembro dojoMiembro = new DojoMiembro();
                dojoMiembro.DojoId = request.DojoModel.Id;
                dojoMiembro.MiembroId = request.MiembroModel.Id;
                var dojos = DojoMiembroAccess.CrearDojoMiembro(dojoMiembro);

                mensajes.Add(new Mensaje("1", "Registro Creado Correctamente"));
                return new DojoMiembroResponse(request, dojos, mensajes);
            }
            catch (Exception ex)
            {
                //Captura de errores
                mensajes.Add(new Mensaje(null, ex.Message));
                return new DojoMiembroResponse(null, false, mensajes);
            }
        }

        public static DojoResponse EditarDojo(DojoModel request)
        {
            var mensajes = new List<Mensaje>();
            try
            {
                Dojo dojo = ConfigAutomapper.mapper.Map<Dojo>(request);
                var dojos = DojoAccess.EditarDojo(dojo);

                mensajes.Add(new Mensaje("1", "Registro Actualizado Correctamente"));

                return new DojoResponse(request, dojos, mensajes);

            }
            catch (Exception ex)
            {

                //Captura de errores
                mensajes.Add(new Mensaje(null, ex.Message));
                return new DojoResponse(null, false, mensajes);
            }
        }

        public static DojoResponse EliminarDojo(DojoModel request)
        {
            var mensajes = new List<Mensaje>();
            try
            {
                Dojo dojo = ConfigAutomapper.mapper.Map<Dojo>(request);
                var dojos = DojoAccess.EliminarDojo(dojo);

                mensajes.Add(new Mensaje("1", "Registro Eliminado Correctamente"));

                return new DojoResponse(request, dojos, mensajes);

            }
            catch (Exception ex)
            {

                //Captura de errores
                mensajes.Add(new Mensaje(null, ex.Message));
                return new DojoResponse(null, false, mensajes);
            }
        }

        public static DojoMiembroResponse EliminarDojoMiembro(DojoMiembroModel request)
        {
            var mensajes = new List<Mensaje>();
            try
            {
                DojoMiembro dojoMiembro = new DojoMiembro();
                dojoMiembro.DojoId = request.DojoModel.Id;
                dojoMiembro.MiembroId = request.MiembroModel.Id;
                var dojos = DojoMiembroAccess.EliminarDojoMiembro(dojoMiembro);
                mensajes.Add(new Mensaje("1", "Registro Eliminado Correctamente"));
                return new DojoMiembroResponse(request, dojos, mensajes);

            }
            catch (Exception ex)
            {

                //Captura de errores
                mensajes.Add(new Mensaje(null, ex.Message));
                return new DojoMiembroResponse(null, false, mensajes);
            }
        }



    }
}
