using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    [Table("Premios")]
    public class Premios
    {
        [Key]
        public int IdPremio { get; set; }
        [Required]
        [MaxLength(100)]
        public String Descripcion { get; set; }
    }
}
