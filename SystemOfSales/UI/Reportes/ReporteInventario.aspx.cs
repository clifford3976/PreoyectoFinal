using BLL;
using Entitites;
using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SystemOfSales.UI.Reportes
{
    public partial class ReporteInventario : System.Web.UI.Page
    {
        Repositorio<Inventarios> repositorio = new Repositorio<Inventarios>();
        Expression<Func<Inventarios, bool>> filtro = C => true;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                InventarioReportViewer.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Local;
                InventarioReportViewer.Reset();

                InventarioReportViewer.LocalReport.ReportPath = Server.MapPath(@"../Reportes/InventarioReporte.rdlc");

                InventarioReportViewer.LocalReport.DataSources.Clear();

                InventarioReportViewer.LocalReport.DataSources.Add(new ReportDataSource("Inventario", repositorio.GetList(c => true)));
                InventarioReportViewer.LocalReport.Refresh();
            }
        }
    }
}