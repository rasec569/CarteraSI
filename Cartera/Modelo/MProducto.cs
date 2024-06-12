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
    class MProducto : MError
    {

        public int ID_Producto { get; set; }
        public string Nombre_Producto { get; set; }
        public string Numero_contrato { get; set; }
        public string Forma_pago { get; set; }        

        public int Valor_Producto { get; set; }
        public DateTime Fecha_Venta { get; set; }
        public string Observaciones { get; set; }
        public int Id_Proyecto { get; set; }
        public int Tipo_Producto { get; set; }
        public int Id_Financiacion { get; set; }

        public static DataTable cargarProductos()
        {
            return Conexion.consulta("SELECT Id_Producto, Nombre_Producto as Producto, Numero_contrato as Contrato, Forma_pago as 'Forma Pago', printf('%, d', Valor_Neto) as 'Valor Neto', printf('%, d', Valor_Producto) as 'Valor Total', Fecha_Venta as 'Fecha Venta', printf('%, d', Valor_Entrada) as 'Inicial', Proyecto_Nombre as Proyecto, Nom_Tipo_Producto as 'Tipo',printf('%, d', Valor_Sin_interes) as 'Valor Inicial', Cuotas_Sin_interes as 'Cuotas Inicial',printf('%, d', Valor_Cuota_Sin_interes)  as 'Valor Cuota Inicial', printf('%, d', Valor_Con_Interes) as 'Valor Saldo', Cuotas_Con_Interes as 'Cuotas Saldo',printf('%, d', Valor_Cuota_Con_Interes) as 'Valor Cuota Saldo', Valor_Interes as 'Interes', Fecha_Recaudo as 'Fecha Recaudo', Observaciones, Fk_Id_Proyecto, Fk_Id_Tipo_Producto , Id_Financiacion FROM Producto LEFT JOIN Financiacion on Fk_Producto = Id_Producto INNER JOIN Proyecto on Id_Proyecto = Fk_Id_Proyecto INNER JOIN Tipo_Producto on Id_Tipo_Producto = Fk_Id_Tipo_Producto INNER JOIN Cliente_Producto on Pfk_ID_Producto= Id_Producto WHERE Estado_Cliente='Activo' GROUP BY Id_Producto ORDER by Nombre_Producto;");            
        }


        //
        public static DataTable cargarProductosPagados(string TipoProductoId)
        {
            if (TipoProductoId == "")
            {
                return Conexion.consulta("SELECT  Nombre,Apellido, Nombre_Producto as 'Producto', printf('%,d', Valor_Total_Pagos) || substr(printf(' % .2f', Valor_Total_Pagos), instr(printf(' % .2f', Valor_Total_Pagos), '.'), length(printf(' % .2f', Valor_Total_Pagos)) - instr(printf(' % .2f', Valor_Total_Pagos), '.') + 1) as 'Valor Pagado', printf('%,d', Valor_Producto) || substr(printf(' % .2f', Valor_Producto), instr(printf(' % .2f', Valor_Producto), '.'), length(printf(' % .2f', Valor_Producto)) - instr(printf(' % .2f', Valor_Producto), '.') + 1) as 'Valor Producto', printf('%,d', Valor_Producto-Valor_Total_Pagos) || substr(printf(' % .2f', Valor_Producto-Valor_Total_Pagos), instr(printf(' % .2f', Valor_Producto-Valor_Total_Pagos), '.'), length(printf(' % .2f', Valor_Producto-Valor_Total_Pagos)) - instr(printf(' % .2f', Valor_Producto-Valor_Total_Pagos), '.') + 1) as 'Diferencia' from Producto INNER JOIN Cliente_Producto on Pfk_ID_Producto= Id_Producto inner join Cliente on Id_Cliente =Pfk_ID_Cliente INNER join Proyecto on Id_Proyecto=Fk_Id_Proyecto where Valor_Total_Pagos>=Valor_Producto AND Estado_Cliente='Activo' order by Nombre;");
                //return Conexion.consulta("SELECT  Nombre,Apellido, Nombre_Producto as 'Producto', printf('%, d', Valor_Total_Pagos) as 'Valor Pagado', printf('%, d', Valor_Producto) as 'Valor Producto', printf('%, d',Valor_Producto-Valor_Total_Pagos) as 'Diferencia' from Producto INNER JOIN Cliente_Producto on Pfk_ID_Producto= Id_Producto inner join Cliente on Id_Cliente =Pfk_ID_Cliente INNER join Proyecto on Id_Proyecto=Fk_Id_Proyecto where Valor_Total_Pagos>=Valor_Producto AND Estado_Cliente='Activo' order by Nombre;");
            }
            else
            {
                return Conexion.consulta("SELECT  Nombre,Apellido, Nombre_Producto as 'Producto', printf('%,d', Valor_Total_Pagos) || substr(printf(' % .2f', Valor_Total_Pagos), instr(printf(' % .2f', Valor_Total_Pagos), '.'), length(printf(' % .2f', Valor_Total_Pagos)) - instr(printf(' % .2f', Valor_Total_Pagos), '.') + 1) as 'Valor Pagado', printf('%,d', Valor_Producto) || substr(printf(' % .2f', Valor_Producto), instr(printf(' % .2f', Valor_Producto), '.'), length(printf(' % .2f', Valor_Producto)) - instr(printf(' % .2f', Valor_Producto), '.') + 1) as 'Valor Producto', printf('%,d', Valor_Producto-Valor_Total_Pagos) || substr(printf(' % .2f', Valor_Producto-Valor_Total_Pagos), instr(printf(' % .2f', Valor_Producto-Valor_Total_Pagos), '.'), length(printf(' % .2f', Valor_Producto-Valor_Total_Pagos)) - instr(printf(' % .2f', Valor_Producto-Valor_Total_Pagos), '.') + 1) as 'Diferencia' from Producto INNER JOIN Cliente_Producto on Pfk_ID_Producto= Id_Producto inner join Cliente on Id_Cliente =Pfk_ID_Cliente INNER join Proyecto on Id_Proyecto=Fk_Id_Proyecto where Valor_Total_Pagos>=Valor_Producto AND Estado_Cliente='Activo' and Fk_Id_Tipo_Producto='" + TipoProductoId + "' order by Nombre;");
            }
        }

        internal static int crearTraslado(string old_Nombre_Producto, string old_Numero_contrato, string nombre_Producto, string numero_contrato, string Fecha_traslado, int Producto)
        {
            string sql = "INSERT INTO Traslados(Old_Producto, Old_Contrato, New_Producto, New_Contrato, Fecha_traslado,Fk_PK_Producto) VALUES(@Old_Producto, @Old_Contrato, @New_Producto, @New_Contrato, @Fecha_traslado, @Fk_PK_Producto)";
            SQLiteCommand cmd = new SQLiteCommand(sql, Conexion.instanciaDb());
            try
            {
                cmd.Parameters.Add(new SQLiteParameter("@Old_Producto", old_Nombre_Producto));
                cmd.Parameters.Add(new SQLiteParameter("@Old_Contrato", old_Numero_contrato));
                cmd.Parameters.Add(new SQLiteParameter("@New_Producto", nombre_Producto));
                cmd.Parameters.Add(new SQLiteParameter("@New_Contrato", numero_contrato));
                cmd.Parameters.Add(new SQLiteParameter("@Fecha_traslado", Fecha_traslado));
                cmd.Parameters.Add(new SQLiteParameter("@Fk_PK_Producto", Producto));
                
            }
            catch (Exception ex)
            {
                Console.WriteLine("Commit Exception Type: {0}", ex.GetType());
                Console.WriteLine("  Message: {0}", ex.Message);

            }
            return cmd.ExecuteNonQuery();
        }

        public static DataTable cargarProductosPagadosProyecto(string proyecto, string TipoProductoId)
        {
            if (TipoProductoId == "")
            {
                return Conexion.consulta("SELECT  Nombre,Apellido, Nombre_Producto as 'Producto', printf('%,d', Valor_Total_Pagos) || substr(printf(' % .2f', Valor_Total_Pagos), instr(printf(' % .2f', Valor_Total_Pagos), '.'), length(printf(' % .2f', Valor_Total_Pagos)) - instr(printf(' % .2f', Valor_Total_Pagos), '.') + 1) as 'Valor Pagado', printf('%,d', Valor_Producto) || substr(printf(' % .2f', Valor_Producto), instr(printf(' % .2f', Valor_Producto), '.'), length(printf(' % .2f', Valor_Producto)) - instr(printf(' % .2f', Valor_Producto), '.') + 1) as 'Valor Producto', printf('%,d', Valor_Producto-Valor_Total_Pagos) || substr(printf(' % .2f', Valor_Producto-Valor_Total_Pagos), instr(printf(' % .2f', Valor_Producto-Valor_Total_Pagos), '.'), length(printf(' % .2f', Valor_Producto-Valor_Total_Pagos)) - instr(printf(' % .2f', Valor_Producto-Valor_Total_Pagos), '.') + 1) as 'Diferencia' from Producto INNER JOIN Cliente_Producto on Pfk_ID_Producto= Id_Producto inner join Cliente on Id_Cliente =Pfk_ID_Cliente INNER join Proyecto on Id_Proyecto=Fk_Id_Proyecto where Valor_Total_Pagos>=Valor_Producto AND Estado_Cliente='Activo' and Fk_Id_Proyecto='" + proyecto + "' order by Nombre;");
            }
            else
            {
                return Conexion.consulta("SELECT  Nombre,Apellido, Nombre_Producto as 'Producto', printf('%,d', Valor_Total_Pagos) || substr(printf(' % .2f', Valor_Total_Pagos), instr(printf(' % .2f', Valor_Total_Pagos), '.'), length(printf(' % .2f', Valor_Total_Pagos)) - instr(printf(' % .2f', Valor_Total_Pagos), '.') + 1) as 'Valor Pagado', printf('%,d', Valor_Producto) || substr(printf(' % .2f', Valor_Producto), instr(printf(' % .2f', Valor_Producto), '.'), length(printf(' % .2f', Valor_Producto)) - instr(printf(' % .2f', Valor_Producto), '.') + 1) as 'Valor Producto', printf('%,d', Valor_Producto-Valor_Total_Pagos) || substr(printf(' % .2f', Valor_Producto-Valor_Total_Pagos), instr(printf(' % .2f', Valor_Producto-Valor_Total_Pagos), '.'), length(printf(' % .2f', Valor_Producto-Valor_Total_Pagos)) - instr(printf(' % .2f', Valor_Producto-Valor_Total_Pagos), '.') + 1) as 'Diferencia' from Producto INNER JOIN Cliente_Producto on Pfk_ID_Producto= Id_Producto inner join Cliente on Id_Cliente =Pfk_ID_Cliente INNER join Proyecto on Id_Proyecto=Fk_Id_Proyecto where Valor_Total_Pagos>=Valor_Producto AND Estado_Cliente='Activo' and Fk_Id_Proyecto='" + proyecto + "' and Fk_Id_Tipo_Producto='" + TipoProductoId + "' order by Nombre;");
            }
        }
        //
        //public static DataTable cargarProductosPagados(string TipoProductoId)
        //{
        //    if (TipoProductoId == "")
        //    {
        //        return Conexion.consulta("SELECT  Nombre,Apellido, Nombre_Producto as 'Producto', Valor_Total_Pagos as 'Valor Pagado', Valor_Producto as 'Valor Producto', Valor_Producto-Valor_Total_Pagos as 'Diferencia' from Producto INNER JOIN Cliente_Producto on Pfk_ID_Producto= Id_Producto inner join Cliente on Id_Cliente =Pfk_ID_Cliente INNER join Proyecto on Id_Proyecto=Fk_Id_Proyecto where Valor_Total_Pagos>=Valor_Producto order by Nombre;");
        //    }
        //    else
        //    {
        //        return Conexion.consulta("SELECT  Nombre,Apellido, Nombre_Producto as 'Producto', Valor_Total_Pagos as 'Valor Pagado', Valor_Producto as 'Valor Producto', Valor_Producto-Valor_Total_Pagos as 'Diferencia' from Producto INNER JOIN Cliente_Producto on Pfk_ID_Producto= Id_Producto inner join Cliente on Id_Cliente =Pfk_ID_Cliente INNER join Proyecto on Id_Proyecto=Fk_Id_Proyecto where Valor_Total_Pagos>=Valor_Producto and Fk_Id_Tipo_Producto='" + TipoProductoId + "' order by Nombre;");
        //    }
        //}
        //public static DataTable cargarProductosPagadosProyecto(string proyecto, string TipoProductoId)
        //{
        //    if(TipoProductoId=="")
        //    {
        //        return Conexion.consulta("SELECT  Nombre,Apellido, Nombre_Producto as 'Producto', Valor_Total_Pagos as 'Valor Pagado', Valor_Producto as 'Valor Producto', Valor_Producto-Valor_Total_Pagos as 'Diferencia' from Producto INNER JOIN Cliente_Producto on Pfk_ID_Producto= Id_Producto inner join Cliente on Id_Cliente =Pfk_ID_Cliente INNER join Proyecto on Id_Proyecto=Fk_Id_Proyecto where Valor_Total_Pagos>=Valor_Producto and Fk_Id_Proyecto='" + proyecto + "' order by Nombre;");
        //    }
        //    else
        //    {
        //        return Conexion.consulta("SELECT  Nombre,Apellido, Nombre_Producto as 'Producto', Valor_Total_Pagos as 'Valor Pagado', Valor_Producto as 'Valor Producto', Valor_Producto-Valor_Total_Pagos as 'Diferencia' from Producto INNER JOIN Cliente_Producto on Pfk_ID_Producto= Id_Producto inner join Cliente on Id_Cliente =Pfk_ID_Cliente INNER join Proyecto on Id_Proyecto=Fk_Id_Proyecto where Valor_Total_Pagos>=Valor_Producto and Fk_Id_Proyecto='" + proyecto + "' and Fk_Id_Tipo_Producto='" + TipoProductoId + "' order by Nombre;");
        //    }            
        //}
        internal static DataTable CantTipoProductos()
        {
            return Conexion.consulta("SELECT Nom_Tipo_Producto as 'Tipo', count( Nom_Tipo_Producto) as 'Numero' FROM Producto LEFT JOIN Financiacion on Fk_Producto = Id_Producto INNER JOIN Proyecto on Id_Proyecto = Fk_Id_Proyecto INNER JOIN Tipo_Producto on Id_Tipo_Producto = Fk_Id_Tipo_Producto INNER JOIN Cliente_Producto on Pfk_ID_Producto= Id_Producto WHERE Estado_Cliente='Activo' GROUP BY Nom_Tipo_Producto;");
        }
        internal static DataTable CantProductosProyecto()
        {
            return Conexion.consulta("SELECT Proyecto_Nombre as 'Proyecto', count( Proyecto_Nombre) as 'Cantidad' FROM Producto LEFT JOIN Financiacion on Fk_Producto = Id_Producto INNER JOIN Proyecto on Id_Proyecto = Fk_Id_Proyecto INNER JOIN Tipo_Producto on Id_Tipo_Producto = Fk_Id_Tipo_Producto INNER JOIN Cliente_Producto on Pfk_ID_Producto= Id_Producto WHERE Estado_Cliente='Activo' GROUP BY Proyecto_Nombre;");
        }
        internal static DataTable CantTipoProductosProyecto(string proyecto)
        {
            return Conexion.consulta("SELECT Nom_Tipo_Producto as 'Tipo', count( Nom_Tipo_Producto) as 'Numero' FROM Producto LEFT JOIN Financiacion on Fk_Producto = Id_Producto INNER JOIN Proyecto on Id_Proyecto = Fk_Id_Proyecto INNER JOIN Tipo_Producto on Id_Tipo_Producto = Fk_Id_Tipo_Producto INNER JOIN Cliente_Producto on Pfk_ID_Producto= Id_Producto WHERE Id_Proyecto='" + proyecto + "' AND Estado_Cliente='Activo' GROUP BY Nom_Tipo_Producto;");
        }
        internal static DataTable CantTipoVentaProductos()
        {
            return Conexion.consulta("SELECT Forma_Pago as 'Tipo', count( Forma_Pago) as 'Numero' FROM Producto LEFT JOIN Financiacion on Fk_Producto = Id_Producto INNER JOIN Proyecto on Id_Proyecto = Fk_Id_Proyecto INNER JOIN Tipo_Producto on Id_Tipo_Producto = Fk_Id_Tipo_Producto INNER JOIN Cliente_Producto on Pfk_ID_Producto = Id_Producto WHERE Estado_Cliente='Activo' GROUP BY Forma_Pago;");
        }
        internal static DataTable CantTipoVentaProductosProyecto(string proyecto)
        {
            return Conexion.consulta("SELECT Forma_Pago as 'Tipo', count( Forma_Pago) as 'Numero' FROM Producto LEFT JOIN Financiacion on Fk_Producto = Id_Producto INNER JOIN Proyecto on Id_Proyecto = Fk_Id_Proyecto INNER JOIN Tipo_Producto on Id_Tipo_Producto = Fk_Id_Tipo_Producto INNER JOIN Cliente_Producto on Pfk_ID_Producto = Id_Producto WHERE Id_Proyecto ='" + proyecto + "' AND Estado_Cliente='Activo' GROUP BY Forma_Pago;");
        }
        //SELECT Forma_Pago as 'Tipo', count( Forma_Pago) as 'Numero' FROM Producto LEFT JOIN Financiacion on Fk_Producto = Id_Producto INNER JOIN Proyecto on Id_Proyecto = Fk_Id_Proyecto INNER JOIN Tipo_Producto on Id_Tipo_Producto = Fk_Id_Tipo_Producto INNER JOIN Cliente_Producto on Pfk_ID_Producto = Id_Producto WHERE Id_Proyecto = 0 AND Estado_Cliente = 'Activo' GROUP BY Forma_Pago ORDER by Nombre_Producto;
        public static DataTable cargarProductosDetalleProyecto(int proyectoid, int TipoProductoId)
        {
            return Conexion.consulta("SELECT Id_Producto, Nombre_Producto as Producto, Numero_contrato as Contrato, Forma_pago as 'Forma Pago', Nombre, Apellido, printf('%, d', Valor_Neto) as 'Valor Neto',printf('%, d', sum(Valor_Pagado)) as Pagado, printf('%, d', Valor_Producto) as 'Valor Final', Fecha_Venta as 'Fecha Venta' FROM Producto INNER JOIN Proyecto on Id_Proyecto = Fk_Id_Proyecto INNER JOIN Pagos on Fk_Id_Producto=Id_Producto INNER JOIN Tipo_Producto on Id_Tipo_Producto = Fk_Id_Tipo_Producto INNER JOIN Cliente_Producto on Pfk_ID_Producto= Id_Producto INNER JOIN Cliente on Pfk_ID_Cliente=Id_Cliente  WHERE Estado_Cliente='Activo' AND Fk_Id_Proyecto='" + proyectoid + "' AND Id_Tipo_Producto='" + TipoProductoId + "' GROUP BY Id_Producto;");
        }      

        public static DataTable cargarTodoProductosDetalleProyecto(int proyectoid)
        {
            return Conexion.consulta("SELECT Id_Producto, Nombre_Producto as Producto, Numero_contrato as Contrato, Forma_pago as 'Forma Pago', Nombre, Apellido, printf('%, d', Valor_Neto) as 'Valor Neto',printf('%, d', sum(Valor_Pagado)) as Pagado, printf('%, d', Valor_Producto) as 'Valor Final', Fecha_Venta as 'Fecha Venta', Nom_Tipo_Producto as Tipo FROM Producto INNER JOIN Proyecto on Id_Proyecto = Fk_Id_Proyecto INNER JOIN Pagos on Fk_Id_Producto=Id_Producto INNER JOIN Tipo_Producto on Id_Tipo_Producto = Fk_Id_Tipo_Producto INNER JOIN Cliente_Producto on Pfk_ID_Producto= Id_Producto INNER JOIN Cliente on Pfk_ID_Cliente=Id_Cliente  WHERE Estado_Cliente='Activo' AND Fk_Id_Proyecto='" + proyectoid + "' GROUP BY Id_Producto;");
        }
        public static DataTable cargarProductosProyecto( int proyectoid)
        {
            return Conexion.consulta("SELECT Id_Producto, Nombre_Producto as Producto, Numero_contrato as Contrato, Forma_pago as 'Forma Pago', printf('%, d', Valor_Neto) as 'Valor Neto', printf('%, d', Valor_Producto) as 'Valor Total', Fecha_Venta as 'Fecha Venta',  printf('%, d', Valor_Entrada) as 'Inicial', Proyecto_Nombre as Proyecto, Nom_Tipo_Producto as 'Tipo', printf('%, d', Valor_Sin_interes) as 'Valor Inicial', Cuotas_Sin_interes as 'Cuotas Inicial', printf('%, d', Valor_Cuota_Sin_interes) as 'Valor Cuota Inicial', printf('%, d', Valor_Con_Interes) as 'Valor Saldo', Cuotas_Con_Interes as 'Cuotas Saldo', printf('%, d', Valor_Cuota_Con_Interes) as 'Valor Cuota Saldo', Valor_Interes as 'Interes', Fecha_Recaudo as 'Fecha Recaudo', Observaciones, Fk_Id_Proyecto, Fk_Id_Tipo_Producto , Id_Financiacion FROM Producto LEFT JOIN Financiacion on Fk_Producto = Id_Producto INNER JOIN Proyecto on Id_Proyecto = Fk_Id_Proyecto INNER JOIN Tipo_Producto on Id_Tipo_Producto = Fk_Id_Tipo_Producto INNER JOIN Cliente_Producto on Pfk_ID_Producto= Id_Producto WHERE Estado_Cliente='Activo' AND Fk_Id_Proyecto='" + proyectoid + "' GROUP BY Id_Producto;");

        }
        public static DataTable BuscarProductos(string Nombre_Producto)
        {            
            return Conexion.consulta("SELECT Id_Producto, Nombre_Producto as Producto, Numero_contrato as Contrato, Forma_pago as 'Forma Pago',  Valor_Neto as 'Valor Neto', Valor_Producto as 'Valor Total', Fecha_Venta as 'Fecha Venta', Valor_Entrada 'Inicial', Proyecto_Nombre as Proyecto, Nom_Tipo_Producto as 'Tipo', Valor_Sin_interes as 'Valor 30', Cuotas_Sin_interes as 'Cuotas 30', Valor_Cuota_Sin_interes as 'Valor Cuota 30', Valor_Con_Interes as 'Valor 70', Cuotas_Con_Interes as 'Cuotas 70', Valor_Cuota_Con_Interes as 'Valor Cuota 70', Valor_Interes as 'Interes', Fecha_Recaudo as 'Fecha Recaudo', Observaciones, Fk_Id_Proyecto, Fk_Id_Tipo_Producto , Id_Financiacion FROM Producto LEFT JOIN Financiacion on Fk_Producto = Id_Producto INNER JOIN Proyecto on Id_Proyecto = Fk_Id_Proyecto INNER JOIN Tipo_Producto on Id_Tipo_Producto = Fk_Id_Tipo_Producto INNER JOIN Cliente_Producto on Pfk_ID_Producto = Id_Producto WHERE Nombre_Producto = '" + Nombre_Producto + "' AND Estado_Cliente = 'Activo';");
        }
        public static DataTable cargarProductosCliente(int IdCliente)
        {
            return Conexion.consulta("SELECT Id_Producto, Nombre_Producto as Producto, Numero_contrato as Contrato, Forma_pago as 'Forma Pago', Valor_Neto as 'Valor Neto', sum(Valor_Pagado) as Pagado,  Valor_Producto as 'Valor Final', Fecha_Venta as 'Fecha Venta', Observaciones, Proyecto_Nombre as Proyecto, Nom_Tipo_Producto as 'Tipo Producto', Fk_Id_Proyecto, Fk_Id_Tipo_Producto FROM Cliente_Producto INNER JOIN Producto on Id_Producto=Pfk_ID_Producto LEFT JOIN Pagos on Fk_Id_Producto= Id_Producto INNER join Proyecto on Id_Proyecto = Fk_Id_Proyecto INNER join Tipo_Producto on Id_Tipo_Producto = Fk_Id_Tipo_Producto WHERE Pfk_ID_Cliente =" + IdCliente + " AND Estado_Cliente ='Activo' GROUP BY Id_Producto");

            //return Conexion.consulta("SELECT Id_Producto, Nombre_Producto, Numero_contrato, Forma_pago, Valor_Producto, Fecha_Venta, Observaciones, Proyecto_Nombre, Nom_Tipo_Producto, Id_Financiacion, Valor_Producto_Financiacion, Valor_Entrada, Valor_Sin_interes, Cuotas_Sin_interes, Valor_Cuota_Sin_interes, Valor_Con_Interes, Cuotas_Con_Interes, Valor_Cuota_Con_Interes, Valor_Interes, Fecha_Recaudo, Fk_Id_Proyecto, Fk_Id_Tipo_Producto FROM Cliente_Producto INNER JOIN Producto on Id_Producto=Pfk_ID_Producto INNER join Proyecto on Id_Proyecto = Fk_Id_Proyecto INNER join Tipo_Producto on Id_Tipo_Producto = Fk_Id_Tipo_Producto INNER JOIN Financiacion on Fk_Producto= Id_Producto WHERE Pfk_ID_Cliente = " + IdCliente + "");
            //ajustar consulta porque falta tener en cuenta la tabla de Cliente_Producto en el join
        }
        public static DataTable ListarTraslado(int IdProducto)
        {
            return Conexion.consulta("SELECT Old_Producto as 'Producto', Old_Contrato as 'Contrato', New_Producto as 'Nuevo Producto', New_Contrato as 'Nuevo Contrato', Fecha_traslado as'Fecha Traslado' from Traslados WHERE Fk_PK_Producto=" + IdProducto + " ORDER by Fecha_traslado");
        }

        public static int crearProducto(string Nombre_Producto, string Numero_contrato, string Forma_Pago, int Valor_Neto, double Valor_Producto, string Fecha_Venta, string Observaciones, int Fk_Id_Proyecto, int Fk_Id_Tipo_Producto)
        {
            string sql = "INSERT INTO Producto(Nombre_Producto, Numero_contrato, Forma_Pago, Valor_Neto, Valor_Producto, Fecha_Venta, Observaciones, Fk_Id_Proyecto, Fk_Id_Tipo_Producto) VALUES(@Nombre_Producto, @Numero_contrato, @Forma_Pago, @Valor_Neto, @Valor_Producto, @Fecha_Venta, @Observaciones, @Fk_Id_Proyecto, @Fk_Id_Tipo_Producto)";
            SQLiteCommand cmd = new SQLiteCommand(sql, Conexion.instanciaDb());
            try
            {
                cmd.Parameters.Add(new SQLiteParameter("@Nombre_Producto", Nombre_Producto));
                cmd.Parameters.Add(new SQLiteParameter("@Numero_contrato", Numero_contrato));
                cmd.Parameters.Add(new SQLiteParameter("@Forma_Pago", Forma_Pago));
                cmd.Parameters.Add(new SQLiteParameter("@Valor_Neto", Valor_Neto));
                cmd.Parameters.Add(new SQLiteParameter("@Valor_Producto", Valor_Producto));
                cmd.Parameters.Add(new SQLiteParameter("@Fecha_Venta", Fecha_Venta));
                cmd.Parameters.Add(new SQLiteParameter("@Observaciones", Observaciones));
                cmd.Parameters.Add(new SQLiteParameter("@Fk_Id_Proyecto", Fk_Id_Proyecto));
                cmd.Parameters.Add(new SQLiteParameter("@Fk_Id_Tipo_Producto", Fk_Id_Tipo_Producto));
                cmd.ExecuteNonQuery();
                long lastInsertId = cmd.Connection.LastInsertRowId;
                return (int)lastInsertId;
            }
            catch (Exception ex)
            {
                LongError("actualizarProducto", sql, ex.Message);
                return -1;
            }
        }

        public static int actualizarProducto(int id_Producto, string Nombre_Producto, string Numero_contrato, string Forma_Pago, int Valor_Neto, double Valor_Producto, string Fecha_Venta, string Observaciones, int Fk_Id_Proyecto, int Fk_Id_Tipo_Producto)
        {
            string sql = "UPDATE Producto SET Nombre_Producto=@Nombre_Producto , Numero_contrato=@Numero_contrato, Forma_Pago=@Forma_Pago, Valor_Neto=@Valor_Neto, Valor_Producto=@Valor_Producto, Fecha_Venta=@Fecha_Venta, Observaciones=@Observaciones, Fk_Id_Proyecto=@Fk_Id_Proyecto, Fk_Id_Tipo_Producto=@Fk_Id_Tipo_Producto WHERE Id_Producto =" + id_Producto + "";
            SQLiteCommand cmd = new SQLiteCommand(sql, Conexion.instanciaDb());
            try
            {
                cmd.Parameters.Add(new SQLiteParameter("@Nombre_Producto", Nombre_Producto));
                cmd.Parameters.Add(new SQLiteParameter("@Numero_contrato", Numero_contrato));
                cmd.Parameters.Add(new SQLiteParameter("@Forma_Pago", Forma_Pago));
                cmd.Parameters.Add(new SQLiteParameter("@Valor_Neto", Valor_Neto));
                cmd.Parameters.Add(new SQLiteParameter("@Valor_Producto", Valor_Producto));
                cmd.Parameters.Add(new SQLiteParameter("@Fecha_Venta", Fecha_Venta));
                cmd.Parameters.Add(new SQLiteParameter("@Observaciones", Observaciones));
                cmd.Parameters.Add(new SQLiteParameter("@Fk_Id_Proyecto", Fk_Id_Proyecto));
                cmd.Parameters.Add(new SQLiteParameter("@Fk_Id_Tipo_Producto", Fk_Id_Tipo_Producto));
                cmd.ExecuteNonQuery();
                long lastInsertId = cmd.Connection.LastInsertRowId;
                return (int)lastInsertId;
            }
            catch (Exception ex)
            {
                LongError("actualizarProducto", sql, ex.Message);
                return -1;
            }
        }
        public static int actualizarValorProducto(int id_Producto, double Valor_Producto)
        {
            string sql = "UPDATE Producto SET Valor_Producto=@Valor_Producto WHERE Id_Producto =" + id_Producto + "";
            SQLiteCommand cmd = new SQLiteCommand(sql, Conexion.instanciaDb());
            cmd.Parameters.Add(new SQLiteParameter("@Valor_Producto", Valor_Producto));
            return cmd.ExecuteNonQuery();
        }

        public static DataTable ultimoProducto()
        {
            return Conexion.consulta("SELECT max(Id_Producto) FROM Producto ORDER BY Id_Producto DESC");
        }
        public static DataTable ReportVentas(string FechaInicio, string FechaFin)
        {
            return Conexion.consulta("SELECT Nombre_Producto as Producto, Numero_contrato as Contrato, Forma_Pago as 'Forma Pago', printf('%,d', Valor_Producto) || substr(printf(' % .2f', Valor_Producto), instr(printf(' % .2f', Valor_Producto), '.'), length(printf(' % .2f', Valor_Producto)) - instr(printf(' % .2f', Valor_Producto), '.') + 1) as Valor, Fecha_Venta as Fecha, Cedula,Nombre, Apellido FROM Producto INNER JOIN Cliente_Producto on Pfk_ID_Producto= Id_Producto INNER JOIN Cliente on Id_Cliente= Pfk_ID_Cliente WHERE Fecha_Venta BETWEEN '" + FechaInicio + "' AND '" + FechaFin + "' AND Estado_Cliente='Activo' ORDER by Fecha_Venta;");
        }
        public static DataTable ReportVentasTipo(string FechaInicio, string FechaFin, string Tipo)
        {
            return Conexion.consulta("SELECT Nombre_Producto as Producto, Numero_contrato as Contrato, Forma_Pago as 'Forma Pago', printf('%,d', Valor_Producto) || substr(printf(' % .2f', Valor_Producto), instr(printf(' % .2f', Valor_Producto), '.'), length(printf(' % .2f', Valor_Producto)) - instr(printf(' % .2f', Valor_Producto), '.') + 1) as Valor, Fecha_Venta as Fecha, Cedula,Nombre, Apellido FROM Producto INNER JOIN Cliente_Producto on Pfk_ID_Producto= Id_Producto INNER JOIN Cliente on Id_Cliente= Pfk_ID_Cliente WHERE Fk_Id_Tipo_Producto='" + Tipo + "' AND Fecha_Venta BETWEEN '" + FechaInicio + "' AND '" + FechaFin + "' AND Estado_Cliente='Activo' ORDER by Fecha_Venta;");
        }
        public static DataTable ReportVentasProyecto(string FechaInicio, string FechaFin, string proyecto)
        {
            return Conexion.consulta("SELECT Nombre_Producto as Producto, Numero_contrato as Contrato, Forma_Pago as 'Forma Pago', printf('%,d', Valor_Producto) || substr(printf(' % .2f', Valor_Producto), instr(printf(' % .2f', Valor_Producto), '.'), length(printf(' % .2f', Valor_Producto)) - instr(printf(' % .2f', Valor_Producto), '.') + 1) as Valor, Fecha_Venta as Fecha, Cedula,Nombre, Apellido FROM Producto INNER JOIN Cliente_Producto on Pfk_ID_Producto= Id_Producto INNER JOIN Cliente on Id_Cliente= Pfk_ID_Cliente WHERE Fk_Id_Proyecto= '" + proyecto + "' AND Fecha_Venta BETWEEN '" + FechaInicio + "' AND '" + FechaFin + "' AND Estado_Cliente='Activo' ORDER by Fecha_Venta;");
        }
        public static DataTable ReportVentasProyectoTipo(string FechaInicio, string FechaFin, string proyecto, string Tipo)
        {
            return Conexion.consulta("SELECT Nombre_Producto as Producto, Numero_contrato as Contrato, Forma_Pago as 'Forma Pago', printf('%,d', Valor_Producto) || substr(printf(' % .2f', Valor_Producto), instr(printf(' % .2f', Valor_Producto), '.'), length(printf(' % .2f', Valor_Producto)) - instr(printf(' % .2f', Valor_Producto), '.') + 1) as Valor, Fecha_Venta as Fecha, Cedula,Nombre, Apellido FROM Producto INNER JOIN Cliente_Producto on Pfk_ID_Producto= Id_Producto INNER JOIN Cliente on Id_Cliente= Pfk_ID_Cliente WHERE Fk_Id_Proyecto= '" + proyecto + "' AND Fk_Id_Tipo_Producto='" + Tipo + "' AND Fecha_Venta BETWEEN '" + FechaInicio + "' AND '" + FechaFin + "' AND Estado_Cliente='Activo' ORDER by Fecha_Venta;");
        }
        public static DataTable ValorReportVentas(string FechaInicio, string FechaFin)
        {
            return Conexion.consulta("SELECT count(Id_Producto)as productos, sum(Valor_Producto) as valor FROM Producto INNER JOIN Cliente_Producto on Pfk_ID_Producto= Id_Producto  WHERE Fecha_Venta BETWEEN '" + FechaInicio + "' AND '" + FechaFin + "'AND Estado_Cliente='Activo';");
        }
        public static DataTable ValorReportVentasTipo(string FechaInicio, string FechaFin, string Tipo)
        {
            return Conexion.consulta("SELECT count(Id_Producto)as productos, sum(Valor_Producto) as valor FROM Producto INNER JOIN Cliente_Producto on Pfk_ID_Producto= Id_Producto  WHERE Fk_Id_Tipo_Producto='" + Tipo + "' AND Fecha_Venta BETWEEN '" + FechaInicio + "' AND '" + FechaFin + "'AND Estado_Cliente='Activo';");
        }
        internal static DataTable ValorReportVentasProyecto(string fechaInicio, string fechaFin, string proyecto)
        {
            return Conexion.consulta("SELECT count(Id_Producto)as productos, sum(Valor_Producto) as valor FROM Producto INNER JOIN Cliente_Producto on Pfk_ID_Producto= Id_Producto  WHERE Fk_Id_Proyecto= '" + proyecto + "' AND Fecha_Venta BETWEEN '" + fechaInicio + "' AND '" + fechaFin + "'AND Estado_Cliente='Activo';");
        }
        internal static DataTable ValorReportVentasProyectoTipo(string fechaInicio, string fechaFin, string proyecto, string Tipo)
        {
            return Conexion.consulta("SELECT count(Id_Producto)as productos, sum(Valor_Producto) as valor FROM Producto INNER JOIN Cliente_Producto on Pfk_ID_Producto= Id_Producto  WHERE Fk_Id_Proyecto= '" + proyecto + "' AND Fk_Id_Tipo_Producto='" + Tipo + "' AND Fecha_Venta BETWEEN '" + fechaInicio + "' AND '" + fechaFin + "'AND Estado_Cliente='Activo';");
        }
        public static DataTable ValorReportProducto()
        {
            //arreglar consulta para que no tenga los valores de las demas financiaciones
            return Conexion.consulta("SELECT count(Id_Producto)as productos, sum(Valor_Producto) as valor FROM Producto LEFT JOIN Financiacion on Fk_Producto = Id_Producto INNER JOIN Proyecto on Id_Proyecto = Fk_Id_Proyecto INNER JOIN Tipo_Producto on Id_Tipo_Producto = Fk_Id_Tipo_Producto INNER JOIN Cliente_Producto on Pfk_ID_Producto= Id_Producto WHERE Estado_Cliente='Activo' and Estado_Financiacion='Activa';");
        }
        public static DataTable ClienteProducto(int IdProducto)
        {
            return Conexion.consulta("SELECT Cedula, Nombre, Apellido, Telefono, Correo, Nombre_Producto as Producto, Numero_contrato as Contrato, Proyecto_Nombre as Proyecto FROM Cliente INNER JOIN Cliente_Producto on Pfk_ID_Cliente = Id_Cliente INNER JOIN Producto on Id_Producto=Pfk_ID_Producto INNER JOIN Proyecto on Id_Proyecto = Fk_Id_Proyecto WHERE Id_Producto='" + IdProducto + "' AND Estado_Cliente= 'Activo';");
        }
        //public static DataTable 

    }
}
