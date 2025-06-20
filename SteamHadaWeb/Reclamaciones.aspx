<%@ Page Title="" Language="C#" MasterPageFile="~/index.Master" AutoEventWireup="true" CodeBehind="Reclamaciones.aspx.cs" Inherits="SteamHadaWeb.Reclamaciones" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="style/stylesheet.css">
    <style type="text/css">
        .auto-style1 {
            height: 478px;
        }
        .auto-style2 {
            height: 778px;
        }
        .auto-style3 {
            height: 1303px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="auto-style3">
           <div id="divprincipalrecla" class="auto-style2">
        <h1 class="h1factreclam"> <span>RECLAMACION</span> </h1>
        <br />

        <div class="auto-style1">
            <h2>Nº del pedido que quieres leer, modificar, borrar o crear la reclamación:</h2>

            <asp:TextBox ID="TextBox3" runat="server" BorderColor ="#07120a" BackColor="#a3dcb2" Width="329px"></asp:TextBox>
            <br />
            <br />
            <br />
            <h2>Título de la reclamación:</h2>
            <asp:TextBox ID="TextBox1" runat="server" Width="476px" BorderColor ="#07120a" BackColor="#a3dcb2" Height="20px" MaxLength="40"></asp:TextBox>
            <br />
            <br />
            <br />
            <h2>Cuerpo de la reclamación:</h2>
        
           
    
            <asp:TextBox ID="TextBox2" TextMode="MultiLine" Columns="10" Rows="5" runat="server" Height="334px" Width="580px" BorderColor ="#07120a" BackColor="#a3dcb2" MaxLength="500"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="Leer" runat="server" Text="Leer" OnClick="Leer_Click"/> 
            &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp 
            &nbsp &nbsp &nbsp &nbsp &nbsp  &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp 
            &nbsp
            <asp:Button ID="Reclamar" runat="server" Text="Reclamar" OnClick="Reclamar_Click1"  />
            <br />
            <asp:Button runat="server" ID="Borrar" Text="Borrar" OnClick="Borrar_Click"/>
            &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp 
            &nbsp &nbsp &nbsp &nbsp &nbsp  &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp
            <asp:Button ID="Modificar" runat="server" Text="Modificar" OnClick="Modificar_Click" Height="" />
            
         
        </div>
        

    </div>
    </div>
</asp:Content>
