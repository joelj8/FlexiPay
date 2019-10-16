using FlexiPay.DAL;
using FlexiPay.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlexiPay.Services
{
    
    public  class DataTarjeta
    {
        private readonly DBFlexiPayContext dbcontext;

        public DataTarjeta()
        {
            dbcontext = new DBFlexiPayContext();
        }

        public List<Tarjeta> GetTarjetas()
        {
            var result = dbcontext.Tarjetas.Where(x => !x.Inactivo).ToList();
            return result;
        }

        public Tarjeta GetTarjeta(int id)
        {
            var result = dbcontext.Tarjetas.FirstOrDefault(x => !x.Inactivo && x.TarjetaID == id);
            return result;
        }

        public bool InsertTarjeta(Tarjeta tarjetanew)
        {
            bool result = false;
            try
            {
                dbcontext.Tarjetas.Add(tarjetanew);
                dbcontext.SaveChanges();
                result = true;
            }
            catch (Exception)
            {
                result = false;
            }

            return result;
        }

        public bool UpdateTarjeta(Tarjeta tarjetaupd)
        {
            bool result = false;
            try
            {
                Tarjeta TarjetaUpdate = GetTarjeta(tarjetaupd.TarjetaID);
                if (TarjetaUpdate != null)
                {
                    TarjetaUpdate.TarjetaNumero = tarjetaupd.TarjetaNumero;
                    dbcontext.Entry(TarjetaUpdate).State = System.Data.Entity.EntityState.Modified;
                    dbcontext.SaveChanges();
                    result = true;
                }
            }
            catch (Exception)
            {

                result = false;
            }
            return result;
        }

        public bool DeleteTarjeta(int id)
        {
            bool result = false;
            try
            {
                Tarjeta TarjetaDelete = GetTarjeta(id);
                if (TarjetaDelete != null)
                {
                    TarjetaDelete.Inactivo = true;
                    dbcontext.Entry(TarjetaDelete).State = System.Data.Entity.EntityState.Modified;
                    dbcontext.SaveChanges();
                    result = true;
                }
            }
            catch (Exception)
            {

                result = false;
            }
            return result;
        }
    }
}
