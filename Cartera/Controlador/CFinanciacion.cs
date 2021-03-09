using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cartera.Modelo;

namespace Cartera.Controlador
{
    class CFinanciacion
    {
        public int crearFinanciacion(string Valor_Producto_Financiacion, string Valor_Entrada, string Valor_Sin_interes, string Valor_Cuota_Sin_interes, string Cuotas_Sin_interes, string Valor_Con_Interes, string Cuotas_Con_Interes, string Valor_Cuota_Con_Interes, string Valor_Interes, string Fecha_Recaudo, string Fk_Producto)
        {
            return MFinanciacion.crearFinanciacion(Valor_Producto_Financiacion, Valor_Entrada, Valor_Sin_interes, Valor_Cuota_Sin_interes, Cuotas_Sin_interes, Valor_Con_Interes, Cuotas_Con_Interes, Valor_Cuota_Con_Interes, Valor_Interes, Fecha_Recaudo, Fk_Producto);
        }
        public int actualizarFinanciacion(string Id_Financiacion, string Valor_Producto_Financiacion, string Valor_Entrada, string Valor_Sin_interes, string Valor_Cuota_Sin_interes, string Cuotas_Sin_interes, string Valor_Con_Interes, string Cuotas_Con_Interes, string Valor_Cuota_Con_Interes, string Valor_Interes, string Fecha_Recaudo, int Fk_Producto)
        {
            return MFinanciacion.actualizarFinanciacion(Id_Financiacion, Valor_Producto_Financiacion, Valor_Entrada, Valor_Sin_interes, Valor_Cuota_Sin_interes, Cuotas_Sin_interes, Valor_Con_Interes, Cuotas_Con_Interes, Valor_Cuota_Con_Interes, Valor_Interes, Fecha_Recaudo, Fk_Producto);
        }
        public int CambiarFinanciacion(string Id_Financiacion, string Valor_Producto_Financiacion, string Valor_Entrada, string Valor_Sin_interes, string Valor_Cuota_Sin_interes, string Cuotas_Sin_interes, string Valor_Con_Interes, string Cuotas_Con_Interes, string Valor_Cuota_Con_Interes, string Valor_Interes, string Fecha_Recaudo, int Fk_Producto)
        {
            return MFinanciacion.CambiarFinanciacion(Id_Financiacion, Valor_Producto_Financiacion, Valor_Entrada, Valor_Sin_interes, Valor_Cuota_Sin_interes, Cuotas_Sin_interes, Valor_Con_Interes, Cuotas_Con_Interes, Valor_Cuota_Con_Interes, Valor_Interes, Fecha_Recaudo, Fk_Producto);
        }
        public DataTable FinanciacionProducto(int Id_Producto)
        {
            return MFinanciacion.FinanciacionProducto(Id_Producto);
        }
        public DataTable HistorialFinanciacion(int Id_Producto)
        {
            return MFinanciacion.HistorialFinanciacion(Id_Producto);
        }

    }
}
