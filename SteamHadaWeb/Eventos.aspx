<%@ Page Title="" Language="C#" MasterPageFile="~/index.Master" AutoEventWireup="true" CodeBehind="Eventos.aspx.cs" Inherits="SteamHadaWeb.Eventos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div>
            <h2 style="color: #000066; background-color: #FFFFFF;">Eventos</h2>
            <h3 style="color: #000000; background-color: #FFFFFF;">Esta es la página de Eventos, donde podrás acceder a contenido audiovisual en vivo y reserva de tickets para las conferencias anunciadas.</h3>            
            <h3 style="color: #000099; background-color: #FFFFFF;">¡RETRANSMISIONES!</h3>
            <h4 style="color: #000000; background-color: #FFFFFF;">Podras visualizar en vivo conferencias, charlas y presentaciones de tus juegos favoritos con el mínimo delay que permita tu conexión.</h4>           
            <h3 style="color: #000099; background-color: #FFFFFF;">¡VIDEOS!</h3>
            <h4 style="color: #000000; background-color: #FFFFFF;">Disfrutarás de retransmisiones anteriores sin ningún problema con una anterioridad de 30 dias, despues el directo desaparecerá.</h4>
            
            <div id="navigation">
            <asp:Menu ID="Menu2" Width="100%" IncludeStyleBlock="false" runat="server" CssClass="nav" Orientation="Horizontal" Font-Size="X-Large" StaticMenuStyle-Width="100%">
                <Items>
                    <asp:MenuItem ImageUrl="imagenes/wifi.png" Text="Retransmisiones" NavigateUrl="~/Retransmisiones.aspx">
                    </asp:MenuItem>
                    <asp:MenuItem ImageUrl="imagenes/play.png" Text="Videos" NavigateUrl="~/Videos.aspx">
                    </asp:MenuItem>
                    <asp:MenuItem ImageUrl="imagenes/avatar-1.png" Text="Crear Evento" NavigateUrl="createEvent.aspx">
                    </asp:MenuItem>
                    <asp:MenuItem ImageUrl="imagenes/avatar-1.png" Text="Crear Video" NavigateUrl="createVideo.aspx">
                    </asp:MenuItem>
                </Items>
            </asp:Menu>
            </div>
            <br /><br />

            <div id="events">
                 <img src="imagenes/events3.png" />
            </div>
            <br /><br />
            <%--<Listado con todas las conferencias disponibles en la base de datos, cada una de ellas con su imagen, precio, descripcion, etc...>--%>
            <%--<Cada una de ellas vendrá con un botón para proceder a comprar la entrada. Si hacemos click en el boton, accedemos a la página de métodos de pago>--%>
            
            <div>
                <asp:SqlDataSource ID="SteamHadaBBDD"
                    runat="server" 
                    ConnectionString="Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\SteamHadaBBDD.mdf;Integrated Security=True;Connect Timeout=30" 
                    ProviderName="System.Data.SqlClient" 
                    SelectCommand="SELECT cod, nombre, descripcion FROM Evento ">
                </asp:SqlDataSource>

              <asp:gridview ID="EventosGridView"
                  DataSourceID="SteamHadaBBDD"
                  runat="server"
                  AutoGenerateColumns="false"  
                  DataKeyNames="cod">
                <Columns>
                    <asp:TemplateField HeaderText="Numero">
                        <ItemTemplate>
                            <asp:LinkButton runat="server" Text =<%# Eval("cod") %> OnClick="escogerEvento"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:BoundField DataField="nombre" HeaderText="Nombre"/>
                    <asp:BoundField DataField="descripcion" HeaderText="Descripcion"/>
                </Columns>
                <HeaderStyle BackColor="#00CC00" Font-Bold="True" ForeColor="Black"/>

              </asp:gridview>
                <%--<INNER JOIN Fisico ON Evento.id = Fisico.evento>--%>
                
            </div>
        </div>
</asp:Content>