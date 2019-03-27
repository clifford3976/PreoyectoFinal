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
    public partial class cRopas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DesdeTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
            HastaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
        }

        protected void ButtonBuscar_Click1(object sender, EventArgs e)
        {
            RopaGridView.DataBind();
            Expression<Func<Ropas, bool>> filtro = x => true;
            Repositorio<Ropas> repositorio = new Repositorio<Ropas>();

            int id;

            DateTime desde = Convert.ToDateTime(DesdeTextBox.Text);
            DateTime hasta = Convert.ToDateTime(HastaTextBox.Text);

            switch (TipodeFiltro.SelectedIndex)
            {
                case 0://ID

                    id = Utilities.Utils.ToInt(TextCriterio.Text);
                    if (FechaCheckBox.Checked == true)
                    {
                        filtro = x => x.RopaId == id && (x.FechaRegistro >= desde && x.FechaRegistro <= hasta);
                    }
                    else
                    {
                        filtro = c => c.RopaId == id;
                    }

                    if (repositorio.GetList(filtro).Count() == 0)
                    {
                        Utilities.Utils.MostrarMensaje(this, " ropa ID No Existe", "Fallido", "success");
                        return;
                    }

                    break;



                case 1:// Descripcion

                    if (FechaCheckBox.Checked == true)
                    {
                        filtro = x => x.Descripcion.Contains(TextCriterio.Text) && (x.FechaRegistro >= desde && x.FechaRegistro <= hasta);
                    }
                    else
                    {
                        filtro = c => c.Descripcion.Contains(TextCriterio.Text);
                    }

                    if (repositorio.GetList(filtro).Count() == 0)
                    {
                        Utilities.Utils.MostrarMensaje(this, "Descripcion no existe", "Fallido", "success");
                        return;
                    }

                    break;




                    case 2:// Precio
                    decimal precio = Utilities.Utils.ToDecimal(TextCriterio.Text);
                    if (FechaCheckBox.Checked == true)
                    {
                        filtro = x => x.Precio == precio && (x.FechaRegistro >= desde && x.FechaRegistro <= hasta);
                    }
                    else
                    {
                        filtro = c => c.Precio == precio;
                    }

                    if (repositorio.GetList(filtro).Count() == 0)
                    {
                        Utilities.Utils.MostrarMensaje(this, "precio incorecto", "Fallido", "success");
                    }

                    break;





                case 3://Todos

                    if (FechaCheckBox.Checked == true)
                    {
                        filtro = x => true && (x.FechaRegistro >= desde && x.FechaRegistro <= hasta);
                    }
                    else
                    {
                        filtro = x => true;
                    }

                    if (repositorio.GetList(filtro).Count() == 0)
                    {
                        Utilities.Utils.MostrarMensaje(this, "No existen Dichos rpas", "Fallido", "success");
                    }
                    break;

            }

            RopaGridView.DataSource = repositorio.GetList(filtro);
            RopaGridView.DataBind();
        }

        protected void ReporteButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Reportes/ReporteRopa.aspx");
        }
    }
}