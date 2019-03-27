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
    public partial class rUsuarios : System.Web.UI.Page
    {
        string condicion = "Seleccione";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LlenarDropDown();
                FechaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
                int id = Utils.ToInt(Request.QueryString["id"]);

                if (id > 0)
                {
                    Repositorio<Usuarios> repositorio = new Repositorio<Usuarios>();
                    var usuario = repositorio.Buscar(id);

                    if (usuario == null)
                        Utils.MostrarMensaje(this, "No Hay Resultado", "Error", "error");
                    else
                        LlenaCampos(usuario);
                }
            }
        }

        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            Repositorio<Usuarios> repositorio = new Repositorio<Usuarios>();
            Usuarios usuarios = repositorio.Buscar(Utils.ToInt(UsuarioIdTextbox.Text));

            if (IsValid)
            {
                if (usuarios != null)
                {
                    Limpiar();
                    LlenaCampos(usuarios);
                }
                else
                {
                    Limpiar();
                    Utils.MostrarMensaje(this, "No Hay Resultado", "Error", "error");
                }
            }
        }

        private void LlenarDropDown()
        {


            TipoUsuarioDropDownList.DataSource = Enum.GetValues(typeof(TipoUsuario));
            TipoUsuarioDropDownList.AppendDataBoundItems = true;
            TipoUsuarioDropDownList.DataBind();

        }

        private Usuarios LLenaClase()
        {
            Usuarios usuario = new Usuarios();
            usuario.UsuarioId = Utils.ToInt(UsuarioIdTextbox.Text);
            usuario.Fecha = Utils.ToDateTime(FechaTextBox.Text);
            usuario.Email = EmailTextBox.Text;
            usuario.NombreUsuario = NombreTextBox.Text;
            usuario.Contrasena = ContrasenaTextBox.Text;
            usuario.TipoUsuario = TipoUsuarioDropDownList.Text;

            return usuario;
        }

        private void LlenaCampos(Usuarios usuario)
        {
            UsuarioIdTextbox.Text = usuario.UsuarioId.ToString();
            FechaTextBox.Text = usuario.Fecha.ToString();
            EmailTextBox.Text = usuario.Email; ;
            NombreTextBox.Text = usuario.NombreUsuario;
            TipoUsuarioDropDownList.Text = usuario.TipoUsuario;
            ContrasenaTextBox.Text = usuario.Contrasena;

        }

        private void Limpiar()
        {
            UsuarioIdTextbox.Text = "";
            FechaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
            EmailTextBox.Text = "";
            NombreTextBox.Text = "";
            ContrasenaTextBox.Text = "";
            ConfirmarTextBox.Text = "";
            TipoUsuarioDropDownList.SelectedIndex = 0;
        }

       

        protected void NuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        protected void GuardarButton_Click(object sender, EventArgs e)
        {
            Repositorio<Usuarios> repositorio = new Repositorio<Usuarios>();
            Usuarios usuarios = repositorio.Buscar(Utils.ToInt(UsuarioIdTextbox.Text));

            if (IsValid)
            {
                if (usuarios != null)
                {
                    if (repositorio.Modificar(LLenaClase()))
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
                else
                {
                    if (repositorio.Guardar(LLenaClase()))
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
            }
        }

        protected void EliminarButton_Click(object sender, EventArgs e)
        {
            Repositorio<Usuarios> repositorio = new Repositorio<Usuarios>();
            Usuarios usuarios = repositorio.Buscar(Utils.ToInt(UsuarioIdTextbox.Text));

            if (IsValid)
            {
                if (usuarios == null)
                {
                    Utils.MostrarMensaje(this, "No Eliminado", "Error", "error");
                    Limpiar();
                }
                else
                {
                    repositorio.Eliminar(usuarios.UsuarioId);
                    Utils.MostrarMensaje(this, "Eliminado", "Exito!!", "success");
                    Limpiar();
                }
            }
        }

        protected void CustomValidator_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (ConfirmarTextBox.Text != ContrasenaTextBox.Text)
            {
                args.IsValid = false;
            }
            else
            {
                args.IsValid = true;
            }
        }


        protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (args.Value.Equals(condicion))
                args.IsValid = false;
            else
                args.IsValid = true;
        }
    }
}