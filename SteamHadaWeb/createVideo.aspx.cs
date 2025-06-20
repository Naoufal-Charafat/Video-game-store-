using SteamHadaLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SteamHadaWeb
{
    public partial class createVideo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void crearVideo(object sender, EventArgs e)
        {
            ENEventoVirtual en = new ENEventoVirtual();

            en.url = Youtube.Text;
            en.juego = Juego.Text;
            en.autor = Autor.Text;

            if (en.createEvents() == true)
            {
                LabelRespuesta.Text = "Evento creado correctamente";
            }
            else
            {
                LabelRespuesta.Text = "Evento no creado";
            }
        }
    }
}