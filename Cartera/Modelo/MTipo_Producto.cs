using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cartera.Modelo
{
    class MTipo_Producto
    {
        public static DataTable listarTipoProducto()
        {
            return Conexion.consulta("SELECT * FROM Tipo_Producto");
        }
    }
}
