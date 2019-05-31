using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos;

namespace Negocio
{
    public class PremioNegocio
    {
        public int IdPremio { get; set; }
        public string Descripcion { get; set; }
        public string URL { get; set; }

        private PremioNegocio(PremioNegocio pr)
        {
            this.IdPremio = pr.IdPremio;
            this.Descripcion = pr.Descripcion;
            this.URL = pr.URL;
        }

        public PremioNegocio()
        {
        }

        // Retorna una lista con todos los premios que existen en la base
        // si no los hay retorna null
        public List<PremioNegocio> GetPremios()
        {
            List<PremioDTO> premiolist = new List<PremioDTO>();
            List<PremioNegocio> premioReturn = new List<PremioNegocio>();
            PremioDTO obj = new PremioDTO();
            premiolist = obj.GetPremios();

            if (premiolist != null)
            {
                foreach(var foo in premiolist)
                {
                    this.IdPremio = foo.IdPremio;
                    this.Descripcion = foo.Descripcion;
                    this.URL = foo.URL;
                    premioReturn.Add(new PremioNegocio(this));
                }
                return premioReturn;
            }

            return null;
        }

        // Busca el premio por iD devuelve true si lo encuentra
        public bool GetPremioByID()
        {
            PremioDTO premio = new PremioDTO();
            premio.IdPremio = this.IdPremio;
            if (premio.GetPremioByID())
            {
                this.Descripcion = premio.Descripcion;
                this.URL = premio.URL;
                return true;
            }
            else
            {
                return false;
            }
            return false;
        }
    }
}
