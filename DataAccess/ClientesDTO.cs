using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
namespace AccesoDatos
{
    public class ClientesDTO : PersonaDTO
    {
        public int Clienteid { get; set; }
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
                        nombre = client.nombre,
                        Apellido = client.Apellido,
                        Direccionid = client.Direccionid,
                        Documento = client.Documento,                        
                        TelefonoId = client.TelefonoId,
                        Descripcion = client.Descripcion
                    }).ToList();
            }
        }

        public void GetClientByID(int idClient)
        {
            using (db)
            {
                var query = from Cliente in db.Clientes select Cliente;
                List<Clientes> clientes = query.ToList<Clientes>();
                foreach (var foo in clientes)
                {
                    if (foo.Clienteid == idClient)
                        Clienteid = foo.Clienteid;
                    nombre = foo.nombre;
                    Apellido = foo.Apellido;
                    Direccionid = foo.Direccionid;
                    Documento = foo.Documento;                    
                    TelefonoId = foo.TelefonoId;
                    Descripcion = foo.Descripcion;
                }
            }
        }


        public int addCliente()
        {
            Clientes cliente = new Clientes();
            cliente.TelefonoId = telefono.addTelefono();
            cliente.Direccionid = direccion.addDireccion();            
            cliente.nombre = this.nombre;
            cliente.Apellido = this.Apellido;
            cliente.Documento = this.Documento;
            cliente.Descripcion = this.Descripcion;
            using (var db = new ModelContexto())
            {
                db.Clientes.Add(cliente);
                db.SaveChanges();
                var query = from dir in db.Clientes
                            orderby dir.Clienteid descending
                            where  dir.nombre == cliente.nombre
                            && dir.Apellido == cliente.Apellido && dir.Direccionid == dir.Direccionid &&
                            dir.Documento == cliente.Documento
                            select dir;
                cliente = query.FirstOrDefault<Clientes>();

                if ( cliente.nombre == this.nombre
                    && cliente.Apellido == this.Apellido && cliente.Direccionid == cliente.Direccionid &&
                    cliente.Documento == this.Documento)
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
