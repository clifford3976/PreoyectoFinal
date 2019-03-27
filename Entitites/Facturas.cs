using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entitites
{
    [Serializable]
    public class Facturas
    {
        [Key]
        public int FacturaId { get; set; }
        public DateTime Fecha { get; set; }
        public int ClienteId { get; set; }
        public double SubTotal { get; set; }
        public double Itbis { get; set; }
        public int Total { get; set; }


        public virtual List<FacturasDetalles> Detalles { get; set; }


        public Facturas()
        {
            FacturaId = 0;
            Fecha = DateTime.Now;
            ClienteId = 0;
            SubTotal = 0;
            Itbis = 0;
            Total = 0;
            this.Detalles = new List<FacturasDetalles>();
        }

        public void AgregarDetalle(int id, int facturaId, int ropaId,string descripcion, int cantidad, decimal precio, int importe)
        {
            this.Detalles.Add(new FacturasDetalles(id, facturaId, ropaId,descripcion, cantidad, precio, importe));
        }

    }
}
