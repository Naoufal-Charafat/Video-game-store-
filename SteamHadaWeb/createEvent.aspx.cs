using SteamHadaLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SteamHadaWeb
{
    public partial class createEvent : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void crearEvento(object sender, EventArgs e)
        {
            ENEvento s = new ENEvento();
            ENEventoFisico en = new ENEventoFisico(Empresa.Text, Localidad.Text, Provincia.Text, int.Parse(Tlf.Text), int.Parse(Precio.Text));
            en.codigo = s.codigo;
            en.nombre = Nombre.Text;
            en.descripcion = Descripcion.Text;
            en.fecha_inicio = FechaInit.Text;
            en.fecha_fin = FechaOut.Text;
            en.hora_inicio = double.Parse(HoraInit.Text);
            en.hora_fin = double.Parse(HoraOut.Text);
            en.email = Email.Text;

            if(en.createEvents() == true)
            {
                LabelRespuesta.Text = "     Evento creado correctamente";

            }
            else
            {
                LabelRespuesta.Text = "     Evento no creado";
            }
        }
    }
}