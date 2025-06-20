<%@ Page Title="" Language="C#" MasterPageFile="~/index.Master" AutoEventWireup="true" CodeFile="Index.aspx.cs" Inherits="SteamHadaWeb.Index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div id="body">

            <div id="oferta">            
                <a href=""> <img src="imagenes/ofertas.png"/> </a>

            </div>

            <h2>Juegos destacados</h2>
            
            <div class="card">
                <a href="">
                    <img src="imagenes/plman.png">
                    <h1>PLMAN</h1>
                    <p>El juego del año</p>
                    <p>20.00€</p>
                    <br />
                </a>
                 <asp:Button runat="server" Text="Añadir al carrito" CssClass="btnAnyadirCarrito"/>
            </div>


            <div class="card">
                <a href="">
                    <img src="imagenes/plman.png">
                    <h1>PLMAN</h1>
                    <p>El juego del año</p>
                    <p>20.00€</p>
                    <br />
                </a>
                 <asp:Button runat="server" Text="Añadir al carrito" CssClass="btnAnyadirCarrito"/>
                <br />
            </div>
        </div>
     <br />
</asp:Content>
