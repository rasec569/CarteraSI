using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cartera.Modelo;

namespace Cartera.Controlador
{
    class CProducto{

        public DataTable cargarProductos()
        {
           return MProducto.cargarProductos();
        }
        public DataTable ultimoProducto()
        {
            return MProducto.ultimoProducto();
        }

        public int crearProducto(string Nombre_Producto, string Numero_contrato, string Forma_Pago, int Valor_Total, string Fecha_Venta, string Observaciones, int Fk_Id_Proyecto, int Fk_Id_Tipo_Producto)
        {
            return MProducto.crearProducto(Nombre_Producto, Numero_contrato, Forma_Pago, Valor_Total, Fecha_Venta, Observaciones, Fk_Id_Proyecto, Fk_Id_Tipo_Producto);
        }        
    }
}
