﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cartera.Modelo;

namespace Cartera.Controlador
{
    class CFinanciacion
    {
        int crearFinanciacion(int Valor_Producto_Financiacion, int Valor_Entrada, int Valor_Sin_interes, int Valor_Cuota_Sin_interes, int Cuotas_Sin_interes, int Valor_Con_Interes, int Cuotas_Con_Interes, int Valor_Cuota_Con_Interes, int Valor_Interes, DateTime Fecha_Recaudo)
        {
            return MFinanciacion.crearFinanciacion(Valor_Producto_Financiacion, Valor_Entrada, Valor_Sin_interes, Valor_Cuota_Sin_interes, Cuotas_Sin_interes, Valor_Con_Interes, Cuotas_Con_Interes, Valor_Cuota_Con_Interes, Valor_Interes, Fecha_Recaudo);
        }
    }
}
