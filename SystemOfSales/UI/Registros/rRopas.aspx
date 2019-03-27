<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="rRopas.aspx.cs" Inherits="SystemOfSales.UI.Registros.rRopas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class=" panel panel-primary">
        <div class="panel-heading text-center">
            <h1><ins>Ropa</ins></h1>
            <br />
        </div>
    </div>

    <div class="col-sm-12">

        <div class="Container-fluid">
            <div class="align-content-center">
            </div>
            <%--   RopaId--%>
            <div>
                <table>
                    <tr>
                        <td>
                            <strong>
                                <asp:Label ID="ID" runat="server" Text="RopaId: "></asp:Label></strong>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:TextBox ID="RopaIdTextbox" runat="server" class="form-control" Height="30" Width="200" ValidationGroup="Buscar"></asp:TextBox>
                        </td>
                        <td>&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp<asp:Button ID="BuscarButton" ValidationGroup="Buscar" runat="server" class="btn btn-info" Text="Buscar" OnClick="BuscarButton_Click" />
                            <asp:RegularExpressionValidator ID="ValidaID" runat="server" ErrorMessage='solo acepta numeros' ControlToValidate="RopaIdTextbox" ValidationExpression="^[0-9]*" Text="*" ForeColor="Red" Display="Dynamic" ToolTip="Entrada no valida" ValidationGroup="Guardar"></asp:RegularExpressionValidator>
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

        <%--DescripcionTextBox--%>
        <div>
            <table>
                <tr>
                    <td>
                        <strong>
                            <asp:Label ID="Descripcion" runat="server" Text="Descripcion:"></asp:Label></strong>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="DescripcionTextBox" runat="server" class="form-control" Height="30" Width="300" MaxLength="80"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RegularExpressionValidator ID="Valida" runat="server" ErrorMessage='solo acepta letras' ControlToValidate="DescripcionTextBox" ValidationExpression="(^[a-zA-Z'.\s]{1,20}$)" Text="*" ForeColor="Red" Display="Dynamic" ToolTip="Entrada no valida" ValidationGroup="Guardar"></asp:RegularExpressionValidator>
                        <asp:RequiredFieldValidator ID="ValidaDescripcion" runat="server" ErrorMessage="El campo &quot;Descripcion&quot; esta vacio" ControlToValidate="DescripcionTextBox" ForeColor="Red" Display="Dynamic" ToolTip="Campo  es obligatorio" ValidationGroup="Guardar">*</asp:RequiredFieldValidator>

                    </td>
                </tr>
            </table>
        </div>
        <br />

        <%--SizeTextBox--%>
        <div>
            <table>
                <tr>
                    <td>
                        <strong>
                            <asp:Label ID="Size" runat="server" Text="Size:"></asp:Label></strong>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="SizeTextBox" runat="server" class="form-control" Height="30" Width="300" MaxLength="80"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage='solo acepta letras' ControlToValidate="SizeTextBox" ValidationExpression="(^[a-zA-Z'.\s]{1,20}$)" Text="*" ForeColor="Red" Display="Dynamic" ToolTip="Entrada no valida" ValidationGroup="Guardar"></asp:RegularExpressionValidator>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="El campo &quot;Size&quot; esta vacio" ControlToValidate="SizeTextBox" ForeColor="Red" Display="Dynamic" ToolTip="Campo  es obligatorio" ValidationGroup="Guardar">*</asp:RequiredFieldValidator>

                    </td>
                </tr>
            </table>
        </div>
        <br />
        <%--MarcaTextBox--%>
        <div>
            <table>
                <tr>
                    <td>
                        <strong>
                            <asp:Label ID="Marca" runat="server" Text="Marca:"></asp:Label></strong>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="MarcaTextBox" runat="server" class="form-control" Height="30" Width="300" MaxLength="80"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage='solo acepta letras' ControlToValidate="MarcaTextBox" ValidationExpression="(^[a-zA-Z'.\s]{1,20}$)" Text="*" ForeColor="Red" Display="Dynamic" ToolTip="Entrada no valida" ValidationGroup="Guardar"></asp:RegularExpressionValidator>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="El campo &quot;Marca&quot; esta vacio" ControlToValidate="MarcaTextBox" ForeColor="Red" Display="Dynamic" ToolTip="Campo  es obligatorio" ValidationGroup="Guardar">*</asp:RequiredFieldValidator>

                    </td>
                </tr>
            </table>
        </div>
        <br />


        <%--PrecioTextBox--%>
        <div>
            <table>
                <tr>
                    <td>
                        <strong>
                            <asp:Label ID="Precio" runat="server" Text="Precio:"></asp:Label></strong>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="PrecioTextBox" runat="server" class="form-control" Height="30" Width="300" MaxLength="80"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="PrecioTextBox" ValidationGroup="Guardar" runat="server" ErrorMessage="*" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                        <asp:CustomValidator ID="PrecioCustomValidator" runat="server" ControlToValidate="PrecioTextBox" ValidationGroup="Guardar" ForeColor="Red" Display="Dynamic" ErrorMessage="solo numeros" OnServerValidate="PrecioCustomValidator_ServerValidate"></asp:CustomValidator>

                    </td>
                </tr>
            </table>
        </div>
        <br />

        <%--InventarioTextBox--%>
        <div>
            <table>
                <tr>
                    <td>
                        <strong>
                            <asp:Label ID="Inventario" runat="server" Text="Inventario:"></asp:Label></strong>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="InventarioTextBox" class="form-control input-sm" TextMode="Number" ReadOnly="true" runat="server" placeholder="0"></asp:TextBox>
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
