<%@ Page Title="" Language="C#" MasterPageFile="~/index.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="SteamHadaWeb.login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
     <div class="form-box" id="login-box">
        <div class="header">INICIAR SESIÓN</div>
            
                <div class="body bg-gray">

                    <div class="form-group">
                        <asp:TextBox ID="TextUsuario" TextMode="Email" Cssclass="TextBox_personalizado" placeholder="Introduzca el correo" runat="server"></asp:TextBox> 
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ForeColor="Red"
                        ControlToValidate="TextUsuario" ErrorMessage="Introduce el correo!!">
                        </asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ForeColor="Red"
                        ErrorMessage="Formato de correo incorrecto" ControlToValidate="TextUsuario"   
                        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator> 
                    </div>

                     <div class="form-group">
                        <asp:TextBox ID="Textcontrasenya" TextMode="Password" Cssclass="TextBox_personalizado" placeholder="Introduzca la contraseña" runat="server"></asp:TextBox> 
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ForeColor="Red"
                        ControlToValidate="Textcontrasenya" ErrorMessage="Introduce una contraseña!!">
                        </asp:RequiredFieldValidator>
                     </div>

                </div>

                <div class="footer"> 
                    <asp:Button ID="ButIngresar" runat="server" Text="Iniciar Sesión" OnClick="ButIngresar_Click" CssClass="btn bg-olive" />
                    <div class="fb-login-button" data-width="" data-size="large" data-button-type="login_with" data-auto-logout-link="false" data-use-continue-as="true"  data-onlogin="actualizaPagina()"></div>
               </div>

            

        </div>
    <br />
    <br />
    
</asp:Content>
