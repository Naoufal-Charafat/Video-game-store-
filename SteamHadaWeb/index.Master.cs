using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SteamHadaWeb
{
    public partial class indexMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Menu1.Items[0].Selectable = false;
            Menu1.Items[0].ChildItems[0].Selectable= false;
            Menu1.Items[2].Selectable = false; 
            if (Session["correo"] != null)
            {

                textLogin.Visible = false;
                textRegistro.Visible = false;
                imageRegistro.Visible = false;
                imageLogin.Visible = false;
                Menu1.Items[4].ImageUrl = Session["rutaImagen"].ToString();
                Menu1.Items[4].Text = Session["nombre"].ToString();
                Menu1.Items[4].Selectable = true;
                Menu1.Items[4].ChildItems[0].Selectable = true;
                Menu1.Items[4].ChildItems[1].Selectable = true;
                Menu1.Items[4].ChildItems[2].Selectable = true;
                Menu1.Items[4].ChildItems[3].Selectable = true;
                Menu1.Items[4].Enabled = true;
                if (int.Parse(Session["privilegio"].ToString()) > 0&&Menu1.Items[4].ChildItems.Count<5) {
                    MenuItem item = new MenuItem();
                    item.Text = "Opciones de desarrollador";
                    item.NavigateUrl = "PaginaDesarrollador.aspx";
                    Menu1.Items[4].ChildItems.Add(item);

                }
            }
            else {
                textLogin.Visible = true;
                textRegistro.Visible = true;
                imageRegistro.Visible = true;
                imageLogin.Visible = true;
                Menu1.Items[4].ImageUrl = "imagenes/avatar.png";
                Menu1.Items[4].Selectable = false;
                Menu1.Items[4].Enabled = false;
                Menu1.Items[4].ChildItems[0].Selectable = false;
                Menu1.Items[4].ChildItems[1].Selectable = false;
                Menu1.Items[4].ChildItems[2].Selectable = false;
                Menu1.Items[4].ChildItems[3].Selectable = false;
                Menu1.Items[4].Text = "Configuración";
            }
        }


        protected void Menu1_MenuItemClick(object sender, MenuEventArgs e)
        {
            if (e.Item.Text.Equals("Cerrar sesión")) {
                Session.RemoveAll();
            
                Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "fbLogoutUser()", true);
            }
        
        }
    }

}