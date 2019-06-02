using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    [Table("Voucher")]
    public class Voucher
    {
        [Key]
        public int IdVoucher { get; set; }

        [Required]
        [MaxLength(100)]
        public string CodigoPromocional { get; set; }
        
        public bool Estado { get; set; } // 1 = usado
    }
}
