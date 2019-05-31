using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using System.Net.Mail;

namespace PresentacionWeb
{
    public partial class Registro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            textDNI.Enabled = true;
            textNombre.Enabled = false;
            textApellido.Enabled = false;
            textDireccion.Enabled = false;
            textLocalidad.Enabled = false;
            textEmail.Enabled = false;
            textProvincia.Enabled = false;
        }

        protected void BtnParticipar_Click(object sender, EventArgs e)
        {
            ClienteNegocio cliente = new ClienteNegocio();
            cliente.Documento = textDNI.Text;

            string mensaje;
            if (cliente.Documento != "")
            {
                if (cliente.ValidaClienteDNI() && textNombre.Text == "")
                {
                    textDNI.Enabled = false;
                    textNombre.Text = cliente.Nombre;
                    textApellido.Text = cliente.Apellido;
                    textDireccion.Text = cliente.Direccion;
                    textLocalidad.Text = cliente.Localidad;
                    textProvincia.Text = cliente.Provincia;
                    textEmail.Text = cliente.email;
                    // return true;
                }
                else if (textNombre.Text == "")
                {
                    textDNI.Enabled = false;
                    textNombre.Enabled = true;
                    textApellido.Enabled = true;
                    textDireccion.Enabled = true;
                    textLocalidad.Enabled = true;
                    textEmail.Enabled = true;
                    textProvincia.Enabled = true;
                    // return false;
                }
                else
                {
                    textDNI.Enabled = false;
                    textNombre.Enabled = false;
                    textApellido.Enabled = false;
                    textDireccion.Enabled = false;
                    textLocalidad.Enabled = false;
                    textEmail.Enabled = false;
                    textProvincia.Enabled = false;


                    cliente.Documento = textDNI.Text;
                    cliente.Nombre = textNombre.Text;
                    cliente.Apellido = textApellido.Text;
                    cliente.Direccion = textDireccion.Text;
                    cliente.Localidad = textLocalidad.Text;
                    cliente.Provincia = textProvincia.Text;
                    cliente.email = textEmail.Text;
                    int result = -1;
                    if (cliente.Clienteid == -1)
                    {
                        result = cliente.AgregaCliente();
                    }

                    if (result != -1 || cliente.Clienteid != -1)
                    {
                        MailMessage mail = new MailMessage("sebastian.mercadomartinez@gmail.com", cliente.email);
                        SmtpClient client = new SmtpClient("smtp.gmail.com");
                        client.Port = 587;
                        client.UseDefaultCredentials = false;
                        client.Credentials=new System.Net.NetworkCredential("sebastian.mercadomartinez@gmail.com", "47271230");
                        client.EnableSsl = true;
                        client.DeliveryMethod = SmtpDeliveryMethod.Network;                       
                        client.Host = "smtp.gmail.com";
                        mail.Subject = "SORTEO !!.";
                        mail.Body = "Gracias por participar del srteo !!!";
                        client.Send(mail);
                        mensaje = "Gracias por participar del sorteo !!! participacion nro: " + result;
                    }
                    mensaje = "Error al registrar cliente " + result;
                    System.Console.WriteLine(mensaje);

                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + mensaje + "');", true);

                    if (result != 1 || cliente.Clienteid != -1)
                    {
                        VoucherNegocio voucher = new VoucherNegocio();
                        voucher = (VoucherNegocio)Session["voucher"];
                        SorteoNegocio sorteo = new SorteoNegocio();
                        sorteo.clienteid = cliente.Clienteid;
                        sorteo.voucherid = voucher.IdVoucher;
                        sorteo.premioid = (int)Session["premio"];
                        int rsorteo = sorteo.AgregaSorteo();
                        if (rsorteo != -1)
                        {
                             mensaje = "Gracias por participar del sorteo !!! sorteo nro: " + result;

                        }
                        else
                        {
                            mensaje = "Error al registrar sorteo " + result;
                        }
                        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + mensaje + "');", true);
                        Response.Redirect("~/Default.aspx");
                        return;
                    }

                }
            }
        }
    }
}
