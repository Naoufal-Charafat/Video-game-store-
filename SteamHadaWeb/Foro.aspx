<%@ Page Title="Foro" Language="C#" MasterPageFile="~/index.Master" AutoEventWireup="true" CodeBehind="~/Foro.aspx.cs" Inherits="SteamHadaWeb.Foro" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<%-- <form id="formForo" runat="server" aria-expanded="true" style="background-color:gainsboro">--%>
		<div style="background-color:cornflowerblue;
					text-align: center;
					vertical-align: central;
					height: 70px; padding-top:15px">
			<h1>BOGAMES FORO</h1>
		</div>
		<div style="padding-top:10px; margin-left: 14%; margin-right: 14%">
			<div>
				<asp:Table runat="server" Width="100%">
					<asp:TableRow>
						<asp:TableCell HorizontalAlign="Left" Width="40%" VerticalAlign="Middle">
							<asp:Label runat="server" Font-Size="16" Font-Bold="true" Text="ÍNDICE DE HILOS "></asp:Label>
						</asp:TableCell>
						<asp:TableCell HorizontalAlign="Right" Width="60%" VerticalAlign="Middle">
							<asp:Label runat="server" Text=""></asp:Label>
							<asp:Button ID="ButtonCrearHilo1" Height="20px" Width="70px" runat="server" Text="Crear Hilo" Visible="true" OnClick="ButtonCrearHilo_Click"/>
						</asp:TableCell>
					</asp:TableRow>
				</asp:Table>
				<asp:PlaceHolder runat="server" ID="PlaceNuevoHilo" Visible="false" >
					<asp:Table runat="server" Width="100%">
					<asp:TableRow>
						<asp:TableCell HorizontalAlign="Left" Width="15%" VerticalAlign="Middle">
							Nuevo asunto:
						</asp:TableCell>
						<asp:TableCell HorizontalAlign="Right" Width="85%" VerticalAlign="Middle">
							<asp:TextBox ID="NuevoAsunto" runat="server" Width="100%"></asp:TextBox>
						</asp:TableCell>
					</asp:TableRow>
					<asp:TableRow>
						<asp:TableCell HorizontalAlign="Left" Width="15%" VerticalAlign="Middle">
							Descripción: 
							<br />
							<br />
							<asp:Button ID="ButtonCearHilo2" runat="server" Width="80px" Text="Crear" OnClick="ButtonCearHilo2_Click"/>
						</asp:TableCell>
						<asp:TableCell HorizontalAlign="Right" Width="85%" VerticalAlign="Middle">
							<asp:TextBox ID="DescripcionNuevoHilo" TextMode="MultiLine" runat="server" Width="100%" Height="70px"></asp:TextBox>
						</asp:TableCell>
					</asp:TableRow>
				</asp:Table>
					<asp:RequiredFieldValidator ID="RequiredFieldValidator1" ForeColor="Red" ControlToValidate="NuevoAsunto" runat="server" ErrorMessage="Necesitas escribir un asunto para crear un hilo<br />"></asp:RequiredFieldValidator>
					<asp:RegularExpressionValidator ID="RegularExpressionValidator1" ForeColor="Red"  ValidationExpression="^([\S\s\d\D\w\W]{0,100})$" runat="server" ControlToValidate="NuevoAsunto" ErrorMessage="El título no puede superar los 100 caracteres"></asp:RegularExpressionValidator>
					<br />
					<asp:RequiredFieldValidator ID="RequiredFieldValidator2" ForeColor="Red" ControlToValidate="DescripcionNuevoHilo" runat="server" ErrorMessage="Necesitas escribir a descripción<br />"></asp:RequiredFieldValidator> 
					<asp:RegularExpressionValidator ID="RegularExpressionValidator2" ForeColor="Red"  ValidationExpression="^([\S\s\d\D\w\W]{0,800})$" runat="server" ControlToValidate="DescripcionNuevoHilo" ErrorMessage="La descripción no puede superar los 800 caracteres"></asp:RegularExpressionValidator>
					<%--  %><asp:ValidationSummary ID="ValidationSummary1" runat="server" /> --%>
				</asp:PlaceHolder>
			</div>
			

			<asp:ListView ID="ListView1" runat="server" DataKeyNames="correo,numero" DataSourceID="SqlDataSource1" style="width: 330px" OnSelectedIndexChanged="ListView1_SelectedIndexChanged">
				<AlternatingItemTemplate>
					<tr style="background-color: #e8effa;color: #333333;  height: 30px;
								padding-top:5px;
								padding-bottom: 5px;
								padding-left:5px;
								padding-right:5px">
						<td style="width : 700px">
							<asp:HyperLink ID="tituloLink" runat="server" Text='<%# Eval("titulo") %>' NavigateUrl='<%# string.Concat("Hilo.aspx?hiloForo=", Eval("numero")) %>' />
						</td>
						<td style="width : 100px; text-align:center">
							<asp:Label ID="numMensajesLabel" runat="server" Text='<%# Eval("numMensajes") %>' />
						</td>
						<td style="width : 200px">
							<asp:Label ID="fechaInicioLabel" runat="server" Text='<%# Eval("fechaInicio") %>' />
							<br />
							Por <asp:label ID="autorLabel" runat="server" Text='<%# Eval("autor") %>'/>
						</td>
						
						<%--  
						<asp:Label ID="apellidosAutorLabel" runat="server" Text='<%# Eval("apellidosAutor") %>' />
						
						
						<asp:Label ID="numeroLabel" runat="server" Text='<%# Eval("numero") %>' />
						
						<asp:Label ID="correoLabel" runat="server" Text='<%# Eval("correo") %>' />
						--%>

					</tr>
				</AlternatingItemTemplate>
				<EditItemTemplate>
					<tr style="background-color: #999999;">
						<td>
							<asp:Button ID="UpdateButton" runat="server" CommandName="Update" Text="Actualizar" />
							<asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Cancelar" />
						</td>
						<td>
							<asp:Label ID="correoLabel1" runat="server" Text='<%# Eval("correo") %>' />
						</td>
						<td>
							<asp:TextBox ID="autorTextBox" runat="server" Text='<%# Bind("autor") %>' />
						</td>
						<td>
							<asp:TextBox ID="apellidosAutorTextBox" runat="server" Text='<%# Bind("apellidosAutor") %>' />
						</td>
						<td>
							<asp:TextBox ID="fechaInicioTextBox" runat="server" Text='<%# Bind("fechaInicio") %>' />
						</td>
						<td>
							<asp:TextBox ID="tituloTextBox" runat="server" Text='<%# Bind("titulo") %>' />
						</td>
						<td>
							<asp:TextBox ID="numMensajesTextBox" runat="server" Text='<%# Bind("numMensajes") %>' />
						</td>
						<td>
							<asp:Label ID="numeroLabel1" runat="server" Text='<%# Eval("numero") %>' />
						</td>
					</tr>
				</EditItemTemplate>
				<EmptyDataTemplate>
					<table runat="server" style="background-color: #FFFFFF;border-collapse: collapse;border-color: #999999;border-style:none;border-width:1px;">
						<tr>
							<td>No hay hilos en el foro</td>
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
							<asp:TextBox ID="correoTextBox" runat="server" Text='<%# Bind("correo") %>' />
						</td>
						<td>
							<asp:TextBox ID="autorTextBox" runat="server" Text='<%# Bind("autor") %>' />
						</td>
						<td>
							<asp:TextBox ID="apellidosAutorTextBox" runat="server" Text='<%# Bind("apellidosAutor") %>' />
						</td>
						<td>
							<asp:TextBox ID="fechaInicioTextBox" runat="server" Text='<%# Bind("fechaInicio") %>' />
						</td>
						<td>
							<asp:TextBox ID="tituloTextBox" runat="server" Text='<%# Bind("titulo") %>' />
						</td>
						<td>
							<asp:TextBox ID="numMensajesTextBox" runat="server" Text='<%# Bind("numMensajes") %>' />
						</td>
						<td>&nbsp;</td>
					</tr>
				</InsertItemTemplate>
				<ItemTemplate>
					<tr style=" background-color: #bbdede;color: #333333;  height: 30px;
								padding-top:5px;
								padding-bottom: 5px;
								padding-left:5px;
								padding-right:5px ">
						<td style="width : 800px">
							<asp:HyperLink ID="tituloLink" runat="server" Text='<%# Eval("titulo") %>' NavigateUrl='<%# string.Concat("Hilo.aspx?hiloForo=", Eval("numero")) %>' />
						</td>
						<td style="width : 100px; text-align:center">
							<asp:Label ID="numMensajesLabel" runat="server" Text='<%# Eval("numMensajes") %>' />
						</td>
						<td style="width : 200px">
							<asp:Label ID="fechaInicioLabel" runat="server" Text='<%# Eval("fechaInicio") %>' />
							<br />
							Por <asp:Label ID="autorLabel" runat="server" Text='<%# Eval("autor") %>' />
						</td>
						
						<%--  
						<asp:Label ID="apellidosAutorLabel" runat="server" Text='<%# Eval("apellidosAutor") %>' />
						
						
						<asp:Label ID="numeroLabel" runat="server" Text='<%# Eval("numero") %>' />
						
						<asp:Label ID="correoLabel" runat="server" Text='<%# Eval("correo") %>' />
						--%>

					</tr>
				</ItemTemplate>
				<LayoutTemplate>
					<table runat="server">
						<tr runat="server">
							<td runat="server">
								<table id="itemPlaceholderContainer" runat="server" border="1" style="background-color: #FFFFFF;border-collapse: collapse;border-color: #999999;border-style:none;border-width:1px;font-family: Verdana, Arial, Helvetica, sans-serif;">
									<tr runat="server" style="background-color: #E0FFFF;color: #333333;">
										<th runat="server">Asunto</th>
										<th runat="server">Mensajes</th>
										<th runat="server">Creado</th>
									</tr>
									<tr id="itemPlaceholder" runat="server">
									</tr>
								</table>
							</td>
						</tr>
							<tr runat="server">
                                <td runat="server" style="text-align: center;background-color: #5D7B9D;font-family: Verdana, Arial, Helvetica, sans-serif;color: #FFFFFF">
                                    <asp:DataPager ID="DataPager1" runat="server" PageSize="5">
                                        <Fields>
                                            <asp:NextPreviousPagerField ButtonCssClass="btn-default" ButtonType="Button"  ShowFirstPageButton="True" ShowLastPageButton="True" />
                                        </Fields>
                                    </asp:DataPager>
                                </td>
                            </tr>

					</table>
				</LayoutTemplate>
				<SelectedItemTemplate>
					<tr style="background-color: #E2DED6;font-weight: bold;color: #333333;">
						<td>
							<asp:Label ID="correoLabel" runat="server" Text='<%# Eval("correo") %>' />
						</td>
						<td>
							<asp:Label ID="autorLabel" runat="server" Text='<%# Eval("autor") %>' />
						</td>
						<td>
							<asp:Label ID="apellidosAutorLabel" runat="server" Text='<%# Eval("apellidosAutor") %>' />
						</td>
						<td>
							<asp:Label ID="fechaInicioLabel" runat="server" Text='<%# Eval("fechaInicio") %>' />
						</td>
						<td>
							<asp:Label ID="tituloLabel" runat="server" Text='<%# Eval("titulo") %>' />
						</td>
						<td>
							<asp:Label ID="numMensajesLabel" runat="server" Text='<%# Eval("numMensajes") %>' />
						</td>
						<td>
							<asp:Label ID="numeroLabel" runat="server" Text='<%# Eval("numero") %>' />
						</td>
					</tr>
				</SelectedItemTemplate>
			</asp:ListView>


			<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:miconexion %>" SelectCommand="SELECT correo, nombre AS autor, apellidos AS apellidosAutor, fechaInicio, titulo, numero, numMensajes
	FROM Usuario, HiloForo,
	(SELECT count(hiloForo) as numMensajes, hiloForo
		from Mensaje
		GROUP BY hiloForo
		UNION
		SELECT 0 as numMensajes, numero
		FROM HiloForo
		WHERE numero NOT IN (SELECT hiloForo from mensaje)
	) AS t
	WHERE Usuario.correo = HiloForo.usuario and t.hiloForo = HiloForo.numero"></asp:SqlDataSource>


			<div>
				<%-- 
				<asp:Table ID="Table1" runat="server"
					CellSpacing="8" 
					BackColor="WhiteSmoke"
					Width="100%"
					CellPadding="8">
					<asp:TableHeaderRow ID="ForoTableHeaderRow" EnableViewState="True" VerticalAlign="Top">
						<asp:TableHeaderCell Width="70%" HorizontalAlign="Left" Font-Size="Medium">Asunto</asp:TableHeaderCell>
						<asp:TableHeaderCell Width="10%" HorizontalAlign="Left" Font-Size="Medium">Mensajes</asp:TableHeaderCell>
						<asp:TableHeaderCell Width="20%" HorizontalAlign="Left" Font-Size="Medium">Creado</asp:TableHeaderCell>
					</asp:TableHeaderRow>

					<asp:TableRow ID="HiloTableRow1" Visible="True" VerticalAlign="Top">
						<asp:TableCell>
							<asp:LinkButton ID="HiloAsunto1" runat="server" Text="Primer Asunto" href="Hilo.aspx"></asp:LinkButton>
						</asp:TableCell>
						<asp:TableCell>
							<asp:Label ID="HiloMensajes1" runat="server" Text="0"></asp:Label>
						</asp:TableCell>
						<asp:TableCell>
							<asp:Label ID="HiloFecha1" runat="server" Text="03/05/2019 - 15:02"></asp:Label>
							<br />
							Por
							<asp:LinkButton ID="HiloAutor1" runat="server" Text="NombreUsuario" href="UserDetails.aspx"></asp:LinkButton>
						</asp:TableCell>
					</asp:TableRow>

					<asp:TableRow ID="HiloTableRow2" Visible="True" VerticalAlign="Top">
						<asp:TableCell>
							<asp:LinkButton ID="HiloAsunto2" runat="server" Text="Asunto de ejemplo más largo" href="Hilo.aspx"></asp:LinkButton>
						</asp:TableCell>
						<asp:TableCell>
							<asp:Label ID="HiloMensajes2" runat="server" Text="0"></asp:Label>
						</asp:TableCell>
						<asp:TableCell>
							<asp:Label ID="HiloFecha2" runat="server" Text="12/02/2019 - 15:02"></asp:Label>
							<br />
							Por 
							<asp:LinkButton ID="HiloAutor2" runat="server" Text="NombreUsuario" href="UserDetails.aspx"></asp:LinkButton>
						</asp:TableCell>
					</asp:TableRow>
				</asp:Table>
				--%>
			</div>
		</div>
		<br />
		
	<%--</form>--%>
	
</asp:Content>
