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
    public partial class cUsuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DesdeTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
            HastaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
        }

        protected void ButtonBuscar_Click1(object sender, EventArgs e)
        {
            UsuarioGridView.DataBind();
            Expression<Func<Usuarios, bool>> filtro = x => true;
            Repositorio<Usuarios> repositorio = new Repositorio<Usuarios>();

            int id;

            DateTime desde = Convert.ToDateTime(DesdeTextBox.Text);
            DateTime hasta = Convert.ToDateTime(HastaTextBox.Text);

            switch (TipodeFiltro.SelectedIndex)
            {
                case 0://ID

                    id = Utilities.Utils.ToInt(TextCriterio.Text);
                    if (FechaCheckBox.Checked == true)
                    {
                        filtro = x => x.UsuarioId == id && (x.Fecha >= desde && x.Fecha <= hasta);
                    }
                    else
                    {
                        filtro = c => c.UsuarioId == id;
                    }

                    if (repositorio.GetList(filtro).Count() == 0)
                    {
                        Utilities.Utils.MostrarMensaje(this, " usuario ID No Existe", "Fallido", "success");
                        return;
                    }

                    break;
                case 1:// NombreUsuario

                    if (FechaCheckBox.Checked == true)
                    {
                        filtro = x => x.NombreUsuario.Contains(TextCriterio.Text) && (x.Fecha >= desde && x.Fecha <= hasta);
                    }
                    else
                    {
                        filtro = c => c.NombreUsuario.Contains(TextCriterio.Text);
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
                        Utilities.Utils.MostrarMensaje(this, "No existen Dichos usuarios", "Fallido", "success");
                    }
                    break;

            }

            UsuarioGridView.DataSource = repositorio.GetList(filtro);
            UsuarioGridView.DataBind();
        }

        protected void ReporteButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Reportes/ReporteUsuario.aspx");
        }
    }
}