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
			string sql1 = "insert into Cartera(Estado_cartera,Valor_Recaudado,Saldo,Total_Cartera) values (@Estado_cartera,@Valor_Recaudado,@Saldo,@Total_Cartera);";
			SQLiteCommand cmd1 = new SQLiteCommand(sql1, Conexion.instanciaDb());
			cmd1.Parameters.Add(new SQLiteParameter("@Estado_cartera", "Nueva"));
			cmd1.Parameters.Add(new SQLiteParameter("@Valor_Recaudado", "0"));
			cmd1.Parameters.Add(new SQLiteParameter("@Saldo", "0"));
			cmd1.Parameters.Add(new SQLiteParameter("@Total_Cartera", "0"));
			return cmd1.ExecuteNonQuery();
		}

        internal static DataTable ActulizarValorTotal(int clienteid, int carteraid)
        {

			return Conexion.consulta("UPDATE Cartera SET Total_Cartera=(SELECT sum(Valor_Producto) FROM Producto INNER JOIN Cliente_Producto on Pfk_ID_Producto= Id_Producto WHERE Pfk_ID_Cliente = '"+clienteid+ "' GROUP by Id_Producto=Id_Producto) WHERE Id_Cartera='" + carteraid + "';");
        }

        internal static int ActulizarEstados(string carteraid,string estado, int cuotas, int meses, int pagas, int mora)
        {
			string sql = "UPDATE Cartera SET Estado_cartera = @Estado_cartera, Cuotas=@Cuotas, Meses=@Meses, Pagas=@Pagas, Mora=@Mora WHERE Id_Cartera='" + carteraid + "';";
			SQLiteCommand cmd = new SQLiteCommand(sql, Conexion.instanciaDb());
			cmd.Parameters.Add(new SQLiteParameter("@Estado_cartera", estado));
			cmd.Parameters.Add(new SQLiteParameter("@Cuotas", cuotas));
			cmd.Parameters.Add(new SQLiteParameter("@Meses", meses));
			cmd.Parameters.Add(new SQLiteParameter("@Pagas", pagas));
			cmd.Parameters.Add(new SQLiteParameter("@Mora", mora));
			return cmd.ExecuteNonQuery();

			throw new NotImplementedException();
        }

        internal static DataTable BuscarFechaspagos(int productoid)
        {
			return Conexion.consulta("SELECT max(Fecha_Pago) as Fecha_Pago, Fecha_Recaudo, Cuotas_Sin_interes+Cuotas_Con_Interes as Cuotas, Cuotas_Sin_interes, Cuotas_Con_Interes, Nombre_Producto, max(Id_Financiacion) as  Id_Financiacion FROM Producto INNER JOIN Pagos on Fk_Id_Producto= Id_Producto LEFT JOIN Financiacion on Fk_Producto=Id_Producto WHERE Id_Producto='" + productoid + "';");
			//return Conexion.consulta("SELECT max(Fecha_Pago) as Fecha_Pago, Fecha_Recaudo, Cuotas_Sin_interes, Valor_Entrada, Valor_Sin_interes, Cuotas_Con_Interes, Valor_Cuota_Sin_interes, Valor_Con_Interes, Cuotas_Sin_interes+Cuotas_Con_Interes as Cuotas,  sum(Valor_Pagado) as Pagado, Nombre_Producto, max(Id_Financiacion) as  Id_Financiacion FROM Producto INNER JOIN Pagos on Fk_Id_Producto= Id_Producto LEFT JOIN Financiacion on Fk_Producto=Id_Producto WHERE Id_Producto='" + productoid + "';");

		}

        internal static DataTable ListarCartera()
        {
			//return Conexion.consulta("SELECT Id_Cliente, Cedula, Nombre, Apellido, Estado_cartera, Valor_Recaudado, Id_Producto, Nombre_Producto, Valor_Mora, Total_Cartera, Id_Cartera FROM Cartera INNER JOIN Cliente on Fk_Id_Cartera= Id_Cartera INNER JOIN Cliente_Producto on Pfk_ID_Cliente= Id_Cliente INNER JOIN Producto on Id_Producto= Pfk_ID_Producto WHERE Estado_Cliente = 'Activo' ORDER by Nombre");
			//return Conexion.consulta("SELECT Id_Cliente, Cedula, Nombre as Nombres, Apellido as Apellidos, Estado_cartera as Pago ,Cuotas as 'Cuotas Pact.', Pagas as 'Cuotas Pag.', Mora as 'Cuotas Mora', Meses  as 'Meses Mora', Valor_Recaudado as Recaudado, count(Id_Producto) as Productos, Saldo, Total_Cartera as Total, Id_Cartera FROM Cartera INNER JOIN Cliente on Fk_Id_Cartera= Id_Cartera INNER JOIN Cliente_Producto on Pfk_ID_Cliente= Id_Cliente INNER JOIN Producto on Id_Producto= Pfk_ID_Producto WHERE Estado_Cliente = 'Activo' GROUP by Id_Cliente ORDER by Nombre;");
			return Conexion.consulta("SELECT Id_Cliente, Cedula, Nombre as Nombres, Apellido as Apellidos, Estado_cartera as Pago, Cuotas as 'Cuotas Pact.', Pagas as 'Cuotas Pag.', Mora as 'Cuotas Mora', Meses  as 'Meses Mora', Valor_Recaudado as Recaudado, count(Id_Producto) as Products, Saldo, Total_Cartera as Total, Id_Cartera FROM Cartera INNER JOIN Cliente on Fk_Id_Cartera= Id_Cartera INNER JOIN Cliente_Producto on Pfk_ID_Cliente= Id_Cliente INNER JOIN Producto on Id_Producto= Pfk_ID_Producto WHERE Estado_Cliente = 'Activo' and Estado_cartera<>'Disuelto' GROUP by Id_Cliente ORDER by Nombre;");
        }
		internal static DataTable ListarCarteraProyecto(int proyectoid)
		{
			
			return Conexion.consulta("SELECT Id_Cliente, Cedula, Nombre as Nombres, Apellido as Apellidos, Estado_cartera as Pago, Cuotas as 'Cuotas Pact.', Pagas as 'Cuotas Pag.', Mora as 'Cuotas Mora', Meses  as 'Meses Mora', Valor_Recaudado as Recaudado, count(Id_Producto) as Products, Saldo, Total_Cartera as Total, Id_Cartera FROM Cartera INNER JOIN Cliente on Fk_Id_Cartera= Id_Cartera INNER JOIN Cliente_Producto on Pfk_ID_Cliente= Id_Cliente INNER JOIN Producto on Id_Producto= Pfk_ID_Producto WHERE Estado_Cliente = 'Activo' and Fk_Id_Proyecto= '" + proyectoid + "' and Estado_cartera<>'Disuelto' GROUP by Id_Cliente ORDER by Nombre;");
		}
		internal static DataTable CarteraCliente(string cedula)
		{
            return Conexion.consulta("SELECT Id_Cliente, Cedula, Nombre as Nombres, Apellido as Apellidos, Estado_cartera as Pago, Cuotas as 'Cuotas Pact.', Pagas as 'Cuotas Pag.', Mora as 'Cuotas Mora', Meses  as 'Meses Mora', Valor_Recaudado as Recaudado, count(Id_Producto) as Products, Saldo, Total_Cartera as Total, Id_Cartera FROM Cartera INNER JOIN Cliente on Fk_Id_Cartera= Id_Cartera INNER JOIN Cliente_Producto on Pfk_ID_Cliente= Id_Cliente INNER JOIN Producto on Id_Producto= Pfk_ID_Producto WHERE Estado_Cliente = 'Activo' and Cedula='" + cedula + "' GROUP by Id_Cliente;");
            //return Conexion.consulta("SELECT Id_Cliente, Cedula, Nombre, Apellido, Estado_cartera, Valor_Recaudado, Id_Producto, Nombre_Producto, Valor_Mora, Total_Cartera, Id_Cartera FROM Cartera INNER JOIN Cliente on Fk_Id_Cartera= Id_Cartera INNER JOIN Cliente_Producto on Pfk_ID_Cliente= Id_Cliente INNER JOIN Producto on Id_Producto= Pfk_ID_Producto WHERE Estado_Cliente = 'Activo' and Cedula='" + cedula + "'");
        }

		internal static DataTable UltimoRegistro()
        {
			return Conexion.consulta("SELECT max(Id_Cartera) FROM Cartera ORDER BY Id_Cartera DESC;");
		}
		internal static int ActulizarValorRecaudado(int carteraid )
        {
			string sql = "UPDATE Cartera SET Valor_Recaudado=(SELECT sum(Valor_Pagado) FROM Pagos INNER JOIN Producto on Id_Producto=Fk_Id_Producto INNER JOIN Cliente_Producto on Pfk_ID_Producto= Id_Producto INNER JOIN Cliente on Id_Cliente=Pfk_ID_Cliente INNER JOIN Cartera on Id_Cartera=Fk_Id_Cartera WHERE Id_Cartera ='" + carteraid + "' AND Estado_Cliente='Activo') WHERE Id_Cartera='" + carteraid + "';";
			//string sql = "UPDATE Cartera SET Valor_Recaudado=(SELECT sum(Valor_Pagado) FROM Pagos WHERE Fk_Id_Producto = '" + productoid + "' GROUP by Fk_Id_Producto=Fk_Id_Producto) WHERE Id_Cartera='" + carteraid + "'";
			//string sql = "UPDATE Cartera SET Valor_Recaudado=(SELECT sum(Valor_Pagado), FROM Pagos WHERE Fk_Id_Producto = '" + productoid + "' GROUP by Fk_Id_Producto=Fk_Id_Producto) WHERE Id_Cartera='" + carteraid + "'";
			SQLiteCommand cmd = new SQLiteCommand(sql, Conexion.instanciaDb());
			return cmd.ExecuteNonQuery();
		}
		internal static int ActulizarSaldo(int carteraid)
		{
			string sql = "UPDATE Cartera SET Saldo=(Total_Cartera-Valor_Recaudado) WHERE Id_Cartera='" + carteraid + "';";
			//string sql = "UPDATE Cartera SET Valor_Recaudado=(SELECT sum(Valor_Pagado), FROM Pagos WHERE Fk_Id_Producto = '" + productoid + "' GROUP by Fk_Id_Producto=Fk_Id_Producto) WHERE Id_Cartera='" + carteraid + "'";
			SQLiteCommand cmd = new SQLiteCommand(sql, Conexion.instanciaDb());
			return cmd.ExecuteNonQuery();
		}
		internal static DataTable TotalesCartera()
		{
			//return Conexion.consulta("SELECT Id_Cliente, Cedula, Nombre, Apellido, Estado_cartera, Valor_Recaudado, Id_Producto, Nombre_Producto, Valor_Mora, Total_Cartera, Id_Cartera FROM Cartera INNER JOIN Cliente on Fk_Id_Cartera= Id_Cartera INNER JOIN Cliente_Producto on Pfk_ID_Cliente= Id_Cliente INNER JOIN Producto on Id_Producto= Pfk_ID_Producto WHERE Estado_Cliente = 'Activo' ORDER by Nombre");
			//return Conexion.consulta("SELECT sum(Valor_Recaudado) as recaudo, sum(Saldo) as saldo, sum(Total_Cartera) as total from Cartera INNER JOIN Cliente on Fk_Id_Cartera=Id_Cartera where Id_Cliente=(select Id_Cliente from Cliente_Producto WHERE Estado_Cliente='Activo');");
			return Conexion.consulta("SELECT sum(Valor_Recaudado) as recaudo, sum(Saldo) as saldo, sum(Total_Cartera) as total from Cartera INNER JOIN Cliente on Fk_Id_Cartera=Id_Cartera where Id_Cliente=(select Id_Cliente from Cliente_Producto WHERE Estado_Cliente='Activo') AND Estado_cartera<>'Disuelto';");
		}
		internal static DataTable Disoluciones(string FechaInicio, string FechaFin)
		{
			return Conexion.consulta("SELECT Cedula, Nombre, Apellido, Nombre_Producto as Producto, Fecha_Cambio as Fecha, Valor_Recaudado as Aportado, Saldo, Total_Cartera as 'Valor Producto',Cuotas as 'Cuotas Pact.', Pagas as 'Cuotas Pag.', Mora as 'Cuotas Mora', Meses  as 'Meses Mora' FROM Cartera INNER JOIN Cliente on Fk_Id_Cartera= Id_Cartera INNER JOIN Cliente_Producto on Pfk_ID_Cliente=Id_Cliente INNER JOIN Producto on Id_Producto=Pfk_ID_Producto WHERE Estado_cartera='Disuelto' AND Fecha_Cambio BETWEEN '" + FechaInicio + "' AND '" + FechaFin + "';");
        }
		internal static DataTable TotalDisoluciones(string FechaInicio, string FechaFin)
		{
			return Conexion.consulta("SELECT sum(Valor_Recaudado) as 'Total Devuelto', count(Id_Cartera) as Cantiad  FROM Cartera INNER JOIN Cliente on Fk_Id_Cartera= Id_Cartera INNER JOIN Cliente_Producto on Pfk_ID_Cliente=Id_Cliente INNER JOIN Producto on Id_Producto=Pfk_ID_Producto WHERE Estado_cartera='Disuelto' AND Fecha_Cambio BETWEEN '" + FechaInicio + "' AND '" + FechaFin + "';");
		}

	}
}
