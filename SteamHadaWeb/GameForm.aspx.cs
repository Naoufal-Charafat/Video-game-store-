using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SteamHadaLib;
using System.Data.SqlClient;

namespace SteamHadaWeb
{
    public partial class GameForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string nombreJuego = Request.QueryString["nombre"];

                if (nombreJuego == null)
                {
                    Response.Redirect("Accion.aspx");
                }

                ENJuego Game = new ENJuego(nombreJuego);
                if (Game.leerJuego())
                {
                    codigoGame.Text = Game.codeGame.ToString();
                    nombreGame.Text = Game.nameGame;
                    fechaGame.Text = Game.dataGame;
                    descripcionGame.Text = Game.descriptionGame;
                    categoriaGame.Text = Game.categoryGame;
                    if (Game.Pvp % 2 == 0 || Game.Pvp % 2 == 1)
                    {
                        precioGame.Text = Game.Pvp/*.ToString()*/ + ",00€";
                    }
                    else
                    {
                        precioGame.Text = Game.Pvp/*.ToString()*/ + "€";
                    }
                    imagenGame.Src = "imagenes/" + Game.Image;
                }
            }
        }

        protected void Comprar_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("~/Compra.aspx?nombre=" + nombreGame.Text);
        }
    }
}