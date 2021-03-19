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
    public class MCliente
    {
        public int ID_Cliente { get; set; }
        public int Cedula { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public string Correo { get; set; }
        public int IdCartera { get; set; }

        public static DataTable cargarClientes(){
        return Conexion.consulta("Select Id_Cliente, Cedula, Nombre, Apellido, Telefono, Direccion, Correo, Fk_Id_Cartera from Cliente INNER JOIN Cliente_Producto on Pfk_ID_Cliente = Id_Cliente WHERE Estado_Cliente='Activo' GROUP by Id_Cliente ORDER by Nombre");
        }

        public static DataTable cargarClientes(string nombre){
        return Conexion.consulta("SELECT * FROM Cliente WHERE Nombre =Upper( '" + nombre + "')");
        }
        public static DataTable BuscarClientesCedula(string cedula)
        {
            return Conexion.consulta("SELECT * FROM Cliente WHERE Cedula ='" + cedula + "'");
        }

        public static int crearCliente(string cedula,string nombre,string apellido, string telefono,string direccion,string correo,int idCartera){
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

        public static int actualizarCliente(string Cliente_id, string cedula,string nombre,string apellido, string telefono,string direccion,string correo,int idCartera){
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

        public static DataTable ultimoCliente()
        {
            
            return Conexion.consulta("SELECT max(Id_Cliente) FROM Cliente ORDER BY Id_Cliente DESC");
        }
        
    }
}
