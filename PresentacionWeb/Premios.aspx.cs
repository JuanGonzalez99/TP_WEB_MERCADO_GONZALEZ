using System;
using System.Collections.Generic;
using System.Drawing;
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
        private Color DefaultColor { get { return Color.DarkGray; } }
        private Color SelectedColor { get { return Color.BlueViolet; } }

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

                // Coloca cada par de imagenes una al lado de la otra y mete un salto de linea para las siguientes 
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
                CrearModal("Atención", "Debe seleccionar un premio para continuar.");
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

        private void CrearModal(string Titulo, string Mensaje)
        {
            lblModalTitle.Text = Titulo;
            lblModalBody.Text = Mensaje;
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
            upModal.Update();
        }
    }
}