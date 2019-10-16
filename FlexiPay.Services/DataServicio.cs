using FlexiPay.DAL;
using FlexiPay.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlexiPay.Services
{
    public class DataServicio
    {
        private readonly DBFlexiPayContext dbcontext;

        public DataServicio()
        {
            dbcontext = new DBFlexiPayContext();
        }

        public List<Servicio> GetServicios()
        {
            var result = dbcontext.Servicios.Where(x=> !x.Inactivo).ToList();
            return result;
        }

        public Servicio GetServicio(int id)
        {
            /*return dbcontext.Servicios.Where(x => x.ServicioID == id && !x.Inactivo ).FirstOrDefault();*/
            return dbcontext.Servicios.FirstOrDefault(x => x.ServicioID == id && !x.Inactivo);
            
        }

        public bool InsertServicio(Servicio servicioadd)
        {
            bool result;
            try
            {
                dbcontext.Servicios.Add(servicioadd);
                dbcontext.SaveChanges();
                result = true;
            }
            catch (Exception)
            {
                result = false;
            }

            return result;
        }

        public bool UpdateServicio(Servicio servicioupd)
        {
            bool result = false;
            try
            {
                /*dbcontext.Servicios.Where(x => x.ServicioID == servicioupd.ServicioID && !x.Inactivo).FirstOrDefault();*/
                Servicio ServicioUpdate = GetServicio(servicioupd.ServicioID);
                    
                if (ServicioUpdate != null)
                {
                    ServicioUpdate.ServicioName = servicioupd.ServicioName;
                    ServicioUpdate.ServicioContrato = servicioupd.ServicioContrato;
                    ServicioUpdate.ServicioTelefono = servicioupd.ServicioTelefono;
                    dbcontext.Entry(ServicioUpdate).State = System.Data.Entity.EntityState.Modified;
                    dbcontext.SaveChanges();
                    result = true;
                }
                
            }
            catch (Exception)
            {
                // loggear el error
                
            }
            return result;
        }

        public bool DeleteServicio(int id)
        {
            bool result;
            try
            {
                /*dbcontext.Servicios.Where(x => x.ServicioID == id && !x.Inactivo).FirstOrDefault();*/
                Servicio ServicioUpdate = GetServicio(id);
                if (ServicioUpdate != null)
                {
                    ServicioUpdate.Inactivo = true;
                    dbcontext.Entry(ServicioUpdate).State = System.Data.Entity.EntityState.Modified;
                    dbcontext.SaveChanges();
                }
                result = true;
            }
            catch (Exception)
            {

                result = false;
            }
            return result;
        }
    }
}
