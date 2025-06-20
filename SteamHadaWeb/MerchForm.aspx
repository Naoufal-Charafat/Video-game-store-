<%@ Page Title="" Language="C#" MasterPageFile="~/index.Master" AutoEventWireup="true" CodeBehind="MerchForm.aspx.cs" Inherits="SteamHadaWeb.MerchForm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .columnRight_GameForm {
            background-color: #FFFFFF;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class ="column_GameForm columnRight_GameForm">
            <img ID="imagenProd" src="" runat="server" style="height: 259px; width: 241px"/>
            <br />
            <br />
             <br />
            <ul>
                <li>Código del producto:  <asp:Label ID ="codigoProd" runat ="server" Text=""></asp:Label></li>
                <li>Nombre del producto:  <asp:Label ID="nombreProd" runat="server" Text=""></asp:Label></li>
                <li>Fecha de publicacion: <asp:Label ID ="fechaProd" runat ="server" Text=""></asp:Label></li>               
                <li>Descripción:          <asp:Label ID ="descripcionProd" runat ="server" Text=""></asp:Label></li> 
                <li>Volumen:              <asp:Label ID="volumenProd" runat="server" Text=""></asp:Label></li> 
                <li>Peso:                 <asp:Label ID ="pesoProd" runat ="server" Text=""></asp:Label></li>
                <li>Precio:               <asp:Label ID="precioProd" runat="server" Text=""></asp:Label></li> 
                <li>
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

</asp:Content>
