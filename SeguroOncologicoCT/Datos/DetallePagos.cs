using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class DetallePagos
    {
        public DetallePagos() { }
        public int IdDetallePagos { get; set; }
        public int IdPagos { get; set; }
        public DateTime FechaRegistro { get; set; }
        public String Observaciones { get; set; }
        public String estado { get; set; }
    }
}
