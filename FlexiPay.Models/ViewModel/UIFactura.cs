﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlexiPay.Models.ViewModel
{
    public class UIFactura
    {
        private decimal _montoDecimal = 0;
        public int ID { get; set; }

        [DisplayName("Servicio")]
        public int ServicioID { get; set; }
        public UIServicio Servicio { get; set; }

        [DisplayFormat(DataFormatString = "{0:#,###0.00}", ApplyFormatInEditMode = true)]
        public decimal Monto { get; set; }

        [DisplayName("Monto")]
        public string MontoText { get; set; } = "0.00";

        [DisplayFormat(DataFormatString = "{0:#,###0.00}", ApplyFormatInEditMode = true)]

        public decimal Pagado { get; set; }

        [DisplayName("Pagado")]
        public string PagadoText { get; set; } = "0.00";

        [DisplayName("Fecha Limite")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime FechaLimite { get; set; }

        [DisplayName("Fecha Pago")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? FechaPago { get; set; }

        [DisplayName("Aprobación Número")]
        public string AprobacionNumero { get; set; }

        [DisplayName("Tarjeta")]
        public int TarjetaID { get; set; }
        public UITarjeta Tarjeta { get; set; }
        public string Comentario { get; set; }
        public bool Inactivo { get; set; }

        public void setValueToText()
        {
            this.MontoText = this.Monto.ToString();
            this.PagadoText = this.Pagado.ToString();
            
        }

        public void setTextToValue()
        {
            decimal.TryParse(this.MontoText.Replace(",", ""), out _montoDecimal);
            this.Monto = _montoDecimal;
            decimal.TryParse(this.PagadoText.Replace(",", ""), out _montoDecimal);
            this.Pagado = _montoDecimal;
        }

    }
}
