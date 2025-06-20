using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SteamHadaLib;

namespace SteamHadaWeb
{
	public partial class Hilo : System.Web.UI.Page
	{
		
		protected void Page_Load(object sender, EventArgs e)
		{
            if(!IsPostBack)
            {
				string correoAutor = null;
				int numHilo = Convert.ToInt32(Request.QueryString["hiloForo"]);
				ENHilo en = new ENHilo();
				en.numeroHilo = numHilo;
				if (en.readHilo(ref correoAutor))
				{
					Asunto.Text = en.tituloHilo;
					Descripcion.Text = en.descripcionHilo;
					FechaAsunto.Text = en.fechaInicioHilo.ToShortDateString();
					HoraAsunto.Text = en.fechaInicioHilo.ToShortTimeString();
					AutorAsunto.Text = en.usuarioHilo;
					//ListView1.DataSource = // dataset
					SqlDataSource1.SelectCommand += " and hiloForo = " + numHilo.ToString() + " order by cod asc";
				}
				else {
					NuevoMensaje.Visible = false;
					ButtonNuevoMensaje.Visible = false;
					SqlDataSource1.SelectCommand += " and hiloForo = 0";
					AutorAsunto.Visible = false;
				}
                if (Session["correo"] != null)
                {
					if (Session["correo"].ToString() == correoAutor)
					{
						PlaceHolderEditHilo.Visible = true;
					}
					//NombreUsuario2.Text = Session["correo"].ToString(); //prueba para ver si va
					PlaceNuevoMensaje.Visible = true;
                }
                else
                {
                    PlaceNuevoMensaje.Visible = false;
                }
            }
        }

		protected void nombreLabel_Click(object sender, EventArgs e)
		{

		}

		protected void ButtonNuevoMensaje_Click(object sender, EventArgs e)
		{
			
			if (Session["correo"] != null)
			{
				RequiredFieldValidatorMensaje.Validate();
				RegularExpressionValidator.Validate();
				if (RequiredFieldValidatorMensaje.IsValid && RegularExpressionValidator.IsValid)
				{
					ENMensajeHilo en = new ENMensajeHilo();
					en.HiloForo = Convert.ToInt32(Request.QueryString["hiloForo"]);
					en.Mensaje = NuevoMensaje.Text;
					en.Usuario = Session["correo"].ToString();
					if (en.CreateMensaje())
					{
						Response.Redirect("Hilo.aspx?hiloForo=" + en.HiloForo);
					}
				}
				
			}
			else
			{
				Response.Redirect("Login.aspx");//////pasarle la url dde vuelta
			}
		}

		protected void ButtonBorrarHilo_Click(object sender, EventArgs e)
		{
			if (Session["correo"] != null)
			{
				ENHilo en = new ENHilo();
				en.numeroHilo = Convert.ToInt32(Request.QueryString["hiloForo"]);
				if (en.deleteHilo())
				{
					Response.Redirect("Foro.aspx");
				}
			}
			else
			{
				Response.Redirect("Login.aspx");
			}

		}

		protected void ButtonModificarHilo_Click(object sender, EventArgs e)
		{
			if (Session["correo"] != null)
			{
				Descripcion.Visible = false;
				Asunto.Visible = false;
				ModificarAsuntoTable.Visible = true;
				EditDescripcion.Text = Descripcion.Text;
				EditAsunto.Text = Asunto.Text;
			}
			else {
				Response.Redirect("Login.aspx");
			}
			
		}

		protected void buttonModificadoHilo_Click(object sender, EventArgs e)
		{
	
			if (Session["correo"] != null)
			{
				ENHilo en = new ENHilo();
				en.descripcionHilo = EditDescripcion.Text;
				en.tituloHilo = EditAsunto.Text;
				en.numeroHilo = Convert.ToInt32(Request.QueryString["hiloForo"]);
				if (en.updateHilo())
				{
					Asunto.Text = EditAsunto.Text;
					Descripcion.Text = EditDescripcion.Text;
					Descripcion.Visible = true;
					Asunto.Visible = true;
					ModificarAsuntoTable.Visible = false;
				}
			}
			else
			{
				Response.Redirect("Login.aspx");
			}

		}

		protected void buttonCancelarModificacion_Click(object sender, EventArgs e)
		{
			Descripcion.Visible = true;
			Asunto.Visible = true;
			ModificarAsuntoTable.Visible = false;
		}

		protected void AutorAsunto_Click(object sender, EventArgs e)
		{
			ENHilo en = new ENHilo();
			string correo = null;
			en.numeroHilo = Convert.ToInt32(Request.QueryString["hiloForo"]);
			if (en.readHilo(ref correo))
			{
				Session["usuarioForo"] = correo;
				Response.Redirect("UserDetails.aspx");
			}
		}
	}
}