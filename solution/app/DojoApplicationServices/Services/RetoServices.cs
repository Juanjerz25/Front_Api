using DataStorage;
using DataStorage.DataAccess;
using DojoApplicationServices.Models;
using DojoApplicationServices.Response;
using DojoApplicationServices.Utilities;
using System;
using System.Collections.Generic;

namespace DojoApplicationServices.Services
{
    public static class RetoServices
    {
        public static RetosResponse ObtenerRetos()
        {
            var mensajes = new List<Mensaje>();
            try
            {
                List<Reto> retos = RetoAccess.ObtenerRetos();
                List<RetoModel> retoModel = ConfigAutomapper.mapper.Map<List<RetoModel>>(retos);

                mensajes.Add(new Mensaje("1", "Consulta Realizada Correctamente"));

                return new RetosResponse(retoModel, true, mensajes);

            }
            catch (Exception ex)
            {
                //Captura de errores
                mensajes.Add(new Mensaje(null, ex.Message));
                return new RetosResponse(null, false, mensajes);
            }
        }
        public static RetoResponse CrearReto(RetoModel request)
        {
            var mensajes = new List<Mensaje>();
            try
            {
                Reto reto = ConfigAutomapper.mapper.Map<Reto>(request);
                var retos = RetoAccess.CrearReto(reto);

                mensajes.Add(new Mensaje("1", "Registro Creado Correctamente"));

                return new RetoResponse(request, retos, mensajes);

            }
            catch (Exception ex)
            {

                //Captura de errores
                mensajes.Add(new Mensaje(null, ex.Message));
                return new RetoResponse(null, false, mensajes);
            }
        }

        public static RetoMiembroResponse CrearRetoMiembro(RetoMiembroModel request)
        {
            var mensajes = new List<Mensaje>();
            try
            {
                RetoMiembro reto = new RetoMiembro();
                reto.MiembroId = request.MiembroModel.Id;
                reto.RetoId = request.RetoModel.Id;
                reto.TiempoLimite = request.TiempoLimite;
                var retoMiembro = RetoMiembroAccess.CrearRetoMiembro(reto);
                mensajes.Add(new Mensaje("1", "Registro Creado Correctamente"));
                return new RetoMiembroResponse(request, retoMiembro, mensajes);
            }
            catch (Exception ex)
            {

                //Captura de errores
                mensajes.Add(new Mensaje(null, ex.Message));
                return new RetoMiembroResponse(null, false, mensajes);
            }
        }

        public static RetoMiembroResponse EliminarRetoMiembro(RetoMiembroModel request)
        {
            var mensajes = new List<Mensaje>();
            try
            {
                RetoMiembro reto = new RetoMiembro();
                reto.MiembroId = request.MiembroModel.Id;
                reto.RetoId = request.RetoModel.Id;
                reto.TiempoLimite = request.TiempoLimite;
                var retoMiembro = RetoMiembroAccess.EliminarRetoMiembro(reto);
                mensajes.Add(new Mensaje("1", "Registro Creado Correctamente"));
                return new RetoMiembroResponse(request, retoMiembro, mensajes);
            }
            catch (Exception ex)
            {

                //Captura de errores
                mensajes.Add(new Mensaje(null, ex.Message));
                return new RetoMiembroResponse(null, false, mensajes);
            }
        }

        public static RetoResponse EliminarReto(RetoModel request)
        {
            var mensajes = new List<Mensaje>();
            try
            {
                Reto reto = ConfigAutomapper.mapper.Map<Reto>(request);
                var retos = RetoAccess.EliminarReto(reto);

                mensajes.Add(new Mensaje("1", "Registro Eliminado Correctamente"));

                return new RetoResponse(request, retos, mensajes);

            }
            catch (Exception ex)
            {

                //Captura de errores
                mensajes.Add(new Mensaje(null, ex.Message));
                return new RetoResponse(null, false, mensajes);
            }
        }

        public static PuntajeResponse CrearPuntaje(PuntajeModel request)
        {
            var mensajes = new List<Mensaje>();
            try
            {
                Puntaje puntaje = ConfigAutomapper.mapper.Map<Puntaje>(request);
                var puntajes = PuntajeAccess.CrearPuntaje(puntaje);

                mensajes.Add(new Mensaje("1", "Registro Creado Correctamente"));

                return new PuntajeResponse(request, puntajes, mensajes);

            }
            catch (Exception ex)
            {
                //Captura de errores
                mensajes.Add(new Mensaje(null, ex.Message));
                return new PuntajeResponse(null, false, mensajes);
            }
        }

        public static PuntajesResponse ObtenerPuntajes()
        {
            var mensajes = new List<Mensaje>();
            try
            {
                PuntajeAccess.CalcularVencidos();
                var puntajes = PuntajeAccess.ObtenerPuntajes();
                List<PuntajeModel> puntajesModel = ConfigAutomapper.mapper.Map<List<PuntajeModel>>(puntajes);

                mensajes.Add(new Mensaje("1", "Registro Consultado Correctamente"));

                return new PuntajesResponse(puntajesModel, true, mensajes);

            }
            catch (Exception ex)
            {
                //Captura de errores
                mensajes.Add(new Mensaje(null, ex.Message));
                return new PuntajesResponse(null, false, mensajes);
            }
        }



        public static RetoMiembrosResponse ObtenerRetoMiembros()
        {
            var mensajes = new List<Mensaje>();
            try
            {
                List<RetoMiembro> retoMiembros = RetoMiembroAccess.ObtenerRetoMiembros();
                List<RetoMiembroModel> listaRetoMiembroModel = new List<RetoMiembroModel>();
                foreach (var item in retoMiembros)
                {
                    RetoMiembroModel retoMiembroModel = new RetoMiembroModel();
                    RetoModel retoModel = ConfigAutomapper.mapper.Map<RetoModel>(item.Reto);
                    MiembroModel miembroModel = ConfigAutomapper.mapper.Map<MiembroModel>(item.Miembro);
                    retoMiembroModel.RetoModel = retoModel;
                    retoMiembroModel.MiembroModel = miembroModel;
                    retoMiembroModel.TiempoLimite = item.TiempoLimite;
                    listaRetoMiembroModel.Add(retoMiembroModel);
                }
                mensajes.Add(new Mensaje("1", "Consulta Realizada Correctamente"));
                return new RetoMiembrosResponse(listaRetoMiembroModel, true, mensajes);
            }
            catch (Exception ex)
            {

                //Captura de errores
                mensajes.Add(new Mensaje(null, ex.Message));
                return new RetoMiembrosResponse(null, false, mensajes);
            }
        }
    }
}
