using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entitites
{
    [Serializable]
    public class Ropas
    {
        [Key]
        public int RopaId { get; set; }
        public DateTime FechaRegistro { get; set; }
        public string Descripcion { get; set; }
        public string Size { get; set; }
        public string Marca { get; set; }
        public Decimal Precio { get; set; }
        public int Inventario { get; set; }

        public Ropas()
        {
            RopaId = 0;
            FechaRegistro = DateTime.Now;
            Descripcion = string.Empty;
            Size = string.Empty;
            Marca = string.Empty;
            Precio = 0;
            Inventario = 0;
        }

        public override string ToString()
        {
            return Descripcion;
        }

    }
}
