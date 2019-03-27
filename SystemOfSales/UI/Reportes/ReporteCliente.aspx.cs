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
    public partial class ReporteCliente : System.Web.UI.Page
    {
        Repositorio<Clientes> repositorio = new Repositorio<Clientes>();
        Expression<Func<Clientes, bool>> filtro = C => true;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ClienteReportViewer.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Local;
                ClienteReportViewer.Reset();

                ClienteReportViewer.LocalReport.ReportPath = Server.MapPath(@"../Reportes/ClienteReporte.rdlc");

                ClienteReportViewer.LocalReport.DataSources.Clear();

                ClienteReportViewer.LocalReport.DataSources.Add(new ReportDataSource("Cliente", repositorio.GetList(c => true)));
                ClienteReportViewer.LocalReport.Refresh();
            }
        }
    }
}