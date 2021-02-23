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
    class MFinanciacion : CFinanciacion
    {
        public Int64 Id_Financiacion { get; set; }
        public Int64 Valor_Producto_Financiacion { get; set;}
        public Int64 Valor_Entrada { get; set; }
        public Int64 Valor_Sin_interes { get; set; }
        public Int64 Valor_Cuota_Sin_interes { get; set; }
        public Int64 Cuotas_Sin_interes { get; set; }
        public Int64 Valor_Con_Interes { get; set; }
        public Int64 Cuotas_Con_Interes { get; set; }
        public Int64 Valor_Cuota_Con_Interes { get; set; }
        public Int64 Valor_Interes { get; set; }
        public DateTime Fecha_Recaudo { get; set; }

        public int crearFinanciacion(int Valor_Producto_Financiacion, int Valor_Entrada, int Valor_Sin_interes, int Valor_Cuota_Sin_interes, int Cuotas_Sin_interes, int Valor_Con_Interes, int Cuotas_Con_Interes, int Valor_Cuota_Con_Interes, int Valor_Interes, DateTime Fecha_Recaudo)
        {
            string sql = "INSERT INTO Financiacion(Valor_Producto+Financiacion, Valor_Sin_interes, Valor_Entrada, Cuotas_Sin_interes, Valor_Cuota_Sin_interes, Valor_Con_Interes, Cuotas_Con_Interes, Valor_Cuota_Con_Interes, Valor_Interes, Fecha_Venta, Fecha_Recaudo, Observaciones, Fk_Id_Cartera, Fk_Id_Proyecto, Fk_Id_Tipo_Producto) VALUES(@Nombre_Producto, @Numero_contrato, @Forma_Pago, @Valor_Total, @Valor_Sin_interes, @Valor_Entrada, @Cuotas_Sin_interes , @Valor_Con_Interes, @Cuotas_Con_Interes, @Valor_Interes, @Fecha_Recaudo, @Observaciones, @Fk_Id_Cartera, @Fk_Id_Proyecto, @Fk_Id_Tipo_Producto)";
            SQLiteCommand cmd = new SQLiteCommand(sql, Conexion.instanciaDb());
            cmd.Parameters.Add(new SQLiteParameter("@Valor_Producto+Financiacion", Valor_Producto_Financiacion));
            cmd.Parameters.Add(new SQLiteParameter("@Valor_Sin_interes", Valor_Entrada));
            cmd.Parameters.Add(new SQLiteParameter("@Valor_Entrada", Valor_Sin_interes));
            cmd.Parameters.Add(new SQLiteParameter("@Cuotas_Sin_interes", Valor_Cuota_Sin_interes));
            cmd.Parameters.Add(new SQLiteParameter("@Valor_Con_Interes", Cuotas_Sin_interes));
            cmd.Parameters.Add(new SQLiteParameter("@Cuotas_Con_Interes", Valor_Con_Interes));
            cmd.Parameters.Add(new SQLiteParameter("@Valor_Interes", Cuotas_Con_Interes));
            cmd.Parameters.Add(new SQLiteParameter("@Fecha_Recaudo", Valor_Cuota_Con_Interes));
            cmd.Parameters.Add(new SQLiteParameter("@Fk_Id_Proyecto", Valor_Interes));
            cmd.Parameters.Add(new SQLiteParameter("@Fk_Id_Tipo_Producto", Fecha_Recaudo));
            return cmd.ExecuteNonQuery();
        }
    }

}
