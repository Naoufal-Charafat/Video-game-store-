using SteamHadaLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SteamHadaWeb
{
	public partial class UserDetails : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (Session["correo"] != null) //distinguir por los tipos de usuario
			{
				actualEmail.Text += Session["correo"].ToString(); //propiedades comunes de todos los tipos de usuario
				actualName.Text += Session["nombre"].ToString();
				actualSurname.Text += Session["Apellido"].ToString();
				actualPhoneNumber.Text += Session["telefono"].ToString();
				actualBiography.Text += Session["biografia"].ToString();
				profileImage.ImageUrl = Session["rutaImagen"].ToString();

				if (int.Parse(Session["privilegio"].ToString()) == 0)
				{
					ENCliente cliente = new ENCliente(Session["correo"].ToString(), Session["contrasena"].ToString());

					if (cliente.readCliente())
					{
						typeOfAccount.Text += "Cliente";
						numberOfGamesDeveloped.Visible = false;
						numberOfUsersBanned.Visible = false;
						numberOfGamesBought.Visible = true;
						actualCash.Text += cliente.Saldo.ToString()/*Session["saldo"].ToString()*/ + " €";
						//select para calcular el número de juegos que ha comprado;
						int games = 0;
						String gamesBought = "";
						//cliente.gamesBought(gamesBought, games);
						numberOfGamesBought.Text += cliente.gamesBought(gamesBought, games);
						//dateOfEntry.Text = cliente.fechaIngreso.ToString();

					}
				}
				else if (int.Parse(Session["privilegio"].ToString()) == 1)
				{
					ENDesarrollador desarrollador = new ENDesarrollador(Session["correo"].ToString(), Session["contrasena"].ToString());

					if (desarrollador.readDesarrollador())
					{
						typeOfAccount.Text += "Desarrollador";
						numberOfGamesDeveloped.Visible = true;
						numberOfUsersBanned.Visible = false;
						numberOfGamesBought.Visible = false;
						//select para calcular el número de juegos que ha desarrollado;
						int games = 0;
						String gamesDeveloped = "";
						desarrollador.gamesDeveloped(gamesDeveloped, games);
					}
				}
			}
			else
				Response.Redirect("index.aspx");
		}

		protected void LanguageDDL_SelectedIndexChanged(object sender, EventArgs e)
		{

		}
	}
}