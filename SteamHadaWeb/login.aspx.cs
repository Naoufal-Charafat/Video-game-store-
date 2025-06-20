using SteamHadaLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace SteamHadaWeb
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["correo"] != null)
            {
                Response.Redirect("Index.aspx");
            }
        }

        protected void ButIngresar_Click(object sender, EventArgs e)
        {
            ENCliente cliente = new ENCliente(TextUsuario.Text.ToString(), Textcontrasenya.Text.ToString());
            if (cliente.readCliente())
            {
                Session["correo"] = cliente.Correo;
                Session["nombre"] = cliente.Nombre;
                Session["telefono"] = cliente.Telefono;
                Session["Apellido"] = cliente.Apellidos;
                Session["rutaImagen"] = cliente.Foto;
                Session["contrasena"] = cliente.Contrasenya;
				Session["biografia"] = cliente.Biografia;
                Session["saldo"] = cliente.Saldo;
                Session["privilegio"] = cliente.Privilegio;
                Response.Redirect("Index.aspx");
            
            }
            else {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "loginIncorrecto()", true);
            }
        }
    }
}