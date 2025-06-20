using SteamHadaLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SteamHadaWeb
{
    public partial class Eventos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["correo"] != null && int.Parse((Session["privilegio"]).ToString()) != 0)
            {
                Menu2.Items[2].Selectable = true;
                Menu2.Items[3].Selectable = true;
				Menu2.Items[0].Selectable = true;

			}
            else
            {
                Menu2.Items[2].Selectable = true;
                Menu2.Items[3].Selectable = true;
				Menu2.Items[0].Selectable = false;

			}

        }

        protected void escogerEvento(object sender, EventArgs e)
        {
            Response.Redirect("~/verEvento.aspx?value=" + ((LinkButton)sender).Text);
        }
    }
}