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
            string sql = "INSERT INTO Financiacion (Valor_Producto_Financiacion, Valor_Entrada, Valor_Sin_interes, Valor_Cuota_Sin_interes, Cuotas_Sin_interes, Valor_Con_Interes, Cuotas_Con_Interes, Valor_Cuota_Con_Interes, Valor_Interes, Fecha_Recaudo, Fk_Producto, Estado_Financiacion) VALUES(@Valor_Producto_Financiacion, @Valor_Entrada, @Valor_Sin_interes, @Valor_Cuota_Sin_interes, @Cuotas_Sin_interes, @Valor_Con_Interes, @Cuotas_Con_Interes, @Valor_Cuota_Con_Interes, @Valor_Interes, @Fecha_Recaudo, @Fk_Producto, @Estado_Financiacion);";
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
            cmd.Parameters.Add(new SQLiteParameter("@Estado_Financiacion", "Activa"));
            return cmd.ExecuteNonQuery();
        }

        internal static DataTable HistorialFinanciacion(int id_Producto)
        {
            return Conexion.consulta("SELECT Id_Financiacion, Valor_Neto, Valor_Producto_Financiacion, Valor_Sin_interes, Valor_Entrada,  Cuotas_Sin_interes, Valor_Cuota_Sin_interes, Valor_Con_Interes, Cuotas_Con_Interes, Valor_Cuota_Con_Interes, Valor_Interes, Fecha_Recaudo, Estado_Financiacion,Fecha_Venta, Id_Refinanciacion FROM Financiacion INNER JOIN Producto on Id_Producto=Fk_Producto LEFT JOIN Refinanciacion on Fk_Financiacion=Id_Financiacion WHERE Fk_Producto='" + id_Producto + "' ORDER BY Estado_Financiacion;");
        }
        internal static DataTable Financiacion(int id_Financiacion)
        {
            return Conexion.consulta("SELECT Id_Financiacion, Valor_Neto, Valor_Producto_Financiacion, Valor_Sin_interes, Valor_Entrada,  Cuotas_Sin_interes, Valor_Cuota_Sin_interes, Valor_Con_Interes, Cuotas_Con_Interes, Valor_Cuota_Con_Interes, Valor_Interes, Fecha_Recaudo, Estado_Financiacion,Fecha_Venta, Id_Refinanciacion FROM Financiacion INNER JOIN Producto on Id_Producto=Fk_Producto LEFT JOIN Refinanciacion on Fk_Financiacion=Id_Financiacion WHERE Id_Financiacion='" + id_Financiacion + "' ORDER BY Estado_Financiacion;");
        }
        internal static DataTable FinanciacionProducto(int id_Producto)
        {
            return Conexion.consulta("SELECT  Id_Financiacion, Valor_Producto_Financiacion, Valor_Sin_interes , Valor_Entrada, Valor_Cuota_Sin_interes, Cuotas_Sin_interes, Valor_Con_Interes, Cuotas_Con_Interes, Valor_Cuota_Con_Interes, Valor_Interes, Fecha_Recaudo, Id_Refinanciacion FROM Financiacion LEFT JOIN Refinanciacion on Fk_Financiacion=Id_Financiacion WHERE Fk_Producto= '" + id_Producto + "' and Estado_Financiacion='Activa';");
        }
        public static int actualizarFinanciacion(int Id_Financiacion, int Valor_Producto_Financiacion, int Valor_Entrada, int Valor_Sin_interes, int Valor_Cuota_Sin_interes, int Cuotas_Sin_interes, int Valor_Con_Interes, int Cuotas_Con_Interes, int Valor_Cuota_Con_Interes, int Valor_Interes, string Fecha_Recaudo, int Fk_Producto)
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
        public static int InactivarFinanciacion(int Id_Financiacion)
        {

            string sql = "UPDATE Financiacion SET Estado_Financiacion = @Estado_Financiacion WHERE Id_Financiacion = '" + Id_Financiacion + "';";
            SQLiteCommand cmd = new SQLiteCommand(sql, Conexion.instanciaDb());            
            cmd.Parameters.Add(new SQLiteParameter("@Estado_Financiacion", "Inactiva"));
            return cmd.ExecuteNonQuery();
        }

        public static int CambiarFinanciacion(int Id_Financiacion, int Valor_Producto_Financiacion, int Valor_Entrada, int Valor_Sin_interes, int Valor_Cuota_Sin_interes, int Cuotas_Sin_interes, int Valor_Con_Interes, int Cuotas_Con_Interes, int Valor_Cuota_Con_Interes, int Valor_Interes, string Fecha_Recaudo, int Fk_Producto)
        {
            string sql = "INSERT INTO Financiacion (Valor_Producto_Financiacion, Valor_Entrada, Valor_Sin_interes, Valor_Cuota_Sin_interes, Cuotas_Sin_interes, Valor_Con_Interes, Cuotas_Con_Interes, Valor_Cuota_Con_Interes, Valor_Interes, Fecha_Recaudo, Fk_Producto, Fk_Predecesor_Financiacion, Estado_Financiacion) VALUES(@Valor_Producto_Financiacion, @Valor_Entrada, @Valor_Sin_interes, @Valor_Cuota_Sin_interes, @Cuotas_Sin_interes, @Valor_Con_Interes, @Cuotas_Con_Interes, @Valor_Cuota_Con_Interes, @Valor_Interes, @Fecha_Recaudo, @Fk_Producto, @Fk_Predecesor_Financiacion, @Estado_Financiacion );";
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
            cmd.Parameters.Add(new SQLiteParameter("@Estado_Financiacion", "Activa"));
            return cmd.ExecuteNonQuery();
        }

    }

}
