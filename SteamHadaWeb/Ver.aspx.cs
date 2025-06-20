using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace SteamHadaWeb
{
    public partial class Ver : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String a = Request.QueryString["value"];
            URL.Text = a.ToString();
            URL.Visible = false;
            this.video1.Attributes["src"] = "" + a.ToString() + "";
        }

        /// <summary>
        /// Cuando haces click en la imagen del video, comienza a reproducirlo desde la Base de Datos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void EventoReproducirBD(object sender, EventArgs e)
        {
           
        }

        /// <summary>
        /// Cuando haces click en la imagen del video, comienza a retransmitir la conferencia en directo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void EventoReproducirAir(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Cuando haces click en enviar comentario, debe almacenarloen los comentarios del video y mostrarlos por pantalla
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void EventoSendMessage(object sender, EventArgs e)
        {

        }
    }
}