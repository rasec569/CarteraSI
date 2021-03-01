using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cartera.Modelo;
using System.Data;

namespace Cartera.Controlador
{
    class CProyecto
    {
        public DataTable listarProyectos()
        {
            return MProyecto.listarProyectos();
        }
        public int RegistrarProyecto(string Proyecto_nombre, string ubicacion)
        {
            return RegistrarProyecto(Proyecto_nombre, ubicacion);
        }
    }
}
