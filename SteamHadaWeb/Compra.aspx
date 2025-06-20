<%@ Page Title="" Language="C#" MasterPageFile="~/index.Master" AutoEventWireup="true" CodeBehind="Compra.aspx.cs" Inherits="SteamHadaWeb.Compra" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <li>¿Desea confirmar este pedido?</li>
    <li>Nombre del producto: <asp:Label runat="server" ID="nombreProd" Text=""></asp:Label>

    <li>Código de producto: <asp:Label runat="server" ID="codigoProd" Text=""></asp:Label>
    <li>Precio: <asp:Label runat="server" ID="precioProd" Text=""></asp:Label>
    <li>
    <li>
    <asp:Button runat="server" ID="Yes" Text ="Aceptar" OnClick="Yes_OnClick" Width="81px"/>
    &nbsp;
    <asp:Button runat="server" ID="No" Text ="Cancelar" OnClick="No_OnClick" Width="81px"/>
</asp:Content>
