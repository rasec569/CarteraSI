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
			string sql1 = "insert into Cartera(Estado_cartera,Valor_Recaudado,Saldo,Total_Cartera) values (@Estado_cartera,@Valor_Recaudado,@Saldo,@Total_Cartera)";
			SQLiteCommand cmd1 = new SQLiteCommand(sql1, Conexion.instanciaDb());
			cmd1.Parameters.Add(new SQLiteParameter("@Estado_cartera", "Nueva"));
			cmd1.Parameters.Add(new SQLiteParameter("@Valor_Recaudado", "0"));
			cmd1.Parameters.Add(new SQLiteParameter("@Saldo", "0"));
			cmd1.Parameters.Add(new SQLiteParameter("@Total_Cartera", "0"));
			return cmd1.ExecuteNonQuery();
		}

        internal static DataTable ActulizarValorTotal(int clienteid, int carteraid)
        {

			return Conexion.consulta("UPDATE Cartera SET Total_Cartera=(SELECT sum(Valor_Producto) FROM Producto INNER JOIN Cliente_Producto on Pfk_ID_Producto= Id_Producto WHERE Pfk_ID_Cliente = '"+clienteid+ "' GROUP by Id_Producto=Id_Producto) WHERE Id_Cartera='" + carteraid + "'");
        }

        internal static int ActulizarEstados(string carteraid,string estado)
        {
			string sql = "UPDATE Cartera SET Estado_cartera = @Estado_cartera WHERE Id_Cartera='"+ carteraid + "';";
			SQLiteCommand cmd = new SQLiteCommand(sql, Conexion.instanciaDb());
			cmd.Parameters.Add(new SQLiteParameter("@Estado_cartera", estado));
			return cmd.ExecuteNonQuery();

			throw new NotImplementedException();
        }

        internal static DataTable BuscarFechaspagos(int productoid)
        {
			return Conexion.consulta("SELECT Fecha_Pago, Fecha_Recaudo, Nombre_Producto, max(Id_Financiacion) as  Id_Financiacion,max(Numero_Cuota) as Cuotas_Pagadas FROM Producto INNER JOIN Pagos on Fk_Id_Producto= Id_Producto LEFT JOIN Financiacion on Fk_Producto=Id_Producto WHERE Id_Producto='" + productoid + "'");

		}

        internal static DataTable ListarCartera()
        {
            //return Conexion.consulta("SELECT Id_Cliente, Cedula, Nombre, Apellido, Estado_cartera, Valor_Recaudado, Id_Producto, Nombre_Producto, Valor_Mora, Total_Cartera, Id_Cartera FROM Cartera INNER JOIN Cliente on Fk_Id_Cartera= Id_Cartera INNER JOIN Cliente_Producto on Pfk_ID_Cliente= Id_Cliente INNER JOIN Producto on Id_Producto= Pfk_ID_Producto WHERE Estado_Cliente = 'Activo' ORDER by Nombre");
            return Conexion.consulta("SELECT Id_Cliente, Cedula, Nombre as Nombres, Apellido as Apellidos, Estado_cartera as Pago , Valor_Recaudado as Recaudado, count(Id_Producto) as Productos, Saldo, Total_Cartera as Total, Id_Cartera FROM Cartera INNER JOIN Cliente on Fk_Id_Cartera= Id_Cartera INNER JOIN Cliente_Producto on Pfk_ID_Cliente= Id_Cliente INNER JOIN Producto on Id_Producto= Pfk_ID_Producto WHERE Estado_Cliente = 'Activo' GROUP by Id_Cliente ORDER by Nombre");
        }
		internal static DataTable CarteraCliente(string cedula)
		{
            return Conexion.consulta("SELECT Id_Cliente, Cedula, Nombre as Nombres, Apellido as Apellidos, Estado_cartera as Pago, Valor_Recaudado as Recaudado, count(Id_Producto) as productos, Saldo, Total_Cartera as Total, Id_Cartera FROM Cartera INNER JOIN Cliente on Fk_Id_Cartera= Id_Cartera INNER JOIN Cliente_Producto on Pfk_ID_Cliente= Id_Cliente INNER JOIN Producto on Id_Producto= Pfk_ID_Producto WHERE Estado_Cliente = 'Activo' and Cedula='" + cedula + "' GROUP by Id_Cliente");
            //return Conexion.consulta("SELECT Id_Cliente, Cedula, Nombre, Apellido, Estado_cartera, Valor_Recaudado, Id_Producto, Nombre_Producto, Valor_Mora, Total_Cartera, Id_Cartera FROM Cartera INNER JOIN Cliente on Fk_Id_Cartera= Id_Cartera INNER JOIN Cliente_Producto on Pfk_ID_Cliente= Id_Cliente INNER JOIN Producto on Id_Producto= Pfk_ID_Producto WHERE Estado_Cliente = 'Activo' and Cedula='" + cedula + "'");
        }

		internal static DataTable UltimoRegistro()
        {
			return Conexion.consulta("SELECT max(Id_Cartera) FROM Cartera ORDER BY Id_Cartera DESC");
		}
		internal static int ActulizarValorRecaudado(int productoid, int carteraid )
        {
			string sql = "UPDATE Cartera SET Valor_Recaudado=(SELECT sum(Valor_Pagado) FROM Pagos WHERE Fk_Id_Producto = '" + productoid + "' GROUP by Fk_Id_Producto=Fk_Id_Producto) WHERE Id_Cartera='" + carteraid + "'";
			//string sql = "UPDATE Cartera SET Valor_Recaudado=(SELECT sum(Valor_Pagado), FROM Pagos WHERE Fk_Id_Producto = '" + productoid + "' GROUP by Fk_Id_Producto=Fk_Id_Producto) WHERE Id_Cartera='" + carteraid + "'";
			SQLiteCommand cmd = new SQLiteCommand(sql, Conexion.instanciaDb());
			return cmd.ExecuteNonQuery();
		}
		internal static int ActulizarSaldo(int carteraid)
		{
			string sql = "UPDATE Cartera SET Saldo=(Total_Cartera-Valor_Recaudado) WHERE Id_Cartera='" + carteraid + "'";
			//string sql = "UPDATE Cartera SET Valor_Recaudado=(SELECT sum(Valor_Pagado), FROM Pagos WHERE Fk_Id_Producto = '" + productoid + "' GROUP by Fk_Id_Producto=Fk_Id_Producto) WHERE Id_Cartera='" + carteraid + "'";
			SQLiteCommand cmd = new SQLiteCommand(sql, Conexion.instanciaDb());
			return cmd.ExecuteNonQuery();
		}
		internal static DataTable TotalesCartera()
		{
			//return Conexion.consulta("SELECT Id_Cliente, Cedula, Nombre, Apellido, Estado_cartera, Valor_Recaudado, Id_Producto, Nombre_Producto, Valor_Mora, Total_Cartera, Id_Cartera FROM Cartera INNER JOIN Cliente on Fk_Id_Cartera= Id_Cartera INNER JOIN Cliente_Producto on Pfk_ID_Cliente= Id_Cliente INNER JOIN Producto on Id_Producto= Pfk_ID_Producto WHERE Estado_Cliente = 'Activo' ORDER by Nombre");
			return Conexion.consulta("SELECT sum(Valor_Recaudado) as recaudo, sum(Saldo) as saldo, sum(Total_Cartera) as total from Cartera INNER JOIN Cliente on Fk_Id_Cartera=Id_Cartera INNER JOIN Cliente_Producto on Pfk_ID_Cliente= Id_Cliente WHERE Estado_Cliente='Activo';");
		}
	}
}
