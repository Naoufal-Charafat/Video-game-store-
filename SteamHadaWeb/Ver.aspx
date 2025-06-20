<%@ Page Title="" Language="C#" MasterPageFile="~/index.Master" AutoEventWireup="true" CodeBehind="Ver.aspx.cs" Inherits="SteamHadaWeb.Ver" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        #indiv {
            text-align: left;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div>
            <asp:Label ID="URL" runat="server" ></asp:Label>
            <iframe ID="video1" runat="server" width="472"  height="266" frameborder="0" allow="accelerometer; autoplay; encrypted-media; gyroscope; picture-in-picture" allowfullscreen></iframe>
            <br /><br />
            <div>
				<asp:PlaceHolder ID="PlaceNuevoMensaje" runat="server" Visible="true">
					<asp:Table runat="server" Width="100%">
						<asp:TableRow runat="server">
							<asp:TableCell Width="30%" HorizontalAlign="Center">
								<asp:Button ID="ButtonNuevoMensaje" runat="server" Text="Publicar Comentario:" Width="80%"/>
							</asp:TableCell>
							<asp:TableCell Width="70%">
								<asp:TextBox ID="NuevoMensaje" runat="server" TextMode="MultiLine" Width="100%" Height="70px"></asp:TextBox>
							</asp:TableCell>
						</asp:TableRow>
					</asp:Table>
				</asp:PlaceHolder>
			</div>
        </div>
    <br /><br />
</asp:Content>
