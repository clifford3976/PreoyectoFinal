using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entitites
{
    [Serializable]
    public class FacturasDetalles
    {
        [Key]
        public int Id { get; set; }
        public int FacturaId { get; set; }
        public int RopaId { get; set; }
        public string Descripcion { get; set; }
        public int Cantidad { get; set; }
        public Decimal Precio { get; set; }
        public int Importe { get; set; }

        [ForeignKey("FacturaId")]
        public virtual Facturas Factura { get; set; }

        [ForeignKey("RopaId")]
        public virtual Ropas Ropa { get; set; }


        public FacturasDetalles()
        {
            Id = 0;
        }

        public FacturasDetalles(int id, int facturaId, int ropaId,string descripcion, int cantidad, decimal precio, int importe)
        {
            this.Id = id;
            this.FacturaId = facturaId;
            this.RopaId = ropaId;
           this.Descripcion = descripcion;
            this.Cantidad = cantidad;
            this.Precio = precio;
            this.Importe = importe;

        }
    }
}
