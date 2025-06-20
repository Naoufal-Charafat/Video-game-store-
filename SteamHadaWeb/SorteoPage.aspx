<%@ Page Title="" Language="C#" MasterPageFile="~/index.Master" AutoEventWireup="true" CodeBehind="SorteoPage.aspx.cs" Inherits="SteamHadaWeb.SorteoPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
  
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">



    <div align="center">

        <h1 align="center" class="auto-style1">
            <img alt="" class="auto-style2" src="imagenes/SORTEOS_BOGAMES.gif" /></h1>

        <asp:Image ID="imagen_del_sorteo" runat="server" />
        <h1 class="my-4">
            <b>
                <asp:Label runat="server" ID="nombre"></asp:Label>
            </b>
        </h1>
        <p class="my-4">
            &nbsp;
        </p>
        <p class="my-4">
            &nbsp;
        </p>
        <p class="my-4">
            &nbsp;
        </p>
        <p class="my-4">
            &nbsp;
        </p>

       
        <h2 class="my-3">
            <b>
                 <asp:Label ID="descripcion_sorteo" runat="server"></asp:Label>
            </b>
        </h2>

        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
    </div>
</asp:Content>
