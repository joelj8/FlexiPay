using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlexiPay.Models.Master
{
    public interface ITarjeta
    {
        int ID { get; set; }
        string TarjetaNumero { get; set; }
        string FechaVence { get; set; }
        string SecretCode { get; set; }
    }
}
