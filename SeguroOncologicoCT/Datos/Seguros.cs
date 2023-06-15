using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class Seguros
    {
        public int IdSeguro { get; set; }
        public string NombreCompania { get; set; }
        public int IdTipoSeguro { get; set; }
       
        public Decimal FactorImpuesto { get; set; }
        public Decimal PrecioUnitario { get; set; }
        public Decimal PorcentajeComision { get; set; }
        public Decimal ImporteMensual { get; set; }
        public DateTime FechaVigencia { get; set; }
        public int EdadPermitida { get; set; }
        public string Estado { get; set; }
    }
}
