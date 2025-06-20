using SteamHadaLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SteamHadaWeb
{
    public partial class verEvento : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            /*
            string valor = Request.QueryString["value"];*/
            if (!IsPostBack)
            {
                int codigo = Convert.ToInt32(Request.QueryString["value"]);

                ENEvento en = new ENEvento(codigo);
                ENEventoFisico enF = new ENEventoFisico();
                enF.codigo = en.codigo;

                bool leer1 = enF.readEvents();
                bool leer2 = en.readEvents();

                if (leer1 == true && leer2 == true)
                {
                    Nombre.Text =  en.nombre;
                    Descripcion.Text =  en.descripcion;
                    FechaInit.Text =  en.fecha_inicio;
                    FechaFin.Text = en.fecha_fin;

                    Provincia.Text =  enF.provincia;
                    Localidad.Text =  enF.provincia;
                    Empresa.Text =  enF.empresa;
                    Precio.Text =  enF.precio.ToString() + " €";
                }
            }


        }

        protected void Comprar_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("~/Compra.aspx?nombre=" + Nombre.Text);
        }
    }
}