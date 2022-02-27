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
			string sql = "INSERT INTO Cuotas(Num_Cuota, Valor_Cuota, Tipo, Fecha, Estado, User_log_Cuota, Fk_Id_Financiacion) VALUES(@Num_Cuota, @Valor_Cuota, @Tipo, @Fecha, @Estado, @User_log_Cuota, @Fk_Id_Financiacion);";
			SQLiteCommand cmd = new SQLiteCommand(sql, Conexion.instanciaDb());
			try
			{
				cmd.Parameters.Add(new SQLiteParameter("@Num_Cuota", cuota));
				cmd.Parameters.Add(new SQLiteParameter("@Valor_Cuota", valor));
				cmd.Parameters.Add(new SQLiteParameter("@Tipo", tipo));
				cmd.Parameters.Add(new SQLiteParameter("@Fecha", fecha));
				cmd.Parameters.Add(new SQLiteParameter("@Estado", Estado));
				cmd.Parameters.Add(new SQLiteParameter("@User_log_Cuota", DtosUsuario.NombreUser));
				cmd.Parameters.Add(new SQLiteParameter("@Fk_Id_Financiacion", financiacion));
			}
			catch (Exception ex)
			{
				Console.WriteLine("Commit Exception Type: {0}", ex.GetType());
				Console.WriteLine("  Message: {0}", ex.Message);

			}
			return cmd.ExecuteNonQuery();

		}

        internal static int ModificarCuota(int idcuota, int cuota, int valor, string tipo, string fecha, string estado,int aporte)
        {
			string sql1 = "UPDATE Cuotas SET Num_Cuota=@Num_Cuota, Valor_Cuota=@Valor_Cuota, Tipo=@Tipo, Estado=@Estado, Fecha=@Fecha, Aporte_Pagos=@Aporte_Pagos, User_log_Cuota=@User_log_Cuota WHERE Id_Cuota = " + idcuota + ";";
			SQLiteCommand cmd1 = new SQLiteCommand(sql1, Conexion.instanciaDb());
			try
			{
				cmd1.Parameters.Add(new SQLiteParameter("@Num_Cuota", cuota));
				cmd1.Parameters.Add(new SQLiteParameter("@Valor_Cuota", valor));
				cmd1.Parameters.Add(new SQLiteParameter("@Tipo", tipo));
				cmd1.Parameters.Add(new SQLiteParameter("@Fecha", fecha));
				cmd1.Parameters.Add(new SQLiteParameter("@Estado", estado));
				cmd1.Parameters.Add(new SQLiteParameter("@Aporte_Pagos", aporte));				
				cmd1.Parameters.Add(new SQLiteParameter("@User_log_Cuota", DtosUsuario.NombreUser));
			}
			catch (Exception ex)
			{
				Console.WriteLine("Commit Exception Type: {0}", ex.GetType());
				Console.WriteLine("  Message: {0}", ex.Message);

			}
			return cmd1.ExecuteNonQuery();
			//throw new NotImplementedException();
        }

        internal static DataTable CuotasPagadas(int financiacion)
        {
			//SELECT max(Num_Cuota) FROM Cuotas WHERE Fk_Id_Financiacion=" + financiacion + " AND Tipo= '"+tipo+"';
			//SELECT count(Estado) FROM Cuotas WHERE Fk_Id_Financiacion=" + financiacion + " AND Estado= 'Pagada'
			return Conexion.consulta("SELECT count(Estado) as cuotas FROM Cuotas WHERE Fk_Id_Financiacion=" + financiacion + " AND Estado= 'Pagada'");
		}
		internal static DataTable CuotasPorPagar(int producto)
        {
			return Conexion.consulta("SELECT Id_Cuota, Num_Cuota, Valor_Cuota, Tipo, Estado, Fecha, Aporte_Pagos, Fk_Id_Financiacion, Valor_Interes FROM Cuotas INNER JOIN Financiacion ON Fk_Id_Financiacion = Id_Financiacion WHERE Fk_Producto = " + producto + " AND Estado_Financiacion = 'Activa' AND Estado <> 'Inactiva'AND Estado <> 'Pagada' ORDER BY Fecha, Num_Cuota;");
        }
		internal static int EliminarCuotas(int financiacion)
		{
			string sql = "DELETE FROM Cuotas WHERE Fk_Id_Financiacion='" + financiacion + "'";
			SQLiteCommand cmd = new SQLiteCommand(sql, Conexion.instanciaDb());
			return cmd.ExecuteNonQuery();
		}

		internal static int InactivarCuota(int cuota, string Estado, int financiacion, string tipo)
		{		
			
				string sql1 = "UPDATE Cuotas SET Estado=@Estado, User_log_Cuota=@User_log_Cuota WHERE Fk_Id_Financiacion = " + financiacion + " AND Num_Cuota  = " + cuota + " AND Tipo= '" + tipo + "';";
				SQLiteCommand cmd1 = new SQLiteCommand(sql1, Conexion.instanciaDb());
				try
				{
					cmd1.Parameters.Add(new SQLiteParameter("@Estado", Estado));
					cmd1.Parameters.Add(new SQLiteParameter("@User_log_Cuota", DtosUsuario.NombreUser));
				}
				catch (Exception ex)
				{
					Console.WriteLine("Commit Exception Type: {0}", ex.GetType());
					Console.WriteLine("  Message: {0}", ex.Message);

				}
				return cmd1.ExecuteNonQuery();
		}
		internal static DataTable ConsultarCuotaAPagar(int productoid, int cuota, string tipo)
		{
			return Conexion.consulta("SELECT IIF(Aporte_Pagos IS NULL, Valor_Cuota, Valor_Cuota - Aporte_Pagos) as Valor,	Estado FROM	Cuotas INNER JOIN Financiacion ON Fk_Id_Financiacion = Id_Financiacion WHERE Estado_Financiacion = 'Activa' AND Estado <> 'Inactiva' AND Fk_Producto = '" + productoid + "' AND Num_Cuota = '" + cuota + "' AND Tipo LIKE  '%" + tipo + "%';");
			throw new NotImplementedException();
		}
		internal static int ActulziarCuotaRegistroPago(int cuota, int aportes, string Estado, int financiacion, string tipo)
		{
			string sql1 = "UPDATE Cuotas SET  Aporte_Pagos=@Aporte_Pagos, Estado=@Estado, User_log_Cuota=@User_log_Cuota WHERE Fk_Id_Financiacion = " + financiacion + " AND Num_Cuota  = " + cuota + " AND Tipo LIKE '%" + tipo + "%';";
			SQLiteCommand cmd1 = new SQLiteCommand(sql1, Conexion.instanciaDb());
			try
			{
				cmd1.Parameters.Add(new SQLiteParameter("@Aporte_Pagos", aportes));
				cmd1.Parameters.Add(new SQLiteParameter("@Estado", Estado));
				cmd1.Parameters.Add(new SQLiteParameter("@User_log_Cuota", DtosUsuario.NombreUser));
			}
			catch (Exception ex)
			{
				Console.WriteLine("Commit Exception Type: {0}", ex.GetType());
				Console.WriteLine("  Message: {0}", ex.Message);

			}
			return cmd1.ExecuteNonQuery();
		}
		internal static DataTable ListarCuotas(int financiacion, string filtro, string estado)
		{

			return Conexion.consulta("SELECT Id_Cuota, Num_Cuota as 'Cuota', printf('% , d', Valor_Cuota)as Valor, Tipo, Fecha as 'Fecha',printf('% , d', Aporte_Pagos) as 'Aportado',Estado FROM Cuotas WHERE Fk_Id_Financiacion='" + financiacion + "' AND Tipo<>'" + filtro + "'AND Estado<>'" + estado + "';");
			//return Conexion.consulta("SELECT Num_Cuota as 'Cuota', printf('% , d', Valor_Cuota)as Valor, Tipo, Fecha as 'Fecha',printf('% , d', Aporte_Pagos) as 'Aportado',Estado FROM Cuotas WHERE Fk_Id_Financiacion='" + financiacion + "' AND Tipo<>'Refinanciación' ;");
		}

        internal static DataTable UltimoInicio()
        {
			return Conexion.consulta("SELECT max(Ultimo_Ingreso) as Ultimo_Ingreso FROM Usuario;");
		}

        internal static DataTable BalanceCuota(int cuota, int id_Producto, string tipo)
		{

			return Conexion.consulta("SELECT (SELECT Sum(Pagos.Valor_Pagado) FROM Pagos INNER JOIN Producto ON Pagos.Fk_Id_Producto = Producto.Id_Producto INNER JOIN Financiacion ON Producto.Id_Producto = Financiacion.Fk_Producto WHERE Pagos.Numero_Cuota = " + cuota + " AND Pagos.Fk_Id_Producto = " + id_Producto + " AND Financiacion.Estado_Financiacion = 'Activa' and Pagos.Porcentaje LIKE '%" + tipo + "%') as valor ,(SELECT sum(Pagos.Valor_Descuento) FROM Pagos	INNER JOIN Producto	ON Pagos.Fk_Id_Producto = Producto.Id_Producto INNER JOIN Financiacion ON Producto.Id_Producto = Financiacion.Fk_Producto WHERE Pagos.Numero_Cuota = " + cuota + " AND Pagos.Fk_Id_Producto = "+ id_Producto + " AND Financiacion.Estado_Financiacion = 'Activa' and Pagos.Porcentaje LIKE '%"+ tipo + "%') as descuento ,IIF((SELECT Sum(Pagos.Valor_Pagado) FROM Pagos INNER JOIN Producto ON Pagos.Fk_Id_Producto = Producto.Id_Producto INNER JOIN Financiacion ON Producto.Id_Producto = Financiacion.Fk_Producto WHERE Pagos.Numero_Cuota = " + cuota + " AND Pagos.Fk_Id_Producto = " + id_Producto + " AND	Financiacion.Estado_Financiacion = 'Activa' and	Pagos.Porcentaje LIKE '%" + tipo + "%') >= (SELECT Cuotas.Valor_Cuota FROM Cuotas INNER JOIN Financiacion ON Cuotas.Fk_Id_Financiacion = Financiacion.Id_Financiacion WHERE	Cuotas.Num_Cuota = " + cuota + " AND Financiacion.Fk_Producto = " + id_Producto + " AND Financiacion.Estado_Financiacion = 'Activa' AND Cuotas.Tipo LIKE '%" + tipo + "%' ), 'Pagada', 'Abono' ) result ;");
		}
		internal static int ValidarEstadoCuotas(string Fecha, string actulizado)
        {
			string sql1 = "UPDATE Cuotas as C set User_log_Cuota='Sistema', Estado=(SELECT IIF(Fecha>='" + Fecha + "', 'Pendiente', 'Mora') from Cuotas as C2 WHERE Estado<>'Pagada' and C.Id_Cuota=C2.Id_Cuota) WHERE Estado<>'Pagada' AND Estado<>'Inactiva' AND Fecha BETWEEN '" + actulizado + "' AND '" + Fecha + "'";
			SQLiteCommand cmd1 = new SQLiteCommand(sql1, Conexion.instanciaDb());
			return cmd1.ExecuteNonQuery();
		}
		internal static DataTable ListarCuotasInteres(int financiacion)
		{

			return Conexion.consulta("SELECT Num_Cuota as '# Cuota', printf('% , d', Valor_Cuota)as Valor, Tipo, Fecha as 'Fecha Pactada', Estado FROM Cuotas WHERE Fk_Id_Financiacion='" + financiacion + "' AND Tipo='Valor Saldo' ;");
		}
		internal static DataTable ListarCuotasInteres2(int financiacion)
		{

			return Conexion.consulta("SELECT Id_Cuota, Num_Cuota as '# Cuota', Fecha as 'Fecha Pago', Estado, printf('% , d', Valor_Cuota)as Valor, printf('% , d', Aporte_Pagos) as Aportado FROM Cuotas WHERE Fk_Id_Financiacion='" + financiacion + "' AND Tipo='Valor Saldo';");
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
			string sql = "UPDATE Usuario SET Ultimo_Ingreso = '" + fecha + "' WHERE Id_usuario = '" + Usuario + "';";
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
