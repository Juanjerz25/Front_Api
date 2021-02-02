using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStorage.DataAccess
{
    public class DojoMiembroAccess
    {
        public static List<DojoMiembro> ObtenerDojoMiembros()
        {
            try
            {
                using (var dbContextScope = new DojoApplicationEntities(false))
                {
                    return dbContextScope.DojoMiembro.Include("Miembro").Include("Dojo").ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool CrearDojoMiembro(DojoMiembro dojoMiembro)
        {
            bool response = false;
            try
            {
                using (var dbContextScope = new DojoApplicationEntities(false))
                {
                    dbContextScope.DojoMiembro.Add(dojoMiembro);
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

        public static bool EditarDojoMiembro(DojoMiembro dojoMiembro)
        {
            bool response = false;
            try
            {
                using (var dbContextScope = new DojoApplicationEntities(false))
                {
                    var dojoMiembroConsulta = dbContextScope.DojoMiembro.Where(x => x.Id == dojoMiembro.Id).FirstOrDefault();
                    if(dojoMiembroConsulta!= null)
                    {
                        dojoMiembroConsulta = dojoMiembro;
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

        public static bool EliminarDojoMiembro(DojoMiembro dojoMiembro)
        {
            bool response = false;
            try
            {
                using (var dbContextScope = new DojoApplicationEntities(false))
                {
                    var dojoMiembroConsulta = dbContextScope.DojoMiembro.Where(x => x.DojoId==dojoMiembro.DojoId && x.MiembroId==dojoMiembro.MiembroId).FirstOrDefault();
                    if (dojoMiembroConsulta != null)
                    {
                        dbContextScope.DojoMiembro.Remove(dojoMiembroConsulta);
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
