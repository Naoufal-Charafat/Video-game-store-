using System;
using System.Web.UI;

namespace SteamHadaWeb
{
    public partial class SorteoPage : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            imagen_del_sorteo.ImageUrl = Request.QueryString["imagen"].ToString();
            nombre.Text = Request.QueryString["nombre"].ToString();
            descripcion_sorteo.Text = Request.QueryString["descripcion"].ToString();

        }
    }
}

