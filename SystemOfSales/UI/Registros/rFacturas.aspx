<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="rFacturas.aspx.cs" Inherits="SystemOfSales.UI.Registros.rFacturas" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class=" panel panel-primary">
        <div class="panel-heading text-center">
            <h1><ins>Facturas</ins></h1>
            <br />
        </div>
    </div>

    <div class="col-sm-12">

        <div class="Container-fluid">
            <div class="align-content-center">
            </div>
            <%--   FacturaId--%>
            <div>
                <table>
                    <tr>
                        <td>
                            <strong>
                                <asp:Label ID="ID" runat="server" Text="facturaId: "></asp:Label></strong>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:TextBox ID="FacturaIdTextbox" runat="server" class="form-control" Height="30" Width="200" ValidationGroup="Buscar"></asp:TextBox>
                        </td>
                        <td>&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp<asp:Button ID="BuscarButton" ValidationGroup="Buscar" runat="server" class="btn btn-info" Text="Buscar" OnClick="BuscarButton_Click" />
                            <asp:RegularExpressionValidator ID="ValidaID" runat="server" ErrorMessage='solo acepta numeros' ControlToValidate="FacturaIdTextbox" ValidationExpression="^[0-9]*" Text="*" ForeColor="Red" Display="Dynamic" ToolTip="Entrada no valida" ValidationGroup="Guardar"></asp:RegularExpressionValidator>
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
                            <asp:TextBox ID="FechaTextBox" ValidationGroup="Guardar" runat="server" class="form-control" type="date" Height="30" Width="200" MaxLength="10"></asp:TextBox>
                            <asp:RequiredFieldValidator ValidationGroup="Guardar" ID="RequiredFieldValidator1" CssClass="ErrorMessage" ControlToValidate="FechaTextBox" runat="server" ErrorMessage="Seleccione una Fecha"></asp:RequiredFieldValidator>
                        </td>

                    </tr>
                </table>
            </div>
        </div>


    </div>
    <div class="form-inline">
        <%--  Cliente--%>
        <div>
            <table>
                <tr>
                    <td>
                        <strong>
                            <asp:Label ID="Label7" runat="server" Text="Cliente"></asp:Label></strong>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:DropDownList ID="ClienteDropDownList" AutoPostBack="true" class="form-control input-sm" runat="server">
                            <asp:ListItem Selected="True">[Seleccione]</asp:ListItem>
                        </asp:DropDownList>
                        <asp:CustomValidator ID="CVClientes" runat="server" ErrorMessage="Seleccione Un Cliente" ControlToValidate="ClienteDropDownList" ValidationGroup="Guardar" ForeColor="Red" Display="Dynamic" OnServerValidate="CVClientes_ServerValidate"></asp:CustomValidator>
                    </td>

                </tr>
            </table>
        </div>

        <div class="align-content-center">
            <%--  Ropa--%>
            <div>
                <table>
                    <tr>
                        <td>
                            <strong>
                                <asp:Label ID="Label1" runat="server" Text="Ropa"></asp:Label></strong>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:DropDownList ID="RopaDropDownList" class="form-control input-sm" runat="server" AppendDataBoundItems="true" AutoPostBack="true" OnSelectedIndexChanged="RopaDropDownList_SelectedIndexChanged" OnTextChanged="RopaDropDownList_TextChanged">
                                <asp:ListItem Selected="True">[Seleccione]</asp:ListItem>
                            </asp:DropDownList>
                            <asp:CustomValidator ID="CVRopa" runat="server" ErrorMessage="Seleccione Una ropa" ControlToValidate="RopaDropDownList" ValidationGroup="Agregar" ForeColor="Red" Display="Dynamic" OnServerValidate="CVRopa_ServerValidate"></asp:CustomValidator>
                        </td>

                    </tr>
                </table>
            </div>
        </div>
        <%--  Cantidad--%>

        <div>
            <table>
                <tr>
                    <td>
                        <strong>
                            <asp:Label ID="Label2" runat="server" Text="Cantidad: "></asp:Label></strong>
                    </td>
                </tr>
                <tr>
                    <td>

                        <asp:TextBox TextMode="Number" class="form-control" Height="30" Width="200px" ID="cantidadTextBox" runat="server" OnTextChanged="cantidadTextBox_TextChanged2" AutoPostBack="true"></asp:TextBox>
                    </td>

                </tr>
            </table>
        </div>

        <%--  Precio--%>

        <div>
            <table>
                <tr>
                    <td>
                        <strong>
                            <asp:Label ID="Label3" runat="server" Text="Precio: "></asp:Label></strong>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox class="form-control" Height="30" Width="200px" ID="precioTextBox" runat="server" AutoPostBack="true" ReadOnly="true"></asp:TextBox>
                    </td>

                </tr>
            </table>
        </div>
        <%--  Importe--%>

        <div>
            <table>
                <tr>
                    <td>
                        <strong>
                            <asp:Label ID="Label4" runat="server"  Text="Importe: "></asp:Label></strong>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox  class="form-control" Height="30" Width="200px" ID="importeTextBox" runat="server" AutoPostBack="true" ReadOnly="false" OnTextChanged="importeTextBox_TextChanged"></asp:TextBox>
                    </td>

                </tr>
            </table>
        </div>

    </div>



    <div class="col-lg-1 p-0">
        <asp:LinkButton ID="agregarLinkButton" CssClass="btn btn-blue mt-4" runat="server" OnClick="agregarLinkButton_Click">
                                <span class="fas fa-search"></span>AGREGAR
        </asp:LinkButton>
    </div>




    <div class="col-md-12 col-md-offset-3">
        <div class="container">
            <div class="form-group">
                <div class="form-row justify-content-center">
                    <asp:GridView ID="detalleGridView" runat="server" class="table table-condensed table-bordered table-responsive" AutoGenerateColumns="False" CellPadding="4" ForeColor="Black" GridLines="None" BackColor="White" OnSelectedIndexChanged="detalleGridView_SelectedIndexChanged" OnSelectedIndexChanging="detalleGridView_SelectedIndexChanging" OnPageIndexChanging="detalleGridView_PageIndexChanging">
                        <AlternatingRowStyle BackColor="#999999" />
                        <Columns>
                            <asp:TemplateField ShowHeader="False">
                                <ItemTemplate>
                                    <asp:Button ID="Remover" class="btn btn-success btn-sm" runat="server" CausesValidation="False" CommandName="Delete" Text="Remover" OnClick="Remover_Click"></asp:Button>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" />
                            <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" />
                            <asp:BoundField DataField="Precio" HeaderText="Precio" />
                            <asp:BoundField DataField="Importe" HeaderText="Importe" />
                        </Columns>
                        <HeaderStyle BackColor="#999999" Font-Bold="True" />
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>
    <div class="form-inline">
        <%--  ITBIS--%>

        <div>
            <table>
                <tr>
                    <td>
                        <strong>
                            <asp:Label ID="Label5" runat="server" Text="ITBIS: "></asp:Label></strong>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox class="form-control" ID="itbisTextBox" Text="0" ReadOnly="true" AutoPostBack="true" runat="server" Width="150px"></asp:TextBox>
                    </td>

                </tr>
            </table>
        </div>

        <%--  Subtotal--%>

        <div>
            <table>
                <tr>
                    <td>
                        <strong>
                            <asp:Label ID="Label6" runat="server" Text="SubTotal: "></asp:Label></strong>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox class="form-control" ID="subtotalTextBox" Text="0" runat="server" ReadOnly="true" AutoPostBack="true" Width="150px"></asp:TextBox>
                    </td>

                </tr>
            </table>
        </div>

        <%--  Total--%>

        <div>
            <table>
                <tr>
                    <td>
                        <strong>
                            <asp:Label ID="Label9" runat="server" Text="Total: "></asp:Label></strong>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox class="form-control" ID="totalTextBox" Text="0" runat="server" ReadOnly="true" AutoPostBack="true" Width="150px"></asp:TextBox>
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
                   
                <asp:Button ID="GuardarButton" runat="server" class="btn btn-success" Text="Guardar" OnClick="GuardarButton_Click" />&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
                   
                <asp:Button ID="EliminarButton" runat="server" class="btn btn-danger" Text="Eliminar" OnClick="EliminarButton_Click" />&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp

                <!-- Modal de factura.// -->
            <div class="modal fade bd-example-modal-lg" tabindex="-1" role="dialog" aria-labelledby="myLargeModalLabel" aria-hidden="true">
                <div class="modal-dialog modal-sm" style="max-width: 600px!important; min-width: 300px!important">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h5 class="modal-title" id="exampleModalLabel">Modal</h5>
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true">&times;</span>
                            </button>
                        </div>
                        <div class="modal-body">
                            <%--Viewer--%>
                            <rsweb:ReportViewer ID="MyFacturasReportViewer" runat="server" Width="500px" BackColor="" ClientIDMode="AutoID">
                                <ServerReport ReportPath="" ReportServerUrl="" />
                                <LocalReport ReportPath="UI\Reportes\FacturaRecibo.rdlc">
                                </LocalReport>
                            </rsweb:ReportViewer>

                        </div>
                        <div class="modal-footer">
                            <asp:Button ID="Eliminar" runat="server" CssClass="btn btn-danger" Text="Si" OnClick="Eliminar_Click" />
                            <button type="button" class="btn btn-secondary" data-dismiss="modal">No</button>
                        </div>
                    </div>
                </div>
            </div>
        </div>

    </div>
</asp:Content>
