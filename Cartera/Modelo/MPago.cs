﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cartera.Modelo
{
    class MPago
    {
        public int Id_Pagos { get; set; }
        public string Procentaje { get; set; }
        public int Numero_Cuota { get; set; }
        public string Fecha_Pago { get; set; }
        public string Referencia_Pago { get; set; }  
        public int Valor_Pagado { get; set; }

        

        public string Descuento { get; set; }
        public int Valor_Descuento { get; set; }

        internal static DataTable ConsultarUltimaCuotaPagada(int productoid)
        {
            return Conexion.consulta("Select Numero_Cuota, max(Fecha_Pago),Porcentaje from Pagos where Fk_Id_Producto = '" + productoid + "';");
            throw new NotImplementedException();
        }
        
        internal static DataTable ConsultarCuotas(int productoid, string tipo)
        {
            return Conexion.consulta("Select max(Numero_Cuota) as cuotas from Pagos where Fk_Id_Producto = '" + productoid + "'AND Porcentaje like '"+tipo+"';");
            throw new NotImplementedException();
        }
        internal static int RegistrarPago(string porcentaje, string numero_Cuota, string fecha_Pago, string Concepto, string Entidad, string referencia_Pago, double valor_Pagado, string descuento, double valor_Descuento, string fk_Id_Producto)
        {
            string sql = "INSERT INTO Pagos(Porcentaje, Numero_Cuota, Fecha_Pago, Concepto, Entidad, Referencia_Pago, Valor_Pagado, Descuento, Valor_Descuento, Fk_Id_Producto)VALUES(@Porcentaje, @Numero_Cuota, @Fecha_Pago, @Concepto, @Entidad, @Referencia_Pago, @Valor_Pagado, @Descuento, @Valor_Descuento, @Fk_Id_Producto)";
            SQLiteCommand cmd = new SQLiteCommand(sql, Conexion.instanciaDb());
            cmd.Parameters.Add(new SQLiteParameter("@Porcentaje", porcentaje));
            cmd.Parameters.Add(new SQLiteParameter("@Numero_Cuota", numero_Cuota));
            cmd.Parameters.Add(new SQLiteParameter("@Fecha_Pago", fecha_Pago));
            cmd.Parameters.Add(new SQLiteParameter("@Concepto", Concepto));
            cmd.Parameters.Add(new SQLiteParameter("@Entidad", Entidad));
            cmd.Parameters.Add(new SQLiteParameter("@Referencia_Pago", referencia_Pago));
            cmd.Parameters.Add(new SQLiteParameter("@Valor_Pagado", valor_Pagado));
            cmd.Parameters.Add(new SQLiteParameter("@Descuento", descuento));
            cmd.Parameters.Add(new SQLiteParameter("@Valor_Descuento", valor_Descuento));
            cmd.Parameters.Add(new SQLiteParameter("@Fk_Id_Producto", fk_Id_Producto));
            return cmd.ExecuteNonQuery();
        }

        

        internal static int EliminarPago(int idpago)
        {
            string sql = "DELETE FROM Pagos WHERE Id_Pagos = '" + idpago + "'";
            SQLiteCommand cmd = new SQLiteCommand(sql, Conexion.instanciaDb());
            return cmd.ExecuteNonQuery();
        }

        internal static int ActulizarPago(int idpago, string porcentaje, string numero_Cuota, string fecha_Pago, string Concepto, string Entidad, string referencia_Pago, string valor_Pagado, string descuento, string valor_Descuento)
        {
            string sql = "UPDATE Pagos SET Porcentaje=@Porcentaje, Numero_Cuota=@Numero_Cuota, Fecha_Pago=@Fecha_Pago, Concepto=@Concepto, Entidad=@Entidad, Referencia_Pago=@Referencia_Pago, Valor_Pagado=@Valor_Pagado, Descuento=@Descuento, Valor_Descuento=@Valor_Descuento WHERE Id_Pagos= " + idpago + ";";
            SQLiteCommand cmd = new SQLiteCommand(sql, Conexion.instanciaDb());
            cmd.Parameters.Add(new SQLiteParameter("@Porcentaje", porcentaje));
            cmd.Parameters.Add(new SQLiteParameter("@Numero_Cuota", numero_Cuota));
            cmd.Parameters.Add(new SQLiteParameter("@Fecha_Pago", fecha_Pago));
            cmd.Parameters.Add(new SQLiteParameter("@Concepto", Concepto));
            cmd.Parameters.Add(new SQLiteParameter("@Entidad", Entidad));
            cmd.Parameters.Add(new SQLiteParameter("@Referencia_Pago", referencia_Pago));
            cmd.Parameters.Add(new SQLiteParameter("@Valor_Pagado", valor_Pagado));
            cmd.Parameters.Add(new SQLiteParameter("@Descuento", descuento));
            cmd.Parameters.Add(new SQLiteParameter("@Valor_Descuento", valor_Descuento));
            return cmd.ExecuteNonQuery();
        }

        internal static DataTable ListarPagosCliente(string productoid)
        {
            return Conexion.consulta("SELECT  Id_Pagos, Numero_Cuota as 'Cuota', Porcentaje as 'Tipo', Concepto, Entidad, Valor_Pagado as 'Valor', Fecha_Pago as Fecha, Referencia_Pago as Referencia, Descuento,Valor_Descuento as  'Valor Descuento' FROM Pagos WHERE Fk_Id_Producto = '" + productoid + "' ORDER BY Porcentaje and Numero_Cuota and Fecha_Pago ");
        }
        internal static DataTable ReportesPagosCliente(string productoid)
        {
            return Conexion.consulta("SELECT  Numero_Cuota as 'Cuota', Porcentaje as 'Tipo', Concepto, Entidad, printf('% , d', Valor_Pagado) || substr(printf('%.2f', Valor_Pagado), instr(printf('%.2f', Valor_Pagado), '.'), length(printf('%.2f', Valor_Pagado)) - instr(printf('%.2f', Valor_Pagado), '.') + 1) as 'Valor', Fecha_Pago as Fecha, Referencia_Pago as Referencia, Descuento,printf('% , d', Valor_Descuento) || substr(printf('%.2f', Valor_Descuento), instr(printf('%.2f', Valor_Descuento), '.'), length(printf('%.2f', Valor_Descuento)) - instr(printf('%.2f', Valor_Descuento), '.') + 1) as  'Valor Descuento' FROM Pagos WHERE Fk_Id_Producto = '" + productoid + "' ORDER BY Fecha_Pago,Porcentaje,Numero_Cuota ");
        }

        internal static DataTable Tota_Recaudado_Producto(string productoid)
        {
            return Conexion.consulta("SELECT  Sum(Valor_Pagado) FROM Pagos WHERE Fk_Id_Producto ='" + productoid + "';");
        }

        internal static DataTable SumarValorRecaudado(string productoid)
        {
            return Conexion.consulta("SELECT sum(Valor_Pagado) FROM Pagos WHERE Fk_Id_Producto = '"+ productoid + "' GROUP by Fk_Id_Producto=Fk_Id_Producto.");
        }
        internal static DataTable reportPagos(string FechaInicio, string FechaFin)
        {
            return Conexion.consulta("SELECT Nombre_Producto as Producto, Numero_Cuota as 'Cuota', Porcentaje as 'Tipo pago', Concepto, Fecha_Pago as Fecha, Referencia_Pago as Referencia, printf('%, d', Valor_Pagado)|| substr(printf('%.2f', Valor_Pagado), instr(printf('%.2f', Valor_Pagado), '.'), length(printf('%.2f', Valor_Pagado)) - instr(printf('%.2f', Valor_Pagado), '.') + 1) as Valor, Descuento, printf('%, d', Valor_Descuento) as'Valor Descuento' FROM Pagos INNER JOIN Producto on Id_Producto= Fk_Id_Producto INNER join Cliente_Producto on Pfk_ID_Producto=Id_Producto WHERE Estado_Cliente='Activo' and Fecha_Pago BETWEEN '" + FechaInicio + "' AND '" + FechaFin + "';");
        }
        internal static DataTable reportPagosTipo(string FechaInicio, string FechaFin, string Tipo)
        {
            return Conexion.consulta("SELECT Nombre_Producto as Producto, Numero_Cuota as 'Cuota', Porcentaje as 'Tipo pago', Concepto, Fecha_Pago as Fecha, Referencia_Pago as Referencia, printf('%, d', Valor_Pagado) as Valor, Descuento, printf('%, d', Valor_Descuento) as'Valor Descuento' FROM Pagos INNER JOIN Producto on Id_Producto= Fk_Id_Producto INNER join Cliente_Producto on Pfk_ID_Producto=Id_Producto  WHERE Estado_Cliente='Activo' and Fk_Id_Tipo_Producto = '" + Tipo + "' AND Fecha_Pago BETWEEN '" + FechaInicio + "' AND '" + FechaFin + "';");
        }         
        internal static DataTable reportPagosProyecto(string FechaInicio, string FechaFin, string proyecto)
        {
            return Conexion.consulta("SELECT Nombre_Producto as Producto, Numero_Cuota as 'Cuota', Porcentaje as 'Tipo pago', Concepto, Fecha_Pago as Fecha, Referencia_Pago as Referencia, printf('%, d', Valor_Pagado) as Valor, Descuento, printf('%, d', Valor_Descuento) as'Valor Descuento' FROM Pagos INNER JOIN Producto on Id_Producto= Fk_Id_Producto INNER join Cliente_Producto on Pfk_ID_Producto=Id_Producto WHERE Estado_Cliente='Activo' and Fk_Id_Proyecto= '" + proyecto+"' AND Fecha_Pago BETWEEN '" + FechaInicio + "' AND '" + FechaFin + "';");
        }
        internal static DataTable reportPagosProyectoTipo(string FechaInicio, string FechaFin, string proyecto, string Tipo)
        {
            return Conexion.consulta("SELECT Nombre_Producto as Producto, Numero_Cuota as 'Cuota', Porcentaje as 'Tipo pago', Concepto, Fecha_Pago as Fecha, Referencia_Pago as Referencia, printf('%, d', Valor_Pagado) as Valor, Descuento, printf('%, d', Valor_Descuento) as'Valor Descuento' FROM Pagos INNER JOIN Producto on Id_Producto= Fk_Id_Producto INNER join Cliente_Producto on Pfk_ID_Producto=Id_Producto WHERE Estado_Cliente='Activo' and Fk_Id_Proyecto= '" + proyecto + "' AND Fk_Id_Tipo_Producto = '" + Tipo + "' AND Fecha_Pago BETWEEN '" + FechaInicio + "' AND '" + FechaFin + "';");
        }
        internal static DataTable ValorReportPagos(string FechaInicio, string FechaFin)
        {
            return Conexion.consulta("SELECT sum(Valor_Pagado) as valor, count(*) as pagos FROM Pagos INNER JOIN Producto on Id_Producto= Fk_Id_Producto INNER join Cliente_Producto on Pfk_ID_Producto=Id_Producto WHERE Estado_Cliente='Activo' and Fecha_Pago BETWEEN '" + FechaInicio + "' AND '" + FechaFin + "';");
        }
        internal static DataTable ValorReportPagosTipo(string FechaInicio, string FechaFin, string tipo)
        {
            return Conexion.consulta("SELECT sum(Valor_Pagado) as valor, count(*) as pagos FROM Pagos INNER JOIN Producto on Id_Producto= Fk_Id_Producto INNER join Cliente_Producto on Pfk_ID_Producto=Id_Producto WHERE Estado_Cliente='Activo' and Fk_Id_Tipo_Producto='" + tipo + "' AND Fecha_Pago BETWEEN '" + FechaInicio + "' AND '" + FechaFin + "';");
        }
        internal static DataTable ValorReportPagosProyecto(string fechaInicio, string fechaFin, string proyecto)
        {
            return Conexion.consulta("SELECT sum(Valor_Pagado) as valor, count(*) as pagos FROM Pagos INNER JOIN Producto on Id_Producto= Fk_Id_Producto INNER join Cliente_Producto on Pfk_ID_Producto=Id_Producto WHERE Estado_Cliente='Activo' and Fk_Id_Proyecto= '" + proyecto + "' AND Fecha_Pago BETWEEN '" + fechaInicio + "' AND '" + fechaFin + "';");
        }
        internal static DataTable ValorReportPagosProyectoTipo(string fechaInicio, string fechaFin, string proyecto, string tipo)
        {
            return Conexion.consulta("SELECT sum(Valor_Pagado) as valor, count(*) as pagos FROM Pagos INNER JOIN Producto on Id_Producto= Fk_Id_Producto INNER join Cliente_Producto on Pfk_ID_Producto=Id_Producto WHERE Estado_Cliente='Activo' and Fk_Id_Proyecto= '" + proyecto + "' AND Fk_Id_Tipo_Producto='" + tipo + "' AND Fecha_Pago BETWEEN '" + fechaInicio + "' AND '" + fechaFin + "';");
        }
        internal static DataTable PagosMes(string FechaInicio, string FechaFin)
        {
            return Conexion.consulta("SELECT printf('%, d', SUM(Valor_Pagado)) as Valor, strftime('%m-%Y', Fecha_Pago) as 'Mes-Año' FROM Pagos WHERE Fecha_Pago BETWEEN '" + FechaInicio + "' AND '" + FechaFin + "'group by strftime('%m-%Y', Fecha_Pago) ORDER BY Fecha_Pago;");
        }
        internal static DataTable PagosMesProyecto(string FechaInicio, string FechaFin, string proyecto)
        {
            return Conexion.consulta("SELECT printf('%, d', SUM(Valor_Pagado)) as Valor, strftime('%m-%Y', Fecha_Pago) as 'Mes-Año' FROM Pagos INNER JOIN Producto on Id_Producto= Fk_Id_Producto  WHERE Fk_Id_Proyecto= '" + proyecto + "' AND Fecha_Pago BETWEEN '" + FechaInicio + "' AND '" + FechaFin + "' group by strftime('%m-%Y', Fecha_Pago) ORDER BY Fecha_Pago;");
        }
    }
}
