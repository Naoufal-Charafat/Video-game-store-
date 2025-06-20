using SteamHadaLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SteamHadaWeb
{
    public partial class Videos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        /// <summary>
        /// Muestra todos los videos almacenados en la base de datos según los filtros puestos por el usuario, si no tienen ninguno, muestra todos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void filtrarVideos(object sender, EventArgs e)
        {
            ENEventoVirtual evento = new ENEventoVirtual();
            evento.juego = Juego.Text;
            videosGridView.DataSource = evento.readVideos();
            videosGridView.DataBind();
        }

        protected void verVideo(object sender, EventArgs e)
        {
            Response.Redirect("~/Ver.aspx?value=" + ((LinkButton)sender).Text);
        }
    }
}