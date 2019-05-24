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
    public class Clientes : Persona
    {
        [Key]
        public int Clienteid { get; set; } // Codigo unico de cliente asignado por la BD
        
    }
}
