using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    [Table("Telefono")]
    public class Telefono
    {
        [Key]
        public int Telefonoid { get; set; }
        [Required]
        [MaxLength(50)]
        public string numeroCasa { get; set; }
        [Required]
        [MaxLength(50)]
        public string numeroCelular { get; set; }
    }
}
