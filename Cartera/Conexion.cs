using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SQLite;

namespace Cartera
{
    class Conexion
    {
        private static Conexion_Instancia instancia = null;
        public static SQLiteConnection instanciaDb()
        {
            if (instancia == null) {
                instancia = new Conexion_Instancia();
            }
            return instancia.com;
        }
        public static DataTable consulta(string sql)
        {
            DataTable dt = new DataTable();
            SQLiteDataAdapter da = new SQLiteDataAdapter(sql, instanciaDb());
            da.Fill(dt);
            return dt;
        }
    }
    public class Conexion_Instancia
    {
        public SQLiteConnection com = null;
        public Conexion_Instancia()
        {
            com = new SQLiteConnection("Data Source = Cartera San Isidro.db");
            com.Open();
        }
        ~Conexion_Instancia()
        {
            com.Close();
        }
    }
    
}
    

    

