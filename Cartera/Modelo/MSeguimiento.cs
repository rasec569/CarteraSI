using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cartera.Modelo
{
    class MSeguimiento
    {
        internal DataTable CargarSeguimiento(string idproducto)
        {
            return Conexion.consulta("SELECT *FROM Seguimiento WHERE Fk_Id_Producto = '"+idproducto+"';");        
        }

        internal int GuardarSeguimiento(string comentario, string fecha, string idproducto)
        {
            //cambiar en bd nombre del atributo fecha_si
            string sql = "insert into Seguimiento(Fecha_Seguimieto, Comentario, Fk_Id_Producto) values(@Fecha_Seguimieto, @Comentario, @Fk_Id_Producto)";
            SQLiteCommand cmd = new SQLiteCommand(sql, Conexion.instanciaDb());
            cmd.Parameters.Add(new SQLiteParameter("@Fecha_Seguimieto", fecha));
            cmd.Parameters.Add(new SQLiteParameter("@Comentario", comentario));
            cmd.Parameters.Add(new SQLiteParameter("@Fk_Id_Producto", idproducto));
            return cmd.ExecuteNonQuery();
    
        }
    }
}
