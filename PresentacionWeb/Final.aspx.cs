using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PresentacionWeb
{
    public partial class Final : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["sorteo"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }

            lblSorteo.Text += Session["sorteo"].ToString();
        }
        
        protected void btnInicio_Click(object sender, EventArgs e)
        {
            Session.Remove("sorteo");
            Response.Redirect("~/Default.aspx");
        }
    }
}