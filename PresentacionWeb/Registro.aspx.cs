using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Globalization;

namespace PresentacionWeb
{
    public partial class Registro : System.Web.UI.Page
    {
        private bool Validar { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["voucher"] == null || Session["premio"] == null)
            {
                Response.Redirect("~/Default.aspx");
                return;
            }

            vistaBuscar();
            Validar = false;
        }

        protected void BtnParticipar_Click(object sender, EventArgs e)
        {
            ClienteNegocio cliente = new ClienteNegocio();
            cliente.Documento = textDNI.Text;

            if (cliente.Documento == "")
            {
                CrearModal("Atención", "Por favor, ingrese su DNI sin puntos ni espacios");
                return;
            }

            try
            {
                //Valida el formato del documento
                int.Parse(cliente.Documento);


                if (!Validar && textNombre.Text == "")
                {
                    bool cargar = cliente.ValidaClienteDNI();
                    vistaParticipar(cargar, cliente);
                    Validar = true;
                    return;
                }

                vistaParticipar(false, null);

                if (camposVacios())
                {
                    CrearModal("Atención", "Por favor, complete todos los campos.");
                    return;
                }
                if (!mailValido(textEmail.Text))
                {
                    CrearModal("Atención", "Formato de mail inválido.");
                    return;
                }
                
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
                        CrearModal("Error",
                            "Ha ocurrido un error al cargar sus datos. Por favor, intente nuevamente en unos minutos");
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

                    Session.Remove("voucher");
                    Session.Remove("premio");

                    envioMail(cliente);

                    Session.Add("sorteo", rsorteo);

                    Response.Redirect("~/Final.aspx");
                }
                else
                {
                    mensaje = "Error al registrar sorteo. Intente en unos minutos nuevamente.";
                    CrearModal("Error", mensaje);
                }
            }
            catch (FormatException)
            {
                CrearModal("Atención", "Formato de DNI no válido. Por favor, ingrese su documento sin puntos ni espacios");
            }
            catch (OverflowException)
            {
                CrearModal("Atención", "DNI demasiado largo, intente nuevamente");
            }
            catch (Exception ex)
            {
                CrearModal("Error", "Ha habido un error. Intente en unos minutos nuevamente.");
                Response.Write("<script>console.log('" + ex.Message + "');</script>");
            }
        }

        private void vistaBuscar()
        {
            titulo.InnerText = "Ingrese su documento. En caso de tener registro de sus datos, los cargaremos por usted";

            textDNI.Enabled = true;

            textNombre.Visible = false;
            textApellido.Visible = false;
            textProvincia.Visible = false;
            textLocalidad.Visible = false;
            textDireccion.Visible = false;
            textEmail.Visible = false;

            lblNombre.Visible = false;
            lblApellido.Visible = false;
            lblProvincia.Visible = false;
            lblLocalidad.Visible = false;
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
            textProvincia.Visible = true;
            textLocalidad.Visible = true;
            textDireccion.Visible = true;
            textEmail.Visible = true;

            lblNombre.Visible = true;
            lblApellido.Visible = true;
            lblProvincia.Visible = true;
            lblLocalidad.Visible = true;
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
                "Si resulta ganador, el 30/2/2020 le enviaremos un mail con las instrucciones para retirar su premio." + Environment.NewLine +
                "Atte, " + Environment.NewLine +
                "Mercado y Gonzalez.";
            //client.Send(mail);
        }

        private bool camposVacios()
        {
            if (textNombre.Text == "" ||
            textApellido.Text == "" ||
            textProvincia.Text == "" ||
            textLocalidad.Text == "" ||
            textDireccion.Text == "" ||
            textEmail.Text == "")
                return true;

            else
                return false;
        }

        private bool mailValido(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;
            
            try
            {
                // Normalize the domain
                email = Regex.Replace(email, @"(@)(.+)$", DomainMapper,
                                        RegexOptions.None, TimeSpan.FromMilliseconds(200));

                // Examines the domain part of the email and normalizes it.
                string DomainMapper(Match match)
                {
                    // Use IdnMapping class to convert Unicode domain names.
                    var idn = new IdnMapping();

                    // Pull out and process domain name (throws ArgumentException on invalid)
                    var domainName = idn.GetAscii(match.Groups[2].Value);

                    return match.Groups[1].Value + domainName;
                }
            }
            catch (RegexMatchTimeoutException e)
            {
                return false;
            }
            catch (ArgumentException e)
            {
                return false;
            }

            try
            {
                return Regex.IsMatch(email,
                    @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                    @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-0-9a-z]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
                    RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }
        
        private void CrearModal(string Titulo, string Mensaje)
        {
            lblModalTitle.Text = Titulo;
            lblModalBody.Text = Mensaje;
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
            upModal.Update();
        }
    }
}
