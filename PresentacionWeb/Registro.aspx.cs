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
            if (Session["voucher"] == null || Session["premio"] == null)
            {
                Response.Redirect("~/Default.aspx");
                return;
            }

            vistaBuscar();
        }

        protected void BtnParticipar_Click(object sender, EventArgs e)
        {
            ClienteNegocio cliente = new ClienteNegocio();
            cliente.Documento = textDNI.Text;

            if (cliente.Documento == "")
            {
                ClientScript.RegisterStartupScript(this.GetType(),
                    "myalert", "alert('Por favor, ingrese su DNI.');", true);
                return;
            }

            try
            {
                //Valida el formato del documento
                int.Parse(cliente.Documento);

                if (textNombre.Text == "")
                {
                    bool cargar = cliente.ValidaClienteDNI();
                    vistaParticipar(cargar, cliente);
                    return;
                }

                vistaParticipar(false, null);
                
                if (!cliente.ValidaClienteDNI())
                {
                    cliente.Nombre = textNombre.Text;
                    cliente.Apellido = textApellido.Text;
                    cliente.Direccion = textDireccion.Text;
                    cliente.Localidad = textLocalidad.Text;
                    cliente.Provincia = textProvincia.Text;
                    cliente.Email = textEmail.Text;

                    cliente.Clienteid = cliente.AgregaCliente();

                    if (cliente.Clienteid == -1)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "myalert",
                            "alert('Ha ocurrido un error al cargar sus datos. Por favor, intente nuevamente en unos minutos ');",
                            true);
                        return;
                    }
                }

                VoucherNegocio voucher = new VoucherNegocio();
                voucher = (VoucherNegocio)Session["voucher"];

                SorteoNegocio sorteo = new SorteoNegocio();
                sorteo.clienteid = cliente.Clienteid;
                sorteo.voucherid = voucher.IdVoucher;
                sorteo.premioid = int.Parse(Session["premio"].ToString());

                int rsorteo = sorteo.AgregaSorteo();

                string mensaje = "";

                if (rsorteo != -1)
                {
                    voucher.CambiarEstado();
                    envioMail(cliente);

                    mensaje = "Gracias por participar de nuestro sorteo! Participación N°: " + rsorteo;

                    Session.Remove("voucher");
                    Session.Remove("premio");

                    Response.Write("<script language='javascript'>window.alert('"+ mensaje + "');window.location='Default.aspx';</script>");
                }
                else
                {
                    mensaje = "Error al registrar sorteo. Intenta en unos minutos nuevamente.";
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + mensaje + "');", true);
                }
            }
            catch (FormatException)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Formato de DNI no válido." + "');", true);
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert",
                    "alert('" + "Ha habido un error. Intente en unos minutos nuevamente." + "');", true);
                Response.Write("<script>console.log('" + ex.Message + "');</script>");
            }
        }

        private void vistaBuscar()
        {
            titulo.InnerText = "Ingrese su documento. En caso de tener registro de sus datos, los cargaremos por usted";

            textDNI.Enabled = true;

            textNombre.Visible = false;
            textApellido.Visible = false;
            textLocalidad.Visible = false;
            textProvincia.Visible = false;
            textDireccion.Visible = false;
            textEmail.Visible = false;

            lblNombre.Visible = false;
            lblApellido.Visible = false;
            lblLocalidad.Visible = false;
            lblProvincia.Visible = false;
            lblDireccion.Visible = false;
            lblEmail.Visible = false;

            BtnParticipar.Text = "Buscar";
        }

        private void vistaParticipar(bool cargarCampos, ClienteNegocio cliente)
        {
            titulo.InnerText = "¡Ingrese sus datos para participar!";

            textDNI.Enabled = false;

            textNombre.Visible = true;
            textApellido.Visible = true;
            textLocalidad.Visible = true;
            textProvincia.Visible = true;
            textDireccion.Visible = true;
            textEmail.Visible = true;

            lblNombre.Visible = true;
            lblApellido.Visible = true;
            lblLocalidad.Visible = true;
            lblProvincia.Visible = true;
            lblDireccion.Visible = true;
            lblEmail.Visible = true;

            if (cargarCampos)
            {
                textNombre.Text = cliente.Nombre;
                textApellido.Text = cliente.Apellido;
                textDireccion.Text = cliente.Direccion;
                textLocalidad.Text = cliente.Localidad;
                textProvincia.Text = cliente.Provincia;
                textEmail.Text = cliente.Email;
            }

            BtnParticipar.Text = "Participar";
        }

        private void envioMail(ClienteNegocio cliente)
        {
            MailMessage mail = new MailMessage("sebastian.mercadomartinez@gmail.com", cliente.Email);
            SmtpClient client = new SmtpClient("smtp.gmail.com");
            client.Port = 587;
            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential("sebastian.mercadomartinez@gmail.com", "47271230");
            client.EnableSsl = false;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.Host = "smtp.gmail.com";

            mail.Subject = "Super Sorteo";
            mail.Body = "Gracias por participar de nuestro sorteo, " + cliente.Nombre + Environment.NewLine +
                "Si resulta ganador le enviaremos un mail con las instrucciones para retirar su premio." + Environment.NewLine +
                "Atte, " + Environment.NewLine +
                "Mercado y Gonzalez.";
            //client.Send(mail);
        }
    }
}
