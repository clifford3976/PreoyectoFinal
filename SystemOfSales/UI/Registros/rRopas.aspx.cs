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
    public partial class rRopas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                FechaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");

                int id = Utils.ToInt(Request.QueryString["id"]);

                if (id > 0)
                {
                    Repositorio<Ropas> repositorio = new Repositorio<Ropas>();
                    var ropa = repositorio.Buscar(id);

                    if (ropa == null)
                        Utils.MostrarMensaje(this, "No Hay Resultado", "Error", "error");
                    else
                        LlenaCampos(ropa);
                }
            }
        }

        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            Repositorio<Ropas> repositorio = new Repositorio<Ropas>();
            Ropas ropa = repositorio.Buscar(Utils.ToInt(RopaIdTextbox.Text));
            if (IsValid)
            {
                if (ropa != null)
                {
                    Utils.MostrarMensaje(this, "Hay Resultado", "Exito!!", "info");
                    Limpiar();
                    LlenaCampos(ropa);
                }
                else
                {
                    Utils.MostrarMensaje(this, "No Hay Resultado", "Fallo!!", "error");
                    Limpiar();
                }
            }
        }

        private Ropas LlenaClase()
        {
            Ropas ropa = new Ropas();

            ropa.RopaId = Utils.ToInt(RopaIdTextbox.Text);
            ropa.FechaRegistro = Utils.ToDateTime(FechaTextBox.Text);
            ropa.Descripcion = DescripcionTextBox.Text;
            ropa.Size = SizeTextBox.Text;
            ropa.Marca = MarcaTextBox.Text;
            ropa.Precio = Utils.ToDecimal(PrecioTextBox.Text);
            ropa.Inventario = Utils.ToInt(InventarioTextBox.Text);

            return ropa;
        }

        private void LlenaCampos(Ropas ropa)
        {
            RopaIdTextbox.Text = ropa.RopaId.ToString();
            FechaTextBox.Text = ropa.FechaRegistro.ToString("yyyy-MM-dd");
            DescripcionTextBox.Text = ropa.Descripcion;
            SizeTextBox.Text = ropa.Size;
            MarcaTextBox.Text = ropa.Marca;
            PrecioTextBox.Text = ropa.Precio.ToString();
            InventarioTextBox.Text = ropa.Inventario.ToString();
        }

        private void Limpiar()
        {
            RopaIdTextbox.Text = "";
            FechaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
            DescripcionTextBox.Text = "";
            SizeTextBox.Text = "";
            MarcaTextBox.Text = " ";
            PrecioTextBox.Text = "";
            InventarioTextBox.Text = "";

        }

        protected void NuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        protected void GuardarButton_Click(object sender, EventArgs e)
        {
            Repositorio<Ropas> repositorio = new Repositorio<Ropas>();
            Ropas ropa = repositorio.Buscar(Utils.ToInt(RopaIdTextbox.Text));

            if (IsValid)
            {
                if (ropa == null)
                {
                    if (repositorio.Guardar(LlenaClase()))
                    {
                        Utils.MostrarMensaje(this, "Guardado", "Exito!!", "success");
                        Limpiar();
                    }
                    else
                    {
                        Utils.MostrarMensaje(this, "No Guardado", "Fallo!!", "warning");
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
                        Utils.MostrarMensaje(this, "No Modificado", "Fallo!!", "warning");
                        Limpiar();
                    }

                }
            }
        }

        protected void EliminarButton_Click(object sender, EventArgs e)
        {
            Repositorio<Ropas> repositorio = new Repositorio<Ropas>();
            Ropas ropa = repositorio.Buscar(Utils.ToInt(RopaIdTextbox.Text));
            if (IsValid)
            {
                if (ropa != null)
                {
                    repositorio.Eliminar(ropa.RopaId);
                    Utils.MostrarMensaje(this, "Eliminado", "Exito!!", "success");
                    Limpiar();
                }
                else
                {
                    Utils.MostrarMensaje(this, "No Eliminado", "Fallo!!", "warning");
                    Limpiar();
                }
            }
        }

        protected void PrecioCustomValidator_ServerValidate(object source, ServerValidateEventArgs args)
        {

        }
    }
}