using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace AccesoDatos
{
    public class PremioDTO
    {
        public int IdPremio { get; set; }
        public string Descripcion { get; set; }
        public string URL { get; set; }

        private ModelContexto db = new ModelContexto();

        // Devuelve una lista con los premios 
        public List<PremioDTO> GetPremio()
        {
            using (db)
            {
                return (
                    from premio in db.Premios
                    select new PremioDTO
                    {
                        IdPremio = premio.IdPremio,
                        Descripcion = premio.Descripcion,
                        URL = premio.URL
                    }).ToList();
            }
        }

        // Si existe el premio con ese id devuelvo true y lo cargo el objeto
        // Si no existe devuelvo false y cargo null
        public bool GetPremioByID()
        {
            using (db)
            {
                var query = from Premio in db.Premios select Premio;
                List<Premio> premio = query.ToList<Premio>();
                foreach (var foo in premio)
                {
                    if (foo.IdPremio == this.IdPremio)
                    {
                        this.Descripcion = foo.Descripcion;
                        this.URL = foo.URL;
                        return true;
                    }


                }

                this.Descripcion = null;
                this.URL = null;
                return false;
            }
        }
    }
}