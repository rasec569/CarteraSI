using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using Cartera.Vista;
using Cartera.Vistas;

namespace Cartera.Vista
{
    public partial class Clientes : Form

    {
        
        private SQLiteConnection con;
        public Clientes()
        {
            InitializeComponent();
            
    }

        private void Clientes_Load(object sender, EventArgs e)
        {
            CargarClientes();
        }
        

        private void BtBuscarCliente_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtBuscarCliente.Text != "")
                {
                    Panel_Registrar_user.Visible = true;
                    string nom = txtBuscarCliente.Text;
                    DataTable DtUsuario = Conexion.consulta("SELECT * FROM Cliente WHERE Nombre =Upper( '" + nom + "')");
                    txtCedula.Text = DtUsuario.Rows[0]["Cedula"].ToString();
                    txtNombres.Text = DtUsuario.Rows[0]["Nombre"].ToString();
                    txtApellidos.Text = DtUsuario.Rows[0]["Apellido"].ToString();
                    txtTelefono.Text = DtUsuario.Rows[0]["Telefono"].ToString();
                    txtDireccion.Text = DtUsuario.Rows[0]["Direccion"].ToString();
                    txtCorreo.Text = DtUsuario.Rows[0]["Correo"].ToString();
                    string Cartera = DtUsuario.Rows[0]["Fk_ID_Cartera"].ToString();
                    DataTable DtProdutos = Conexion.consulta("SELECT * FROM Producto INNER join Cartera on ID_Cartera = Fk_ID_Cartera WHERE ID_Cartera = " + Cartera + "");
                }
                else
                {
                    MessageBox.Show("ingrese un nombre a buscar");
                }
            }
            catch
            {
                MessageBox.Show("error");
            }
            
        }       
        private void CargarClientes()
        {
            dataGridView1.DataSource = Conexion.consulta("Select Cedula, Nombre, Apellido, Telefono, Direccion, Correo  from Cliente");
        }

        private void BtGuardarCliente_Click(object sender, EventArgs e)
        {
            string sql1 = "insert into Cartera(Estado_cartera,Total_Neto_Recaudado,Total_mora,Total_Cartera) values (@Estado_cartera,@Total_Neto_Recaudado,@Total_mora,@Total_Cartera)";
            SQLiteCommand cmd = new SQLiteCommand(sql1, Conexion.instanciaDb());
            cmd.Parameters.Add(new SQLiteParameter("@Estado_cartera", "Nueva"));
            cmd.Parameters.Add(new SQLiteParameter("@Total_Neto_Recaudado", "0"));
            cmd.Parameters.Add(new SQLiteParameter("@Total_mora", "0"));
            cmd.Parameters.Add(new SQLiteParameter("@Total_Cartera", "0"));
            cmd.ExecuteNonQuery();
            
            DataTable DtCartera = Conexion.consulta("SELECT max(ID_Cartera) FROM Cartera ORDER BY ID_Cartera DESC");
            string sql2 = "insert into Cliente(Cedula,Nombre,Apellido,Telefono, Direccion, Correo, Fk_ID_Cartera) values(@Cedula,upper(@Nombre),upper(@Apellido),@Telefono,@Direccion,@Correo,@Fk_ID_Cartera)";
            SQLiteCommand cmd1 = new SQLiteCommand(sql2, Conexion.instanciaDb());
            cmd1.Parameters.Add(new SQLiteParameter("@Cedula", txtCedula.Text));
            cmd1.Parameters.Add(new SQLiteParameter("@Nombre", txtNombres.Text));
            cmd1.Parameters.Add(new SQLiteParameter("@Apellido", txtApellidos.Text));
            cmd1.Parameters.Add(new SQLiteParameter("@Telefono", txtTelefono.Text));
            cmd1.Parameters.Add(new SQLiteParameter("@Direccion", txtCedula.Text));
            cmd1.Parameters.Add(new SQLiteParameter("@Correo", txtCorreo.Text));
            cmd1.Parameters.Add(new SQLiteParameter("@Fk_ID_Cartera", DtCartera.Rows[0]["max(ID_Cartera)"].ToString()));
            cmd1.ExecuteNonQuery();
            Panel_Registrar_user.Visible = false;
            //Panel_Clientes.Visible = true;
            CargarClientes();
        }

        private void BtNuevoCliente_Click(object sender, EventArgs e)
        {
            Panel_Registrar_user.Visible = true;
            txtCedula.Clear();
            txtNombres.Clear();
            txtApellidos.Clear();
            txtTelefono.Clear();
            txtCedula.Clear();
            txtCorreo.Clear();
            //Panel_Clientes.Visible = false;

        }
    }
}
