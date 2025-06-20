<%@ Page Title="" Language="C#" MasterPageFile="~/index.Master" AutoEventWireup="true" CodeBehind="UserConfiguration.aspx.cs" Inherits="SteamHadaWeb.UserConfiguration" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<div class="row">
        <div class = "column_UserConfiguration columnLeft_UserConfiguration">
            <ul>
				<li><asp:HyperLink ID="DetallesLink" NavigateUrl="UserDetails.aspx" runat="server">Detalles</asp:HyperLink></li>
				<li><asp:HyperLink ID="ConfigurationLink" NavigateUrl="UserConfiguration.aspx" runat="server">Configuración</asp:HyperLink></li>
				<li> Idioma </li>
					<asp:DropDownList ID="LanguageDDL" runat="server">
						<asp:ListItem Selected="True" Value="Español"> Español</asp:ListItem>
						<asp:ListItem Value="Inglés">Inglés </asp:ListItem>
						<asp:ListItem Value="Catalán">Català</asp:ListItem>
						</asp:DropDownList>
				<li> Cambiar avatar</li> <br />
						<asp:FileUpload ID="ProfilePicUpload" runat="server" /> <br />
						<asp:Button ID="changeImage" runat="server" Text="Cambiar imagen" OnClick="changeProfilePicture"/>
			</ul>
		</div>

		<div class ="column_UserConfiguration columnRight_UserConfiguration"> <br />
			 <asp:Image ID="profileImage" runat="server" Height="170px" ImageUrl="imagenes/avatar.png" Width="194px" /> <br />
            <ul>
                <li>Correo electrónico:         <asp:Label ID="actualEmail" runat="server" Text="boChen@juegos"></asp:Label></li> <br />
                <li>Nuevo correo electrónico: <asp:TextBox ID="newEmail" runat="server" Text=""></asp:TextBox></li>  <br />

				<asp:Button ID="updateEmailButton" runat="server" Text="Actualizar email" Width="132px" OnClick="updateEmailButton_Click"/> 
				<asp:Label ID="updateEmailLabel" runat="server" Text="Label" Visible="false"></asp:Label><br />
				<asp:RegularExpressionValidator ID="RegularExpressionEmail" runat="server" ErrorMessage="El correo no tiene el formato correcto" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="newEmail" Display="Dynamic" EnableClientScript="False"></asp:RegularExpressionValidator>
				<li> 	<asp:Label ID="updateEmail" runat="server" Text="Label" Visible ="false "></asp:Label> <br />
                <li>Contraseña actual:         <asp:Label ID="actualPassword" runat="server" Text="******"></asp:Label></li> <br />
                <li>Nueva contraseña:           <asp:TextBox ID="newPassword" runat="server" TextMode="Password"></asp:TextBox></li><br />
                <li>Repetir contraseña:         <asp:TextBox ID="newRepeatedPassword" runat="server" TextMode="Password"></asp:TextBox></li>
				<asp:Label ID="changedPassword" runat="server" Text="" ></asp:Label><br />
				<asp:CompareValidator ID="compareRepeatedPassword" runat="server" ErrorMessage="Las contraseñas no coinciden" ControlToCompare="newPassword" ValueToCompare="newPassord" ControlToValidate="newRepeatedPassword" ForeColor="Red"></asp:CompareValidator> <br />
				
				<li><asp:Button ID="changePassword" runat="server" Text="Cambiar contraseña" Width="132px" OnClick="changePassword_Click" /> </li><br />
                <li>Nombre:                     <asp:TextBox ID="userName" runat="server" Text="" ></asp:TextBox>  </li>
				<asp:RequiredFieldValidator ID="nameValidator" runat="server" ErrorMessage="El nombre no puede ser vacío" ControlToValidate="userName"></asp:RequiredFieldValidator><br />
                <li>Apellidos:                   <asp:TextBox ID="userSurname" runat="server" Text=""></asp:TextBox>  </li> 
				<asp:RequiredFieldValidator ID="surnameValidator" runat="server" ErrorMessage="El apellido no puede ser vacío" ControlToValidate="userSurname"></asp:RequiredFieldValidator><br />
                <li>Nuevo Teléfono:             <asp:TextBox ID="newPhoneNumber" runat="server" Text="" MaxLength="15"></asp:TextBox>  </li> 
				<asp:RangeValidator ID="validatePhoneNumber" runat="server" ErrorMessage="El número debe contener 9 o más dígitos" ControlToValidate="newPhoneNumber" Display="Dynamic" ForeColor="Red" MaximumValue="999999999" MinimumValue="100000000" EnableClientScript="False" SetFocusOnError="True" Type="Integer"></asp:RangeValidator>
				<br />
                <li>Biografía: <br /><asp:TextBox ID="biography" runat="server" Height="97px" Width="221px" MaxLength="250" TextMode="MultiLine"></asp:TextBox> </li> 
                <asp:Label ID="maxBiographyLength" runat="server" Text=""></asp:Label>
                <br />
                <asp:Button ID="saveChanges" runat="server" Text="Aceptar Cambios" OnClick="saveChanges_Click1"  />
                <asp:Button ID="cancelChanges" runat="server" Text="Cancelar" />

				<li> <asp:Label ID="changesLabel" runat="server" Text=""></asp:Label></li>
            </ul>
          </div>
</div>

</asp:Content>
