using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStorage.DataAccess
{
    public class PuntajeAccess
    {
        public static List<Puntaje> ObtenerPuntajes()
        {
            try
            {
                using (var dbContextScope = new DojoApplicationEntities(false))
                {                    
                    return dbContextScope.Puntaje.ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void CalcularVencidos()
        {
            using (var dbContextScope = new DojoApplicationEntities(false))
            {
                DateTime fecha = DateTime.Now;
                var listaVencidos = dbContextScope.RetoMiembro.Where(x => x.TiempoLimite <= fecha).ToList();
                foreach(var item in listaVencidos)
                {
                    Puntaje puntaje = new Puntaje();
                    puntaje.RetoMiembroId = item.Id;
                    puntaje.PuntajeReto = 0;
                    dbContextScope.Puntaje.Add(puntaje);
                    dbContextScope.SaveChanges();
                }
            }
        }

        public static bool CrearPuntaje(Puntaje puntaje)
        {
            bool response = false;
            try
            {
                using (var dbContextScope = new DojoApplicationEntities(false))
                {
                    dbContextScope.Puntaje.Add(puntaje);
                    dbContextScope.SaveChanges();
                    response = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return response;
        }

        public static bool EditarPuntaje(Puntaje puntaje)
        {
            bool response = false;
            try
            {
                using (var dbContextScope = new DojoApplicationEntities(false))
                {
                    var puntajeConsulta = dbContextScope.Puntaje.Where(x => x.Id == puntaje.Id).FirstOrDefault();
                    if(puntajeConsulta!= null)
                    {
                        puntajeConsulta = puntaje;
                        dbContextScope.SaveChanges();
                        response = true;
                    }                    
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;
        }

        public static bool EliminarPuntaje(Puntaje puntaje)
        {
            bool response = false;
            try
            {
                using (var dbContextScope = new DojoApplicationEntities(false))
                {
                    var puntajeConsulta = dbContextScope.Puntaje.Where(x => x.Id == puntaje.Id).FirstOrDefault();
                    if (puntajeConsulta != null)
                    {
                        dbContextScope.Puntaje.Remove(puntajeConsulta);
                        dbContextScope.SaveChanges();
                        response = true;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;
        }
    }
}
