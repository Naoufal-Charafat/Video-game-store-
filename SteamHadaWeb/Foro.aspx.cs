using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SteamHadaLib;

namespace SteamHadaWeb
{
    public partial class Foro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                if (Session["correo"] != null)
                {
                    ButtonCrearHilo1.Visible = true;
                }
                else
                {
                    ButtonCrearHilo1.Visible = false;
                }
                PlaceNuevoHilo.Visible = false;
            }

        }

		protected void ButtonCrearHilo_Click(object sender, EventArgs e)
		{
            if (Session["correo"] != null)
            {

                PlaceNuevoHilo.Visible = !PlaceNuevoHilo.Visible;
            }
            else
            {
				Response.Redirect("Login.aspx?from=Foro.aspx");
			}
        }

		protected void ButtonCearHilo2_Click(object sender, EventArgs e)
		{
			if (Session["correo"] != null)
			{
				if (Page.IsValid)
				{ /// hacer validacion
					ENHilo en = new ENHilo();
					en.tituloHilo = NuevoAsunto.Text;
					en.descripcionHilo = DescripcionNuevoHilo.Text;
					en.usuarioHilo = Session["correo"].ToString();
					//en.fechaInicioHilo = DateTime.Now;
					if (en.createHilo())
					{
						en.ultimoHilo();
						Response.Redirect("Hilo.aspx?hiloForo=" + en.numeroHilo.ToString());
					}
				}
			}
			else
			{
				Response.Redirect("Login.aspx?from=Foro.aspx");
			}
			
		}

		protected void ListView1_SelectedIndexChanged(object sender, EventArgs e)
		{

		}

	}
}