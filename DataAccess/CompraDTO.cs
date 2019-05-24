using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos
{
    public class CompraDTO
    {
        int IdCompra { get; set; }
        string CodigoPromocional { get; set; } // Se genera Fecha+horaMinutosSegundos+IdCompra
        bool estado { get; set; } // 0 no valido 1 usado
    }
}
