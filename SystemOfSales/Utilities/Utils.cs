using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace SystemOfSales.Utilities
{
    public static class Utils
    {
        public static int ToInt(string valor)
        {
            int retorno = 0;
            int.TryParse(valor, out retorno);

            return retorno;
        }

        public static int ToIntObjetos(object valor)
        {
            int retorno = 0;
            int.TryParse(valor.ToString(), out retorno);

            return retorno;
        }

        public static double ToDouble(string valor)
        {
            double retorno = 0;
            double.TryParse(valor, out retorno);

            return retorno;
        }

        public static double ToDoubleObjetos(object valor)
        {
            double retorno = 0;
            double.TryParse(valor.ToString(), out retorno);

            return Convert.ToDouble(retorno);
        }

        public static decimal ToDecimal(string valor)
        {
            decimal retorno = 0;
            decimal.TryParse(valor, out retorno);

            return retorno;
        }

        public static DateTime ToDateTime(string valor)
        {
            DateTime retorno = DateTime.Now;
            DateTime.TryParse(valor, out retorno);

            return retorno;
        }

        public static void ShowToastr(this Page page, string message, string title, string type = "info")
        {
            page.ClientScript.RegisterStartupScript(page.GetType(), "toastr_message",
                  String.Format("toastr.{0}('{1}', '{2}');", type.ToLower(), message, title), addScriptTags: true);
        }

        public static void MostrarMensaje(this Page page, string message, string title, string type = "info")
        {
            page.ClientScript.RegisterStartupScript(page.GetType(), "toastr_message",
                 String.Format("toastr.{0}('{1}', '{2}');", type.ToLower(), message, title), addScriptTags: true);
        }
    }
}