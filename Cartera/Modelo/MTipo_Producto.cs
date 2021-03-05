using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cartera.Modelo
{
    class MTipo_Producto
    {
        public static DataTable listarTipoProducto()
        {
            return Conexion.consulta("SELECT * FROM Tipo_Producto");
        }

        internal static int RegistrarTipoProducto(string Nom_Tipo_Producto)
        {
            string sql = "INSERT INTO Tipo_Producto(Nom_Tipo_Producto) VALUES(upper(@Nom_Tipo_Producto));";
            SQLiteCommand cmd = new SQLiteCommand(sql, Conexion.instanciaDb());
            cmd.Parameters.Add(new SQLiteParameter("@Nom_Tipo_Producto", Nom_Tipo_Producto));
            return cmd.ExecuteNonQuery();
        }

        internal static int EliminarTipoProducto(int Id_Tipo_Producto)
        {
            string sql = "DELETE FROM Tipo_Producto WHERE Id_Tipo_Producto = '" + Id_Tipo_Producto + "')";
            SQLiteCommand cmd = new SQLiteCommand(sql, Conexion.instanciaDb());
            cmd.Parameters.Add(new SQLiteParameter("@Id_Tipo_Producto", Id_Tipo_Producto));
            return cmd.ExecuteNonQuery();
        }
        internal static int ActualizarTipoProducto(int Id_Tipo_Producto, string Nom_Tipo_Producto)
        {
            string sql = "UPDATE Tipo_Producto SET Id_Tipo_Producto = @Id_Tipo_Producto, Nom_Tipo_Producto = upper(@Nom_Tipo_Producto) WHERE Id_Tipo_Producto =" + Id_Tipo_Producto + "";
            SQLiteCommand cmd = new SQLiteCommand(sql, Conexion.instanciaDb());
            cmd.Parameters.Add(new SQLiteParameter("@Id_Tipo_Producto", Id_Tipo_Producto));
            cmd.Parameters.Add(new SQLiteParameter("@Nom_Tipo_Producto", Nom_Tipo_Producto));
            return cmd.ExecuteNonQuery();

        }
    }
}
