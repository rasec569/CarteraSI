using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cartera.Modelo;

namespace Cartera.Controlador
{
    class CTipo_Producto
    {
        public DataTable listarTipoProducto()
        {
            return MTipo_Producto.listarTipoProducto();
        }
    }
}
