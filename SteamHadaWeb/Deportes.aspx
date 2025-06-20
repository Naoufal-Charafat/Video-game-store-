<%@ Page Title="" Language="C#" MasterPageFile="~/index.Master" AutoEventWireup="true" CodeBehind="Deportes.aspx.cs" Inherits="SteamHadaWeb.Deportes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
                <h2>Juegos de Deportes</h2>
    <ul>
                <li class="auto-style2"><strong>FILTRO</strong></li>
                <br />
                <li>
                    <br />
                Nombre: <asp:TextBox ID ="Nombre" runat ="server" Width="299px"></asp:TextBox>
                    </li><br />
                <li>
                    <asp:Button ID="Buscar" runat ="server" Text="Buscar" OnClick="Buscar_OnClick"></asp:Button>
                </li>
            </ul>
          </div>
         <br />
         <br />
         <br />
         <br />
         <br />
         <br />
    <br />

    
    <ul>
        <div id="resultados filtro">
        <h3>Resultados más aproximados:</h3>
        <div>
        <br />

        <div class="card">
                
                    <img ID="filtro1imagen" runat="server" src="plman.png" style="height: 176px; width: 209px"/>
                    <br />
                    <br />
                    <br />
                    <asp:Label runat="server" style="font-weight: 700; font-size: medium; ">
                        <asp:LinkButton ID="Filtro1Nombre" runat="server" Text="SIN RESULTADO" OnClick="Resultado_OnClick">

                        </asp:LinkButton>
                    </asp:Label>
                <br />
                
                    <asp:Label ID="Filtro1Precio" runat="server" Text="0.00€"></asp:Label>
                    <br />
                
                 <asp:Button ID="Comprar1" runat="server" OnClick="Comprar_OnClick" Text="Sin resultado" CssClass="btnAnyadirCarrito"/>
            </div>

            <div class="card">
                
                    <img ID="filtro2imagen" runat="server" src="plman.png" style="height: 176px; width: 209px"/>
                    <br />
                    <br />
                    <br />
                    <asp:Label runat="server" style="font-weight: 700; font-size: medium; ">
                        <asp:LinkButton ID="Filtro2Nombre" runat="server" Text="SIN RESULTADO" OnClick="Resultado_OnClick">

                        </asp:LinkButton>
                    </asp:Label>
                <br />
                
                    <asp:Label ID="Filtro2Precio" runat="server" Text="0.00€"></asp:Label>
                    <br />
                
                 <asp:Button ID="Comprar2" runat="server" OnClick="Comprar_OnClick" Text="Sin resultado" CssClass="btnAnyadirCarrito"/>
            </div>

            <div class="card">
                
                    <img ID="filtro3imagen" runat="server" src="plman.png" style="height: 176px; width: 209px"/>
                    <br />
                    <br />
                    <br />
                    <asp:Label runat="server" style="font-weight: 700; font-size: medium; ">
                        <asp:LinkButton ID="Filtro3Nombre" runat="server" Text="SIN RESULTADO" OnClick="Resultado_OnClick">

                        </asp:LinkButton>
                    </asp:Label>
                <br />
                
                    <asp:Label ID="Filtro3Precio" runat="server" Text="0.00€"></asp:Label>
                    <br />
                
                 <asp:Button ID="Comprar3" runat="server" OnClick="Comprar_OnClick" Text="Sin resultado" CssClass="btnAnyadirCarrito"/>
            </div>

            <div class="card">
                
                    <img ID="filtro4imagen" runat="server" src="plman.png" style="height: 176px; width: 209px"/>
                    <br />
                    <br />
                    <br />
                   <asp:Label runat="server" style="font-weight: 700; font-size: medium; ">
                        <asp:LinkButton ID="Filtro4Nombre" runat="server" Text="SIN RESULTADO" OnClick="Resultado_OnClick">

                        </asp:LinkButton>
                    </asp:Label>
                <br />
                
                    <asp:Label ID="Filtro4Precio" runat="server" Text="0.00€"></asp:Label>
                    <br />
                
                 <asp:Button ID="Comprar4" runat="server" OnClick="Comprar_OnClick" Text="Sin resultado" CssClass="btnAnyadirCarrito"/>
            </div>

            <div class="card">
                
                    <img ID="filtro5imagen" runat="server" src="plman.png" style="height: 176px; width: 209px"/>
                    <br />
                    <br />
                    <br />
                    <asp:Label runat="server" style="font-weight: 700; font-size: medium; ">
                        <asp:LinkButton ID="Filtro5Nombre" runat="server" Text="SIN RESULTADO" OnClick="Resultado_OnClick">

                        </asp:LinkButton>
                    </asp:Label>
                <br />
                
                    <asp:Label ID="Filtro5Precio" runat="server" Text="0.00€"></asp:Label>
                    <br />
                
                 <asp:Button ID="Comprar5" runat="server" OnClick="Comprar_OnClick" Text="Sin resultado" CssClass="btnAnyadirCarrito"/>
            </div>
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />

            <br />

            <asp:Label runat="server" Text ="Listado completo de juegos de Deportes" style="font-size: large"></asp:Label>
            
            
    <asp:GridView ID="GridView1" runat="server" DataSourceID="SteamHadaBBDD" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" Width="413px">
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <Columns>
            <asp:TemplateField HeaderText="Nombre">
                        <ItemTemplate>
                            <asp:LinkButton runat="server" Text =<%# Eval("nombre") %> OnClick="LinkButton1_OnClick">
                                
                            </asp:LinkButton>
                        </ItemTemplate>
                            

                        </asp:TemplateField>
            <asp:BoundField DataField="precio" HeaderText="precio" SortExpression="precio"></asp:BoundField>
            <asp:ImageField DataImageUrlField="imagen" DataImageUrlFormatString="~/{0}png" HeaderText="Item">
                         <ItemStyle BorderColor="#999999" BorderStyle="Solid" />
                        </asp:ImageField>
        </Columns>
        <EditRowStyle BackColor="#999999" />
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#E9E7E2" />
        <SortedAscendingHeaderStyle BackColor="#506C8C" />
        <SortedDescendingCellStyle BackColor="#FFFDF8" />
        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
    </asp:GridView>
    <asp:SqlDataSource ID="SteamHadaBBDD" runat="server" ConnectionString="Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\SteamHadaBBDD.mdf;Integrated Security=True;Connect Timeout=30" ProviderName="System.Data.SqlClient" SelectCommand="SELECT Producto.nombre, Producto.precio, Producto.imagen FROM Juego INNER JOIN Producto ON Juego.producto = Producto.id WHERE (Juego.categoria = 'Deportes')"></asp:SqlDataSource>
            
            
</asp:Content>
