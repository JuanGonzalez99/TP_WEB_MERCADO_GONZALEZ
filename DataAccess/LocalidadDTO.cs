using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
namespace AccesoDatos
{
    public class LocalidadDTO
    {
        public int Localidadid { get; set; }
        public string Descripcion { get; set; }
        public int ProvinciaId { get; set; }

        // Devuelvo todas las provincias
        public List<LocalidadDTO> GetLoalidad()
        {

            using (var db = new ModelContexto())
            {
                return (
                    from lol in db.Localidad
                    select new LocalidadDTO
                    {
                        Localidadid = lol.Localidadid,
                        Descripcion = lol.Descripcion

                    }).ToList();
            }
        }
        // Devolve las localidades para una provincia
        public List<LocalidadDTO> GetLoalidadbyprovinciaID(int provinciaId)
        {
            List<LocalidadDTO> lista = new List<LocalidadDTO>();
            using (var db = new ModelContexto())
            {

                var query = from lol in db.Localidad select new LocalidadDTO
                {
                    Localidadid = lol.Localidadid,
                    Descripcion = lol.Descripcion,
                    ProvinciaId = lol.ProvinciaId
                };
                List<LocalidadDTO> localidad = query.ToList<LocalidadDTO>();
                foreach (var foo in localidad)
                {
                    if (foo.ProvinciaId == provinciaId)
                    {
                        lista.Add(foo);
                    }
                }
                return lista;
            }
        }

        public void GetLoalidadbyID(int localidadID)
        {
            List<LocalidadDTO> lista = new List<LocalidadDTO>();
            using (var db = new ModelContexto())
            {

                var query = from lol in db.Localidad
                            select new LocalidadDTO
                            {
                                Localidadid = lol.Localidadid,
                                Descripcion = lol.Descripcion,
                                ProvinciaId = lol.ProvinciaId
                            };
                List<LocalidadDTO> localidad = query.ToList<LocalidadDTO>();
                foreach (var foo in localidad)
                {
                    if (foo.Localidadid== localidadID)
                    {
                        this.Localidadid = foo.Localidadid;
                        this.ProvinciaId = foo.ProvinciaId;
                        this.Descripcion = foo.Descripcion;
                    }
                }
            }
        }
    }
}
