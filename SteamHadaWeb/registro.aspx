<%@ Page Title="" Language="C#" MasterPageFile="~/index.Master" AutoEventWireup="true" CodeBehind="registro.aspx.cs" Inherits="SteamHadaWeb.registroUsuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="form-box" id="registro-box">
        <div class="header">REGISTRO</div>

        <div class="body bg-gray">

            <div class="form-group">
                <asp:TextBox ID="RegUsuarioNom" CssClass="TextBox_personalizado" placeholder="Introduzca nombre" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="UserNameReq" runat="server" ForeColor="Red"
                ControlToValidate="RegUsuarioNom" ErrorMessage="Introduce el nombre de usuario!!">
                </asp:RequiredFieldValidator>

            </div>

            <div class="form-group">
                <asp:TextBox ID="RegUsuarioApell" CssClass="TextBox_personalizado" placeholder="Introduzca apellidos" runat="server"></asp:TextBox>
                 <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ForeColor="Red"
                ControlToValidate="RegUsuarioApell" ErrorMessage="Introduce los apellidos !!">
                
                </asp:RequiredFieldValidator>
            </div>

            <div class="form-group">
                <asp:TextBox TextMode="Email" ID="RegUsuarioCorreo" CssClass="TextBox_personalizado" placeholder="Introduzca  correo electrónico " runat="server">
                </asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ForeColor="Red"
                ControlToValidate="RegUsuarioCorreo" ErrorMessage="Introduce el correo!!">
                </asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ForeColor="Red"
                ErrorMessage="Formato de correo incorrecto" ControlToValidate="RegUsuarioCorreo"   
                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator> 
            </div>

            <div class="form-group">
                <asp:TextBox TextMode="Phone" ID="RegUsuarioTel" CssClass="TextBox_personalizado" placeholder="Introduzca telefono" runat="server"/>

                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ForeColor="Red"
                ControlToValidate="RegUsuarioTel" ErrorMessage="Introduce el telefono!!">
                </asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Introduce un número válido" ControlToValidate="RegUsuarioTel" ValidationExpression="^[0-9]{9,9}"  ForeColor="Red"></asp:RegularExpressionValidator>
            </div>

            <div class="form-group">
                <asp:TextBox TextMode="Password" ID="RegUsuarioContra" CssClass="TextBox_personalizado" placeholder="Introduzca contraseña" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ForeColor="Red"
                ControlToValidate="RegUsuarioContra" ErrorMessage="Introduce una contraseña!!">
                </asp:RequiredFieldValidator>
            </div>

            <div class="form-group">
                <asp:TextBox TextMode="Password" ID="RegUsuarioRepContra" CssClass="TextBox_personalizado" placeholder="Repetir contraseña" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ForeColor="Red"
                ControlToValidate="RegUsuarioRepContra" ErrorMessage="Confirma la contraseña!!"> 
                </asp:RequiredFieldValidator>
                <br />
                  <asp:CompareValidator
                      ViewStateMode="Disabled"
                      runat="server" 
                     ControlToValidate="RegUsuarioRepContra"
                     ForeColor="Red"
                     ControlToCompare="RegUsuarioContra"
                     ErrorMessage="No coinciden las contraseñas" 
                     />
            </div>

            <div class="form-group">
                <asp:FileUpload ID="RegUsuarioNomFileUpload" text="Subir foto" runat="server" CssClass="form-control" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ForeColor="Red"
                ControlToValidate="RegUsuarioNomFileUpload" ErrorMessage="Introduce  una imagen!!">
                </asp:RequiredFieldValidator>
            </div>

        </div>
        </div>

        <div class="footer">
            <asp:Button ID="ButIngresar" runat="server"  Text="Confirmar" CssClass="btn bg-olive" OnClick="ButIngresar_Click" />
           
            <br />  
         <div id="registrobody" class="fa-briefcase" style="height: 8%">
                
                <div class="fb-login-button"  data-width="" data-size="large" data-button-type="continue_with" data-auto-logout-link="false" data-use-continue-as="true" data-onlogin="actualizaPagina()"></div>
         
         </div>
        
        </div>

</asp:Content>
