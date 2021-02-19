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
        private void NuevoUsuario_Load(object sender, EventArgs e)
        {
            CargarProyectos();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ValidarCampos();
            if (ValidarCampos() == true)
            {
                string sql = "insert into Proyecto(Proyecto_Nombre,Proyecto_Ubicacion) values(@Proyecto_Nombre,@Proyecto_Ubicacion)";
                SQLiteCommand cmd = new SQLiteCommand(sql, Conexion.instanciaDb());
                cmd.Parameters.Add(new SQLiteParameter("@Proyecto_Nombre", txtNombreP.Text));
                cmd.Parameters.Add(new SQLiteParameter("@Proyecto_Ubicacion", txtUbicacion.Text));
                int ok = cmd.ExecuteNonQuery();
                if (ok > 0)
                {
                    MessageBox.Show("Registro exitoso");
                }
                CargarProyectos();
            }
                
        }
        private bool ValidarCampos()
        {
            bool ok = true;
            if (txtNombreP.Text == "")
            {
                ok = false;
                errorProvider1.SetError(txtNombreP, "Digite Nombre Proyecto");
            }
            else
            {
                ok = true;
                errorProvider1.Clear();
            }
            if (txtUbicacion.Text == "")
            {
                ok = false;
                errorProvider1.SetError(txtUbicacion, "Digite Ubicacion");
            }
            else
            {
                ok = true;
                errorProvider1.Clear();
            }
            return ok;
        }

        private void CargarProyectos()
        {
            dataGridView1.DataSource = Conexion.consulta("SELECT* from Proyecto");
            //cambiar titulo de la columna
            dataGridView1.Columns["Id_Proyecto"].Visible = false;
            dataGridView1.Columns[1].HeaderText = "Nombre";
            dataGridView1.Columns[2].HeaderText = "Ubicación";
        }
        
            private void txtNombreP_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }
    }
}
