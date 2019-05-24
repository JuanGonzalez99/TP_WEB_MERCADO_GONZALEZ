using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    [Table("Provincia")]
    public class Provincia
    {
        [Key]
        public int Provinciaid { get; set; }

        [Required]
        [MaxLength(100)]
        public string nombre { get; set; }

        public List<Localidad> Localidad;
    }
}
