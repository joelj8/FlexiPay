using FlexiPay.DAL;
using FlexiPay.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlexiPay.Services
{
    public class DataFactura
    {
        private readonly DBFlexiPayContext dbcontext;

        public DataFactura()
        {
            dbcontext = new DBFlexiPayContext();
        }

        public List<Factura> GetFacturas()
        {
            //return dbcontext.Facturas.Where(x => !x.Inactivo).ToList();
            return dbcontext.Facturas.Include("Servicio").Include("Tarjeta").Where(x => !x.Inactivo).ToList();
            
        }

        public Factura GetFactura(int id)
        {
            //return dbcontext.Facturas.Include("Servicio").Include("Tarjeta").FirstOrDefault(x => x.ID == id);
            return dbcontext.Facturas.Include("Servicio").Include("Tarjeta").FirstOrDefault(x => x.ID == id);
        }

        public bool InsertFactura(Factura facturanew)
        {
            bool result=false;
            try
            {
                facturanew.FechaPago = null;
                dbcontext.Facturas.Add(facturanew);
                dbcontext.SaveChanges();
                result = true;
            }
            catch (Exception ex)
            {

                result = false;
            }

            return result;
        }

        public bool UpdateFactura(Factura facturaupd)
        {
            bool result = false;
            try
            {
                Factura facturaUpdate = GetFactura(facturaupd.ID);
                
                facturaUpdate.FechaLimite = facturaupd.FechaLimite;
                facturaUpdate.FechaPago = facturaupd.FechaPago;
                facturaUpdate.Monto = facturaupd.Monto;
                facturaUpdate.Pagado = facturaupd.Pagado;
                facturaUpdate.ServicioID = facturaupd.ServicioID;
                facturaUpdate.TarjetaID = facturaupd.TarjetaID;
                facturaUpdate.AprobacionNumero = facturaupd.AprobacionNumero;
                facturaUpdate.Comentario = facturaupd.Comentario;

                dbcontext.Entry(facturaUpdate).State = System.Data.Entity.EntityState.Modified;
                dbcontext.SaveChanges();
                result = true;
            }
            catch (Exception)
            {

                result = false;
            }

            return result;
        }

        public bool DeleteFactura(int id)
        {
            bool result = false;
            try
            {
                Factura facturaDelete = GetFactura(id);
                facturaDelete.Inactivo = true;

                dbcontext.Entry(facturaDelete).State = System.Data.Entity.EntityState.Modified;
                dbcontext.SaveChanges();
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
