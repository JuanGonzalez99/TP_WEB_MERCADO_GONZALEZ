using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;

namespace PresentacionWeb
{
    public partial class Premios1 : System.Web.UI.Page
    {
        //Lista auxiliar para modificar los image button de la pantalla
        private List<ImageButton> auxList { get; set; }

        //Colores de los bordes para indicar si un premio está seleccionado o no
        private System.Drawing.Color DefaultColor { get { return System.Drawing.Color.DarkGray; } }
        private System.Drawing.Color SelectedColor { get { return System.Drawing.Color.BlueViolet; } }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["voucher"] == null)
            {
                Response.Redirect("~/Default.aspx");
                return;
            }

            PremioNegocio premio = new PremioNegocio();
            List<PremioNegocio> listpremios = new List<PremioNegocio>();
            listpremios = premio.GetPremios();
            // Premios Dinamicos
            List<ImageButton> aImageButton = new List<ImageButton>();
            Panel1.Visible = true;

            int i = 0;
            foreach (var foo in listpremios)
            {
                aImageButton.Add(new ImageButton());
                aImageButton[i].ID = "ImageButton" + (i + 1);
                aImageButton[i].Width = 300;
                aImageButton[i].Height = 300;
                aImageButton[i].BorderWidth = 5;
                aImageButton[i].BorderColor = DefaultColor;
                aImageButton[i].Click += new ImageClickEventHandler(imageButton_Click);
                aImageButton[i].ToolTip = foo.Descripcion;
                aImageButton[i].CommandArgument = foo.IdPremio.ToString();
                aImageButton[i].ImageUrl = foo.URL;
                aImageButton[i].AlternateText = foo.Descripcion;
                aImageButton[i].Visible = true;

                Panel1.Controls.Add(aImageButton[i]);

                // Coloca 2 imagenes una alado de la otra y mete un salto de linea
                // para la siguientes 
                if ((i + 1) % 2 == 0)
                {
                    Panel1.Controls.Add(new LiteralControl("<br />"));
                }
                else
                {
                    Panel1.Controls.Add(new LiteralControl("<span> </span>"));
                }

                i++;
            }

            auxList = new List<ImageButton>(aImageButton);
        }

        protected void btnSiguiente_Click(object sender, EventArgs e)
        {
            //Si no hay ningún premio seleccionado (valido con el color del borde), tiro error
            if (!auxList.Exists(x => x.BorderColor == SelectedColor))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('"+"Debe seleccionar un premio para continuar."+"');", true);
                return;
            }

            //Si no, agrego el IdPremio del seleccionado a sesión
            Session.Add("premio", auxList.First(x => x.BorderColor == SelectedColor).CommandArgument);
            Response.Redirect("~/Registro.aspx");
        }

        //Función artificial para manejar el evento de click en cada image button, para cambiar el color del borde
        public void imageButton_Click(object sender, EventArgs e)
        {
            ImageButton imgBtn = (ImageButton)sender;
            imgBtn.BorderColor = SelectedColor;

            foreach (ImageButton item in auxList)
            {
                if (item.CommandArgument != imgBtn.CommandArgument)
                    item.BorderColor = DefaultColor;
            }
        }

    }
}