﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data;

namespace Cartera.Modelo
{
    internal class MRefinanciacion
    {
        internal static int crearRefinanciacion(double Valor_Neto_Refi, double Interes_Mora, double Valor_Deuda, int Cuotas_Refi, double Valor_Cuota_Refi, double Valor_Interes_Refi, double Valor_Total_Refi, double Total, string Fecha_Refi, string User_log_Refi, int Fk_Financiacion)
        {
            string sql = "INSERT INTO Refinanciacion (Valor_Neto_Refi, Interes_Mora, Valor_Deuda, Cuotas_Refi, Valor_Cuota_Refi, Valor_Interes_Refi, Valor_Total_Refi, Total_Refi, Fecha_Refi, User_log_Refi, Fk_Financiacion) VALUES(@Valor_Neto_Refi, @Interes_Mora, @Valor_Deuda, @Cuotas_Refi, @Valor_Cuota_Refi, @Valor_Interes_Refi, @Valor_Total_Refi, @Total_Refi, @Fecha_Refi, @User_log_Refi, @Fk_Financiacion);";
            SQLiteCommand cmd = new SQLiteCommand(sql, Conexion.instanciaDb());
            try
            {
                cmd.Parameters.Add(new SQLiteParameter("@Valor_Neto_Refi", Valor_Neto_Refi));
                cmd.Parameters.Add(new SQLiteParameter("@Interes_Mora", Interes_Mora));
                cmd.Parameters.Add(new SQLiteParameter("@Valor_Deuda", Valor_Deuda));
                cmd.Parameters.Add(new SQLiteParameter("@Cuotas_Refi", Cuotas_Refi));
                cmd.Parameters.Add(new SQLiteParameter("@Valor_Cuota_Refi", Valor_Cuota_Refi));
                cmd.Parameters.Add(new SQLiteParameter("@Valor_Interes_Refi", Valor_Interes_Refi));
                cmd.Parameters.Add(new SQLiteParameter("@Valor_Total_Refi", Valor_Total_Refi));
                cmd.Parameters.Add(new SQLiteParameter("@Total_Refi", Total));                
                cmd.Parameters.Add(new SQLiteParameter("@Fecha_Refi", Fecha_Refi));
                cmd.Parameters.Add(new SQLiteParameter("@User_log_Refi", User_log_Refi));
                cmd.Parameters.Add(new SQLiteParameter("@Fk_Financiacion", Fk_Financiacion));
            }
            catch (Exception ex){
                Console.WriteLine("Commit Exception Type: {0}", ex.GetType());
                Console.WriteLine("  Message: {0}", ex.Message);

            }
            
            return cmd.ExecuteNonQuery();
        }

        internal static DataTable RefinanciacionFinanciacion(int Financiacion)
        {
            return Conexion.consulta("SELECT Id_Refinanciacion, Valor_Neto_Refi AS 'Valor Financiación', Interes_Mora AS 'Interes Mora', Valor_Deuda AS 'Valor Deuda', Cuotas_Refi AS '# Cuotas', Valor_Cuota_Refi AS 'Valor Cuota', Valor_Interes_Refi AS 'Valor Interes', Valor_Total_Refi AS 'Valor Total', Fecha_Refi AS Fecha FROM Refinanciacion WHERE Fk_Financiacion = '" + Financiacion + "';");
        }
    }
}
