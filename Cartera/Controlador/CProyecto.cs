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
            return MProyecto.RegistrarProyecto(Proyecto_nombre, ubicacion);
        }
        public int ActualizarProyecto(int Id_Proyecto, string Proyecto_Nombre, string Proyecto_Ubicacion)
        {
            return MProyecto.ActualizarProyecto(Id_Proyecto, Proyecto_Nombre, Proyecto_Ubicacion);
        }
    }
}
