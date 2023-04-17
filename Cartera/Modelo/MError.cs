using Cartera.Controlador;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cartera.Modelo
{
    internal class MError
    {
        internal static int LongError(string TextError, string SqlError,string MetodoError)
        {
            string sql_Er = "INSERT INTO Log_Error (Metodo_Error, Sql_Error, Mensaje_Error) VALUES (@Metodo_error, @Sql_Error, @Tex_Error);";
            SQLiteCommand cmd_Er = new SQLiteCommand(sql_Er, Conexion.instanciaDb());
            cmd_Er.Parameters.Add(new SQLiteParameter("@Tex_Error", TextError));
            cmd_Er.Parameters.Add(new SQLiteParameter("@Sql_Error", SqlError));
            cmd_Er.Parameters.Add(new SQLiteParameter("@Metodo_error", MetodoError));
            return cmd_Er.ExecuteNonQuery();

        }
    }
}
