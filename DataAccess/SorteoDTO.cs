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
        int IdPremios { get; set; }
        int IdClientes { get; set; }
        int IdCompra { get; set; }

        private ModelContexto db = new ModelContexto();


    }
}
