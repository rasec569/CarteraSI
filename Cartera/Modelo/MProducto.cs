﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data;

namespace Cartera.Modelo
{
    class MProducto
    {
        public Int64 ID_Producto { get; set; }
        public string Nombre_Producto { get; set; }
        public Int64 Numero_contrato { get; set; }
        public string Forma_pago { get; set; }
        //public string Tipo_producto { get; set; }
        public Int64 Valor_Total { get; set; }
        //public Int64 Valor_30 { get; set; }
        //public Int64 Valor_Entrada { get; set; }
        //public Int64 Cuotas_30 { get; set; }
        //public Int64 Valor_70 { get; set; }
        //public Int64 Cuotas_70 { get; set; }
        //public Int64 Valor_intereses { get; set; }
        public DateTime Fecha_Venta { get; set; }
        public string Observaciones { get; set; }
        public Int64 Id_Proyecto { get; set; }
        public Int64 Tipo_Producto { get; set; }
        public Int64 Id_Financiacion { get; set; }

        public static DataTable cargarProductos(){
            return Conexion.consulta("SELECT Id_Producto, Nombre_Producto, Numero_contrato, Forma_pago, Valor_Total, Fecha_Venta, Valor_Entrada, Proyecto_Nombre, Nom_Tipo_Producto, Valor_Sin_interes, Cuotas_Sin_interes, Valor_Cuota_Sin_interes, Valor_Con_Interes, Cuotas_Con_Interes, Valor_Cuota_Con_Interes, Valor_Interes, Fecha_Recaudo, Observaciones, Fk_Id_Proyecto, Fk_Id_Tipo_Producto FROM Producto INNER join Proyecto on Id_Proyecto = Fk_Id_Proyecto INNER join Tipo_Producto on Id_Tipo_Producto = Fk_Id_Tipo_Producto");
            //ajustar que celdas son porque estas son de la tabla vieja
        }

        public static DataTable cargarProductosCliente(int IdCartera){
            return Conexion.consulta("SELECT Id_Producto, Nombre_Producto, Numero_contrato, Forma_pago, Valor_Total, Fecha_Venta, Valor_Entrada, Proyecto_Nombre, Nom_Tipo_Producto, Valor_Sin_interes, Cuotas_Sin_interes, Valor_Cuota_Sin_interes, Valor_Con_Interes, Cuotas_Con_Interes, Valor_Cuota_Con_Interes, Valor_Interes, Fecha_Recaudo, Observaciones, Fk_Id_Proyecto, Fk_Id_Tipo_Producto FROM Producto INNER join Proyecto on Id_Proyecto = Fk_Id_Proyecto INNER join Tipo_Producto on Id_Tipo_Producto = Fk_Id_Tipo_Producto WHERE Fk_Id_CarteraP =  " + IdCartera + "");
            //ajustar consulta porque falta tener en cuenta la tabla de Cliente_Producto en el join
        }

        public static int crearProducto(string Nombre_Producto,int Numero_contrato,string Forma_Pago,int Valor_Total,string Fecha_Venta,string Observaciones,int Fk_Id_Proyecto,int Fk_Id_Tipo_Producto,int Fk_Id_Financiacion){
            //en este caso para crear producto primero se debe crear una financiacion
        string sql3 = "INSERT INTO Producto(Nombre_Producto, Numero_contrato, Forma_Pago, Valor_Total, Fecha_Venta, Observaciones, Fk_Id_Proyecto, Fk_Id_Tipo_Producto,Fk_Id_Financiacion) VALUES(@Nombre_Producto, @Numero_contrato, @Forma_Pago, @Valor_Total, @Fecha_Venta, @Observaciones, @Fk_Id_Proyecto, @Fk_Id_Tipo_Producto, @Fk_Id_Financiacion)";
                            SQLiteCommand cmd3 = new SQLiteCommand(sql3, Conexion.instanciaDb());
                            cmd3.Parameters.Add(new SQLiteParameter("@Nombre_Producto", Nombre_Producto));
                            cmd3.Parameters.Add(new SQLiteParameter("@Numero_contrato", Numero_contrato));
                            cmd3.Parameters.Add(new SQLiteParameter("@Forma_Pago", Forma_Pago));
                            cmd3.Parameters.Add(new SQLiteParameter("@Valor_Total", Valor_Total));
                            //cmd3.Parameters.Add(new SQLiteParameter("@Valor_Sin_interes", txtValorSin.Text));
                            //cmd3.Parameters.Add(new SQLiteParameter("@Valor_Entrada", txtValorEntrada.Text));
                            //cmd3.Parameters.Add(new SQLiteParameter("@Cuotas_Sin_interes", Convert.ToString(numCuotaSinInteres.Value)));
                            //cmd3.Parameters.Add(new SQLiteParameter("@Valor_Con_Interes", txtValorCon.Text));
                            //cmd3.Parameters.Add(new SQLiteParameter("@Cuotas_Con_Interes", Convert.ToString(numCuotaSinInteres.Value)));
                            //cmd3.Parameters.Add(new SQLiteParameter("@Valor_Interes", txtValorCuotaInteres.Text));
                            cmd3.Parameters.Add(new SQLiteParameter("@Fecha_Venta", Fecha_Venta));
                            //cmd3.Parameters.Add(new SQLiteParameter("@Fecha_Recaudo", DateRecaudo.Text));
                            cmd3.Parameters.Add(new SQLiteParameter("@Observaciones", Observaciones));
                            //cmd3.Parameters.Add(new SQLiteParameter("@Fk_Id_CarteraP", Cartera_id));
                            cmd3.Parameters.Add(new SQLiteParameter("@Fk_Id_Proyecto", Fk_Id_Proyecto));
                            cmd3.Parameters.Add(new SQLiteParameter("@Fk_Id_Tipo_Producto", Fk_Id_Tipo_Producto));
                            cmd3.Parameters.Add(new SQLiteParameter("@Fk_Id_Financiacion", Fk_Id_Financiacion));
                            return cmd3.ExecuteNonQuery();
        }

