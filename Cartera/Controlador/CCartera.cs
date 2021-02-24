using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Cartera.Modelo;

namespace Cartera.Controlador
{
    class CCartera
    {
        public int crearCartera() 
        {
            return MCartera.crearCartera();
        }

        public DataTable UltimoRegistro()
        {
            return MCartera.UltimoRegistro();
        }
    }
}
