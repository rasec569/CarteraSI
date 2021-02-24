using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cartera.Modelo;

namespace Cartera.Controlador
{
    class CLogin
    {
        public DataTable ValidaUser(string user, string pass)
        {
            return MLogin.ValidaUser(user, pass);
        }
    }
}
