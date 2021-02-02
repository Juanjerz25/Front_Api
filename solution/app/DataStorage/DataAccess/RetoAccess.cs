using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStorage.DataAccess
{
    public class RetoAccess
    {
        public static List<Reto> ObtenerRetos()
        {
            try
            {
                using (var dbContextScope = new DojoApplicationEntities(false))
                {
                    return dbContextScope.Reto.ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool CrearReto(Reto reto)
        {
            bool response = false;
            try
            {
                using (var dbContextScope = new DojoApplicationEntities(false))
                {
                    dbContextScope.Reto.Add(reto);
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

        public static bool EditarReto(Reto reto)
        {
            bool response = false;
            try
            {
                using (var dbContextScope = new DojoApplicationEntities(false))
                {
                    var retoConsulta = dbContextScope.Reto.Where(x => x.Id == reto.Id).FirstOrDefault();
                    if(retoConsulta!= null)
                    {
                        retoConsulta = reto;
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

        public static bool EliminarReto(Reto reto)
        {
            bool response = false;
            try
            {
                using (var dbContextScope = new DojoApplicationEntities(false))
                {
                    var retoConsulta = dbContextScope.Reto.Where(x => x.Id == reto.Id).FirstOrDefault();
                    if (retoConsulta != null)
                    {
                        dbContextScope.Reto.Remove(retoConsulta);
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
