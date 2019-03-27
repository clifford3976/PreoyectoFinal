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
    public partial class cClientes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DesdeTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
            HastaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
        }

        protected void ButtonBuscar_Click1(object sender, EventArgs e)
        {
            ClienteGridView.DataBind();
            Expression<Func<Clientes, bool>> filtro = x => true;
            Repositorio<Clientes> repositorio = new Repositorio<Clientes>();

            int id;

            DateTime desde = Convert.ToDateTime(DesdeTextBox.Text);
            DateTime hasta = Convert.ToDateTime(HastaTextBox.Text);

            switch (TipodeFiltro.SelectedIndex)
            {
                case 0://ID

                    id = Utilities.Utils.ToInt(TextCriterio.Text);
                    if (FechaCheckBox.Checked == true)
                    {
                        filtro = x => x.ClienteId == id && (x.Fecha >= desde && x.Fecha <= hasta);
                    }
                    else
                    {
                        filtro = c => c.ClienteId == id;
                    }

                    if (repositorio.GetList(filtro).Count() == 0)
                    {
                        Utilities.Utils.MostrarMensaje(this, " cliente ID No Existe", "Fallido", "success");
                        return;
                    }

                    break;



                case 1:// Nombre

                    if (FechaCheckBox.Checked == true)
                    {
                        filtro = x => x.Nombres.Contains(TextCriterio.Text) && (x.Fecha >= desde && x.Fecha <= hasta);
                    }
                    else
                    {
                        filtro = c => c.Nombres.Contains(TextCriterio.Text);
                    }

                    if (repositorio.GetList(filtro).Count() == 0)
                    {
                        Utilities.Utils.MostrarMensaje(this, "Nombre no existe", "Fallido", "success");
                        return;
                    }

                    break;




                case 2:// Apellido

                    if (FechaCheckBox.Checked == true)
                    {
                        filtro = x => x.Apellidos.Contains(TextCriterio.Text) && (x.Fecha >= desde && x.Fecha <= hasta);
                    }
                    else
                    {
                        filtro = c => c.Apellidos.Contains(TextCriterio.Text);
                    }

                    if (repositorio.GetList(filtro).Count() == 0)
                    {
                        Utilities.Utils.MostrarMensaje(this, "Nombre no existe", "Fallido", "success");
                        return;
                    }

                    break;




                case 3://Todos

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
                        Utilities.Utils.MostrarMensaje(this, "No existen Dichos clientes", "Fallido", "success");
                    }
                    break;

            }

            ClienteGridView.DataSource = repositorio.GetList(filtro);
            ClienteGridView.DataBind();
        }

        protected void ReporteButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Reportes/ReporteCliente.aspx");
        }
    }
}