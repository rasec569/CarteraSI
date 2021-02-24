using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cartera.Modelo;

namespace Cartera.Controlador
{
    class CCliente_Producto
    {
        //MCliente_Producto mcp = new MCliente_Producto();
        public int InsertCliente_Producto(int id_Cliente, int Id_Producto) {
            return MCliente_Producto.InsertCliente_Producto(id_Cliente, Id_Producto);
        }
    }
}
