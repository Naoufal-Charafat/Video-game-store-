<%@ Page Title="" Language="C#" MasterPageFile="~/index.Master" AutoEventWireup="true" CodeBehind="UserDetails.aspx.cs" Inherits="SteamHadaWeb.UserDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
	<div class="row">
        <div class = "column_UserConfiguration columnLeft_UserConfiguration">
            <ul>

			<li><asp:HyperLink ID="DetallesLink" NavigateUrl="UserDetails.aspx" runat="server">Detalles</asp:HyperLink></li>
			<li><asp:HyperLink ID="ConfigurationLink" NavigateUrl="UserConfiguration.aspx" runat="server">Configuración</asp:HyperLink></li>
            
				<li></li>
            <li> Idioma </li>
                <asp:DropDownList ID="LanguageDDL" runat="server" OnSelectedIndexChanged="LanguageDDL_SelectedIndexChanged">
                    <asp:ListItem Selected="True" Value="Español"> Español</asp:ListItem>
                    <asp:ListItem Value="Inglés">Inglés </asp:ListItem>
                    <asp:ListItem Value="Catalán">Català</asp:ListItem>
                </asp:DropDownList>
            </ul>
         </div>
         <div class ="column_UserConfiguration columnRight_UserConfiguration">
             <br>
             <asp:Image ID="profileImage" runat="server" Height="170px" ImageUrl="imagenes/avatar.png" Width="194px" />
             <br />
             <br />
            <ul>
                <asp:Label ID="actualEmail" runat="server" Text="Correo electrónico: "></asp:Label> <br />
				<asp:Label ID="typeOfAccount" runat="server" Text="Tipo de cuenta: "></asp:Label><br />
                <asp:Label ID="actualName" runat="server" Text="Nombre: "></asp:Label><br />
                <asp:Label ID="actualSurname" runat="server" Text="Apellidos: "></asp:Label> <br />
                <asp:Label ID="actualCash" runat="server" Text="Saldo: "></asp:Label> <br />
				<asp:Label ID="numberOfGamesBought" runat="server" Visible="false" Text="Juegos comprados: "></asp:Label><br />
				<asp:Label ID="numberOfGamesDeveloped" runat="server" Visible="false" Text="Juegos desarrollados: "></asp:Label><br />
				<asp:Label ID="numberOfUsersBanned" runat="server" Visible="false" Text="Usuarios baneados: "></asp:Label><br />
				<asp:Label ID="commission" runat="server" Visible="false" Text="Comisión : "></asp:Label><br />
				<li>Biografía: <br />      <asp:TextBox ID="actualBiography" runat="server" Height="95px" Width="178px" ReadOnly="True" TextMode="MultiLine"></asp:TextBox></li> <br />
				<asp:Label ID="actualPhoneNumber" runat="server" Text="Teléfono: "></asp:Label> <br />
                <asp:Label ID="dateOfEntry" runat="server" Text="Fecha ingreso: "></asp:Label><br />
            </ul>
          </div>
    </div>
    <br />
    <br />
    <br />
    <br />
<br />
<br />
    <br />
    <br />
</asp:Content>
