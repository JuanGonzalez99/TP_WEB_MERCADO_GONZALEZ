using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
namespace AccesoDatos
{
    public class ClientesDTO
    {
        public int Clienteid { get; set; }
        public string Nombre { get; set; } // nombre 
        public string Apellido { get; set; } // apellido
        public int tipoDocumento { get; set; } // 1 - Cuit 2 - DNI 
        public string Documento { get; set; } // puede set cuit y dni dependiento de tipodocumento

        private ModelContexto db = new ModelContexto();


        public List<ClientesDTO> GetClient()
        {
            using (db)
            {
                return (
                    from client in db.Clientes
                    select new ClientesDTO
                    {
                        Clienteid = client.Clienteid,
                        Nombre = client.Nombre,
                        Apellido = client.Apellido,
                        Documento = client.Documento
                    }).ToList();
            }
        }

        public void GetClientByID(int idClient)
        {
            using (db)
            {
                var query = from Cliente in db.Clientes select Cliente;
                List<Cliente> clientes = query.ToList<Cliente>();
                foreach (var foo in clientes)
                {
                    if (foo.Clienteid == idClient)
                        Clienteid = foo.Clienteid;
                    Nombre = foo.Nombre;
                    Apellido = foo.Apellido;
                    Documento = foo.Documento;                    
                }
            }
        }


        public int addCliente()
        {
            Cliente cliente = new Cliente();
            cliente.Nombre = this.Nombre;
            cliente.Apellido = this.Apellido;
            cliente.Documento = this.Documento;
            using (var db = new ModelContexto())
            {
                db.Clientes.Add(cliente);
                db.SaveChanges();
                var query = from dir in db.Clientes
                            orderby dir.Clienteid descending
                            where  dir.Nombre == cliente.Nombre
                            && dir.Apellido == cliente.Apellido 
                            && dir.Documento == cliente.Documento
                            select dir;
                cliente = query.FirstOrDefault<Cliente>();

                if ( cliente.Nombre == this.Nombre
                    && cliente.Apellido == this.Apellido 
                    && cliente.Documento == this.Documento)
                {
                    return cliente.Clienteid;
                }
                else
                {
                    return -1;
                }
            }
        }

    }
}
