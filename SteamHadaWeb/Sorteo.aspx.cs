using SteamHadaLib;
using System;
using System.Windows.Forms;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

namespace SteamHadaWeb
{
    public partial class Sorteo : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


            if (Session["correo"] != null)
            {
                if (int.Parse(Session["privilegio"].ToString()) == 2)
                {
                    crearSorteos.Visible = true;
                } 
            }

            if (!IsPostBack)
            {
                FormView_SorteoPrincipal(sender, e);
                GridView_SorteosAnteriores(sender, e);
            }
        }

        protected void FormView_SorteoPrincipal(object sender, EventArgs e)
        {

            try
            {
                ENSorteo sorteoPrincipal = new ENSorteo();
                sorteoPrincipal.Sorteo_principal(SorteoPrincipal);

            }
            catch (Exception) { }
        }
      

        protected void GridView_SorteosAnteriores(object sender, EventArgs e)
        {
            try
            {
                ENSorteo sorteos = new ENSorteo();
                sorteos.TablaSorteos_anteriores(tablaSorteosAnteriors);
                
            }
            catch (Exception) { }
        }


        protected void Click_crearSorteos(object sender, ImageClickEventArgs e)
        {
            crear_sorteos_admin.Visible = true;
            SorteoPrincipal.Visible = false;
            tablaSorteosAnteriors.Visible = false;
            titulo_SorteosAnteriores.Visible = false;
        }
        
        protected void Click_BotonCREARsorteo(object sender, EventArgs e)
        {
           try
           {
                //se a cumplicado la parte de subir foto ya que uso un ( FormView ID="SorteoPrincipal"  ) y no se como enlazarle la url
                /*
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
                    imagenSorteo.SaveAs(nombre);

                    SorteoPrincipal.BackImageUrl = rutaRelativa;
                  */

                //string adm = "KIKE_CHARAFAT"; para comprobar que va bien 
                ENSorteo creaSorteo = new ENSorteo();
                creaSorteo.nombre = NombreNuevoSorteo.Text;
                //creaSorteo.imagen = rutaRelativa;
                //creaSorteo.usr_Adm = adm;  para comprobar que va bien 
                creaSorteo.usr_Adm = Session["correo"].ToString();
                
                creaSorteo.descripcion = DescripcionNuevoSorteo.Text;
                creaSorteo.createSorteo();
                
                Response.Redirect("Sorteo.aspx");
           }
           catch (Exception) { }

        }
    
    }
}