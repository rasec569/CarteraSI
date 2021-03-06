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

	class MCartera
	{
		public int Id_Cartera { get; set; }
		public string Estado_cartera { get; set; }
		public string Total_Neto_Recaudado { get; set; }
		public string Total_Mora { get; set; }
		public string Total_Cartera { get; set; }

		internal static int crearCartera()
		{
			string sql1 = "insert into Cartera(Estado_cartera,Valor_Recaudado,Valor_Mora,Total_Cartera) values (@Estado_cartera,@Valor_Recaudado,@Valor_Mora,@Total_Cartera)";
			SQLiteCommand cmd1 = new SQLiteCommand(sql1, Conexion.instanciaDb());
			cmd1.Parameters.Add(new SQLiteParameter("@Estado_cartera", "Nueva"));
			cmd1.Parameters.Add(new SQLiteParameter("@Valor_Recaudado", "0"));
			cmd1.Parameters.Add(new SQLiteParameter("@Valor_Mora", "0"));
			cmd1.Parameters.Add(new SQLiteParameter("@Total_Cartera", "0"));
			return cmd1.ExecuteNonQuery();
		}

        internal static DataTable ActulizarValorTotal(int clienteid, int carteraid)
        {
			return Conexion.consulta("UPDATE Cartera SET Total_Cartera=(SELECT sum(Valor_Producto) FROM Producto INNER JOIN Cliente_Producto on Pfk_ID_Producto= Id_Producto WHERE Pfk_ID_Cliente = '"+clienteid+ "' GROUP by Id_Producto=Id_Producto) WHERE Id_Cartera='" + carteraid + "'");
        }

        internal static DataTable ListarCartera()
        {
			return Conexion.consulta("SELECT Id_Cliente, Cedula, Nombre, Apellido, Estado_cartera, Valor_Recaudado, count(Id_Producto) as productos, Valor_Mora, Total_Cartera, Id_Cartera FROM Cartera INNER JOIN Cliente on Fk_Id_Cartera= Id_Cartera INNER JOIN Cliente_Producto on Pfk_ID_Cliente= Id_Cliente INNER JOIN Producto on Id_Producto= Pfk_ID_Producto WHERE Estado_Cliente = 'Activo' GROUP by Id_Cliente");
        }

		internal static DataTable UltimoRegistro()
        {
			return Conexion.consulta("SELECT max(Id_Cartera) FROM Cartera ORDER BY Id_Cartera DESC");
		}
		internal static DataTable ActulizarValorRecaudado(int productoid, int carteraid )
        {
			return Conexion.consulta("UPDATE Cartera SET Valor_Recaudado=(SELECT sum(Valor_Pagado) FROM Pagos WHERE Fk_Id_Producto = '"+ productoid + "' GROUP by Fk_Id_Producto=Fk_Id_Producto) WHERE Id_Cartera='"+ carteraid + "'");
		}
	}
}
