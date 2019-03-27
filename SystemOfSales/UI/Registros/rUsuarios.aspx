<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="rUsuarios.aspx.cs" Inherits="SystemOfSales.UI.Registros.rUsuarios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class=" panel panel-primary">
        <div class="panel-heading text-center">
            <h1><ins>Usuario</ins></h1>
            <br />
        </div>
    </div>

    <div class="col-sm-12">

        <div class="Container-fluid">
            <div class="align-content-center">
            </div>
            <%--   UsuarioId--%>
            <div>
                <table>
                    <tr>
                        <td>
                            <strong>
                                <asp:Label ID="ID" runat="server" Text="UsuarioId: "></asp:Label></strong>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:TextBox ID="UsuarioIdTextbox" runat="server" class="form-control" Height="30" Width="200" ValidationGroup="Buscar"></asp:TextBox>
                        </td>
                        <td>&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp<asp:Button ID="BuscarButton" ValidationGroup="Buscar" runat="server" class="btn btn-info" Text="Buscar" OnClick="BuscarButton_Click" />
                            <asp:RegularExpressionValidator ID="ValidaID" runat="server" ErrorMessage='solo acepta numeros' ControlToValidate="UsuarioIdTextbox" ValidationExpression="^[0-9]*" Text="*" ForeColor="Red" Display="Dynamic" ToolTip="Entrada no valida" ValidationGroup="Guardar"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                </table>
            </div>
            <br />

            <%--  Fecha--%>

            <div>
                <table>
                    <tr>
                        <td>
                            <strong>
                                <asp:Label ID="Label8" runat="server" Text="Fecha: "></asp:Label></strong>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:TextBox ID="FechaTextBox" ValidationGroup="Guardar" runat="server" class="form-control" type="date" Height="30" Width="300" MaxLength="10"></asp:TextBox>
                            <asp:RequiredFieldValidator ValidationGroup="Guardar" ID="RequiredFieldValidator1" CssClass="ErrorMessage" ControlToValidate="FechaTextBox" runat="server" ErrorMessage="Seleccione una Fecha"></asp:RequiredFieldValidator>
                        </td>

                    </tr>
                </table>
            </div>
        </div>


        <%--NombreTextbox--%>
        <div>
            <table>
                <tr>
                    <td>
                        <strong>
                            <asp:Label ID="Nombre" runat="server" Text="Nombre:"></asp:Label></strong>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="NombreTextBox" runat="server" class="form-control" Height="30" Width="300" MaxLength="80"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RegularExpressionValidator ID="Valida" runat="server" ErrorMessage='solo acepta letras' ControlToValidate="NombreTextBox" ValidationExpression="(^[a-zA-Z'.\s]{1,20}$)" Text="*" ForeColor="Red" Display="Dynamic" ToolTip="Entrada no valida" ValidationGroup="Guardar"></asp:RegularExpressionValidator>
                        <asp:RequiredFieldValidator ID="ValidaNombre" runat="server" ErrorMessage="El campo &quot;Nombre&quot; esta vacio" ControlToValidate="NombreTextBox" ForeColor="Red" Display="Dynamic" ToolTip="Campo  es obligatorio" ValidationGroup="Guardar">*</asp:RequiredFieldValidator>

                    </td>
                </tr>
            </table>
        </div>
        <br />

        <%--EmailTextBox--%>
        <div>
            <table>
                <tr>
                    <td>
                        <strong>
                            <asp:Label ID="Email" runat="server" Text="Email:"></asp:Label></strong>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="EmailTextBox" runat="server" class="form-control" Height="30" Width="300" MaxLength="80"></asp:TextBox>
                    </td>
                    <td>

                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ValidationGroup="Guardar" ControlToValidate="EmailTextBox" runat="server" ErrorMessage="*" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>

                    </td>
                </tr>
            </table>
        </div>
        <br />


        <%--Contrasena--%>
        <div>
            <table>
                <tr>
                    <td>
                        <strong>
                            <label for="ContrasenaTextBox">Contraseña</label></strong>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="ContrasenaTextBox" class="form-control input-sm" AutoCompleteType="Disabled" TextMode="Password" placeholder="Contraseña" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="ContrasenaTextBox" ValidationGroup="Guardar" runat="server" ErrorMessage="*" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>

                    </td>
                </tr>
            </table>
        </div>
        <br />

        <%--Confirmar--%>
        <div>
            <table>
                <tr>
                    <td>
                        <strong>
                            <label for="ConfirmarTextBox">Confirmar</label></strong>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="ConfirmarTextBox" class="form-control input-sm" AutoCompleteType="Disabled" TextMode="Password" placeholder="Confirmar" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:CustomValidator ID="CustomValidator" runat="server" ControlToValidate="ConfirmarTextBox" ValidationGroup="Guardar" ForeColor="Red" Display="Dynamic" ErrorMessage="Contraseña No Coinciden  " OnServerValidate="CustomValidator_ServerValidate"></asp:CustomValidator>

                    </td>
                </tr>
            </table>
        </div>
        <br />


        <%--  TipoUsuario--%>
        <div>
            <table>
                <tr>
                    <td>
                        <strong>
                            <label for="TipoUsuarioDropDownList">Tipo Usuario</label></strong>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:DropDownList ID="TipoUsuarioDropDownList" class="form-control input-sm" runat="server">
                         <asp:ListItem Selected="True">[Seleccione]</asp:ListItem>
                        </asp:DropDownList>
                        <asp:CustomValidator ID="CustomValidator1" runat="server" ControlToValidate="TipoUsuarioDropDownList" ValidationGroup="Guardar" ForeColor="Red" Display="Dynamic" ErrorMessage="Seleccione Un Tipo De Usuario " OnServerValidate="CustomValidator1_ServerValidate"></asp:CustomValidator>

                    </td>

                </tr>
            </table>
        </div>
    </div>


    <%--Botones--%>
    <div class="panel-footer">
        <div class="text-center">
            <asp:Label class="text-center " ID="ErrorLabel" runat="server" Text=""></asp:Label>

            <asp:Button ID="NuevoButton" runat="server" class="btn btn-info" Text="Nuevo" OnClick="NuevoButton_Click" ValidationGroup="Nuevo" />&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
                   
                <asp:Button ID="GuardarButton" runat="server" class="btn btn-success" Text="Guardar" OnClick="GuardarButton_Click" ValidationGroup="Guardar" />&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
                   
                <asp:Button ID="EliminarButton" runat="server" class="btn btn-danger" Text="Eliminar" OnClick="EliminarButton_Click" />&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp

               
        </div>

    </div>




</asp:Content>
