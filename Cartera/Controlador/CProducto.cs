using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cartera.Modelo;

namespace Cartera.Controlador
{
    interface CProducto{

        DataTable cargarProductos();

        int crearProducto(string Nombre_Producto, string Numero_contrato, string Forma_Pago, int Valor_Total, string Fecha_Venta, string Observaciones, int Fk_Id_Proyecto, int Fk_Id_Tipo_Producto, int Fk_Id_Financiacion);
    }
}
