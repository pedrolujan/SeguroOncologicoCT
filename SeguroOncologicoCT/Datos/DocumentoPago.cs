using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class DocumentoPago
    {
        public DocumentoPago() { }

        public int IdDocumentoPago { get; set; }
        public int idPago { get; set; }
        public string Codigo  { get; set; }
        public Decimal ImporteTotal { get; set; }
        public string Estado { get; set; }
    }
}
