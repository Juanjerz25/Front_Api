using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStorage.DataAccess
{
    public class MiembroAccess
    {
        public static List<Miembro> ObtenerMiembros()
        {
            try
            {
                using (var dbContextScope = new DojoApplicationEntities(false))
                {
                    return dbContextScope.Miembro.ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool CrearMiembro(Miembro miembro)
        {
            bool response = false;
            try
            {
                using (var dbContextScope = new DojoApplicationEntities(false))
                {
                    dbContextScope.Miembro.Add(miembro);
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

        public static bool EditarMiembro(Miembro miembro)
        {
            bool response = false;
            try
            {
                using (var dbContextScope = new DojoApplicationEntities(false))
                {
                    var miembroConsulta = dbContextScope.Miembro.Where(x => x.Id == miembro.Id).FirstOrDefault();
                    if(miembroConsulta!= null)
                    {
                        miembroConsulta = miembro;
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

        public static bool EliminarMiembro(Miembro miembro)
        {
            bool response = false;
            try
            {
                using (var dbContextScope = new DojoApplicationEntities(false))
                {
                    var miembroConsulta = dbContextScope.Miembro.Where(x => x.Id == miembro.Id).FirstOrDefault();
                    if (miembroConsulta != null)
                    {
                        dbContextScope.Miembro.Remove(miembroConsulta);
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
