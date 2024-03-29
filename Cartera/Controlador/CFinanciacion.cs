﻿using System;
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
        public int crearFinanciacion(double Valor_Producto_Financiacion, int Valor_Entrada, int Valor_Sin_interes, double Valor_Cuota_Sin_interes, int Cuotas_Sin_interes, double Valor_Con_Interes, int Cuotas_Con_Interes, double Valor_Cuota_Con_Interes, int Valor_Interes, string Fecha_Recaudo, string Fk_Producto)
        {
            return MFinanciacion.crearFinanciacion(Valor_Producto_Financiacion, Valor_Entrada, Valor_Sin_interes, Valor_Cuota_Sin_interes, Cuotas_Sin_interes, Valor_Con_Interes, Cuotas_Con_Interes, Valor_Cuota_Con_Interes, Valor_Interes, Fecha_Recaudo, Fk_Producto);
        }
        public int actualizarFinanciacion(int Id_Financiacion, double Valor_Producto_Financiacion, int Valor_Entrada, int Valor_Sin_interes, double Valor_Cuota_Sin_interes, int Cuotas_Sin_interes, double Valor_Con_Interes, int Cuotas_Con_Interes, double Valor_Cuota_Con_Interes, int Valor_Interes, string Fecha_Recaudo, int Fk_Producto)
        {
            return MFinanciacion.actualizarFinanciacion(Id_Financiacion, Valor_Producto_Financiacion, Valor_Entrada, Valor_Sin_interes, Valor_Cuota_Sin_interes, Cuotas_Sin_interes, Valor_Con_Interes, Cuotas_Con_Interes, Valor_Cuota_Con_Interes, Valor_Interes, Fecha_Recaudo, Fk_Producto);
        }
        public int InactivarFinanciacion(int Id_Financiacion)
        {
            return MFinanciacion.InactivarFinanciacion(Id_Financiacion);
        }
        public int CambiarFinanciacion(int Id_Financiacion, int Valor_Producto_Financiacion, int Valor_Entrada, int Valor_Sin_interes, int Valor_Cuota_Sin_interes, int Cuotas_Sin_interes, int Valor_Con_Interes, int Cuotas_Con_Interes, int Valor_Cuota_Con_Interes, int Valor_Interes, string Fecha_Recaudo, int Fk_Producto)
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
        public DataTable Financiacion(int id_Financiacion)
        {
            return MFinanciacion.Financiacion(id_Financiacion);
        }
    }
}
