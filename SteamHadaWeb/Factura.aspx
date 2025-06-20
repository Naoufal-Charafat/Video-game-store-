<%@ Page Title="" Language="C#" MasterPageFile="~/index.Master" AutoEventWireup="true" CodeBehind="Factura.aspx.cs" Inherits="SteamHadaWeb.Factura" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<link rel="stylesheet" href="style/stylesheet.css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div id="divprincipalrecla">
            <h1 class="h1factreclam"> <span>FACTURAS</span> </h1>
            <div id="divgridviewcentro">
                <br />
               
                <asp:GridView ID="GridView1" runat="server"  AutoGenerateColumns="False" DataKeyNames="numPedido" Height="19px" 
                                   Width="917px" AllowPaging="True" BackColor="#CCCCCC" CellPadding="2" CellSpacing="4" ForeColor="Black" 
                                   BorderStyle="Groove" BorderColor="Black" BorderWidth="3px" OnRowDataBound="listaJuegos_RowDataBound"
                                   PageSize="5" OnPageIndexChanging="GridView1_PageIndexChanging">
                    <Columns>
                        <asp:BoundField DataField="numPedido" HeaderText="numPedido" SortExpression="numPedido" InsertVisible="False" ReadOnly="True" />
                        <asp:BoundField DataField="fecha" HeaderText="fecha" SortExpression="fecha" />

                        <asp:BoundField DataField="importe" HeaderText="importe" SortExpression="importe" />
    

                    </Columns>
                    <FooterStyle BackColor="#CCCCCC" />
                    <HeaderStyle BackColor="#37904E" Font-Bold="True" ForeColor="BLACK" />
                    <PagerStyle BackColor="#a3dcb2" ForeColor="Black" HorizontalAlign="Left" />
                    <RowStyle BackColor="white" />
                    <SelectedRowStyle BackColor="#A8D7C8" Font-Bold="True" ForeColor="BLACK" />
                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                    <SortedAscendingHeaderStyle BackColor="#808080" />
                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                    <SortedDescendingHeaderStyle BackColor="#383838" />
                </asp:GridView>

           
                <br />
                <br />
                <br />
            </div>
        </div>


</asp:Content>
