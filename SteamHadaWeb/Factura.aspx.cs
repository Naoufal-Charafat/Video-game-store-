using Apitron.PDF.Kit.FlowLayout.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Apitron.PDF.Kit.FlowLayout;
using Apitron.PDF.Kit.Styles;
using Apitron.PDF.Kit.Styles.Appearance;
using Apitron.PDF.Kit.FixedLayout.Resources.Fonts;
using Apitron.PDF.Kit.FixedLayout.Resources;
using System.IO;
using Image = Apitron.PDF.Kit.FlowLayout.Content.Image;
using Apitron.PDF.Kit;
using Apitron.PDF.Kit.FixedLayout.PageProperties;
using Apitron.PDF.Kit.FixedLayout;
using SteamHadaLib;
using System.Data;

namespace SteamHadaWeb
{
    public partial class Factura : System.Web.UI.Page
    {
        ENFacturacion factura = new ENFacturacion();
        DataSet d = new DataSet();
        protected void Page_Init(object sender, EventArgs e)
        {
            if(Session["correo"]==null) Response.Redirect("Index.aspx");

            BoundField btnField = new BoundField();
            btnField.HeaderText = "Descargar";
            GridView1.Columns.Add(btnField);
            GridView1.DataSource = factura.obtenerFacturasPorCliente(Session["correo"].ToString());
            GridView1.DataBind();
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

            foreach (GridViewRow row in GridView1.Rows)
            {

                if (row.RowType == DataControlRowType.DataRow && row.Cells[3].Controls.Count == 0)
                {
                    Button lb = new Button();
                    lb.Text = "Descargar";
                    lb.CommandName = "Descargar";
                    lb.Command += ImageButton_CommandDownload;
                    row.Cells[3].Controls.Add(lb);

                }
            }
        }

        

        protected void ImageButton_CommandDownload(object sender, CommandEventArgs e)
        {
            GridViewRow fila = (GridViewRow)((Button)sender).Parent.Parent;
            string fecha = ((DataControlFieldCell)fila.Controls[1]).Text;
            float importe = float.Parse(((DataControlFieldCell)fila.Controls[2]).Text);
            GenerateInvoice(Session["nombre"].ToString(), fecha, importe);

        }
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            d = factura.obtenerFacturasPorCliente(Session["correo"].ToString());
            GridView1.PageIndex = e.NewPageIndex;
            GridView1.DataSource = d;
            GridView1.DataBind();
        }
        
        private void GenerateInvoice(string cliente,string fecha,float precio) {
            string imagesPath = AppDomain.CurrentDomain.BaseDirectory + "\\imagenes\\";
            
            FlowDocument document = new FlowDocument();

            document.StyleManager.RegisterStyle("gridrow.tableHeader", new Apitron.PDF.Kit.Styles.Style() { Background = RgbColors.LightSlateGray });
            document.StyleManager.RegisterStyle("gridrow.centerAlignedCells > *,gridrow > *.centerAlignedCell", new Apitron.PDF.Kit.Styles.Style() { Align = Align.Center, Margin = new Thickness(0) });
            document.StyleManager.RegisterStyle("gridrow > *.leftAlignedCell", new Apitron.PDF.Kit.Styles.Style() { Align = Align.Left, Margin = new Thickness(5, 0, 0, 0) });
            document.StyleManager.RegisterStyle("gridrow > *", new Apitron.PDF.Kit.Styles.Style() { Align = Align.Right, Margin = new Thickness(0, 0, 5, 0) });

            ResourceManager resourceManager = new ResourceManager();
            resourceManager.RegisterResource(
                new Apitron.PDF.Kit.FixedLayout.Resources.XObjects.Image("logo",
                Path.Combine(imagesPath, "BoGames.png"), true)
                { Interpolate = true });

            resourceManager.RegisterResource(new Apitron.PDF.Kit.FixedLayout.Resources.XObjects.Image("stamp", Path.Combine(imagesPath, "BoGames.png"), true) { Interpolate = true });
            document.PageHeader.Margin = new Thickness(0, 40, 0, 20);
            document.PageHeader.Padding = new Thickness(10, 0, 10, 0);
            document.PageHeader.Height = 120;
            document.PageHeader.Background = RgbColors.LightGray;
            document.PageHeader.LineHeight = 60;
            document.PageHeader.Add(new Image("logo") { Height = 50, Width = 50, VerticalAlign = Apitron.PDF.Kit.Styles.Appearance.VerticalAlign.Middle });
            document.PageHeader.Add(new TextBlock("Factura")
            {
                Display = Display.InlineBlock,
                Align = Align.Right,
                Font = new Apitron.PDF.Kit.Styles.Text.Font(StandardFonts.CourierBold,20),
                Color = RgbColors.Black
            });
            Section pageSection = new Section() { Padding = new Thickness(20) };
            pageSection.AddItems(CreateInfoSubsections(new string[] {"BOGAMES"," recibo para :\r\n",cliente,"\n Fecha:",fecha }));// cambiar cliente tonto por objeto session
 
            pageSection.Add(new Hr() { Padding = new Thickness(0, 20, 0, 20) });
            pageSection.Add(CreateProductsGrid(precio));
            pageSection.Add(new Br { Height = 20 });
            pageSection.Add(new Section() { Width = 250, Display = Display.InlineBlock });
            pageSection.Add(new Image("stamp"));

            document.Add(pageSection);
            FileStream file = File.OpenWrite(imagesPath + "Factura.pdf");
            document.Write(file, resourceManager, new PageBoundary(Boundaries.A4));
            file.Close();
        }
        private Grid CreateProductsGrid(float precio) {
            ENFacturacion factura = new ENFacturacion();
            Grid productsGrid = new Grid(20, 60, 40, 50, 55);
            productsGrid.Add(new GridRow(new TextBlock("#"), new TextBlock("Juego"), new TextBlock("Precio"), new TextBlock("Desc.(%)"), new TextBlock("Total")) { Class = "tableHeader centerAlignedCells" });

                // foreach ( product in products)
                //{
                TextBlock pos = new TextBlock(""+1) { Class = "centerAlignedCell" };
                TextBlock description = new TextBlock("Juego") { Class = "leftAlignedCell" };
//                TextBlock qty = new TextBlock(""+1) { Class = "centerAlignedCell" };
                TextBlock price = new TextBlock(""+precio);
                TextBlock discount = new TextBlock(""+0);
                TextBlock total = new TextBlock(""+precio);
                productsGrid.Add(new GridRow(pos, description, price, discount, total));


                productsGrid.Add(new GridRow(new TextBlock("Total(€)") { ColSpan = 4}, new TextBlock(""+precio)));

            return productsGrid;
        }
        private IList<Section> CreateInfoSubsections(string[] info)
        {
            List<Section> createdSections = new List<Section>();
            double width = 100.0 / info.Length;
            for (int i = 0; i < info.Length; i++)
            {
                Section section = new Section()
                {
                    Width = Length.FromPercentage(width),
                    Display = Display.InlineBlock
                };
                using (StringReader reader = new StringReader(info[i]))
                {
                    string currentLine = null;
                    while ((currentLine = reader.ReadLine()) != null)
                    {
                        section.Add(new TextBlock(currentLine));
                        section.Add(new Br());
                    }
                }
                createdSections.Add(section);
            }
            return createdSections;
        }

    }
}