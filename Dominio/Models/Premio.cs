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
    public class Premio
    {
        [Key]
        public int IdPremio { get; set; }

        [Required]
        [MaxLength(100)]
        public string Descripcion { get; set; }

        [Required]
        [MaxLength(255)]
        public string URL { get; set; }
    }
}
