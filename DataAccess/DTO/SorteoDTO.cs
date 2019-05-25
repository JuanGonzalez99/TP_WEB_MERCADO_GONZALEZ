using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace AccesoDatos
{
    public class SorteoDTO
    {
        int IdSorteo { get; set; }
        int IdPremio { get; set; }
        int IdCliente { get; set; }
        int IdVoucher { get; set; }

        private ModelContexto db = new ModelContexto();


    }
}
