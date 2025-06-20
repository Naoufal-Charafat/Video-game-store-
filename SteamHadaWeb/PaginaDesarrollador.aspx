<%@ Page Title="" Language="C#" MasterPageFile="~/index.Master" AutoEventWireup="true" CodeBehind="PaginaDesarrollador.aspx.cs" Inherits="SteamHadaWeb.PaginaDesarrollador" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="row">
        <div class = "column_UserConfiguration columnLeft_UserConfiguration">
            <ul>
            <li ID="asubirJuegos" ><a style="text-decoration:none"> Subir Juego </a></li> 
            <li ID="ajuegosDesarrollados"><a style="text-decoration:none">Configuración de Juegos </a></li>
            </ul>
         </div>

         <div class ="column_UserConfiguration columnRight_UserConfiguration">
            <div id="subirJuegos" style="display:block">
                <ul>
                    <li>Nombre <asp:TextBox runat="server" ID="GameNameReq"></asp:TextBox> </li> <br />
                     <asp:RequiredFieldValidator runat="server" ForeColor="Red"  ValidationGroup="valGroup2"
                    ControlToValidate="GameNameReq" ErrorMessage="Introduce el nombre del juego!!">
                         
                    </asp:RequiredFieldValidator>
                    <li>Descripcion      <br />  <asp:TextBox  runat="server" ID="GameDescReq" Width="500px" Height="50px"></asp:TextBox></li> <br />
                    <asp:RequiredFieldValidator runat="server" ForeColor="Red"  ValidationGroup="valGroup2"
                    ControlToValidate="GameDescReq" ErrorMessage="Introduce la descripcion del juego!!">
                    </asp:RequiredFieldValidator>
                    <li>Precio <asp:TextBox ID="GamePriceReq" runat="server" ></asp:TextBox></li> <br />
                    <asp:RequiredFieldValidator runat="server" ForeColor="Red"  ValidationGroup="valGroup2"
                    ControlToValidate="GamePriceReq" ErrorMessage="Introduce el precio del juego!!">
                    </asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ForeColor="Red"
                    ErrorMessage="Introduce solo números con el siguiente formato 23.40" ControlToValidate="GamePriceReq"    ValidationGroup="valGroup2"
                    ValidationExpression="\d+(\.\d{1,2})?"></asp:RegularExpressionValidator>
                    
                   <li> Categoria <asp:DropDownList ID="DDLCategoria" runat="server" DataSourceID="SqlDataSource1" DataTextField="nombre" DataValueField="nombre">
                    </asp:DropDownList>
                       </li>
                    <br />
                <li><asp:FileUpload ID="RegGameNomFileUpload" text="Subir foto" runat="server" CssClass="form-control" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ForeColor="Red"  ValidationGroup="valGroup2"
                ControlToValidate="RegGameNomFileUpload" ErrorMessage="Introduce  una imagen!!">
                </asp:RequiredFieldValidator></li>
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:miconexion %>" SelectCommand="SELECT * FROM [Categoria]"></asp:SqlDataSource>
                    <br />
                    <asp:Button ID="saveChanges" runat="server" Text="Subir"  ValidationGroup="valGroup2" OnClick="saveChanges_Click" />
                       
                </ul>
            </div>
             <div id="juegosDesarrollados" style="display:none">
            <h2>Juegos desarrollados </h2>

             <br />
             <br />
                 <ul>
                    <li>Descripcion      <br />  <asp:TextBox  runat="server" ID="GameDescReq2" Width="500px" Height="50px"></asp:TextBox></li> <br />
                    <asp:RequiredFieldValidator runat="server" ForeColor="Red"  ValidationGroup="valGroup1"
                    ControlToValidate="GameDescReq2" ErrorMessage="Introduce la descripcion del juego!!">
                    </asp:RequiredFieldValidator>
                    <li>Precio <asp:TextBox ID="GamePriceReq2" runat="server" ></asp:TextBox></li> <br />
                    <asp:RequiredFieldValidator runat="server" ForeColor="Red"
                         ValidationGroup="valGroup1"
                    ControlToValidate="GamePriceReq2" ErrorMessage="Introduce el precio del juego!!">
                    </asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ForeColor="Red"
                    ErrorMessage="Introduce solo números" ControlToValidate="GamePriceReq2"    ValidationGroup="valGroup1"
                    ValidationExpression="\d+(\.\d{1,2})?"></asp:RegularExpressionValidator>
                    
                   <li> Categoria <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlDataSource1" DataTextField="nombre" DataValueField="nombre">
                    </asp:DropDownList>
                       </li>
                    <br />
                <li><asp:FileUpload ID="RegGameNomFileUpload2" text="Subir foto" runat="server" CssClass="form-control" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ForeColor="Red"  ValidationGroup="valGroup1"
                ControlToValidate="RegGameNomFileUpload2" ErrorMessage="Introduce  una imagen!!">
                </asp:RequiredFieldValidator></li>

                 </ul>
                 <br />
                 
                 <br />
                 
                 <br />
                 <br />
                 <br />
                 <br />
                 <br />
                 <br />
                 <br />
                 <br />
               
                 <br />
                 <br />
                 <br />
                 <br />
                 <br />
                 <br />
                <asp:GridView ID="listaJuegos" runat="server" AllowPaging="True" Width="720px" OnRowDataBound="listaJuegos_RowDataBound">
             </asp:GridView>
             
                   </div>
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
        <script type="text/javascript">
        var divSubirJuego = document.getElementById("asubirJuegos");
        divSubirJuego.style.cursor = 'pointer';
            divSubirJuego.onclick = function () {
                        document.getElementById("juegosDesarrollados").style.display = "none";
            document.getElementById("subirJuegos").style.display = "block";

        };
        var divJuegoDesarrollados = document.getElementById("ajuegosDesarrollados");
        divJuegoDesarrollados.style.cursor = 'pointer';
        divJuegoDesarrollados.onclick = function () {
                        document.getElementById("juegosDesarrollados").style.display = "block";
            document.getElementById("subirJuegos").style.display = "none";
        };

    </script>
        
</asp:Content>
