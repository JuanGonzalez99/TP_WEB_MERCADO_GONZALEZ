using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos
{
    public class PersonaDTO 
    {


            public string nombre { get; set; } // nombre 
            public string Apellido { get; set; } // apellido
            public int tipoDocumento { get; set; } // 1 - Cuit 2 - DNI 
            public string Documento { get; set; } // puede set cuit y dni dependiento de tipodocumento
        
    }
}
