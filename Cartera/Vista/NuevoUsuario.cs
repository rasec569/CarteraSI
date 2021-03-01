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
using Cartera.Controlador;


namespace Cartera.Vistas
{
    public partial class NuevoUsuario : Form
    {
        CProyecto proyecto = new CProyecto();
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
                int ok = proyecto.RegistrarProyecto(txtNombreP.Text, txtUbicacion.Text);
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
            dataGridView1.DataSource = proyecto.listarProyectos();
            //cambiar titulo de la columna
            dataGridView1.Columns["Id_Proyecto"].Visible = false;
            dataGridView1.Columns[1].HeaderText = "Nombre";
            dataGridView1.Columns[2].HeaderText = "Ubicación";
        }
        
            

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }
    }
}
