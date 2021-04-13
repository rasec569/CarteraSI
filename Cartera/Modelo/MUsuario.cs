using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cartera.Modelo
{
    class MUsuario
    {
        internal static int crearUsuario(string nombre, string contraseña)
        {
            string sql = "INSERT INTO Usuario(Nom_Usuario, Contraseña) VALUES(@Nom_Usuario, @Contraseña);";
            SQLiteCommand cmd = new SQLiteCommand(sql, Conexion.instanciaDb());
            cmd.Parameters.Add(new SQLiteParameter("@Nom_Usuario", nombre));
            cmd.Parameters.Add(new SQLiteParameter("@Contraseña", contraseña));
            return cmd.ExecuteNonQuery();
        }

        internal static int ActulizarUsuario(string id_usuario, string nombre, string contraseña)
        {
            string sql = "UPDATE Usuario set  Nom_Usuario=@Nom_Usuario, Contraseña=@Contraseña from Usuario WHERE Id_usuario='"+ id_usuario + "';";
            SQLiteCommand cmd = new SQLiteCommand(sql, Conexion.instanciaDb());
            cmd.Parameters.Add(new SQLiteParameter("@Nom_Usuario", nombre));
            cmd.Parameters.Add(new SQLiteParameter("@Contraseña", contraseña));
            return cmd.ExecuteNonQuery();
        }

        internal static DataTable listarUsuario()
        {
            return Conexion.consulta("Select Id_usuario, Nom_Usuario as Usuario, Contraseña as Pass from Usuario");
        }
    }
}
