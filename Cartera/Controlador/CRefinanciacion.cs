using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cartera.Modelo;

namespace Cartera.Controlador
{
    internal class CRefinanciacion
    {
        public int crearRefinanciacion(int Valor_Neto_Refi, double Interes_Mora, double Valor_Deuda, int Cuotas_Refi, double Valor_Cuota_Refi, double Valor_Interes_Refi, int Valor_Total_Refi, string Fecha_Refi, string User_log_Refi, int Fk_Financiacion)
        {
            return MRefinanciacion.crearRefinanciacion(Valor_Neto_Refi, Interes_Mora, Valor_Deuda, Cuotas_Refi, Valor_Cuota_Refi, Valor_Interes_Refi, Valor_Total_Refi, Fecha_Refi, User_log_Refi, Fk_Financiacion);
        }
        public DataTable RefinanciacionFinanciacion(int Financiacion)
        {
            return MRefinanciacion.RefinanciacionFinanciacion(Financiacion);
        }
    }
}
