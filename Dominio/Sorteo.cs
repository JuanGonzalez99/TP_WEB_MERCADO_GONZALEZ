using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    [Table("Sorteo")]
    public class Sorteo    
    {
        [Key]
        public int IdSorteo { get; set; }

        public Premios premios { get; set; }
        public int IdPremios { get; set; }

        public Clientes clientes { get; set; }
        public int IdClientes { get; set; }

        public Compra compra { get; set; }
        public int IdCompra { get; set; }
    }
}
