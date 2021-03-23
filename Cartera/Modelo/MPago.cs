using System;
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

        internal static DataTable ConsultarUltimaCuota(int productoid)
        {
            return Conexion.consulta("Select max(Numero_Cuota)  from Pagos where Fk_Id_Producto = '"+ productoid + "'");
            throw new NotImplementedException();
        }

        internal static int RegistrarPago(string porcentaje, string numero_Cuota, string fecha_Pago, string referencia_Pago, string valor_Pagado, string descuento, string valor_Descuento, string fk_Id_Producto)
        {
            string sql = "INSERT INTO Pagos(Porcentaje, Numero_Cuota, Fecha_Pago, Referencia_Pago, Valor_Pagado, Descuento, Valor_Descuento, Fk_Id_Producto)VALUES(@Porcentaje, @Numero_Cuota, @Fecha_Pago, @Referencia_Pago, @Valor_Pagado, @Descuento, @Valor_Descuento, @Fk_Id_Producto)";
            SQLiteCommand cmd = new SQLiteCommand(sql, Conexion.instanciaDb());
            cmd.Parameters.Add(new SQLiteParameter("@Porcentaje", porcentaje));
            cmd.Parameters.Add(new SQLiteParameter("@Numero_Cuota", numero_Cuota));
            cmd.Parameters.Add(new SQLiteParameter("@Fecha_Pago", fecha_Pago));
            cmd.Parameters.Add(new SQLiteParameter("@Referencia_Pago", referencia_Pago));
            cmd.Parameters.Add(new SQLiteParameter("@Valor_Pagado", valor_Pagado));
            cmd.Parameters.Add(new SQLiteParameter("@Descuento", descuento));
            cmd.Parameters.Add(new SQLiteParameter("@Valor_Descuento", valor_Descuento));
            cmd.Parameters.Add(new SQLiteParameter("@Fk_Id_Producto", fk_Id_Producto));
            return cmd.ExecuteNonQuery();
        }

        internal static DataTable ListarPagosCliente(string productoid)
        {
            return Conexion.consulta("SELECT  Numero_Cuota as 'N° Cuota', Valor_Pagado as 'Valor', Fecha_Pago as Fecha, Referencia_Pago as Referencia, Descuento,Valor_Descuento as  'Valor Descuento' FROM Pagos WHERE Fk_Id_Producto = '" + productoid + "'");
        }
        internal static DataTable Tota_Recaudado_Producto(string productoid)
        {
            return Conexion.consulta("SELECT  Sum(Valor_Pagado) FROM Pagos WHERE Fk_Id_Producto ='" + productoid + "';");
        }

        internal static DataTable SumarValorRecaudado(string productoid)
        {
            return Conexion.consulta("SELECT sum(Valor_Pagado) FROM Pagos WHERE Fk_Id_Producto = '"+ productoid + "' GROUP by Fk_Id_Producto=Fk_Id_Producto.");
        }
    }
}
