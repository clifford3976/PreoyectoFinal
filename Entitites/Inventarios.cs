using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entitites
{
    [Serializable]
    public class Inventarios
    {
        [Key]
        public int InventarioId { get; set; }
        public DateTime Fecha { get; set; }
        public int Cantidad { get; set; }
        public string Descripcion { get; set; }
        public int RopaId { get; set; }


        public Inventarios()
        {
            InventarioId = 0;
            RopaId = 0;
            Descripcion = string.Empty;
            Fecha = DateTime.Now;
            Cantidad = 0;
        }


    }
}
