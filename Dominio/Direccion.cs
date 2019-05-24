using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    [Table("Direccion")]
    public class Direccion
    {
        [Key]
        public int Direccionid { get; set; }

        public Provincia Provincia { get; set; }
        public int Provinciaid { get; set; }

        public int Localidadid { get; set; }
        public Localidad Localidad { get; set; }
        
        

        [Required]
        [MaxLength(50)]
        public string Calle { get; set; }

        public int Altura { get; set; }
        public int Piso { get; set; }
    }
}
