using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cartera.Modelo;

namespace Cartera.Controlador
{
    class CCliente_Producto
    {
        //MCliente_Producto mcp = new MCliente_Producto();
        public int InsertCliente_Producto(string id_Cliente, string Id_Producto) {
            return MCliente_Producto.InsertCliente_Producto(id_Cliente, Id_Producto);
        }
        public DataTable HistorialCliente (int id_Producto)
        {
            return MCliente_Producto.HistorialCliente(id_Producto);
        }
        public int EstadoTrasferir(string id_Cliente, string Id_Producto, string fechacambio)
        {
            return MCliente_Producto.EstadoTrasferir(id_Cliente, Id_Producto, fechacambio);
        }
        public int EstadoDisolver(string id_Cliente, string Id_Producto, string fechacambio)
        {
            return MCliente_Producto.EstadoDisolver(id_Cliente, Id_Producto, fechacambio);
        }
    }
}
