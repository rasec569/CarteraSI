using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SQLite;
using Cartera.Controlador;

namespace Cartera.Modelo
{

	class MCartera:CCartera
	{
		public Int64 Id_Cartera { get; set; }
		public string Estado_cartera { get; set; }
		public string Total_Neto_Recaudado { get; set; }
		public string Total_Mora { get; set; }
		public string Total_Cartera { get; set; }

		public int crearCartera()
		{
			string sql1 = "insert into Cartera(Estado_cartera,Valor_Recaudado,Valor_Mora,Total_Cartera) values (@Estado_cartera,@Valor_Recaudado,@Valor_Mora,@Total_Cartera)";
			SQLiteCommand cmd1 = new SQLiteCommand(sql1, Conexion.instanciaDb());
			cmd1.Parameters.Add(new SQLiteParameter("@Estado_cartera", "Nueva"));
			cmd1.Parameters.Add(new SQLiteParameter("@Valor_Recaudado", "0"));
			cmd1.Parameters.Add(new SQLiteParameter("@Valor_Mora", "0"));
			cmd1.Parameters.Add(new SQLiteParameter("@Total_Cartera", "0"));
			return cmd1.ExecuteNonQuery();
		}
		public DataTable UltimoRegistro()
        {
			return Conexion.consulta("SELECT max(Id_Cartera) FROM Cartera ORDER BY Id_Cartera DESC");
		}
	}
}
