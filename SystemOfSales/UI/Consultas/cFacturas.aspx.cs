using BLL;
using Entitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SystemOfSales.UI.Consultas
{
    public partial class cFacturas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DesdeTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
            HastaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
        }

        protected void ButtonBuscar_Click1(object sender, EventArgs e)
        {
            FacturaGridView.DataBind();
            Repositorio<FacturasDetalles> repository = new Repositorio<FacturasDetalles>();
            Expression<Func<Facturas, bool>> filtro = x => true;
            Repositorio<Facturas> repositorio = new Repositorio<Facturas>();

            int id;

            DateTime desde = Convert.ToDateTime(DesdeTextBox.Text);
            DateTime hasta = Convert.ToDateTime(HastaTextBox.Text);

            switch (TipodeFiltro.SelectedIndex)
            {
                case 0://ID

                    id = Utilities.Utils.ToInt(TextCriterio.Text);
                    if (FechaCheckBox.Checked == true)
                    {
                        filtro = x => x.FacturaId == id && (x.Fecha >= desde && x.Fecha <= hasta);
                    }
                    else
                    {
                        filtro = c => c.FacturaId == id;
                    }

                    if (repositorio.GetList(filtro).Count() == 0)
                    {
                        Utilities.Utils.MostrarMensaje(this, " factura ID No Existe", "Fallido", "success");
                        return;
                    }

                    break;

                case 1:// clienteid
                    int clienteid = Utilities.Utils.ToInt(TextCriterio.Text);
                    if (FechaCheckBox.Checked == true)
                    {
                        filtro = x => x.ClienteId == clienteid && (x.Fecha >= desde && x.Fecha <= hasta);
                    }
                    else
                    {
                        filtro = c => c.ClienteId == clienteid;
                    }

                    if (repositorio.GetList(filtro).Count() == 0)
                    {
                        Utilities.Utils.MostrarMensaje(this, "cliete id ID No Existe", "Fallido", "success");
                    }

                    break;


                case 2://Todos

                    if (FechaCheckBox.Checked == true)
                    {
                        filtro = x => true && (x.Fecha >= desde && x.Fecha <= hasta);
                    }
                    else
                    {
                        filtro = x => true;
                    }

                    if (repositorio.GetList(filtro).Count() == 0)
                    {
                        Utilities.Utils.MostrarMensaje(this, "No existen Dichos facturas", "Fallido", "success");
                    }
                    break;

            }

            FacturaGridView.DataSource = repositorio.GetList(filtro);
            FacturaGridView.DataBind();
        }

        protected void ReporteButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Reportes/ReporteFactura.aspx");
        }
    }
    
}