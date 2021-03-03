using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Cartera.Controlador;
using System.Data.SQLite;

namespace Cartera.Modelo
{
    class MProyecto
    {
        public Int64 ID_Proyecto { get; set; }
        public string Proyecto_nombre { get; set; }
        public string ubicacion { get; set; }

        public static DataTable listarProyectos()
        {
            return Conexion.consulta("SELECT * FROM Proyecto");
        }
        public static int RegistrarProyecto(string Proyecto_nombre, string ubicacion)
        {
            string sql = "insert into Proyecto(Proyecto_Nombre,Proyecto_Ubicacion) values(@Proyecto_Nombre,@Proyecto_Ubicacion)";
            SQLiteCommand cmd = new SQLiteCommand(sql, Conexion.instanciaDb());
            cmd.Parameters.Add(new SQLiteParameter("@Proyecto_Nombre", Proyecto_nombre));
            cmd.Parameters.Add(new SQLiteParameter("@Proyecto_Ubicacion", ubicacion));
            return cmd.ExecuteNonQuery(); 
        }
        public static int ActualizarProyecto(int Id_Proyecto, string Proyecto_Nombre, string Proyecto_Ubicacion)
        {
            string sql = "UPDATE Proyecto SET Id_Proyecto = @Id_Proyecto, Proyecto_Nombre = @Proyecto_Nombre, Proyecto_Ubicacion = @Proyecto_Ubicacion WHERE Id_Proyecto ="+Id_Proyecto+"";
            SQLiteCommand cmd = new SQLiteCommand(sql, Conexion.instanciaDb());
            cmd.Parameters.Add(new SQLiteParameter("@Id_Proyecto", Id_Proyecto));
            cmd.Parameters.Add(new SQLiteParameter("@Proyecto_Nombre", Proyecto_Nombre));
            cmd.Parameters.Add(new SQLiteParameter("@Proyecto_Ubicacion", Proyecto_Ubicacion));          
            return cmd.ExecuteNonQuery();
        }

    }
}
