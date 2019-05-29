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
        public string Documento { get; set; } // puede set cuit y dni dependiento de tipodocumento
        public string Localidad { get; set; }
        public string Provincia { get; set; }
        public string Direccion { get; set; }
        public string email { get; set; }

        // Retorna True si existe el cliente y lo carga en el objeto flase si no esta
        public bool GetClientByID()
        {
            using (db)
            {
                var query = from Cliente in db.Clientes select Cliente;
                List<Cliente> clientes = query.ToList<Cliente>();
                foreach (var foo in clientes)
                {
                    if (foo.Clienteid == this.Clienteid)
                    {
                        this.Nombre = foo.Nombre;
                        this.Apellido = foo.Apellido;
                        this.Direccion = foo.Direccion;
                        this.Localidad = foo.Localidad;
                        this.Provincia = foo.Provincia;
                        this.Documento = foo.Documento;
                        this.Localidad = foo.Localidad;
                        this.Provincia = foo.Provincia;
                        this.Direccion = foo.Direccion;
                        this.email = foo.email;
                        return true;
                    }
                }

                return false;
            }
        }

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
                        Documento = client.Documento,
                        Localidad = client.Localidad,
                        Provincia = client.Provincia,
                        Direccion = client.Direccion,
                        email = client.email
                    }).ToList();
            }
        }

        // Seteo cliente recibido por parametro
        public void SetClient(string nombre, string apellido, string documento, string localidad, string provincia, string direccion, string email)
        {
            this.Nombre = Nombre;
            this.Apellido = Apellido;
            this.Direccion = Direccion;
            this.Localidad = Localidad;
            this.Provincia = Provincia;
            this.Documento = Documento;
            this.Localidad = Localidad;
            this.Provincia = Provincia;
            this.Direccion = Direccion;
            this.email = email;
        }



        // Retorna true si el cliente existe y lo carga al objeto
        // Retorna false si el cliente no existe
        public bool GetClientByDocumento(string documento)
        {
            using (db)
            {
                var query = from Cliente in db.Clientes select Cliente;
                List<Cliente> clientes = query.ToList<Cliente>();
                foreach (var foo in clientes)
                {
                    if (foo.Documento == documento)
                    {
                        this.Clienteid = foo.Clienteid;
                        this.Nombre = foo.Nombre;
                        this.Apellido = foo.Apellido;
                        this.Direccion = foo.Direccion;
                        this.Localidad = foo.Localidad;
                        this.Provincia = foo.Provincia;
                        this.Documento = foo.Documento;
                        this.Localidad = foo.Localidad;
                        this.Provincia = foo.Provincia;
                        this.Direccion = foo.Direccion;
                        this.email = foo.email;
                        return true;
                    }
                }

                return false;
            }
        }

        //Retorna el ID del cliente creado, si hay error retorna -1 
        public int addCliente()
        {
            Cliente cliente = new Cliente();
            cliente.Nombre = this.Nombre;
            cliente.Apellido = this.Apellido;
            cliente.Documento = this.Documento;
            try
            {
                using (var db = new ModelContexto())
                {
                    db.Clientes.Add(cliente);
                    db.SaveChanges();
                    var query = from dir in db.Clientes
                                orderby dir.Clienteid descending
                                where dir.Nombre == cliente.Nombre
                                && dir.Apellido == cliente.Apellido
                                && dir.Documento == cliente.Documento
                                select dir;
                    cliente = query.FirstOrDefault<Cliente>();

                    if (cliente.Nombre == this.Nombre
                        && cliente.Apellido == this.Apellido
                        && cliente.Documento == this.Documento)
                    {
                        return cliente.Clienteid;
                    }

                }
            }
            catch (Exception ex)
            {
                return -1;
            }

            return -1;
        }

    }
}