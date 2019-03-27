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
    public partial class ReporteUsuario : System.Web.UI.Page
    {
        Repositorio<Usuarios> repositorio = new Repositorio<Usuarios>();
        Expression<Func<Usuarios, bool>> filtro = C => true;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                UsuarioReportViewer.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Local;
                UsuarioReportViewer.Reset();

                UsuarioReportViewer.LocalReport.ReportPath = Server.MapPath(@"../Reportes/UsuarioReporte.rdlc");

                UsuarioReportViewer.LocalReport.DataSources.Clear();

                UsuarioReportViewer.LocalReport.DataSources.Add(new ReportDataSource("Usuario", repositorio.GetList(c => true)));
                UsuarioReportViewer.LocalReport.Refresh();
            }
        }
    }
}