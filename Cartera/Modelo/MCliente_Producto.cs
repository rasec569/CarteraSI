using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cartera.Controlador;
using System.Data.SQLite;
using System.Data;

namespace Cartera.Modelo
{
    class MCliente_Producto

    {
        int Id_Cliente { get; set; }
        int Id_Producto { get; set; }
        DateTime Fecha_Cambio { get; set; }
        string Estado_Cliente { get; set; }

        public static int InsertCliente_Producto(string id_Cliente, string Id_Producto)
        {
            string sql = "INSERT INTO Cliente_Producto(Pfk_ID_Cliente, Pfk_ID_Producto, Fecha_Cambio, Estado_Cliente) VALUES (@Id_Cliente, @Id_Producto, @Fecha_Cambio, @Estado_Cliente); ";
            SQLiteCommand cmd = new SQLiteCommand(sql, Conexion.instanciaDb());
            cmd.Parameters.Add(new SQLiteParameter("@Id_Cliente", id_Cliente));
            cmd.Parameters.Add(new SQLiteParameter("@Id_Producto", Id_Producto));
            cmd.Parameters.Add(new SQLiteParameter("@Fecha_Cambio", DateTime.Now.ToShortDateString()));
            cmd.Parameters.Add(new SQLiteParameter("@Estado_Cliente", "Activo"));
            return cmd.ExecuteNonQuery();
        }

        internal static int EstadoDisolver(string id_Cliente, string id_Producto, string fechacambio)
        {
            string sql = "UPDATE Cliente_Producto SET Estado_Cliente=@Estado_Cliente, Fecha_Cambio=@Fecha_Cambio WHERE Pfk_ID_Cliente= '" + id_Cliente + "' AND Pfk_ID_Producto='" + id_Producto + "'";
            SQLiteCommand cmd = new SQLiteCommand(sql, Conexion.instanciaDb());
            cmd.Parameters.Add(new SQLiteParameter("@Estado_Cliente", "Disuelto"));
            cmd.Parameters.Add(new SQLiteParameter("@Fecha_Cambio", fechacambio));
            return cmd.ExecuteNonQuery();
        }

        internal static int EstadoTrasferir(string id_Cliente, string id_Producto, string fechacambio)
        {
            string sql = "UPDATE Cliente_Producto SET Estado_Cliente=@Estado_Cliente, Fecha_Cambio=@Fecha_Cambio WHERE Pfk_ID_Cliente= '" + id_Cliente + "' AND Pfk_ID_Producto='" + id_Producto + "'";
            SQLiteCommand cmd = new SQLiteCommand(sql, Conexion.instanciaDb());
            cmd.Parameters.Add(new SQLiteParameter("@Estado_Cliente", "Cedido"));
            cmd.Parameters.Add(new SQLiteParameter("@Fecha_Cambio", fechacambio));
            return cmd.ExecuteNonQuery();
           
        }

        internal static DataTable HistorialCliente(int id_Producto)
        {
            return Conexion.consulta("SELECT Cedula, Nombre, Apellido, Nombre_Producto, Estado_Cliente, Fecha_Cambio FROM Cliente_Producto INNER JOIN Cliente on Id_Cliente = Pfk_ID_Cliente INNER JOIN Producto on Id_Producto= Pfk_ID_Producto WHERE Pfk_ID_Producto='" + id_Producto + "'");
        }
    }
}
