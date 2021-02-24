using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SQLite;
using Cartera.Controlador;

namespace Cartera.Modelo
{
    public class MLogin

    {
        public string Nom_Usuario { get; set; }
        public string Contraseña { get; set; }

        public static DataTable ValidaUser(string Nom_Usuario, string Contraseña)
        {
            return Conexion.consulta("Select Nom_Usuario, Contraseña from Usuario where Nom_Usuario='" + Nom_Usuario + "' AND Contraseña= '" + Contraseña + "'");
        }        
        
    }
}
