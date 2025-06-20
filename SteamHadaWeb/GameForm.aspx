<%@ Page Title="" Language="C#" MasterPageFile="~/index.Master" AutoEventWireup="true" CodeBehind="GameForm.aspx.cs" Inherits="SteamHadaWeb.GameForm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .columnRight_GameForm {
            background-color: #FFFFFF;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%--<form runat ="server">--%>
         <div class ="column_GameForm columnRight_GameForm">
            <img id="imagenGame" runat="server" src="" style="height: 283px; width: 294px"/>
             <br />
             <br />
             <br />
            <ul>
                <li>Código del juego:  <asp:Label ID ="codigoGame" runat ="server" Text=""></asp:Label></li>
                <li>Nombre del juego:  <asp:Label ID="nombreGame" runat="server" Text=""></asp:Label></li>
                <li>Fecha de publicacion: <asp:Label ID ="fechaGame" runat ="server" Text=""></asp:Label></li>               
                <li>Descripción:          <asp:Label ID ="descripcionGame" runat ="server" Text=""></asp:Label></li> 
                <li>Categoría:            <asp:Label ID ="categoriaGame" runat ="server" Text=""></asp:Label></li>
                <li>Precio:               <asp:Label ID="precioGame" runat="server" Text=""></asp:Label></li> 
                <li>
                <asp:Button runat="server" CssClass="btnAnyadirCarrito" OnClick="Comprar_OnClick" Text="Comprar" Height="43px"/>
            </ul>
          </div>
    </div>
    <div style="font-family: Arial">
</div>
    <br />
    <br />
    <br />
    <br />
<br />
<br />
    <br />
    <br />
    
<%--</form>--%>
</asp:Content>

    

