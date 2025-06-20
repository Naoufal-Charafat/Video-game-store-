using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using SteamHadaLib;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace SteamHadaWeb
{
    public partial class MerchPage : System.Web.UI.Page
    {
        //public string constring = ConfigurationManager.ConnectionStrings["miconexion"].ToString();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Buscar_OnClick(object sender, EventArgs e)
        {
            //VERSION ESTABLE PERO NO OPTIMA DEL BUSCADOR
            /*string name = Nombre.Text;
            ENMerch Merch = new ENMerch(name);
            if (Merch.readMerchFilter())
            {
                filtroimagen.Src = "imagenes/" + Merch.imageMerch;
                Filtro1Nombre.Text = Merch.nameMerch;
            if (Merch.pvpMerch % 2 == 0 || Merch.pvpMerch % 2 == 1)
            {
                Filtro1Precio.Text = Merch.pvpMerch + ",00€";
            } else
            {
                Filtro1Precio.Text = Merch.pvpMerch + "€";
            }

                Carrito.Text = "Añadir al carrito";
            } else
            {
                filtroimagen.Src = "";
                Filtro1Nombre.Text = "SIN RESULTADO";
                Filtro1Precio.Text = "0,00€";
                Carrito.Text = "Sin Resultado";
            }*/

            //VERSION FUNCIONAL DE FILTRO DE 5 RESULTADOS
            if (Nombre.Text != "")
            {
                string name = Nombre.Text;
                ENMerch Merch = new ENMerch(name);
                ENMerch[] aux = new ENMerch[5];
                aux = Merch.read5merch();

                if (aux[0] != null)
                {
                    filtro1imagen.Src = "imagenes/" + aux[0].imageMerch;
                    Filtro1Nombre.Text = aux[0].nameMerch;
                    if (aux[0].pvpMerch % 2 == 0 || aux[0].pvpMerch % 2 == 1)
                    {
                        Filtro1Precio.Text = aux[0].pvpMerch + ",00€";
                    }
                    else
                    {
                        Filtro1Precio.Text = aux[0].pvpMerch + "€";
                    }

                    Comprar1.Text = "Comprar";
                }
                else
                {
                    filtro1imagen.Src = "";
                    Filtro1Nombre.Text = "SIN RESULTADO";
                    Filtro1Precio.Text = "0,00€";
                    Comprar1.Text = "Sin resultado";
                }

                if (aux[1] != null)
                {
                    filtro2imagen.Src = "imagenes/" + aux[1].imageMerch;
                    Filtro2Nombre.Text = aux[1].nameMerch;
                    if (aux[1].pvpMerch % 2 == 0 || aux[1].pvpMerch % 2 == 1)
                    {
                        Filtro2Precio.Text = aux[1].pvpMerch + ",00€";
                    }
                    else
                    {
                        Filtro2Precio.Text = aux[1].pvpMerch + "€";
                    }

                    Comprar2.Text = "Comprar";
                }
                else
                {
                    filtro2imagen.Src = "";
                    Filtro2Nombre.Text = "SIN RESULTADO";
                    Filtro2Precio.Text = "0,00€";
                    Comprar2.Text = "Sin resultado";
                }

                if (aux[2] != null)
                {
                    filtro3imagen.Src = "imagenes/" + aux[2].imageMerch;
                    Filtro3Nombre.Text = aux[2].nameMerch;
                    if (aux[2].pvpMerch % 2 == 0 || aux[2].pvpMerch % 2 == 1)
                    {
                        Filtro3Precio.Text = aux[2].pvpMerch + ",00€";
                    }
                    else
                    {
                        Filtro3Precio.Text = aux[2].pvpMerch + "€";
                    }

                    Comprar3.Text = "Comprar";
                }
                else
                {
                    filtro3imagen.Src = "";
                    Filtro3Nombre.Text = "SIN RESULTADO";
                    Filtro3Precio.Text = "0,00€";
                    Comprar3.Text = "Sin resultado";
                }

                if (aux[3] != null)
                {
                    filtro4imagen.Src = "imagenes/" + aux[3].imageMerch;
                    Filtro4Nombre.Text = aux[3].nameMerch;
                    if (aux[3].pvpMerch % 2 == 0 || aux[3].pvpMerch % 2 == 1)
                    {
                        Filtro4Precio.Text = aux[3].pvpMerch + ",00€";
                    }
                    else
                    {
                        Filtro4Precio.Text = aux[3].pvpMerch + "€";
                    }

                    Comprar4.Text = "Comprar";
                }
                else
                {
                    filtro4imagen.Src = "";
                    Filtro4Nombre.Text = "SIN RESULTADO";
                    Filtro4Precio.Text = "0,00€";
                    Comprar4.Text = "Sin resultado";
                }

                if (aux[4] != null)
                {
                    filtro5imagen.Src = "imagenes/" + aux[4].imageMerch;
                    Filtro5Nombre.Text = aux[4].nameMerch;
                    if (aux[4].pvpMerch % 2 == 0 || aux[4].pvpMerch % 2 == 1)
                    {
                        Filtro5Precio.Text = aux[4].pvpMerch + ",00€";
                    }
                    else
                    {
                        Filtro5Precio.Text = aux[4].pvpMerch + "€";
                    }

                    Comprar5.Text = "Comprar";
                }
                else
                {
                    filtro5imagen.Src = "";
                    Filtro5Nombre.Text = "SIN RESULTADO";
                    Filtro5Precio.Text = "0,00€";
                    Comprar5.Text = "Sin resultado";
                }
            }
            else
            {
                filtro1imagen.Src = "";
                Filtro1Nombre.Text = "SIN RESULTADO";
                Filtro1Precio.Text = "0,00€";
                Comprar1.Text = "Sin resultado";

                filtro2imagen.Src = "";
                Filtro2Nombre.Text = "SIN RESULTADO";
                Filtro2Precio.Text = "0,00€";
                Comprar2.Text = "Sin resultado";

                filtro3imagen.Src = "";
                Filtro3Nombre.Text = "SIN RESULTADO";
                Filtro3Precio.Text = "0,00€";
                Comprar3.Text = "Sin resultado";

                filtro4imagen.Src = "";
                Filtro4Nombre.Text = "SIN RESULTADO";
                Filtro4Precio.Text = "0,00€";
                Comprar4.Text = "Sin resultado";

                filtro5imagen.Src = "";
                Filtro5Nombre.Text = "SIN RESULTADO";
                Filtro5Precio.Text = "0,00€";
                Comprar5.Text = "Sin resultado";
            }

        }

        protected void LinkButton1_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("~/MerchForm.aspx?nombre=" + ((LinkButton)sender).Text);
        }

        protected void Resultado_OnClick(object sender, EventArgs e)
        {
            if (((LinkButton)sender).Text != "SIN RESULTADO")
            {
                Response.Redirect("~/MerchForm.aspx?nombre=" + ((LinkButton)sender).Text);
            }

        }

        protected void Comprar_OnClick(object sender, EventArgs e)
        {
            if (((Button)sender).Text != "Sin resultado")
            {
                if (((Button)sender).ID == "Comprar1")
                {
                    Response.Redirect("~/Compra.aspx?nombre=" + Filtro1Nombre.Text);
                }
                else if (((Button)sender).ID == "Comprar2")
                {
                    Response.Redirect("~/Compra.aspx?nombre=" + Filtro2Nombre.Text);
                }
                else if (((Button)sender).ID == "Comprar3")
                {
                    Response.Redirect("~/Compra.aspx?nombre=" + Filtro3Nombre.Text);
                }
                else if (((Button)sender).ID == "Comprar4")
                {
                    Response.Redirect("~/Compra.aspx?nombre=" + Filtro4Nombre.Text);
                }
                else if (((Button)sender).ID == "Comprar5")
                {
                    Response.Redirect("~/Compra.aspx?nombre=" + Filtro5Nombre.Text);
                }
            }
        }
    }
}