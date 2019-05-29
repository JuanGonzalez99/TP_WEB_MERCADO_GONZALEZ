using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PresentacionWeb
{
    public partial class Premios1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Session["voucher"] != null)
            //{
            //    if (!lblVoucher.Text.Contains(Session["voucher"].ToString()))
            //        lblVoucher.Text += Session["voucher"].ToString() + " (esto no va, es para comprobar que se guarda)";
            //}
            if(Session["voucher2"] != null)
            {
                string voucher = Session["voucher2"].ToString();
                if (!lblVoucher.Text.Contains(voucher))
                    lblVoucher.Text += voucher + " (esto no va, es para comprobar que se guarda)";
            }
        }

        protected void btnSiguiente_Click(object sender, EventArgs e)
        {
            //Redirigir a la carga de datos del cliente
            Response.Redirect("~/Registro.aspx");
        }
    }
}