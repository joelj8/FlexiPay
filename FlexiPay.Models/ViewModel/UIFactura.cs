using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlexiPay.Models.ViewModel
{
    public class UIFactura
    {
        public int ID { get; set; }

        [DisplayName("Servicio")]
        public int ServicioID { get; set; }
        public UIServicio Servicio { get; set; }
        public decimal Monto { get; set; }
        public decimal Pagado { get; set; }

        [DisplayName("Fecha Limite")]
        public DateTime FechaLimite { get; set; }
        public DateTime FechaPago { get; set; }

        [DisplayName("Aprobación Número")]
        public string AprobacionNumero { get; set; }

        [DisplayName("Tarjeta")]
        public int TarjetaID { get; set; }
        public UITarjeta Tarjeta { get; set; }
        public string Comentario { get; set; }
        public bool Inactivo { get; set; }
    }
}
