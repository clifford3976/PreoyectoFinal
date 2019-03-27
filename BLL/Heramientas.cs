using Entitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;

namespace BLL
{
    public static class Heramientas
    {
        public static int ToInt(string valor)
        {
            int retorno = 0;
            int.TryParse(valor, out retorno);

            return retorno;
        }

        //Métodos que retornan la lista en el Imprimir de las Consultas (Reportes).
        public static List<Clientes> FClientes()
        {
            Expression<Func<Clientes, bool>> filtro = p => true;
            Repositorio<Clientes> repositorio = new Repositorio<Clientes>();
            List<Clientes> list = new List<Clientes>();

            list = repositorio.GetList(filtro);

            return list;
        }

       
        

        public static List<Inventarios> FInventarios()
        {
            Expression<Func<Inventarios, bool>> filtro = p => true;
            Repositorio<Inventarios> repositorio = new Repositorio<Inventarios>();
            List<Inventarios> list = new List<Inventarios>();

            list = repositorio.GetList(filtro);

            return list;
        }

        public static List<Facturas> FFacturas()
        {
            Expression<Func<Facturas, bool>> filtro = p => true;
            Repositorio<Facturas> repositorio = new Repositorio<Facturas>();
            List<Facturas> list = new List<Facturas>();

            list = repositorio.GetList(filtro);

            return list;
        }


        public static List<FacturasDetalles> FilFacturas(int id)
        {
            Expression<Func<FacturasDetalles, bool>> filtro = p => true;
            Repositorio<FacturasDetalles> repositorio = new Repositorio<FacturasDetalles>();
            List<FacturasDetalles> list = new List<FacturasDetalles>();

            list = repositorio.GetList(p => p.FacturaId == id);

            return list;
        }
        public static List<Ropas> FRopas()
        {
            Expression<Func<Ropas, bool>> filtro = p => true;
            Repositorio<Ropas> repositorio = new Repositorio<Ropas>();
            List<Ropas> list = new List<Ropas>();

            list = repositorio.GetList(filtro);

            return list;
        }

        public static List<Usuarios> FUsuarios()
        {
            Expression<Func<Usuarios, bool>> filtro = p => true;
            Repositorio<Usuarios> repositorio = new Repositorio<Usuarios>();
            List<Usuarios> list = new List<Usuarios>();

            list = repositorio.GetList(filtro);

            return list;
        }

        //Métodos que retornan la lista en el Buscar de las Consultas.

        public static List<Clientes> FiltrarClientes(int index, string criterio, DateTime desde, DateTime hasta)
        {
            Expression<Func<Clientes, bool>> filtro = p => true;
            Repositorio<Clientes> repositorio = new Repositorio<Clientes>();
            List<Clientes> list = new List<Clientes>();

            int id = ToInt(criterio);
            switch (index)
            {
                case 0://Todo
                    break;

                case 1://Todo por fecha
                    filtro = p => p.Fecha >= desde && p.Fecha <= hasta;
                    break;

                case 2://ClienteId
                    filtro = p => p.ClienteId == id && p.Fecha >= desde && p.Fecha <= hasta;
                    break;

                case 3://Nombre
                    filtro = p => p.Nombres.Contains(criterio) && p.Fecha >= desde && p.Fecha <= hasta;
                    break;
            }

            list = repositorio.GetList(filtro);

            return list;
        }

       

        public static List<Inventarios> FiltrarInventarios(int index, string criterio, DateTime desde, DateTime hasta)
        {
            Expression<Func<Inventarios, bool>> filtro = p => true;
            Repositorio<Inventarios> repositorio = new Repositorio<Inventarios>();
            List<Inventarios> list = new List<Inventarios>();

            int id = ToInt(criterio);
            switch (index)
            {
                case 0://Todo
                    break;

                case 1://Todo por fecha
                    filtro = p => p.Fecha >= desde && p.Fecha <= hasta;
                    break;

                case 2://EntradaId
                    filtro = p => p.InventarioId == id && p.Fecha >= desde && p.Fecha <= hasta;
                    break;

                case 3://ProductoId
                    filtro = p => p.RopaId == id && p.Fecha >= desde && p.Fecha <= hasta;
                    break;
            }

            list = repositorio.GetList(filtro);

            return list;
        }

