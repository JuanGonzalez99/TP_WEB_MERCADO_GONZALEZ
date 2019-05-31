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

        }

        protected void btnSiguiente_Click(object sender, EventArgs e)
        {
            //VoucherNegocio v = new VoucherNegocio();
            //v.GetVoucherByCode(txtVoucher.Text);
            //Validar voucher
            VoucherNegocio voucher = new VoucherNegocio();
            voucher.CodigoPromocional = txtVoucher.Text;

            int aux = voucher.ValidoCodigo();
            if (aux == 0)
            {
                Session.Add("voucher", voucher);
                Response.Redirect("~/Premios.aspx");
            }
            else
            {
                string errorText = "";
                if (aux == 1)
                    errorText = "Voucher ya fue utilizado";
                else if (aux == 2)
                    errorText = "Voucher no válido para esta promoción";
                else
                    errorText = "Ha habido un error. Intente nuevemente en unos minutos";

                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + errorText + "');", true);
            }
        }
    }
}