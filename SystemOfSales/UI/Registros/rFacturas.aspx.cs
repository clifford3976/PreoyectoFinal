using BLL;
using Entitites;
using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SystemOfSales.Utilities;

namespace SystemOfSales.UI.Registros
{
    public partial class rFacturas : System.Web.UI.Page
    { 
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                FechaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
                LlenaCombo();
                ViewState["FacturaDetalle"] = new FacturasDetalles();

                LlenaReport();
            }


        }

        private void LlenaCombo()
        {

            Repositorio<Clientes> repositorio = new Repositorio<Clientes>();
            Repositorio<Ropas> repository = new Repositorio<Ropas>();



            ClienteDropDownList.DataSource = repositorio.GetList(t => true);
            ClienteDropDownList.DataValueField = "ClienteId";
            ClienteDropDownList.DataTextField = "Nombres";
            ClienteDropDownList.DataBind();

            RopaDropDownList.DataSource = repository.GetList(t => true);
            RopaDropDownList.DataValueField = "RopaId";
            RopaDropDownList.DataTextField = "Descripcion";
            RopaDropDownList.DataBind();
        }

        public void LlenaReport()
        {
            int id = Utils.ToInt(FacturaIdTextbox.Text);
            MyFacturasReportViewer.ProcessingMode = ProcessingMode.Local;
            MyFacturasReportViewer.Reset();
            MyFacturasReportViewer.LocalReport.ReportPath = Server.MapPath(@"~\Reportes\FacturaRecibo.rdlc");
            MyFacturasReportViewer.LocalReport.DataSources.Clear();
            MyFacturasReportViewer.LocalReport.DataSources.Add(new ReportDataSource("FacturaRecibo", BLL.Heramientas.FilFacturas(id)));
            MyFacturasReportViewer.LocalReport.Refresh();
        }

        public Facturas LlenarClase()
        {
            Facturas factura = new Facturas();

            factura.FacturaId = Utils.ToInt(FacturaIdTextbox.Text);
            factura.Fecha = Convert.ToDateTime(FechaTextBox.Text).Date;
            factura.ClienteId = Utils.ToInt(ClienteDropDownList.SelectedValue);
            factura.Itbis = Utils.ToDouble(itbisTextBox.Text);
            factura.SubTotal = Utils.ToDouble(subtotalTextBox.Text);
            factura.Total = Utils.ToInt(totalTextBox.Text);

            factura.Detalles = (List<FacturasDetalles>)ViewState["FacturaDetalle"];

            return factura;
        }

        public void LlenarCampos(Facturas factura)
        {
            FechaTextBox.Text = factura.Fecha.ToString("yyyy-MM-dd");
            ClienteDropDownList.SelectedValue = factura.ClienteId.ToString();
            detalleGridView.DataSource = Heramientas.ListaDetalle(Utils.ToInt(FacturaIdTextbox.Text));
            detalleGridView.DataBind();
            itbisTextBox.Text = factura.Itbis.ToString();
            subtotalTextBox.Text = factura.SubTotal.ToString();
            totalTextBox.Text = factura.Total.ToString();
        }

        protected void LimpiaObjetos()
        {
            FacturaIdTextbox.Text = "0";
            FechaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
            ClienteDropDownList.SelectedIndex = 0;
            cantidadTextBox.Text = "";
            precioTextBox.Text = "";
            importeTextBox.Text = "";
            itbisTextBox.Text = "";
            subtotalTextBox.Text = "";
            totalTextBox.Text = "";
            detalleGridView.DataSource = null;
            detalleGridView.DataBind();
        }

        private bool HayErrores()
        {
            bool HayErrores = false;

            if (detalleGridView.Rows.Count == 0)
            {
                Utils.ShowToastr(this, "Debe agregar.", "Error", "error");
                HayErrores = true;
            }
            if (Utils.ToIntObjetos(ClienteDropDownList.SelectedValue) < 1)
            {
                Utils.ShowToastr(this, "Todavía no hay cliente guardado.", "Error", "error");
                HayErrores = true;
            }
            if (Utils.ToIntObjetos(RopaDropDownList.SelectedValue) < 1)
            {
                Utils.ShowToastr(this, "Todavía no hay una ropa guardado.", "Error", "error");
                HayErrores = true;
            }
            return HayErrores;
        }

        private void LlenaPrecio()
        {
            int id = Utils.ToInt(RopaDropDownList.SelectedValue);
            Repositorio<Ropas> repositorio = new Repositorio<Ropas>();
            List<Ropas> ListRopas = repositorio.GetList(c => c.RopaId == id);
            foreach (var item in ListRopas)
            {
                precioTextBox.Text = item.Precio.ToString();
            }
        }

        private void LlenaImporte()
        {
            int cantidad, precio;

            cantidad = Utils.ToInt(cantidadTextBox.Text);
            precio = Utils.ToInt(precioTextBox.Text);
            importeTextBox.Text = Heramientas.Importe(cantidad, precio).ToString();
        }

        private void LlenaValores()
        {
            FacturasBLL repositorio = new FacturasBLL();
            int total = 0;
            List<FacturasDetalles> lista = (List<FacturasDetalles>)ViewState["FacturaDetalle"];
            foreach (var item in lista)
            {
                total += item.Importe;
            }

            double Itbis = 0;
            double SubTotal = 0;
            Itbis = total * 0.18f;
            SubTotal = total - Itbis;
            subtotalTextBox.Text = SubTotal.ToString();
            itbisTextBox.Text = Itbis.ToString();
            totalTextBox.Text = total.ToString();
        }
        

        private void RebajaValores()
        {
            FacturasBLL repositorio = new FacturasBLL();
            int total = 0;
            List<FacturasDetalles> lista = (List<FacturasDetalles>)ViewState["FacturaDetalle"];
            foreach (var item in lista)
            {
                total += item.Importe;
            }
            total *= (-1);
            double Itbis = 0;
            double SubTotal = 0;
            Itbis = total * 0.18f;
            SubTotal = total - Itbis;
            subtotalTextBox.Text = SubTotal.ToString();
            itbisTextBox.Text = Itbis.ToString();
            totalTextBox.Text = total.ToString();
        }

        protected void agregarLinkButton_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                List<FacturasDetalles> listDetalle = new List<FacturasDetalles>();

                Facturas facturas = new Facturas();


                DateTime date = DateTime.Now.Date;
                int cantidad = Utils.ToInt(cantidadTextBox.Text);
                int precio = Utils.ToInt(precioTextBox.Text);
                int importe = Utils.ToInt(importeTextBox.Text);

                
                int ropaId = Utils.ToIntObjetos(RopaDropDownList.SelectedValue);
                string descripcion = Heramientas.Descripcion(ropaId);

                if (detalleGridView.Rows.Count != 0)
                {
                    facturas.Detalles = (List<FacturasDetalles>)ViewState["FacturaDetalle"];
                }
              
                totalTextBox.Text = importe.ToString();

                facturas.Detalles.Add(new FacturasDetalles(0, Utils.ToInt(FacturaIdTextbox.Text), ropaId, descripcion, cantidad, precio, importe));

                LlenaPrecio();
                LlenaImporte();

                ViewState["FacturaDetalle"] = facturas.Detalles;
                detalleGridView.DataSource = ViewState["FacturaDetalle"];
                detalleGridView.DataBind();

            }
        }

        protected void RemoverButton_Click(object sender, EventArgs e)
        {
            RebajaValores();
            detalleGridView.DataSource = null;
            detalleGridView.DataBind();
        }

        protected void cantidadTextBox_TextChanged(object sender, EventArgs e)
        {
            LlenaPrecio();
            LlenaImporte();
        }

        protected void NuevoButton_Click(object sender, EventArgs e)
        {
            LimpiaObjetos();
        }

        protected void GuardarButton_Click(object sender, EventArgs e)
        {
            bool paso = false;
            FacturaRepositorio repositorio = new FacturaRepositorio();
            Facturas factura = new Facturas();

            if (HayErrores())
            {
                return;
            }
            else
            {
                factura = LlenarClase();

                if (Utils.ToInt(FacturaIdTextbox.Text) == 0)
                {
                    paso = repositorio.Guardar(factura);
                    Utils.ShowToastr(this, "Guardado", "Exito", "success");
                    LimpiaObjetos();
                }
                else
                {
                    FacturaRepositorio repository = new FacturaRepositorio();
                    int id = Utils.ToInt(FacturaIdTextbox.Text);
                    factura = repository.Buscar(id);

                    if (factura != null)
                    {
                        paso = repository.Modificar(LlenarClase());
                        Utils.ShowToastr(this, "Modificado", "Exito", "success");
                    }
                    else
                        Utils.ShowToastr(this, "Id no existe", "Error", "error");
                }

                if (paso)
                {
                    LimpiaObjetos();
                }
                else
                    Utils.ShowToastr(this, "No se pudo guardar", "Error", "error");
            }
        }

        protected void EliminarButton_Click(object sender, EventArgs e)
        {
            FacturaRepositorio repositorio = new FacturaRepositorio();
            int id = Utils.ToInt(FacturaIdTextbox.Text);

            var factura = repositorio.Buscar(id);

            if (factura != null)
            {
                if (repositorio.Eliminar(id))
                {
                    Utils.ShowToastr(this, "Eliminado", "Exito", "success");
                    LimpiaObjetos();
                }
                else
                    Utils.ShowToastr(this, "No se pudo eliminar", "Error", "error");
            }
            else
                Utils.ShowToastr(this, "No existe", "Error", "error");
        }

        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            FacturaRepositorio repositorio = new FacturaRepositorio();

            var factura = repositorio.Buscar(Utils.ToInt(FacturaIdTextbox.Text));
            if (factura != null)
            {
                LlenarCampos(factura);
                Utils.ShowToastr(this, "Busqueda exitosa", "Exito", "success");
            }
            else
            {
                LimpiaObjetos();
                Utils.ShowToastr(this, "No se pudo encontrar la factura especificada", "Error", "error");
            }
        }

        protected void detalleGridView_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
           
        }

        protected void detalleGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            detalleGridView.DataSource = ViewState["FacturaDetalle"];
            detalleGridView.PageIndex = e.NewPageIndex;
            detalleGridView.DataBind();
        }

        protected void CVClientes_ServerValidate(object source, ServerValidateEventArgs args)
        {

        }

        protected void CVRopa_ServerValidate(object source, ServerValidateEventArgs args)
        {

        }

        protected void RopaDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void RopaDropDownList_TextChanged(object sender, EventArgs e)
        {

        }

        protected void importeTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        protected void detalleGridView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void RemoverButton_Click1(object sender, EventArgs e)
        {

        }

        protected void Remover_Click(object sender, EventArgs e)
        {
           
        }

        protected void Eliminar_Click(object sender, EventArgs e)
        {
            GridViewRow row = detalleGridView.SelectedRow;
            ((List<FacturasDetalles>)detalleGridView.DataSource).RemoveAt(row.RowIndex);
            detalleGridView.DataSource = ViewState["FacturaDetalle"];
            detalleGridView.DataBind();

            List<FacturasDetalles> detalle = new List<FacturasDetalles>();

            if (detalleGridView.DataSource != null)
            {
                detalle = (List<FacturasDetalles>)detalleGridView.DataSource;
            }
            decimal Total = 0;
            foreach (var item in detalle)
            {
                Total -= item.Precio;
            }
            RebajaValores();
            detalleGridView.DataSource = null;
            detalleGridView.DataBind();
        }
    }

}