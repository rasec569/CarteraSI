using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data;
using Cartera.Controlador;

namespace Cartera.Modelo
{
    class MFinanciacion
    {
        public int Id_Financiacion { get; set; }
        public int Valor_Producto_Financiacion { get; set;}
        public int Valor_Entrada { get; set; }
        public int Valor_Sin_interes { get; set; }
        public int Valor_Cuota_Sin_interes { get; set; }
        public int Cuotas_Sin_interes { get; set; }
        public int Valor_Con_Interes { get; set; }
        public int Cuotas_Con_Interes { get; set; }
        public int Valor_Cuota_Con_Interes { get; set; }
        public int Valor_Interes { get; set; }
        public DateTime Fecha_Recaudo { get; set; }

        public static int crearFinanciacion(int Valor_Producto_Financiacion, int Valor_Entrada, int Valor_Sin_interes, int Valor_Cuota_Sin_interes, int Cuotas_Sin_interes, int Valor_Con_Interes, int Cuotas_Con_Interes, int Valor_Cuota_Con_Interes, int Valor_Interes, string Fecha_Recaudo, string Fk_Producto)
        {
            string sql = "INSERT INTO Financiacion (Valor_Producto_Financiacion, Valor_Entrada, Valor_Sin_interes, Valor_Cuota_Sin_interes, Cuotas_Sin_interes, Valor_Con_Interes, Cuotas_Con_Interes, Valor_Cuota_Con_Interes, Valor_Interes, Fecha_Recaudo, Fk_Producto) VALUES(@Valor_Producto_Financiacion, @Valor_Entrada, @Valor_Sin_interes, @Valor_Cuota_Sin_interes, @Cuotas_Sin_interes, @Valor_Con_Interes, @Cuotas_Con_Interes, @Valor_Cuota_Con_Interes, @Valor_Interes, @Fecha_Recaudo, @Fk_Producto);";
            SQLiteCommand cmd = new SQLiteCommand(sql, Conexion.instanciaDb());
            cmd.Parameters.Add(new SQLiteParameter("@Valor_Producto_Financiacion", Valor_Producto_Financiacion));
            cmd.Parameters.Add(new SQLiteParameter("@Valor_Entrada", Valor_Entrada));
            cmd.Parameters.Add(new SQLiteParameter("@Valor_Sin_interes", Valor_Sin_interes));
            cmd.Parameters.Add(new SQLiteParameter("@Valor_Cuota_Sin_interes", Valor_Cuota_Sin_interes));
            cmd.Parameters.Add(new SQLiteParameter("@Cuotas_Sin_interes", Cuotas_Sin_interes));
            cmd.Parameters.Add(new SQLiteParameter("@Valor_Con_Interes", Valor_Con_Interes));
            cmd.Parameters.Add(new SQLiteParameter("@Cuotas_Con_Interes", Cuotas_Con_Interes));
            cmd.Parameters.Add(new SQLiteParameter("@Valor_Cuota_Con_Interes", Valor_Cuota_Con_Interes));
            cmd.Parameters.Add(new SQLiteParameter("@Valor_Interes", Valor_Interes));
            cmd.Parameters.Add(new SQLiteParameter("@Fecha_Recaudo", Fecha_Recaudo));
            cmd.Parameters.Add(new SQLiteParameter("@Fk_Producto", Fk_Producto));
            return cmd.ExecuteNonQuery();
        }

        internal static DataTable HistorialFinanciacion(int id_Producto)
        {
            return Conexion.consulta("SELECT  Valor_Producto_Financiacion, Valor_Entrada, Valor_Sin_interes, Cuotas_Sin_interes, Valor_Cuota_Sin_interes, Valor_Con_Interes, Cuotas_Con_Interes, Valor_Cuota_Con_Interes, Valor_Interes, Fecha_Recaudo  FROM Financiacion WHERE Fk_Producto='" + id_Producto + "'");
        }

        internal static DataTable FinanciacionProducto(int id_Producto)
        {
            return Conexion.consulta("SELECT  max(Id_Financiacion) as Id_Financiacion, Valor_Producto_Financiacion, Valor_Entrada, Valor_Sin_interes, Valor_Cuota_Sin_interes, Cuotas_Sin_interes, Valor_Con_Interes, Cuotas_Con_Interes, Valor_Cuota_Con_Interes, Valor_Interes, Fecha_Recaudo  FROM Financiacion WHERE Fk_Producto= '" + id_Producto + "'");
        }

