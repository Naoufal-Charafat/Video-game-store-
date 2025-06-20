<%@ Page Title="" Language="C#" MasterPageFile="~/index.Master" AutoEventWireup="true" CodeBehind="Retransmisiones.aspx.cs" Inherits="SteamHadaWeb.Retransmisiones" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%-- <form runat="server">--%>
        <div id="body">
            <ul class="even">
				<li><a href="Retransmisiones.aspx"><img src="imagenes/wifi.png" />Retransmisiones</a></li>
				<li><a href="Videos.aspx"><img src="imagenes/play.png" />Videos</a></li>		
			</ul>
            <br />
            <div id="indiv">            
                <a href="Ver.aspx"> <img src="imagenes/fortnite.jpg" style="width: 470px"/> </a><br />
                <h4>Cuando haces click en la imagen, la web te redirige a una página exclusiva para reproducir contenido audiovusial, sea en directo o no.
                    <br />
                    En el caso de ser una retransmisión, debemos pasar a esa págin el enlace del video para poder reproducirlo.
                    <br />
                    Esta página debe estar relacionada con otras páginas en tiempo real, por lo que su implementación, a priori, no será una retransmisión en directo al uso
                </h4>
            </div>
        </div>
<%--</form>--%>
</asp:Content>
