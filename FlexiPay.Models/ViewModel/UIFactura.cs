using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlexiPay.Models.ViewModel
{
    public class UIFactura
    {
        private decimal _montoDecimal = 0;
        private DateTime _valorDateTime ;
        public int ID { get; set; }

        [DisplayName("Servicio")]
        public int ServicioID { get; set; }
        public UIServicio Servicio { get; set; }

        [DisplayFormat(DataFormatString = "{0:#,###0.00}", ApplyFormatInEditMode = true)]
        public decimal Monto { get; set; }

        [DisplayName("Monto")]
        [Required(ErrorMessage = "Please add the amount")]
        public string MontoText { get; set; } = "0.00";

        [DisplayFormat(DataFormatString = "{0:#,###0.00}", ApplyFormatInEditMode = true)]
        public decimal Pagado { get; set; }

        [DisplayName("Pagado")]
        [Required(ErrorMessage = "Please add the payment")]
        
        public string PagadoText { get; set; } = "0.00";

        [DisplayName("Fecha Limite")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime FechaLimite { get; set; }

        [DisplayName("Fecha Limite")]
        [Required(ErrorMessage = "Please add the invoice date")]
        public string FechaLimiteText { get; set; }

        [DisplayName("Fecha Pago")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? FechaPago { get; set; }

        [DisplayName("Fecha Pago")]
        [Required(ErrorMessage = "Please add the payment date")]
        public string FechaPagoText { get; set; }

        [DisplayName("Número Aprobación")]
        [StringLength(20, MinimumLength = 0, ErrorMessage = "Número Apobración 20 caracteres máximo")]
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
            this.FechaLimiteText = this.FechaLimite.ToString("dd'/'MM'/'yyyy");
            this.FechaPagoText = this.FechaPago == null ? "" : this.FechaPago.Value.ToString("dd'/'MM'/'yyyy");

        }
        public void setTextToValue()
        {
            decimal.TryParse(this.MontoText.Replace(",", ""), out _montoDecimal);
            this.Monto = _montoDecimal;
            decimal.TryParse(this.PagadoText.Replace(",", ""), out _montoDecimal);
            this.Pagado = _montoDecimal;
            _valorDateTime = DateTime.ParseExact(this.FechaLimiteText, "dd/MM/yyyy", CultureInfo.CurrentCulture);
            this.FechaLimite = _valorDateTime;
            if (this.FechaPagoText != null && this.FechaPagoText != string.Empty )
            {
                _valorDateTime = DateTime.ParseExact(this.FechaPagoText,"dd/MM/yyyy", CultureInfo.CurrentCulture);
                this.FechaPago = _valorDateTime;
            }
            
        }

    }
}
