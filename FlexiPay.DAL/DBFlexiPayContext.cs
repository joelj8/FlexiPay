using FlexiPay.Models.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlexiPay.DAL
{
    public class DBFlexiPayContext: DbContext 
    {
        public DBFlexiPayContext(): base("FlexiPayDB")
        {

        }

        public virtual DbSet<Tarjeta> Tarjetas { get; set; }
        public virtual DbSet<Servicio> Servicios { get; set; }
        public virtual DbSet<Factura> Facturas { get; set; }

    }
}
