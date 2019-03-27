using BLL;
using Entitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SystemOfSales.Utilities;

namespace SystemOfSales.UI.Registros
{
    public partial class rInventarios : System.Web.UI.Page
    {
        string condicion = "[Seleccione]";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                FechaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
                int id = Utils.ToInt(Request.QueryString["id"]);
                LlenaDropDown();
                if (id > 0)
                {
                    InventarioRepositorio repositorio = new InventarioRepositorio();
                    var inventario = repositorio.Buscar(id);

                    if (inventario != null)
                        Utils.MostrarMensaje(this, "No Hay Resultado", "Error", "error");
                    else
                        LlenaCampos(inventario);
                }
            }
        }

        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            InventarioRepositorio repositorio = new InventarioRepositorio();
            Inventarios inventario = repositorio.Buscar(Utils.ToInt(InventarioIdTextbox.Text));

            if (IsValid)
            {
                if (inventario != null)
                {
                    Utils.MostrarMensaje(this, "Hay Resultado", "Exito!!", "info");
                    Limpiar();
                    LlenaCampos(inventario);
                }
                else
                {
                    Utils.MostrarMensaje(this, "No Hay Resultado", "Error", "error");
                    Limpiar();
                }
            }
        }

        protected void NuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        protected void GuardarButton_Click(object sender, EventArgs e)
        {
            InventarioRepositorio repositorio = new InventarioRepositorio();
            Inventarios inventario = repositorio.Buscar(Utils.ToInt(InventarioIdTextbox.Text));

            if (IsValid)
            {
                if (Utils.ToInt(InventarioIdTextbox.Text) == 0)
                {
                    if (repositorio.Guardar(LlenaClase()))
                    {
                        Utils.MostrarMensaje(this, "Guardado", "Exito!!", "success");
                        Limpiar();
                    }
                    else
                    {
                        Utils.MostrarMensaje(this, "No Guardado", "Error", "error");
                        Limpiar();
                    }
                }
                else
                {
                    if (repositorio.Modificar(LlenaClase()))
                    {
                        Utils.MostrarMensaje(this, "Modificado", "Exito!!", "info");
                        Limpiar();
                    }
                    else
                    {
                        Utils.MostrarMensaje(this, "No Modificado", "Error", "error");
                        Limpiar();
                    }

                }
            }
        }

        protected void EliminarButton_Click(object sender, EventArgs e)
        {
            InventarioRepositorio repositorio = new InventarioRepositorio();
            Inventarios inventario = repositorio.Buscar(Utils.ToInt(InventarioIdTextbox.Text));

            if (IsValid)
            {
                if (inventario != null)
                {
                    repositorio.Eliminar(inventario.InventarioId);
                    Utils.MostrarMensaje(this, "Eliminado", "Exito!!", "success");
                    Limpiar();
                }
                else
                {
                    Utils.MostrarMensaje(this, "No Eliminado", "Error", "error");
                    Limpiar();
                }
            }
        }

        private Inventarios LlenaClase()
        {
            Inventarios inventarios = new Inventarios();

            inventarios.InventarioId = Utils.ToInt(InventarioIdTextbox.Text);
            inventarios.Fecha = DateTime.Parse(FechaTextBox.Text);
            inventarios.RopaId = Utils.ToInt(RopaDropDownList.SelectedValue);
            inventarios.Descripcion = RopaDropDownList.Text;
            inventarios.Cantidad = Utils.ToInt(CantidadTextBox.Text);


            return inventarios;
        }

        private void LlenaCampos(Inventarios inventario)
        {
            InventarioIdTextbox.Text = inventario.InventarioId.ToString();
            FechaTextBox.Text = inventario.Fecha.ToShortDateString();
            RopaDropDownList.Text = inventario.RopaId.ToString();
            CantidadTextBox.Text = inventario.Cantidad.ToString();
        }

        private void LlenaDropDown()
        {
            Repositorio<Ropas> repositorio = new Repositorio<Ropas>();
            RopaDropDownList.DataSource = repositorio.GetList(p => true);
            RopaDropDownList.DataValueField = "RopaId";
            RopaDropDownList.DataTextField = "Descripcion";
            RopaDropDownList.AppendDataBoundItems = true;
            RopaDropDownList.DataBind();
        }

        private void Limpiar()
        {
            InventarioIdTextbox.Text = "";
            FechaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
            RopaDropDownList.SelectedIndex = 0;
            CantidadTextBox.Text = "";

        }

        protected void CVRopa_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (args.Value.Equals(condicion))
                args.IsValid = false;
            else
                args.IsValid = true;
        }
    }
}