﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cartera.Modelo
{
    class MPago
    {
        internal static DataTable ConsultarUltimaCuota(int productoid)
        {
            return Conexion.consulta("Select max(Numero_Cuota)  from Pagos where Fk_Id_Producto = '"+ productoid + "'");
            throw new NotImplementedException();
        }

        internal static int RegistrarPago(string porcentaje, int numero_Cuota, string fecha_Pago, string referencia_Pago, int valor_Pagado, string descuento, int valor_Descuento, int fk_Id_Producto)
        {
            string sql = "INSERT INTO Pagos(Porcentaje, Numero_Cuota, Fecha_Pago, Referencia_Pago, Valor_Pagado, Descuento, Valor_Descuento, Fk_Id_Producto)VALUES(@Porcentaje, @Numero_Cuota, @Fecha_Pago, @Referencia_Pago, @Valor_Pagado, @Descuento, @Valor_Descuento, @Fk_Id_Producto)";
            SQLiteCommand cmd = new SQLiteCommand(sql, Conexion.instanciaDb());
            cmd.Parameters.Add(new SQLiteParameter("@Porcentaje", porcentaje));
            cmd.Parameters.Add(new SQLiteParameter("@Numero_Cuota", numero_Cuota));
            cmd.Parameters.Add(new SQLiteParameter("@Fecha_Pago", fecha_Pago));
            cmd.Parameters.Add(new SQLiteParameter("@Referencia_Pago", referencia_Pago));
            cmd.Parameters.Add(new SQLiteParameter("@Valor_Pagado", valor_Pagado));
            cmd.Parameters.Add(new SQLiteParameter("@Descuento", descuento));
            cmd.Parameters.Add(new SQLiteParameter("@Valor_Descuento", valor_Descuento));
            cmd.Parameters.Add(new SQLiteParameter("@Fk_Id_Producto", fk_Id_Producto));
            return cmd.ExecuteNonQuery();
        }
    }
}