        public static int actualizarFinanciacion(string Id_Financiacion, string Valor_Producto_Financiacion, string Valor_Entrada, string Valor_Sin_interes, string Valor_Cuota_Sin_interes, string Cuotas_Sin_interes, string Valor_Con_Interes, string Cuotas_Con_Interes, string Valor_Cuota_Con_Interes, string Valor_Interes, string Fecha_Recaudo, int Fk_Producto)
        {
                                              
            string sql = "UPDATE Financiacion SET Valor_Producto_Financiacion = @Valor_Producto_Financiacion, Valor_Entrada = @Valor_Entrada, Valor_Sin_interes = @Valor_Sin_interes, Valor_Cuota_Sin_interes = @Valor_Cuota_Sin_interes, Cuotas_Sin_interes = @Cuotas_Sin_interes, Valor_Con_Interes = @Valor_Con_Interes, Cuotas_Con_Interes = @Cuotas_Con_Interes, Valor_Cuota_Con_Interes = @Valor_Cuota_Con_Interes, Valor_Interes = @Valor_Interes, Fecha_Recaudo = @Fecha_Recaudo, Fk_Producto = @Fk_Producto WHERE Id_Financiacion = '" + Id_Financiacion + "';";
            SQLiteCommand cmd = new SQLiteCommand(sql, Conexion.instanciaDb());
            cmd.Parameters.Add(new SQLiteParameter("@Valor_Producto_Financiacion", Valor_Producto_Financiacion));
            cmd.Parameters.Add(new SQLiteParameter("@Valor_Entrada", Valor_Entrada));
            cmd.Parameters.Add(new SQLiteParameter("@Valor_Sin_interes", Valor_Sin_interes));
            cmd.Parameters.Add(new SQLiteParameter("@Valor_Cuota_Sin_interes", Valor_Cuota_Sin_interes));
            cmd.Parameters.Add(new SQLiteParameter("@Cuotas_Sin_interes", Cuotas_Sin_interes));
            cmd.Parameters.Add(new SQLiteParameter("@Valor_Con_Interes", Valor_Con_Interes));
            cmd.Parameters.Add(new SQLiteParameter("@Cuotas_Con_Interes", Cuotas_Con_Interes));
            cmd.Parameters.Add(new SQLiteParameter("@Valor_Cuota_Con_Interes", Valor_Cuota_Con_Interes));
            cmd.Parameters.Add(new SQLiteParameter("@Valor_Interes", Valor_Interes));
            cmd.Parameters.Add(new SQLiteParameter("@Fecha_Recaudo", Fecha_Recaudo));
            cmd.Parameters.Add(new SQLiteParameter("@Fk_Producto", Fk_Producto));
            return cmd.ExecuteNonQuery();
        }
        public static int CambiarFinanciacion(string Id_Financiacion, string Valor_Producto_Financiacion, string Valor_Entrada, string Valor_Sin_interes, string Valor_Cuota_Sin_interes, string Cuotas_Sin_interes, string Valor_Con_Interes, string Cuotas_Con_Interes, string Valor_Cuota_Con_Interes, string Valor_Interes, string Fecha_Recaudo, int Fk_Producto)
        {
            string sql = "INSERT INTO Financiacion (Valor_Producto_Financiacion, Valor_Entrada, Valor_Sin_interes, Valor_Cuota_Sin_interes, Cuotas_Sin_interes, Valor_Con_Interes, Cuotas_Con_Interes, Valor_Cuota_Con_Interes, Valor_Interes, Fecha_Recaudo, Fk_Producto, Fk_Predecesor_Financiacion) VALUES(@Valor_Producto_Financiacion, @Valor_Entrada, @Valor_Sin_interes, @Valor_Cuota_Sin_interes, @Cuotas_Sin_interes, @Valor_Con_Interes, @Cuotas_Con_Interes, @Valor_Cuota_Con_Interes, @Valor_Interes, @Fecha_Recaudo, @Fk_Producto, @Fk_Predecesor_Financiacion);";
            SQLiteCommand cmd = new SQLiteCommand(sql, Conexion.instanciaDb());
            cmd.Parameters.Add(new SQLiteParameter("@Valor_Producto_Financiacion", Valor_Producto_Financiacion));
            cmd.Parameters.Add(new SQLiteParameter("@Valor_Entrada", Valor_Entrada));
            cmd.Parameters.Add(new SQLiteParameter("@Valor_Sin_interes", Valor_Sin_interes));
            cmd.Parameters.Add(new SQLiteParameter("@Valor_Cuota_Sin_interes", Valor_Cuota_Sin_interes));
            cmd.Parameters.Add(new SQLiteParameter("@Cuotas_Sin_interes", Cuotas_Sin_interes));
            cmd.Parameters.Add(new SQLiteParameter("@Valor_Con_Interes", Valor_Con_Interes));
            cmd.Parameters.Add(new SQLiteParameter("@Cuotas_Con_Interes", Cuotas_Con_Interes));
            cmd.Parameters.Add(new SQLiteParameter("@Valor_Cuota_Con_Interes", Valor_Cuota_Con_Interes));
            cmd.Parameters.Add(new SQLiteParameter("@Valor_Interes", Valor_Interes));
            cmd.Parameters.Add(new SQLiteParameter("@Fecha_Recaudo", Fecha_Recaudo));
            cmd.Parameters.Add(new SQLiteParameter("@Fk_Producto", Fk_Producto));
            cmd.Parameters.Add(new SQLiteParameter("@Fk_Predecesor_Financiacion", Id_Financiacion));
            return cmd.ExecuteNonQuery();
        }
    }

}
