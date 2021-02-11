using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cartera.Modelo
{
    class MCliente
    {
        public Int64 ID_Cliente { get; set; }
        public Int64 Cedula { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public Int64 Telefono { get; set; }
        public string Direccion { get; set; }
        public string Correo { get; set; }
    }
}
