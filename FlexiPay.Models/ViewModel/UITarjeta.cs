using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlexiPay.Models.ViewModel
{
    public class UITarjeta
    {
        public int ID { get; set; }

        [DisplayName("Numero de Tarjeta")]
        [StringLength(20, MinimumLength = 1, ErrorMessage = "Numero de Tarjeta debe tener 1 caracter mínimo y 20 caracteres máximo")]
        public string TarjetaNumero { get; set; }

    }
}
