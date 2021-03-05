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

        public int RegistrarTipoProducto(string Nom_Tipo_Producto)
        {
            return MTipo_Producto.RegistrarTipoProducto(Nom_Tipo_Producto);
        }

        public int ActualizarTipoProducto(int Id_Tipo_Producto, string Nom_Tipo_Producto)
        {
            return MTipo_Producto.ActualizarTipoProducto(Id_Tipo_Producto, Nom_Tipo_Producto);
        }

        public int EliminarTipoProducto(int Id_Tipo_Producto)
        {
            return MTipo_Producto.EliminarTipoProducto(Id_Tipo_Producto);
        }
    }
}
