using FlexiPay.Models.Master;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlexiPay.Models.Model
{
    public class Tarjeta
    {
        [Key]
        public int TarjetaID { get; set; }

        [Column("TarjetaNumero", TypeName = "varchar")]
        [DisplayName("Numero de Tarjeta")]
        [MaxLength(20)]
        public string TarjetaNumero { get; set; }
        public bool Inactivo { get; set; }
        //public string FechaVence { get; set; }
        //public string SecretCode { get; set; }

        [NotMapped]
        public virtual List<Factura> Facturas { get; set; }
        
        
    }
}
