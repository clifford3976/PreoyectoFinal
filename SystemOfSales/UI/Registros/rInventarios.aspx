<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="rInventarios.aspx.cs" Inherits="SystemOfSales.UI.Registros.rInventarios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class=" panel panel-primary">
        <div class="panel-heading text-center">
            <h1><ins>Inventarios</ins></h1>
            <br />
        </div>
    </div>

    <div class="col-sm-12">

        <div class="Container-fluid">
            <div class="align-content-center">
            </div>
            <%--   InventarioId--%>
            <div>
                <table>
                    <tr>
                        <td>
                            <strong>
                                <asp:Label ID="ID" runat="server" Text="InventarioId: "></asp:Label></strong>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:TextBox ID="InventarioIdTextbox" runat="server" class="form-control" Height="30" Width="200" ValidationGroup="Buscar"></asp:TextBox>
                        </td>
                        <td>&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp<asp:Button ID="BuscarButton" ValidationGroup="Buscar" runat="server" class="btn btn-info" Text="Buscar" OnClick="BuscarButton_Click" />
                            <asp:RegularExpressionValidator ID="ValidaID" runat="server" ErrorMessage='solo acepta numeros' ControlToValidate="InventarioIdTextbox" ValidationExpression="^[0-9]*" Text="*" ForeColor="Red" Display="Dynamic" ToolTip="Entrada no valida" ValidationGroup="Guardar"></asp:RegularExpressionValidator>
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

        <%--  Ropa--%>
        <div>
            <table>
                <tr>
                    <td>
                        <strong>
                            <label for="RopaDropDownList">Ropa</label></strong>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:DropDownList ID="RopaDropDownList" class="form-control input-sm" runat="server">
                            <asp:ListItem Selected="True">[Seleccione]</asp:ListItem>
                        </asp:DropDownList>
                        <asp:CustomValidator ID="CVRopa" runat="server" ForeColor="Red" Display="Dynamic" ControlToValidate="RopaDropDownList" ValidationGroup="Guardar" ErrorMessage="Seleccione Una ropa" OnServerValidate="CVRopa_ServerValidate"></asp:CustomValidator>
                    </td>

                </tr>
            </table>
        </div>
    </div>

    <%--CantidadTextBox--%>
    <div>
        <table>
            <tr>
                <td>
                    <strong>
                        <asp:Label ID="Cantidad" runat="server" Text="Cantidad:"></asp:Label></strong>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="CantidadTextBox" runat="server" class="form-control" Height="30" Width="300" MaxLength="80"></asp:TextBox>
                </td>
                <td>
                    <asp:RegularExpressionValidator ID="ValidaMontoNUM" runat="server" ErrorMessage=' solo acepta numeros' ControlToValidate="CantidadTextBox" ValidationExpression="^[0.0-9.0]*" Text="*" ForeColor="Red" Display="Dynamic" ToolTip="Entrada no valida" ValidationGroup="Guardar"></asp:RegularExpressionValidator>
                    <asp:RequiredFieldValidator ID="Validacantidad" runat="server" ErrorMessage="El campo &quot;cantidad&quot; esta vacio" ControlToValidate="CantidadTextBox" ForeColor="Red" Display="Dynamic" ToolTip="Campo obligatorio" ValidationGroup="Guardar">*</asp:RequiredFieldValidator>

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
                   
                <asp:Button ID="GuardarButton" runat="server" class="btn btn-success" Text="Guardar" OnClick="GuardarButton_Click" />&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
                   
                <asp:Button ID="EliminarButton" runat="server" class="btn btn-danger" Text="Eliminar" OnClick="EliminarButton_Click" />&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp

               
        </div>

    </div>

</asp:Content>
