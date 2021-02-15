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
            try
            {
                con = new SQLiteConnection("Data Source=data.db");
                con.Open();
            }
            catch (SQLiteException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void BtGuardarCliente_Click(object sender, EventArgs e)
        {
            Panel_Registrar_user.Visible = false;
            //Escribimos la cadena sql
            string cadenaSQL = "insert into Cartera(Estado_cartera,Total_Neto_Recaudado,Total_mora,Total_Cartera) values(" +"al dia" +"," + 0 + "," + 0 + "," + 0 + ");";
            string cadenaSQL2 = "insert into Cliente(Cedula,Nombre,Apellido,Telefono, Direccion, Correo) values('" + txtCedula.Text + "'," + txtNombres.Text + "," + txtApellidos.Text + ");";
            //preparamos la cadena pra insercion
            SQLiteCommand command = new SQLiteCommand(cadenaSQL, con);
            //y la ejecutamos
            command.ExecuteNonQuery();
            //finalmente cerramos la conexion ya que solo debe servir para una sola orden
            command.Dispose();
        }

        private void BtNuevoCliente_Click(object sender, EventArgs e)
        {
            Panel_Registrar_user.Visible = true;
            Panel_Clientes.Visible = false;
            PanelSuperior.Visible = false;
        }

        private void BtBuscarCliente_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
