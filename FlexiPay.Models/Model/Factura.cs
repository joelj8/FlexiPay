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
    public class Factura
    {
        [Key]
        public int ID { get; set; }

        [ForeignKey("Servicio")]
        [Required(ErrorMessage = "Please add a Service")]
        public int ServicioID { get; set; }
        public Servicio Servicio { get; set; }
        
        [Required(ErrorMessage = "Please add the amount")]
        public decimal Monto { get; set; }

        public decimal? Pagado { get; set; }
        
        [DisplayName("Fecha Limite")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage ="Please add the Date")]
        public DateTime FechaLimite { get; set; }

        [DisplayName("Fecha de Pago")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? FechaPago { get; set; }

        [Column("Aprobacion", TypeName = "varchar")]
        [DisplayName("Numero Aprobación")]
        [MaxLength(20)]
        [Required(AllowEmptyStrings = true)]
        public string AprobacionNumero { get; set; } = "";

        [ForeignKey("Tarjeta")]
        public int? TarjetaID { get; set; }
        public Tarjeta Tarjeta { get; set; }

        [Column("Coment", TypeName = "ntext")]
        [DisplayName("Comentario")]
        [Required(AllowEmptyStrings = true)]
        public string Comentario { get; set; } = "";
        public bool Inactivo { get; set; }



        


    }
}
