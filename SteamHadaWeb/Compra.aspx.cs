using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SteamHadaLib;

namespace SteamHadaWeb
{
    public partial class Compra : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string nombre = Request.QueryString["nombre"];

                if (nombre == null)
                {
                    Response.Redirect("Index.aspx");
                   
                }

                ENJuego Game = new ENJuego(nombre);
                ENMerch Merch = new ENMerch(nombre);
                if (Game.leerJuego())
                {
                    nombreProd.Text = Game.nameGame.ToString();
                    codigoProd.Text = Game.codeGame.ToString();
                    if (Game.Pvp % 2 == 0 || Game.Pvp % 2 == 1)
                    {
                        precioProd.Text = Game.Pvp/*.ToString()*/ + ",00€";
                    }
                    else
                    {
                        precioProd.Text = Game.Pvp/*.ToString()*/ + "€";
                    }
                    
                }
                else
                {
                    if (Merch.readMerchFilter())
                    {
                        nombreProd.Text = Merch.nameMerch.ToString();
                        codigoProd.Text = Merch.nameMerch.ToString();
                        if (Merch.pvpMerch % 2 == 0 || Merch.pvpMerch % 2 == 1)
                        {
                            precioProd.Text = Merch.pvpMerch/*.ToString()*/ + ",00€";
                        }
                        else
                        {
                            precioProd.Text = Merch.pvpMerch/*.ToString()*/ + "€";
                        }
                    }
                }
            }
        }

        protected void No_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("~/Index.aspx");
        }

        protected void Yes_OnClick(object sender, EventArgs e)
        {

        }
    }
}