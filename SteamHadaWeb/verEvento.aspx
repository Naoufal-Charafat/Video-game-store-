<%@ Page Title="" Language="C#" MasterPageFile="~/index.Master" AutoEventWireup="true" CodeBehind="verEvento.aspx.cs" Inherits="SteamHadaWeb.verEvento" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .columnRight_GameForm {
            background-color: #FFFFFF;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class ="column_GameForm columnRight_GameForm">
       <ul>
		    <li>Nombre del Evento:          <asp:Label ID="Nombre" runat="server" Text=""></asp:Label></li>
            <li>Descripcion:                <asp:Label ID="Descripcion" runat="server" Text="" ></asp:Label></li>
            <li>Provincia:                  <asp:Label ID="Provincia" runat="server" Text=""></asp:Label></li>
            <li>Localidad:                  <asp:Label ID="Localidad" runat="server" Text="" ></asp:Label></li>
            <li>Empresa:                    <asp:Label ID="Empresa" runat="server" Text=""></asp:Label></li>
            <li>FechaInit:                  <asp:Label ID="FechaInit" runat="server" Text="" ></asp:Label></li>
            <li>FechaFin:                   <asp:Label ID="FechaFin" runat="server" Text=""></asp:Label></li>
            <li>Precio:                     <asp:Label ID="Precio" runat="server" Text=""></asp:Label></li>
           <asp:Button runat="server" CssClass="btnAnyadirCarrito" OnClick="Comprar_OnClick" Text="Comprar" Height="43px"/>
		</ul>
        <p>
                &nbsp;</p>
            <p>
                &nbsp;</p>
            <p>
                &nbsp;</p>
            <p>
                &nbsp;</p>
            <p>
                &nbsp;</p>
            <p>
                &nbsp;</p>
            <p>
                &nbsp;</p>

    </div>
    <div style="font-family: Arial">
</div>
</asp:Content>
