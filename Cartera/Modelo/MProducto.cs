using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data;
using Cartera.Controlador;

namespace Cartera.Modelo
{
    class MProducto { 

        public int ID_Producto { get; set; }
        public string Nombre_Producto { get; set; }
        public string Numero_contrato { get; set; }
        public string Forma_pago { get; set; }
        //public string Tipo_producto { get; set; }
        public int Valor_Producto { get; set; }
        //public int Valor_30 { get; set; }
        //public int Valor_Entrada { get; set; }
        //public int Cuotas_30 { get; set; }
        //public int Valor_70 { get; set; }
        //public int Cuotas_70 { get; set; }
        //public int Valor_intereses { get; set; }
        public DateTime Fecha_Venta { get; set; }
        public string Observaciones { get; set; }
        public int Id_Proyecto { get; set; }
        public int Tipo_Producto { get; set; }
        public int Id_Financiacion { get; set; }

        public static DataTable cargarProductos(){
            return Conexion.consulta("SELECT Id_Producto, Nombre_Producto, Numero_contrato, Forma_pago, Valor_Producto, Fecha_Venta, Valor_Entrada, Proyecto_Nombre, Nom_Tipo_Producto, Valor_Sin_interes, Cuotas_Sin_interes, Valor_Cuota_Sin_interes, Valor_Con_Interes, Cuotas_Con_Interes, Valor_Cuota_Con_Interes, Valor_Interes, Fecha_Recaudo, Observaciones, Fk_Id_Proyecto, Fk_Id_Tipo_Producto FROM Producto INNER join Proyecto on Id_Proyecto = Fk_Id_Proyecto INNER join Tipo_Producto on Id_Tipo_Producto = Fk_Id_Tipo_Producto");
            //ajustar que celdas son porque estas son de la tabla vieja
        }

        public static DataTable cargarProductosCliente(int IdCliente){
            return Conexion.consulta("SELECT Id_Producto, Nombre_Producto, Numero_contrato, Forma_pago, Valor_Producto, Fecha_Venta, Observaciones, Proyecto_Nombre, Nom_Tipo_Producto, Id_Financiacion, Valor_Producto_Financiacion, Valor_Entrada, Valor_Sin_interes, Cuotas_Sin_interes, Valor_Cuota_Sin_interes, Valor_Con_Interes, Cuotas_Con_Interes, Valor_Cuota_Con_Interes, Valor_Interes, Fecha_Recaudo, Fk_Id_Proyecto, Fk_Id_Tipo_Producto FROM Cliente_Producto INNER JOIN Producto on Id_Producto=Pfk_ID_Producto INNER join Proyecto on Id_Proyecto = Fk_Id_Proyecto INNER join Tipo_Producto on Id_Tipo_Producto = Fk_Id_Tipo_Producto INNER JOIN Financiacion on Fk_Producto= Id_Producto WHERE Pfk_ID_Cliente = " + IdCliente + "");
            //ajustar consulta porque falta tener en cuenta la tabla de Cliente_Producto en el join
        }

        public static int crearProducto(string Nombre_Producto, string Numero_contrato,string Forma_Pago,int Valor_Producto,string Fecha_Venta,string Observaciones,int Fk_Id_Proyecto,int Fk_Id_Tipo_Producto){
        string sql = "INSERT INTO Producto(Nombre_Producto, Numero_contrato, Forma_Pago, Valor_Producto, Fecha_Venta, Observaciones, Fk_Id_Proyecto, Fk_Id_Tipo_Producto) VALUES(@Nombre_Producto, @Numero_contrato, @Forma_Pago, @Valor_Producto, @Fecha_Venta, @Observaciones, @Fk_Id_Proyecto, @Fk_Id_Tipo_Producto)";
                            SQLiteCommand cmd = new SQLiteCommand(sql, Conexion.instanciaDb());
                            cmd.Parameters.Add(new SQLiteParameter("@Nombre_Producto", Nombre_Producto));
                            cmd.Parameters.Add(new SQLiteParameter("@Numero_contrato", Numero_contrato));
                            cmd.Parameters.Add(new SQLiteParameter("@Forma_Pago", Forma_Pago));
                            cmd.Parameters.Add(new SQLiteParameter("@Valor_Producto", Valor_Producto));                            
                            cmd.Parameters.Add(new SQLiteParameter("@Fecha_Venta", Fecha_Venta));
                            cmd.Parameters.Add(new SQLiteParameter("@Observaciones", Observaciones));
                            cmd.Parameters.Add(new SQLiteParameter("@Fk_Id_Proyecto", Fk_Id_Proyecto));
                            cmd.Parameters.Add(new SQLiteParameter("@Fk_Id_Tipo_Producto", Fk_Id_Tipo_Producto));
                            return cmd.ExecuteNonQuery();
        }

        public static int actualizarProducto(int id_Producto, string Nombre_Producto, string Numero_contrato,string Forma_Pago,int Valor_Producto,string Fecha_Venta,string Observaciones,int Fk_Id_Proyecto,int Fk_Id_Tipo_Producto){
            string sql = "UPDATE Producto SET Nombre_Producto=@Nombre_Producto , Numero_contrato=@Numero_contrato, Forma_Pago=@Forma_Pago, Valor_Producto=@Valor_Producto, Fecha_Venta=@Fecha_Venta Observaciones=@Observaciones, Fk_Id_Proyecto=@Fk_Id_Proyecto, Fk_Id_Tipo_Producto=@Fk_Id_Tipo_Producto WHERE Id_Producto =" + id_Producto + "";
                            SQLiteCommand cmd = new SQLiteCommand(sql, Conexion.instanciaDb());
                            cmd.Parameters.Add(new SQLiteParameter("@Nombre_Producto", Nombre_Producto));
                            cmd.Parameters.Add(new SQLiteParameter("@Numero_contrato", Numero_contrato));
                            cmd.Parameters.Add(new SQLiteParameter("@Forma_Pago", Forma_Pago));
                            cmd.Parameters.Add(new SQLiteParameter("@Valor_Producto", Valor_Producto));
                            cmd.Parameters.Add(new SQLiteParameter("@Fecha_Venta", Fecha_Venta));
                            cmd.Parameters.Add(new SQLiteParameter("@Observaciones", Observaciones));
                            cmd.Parameters.Add(new SQLiteParameter("@Fk_Id_Proyecto", Fk_Id_Proyecto));
                            cmd.Parameters.Add(new SQLiteParameter("@Fk_Id_Tipo_Producto", Fk_Id_Tipo_Producto));
                            return cmd.ExecuteNonQuery();
        }

        public static DataTable ultimoProducto()
        {
            return Conexion.consulta("SELECT max(Id_Producto) FROM Producto ORDER BY Id_Producto DESC");
        }

    }
}
