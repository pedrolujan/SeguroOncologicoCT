using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class Pagos
    {
        public Pagos() { }

        public int IdPagos { get; set; }
        public int IdCronograma { get; set; }
        public DateTime FechaPago { get; set; }
        public int IdMoneda { get; set; }
        public Decimal Importe { get; set; }
        public string Estado { get; set; }
    }
}
