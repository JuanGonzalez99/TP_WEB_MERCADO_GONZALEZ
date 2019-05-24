using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Persona
    {
        [Required]
        [MaxLength(100)]
        public string nombre { get; set; } // nombre 

        [Required]
        [MaxLength(100)]
        public string Apellido { get; set; } // apellido

        [Required]
        [MaxLength(100)]
        public string Descripcion { get; set; } // Descripcion

        [Required]
        [MaxLength(100)]
        public string Documento { get; set; } // dni dependiento de tipodocumento

        public virtual Direccion Direccion { get; set; }
        public int Direccionid { get; set; }

        public Telefono Telefono { get; set; }
        public int TelefonoId { get; set; }
    }
}
