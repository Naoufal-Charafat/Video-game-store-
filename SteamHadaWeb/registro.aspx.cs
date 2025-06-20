using SteamHadaLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SteamHadaWeb
{
    public partial class registroUsuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["correo"] != null)
            {
                Response.Redirect("Index.aspx");
            }
        }


        [System.Web.Services.WebMethod]
        public static bool cargaDatosFB(String correo, String nombreF, String apellidos, String ruta)
        {
            Random rnd = new Random();
            string characters = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            StringBuilder builder = new StringBuilder(20);
            for (int i = 0; i < 20; i++)
            {
                builder.Append(characters[rnd.Next(characters.Length)]);
            }
            String nombre = builder.ToString();
            String rutaRelativa = "imagenes\\" + nombre + ".png";
            nombre = AppDomain.CurrentDomain.BaseDirectory + "\\imagenes\\" + nombre + ".png";
            
            ENCliente cliente=new ENCliente(correo, nombreF, apellidos, "", "", rutaRelativa, "");
            if (cliente.createCliente())
            {
                HttpContext.Current.Session["correo"] = correo;
                HttpContext.Current.Session["nombre"] = nombreF;
                HttpContext.Current.Session["Apellido"] = apellidos;
                HttpContext.Current.Session["rutaImagen"] = rutaRelativa;
                HttpContext.Current.Session["privilegio"] = 0;
                HttpContext.Current.Session["saldo"] = 0;
                HttpContext.Current.Session["telefono"] = "123456789";
                HttpContext.Current.Session["biografia"] = " ";
                HttpContext.Current.Session["contrasena"] = " ";
                new WebClient().DownloadFile(ruta, nombre);
                return true;
            }
            else if (cliente.readCliente()) {
                HttpContext.Current.Session["correo"] = cliente.Correo;
                HttpContext.Current.Session["nombre"] = cliente.Nombre;
                HttpContext.Current.Session["Apellido"] = cliente.Apellidos;
                HttpContext.Current.Session["rutaImagen"] = cliente.Foto;
                HttpContext.Current.Session["saldo"] = cliente.Saldo;
                HttpContext.Current.Session["privilegio"] = cliente.Privilegio;
                HttpContext.Current.Session["telefono"] = cliente.Telefono;
                HttpContext.Current.Session["biografia"] = cliente.Biografia;
                HttpContext.Current.Session["contrasena"] = " ";
                return true;
            }
            return false;
        }

        protected void ButIngresar_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            string characters = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            StringBuilder builder = new StringBuilder(20);
            for (int i = 0; i < 20; i++)
            {
                builder.Append(characters[rnd.Next(characters.Length)]);
            }
            String nombre = builder.ToString();
            String rutaRelativa = "imagenes\\" + nombre + ".png";
            nombre = AppDomain.CurrentDomain.BaseDirectory + "\\imagenes\\" + nombre + ".png";

          
            if (new ENCliente(RegUsuarioCorreo.Text,RegUsuarioNom.Text,RegUsuarioApell.Text,RegUsuarioContra.Text,"",rutaRelativa,RegUsuarioTel.Text).createCliente()) {
                Session["correo"] = RegUsuarioCorreo.Text;
                Session["nombre"] = RegUsuarioNom.Text;
                Session["telefono"] = RegUsuarioTel.Text;
                Session["Apellido"] = RegUsuarioApell.Text;
                Session["rutaImagen"] = rutaRelativa;
                Session["contrasena"] = RegUsuarioContra.Text;
                Session["saldo"] = 0;
                Session["privilegio"] = 0;
                Session["biografia"] = "";
                RegUsuarioNomFileUpload.SaveAs(nombre);
                enviaCorreo();
                Response.Redirect("Index.aspx");
               
            }
            else
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Ha ocurrido un error')", true);
            }
        }
        private void enviaCorreo() {
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);

            smtpClient.Credentials = new System.Net.NetworkCredential("bogames2019@gmail.com", "Steamhada2019");
            MailMessage message = new MailMessage();
            try
            {
                MailAddress fromAddress = new MailAddress("bochen47@gmail.com", "Alias remitente");
               
                MailAddress toAddress = new MailAddress(Session["correo"].ToString(), "Alias destinatario");
                message.From = fromAddress;
                message.To.Add(toAddress);
                message.Subject = "Bienvenido a BoGames!";
             message.Body = "Te damos la bienvenida a bogames";
             smtpClient.EnableSsl = true;

               
                smtpClient.Send(message);
               
            }
            catch (Exception ex)
            {
                string a = ex.ToString();
            }
        }
    }
}