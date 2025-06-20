using SteamHadaLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SteamHadaWeb
{
    public partial class Reclamaciones : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
           
        }


     
        protected void Modificar_Click(Object sender, EventArgs e)
        {
            Reclamacion reclamacion = new Reclamacion();
            reclamacion.Titulo = TextBox1.Text;
            reclamacion.Cuerpo = TextBox2.Text;
            reclamacion.Fecha = DateTime.Now;
            reclamacion.Pedido = int.Parse(TextBox3.Text);


            ENFacturacion enfactura = new ENFacturacion();
            enfactura.cambiarReclamacion(reclamacion);
            enfactura.pedidoFact = int.Parse(TextBox3.Text);

            if (enfactura.updateReclamacion(Session["correo"].ToString()))
            {
                TextBox1.Text = "Ha sido modificado";
            }
        }

        protected void Leer_Click(object sender, EventArgs e)
        {
            ENFacturacion enfactura = new ENFacturacion();
            enfactura.pedidoFact = int.Parse(TextBox3.Text);



            if (enfactura.readReclamacion(Session["correo"].ToString()))
            {
                TextBox3.Text = enfactura.pedidoFact.ToString();
                TextBox2.Text = enfactura.getCuerpoReclamacion();
                TextBox1.Text = enfactura.getTituloReclamacion();
            }
            else
            {
                TextBox1.Text = "No existe la reclamacion";
            }
        }

        protected void Borrar_Click(object sender, EventArgs e)
        {
            ENFacturacion enfactura = new ENFacturacion();
            enfactura.pedidoFact = int.Parse(TextBox3.Text);
            if (enfactura.deleteReclamacion(Session["correo"].ToString()))
            {
                //enfactura.reclamacionFact = false;
                TextBox3.Text = "Ha sido borrado";
            }
            else
            {
                TextBox1.Text = "No existe la reclamacion";
            }
        }

        protected void Reclamar_Click1(object sender, EventArgs e)
        {
            /*public string Titulo { get; set; }
             public string Cuerpo { get; set; }
             public DateTime Fecha { get; set; }
             public int Pedido { get; set; }*/
            Reclamacion reclamacion = new Reclamacion();
            reclamacion.Titulo = TextBox1.Text;
            reclamacion.Cuerpo = TextBox2.Text;
            reclamacion.Fecha = DateTime.Now;
            reclamacion.Pedido = int.Parse(TextBox3.Text);


            ENFacturacion enfactura = new ENFacturacion();
            enfactura.cambiarReclamacion(reclamacion);
            enfactura.pedidoFact = int.Parse(TextBox3.Text);
            if (enfactura.createReclamacion(Session["correo"].ToString()))
            {
                //enfactura.reclamacionFact = true;
                TextBox3.Text = "Ha sido creada";
            }
            else {
                TextBox3.Text = "No se ha podido crear, a lo mejor ya existe, dale a Leer";
            }
        }
    }
}