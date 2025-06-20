<%@ Page Title="" Language="C#" MasterPageFile="~/index.Master" AutoEventWireup="true" CodeBehind="Videos.aspx.cs" Inherits="SteamHadaWeb.Videos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <div>
            <ul class="even">
				<li><a href="Retransmisiones.aspx"><img src="imagenes/wifi.png" />Retransmisiones</a></li>
				<li><a href="Videos.aspx"><img src="imagenes/play.png" />Videos</a></li>		
			</ul>
        </div>
        <br />
        <div>
            <ul class="filtro">
                <li><label for="Juego">Juego:</label>
                <asp:TextBox ID="Juego" runat="server" Width="200px"></asp:TextBox><br /><br /></li>

                <li>
                    <asp:Button ID="Button1" runat="server" Text="Aplicar Filtros" OnClick="filtrarVideos"/>
                </li>
            </ul>        
        </div>
        <br /><br /><br /><br /><br />
        <div>
            <asp:gridview ID="videosGridView"
             runat="server"
             AutoGenerateColumns="false"  
             AllowPaging="True" Width="720px">
           <Columns>
                   <asp:BoundField DataField="Juego" HeaderText="Juego"/>
                   <asp:BoundField DataField="autor" HeaderText="Autor"/>
                 <asp:TemplateField HeaderText="URL">
                      <ItemTemplate>
                          <asp:LinkButton runat="server" Text =<%# Eval("url") %> OnClick="verVideo"></asp:LinkButton>
                      </ItemTemplate>
                 </asp:TemplateField>
           </Columns>
           <HeaderStyle BackColor="#00CC00" Font-Bold="True" ForeColor="Black"/>

         </asp:gridview>

        </div>
         

        <br /><br /><br /><br /><br /><br /><br /><br /><br />
    </div>     
</asp:Content>
