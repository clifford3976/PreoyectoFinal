<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="rClientes.aspx.cs" Inherits="SystemOfSales.UI.Registros.rClientes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class=" panel panel-primary">
        <div class="panel-heading text-center">
            <h1><ins>Cliente</ins></h1>
            <br />
        </div>
    </div>

    <div class="col-sm-12">

        <div class="Container-fluid">
            <div class="align-content-center">
            </div>

            <%--   ClienteId--%>
            <div>
                <table>
                    <tr>
                        <td>
                            <strong>
                                <asp:Label ID="ID" runat="server" Text="ClienteId: "></asp:Label></strong>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:TextBox ID="ClienteIdTextbox" runat="server" class="form-control" Height="30" Width="200" ValidationGroup="Buscar"></asp:TextBox>
                        </td>
                        <td>&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp<asp:Button ID="BuscarButton" ValidationGroup="Buscar" runat="server" class="btn btn-info" Text="Buscar" OnClick="BuscarButton_Click" />
                            <asp:RegularExpressionValidator ID="ValidaID" runat="server" ErrorMessage='solo acepta numeros' ControlToValidate="ClienteIdTextbox" ValidationExpression="^[0-9]*" Text="*" ForeColor="Red" Display="Dynamic" ToolTip="Entrada no valida" ValidationGroup="Guardar"></asp:RegularExpressionValidator>
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

        <%--ApellidoTextBox--%>
        <div>
            <table>
                <tr>
                    <td>
                        <strong>
                            <asp:Label ID="Apellido" runat="server" Text="Apellido:"></asp:Label></strong>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="ApellidoTextBox" runat="server" class="form-control" Height="30" Width="300" MaxLength="80"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage='solo acepta letras' ControlToValidate="ApellidoTextBox" ValidationExpression="(^[a-zA-Z'.\s]{1,20}$)" Text="*" ForeColor="Red" Display="Dynamic" ToolTip="Entrada no valida" ValidationGroup="Guardar"></asp:RegularExpressionValidator>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="El campo &quot;Apellido&quot; esta vacio" ControlToValidate="ApellidoTextBox" ForeColor="Red" Display="Dynamic" ToolTip="Campo  es obligatorio" ValidationGroup="Guardar">*</asp:RequiredFieldValidator>

                    </td>
                </tr>
            </table>
        </div>
        <br />

        <%--DireccionTextBox--%>
        <div>
            <table>
                <tr>
                    <td>
                        <strong>
                            <asp:Label ID="Direccion" runat="server" Text="Direccion:"></asp:Label></strong>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="DireccionTextBox" runat="server" class="form-control" Height="30" Width="300" MaxLength="80"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage='solo acepta letras' ControlToValidate="DireccionTextBox" ValidationExpression="(^[a-zA-Z'.\s]{1,20}$)" Text="*" ForeColor="Red" Display="Dynamic" ToolTip="Entrada no valida" ValidationGroup="Guardar"></asp:RegularExpressionValidator>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="El campo &quot;Direccion&quot; esta vacio" ControlToValidate="DireccionTextBox" ForeColor="Red" Display="Dynamic" ToolTip="Campo  es obligatorio" ValidationGroup="Guardar">*</asp:RequiredFieldValidator>

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

                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ValidationGroup="Guardar" ControlToValidate="EmailTextBox" runat="server" ErrorMessage="*" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>

                    </td>
                </tr>
            </table>
        </div>
        <br />


        <%--CedulaTextBox--%>
        <div>
            <table>
                <tr>
                    <td>
                        <strong>
                            <asp:Label ID="Cedula" runat="server" Text="Cedula:"></asp:Label></strong>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="CedulaTextBox" runat="server" class="form-control" Height="30" Width="300" MaxLength="80"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ErrorMessage=' solo acepta numeros' ControlToValidate="CedulaTextBox" ValidationExpression="^[0.0-9.0]*" Text="*" ForeColor="Red" Display="Dynamic" ToolTip="Entrada no valida" ValidationGroup="Guardar"></asp:RegularExpressionValidator>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="El campo &quot;cedula&quot; esta vacio" ControlToValidate="CedulaTextBox" ForeColor="Red" Display="Dynamic" ToolTip="Campo obligatorio" ValidationGroup="Guardar">*</asp:RequiredFieldValidator>

                    </td>
                </tr>
            </table>
        </div>
        <br />

        <%--TelefonoTextBox--%>
        <div>
            <table>
                <tr>
                    <td>
                        <strong>
                            <asp:Label ID="Telefono" runat="server" Text="Telefono:"></asp:Label></strong>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="TelefonoTextBox" runat="server" class="form-control" Height="30" Width="300" MaxLength="80"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RegularExpressionValidator ID="ValidaMontoNUM" runat="server" ErrorMessage=' solo acepta numeros' ControlToValidate="TelefonoTextBox" ValidationExpression="^[0.0-9.0]*" Text="*" ForeColor="Red" Display="Dynamic" ToolTip="Entrada no valida" ValidationGroup="Guardar"></asp:RegularExpressionValidator>
                        <asp:RequiredFieldValidator ID="ValidaTelefono" runat="server" ErrorMessage="El campo &quot;Telefono&quot; esta vacio" ControlToValidate="TelefonoTextBox" ForeColor="Red" Display="Dynamic" ToolTip="Campo obligatorio" ValidationGroup="Guardar">*</asp:RequiredFieldValidator>

                    </td>
                </tr>
            </table>
        </div>
        <br />

        <%--Botones--%>
        <div class="panel-footer">
            <div class="text-center">
                <asp:Label class="text-center " ID="ErrorLabel" runat="server" Text=""></asp:Label>

                <asp:Button ID="NuevoButton" runat="server" class="btn btn-info" Text="Nuevo" OnClick="NuevoButton_Click" ValidationGroup="Nuevo" />&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
                   
                <asp:Button ID="GuardarButton" runat="server" class="btn btn-success" Text="Guardar" OnClick="GuardarButton_Click" ValidationGroup="Guardar" />&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
                   
                <asp:Button ID="EliminarButton" runat="server" class="btn btn-danger" Text="Eliminar" OnClick="EliminarButton_Click" />&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp

               
            </div>

        </div>
    </div>

</asp:Content>
