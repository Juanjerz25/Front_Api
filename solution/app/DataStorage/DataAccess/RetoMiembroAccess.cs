using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStorage.DataAccess
{
    public class RetoMiembroAccess
    {
        public static List<RetoMiembro> ObtenerRetoMiembros()
        {
            try
            {
                using (var dbContextScope = new DojoApplicationEntities(false))
                {
                    return dbContextScope.RetoMiembro.Include("Reto").Include("Miembro").ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool CrearRetoMiembro(RetoMiembro retoMiembro)
        {
            bool response = false;
            try
            {
                using (var dbContextScope = new DojoApplicationEntities(false))
                {
                    dbContextScope.RetoMiembro.Add(retoMiembro);
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

        public static bool EditarRetoMiembro(RetoMiembro retoMiembro)
        {
            bool response = false;
            try
            {
                using (var dbContextScope = new DojoApplicationEntities(false))
                {
                    var retoMiembroConsulta = dbContextScope.RetoMiembro.Where(x => x.Id == retoMiembro.Id).FirstOrDefault();
                    if(retoMiembroConsulta!= null)
                    {
                        retoMiembroConsulta = retoMiembro;
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

        public static bool EliminarRetoMiembro(RetoMiembro retoMiembro)
        {
            bool response = false;
            try
            {
                using (var dbContextScope = new DojoApplicationEntities(false))
                {
                    var retoMiembroConsulta = dbContextScope.RetoMiembro.Where(x => x.RetoId == retoMiembro.RetoId && x.MiembroId == retoMiembro.MiembroId).FirstOrDefault();
                    if (retoMiembroConsulta != null)
                    {
                        dbContextScope.RetoMiembro.Remove(retoMiembroConsulta);
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
