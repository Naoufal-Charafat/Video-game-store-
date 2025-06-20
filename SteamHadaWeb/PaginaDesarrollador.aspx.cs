using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SteamHadaLib;
namespace SteamHadaWeb
{
    public partial class PaginaDesarrollador : System.Web.UI.Page
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            ENCliente cliente = new ENCliente();
            cliente.Correo = Session["correo"].ToString();
            BoundField btnField = new BoundField();
            btnField.HeaderText = "Comandos";
            listaJuegos.Columns.Add(btnField);
            listaJuegos.DataSource = cliente.readListaJuegosDesarrollados();
            listaJuegos.DataBind();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                AddLinkButton();
            }
        }

        protected void listaJuegos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            AddLinkButton();
        }
        private void AddLinkButton()
        {

            foreach (GridViewRow row in listaJuegos.Rows)
            {
                
                if (row.RowType == DataControlRowType.DataRow&&row.Cells[0].Controls.Count==0)
                {
                    Button lb = new Button();
                    lb.Text = "Eliminar";
                    lb.CommandName = "Eliminar";
                    lb.Command += LinkButton_CommandDelete;
                    Button lb2 = new Button();
                    lb2.Text = "Editar";
                    lb2.CommandName = "Editar";
                    lb2.Command += LinkButton_CommandUpdate;
                    lb2.ValidationGroup = "valGroup1";
                    row.Cells[0].Controls.Add(lb);
                    row.Cells[0].Controls.Add(lb2);

                }
            }
        }

        protected void LinkButton_CommandUpdate(object sender, CommandEventArgs e)
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

            GridViewRow fila =(GridViewRow) ((Button)sender).Parent.Parent;
            string nombreJuego = ((DataControlFieldCell) fila.Controls[1]).Text;
            string descripcion = GameDescReq2.Text;
            float precio = float.Parse(GamePriceReq2.Text);
            string categoria = DropDownList1.SelectedValue.ToString();
            
            if(new ENJuego(nombreJuego, precio, rutaRelativa, descripcion, categoria, Session["correo"].ToString()).modificarJuego()) {
                RegGameNomFileUpload2.SaveAs(nombre);
                Response.Redirect("PaginaDesarrollador.aspx");
            }

        }
        protected void LinkButton_CommandDelete(object sender, CommandEventArgs e)
        {
            GridViewRow fila = (GridViewRow)((Button)sender).Parent.Parent;
            string nombreJuego = ((DataControlFieldCell)fila.Controls[1]).Text;

            if (new ENJuego(nombreJuego, 0, "", "", "", "").eliminarJuegoo())
            {
                
                Response.Redirect("PaginaDesarrollador.aspx");
            }

        }
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
        }

        protected void saveChanges_Click(object sender, EventArgs e)
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


            if (new ENJuego(GameNameReq.Text, float.Parse(GamePriceReq.Text),rutaRelativa,GameDescReq.Text,DDLCategoria.SelectedValue.ToString(), Session["correo"].ToString()).crearJuego()){//session
                RegGameNomFileUpload.SaveAs(nombre);
                Response.Redirect("PaginaDesarrollador.aspx");
            }
        }
    }
}