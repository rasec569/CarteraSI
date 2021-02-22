using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cartera.Controlador
{
    interface CLogin
    {
        DataTable ValidaUser(string user, string pass);
    }
}