        public static List<Facturas> FiltrarFacturas(int index, string criterio, DateTime desde, DateTime hasta)
        {
            Expression<Func<Facturas, bool>> filtro = p => true;
            Repositorio<Facturas> repositorio = new Repositorio<Facturas>();
            List<Facturas> list = new List<Facturas>();

            int id = ToInt(criterio);
            switch (index)
            {
                case 0://Todo
                    break;

                case 1://Todo por fecha
                    filtro = p => p.Fecha >= desde && p.Fecha <= hasta;
                    break;

                case 2://FacturaId
                    filtro = p => p.FacturaId == id && p.Fecha >= desde && p.Fecha <= hasta;
                    break;

                case 3://ClienteId
                    filtro = p => p.ClienteId == id && p.Fecha >= desde && p.Fecha <= hasta;
                    break;
            }

            list = repositorio.GetList(filtro);

            return list;
        }

       

        public static List<Ropas> FiltrarRopas(int index, string criterio, DateTime desde, DateTime hasta)
        {
            Expression<Func<Ropas, bool>> filtro = p => true;
            Repositorio<Ropas> repositorio = new Repositorio<Ropas>();
            List<Ropas> list = new List<Ropas>();

            int id = ToInt(criterio);
            switch (index)
            {
                case 0://Todo
                    break;

                case 1://Todo por fecha
                    filtro = p => p.FechaRegistro >= desde && p.FechaRegistro <= hasta;
                    break;

                case 2://ProductoId
                    filtro = p => p.RopaId == id && p.FechaRegistro >= desde && p.FechaRegistro <= hasta;
                    break;

                case 3://Descripcion
                    filtro = p => p.Descripcion.Contains(criterio) && p.FechaRegistro >= desde && p.FechaRegistro <= hasta;
                    break;
            }

            list = repositorio.GetList(filtro);

            return list;
        }

        public static List<Usuarios> FiltrarUsuarios(int index, string criterio, DateTime desde, DateTime hasta)
        {
            Expression<Func<Usuarios, bool>> filtro = p => true;
            Repositorio<Usuarios> repositorio = new Repositorio<Usuarios>();
            List<Usuarios> list = new List<Usuarios>();

            int id = ToInt(criterio);
            switch (index)
            {
                case 0://Todo
                    break;

                case 1://Todo por fecha
                    filtro = p => p.Fecha >= desde && p.Fecha <= hasta;
                    break;

                case 2://UsuarioId
                    filtro = p => p.UsuarioId == id && p.Fecha >= desde && p.Fecha <= hasta;
                    break;

                case 3://CuentaId
                    filtro = p => p.NombreUsuario.Contains(criterio) && p.Fecha >= desde && p.Fecha <= hasta;
                    break;
            }

            list = repositorio.GetList(filtro);

            return list;
        }

        public static double ToDouble(string valor)
        {
            double retorno = 0;
            double.TryParse(valor, out retorno);

            return retorno;
        }

       

        //Toastr.
        public static void ShowToastr(this Page page, string message, string title, string type = "info")
        {
            page.ClientScript.RegisterStartupScript(page.GetType(), "toastr_message",
                  String.Format("toastr.{0}('{1}', '{2}');", type.ToLower(), message, title), addScriptTags: true);
        }

        //Lista para el Detalle.
        public static string Descripcion(int IdLista)
        {
            Repositorio<Ropas> repositorio = new Repositorio<Ropas>();
            Ropas ropa = new Ropas();
            int id = IdLista;
            ropa = repositorio.Buscar(id);

            string desc = ropa.Descripcion;

            return desc;
        }

        //Lista para el Detalle.
        public static List<FacturasDetalles> ListaDetalle(int IdLista)
        {
            Repositorio<FacturasDetalles> repositorio = new Repositorio<FacturasDetalles>();
            List<FacturasDetalles> list = new List<FacturasDetalles>();
            int id = IdLista;
            list = repositorio.GetList(c => c.FacturaId == id);

            return list;
        }

        //Lista para el Importe del Detalle.
        public static int Importe(int cantidad, int precio)
        {
            int CalImporte = 0;
            CalImporte = cantidad * precio;

            return CalImporte;
        }
    }
}
