using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cartera.Modelo
{
    class MCuota
    {
		internal static int crearcuota(int cuota, int valor, string tipo, string fecha, string Estado, int financiacion)
		{
			string sql1 = "INSERT INTO Cuotas(Num_Cuota, Valor_Cuota, Tipo, Fecha, Estado, Fk_Id_Financiacion) VALUES(@Num_Cuota, @Valor_Cuota, @Tipo, @Fecha, @Estado, @Fk_Id_Financiacion);";
			SQLiteCommand cmd1 = new SQLiteCommand(sql1, Conexion.instanciaDb());
			cmd1.Parameters.Add(new SQLiteParameter("@Num_Cuota", cuota));
			cmd1.Parameters.Add(new SQLiteParameter("@Valor_Cuota", valor));
			cmd1.Parameters.Add(new SQLiteParameter("@Tipo", tipo));
			cmd1.Parameters.Add(new SQLiteParameter("@Fecha", fecha));
			cmd1.Parameters.Add(new SQLiteParameter("@Estado", Estado));
			cmd1.Parameters.Add(new SQLiteParameter("@Fk_Id_Financiacion", financiacion));
			return cmd1.ExecuteNonQuery();
		}

        internal static DataTable CuotasPagadas(int financiacion)
        {
			//SELECT max(Num_Cuota) FROM Cuotas WHERE Fk_Id_Financiacion=" + financiacion + " AND Tipo= '"+tipo+"';
			//SELECT count(Estado) FROM Cuotas WHERE Fk_Id_Financiacion=" + financiacion + " AND Estado= 'Pagada'
			return Conexion.consulta("SELECT count(Estado) as cuotas FROM Cuotas WHERE Fk_Id_Financiacion=" + financiacion + " AND Estado= 'Pagada'");
		}
		internal static int EliminarCuotas(int financiacion)
		{
			string sql = "DELETE FROM Cuotas WHERE Fk_Id_Financiacion='" + financiacion + "'";
			SQLiteCommand cmd = new SQLiteCommand(sql, Conexion.instanciaDb());
			return cmd.ExecuteNonQuery();
		}

		internal static int actualizarcuota(int cuota, string Estado, int financiacion, string tipo)
		{			
			string sql1 = "UPDATE Cuotas SET Estado=@Estado WHERE Fk_Id_Financiacion = " + financiacion + " AND Num_Cuota  = " + cuota + " AND Tipo= '"+ tipo + "';";
			SQLiteCommand cmd1 = new SQLiteCommand(sql1, Conexion.instanciaDb());			
			cmd1.Parameters.Add(new SQLiteParameter("@Estado", Estado));
			return cmd1.ExecuteNonQuery();
		}
		internal static DataTable ListarCuotas(int financiacion)
		{

			return Conexion.consulta("SELECT Num_Cuota as '# Cuota', printf('% , d', Valor_Cuota)as Valor, Tipo, Fecha as 'Fecha Pactada', Estado FROM Cuotas WHERE Fk_Id_Financiacion='" + financiacion + "' ;");
		}
		internal static DataTable ListarCuotasInteres(int financiacion)
		{

			return Conexion.consulta("SELECT Num_Cuota as '# Cuota', printf('% , d', Valor_Cuota)as Valor, Tipo, Fecha as 'Fecha Pactada', Estado FROM Cuotas WHERE Fk_Id_Financiacion='" + financiacion + "' AND Tipo='Valor Saldo' ;");
		}
		internal static DataTable ListarCuotasInteres2(int financiacion)
		{

			return Conexion.consulta("SELECT Id_Cuota, Num_Cuota as '# Cuota', Fecha as 'Fecha Pactada', Estado, printf('% , d', Valor_Cuota)as Valor FROM Cuotas WHERE Fk_Id_Financiacion='" + financiacion + "' AND Tipo='Valor Saldo' ;");
		}
		internal static DataTable ListarCuotasActulizar(int financiacion, string fecha)
		{

			return Conexion.consulta("SELECT Num_Cuota as '# Cuota', printf('% , d', Valor_Cuota)as Valor, Tipo, Fecha as 'Fecha Pactada', Estado FROM Cuotas WHERE Fk_Id_Financiacion='" + financiacion + "' AND Fecha< '" + fecha + "';");
		}
		internal static DataTable reportProyeccion(string FechaInicio, string FechaFin)
		{
			return Conexion.consulta("SELECT Num_Cuota as 'Cuota', printf('% , d', Valor_Cuota) as 'Valor a Pagar', Nombre_Producto as Producto, Nombre as Nombres, Apellido as Apellidos, Fecha as 'Fecha Pago', Estado FROM Cuotas INNER JOIN Financiacion on Id_Financiacion=Fk_Id_Financiacion INNER JOIN Producto on Id_Producto=Fk_Producto INNER JOIN Cliente_Producto on Pfk_ID_Producto= Id_Producto INNER JOIN Cliente on Id_Cliente= Pfk_ID_Cliente WHERE Fecha BETWEEN '" + FechaInicio + "' AND '" + FechaFin + "' AND Estado_Financiacion= 'Activa' AND Estado_Cliente='Activo' ORDER BY Fecha;");
		}
		internal static DataTable reportProyeccionTipo(string FechaInicio, string FechaFin, string Tipo)
		{
			return Conexion.consulta("SELECT Num_Cuota as 'Cuota', printf('% , d', Valor_Cuota) as 'Valor a Pagar', Nombre_Producto as Producto, Nombre as Nombres, Apellido as Apellidos, Fecha as 'Fecha Pago', Estado FROM Cuotas INNER JOIN Financiacion on Id_Financiacion=Fk_Id_Financiacion INNER JOIN Producto on Id_Producto=Fk_Producto INNER JOIN Cliente_Producto on Pfk_ID_Producto= Id_Producto INNER JOIN Cliente on Id_Cliente= Pfk_ID_Cliente WHERE Fk_Id_Tipo_Producto = '" + Tipo + "' AND Fecha BETWEEN '" + FechaInicio + "' AND '" + FechaFin + "' AND Estado_Financiacion= 'Activa' AND Estado_Cliente='Activo' ORDER BY Fecha;");
		}
		internal static DataTable reportProyeccionProyecto(string FechaInicio, string FechaFin, string proyecto)
		{
			return Conexion.consulta("SELECT Num_Cuota as 'Cuota', printf('% , d', Valor_Cuota) as 'Valor a Pagar', Nombre_Producto as Producto, Nombre as Nombres, Apellido as Apellidos, Fecha as 'Fecha Pago', Estado FROM Cuotas INNER JOIN Financiacion on Id_Financiacion=Fk_Id_Financiacion INNER JOIN Producto on Id_Producto=Fk_Producto INNER JOIN Cliente_Producto on Pfk_ID_Producto= Id_Producto INNER JOIN Cliente on Id_Cliente= Pfk_ID_Cliente WHERE Fk_Id_Proyecto= '" + proyecto + "' AND Fecha BETWEEN '" + FechaInicio + "' AND '" + FechaFin + "' AND Estado_Financiacion= 'Activa' AND Estado_Cliente='Activo' ORDER BY Fecha;");
		}
		internal static DataTable reportProyeccionProyectoTipo(string FechaInicio, string FechaFin, string proyecto, string Tipo)
		{
			return Conexion.consulta("SELECT Num_Cuota as 'Cuota', printf('% , d', Valor_Cuota) as 'Valor a Pagar', Nombre_Producto as Producto, Nombre as Nombres, Apellido as Apellidos, Fecha as 'Fecha Pago', Estado FROM Cuotas INNER JOIN Financiacion on Id_Financiacion=Fk_Id_Financiacion INNER JOIN Producto on Id_Producto=Fk_Producto INNER JOIN Cliente_Producto on Pfk_ID_Producto= Id_Producto INNER JOIN Cliente on Id_Cliente= Pfk_ID_Cliente WHERE Fk_Id_Proyecto= '" + proyecto + "' AND Fk_Id_Tipo_Producto = '" + Tipo + "' AND Fecha BETWEEN '" + FechaInicio + "' AND '" + FechaFin + "' AND Estado_Financiacion= 'Activa' AND Estado_Cliente='Activo' ORDER BY Fecha;");
		}
		internal static DataTable PagosProgramados(int financiacion, string fecha)
        {
			return Conexion.consulta("SELECT sum(Valor_Cuota) as 'Valor Programado' FROM Cuotas where Fk_Id_Financiacion='" + financiacion + "' AND Fecha BETWEEN '2015-01-28' AND '" + fecha + "';");
        }
		internal static int UltimaActuliacionEstadosCuota(string Usuario, string fecha)
		{
			string sql = "UPDATE Usuario SET ActualizacionEstados = '" + fecha + "' WHERE Id_usuario = '" + Usuario + "';";
			SQLiteCommand cmd = new SQLiteCommand(sql, Conexion.instanciaDb());
			return cmd.ExecuteNonQuery();
		}
		internal static DataTable ValidarActulizacion(string Usuario)
		{
			return Conexion.consulta("SELECT ActualizacionEstados FROM Usuario where Id_usuario='" + Usuario + "';");
		}
		internal static DataTable ProyeccionMes(string FechaInicio, string FechaFin)
		{
			return Conexion.consulta("SELECT SUM(Valor_Cuota) as Valor, strftime('%m-%Y', Fecha) as 'Mes-Año'  FROM Cuotas INNER JOIN Financiacion on Id_Financiacion=Fk_Id_Financiacion INNER JOIN Producto on Id_Producto=Fk_Producto INNER JOIN Cliente_Producto on Pfk_ID_Producto= Id_Producto INNER JOIN Cliente on Id_Cliente= Pfk_ID_Cliente WHERE Fecha BETWEEN '" + FechaInicio + "' AND '" + FechaFin + "'AND Estado_Financiacion= 'Activa' AND Estado_Cliente='Activo' group by strftime('%m-%Y', Fecha) ORDER BY Fecha;");
		}
		internal static DataTable ProyeccionMesProyecto(string FechaInicio, string FechaFin, string proyecto)
		{
			return Conexion.consulta("SELECT SUM(Valor_Cuota) as Valor, strftime('%m-%Y', Fecha) as 'Mes-Año'  FROM Cuotas INNER JOIN Financiacion on Id_Financiacion=Fk_Id_Financiacion INNER JOIN Producto on Id_Producto=Fk_Producto INNER JOIN Cliente_Producto on Pfk_ID_Producto= Id_Producto INNER JOIN Cliente on Id_Cliente= Pfk_ID_Cliente WHERE Fk_Id_Proyecto= '" + proyecto + "' AND Fecha BETWEEN '" + FechaInicio + "' AND '" + FechaFin + "'AND Estado_Financiacion= 'Activa' AND Estado_Cliente='Activo' group by strftime('%m-%Y', Fecha) ORDER BY Fecha;");
		}
	}
}
