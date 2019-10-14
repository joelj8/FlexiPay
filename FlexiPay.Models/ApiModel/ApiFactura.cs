using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FlexiPay.Models.ApiModel 
{
    public class ApiFactura
    {
        public int ID { get; set; }
        public int ServicioID { get; set; }
        public ApiServicio Servicio { get; set; }
        public decimal Monto { get; set; }
        public decimal Pagado { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime FechaLimite { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime FechaPago { get; set; }
        public string AprobacionNumero { get; set; }
        public int TarjetaID { get; set; }
        public ApiTarjeta Tarjeta { get; set; }
        public string Comentario { get; set; }
        public bool Inactivo { get; set; }
    }
}