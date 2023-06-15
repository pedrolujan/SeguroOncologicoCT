using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class Afiliacion
    {
        public Afiliacion() { }

        public int IdAfiliacion { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public DateTime FechaRegistro { get; set; }
        public int IdCliente { get; set; }
        public int IdSeguro { get; set; }
        public String Estado { get; set; }
    }
}
