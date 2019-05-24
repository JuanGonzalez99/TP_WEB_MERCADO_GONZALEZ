using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    [Table("Compra")]
    public class Compra
    {
        [Key]
        public int IdCompra { get; set; }
        [Required]
        [MaxLength(100)]
        public string CodigoPromocional { get; set; } // Se genera Fecha+horaMinutosSegundos+IdCompra
        public bool estado { get; set; } // 0 no valido 1 usado
    }
}
