using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;

namespace PresentacionWeb
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["sorteo"] != null)
            {
                Session.Remove("sorteo");
            }
        }

        protected void btnSiguiente_Click(object sender, EventArgs e)
        {
            VoucherNegocio voucher = new VoucherNegocio();
            voucher.CodigoPromocional = txtVoucher.Text;

            if (voucher.CodigoPromocional == "")
            {
                CrearModal("Atención", "Debe ingresar un código para continuar.");
                return;
            }

            try
            {
                int aux = voucher.ValidoCodigo();
                if (aux == 0)
                {
                    Session.Add("voucher", voucher);
                    Response.Redirect("~/Premios.aspx");
                }
                else
                {
                    string errorText, errorTitle = "";
                    if (aux == 1)
                    {
                        errorTitle = "Atención";
                        errorText = "El código ya fue utilizado.";
                    }
                    else if (aux == 2)
                    {
                        errorTitle = "Atención";
                        errorText = "Código no válido para esta promoción.";
                    }
                    else
                    {
                        errorTitle = "Error";
                        errorText = "Ha habido un error. Intente nuevemente en unos minutos.";
                    }

                    CrearModal(errorTitle, errorText);
                }
            }
            catch (Exception ex)
            {
                CrearModal("Error", "Ha habido un error. Intente en unos minutos nuevamente.");
                Response.Write("<script>console.log('" + ex.Message + "');</script>");
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