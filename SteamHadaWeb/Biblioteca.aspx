<%@ Page Title="" Language="C#" MasterPageFile="~/index.Master" AutoEventWireup="true" CodeBehind="Biblioteca.aspx.cs" Inherits="SteamHadaWeb.Biblioteca2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Biblioteca</title>
    <style type="text/css">
        .auto-style1 {
            width: 789px;
            height: 315px;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div align="center">
        <img alt="" class="auto-style1" src="imagenes/BIBLIOTECA_BOGAME.png" /><br />

        <a href="GameForm.aspx">
            <asp:GridView ID="GridView1" OnLoad="GridView1_SelectedIndexChanged" runat="server" AutoGenerateColumns="False"
                RowStyle-HorizontalAlign="Center"
                AllowPaging="True"
                CssClass="mGrid">
                <Columns>
                    <asp:BoundField DataField="nombre" HeaderText="TITULO" SortExpression="nombre" FooterStyle-HorizontalAlign="Center">
                        <FooterStyle HorizontalAlign="Center"></FooterStyle>
                    </asp:BoundField>

                    <asp:BoundField DataField="categoria" HeaderText="CATEGORIA" SortExpression="categoria"></asp:BoundField>

                    <asp:BoundField DataField="descripcion" HeaderText="DESCRIPCION" SortExpression="descripcion"></asp:BoundField>

                    <asp:ImageField DataImageUrlField="imagen" DataImageUrlFormatString="~/imagenes/{0}" HeaderText="JUEGO">
                        <ControlStyle BorderStyle="Solid" />
                        <HeaderStyle BorderStyle="Solid" Height="50%" HorizontalAlign="Center" />
                        <ItemStyle Height="50%" HorizontalAlign="Center" />
                    </asp:ImageField>

                    <asp:CommandField ButtonType="Button" ShowSelectButton="True" />

                </Columns>

                <RowStyle HorizontalAlign="Center"></RowStyle>

            </asp:GridView>
        </a>
        <br />
    </div>
</asp:Content>
