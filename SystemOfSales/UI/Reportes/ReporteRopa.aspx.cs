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
    public partial class ReporteRopa : System.Web.UI.Page
    {
        Repositorio<Ropas> repositorio = new Repositorio<Ropas>();
        Expression<Func<Ropas, bool>> filtro = C => true;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                RopaReportViewer.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Local;
                RopaReportViewer.Reset();

                RopaReportViewer.LocalReport.ReportPath = Server.MapPath(@"../Reportes/RopaReporte.rdlc");

                RopaReportViewer.LocalReport.DataSources.Clear();

                RopaReportViewer.LocalReport.DataSources.Add(new ReportDataSource("Ropa", repositorio.GetList(c => true)));
                RopaReportViewer.LocalReport.Refresh();
            }
        }
    }
}