using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cartera.Controlador;
using System.Data.SQLite;


namespace Cartera.Modelo
{
    class MCliente_Producto

    {
        int Id_Cliente { get; set; }
        int Id_Producto { get; set; }
        DateTime Fecha_Cambio { get; set; }
        string Estado_Cliente { get; set; }

        public static int InsertCliente_Producto(int id_Cliente, int Id_Producto)
        {
            string sql = "INSERT INTO Cliente_Producto(Pfk_ID_Cliente, Pfk_ID_Producto, Fecha_Cambio, Estado_Cliente) VALUES (@Id_Cliente, @Id_Producto, @Fecha_Cambio, @Estado_Cliente); ";
            SQLiteCommand cmd = new SQLiteCommand(sql, Conexion.instanciaDb());
            cmd.Parameters.Add(new SQLiteParameter("@Id_Cliente", id_Cliente));
            cmd.Parameters.Add(new SQLiteParameter("@Id_Producto", Id_Producto));
            cmd.Parameters.Add(new SQLiteParameter("@Fecha_Cambio", DateTime.Now));
            cmd.Parameters.Add(new SQLiteParameter("@Estado_Cliente", "Activo"));
            return cmd.ExecuteNonQuery();
        }
    }
}
