using DataStorage.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DataStorage.DataAccess
{
    public static class DojoAccess
    {
        public static List<Dojo> ObtenerDojos()
        {
            try
            {
                using (var dbContextScope = new DojoApplicationEntities(true))
                {
                    return dbContextScope.Dojo.ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool CrearDojo(Dojo dojo)
        {
            bool response = false;
            try
            {
                using (var dbContextScope = new DojoApplicationEntities(false))
                {
                    dbContextScope.Dojo.Add(dojo);
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

        public static bool EditarDojo(Dojo dojo)
        {
            bool response = false;
            try
            {
                using (var dbContextScope = new DojoApplicationEntities(false))
                {
                    var dojoConsulta = dbContextScope.Dojo.Where(x => x.Id == dojo.Id).FirstOrDefault();
                    if(dojoConsulta!= null)
                    {
                        //dojoConsulta.Nombre = string.IsNullOrEmpty(dojo.Nombre) ? dojoConsulta.Nombre : dojo.Nombre;
                        FrammeworkTypeUtility.SetProperties(dojo, dojoConsulta);
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

        public static bool EliminarDojo(Dojo dojo)
        {
            bool response = false;
            try
            {
                using (var dbContextScope = new DojoApplicationEntities(false))
                {
                    var dojoConsulta = dbContextScope.Dojo.Where(x => x.Id == dojo.Id).FirstOrDefault();
                    if (dojoConsulta != null)
                    {
                        dbContextScope.Dojo.Remove(dojoConsulta);
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
