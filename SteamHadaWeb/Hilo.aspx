<%@ Page Title="Hilo" Language="C#" MasterPageFile="~/index.Master" AutoEventWireup="true" CodeBehind="Hilo.aspx.cs" Inherits="SteamHadaWeb.Hilo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<%--  %><form method="post"> 
		<input name="correo" hidden type="hidden"></in> --%>
		<div style="background-color:cornflowerblue;
					text-align: center;
					vertical-align: central;
					height: 70px; padding-top:15px">
			<h1>BOGAMES FORO</h1>
		</div>
		<div style="padding-top:10px; margin-left: 14%; margin-right: 14%">
			<div style="padding: 5px; border:solid; border-width:2px; border-color:darkgray">
				<p>
					<asp:Label ID="Asunto" runat="server" Text="Error en la página" Font-Size ="14" ForeColor="#24578e" Font-Bold="true"></asp:Label>
					
				</p>
				<p>
					<asp:Label ID="Descripcion" runat="server" Text="Este hilo no existe" ForeColor="#24578e"></asp:Label>
					
				</p>
					<asp:Table ID ="ModificarAsuntoTable" Visible ="false" runat="server" CellPadding="5" Width="100%">
						<asp:TableRow Width ="100%">
							<asp:TableCell width="40px" Height="100%">
								<asp:Button ID="buttonModificadoHilo" Height="50%" Width="100%" Text="Actualizar" runat="server" OnClick="buttonModificadoHilo_Click" />
								<br />
								<asp:Button ID="buttonCancelarModificacion" Height="50%" Width="100%" Text="Cancelar" runat="server" OnClick="buttonCancelarModificacion_Click" />
							</asp:TableCell>
							<asp:TableCell Width="100%" height="100%" al>
								<asp:TextBox ID="EditAsunto" runat="server" Text="Error en la página" Width="100%"></asp:TextBox>
								<br />
								<asp:TextBox ID="EditDescripcion" runat="server" Width="100%" Text="Este hilo no existe" TextMode="MultiLine"></asp:TextBox>
							</asp:TableCell>
						</asp:TableRow>
					</asp:Table>
				<p>
					Creado el <asp:label ID="FechaAsunto" runat="server" text="00/00/2000"></asp:label>
					a las <asp:label ID="HoraAsunto" runat="server" text="00:00"></asp:label>
					por <asp:linkbutton ID="AutorAsunto" runat="server" Text="NombreUsuario" OnClick="AutorAsunto_Click"></asp:linkbutton>
				</p>
				<asp:PlaceHolder ID="PlaceHolderEditHilo" runat="server" Visible="false">
					<asp:LinkButton ID="ButtonBorrarHilo" runat="server" Text="Borrar Hilo" OnClick="ButtonBorrarHilo_Click"></asp:LinkButton>
					 - <asp:LinkButton ID="ButtonModificarHilo" runat="server" Text="Modificar Hilo" OnClick="ButtonModificarHilo_Click"></asp:LinkButton>
				</asp:PlaceHolder>
			</div>
			<div>
                <br />
				<asp:PlaceHolder ID="PlaceNuevoMensaje" runat="server" Visible="true">
					<asp:Table runat="server" Width="100%">
						<asp:TableRow runat="server">
							<asp:TableCell Width="30%" HorizontalAlign="Center">
								Nuevo comentario:
								<asp:Button ID="ButtonNuevoMensaje" runat="server" Text="Publicar" Width="80%" OnClick="ButtonNuevoMensaje_Click"/>
								<br />
								<asp:RequiredFieldValidator runat="server" ValidationGroup="ValidationNuevoMensaje" ID="RequiredFieldValidatorMensaje" ControlToValidate="NuevoMensaje" ForeColor="Red" Text="Escribe un comentario"></asp:RequiredFieldValidator>
								<asp:RegularExpressionValidator ID="RegularExpressionValidator" ForeColor="Red" ValidationGroup="ValidationNuevoMensaje" ValidationExpression="^([\S\s\d\D\w\W]{0,800})$" runat="server" ControlToValidate="NuevoMensaje" ErrorMessage="El título no puede superar los 800 caracteres"></asp:RegularExpressionValidator>
							</asp:TableCell>
							<asp:TableCell Width="70%">
								<asp:TextBox ID="NuevoMensaje" runat="server" TextMode="MultiLine" Width="100%" Height="70px"></asp:TextBox>
							</asp:TableCell>
						</asp:TableRow>
					</asp:Table>
					
				</asp:PlaceHolder>
				<br />
			</div>


			<div>
				<asp:ListView ID="ListView1" runat="server" DataSourceID="SqlDataSource1" >
           
						<AlternatingItemTemplate >
                          <tr style="background-color: #e8effa;color: #333333; padding:10px">
                            <td>
								<asp:Image ID="ImagenAutor" runat="server" Width="128px" Height="128px" BorderStyle="Solid" BorderWidth="1px" ImageUrl='<%# Eval("foto") %>' />
								<br />
								<asp:Label ID="nombreLabel" runat="server" Text='<%# Eval("nombre") %>'/>
								<br />
								Registrado el <asp:Label ID="LabelFechaIngreso" runat="server" Text='<%# Convert.ToDateTime(Eval("fechaIngreso")).ToShortDateString().ToString() %>'></asp:Label>
								<br />
								Mensajes escritos: <asp:Label ID="MensajesUsuario1" runat="server" Text='<%# Eval("numMensajes") %>'></asp:Label>
								<br />

                            </td>
                            <td style="vertical-align : top; padding = 5px">
								<%-- <asp:Label ID="LabelHashtag" runat="server" Text="#" Font-Size="10"></asp:Label> --%>
								<asp:Label ID="NumMensaje" runat="server" Text='<%# string.Concat("#",Eval("cod")) %>' Font-Size="10"></asp:Label>
								<asp:Label ID="Labelfechapub" runat="server" Text=<%# (string.Concat(" Publicado el ", Convert.ToDateTime(Eval("fechaHora")).ToShortDateString(), " a las ", Convert.ToDateTime(Eval("fechaHora")).ToShortTimeString())) %> Font-Size="10"></asp:Label>
								<br />
                                <asp:Label ID="mensajeLabel" runat="server" Text='<%# Eval("mensaje") %>' />
                            </td>

                        </tr>
						</AlternatingItemTemplate>
					

                    <EditItemTemplate>
                        <tr style="background-color: #999999;">
                            <td>
                                <asp:Button ID="UpdateButton" runat="server" CommandName="Update" Text="Actualizar" />
                                <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Cancelar" />
                            </td>
                            <td>
                                <asp:TextBox ID="nombreTextBox" runat="server" Text='<%# Bind("nombre") %>' />
                            </td>
                            <td>
                                <asp:TextBox ID="mensajeTextBox" runat="server" Text='<%# Bind("mensaje") %>' />
                            </td>
                            <td>
                                <asp:TextBox ID="fechaHoraTextBox" runat="server" Text='<%# Bind("fechaHora") %>' />
                            </td>
                        </tr>
                    </EditItemTemplate>
                    <EmptyDataTemplate>
                        <table runat="server" style="background-color: #FFFFFF;border-collapse: collapse;border-color: #999999;border-style:none;border-width:1px;">
                            <tr>
                                <td>No hay mensajes en este hilo</td>
                            </tr>
                        </table>
                    </EmptyDataTemplate>
                    <InsertItemTemplate>
                        <tr style="">
                            <td>
                                <asp:Button ID="InsertButton" runat="server" CommandName="Insert" Text="Insertar" />
                                <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Borrar" />
                            </td>
                            <td>
                                <asp:TextBox ID="nombreTextBox" runat="server" Text='<%# Bind("nombre") %>' />
                            </td>
                            <td>
                                <asp:TextBox ID="mensajeTextBox" runat="server" Text='<%# Bind("mensaje") %>' />
                            </td>
                            <td>
                                <asp:TextBox ID="fechaHoraTextBox" runat="server" Text='<%# Bind("fechaHora") %>' />
                            </td>
                        </tr>
                    </InsertItemTemplate>
                    <ItemTemplate>
                        <tr style=" background-color: #bbdede;color: #333333;">
                            <td style="width : 300px;">
								
								<asp:Image ID="ImagenAutor" runat="server" Width="128px" Height="128px" BorderStyle="Solid" BorderWidth="1px" ImageUrl='<%# Eval("foto") %>' /> <%-- y si no tiene avatar --%>
								<br />
								<asp:Label ID="nombreLabel" runat="server" Text='<%# Eval("nombre") %>' />
								<br />
								Registrado el <asp:Label ID="LabelFechaIngreso" runat="server" Text='<%# Convert.ToDateTime(Eval("fechaIngreso")).ToShortDateString() %>'></asp:Label>
								<br />
								Mensajes escritos: <asp:Label ID="MensajesUsuario1" runat="server" Text='<%# Eval("numMensajes") %>'></asp:Label>
								<br />

                            </td>
                            <td style="vertical-align : top; width : 900px">
								<%-- <asp:Label ID="LabelHashtag" runat="server" Text="#" Font-Size="10"></asp:Label> --%>
								<asp:Label ID="NumMensaje" runat="server" Text='<%# string.Concat("#",Eval("cod")) %>' Font-Size="10"></asp:Label>
								<asp:Label ID="Labelfechapub" runat="server" Text=<%# (string.Concat(" Publicado el ", Convert.ToDateTime(Eval("fechaHora")).ToShortDateString(), " a las ", Convert.ToDateTime(Eval("fechaHora")).ToShortTimeString())) %> Font-Size="10"></asp:Label>
								<br />
                                <asp:Label ID="mensajeLabel" runat="server" Text='<%# Eval("mensaje") %>' />
                            </td>

                        </tr>
                    </ItemTemplate>
                    <LayoutTemplate>
                        <table runat="server">
                            <tr runat="server">
                                <td runat="server">
                                    <table id="itemPlaceholderContainer" runat="server" border="1" style="background-color: #FFFFFF;border-collapse: collapse;border-color: #999999;border-style:none;border-width:1px;font-family: Verdana, Arial, Helvetica, sans-serif;">
                                        <tr runat="server" style="background-color: #E0FFFF;color: #333333;">
                                            <th runat="server">Autor</th>
                                            <th runat="server">Comentario</th>
                                        </tr>
                                        <tr id="itemPlaceholder" runat="server">
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr runat="server">
                                <td runat="server" style="text-align: center;background-color: #5D7B9D;font-family: Verdana, Arial, Helvetica, sans-serif;color: #FFFFFF">
                                    <asp:DataPager ID="DataPager1" PageSize="10" runat="server">
                                        <Fields>
                                            <asp:NextPreviousPagerField ButtonType="Button" ButtonCssClass="btn-default" ShowFirstPageButton="True" ShowLastPageButton="True" />
                                        </Fields>
                                    </asp:DataPager>
                                </td>
                            </tr>
                        </table>
                    </LayoutTemplate>
                    <SelectedItemTemplate>
                        <tr style="background-color: #E2DED6;font-weight: bold;color: #333333;">
                            <td>
                                <asp:Label ID="nombreLabel" runat="server" Text='<%# Eval("nombre") %>' />

                            </td>
                            <td>
                                <asp:Label ID="mensajeLabel" runat="server" Text='<%# Eval("mensaje") %>' />
                            </td>
                            <td>
                                <asp:Label ID="fechaHoraLabel" runat="server" Text='<%# Eval("fechaHora") %>' />
                            </td>
                        </tr>
                    </SelectedItemTemplate>
                </asp:ListView>

				<%--
				<asp:table id="Table1" runat="server"
					cellspacing="16"
					backcolor="WhiteSmoke"
					width="100%"
					cellpadding="8">

					<asp:TableHeaderRow>
						<asp:TableHeaderCell HorizontalAlign="Left" Width="30%">
							Autor
						</asp:TableHeaderCell>
						<asp:TableHeaderCell HorizontalAlign="Left" Width="80%">
							Mensaje
						</asp:TableHeaderCell>
					</asp:TableHeaderRow>

					<asp:TableRow ID="HiloTableRow1" Visible="True" BackColor="" VerticalAlign="Top" BorderWidth="1px" BorderColor="Gray" BorderStyle="Solid">
						<asp:TableCell ID="Autor1" runat="server">
							<asp:Image ID="ImagenAutor1" runat="server" Width="128px" Height="128px" BorderStyle="Solid" BorderWidth="1px" ImageUrl="~/imagenes/avatar.png" />
							<br />
							<asp:LinkButton ID="NombreAutor1" runat="server" Text="NombreUsuario" href="UserDetails.aspx"></asp:LinkButton>
							<br />
							Registrado: <asp:Label ID="RegistroUsuario1" runat="server" Text="12/31/2006"></asp:Label>
							<br />
							Mensajes: <asp:Label ID="MensajesUsuario1" runat="server" Text="2"></asp:Label>
							<br />
						</asp:TableCell>
						<asp:TableCell ID="Mensaje1" runat="server">
							<asp:Label ID="CabeceraMensaje1" runat="server" Text="#1 Fecha publicación: 03/05/19 - 17:25:02"  Font-Size="10"></asp:Label>
							<br />
							<asp:Label ID="DescripcionMensaje1" runat="server" Text="Comentario de ejemplo"></asp:Label>
						</asp:TableCell>
					</asp:TableRow>

					<asp:TableRow ID="HiloTableRow2" Visible="True" BackColor="" VerticalAlign="Top" BorderWidth="1px" BorderColor="Gray" BorderStyle="Solid">
						<asp:TableCell ID="Autor2" runat="server">
							<asp:Image ID="imagenAutor2" runat="server" Width="128px" Height="128px" BorderStyle="Solid" BorderWidth="1px" ImageUrl="~/imagenes/avatar.png" />
							<br />
							<asp:LinkButton ID="NombreUsuario2" runat="server" Text="NombreUsuario" href="UserDetails.aspx"></asp:LinkButton>
							<br />
							Registrado: <asp:Label ID="RegistroUsuario2" runat="server" Text="12/31/2006"></asp:Label>
							<br />
							Mensajes: <asp:Label ID="MensajesUsuario2" runat="server" Text="2"></asp:Label>
							<br />
						</asp:TableCell>
						<asp:TableCell ID="Mensaje2" runat="server">
							<asp:Label ID="CabeceraMensaje2" runat="server" Text="#2 Fecha publicación: 03/05/19 - 17:25:02"  Font-Size="10"></asp:Label>
							<br />
							<asp:Label ID="DescripcionMensaje2" runat="server" Text="Comentario de ejemplo"></asp:Label>
						</asp:TableCell>
					</asp:TableRow>
				</asp:table>
				--%>
			</div>
		</div>
		<br />
		<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:miconexion %>" SelectCommand="SELECT Usuario.correo,
Usuario.nombre, Mensaje.mensaje,
Mensaje.fechaHora,
Usuario.fechaIngreso,
Mensaje.cod, foto,
t.numMensajes
FROM Mensaje,
Usuario,
(select count(M.usuario) as numMensajes,
M.usuario as usuario
from Mensaje as M
group by M.usuario) as t
where Mensaje.usuario = Usuario.correo  and t.usuario = Mensaje.usuario"></asp:SqlDataSource>
		<br />
		
	<%-- </form> --%>
</asp:Content>
