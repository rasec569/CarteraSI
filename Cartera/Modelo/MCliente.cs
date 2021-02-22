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
    class MCliente : CCliente
    {
        public Int64 ID_Cliente { get; set; }
        public Int64 Cedula { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public Int64 Telefono { get; set; }
        public string Direccion { get; set; }
        public string Correo { get; set; }
        public Int64 IdCartera { get; set; }

        public static DataTable cargarClientes(){
        return Conexion.consulta("Select Id_Cliente, Cedula, Nombre, Apellido, Telefono, Direccion, Correo, Fk_Id_Cartera  from Cliente");
        }

        public static DataTable cargarClientes(string nombre){
        return Conexion.consulta("SELECT * FROM Cliente WHERE Nombre =Upper( '" + nombre + "')");
        }

        public static int crearCliente(int cedula,string nombre,string apellido, int telefono,string direccion,string correo,int idCartera){
        string sql2 = "insert into Cliente(Cedula,Nombre,Apellido,Telefono, Direccion, Correo, Fk_Id_Cartera) values(@Cedula,upper(@Nombre),upper(@Apellido),@Telefono,@Direccion,@Correo,@Fk_Id_Cartera)";
                        SQLiteCommand cmd2 = new SQLiteCommand(sql2, Conexion.instanciaDb());
                        cmd2.Parameters.Add(new SQLiteParameter("@Cedula", cedula));
                        cmd2.Parameters.Add(new SQLiteParameter("@Nombre", nombre));
                        cmd2.Parameters.Add(new SQLiteParameter("@Apellido", apellido));
                        cmd2.Parameters.Add(new SQLiteParameter("@Telefono", telefono));
                        cmd2.Parameters.Add(new SQLiteParameter("@Direccion", direccion));
                        cmd2.Parameters.Add(new SQLiteParameter("@Correo", correo));
                        cmd2.Parameters.Add(new SQLiteParameter("@Fk_Id_Cartera", idCartera));
                        return  cmd2.ExecuteNonQuery();
        }

        public static int actualizarCliente(int Cliente_id,int cedula,string nombre,string apellido, int telefono,string direccion,string correo,int idCartera){
        string sql2_1 = "UPDATE Cliente SET Cedula=@Cedula, Nombre=Upper(@Nombre), Apellido=Upper(@Apellido), Telefono=@Telefono, Direccion=@Direccion, Correo=@Correo WHERE Id_Cliente=" + Cliente_id + "";
                    SQLiteCommand cmd2 = new SQLiteCommand(sql2_1, Conexion.instanciaDb());
                        cmd2.Parameters.Add(new SQLiteParameter("@Cedula", cedula));
                        cmd2.Parameters.Add(new SQLiteParameter("@Nombre", nombre));
                        cmd2.Parameters.Add(new SQLiteParameter("@Apellido", apellido));
                        cmd2.Parameters.Add(new SQLiteParameter("@Telefono", telefono));
                        cmd2.Parameters.Add(new SQLiteParameter("@Direccion", direccion));
                        cmd2.Parameters.Add(new SQLiteParameter("@Correo", correo));
                        cmd2.Parameters.Add(new SQLiteParameter("@Fk_Id_Cartera", idCartera));
                    return cmd2.ExecuteNonQuery();
        }
        
    }
}
