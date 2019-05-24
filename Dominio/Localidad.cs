using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    [Table("Localidad")]
    public class Localidad
    {
        [Key]
        public int Localidadid { get; set; }

        [Required]
        [MaxLength(100)]
        public string Descripcion { get; set; }

        public Provincia provincia;    
        public int ProvinciaId { get; set; }
    }
}
