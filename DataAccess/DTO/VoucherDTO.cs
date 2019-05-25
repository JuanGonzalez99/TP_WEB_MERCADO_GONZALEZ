using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos
{
    public class VoucherDTO
    {
        int IdVoucher { get; set; }
        string CodigoPromocional { get; set; } // Se genera Fecha+horaMinutosSegundos+IdVoucher
        bool Estado { get; set; } // 0 no valido 1 usado
    }
}
