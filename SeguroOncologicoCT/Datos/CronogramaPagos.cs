using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class CronogramaPagos
    {
        public CronogramaPagos() { }

        public int IdCronogramaPagos { get; set; }
        public int IdAfiliacion { get; set; }
        public DateTime FechaPago { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public DateTime FechaRegistro { get; set; }
        public String Estado { get; set; }
    }
}
