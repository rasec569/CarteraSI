using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Cartera.Controlador;

namespace Cartera.Modelo
{
    class MProyecto
    {
        public Int64 ID_Proyecto { get; set; }
        public string Proyecto_nombre { get; set; }

        public static DataTable listarProyectos()
        {
            return Conexion.consulta("SELECT * FROM Proyecto");
        }

    }
}
