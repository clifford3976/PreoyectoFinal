using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class CalculosBLL
    {
        public static Decimal CalcularImporte(Decimal cantidad, Decimal precio)
        {
            return cantidad * precio;
        }

        public static Decimal CalcularSubTotal(Decimal importe)
        {
            return importe;
        }

        public static Decimal CalcularItbis(Decimal subtotal)
        {
            return subtotal * (decimal)0.18;
        }

        public static Decimal CalcularTotal(Decimal subtotal, Decimal itbis)
        {
            return subtotal + itbis;
        }

        public static Decimal CalcularDevuelta(Decimal efectivo, Decimal total)
        {
            return efectivo - total;
        }
    }
}
