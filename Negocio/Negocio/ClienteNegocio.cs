using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos;

namespace Negocio
{
    public class ClienteNegocio
    {
        public int Clienteid { get; set; }
        public string Nombre { get; set; } 
        public string Apellido { get; set; } 
        public string Documento { get; set; } 
        public string Localidad { get; set; }
        public string Provincia { get; set; }
        public string Direccion { get; set; }
        public string Email { get; set; }
        
        // Retorna true si el cliente existe y lo carga en el objeto
        // Retorna False si no existe el cliente
        public bool ValidaClienteDNI()
        {
            try
            {
                ClientesDTO clientedto = new ClientesDTO();
                if (clientedto.GetClientByDocumento(Documento))
                {
                    this.Clienteid = clientedto.Clienteid;
                    this.Nombre = clientedto.Nombre;
                    this.Apellido = clientedto.Apellido;
                    this.Documento = clientedto.Documento;
                    this.Localidad = clientedto.Localidad;
                    this.Provincia = clientedto.Provincia;
                    this.Direccion = clientedto.Direccion;
                    this.Email = clientedto.Email;
                    return true;
                }

            }
            catch (Exception ex)
            {
                return false;
            }
            return false;
        }

        // Agrega cliente valida que los campos no esten vacios 
        // Devuelve ClienteId si fue cargado correctamente caso contrario -1
        public int AgregaCliente()
        {
            if (Nombre != "" && Apellido != "" && Documento !="" && Localidad != ""
                && Provincia != "" && Direccion != "" && Email!= "")
            {
                System.Console.WriteLine("Verifique para cargar datos");
                ClientesDTO clientedto = new ClientesDTO();
                clientedto.Nombre = this.Nombre;
                clientedto.Apellido = this.Apellido;
                clientedto.Documento = this.Documento;
                clientedto.Localidad = this.Localidad;
                clientedto.Provincia = this.Provincia;
                clientedto.Direccion = this.Direccion;
                clientedto.Email = this.Email;
                this.Clienteid=clientedto.addCliente();
                System.Console.WriteLine("Resultado de agregado " +this.Clienteid);
                if (this.Clienteid != -1)
                {
                    return Clienteid;
                }
            }

            return -1;
        }
    }
}
