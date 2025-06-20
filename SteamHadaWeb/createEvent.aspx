<%@ Page Title="" Language="C#" MasterPageFile="~/index.Master" AutoEventWireup="true" CodeBehind="createEvent.aspx.cs" Inherits="SteamHadaWeb.createEvent" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <h2>Crear Eventos</h2>

            <div class="form-group">
                <asp:TextBox ID="Nombre" CssClass="TextBox_personalizado" placeholder="Introduzca nombre" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="NameReq" runat="server" ForeColor="Red"
                ControlToValidate="Nombre" ErrorMessage="Introduce el nombre del evento!!">
                </asp:RequiredFieldValidator>

            </div>
                <div class="form-group">
                <asp:TextBox ID="Descripcion" CssClass="TextBox_personalizado" placeholder="Introduzca Descripcion del evento" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ForeColor="Red"
                ControlToValidate="Descripcion" ErrorMessage="Introduce descripcion!!">
                </asp:RequiredFieldValidator>

            </div>
                <div class="form-group">
                <asp:TextBox ID="Provincia" CssClass="TextBox_personalizado" placeholder="Introduzca Provincia" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ForeColor="Red"
                ControlToValidate="Provincia" ErrorMessage="Introduce provincia!!">
                </asp:RequiredFieldValidator>

            </div>
                <div class="form-group">
                <asp:TextBox ID="Localidad" CssClass="TextBox_personalizado" placeholder="Introduzca Localidad" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ForeColor="Red"
                ControlToValidate="Localidad" ErrorMessage="Introduce localidad!!">
                </asp:RequiredFieldValidator>

            </div>
                <div class="form-group">
                <asp:TextBox ID="FechaInit" CssClass="TextBox_personalizado" placeholder="Introduzca Fecha Inicio" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ForeColor="Red"
                ControlToValidate="FechaInit" ErrorMessage="Introduce fecha!!">
                </asp:RequiredFieldValidator>

            </div>
                <div class="form-group">
                <asp:TextBox ID="FechaOut" CssClass="TextBox_personalizado" placeholder="Introduzca Fecha Salida" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ForeColor="Red"
                ControlToValidate="FechaOut" ErrorMessage="Introduce fecha!!">
                </asp:RequiredFieldValidator>

            </div>
                <div class="form-group">
                <asp:TextBox ID="HoraInit" CssClass="TextBox_personalizado" placeholder="Introduzca Hora Inicio" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ForeColor="Red"
                ControlToValidate="HoraInit" ErrorMessage="Introduce la hra de entrada!!">
                </asp:RequiredFieldValidator>

            </div>
                <div class="form-group">
                <asp:TextBox ID="HoraOut" CssClass="TextBox_personalizado" placeholder="Introduzca Hora Salida" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ForeColor="Red"
                ControlToValidate="HoraOut" ErrorMessage="Introduce la hora de salida!!">
                </asp:RequiredFieldValidator>

            </div>
                <div class="form-group">
                <asp:TextBox ID="Empresa" CssClass="TextBox_personalizado" placeholder="Introduzca Nombre Empresa" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ForeColor="Red"
                ControlToValidate="Empresa" ErrorMessage="Introduce nombre!!">
                </asp:RequiredFieldValidator>

            </div>

            <div class="form-group">
                <asp:TextBox TextMode="Email" ID="Email" CssClass="TextBox_personalizado" placeholder="Introduzca email de la empresa " runat="server">
                </asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ForeColor="Red"
                ControlToValidate="Email" ErrorMessage="Introduce el correo!!">
                </asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ForeColor="Red"
                ErrorMessage="Formato de correo incorrecto" ControlToValidate="Email"   
                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator> 
            </div>

            <div class="form-group">
                <asp:TextBox ID="Tlf" CssClass="TextBox_personalizado" placeholder="Introduzca Teléfino de la Empresa" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ForeColor="Red"
                ControlToValidate="Tlf" ErrorMessage="Introduce el Teléfono!!">
                </asp:RequiredFieldValidator>

            </div>
            <div class="form-group">
                <asp:TextBox ID="Precio" CssClass="TextBox_personalizado" placeholder="Introduzca Precio" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ForeColor="Red"
                ControlToValidate="Precio" ErrorMessage="Introduce el precio de la entrada!!">
                </asp:RequiredFieldValidator>

            </div>

            <div class="footer">
                <asp:Button ID="ButIngresar" runat="server"  Text="Confirmar" CssClass="btn bg-olive" OnClick="crearEvento" />
            </div>

            <asp:Label ID="LabelRespuesta" runat="server"></asp:Label> 
</asp:Content>
