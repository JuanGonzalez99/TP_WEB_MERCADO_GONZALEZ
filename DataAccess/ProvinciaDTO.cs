using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos
{
    public class ProvinciaDTO
    {       
        public int Provinciaid { get; set; }
        public string nombre { get; set; }

        public List<ProvinciaDTO> GetProvincia()
        {

            using (var db = new ModelContexto())
            {
                return (
                    from prov in db.Provincia
                    select new ProvinciaDTO
                    {
                        Provinciaid = prov.Provinciaid,
                        nombre = prov.nombre

                    }).ToList();
            }
        }

    }
}
