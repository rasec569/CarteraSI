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
    public class MCliente : CCliente
    {
        public Int64 ID_Cliente { get; set; }
        public Int64 Cedula { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public Int64 Telefono { get; set; }
        public string Direccion { get; set; }
        public string Correo { get; set; }
        public Int64 IdCartera { get; set; }

        public DataTable cargarClientes(){
        return Conexion.consulta("Select Id_Cliente, Cedula, Nombre, Apellido, Telefono, Direccion, Correo, Fk_Id_Cartera  from Cliente");
        }

        public DataTable cargarClientes(string nombre){
        return Conexion.consulta("SELECT * FROM Cliente WHERE Nombre =Upper( '" + nombre + "')");
        }

        public int crearCliente(int cedula,string nombre,string apellido, int telefono,string direccion,string correo,int idCartera){
        string sql = "insert into Cliente(Cedula,Nombre,Apellido,Telefono, Direccion, Correo, Fk_Id_Cartera) values(@Cedula,upper(@Nombre),upper(@Apellido),@Telefono,@Direccion,@Correo,@Fk_Id_Cartera)";
                        SQLiteCommand cmd = new SQLiteCommand(sql, Conexion.instanciaDb());
                        cmd.Parameters.Add(new SQLiteParameter("@Cedula", cedula));
                        cmd.Parameters.Add(new SQLiteParameter("@Nombre", nombre));
                        cmd.Parameters.Add(new SQLiteParameter("@Apellido", apellido));
                        cmd.Parameters.Add(new SQLiteParameter("@Telefono", telefono));
                        cmd.Parameters.Add(new SQLiteParameter("@Direccion", direccion));
                        cmd.Parameters.Add(new SQLiteParameter("@Correo", correo));
                        cmd.Parameters.Add(new SQLiteParameter("@Fk_Id_Cartera", idCartera));
                        return  cmd.ExecuteNonQuery();
        }

        public int actualizarCliente(int Cliente_id,int cedula,string nombre,string apellido, int telefono,string direccion,string correo,int idCartera){
        string sql = "UPDATE Cliente SET Cedula=@Cedula, Nombre=Upper(@Nombre), Apellido=Upper(@Apellido), Telefono=@Telefono, Direccion=@Direccion, Correo=@Correo WHERE Id_Cliente=" + Cliente_id + "";
                    SQLiteCommand cmd = new SQLiteCommand(sql, Conexion.instanciaDb());
                        cmd.Parameters.Add(new SQLiteParameter("@Cedula", cedula));
                        cmd.Parameters.Add(new SQLiteParameter("@Nombre", nombre));
                        cmd.Parameters.Add(new SQLiteParameter("@Apellido", apellido));
                        cmd.Parameters.Add(new SQLiteParameter("@Telefono", telefono));
                        cmd.Parameters.Add(new SQLiteParameter("@Direccion", direccion));
                        cmd.Parameters.Add(new SQLiteParameter("@Correo", correo));
                        cmd.Parameters.Add(new SQLiteParameter("@Fk_Id_Cartera", idCartera));
                    return cmd.ExecuteNonQuery();
        }
        
    }
}
