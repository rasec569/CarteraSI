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

namespace Cartera.Vistas
{
    public partial class NuevoUsuario : Form
    {
        public NuevoUsuario()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sql = "insert into Cliente(Cedula,Nombre,Apellido,Telefono, Direccion, Correo, Fk_ID_Cartera) values(@Cedula,@Nombre,@Apellido,@Telefono,@Direccion,@Correo,@Fk_ID_Cartera)";
            SQLiteCommand cmd = new SQLiteCommand(sql, Conexion.instanciaDb());
            cmd.Parameters.Add(new SQLiteParameter("@Cedula", txtCedula.Text));
            cmd.Parameters.Add(new SQLiteParameter("@Nombre", txtNombres.Text));
            cmd.Parameters.Add(new SQLiteParameter("@Apellido", txtApellidos.Text));
            cmd.Parameters.Add(new SQLiteParameter("@Telefono", txtTelefono.Text));
            cmd.Parameters.Add(new SQLiteParameter("@Direccion", txtCedula.Text));
            cmd.Parameters.Add(new SQLiteParameter("@Correo", txtCorreo.Text));
            cmd.Parameters.Add(new SQLiteParameter("@Fk_ID_Cartera", "1"));
            cmd.ExecuteNonQuery();
            CargarClientes();

        }

        private void NuevoUsuario_Load(object sender, EventArgs e)
        {
            CargarClientes();
        }
        private void CargarClientes()
        {
            dataGridView1.DataSource = Conexion.consulta("Select Cedula, Nombre, Apellido, Telefono, Direccion, Correo  from Cliente");
            //cambiar titulo de la columna
            dataGridView1.Columns[0].HeaderText = "Cédula de identidad";
        }

        private void txtTelefono_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void txtDireccion_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtCorreo_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void txtApellidos_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txtNombres_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtCedula_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
