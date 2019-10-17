using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlexiPay.Models.ViewModel
{
    public class UIServicio
    {
        public int ID { get; set; }

        [StringLength(50, MinimumLength = 1, ErrorMessage = "Servicio debe tener 1 caracter mínimo y 50 caracteres máximo")]
        public string Servicio { get; set; }
        
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Contrato debe tener 1 caracter mínimo y 50 caracteres máximo")]
        public string Contrato { get; set; }

        [StringLength(20, MinimumLength = 1, ErrorMessage = "Telefono debe tener 1 caracter mínimo y 20 caracteres máximo")]
        public string Telefono { get; set; }
        
        
    }
}
