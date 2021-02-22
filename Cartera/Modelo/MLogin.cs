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
    public class MLogin:CLogin

    {
        public string Nom_Usuario { get; set; }
        public string Contraseña { get; set; }

        public DataTable ValidaUser(string user, string pass)
        {
            return Conexion.consulta("Select Nom_Usuario, Contraseña from Usuario where Nom_Usuario='" + user + "' AND Contraseña= '" + pass + "')");
        }        
        
    }
}
