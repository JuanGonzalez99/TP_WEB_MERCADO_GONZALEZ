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

        [Required]
        public int IdPremio { get; set; }
        public Premio Premio { get; set; }

        [Required]
        public int Clienteid { get; set; }
        public Cliente Cliente { get; set; }

        [Required]
        public int IdVoucher { get; set; }
        public Voucher Voucher { get; set; }
       
    }
}