        public static int actualizarProducto(int id_Producto, string Nombre_Producto,int Numero_contrato,string Forma_Pago,int Valor_Total,string Fecha_Venta,string Observaciones,int Fk_Id_Proyecto,int Fk_Id_Tipo_Producto,int Fk_Id_Financiacion){
            string sql3 = "UPDATE Producto SET Nombre_Producto=@Nombre_Producto , Numero_contrato=@Numero_contrato, Forma_Pago=@Forma_Pago, Valor_Total=@Valor_Total, Fecha_Venta=@Fecha_Venta Observaciones=@Observaciones, Fk_Id_Proyecto=@Fk_Id_Proyecto, Fk_Id_Tipo_Producto=@Fk_Id_Tipo_Producto WHERE Id_Producto =" + id_Producto + "";
                            SQLiteCommand cmd3 = new SQLiteCommand(sql3, Conexion.instanciaDb());
                            cmd3.Parameters.Add(new SQLiteParameter("@Nombre_Producto", Nombre_Producto));
                            cmd3.Parameters.Add(new SQLiteParameter("@Numero_contrato", Numero_contrato));
                            cmd3.Parameters.Add(new SQLiteParameter("@Forma_Pago", Forma_Pago));
                            cmd3.Parameters.Add(new SQLiteParameter("@Valor_Total", Valor_Total));
                            //cmd3.Parameters.Add(new SQLiteParameter("@Valor_Sin_interes", txtValorSin.Text));
                            //cmd3.Parameters.Add(new SQLiteParameter("@Valor_Entrada", txtValorEntrada.Text));
                            //cmd3.Parameters.Add(new SQLiteParameter("@Cuotas_Sin_interes", Convert.ToString(numCuotaSinInteres.Value)));
                            //cmd3.Parameters.Add(new SQLiteParameter("@Valor_Con_Interes", txtValorCon.Text));
                            //cmd3.Parameters.Add(new SQLiteParameter("@Cuotas_Con_Interes", Convert.ToString(numCuotaSinInteres.Value)));
                            //cmd3.Parameters.Add(new SQLiteParameter("@Valor_Interes", txtValorCuotaInteres.Text));
                            cmd3.Parameters.Add(new SQLiteParameter("@Fecha_Venta", Fecha_Venta));
                            //cmd3.Parameters.Add(new SQLiteParameter("@Fecha_Recaudo", DateRecaudo.Text));
                            cmd3.Parameters.Add(new SQLiteParameter("@Observaciones", Observaciones));
                            //cmd3.Parameters.Add(new SQLiteParameter("@Fk_Id_CarteraP", Cartera_id));
                            cmd3.Parameters.Add(new SQLiteParameter("@Fk_Id_Proyecto", Fk_Id_Proyecto));
                            cmd3.Parameters.Add(new SQLiteParameter("@Fk_Id_Tipo_Producto", Fk_Id_Tipo_Producto));
                            cmd3.Parameters.Add(new SQLiteParameter("@Fk_Id_Financiacion", Fk_Id_Financiacion));
                            return cmd3.ExecuteNonQuery();
        }

    }
}
