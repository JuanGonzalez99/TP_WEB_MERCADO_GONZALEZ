using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    [Table("Clientes")]
    public class Cliente
    {
        [Key]
        public int Clienteid { get; set; } // Codigo unico de cliente asignado por la BD
        
        [Required]
        [MaxLength(20)]
        public string Documento { get; set; } // DNI dependiento de TipoDocumento

        [Required]
        [MaxLength(100)]
        public string Nombre { get; set; }

        [Required]
        [MaxLength(100)]
        public string Apellido { get; set; }

        [MaxLength(50)]
        public string Localidad { get; set; }

        [MaxLength(50)]
        public string Provincia { get; set; }

        [MaxLength(100)]
        public string Direccion { get; set; }

    }
}
