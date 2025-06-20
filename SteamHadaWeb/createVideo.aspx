<%@ Page Title="" Language="C#" MasterPageFile="~/index.Master" AutoEventWireup="true" CodeBehind="createVideo.aspx.cs" Inherits="SteamHadaWeb.createVideo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
         <h2> Crear Video </h2>

            <div class="form-group">
                <asp:TextBox ID="Youtube" CssClass="TextBox_personalizado" placeholder="Ve a youtube, busca el video, click derecho, copiar código inserción y deja aquí sólo la URL" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ForeColor="Red"
                ControlToValidate="Youtube" ErrorMessage="Ve a youtube, busca el video, click derecho, copiar código inserción y deja aquí sólo la URL">
                </asp:RequiredFieldValidator>

            </div>

            <div class="form-group">
                <asp:TextBox ID="Juego" CssClass="TextBox_personalizado" placeholder="Introduzca Juego" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ForeColor="Red"
                ControlToValidate="Juego" ErrorMessage="Introduce el Juego!!">
                </asp:RequiredFieldValidator>

            </div>

            <div class="form-group">
                <asp:TextBox ID="Autor" CssClass="TextBox_personalizado" placeholder="Introduzca Autor" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ForeColor="Red"
                ControlToValidate="Autor" ErrorMessage="Introduce el Autor!!">
                </asp:RequiredFieldValidator>

            </div>

            <div class="footer">
                <asp:Button ID="ButIngresar" runat="server"  Text="Confirmar" CssClass="btn bg-olive" OnClick="crearVideo" />
            </div>

            <asp:Label ID="LabelRespuesta" runat="server"></asp:Label> 
</asp:Content>
