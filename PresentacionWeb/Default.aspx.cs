using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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
            if (txtVoucher.Value == "hola")
            {
                Session.Add("voucher2", txtVoucher.Value);
                Response.Redirect("~/Premios.aspx");
            }
            else
            {

            }
        }

        public void funcion()
        {
            string x = "hola";
            x += " y chau";
        }
    }
}