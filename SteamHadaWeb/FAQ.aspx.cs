using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SteamHadaLib;

namespace SteamHadaWeb
{
    
    public partial class FAQ : System.Web.UI.Page
    {
        ENFaq faq = new ENFaq();
        DataSet d = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                d = faq.obtenerFaq();

                GridView1.DataSource = d;
                GridView1.DataBind();

                
            }
            Respuesta.Attributes.Add("maxlength", Respuesta.MaxLength.ToString());
            if(Session["privilegio"] != null)
            {
                if (int.Parse((Session["privilegio"]).ToString()) == 2)
                {
                    Crear.Visible = true;
                    Modificar.Visible = true;
                    Borrar.Visible = true;
                    Label.Visible = true;
                    Label1.Visible = true;
                    Label2.Visible = true;
                    CodFAQ.Visible = true;
                    Pregunta.Visible = true;
                    Respuesta.Visible = true;
                }
            }
            
        }
       

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            d = faq.obtenerFaq();
            GridView1.PageIndex = e.NewPageIndex;
            GridView1.DataSource = d;
            GridView1.DataBind();
        }

        protected void Crear_Click(object sender, EventArgs e)
        {
            
            //faq.Codigo = int.Parse(CodFAQ.Text);
            faq.Pregunta = Pregunta.Text;
            faq.Respuesta = Respuesta.Text;

            if (faq.insertFaq())
            {
                Pregunta.Text = "ha sido creada";

            }

        }

        protected void Modificar_Click(object sender, EventArgs e)
        {
            faq.Codigo = int.Parse(CodFAQ.Text);
            faq.Pregunta = Pregunta.Text;
            faq.Respuesta = Respuesta.Text;
            faq.updateFaq();
        }

        protected void Borrar_Click(object sender, EventArgs e)
        {
            faq.Codigo = int.Parse(CodFAQ.Text);
            faq.deleteFaq();
        }
    }
}