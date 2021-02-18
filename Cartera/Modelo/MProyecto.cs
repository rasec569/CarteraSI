using Cartera.Controlador;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cartera.Modelo
{
    class MProyecto : CProyecto
    {
        public Int64 ID_Proyecto { get; set; }
        public string Proyecto_nombre { get; set; }

        public static DataTable ConsultarProyectos()
        {
            return Conexion.consulta("SELECT * FROM Proyecto INNER JOIN");
        }

        public static DataTable ConsultarProyecto(Int64 ID)
        {
            return Conexion.consulta(string.Format("SELECT * FROM Proyecto WHERE ID = {0}", ID));
        }

        public bool BorrarProyecto(long ID, string otracosa, string mascosas)
        {
            string sql1 = "insert into Cartera(Estado_cartera,Total_Neto_Recaudado,Total_mora,Total_Cartera) values (@Estado_cartera,@Total_Neto_Recaudado,@Total_mora,@Total_Cartera)";
            SQLiteCommand cmd1 = new SQLiteCommand(sql1, Conexion.instanciaDb());
            cmd1.Parameters.Add(new SQLiteParameter("@Estado_cartera", ID));
            cmd1.Parameters.Add(new SQLiteParameter("@Total_Neto_Recaudado", otracosa));
            cmd1.Parameters.Add(new SQLiteParameter("@Total_mora", "0"));
            cmd1.Parameters.Add(new SQLiteParameter("@Total_Cartera", "0"));
            int retorno = cmd1.ExecuteNonQuery();
            ValidarInsert(retorno);
        }

        private void ValidarInsert(int retorno)
        {
            if (retorno == 0)
            {
                throw new Exception("Algo fallo");
            }
        }
    }
}
