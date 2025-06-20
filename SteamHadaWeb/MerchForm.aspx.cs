using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using SteamHadaLib;

namespace SteamHadaWeb
{
    public partial class MerchForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string nombreProducto = Request.QueryString["nombre"];

                if (nombreProducto == null)
                {
                    Response.Redirect("MerchPage.aspx");
                }

                ENMerch merch = new ENMerch(nombreProducto);
                if (merch.readMerchFilter())
                {
                    codigoProd.Text = merch.codeMerch.ToString();
                    nombreProd.Text = merch.nameMerch;
                    fechaProd.Text = merch.dataMerch;
                    descripcionProd.Text = merch.descriptionMerch;
                    if (merch.pvpMerch % 2 == 0 || merch.pvpMerch % 2 == 1)
                    {
                        precioProd.Text = merch.pvpMerch/*.ToString()*/ + ",00€";
                    }
                    else
                    {
                        precioProd.Text = merch.pvpMerch/*.ToString()*/ + "€";
                    }
                    volumenProd.Text = merch.volumenMerch + " centimetros cuadrados";
                    pesoProd.Text = merch.pesoMerch + "kg";
                    imagenProd.Src = "imagenes/" + merch.imageMerch;


                }

            }
        }

        protected void Comprar_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("~/Compra.aspx?nombre=" + nombreProd.Text);
        }
    }
}