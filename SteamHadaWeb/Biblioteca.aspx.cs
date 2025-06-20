using SteamHadaLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace SteamHadaWeb
{
    public partial class Biblioteca2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GridView1_SelectedIndexChanged(sender, e);
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ENCliente cliente = new ENCliente();
                cliente.Correo = Session["correo"].ToString();
                cliente.biblioteca_cliente(GridView1);
            }
            catch (Exception) { }

        }
    }
}