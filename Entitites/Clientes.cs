using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entitites
{
    [Serializable]
    public class Clientes
    {
        [Key]
        public int ClienteId { get; set; }
        public DateTime Fecha { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Direccion { get; set; }
        public string Email { get; set; }
        public string Cedula { get; set; }
        public string Telefono { get; set; }


        public Clientes()
        {
            ClienteId = 0;
            Fecha = DateTime.Now;
            Nombres = string.Empty;
            Apellidos = string.Empty;
            Direccion = string.Empty;
            Email = string.Empty;
            Cedula = string.Empty;
            Telefono = string.Empty;
        }

        public override string ToString()
        {
            return Nombres + Apellidos;
        }
    }
}
