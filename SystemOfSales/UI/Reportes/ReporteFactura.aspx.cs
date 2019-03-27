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
    public partial class ReporteFactura : System.Web.UI.Page
    {
        
        Expression<Func<Facturas, bool>> filtro = C => true;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FacturaReportViewer.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Local;
                FacturaReportViewer.Reset();

                FacturaReportViewer.LocalReport.ReportPath = Server.MapPath(@"../Reportes/FacturaReporte.rdlc");

                FacturaReportViewer.LocalReport.DataSources.Clear();

                FacturaReportViewer.LocalReport.DataSources.Add(new ReportDataSource("Factura", FacturasBLL.GetList(filtro)));
                FacturaReportViewer.LocalReport.Refresh();
            }
        }
    }
}