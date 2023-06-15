using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class Cliente
    {
        public Cliente() { }

        public int IdCliente { get; set; }
        public String Dni { get; set; }
        public String Nombres { get; set; }
        public String Apellidos { get; set; }
        public int Edad { get; set; }
        public String Direccion { get; set; }
        public String Telefono { get; set; }


    }
}
