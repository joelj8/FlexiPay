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
    public class Servicio
    {
        [Key]
        public int ServicioID { get; set; }

        [Column("ServicioName", TypeName = "varchar")]
        [DisplayName("Servicio")]
        [MaxLength(50)]
        public string ServicioName { get; set; }

        [Column("ServicioContrato", TypeName = "varchar")]
        [DisplayName("Contrato")]
        [MaxLength(50)]
        public string ServicioContrato { get; set; }

        [Column("ServicioTelefono", TypeName = "varchar")]
        [DisplayName("Telefono")]
        [MaxLength(20)]
        public string ServicioTelefono { get; set; }
        public bool Inactivo { get; set; } = false;

        [NotMapped]
        public virtual List<Factura> Facturas { get; set; }

    }
}
