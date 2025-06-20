<%@ Page Title="" Language="C#" MasterPageFile="~/index.Master" AutoEventWireup="true" CodeBehind="Sorteo.aspx.cs" Inherits="SteamHadaWeb.Sorteo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <style type="text/css">
        .auto-style1 {
            width: 702px;
            height: 317px;
        }

        .auto-style2 {
            margin-left: 2221px;
        }

        .auto-style3 {
            width: 721px;
            height: 200px;
            margin-left: auto;
            margin-right: auto;
            margin-top: 90px;
            margin-bottom: 0;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div align="right">
        <br />
        <asp:ImageButton ID="crearSorteos" OnClick="Click_crearSorteos" Visible="false" runat="server" CssClass="auto-style2" Height="3%" ImageAlign="Right" ImageUrl="~/imagenes/crear_sorteos.png" Width="10%" />
    </div>
    <div align="center">
        <h1 align="center" class="auto-style1">
            <img alt="" class="auto-style1" src="imagenes/SORTEOS_BOGAMES.gif" />&nbsp;
        </h1>
    </div>







    <asp:PlaceHolder runat="server" ID="crear_sorteos_admin" Visible="false">
        <asp:Table runat="server" class="auto-style3">
            <asp:TableRow>
                <asp:TableCell HorizontalAlign="Left" Width="15%" VerticalAlign="Middle">
							Titulo del Sorteo:
                </asp:TableCell>
                <asp:TableCell HorizontalAlign="Right" Width="85%" VerticalAlign="Middle">
                    <asp:TextBox
                        ID="NombreNuevoSorteo" CssClass="TextBox_personalizado" runat="server" Width="100%">
                    </asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell HorizontalAlign="Left" Width="15%" VerticalAlign="Middle">
							Imagen del Sorteo:
                </asp:TableCell>
                <asp:TableCell HorizontalAlign="Right" Width="85%" VerticalAlign="Middle">

                    <div align="left">
                        <asp:FileUpload ID="imagenSorteo" runat="server" />
                    </div>
                </asp:TableCell>
            </asp:TableRow>



            <asp:TableRow>
                <asp:TableCell HorizontalAlign="Left" Width="15%" VerticalAlign="Middle">
                        Descripción del Sorteo: 
							<br />
                        <br />        
                    
                </asp:TableCell>
                <asp:TableCell HorizontalAlign="Right" Width="85%" VerticalAlign="Middle">
                    <asp:TextBox
                        ID="DescripcionNuevoSorteo" CssClass="TextBox_personalizado" TextMode="MultiLine" runat="server" Width="100%" Height="350px">
                    </asp:TextBox>
                    <a href="Sorteo.aspx">
                        <asp:ImageButton ID="BOTON_CREAR_EVENTO" OnClick="Click_BotonCREARsorteo" runat="server" Width="130px" ImageUrl="~/imagenes/BOTON_CREAR_EVENTO.gif" />
                    </a>

                </asp:TableCell>

            </asp:TableRow>
        </asp:Table>

        <div align="center">

            <asp:RequiredFieldValidator
                ID="RequiredFieldValidator1" ForeColor="Red" CssClass="TextBox_personalizado" ErrorMessage="Necesitas escribir un Titulo para crear un sorteo" ControlToValidate="NombreNuevoSorteo" runat="server" />
            <asp:RequiredFieldValidator
                ID="RequiredFieldValidator2" ForeColor="Red" CssClass="TextBox_personalizado" ErrorMessage="Necesitas subir una foto para crear un sorteo" ControlToValidate="imagenSorteo" runat="server" />
            <asp:RequiredFieldValidator
                ID="RequiredFieldValidator3" ForeColor="Red" CssClass="TextBox_personalizado" ErrorMessage="Necesitas escribir una Descripción para crear un sorteo" ControlToValidate="DescripcionNuevoSorteo" runat="server" />

        </div>

    </asp:PlaceHolder>






    <div align="center">
        <asp:FormView ID="SorteoPrincipal" DataSourceID="SqlDataSource1" OnLoad="FormView_SorteoPrincipal" runat="server" Height="156px" Width="776px">

            <ItemTemplate>
                <a href="SorteoPage.aspx?nombre=<%# Eval("nombre") %>
                        &imagen=<%# Eval("imagen", "~/imagenes/{0}")%>
                        &descripcion=<%# Eval("descripcion")%>">&nbsp;
                    <asp:Image ID="Image1" runat="server" Height="394px" ImageUrl='<%# Eval("imagen", "~/imagenes/{0}") %>' Width="906px" />
                    <br />
                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("nombre") %>' BorderColor="#CC3300" BorderStyle="Solid" Font-Bold="True" Font-Size="X-Large"></asp:Label>
                    <asp:Button runat="server" Text="Participa" CssClass="Participa" />
                    <br />
                    <br />
                </a>
            </ItemTemplate>

        </asp:FormView>

        <asp:SqlDataSource
            ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:miconexion %>" SelectCommand="select imagen,nombre, descripcion  from Sorteo where fechaHora = (select max(fechaHora) from Sorteo)"></asp:SqlDataSource>
    </div>



    <h2 align="center">&nbsp;</h2>
    <h2 align="center">&nbsp;</h2>


    <div align="center">
        <h1>
            <asp:Label ID="titulo_SorteosAnteriores" runat="server" Visible="true" Text="Sorteos Anteriores"></asp:Label></h1>

        <asp:GridView ID="tablaSorteosAnteriors" runat="server" Visible="true"
            OnLoad="GridView_SorteosAnteriores" AutoGenerateColumns="False"
            RowStyle-HorizontalAlign="Center"
            AllowPaging="True"
            CssClass="mGrid">
            <Columns>
                <asp:BoundField DataField="nombre" HeaderText="EVENTOS" SortExpression="nombre" />
                <asp:ImageField DataImageUrlField="imagen" DataImageUrlFormatString="~/imagenes/{0}">
                </asp:ImageField>
            </Columns>
            <RowStyle HorizontalAlign="Center"></RowStyle>
        </asp:GridView>

        <br />
        <br />
        <br />
        <br />
    </div>
</asp:Content>
