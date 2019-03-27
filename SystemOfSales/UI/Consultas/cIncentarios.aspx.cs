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
    public partial class cIncentarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DesdeTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
            HastaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
        }

        protected void ButtonBuscar_Click1(object sender, EventArgs e)
        {
            InventarioGridView.DataBind();
            Expression<Func<Inventarios, bool>> filtro = x => true;
            Repositorio<Inventarios> repositorio = new Repositorio<Inventarios>();

            int id;

            DateTime desde = Convert.ToDateTime(DesdeTextBox.Text);
            DateTime hasta = Convert.ToDateTime(HastaTextBox.Text);

            switch (TipodeFiltro.SelectedIndex)
            {
                case 0://ID

                    id = Utilities.Utils.ToInt(TextCriterio.Text);
                    if (FechaCheckBox.Checked == true)
                    {
                        filtro = x => x.InventarioId == id && (x.Fecha >= desde && x.Fecha <= hasta);
                    }
                    else
                    {
                        filtro = c => c.InventarioId == id;
                    }

                    if (repositorio.GetList(filtro).Count() == 0)
                    {
                        Utilities.Utils.MostrarMensaje(this, " inventario ID No Existe", "Fallido", "success");
                        return;
                    }

                    break;

                case 1:// ropaId
                    int ropaid = Utilities.Utils.ToInt(TextCriterio.Text);
                    if (FechaCheckBox.Checked == true)
                    {
                        filtro = x => x.RopaId == ropaid && (x.Fecha >= desde && x.Fecha <= hasta);
                    }
                    else
                    {
                        filtro = c => c.RopaId == ropaid;
                    }

                    if (repositorio.GetList(filtro).Count() == 0)
                    {
                        Utilities.Utils.MostrarMensaje(this, "ropa ID No Existe", "Fallido", "success");
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
                        Utilities.Utils.MostrarMensaje(this, "No existen Dichos inventarios", "Fallido", "success");
                    }
                    break;

            }

            InventarioGridView.DataSource = repositorio.GetList(filtro);
            InventarioGridView.DataBind();

        }

        protected void ReporteButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Reportes/ReporteInventario.aspx");
        }
    }
}