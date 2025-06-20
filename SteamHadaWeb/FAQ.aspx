<%@ Page Title="" Language="C#" MasterPageFile="~/index.Master" AutoEventWireup="true" CodeBehind="FAQ.aspx.cs" Inherits="SteamHadaWeb.FAQ" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div id="body">
            Imagen inicio
            <div id="faq">
                 <img src="imagenes/faq.png"/>
            </div>
            <!--
            <div id="consultasfaq">
                <h2 id ="subtitulofaq">Consultas generales:</h2>
                <br />
                <div>
                    <ul style="list-style-type:square;">
                        <li><span class="preguntasfaq"><strong>¿Cómo funciona BOGAMES?</strong></span></li>
                        <p>Es una página dónde encontrarás tus juegos favoritos al precio más bajo. Además de comprar juegos, si eres un desarrollador</p>
                        <p>podrás dar de alta tu juego y nosotros comprobaremos su valía y lo pondremos a la venta y te ayudaremos a darlo a conocer.</p>
                        <li><span class="preguntasfaq"><strong>¿Cómo crearse cuenta en BOGAMES?</strong></span></li>
                        <p>Para crearse una cuenta tendrás que hacer click en "Registro" que se encuentra arriba a la derecha y rellenar los datos que se</p>
                        <p>piden, una vez rellenados usted ya tendrá disponible la acción de compra. Si usted es un desarrollador tendrá que comunicarse</p>
                        <p>con nuestro equipo para poder darle la funcionalidad de subir tu juego.</p>
                    </ul>
                </div>
                <br />
            </div>
            -->
            
        
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False" BackColor="White" BorderColor="#336666" 
                         BorderStyle="Double" BorderWidth="3px" CellPadding="4" GridLines="Horizontal" Height="506px" Width="1529px" OnPageIndexChanging="GridView1_PageIndexChanging">
            <Columns>
                <asp:BoundField DataField="cod" HeaderText="Número" ReadOnly="True" SortExpression="cod" />
                <asp:BoundField DataField="pregunta" HeaderText="PREGUNTAS" SortExpression="pregunta" ReadOnly="true" />
                <asp:BoundField DataField="respuesta" HeaderText="RESPUESTAS" SortExpression="respuesta" />
            </Columns>
            <FooterStyle BackColor="White" ForeColor="#333333" />
            <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#336666" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="White" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F7F7F7" />
            <SortedAscendingHeaderStyle BackColor="#487575" />
            <SortedDescendingCellStyle BackColor="#E5E5E5" />
            <SortedDescendingHeaderStyle BackColor="#275353" />
            </asp:GridView>
        
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:miconexion %>" SelectCommand="SELECT [pregunta], [respuesta] FROM [Faqs] ORDER BY [cod]"></asp:SqlDataSource>
            
            <!-- botones solo visibles para los administradores: -->
            <asp:Label ID="Label" runat="server" Visible="false"> Escribe el numero de la pregunta que quieras modificar/borrar</asp:Label>
            <asp:TextBox ID="CodFAQ" runat="server" Visible="false" ></asp:TextBox>           
            <br />
            <asp:Label ID="Label1" runat="server" Visible="false"> Escribe la pregunta que quieras realizar</asp:Label>
            <asp:TextBox ID="Pregunta" runat="server" Visible="false" MaxLength="50" ></asp:TextBox>  
            <br />
            <asp:Label ID="Label2" runat="server" Visible="false"> Escribe la respuesta que le quieres dar</asp:Label>
            <br />
            <asp:TextBox ID="Respuesta" runat="server" Visible="false" Height="200px" Width="524px"   Columns="10" Rows="5" MaxLength="400"  TextMode="MultiLine"></asp:TextBox>  
            <br />
            <br />
            <asp:Button ID="Crear" Text="Crear Nueva Pregunta y Respuesta" OnClick="Crear_Click" runat ="server" Visible="false" />
            <asp:Button ID="Modificar" Text="Modificar Pregunta y/o Respuesta" OnClick="Modificar_Click" runat="server" Visible="false"/>
            <asp:Button ID="Borrar" Text="Borrar Pregunta y Respuesta" OnClick="Borrar_Click" runat="server" Visible="false" />
          </div>
        </asp:Content>
