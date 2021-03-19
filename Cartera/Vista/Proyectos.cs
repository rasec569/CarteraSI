using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cartera.Controlador;

namespace Cartera.Vista
{
    public partial class Proyectos : Form
    {
        string idproyecto = "";
        CProyecto proyecto = new CProyecto();
        public Proyectos()
        {
            InitializeComponent();
            CargarProyectos();
        }

        private void BtGuardarProyecto_Click(object sender, EventArgs e)
        {
            ValidarCampos();
            if (ValidarCampos() == true)
            {
                if (idproyecto == "")
                {
                    proyecto.RegistrarProyecto(txtNombreP.Text, txtUbicacion.Text);
                }
                else
                {
                    proyecto.ActualizarProyecto(int.Parse(idproyecto), txtNombreP.Text, txtUbicacion.Text);
                }
                CargarProyectos();
                LimpiarCampos();
            }
        }

        private void Proyectos_Load(object sender, EventArgs e)
        {

        }
        private void CargarProyectos()
        {
            DataTable dtProyectos= proyecto.listarProyectos();
            dataGridView1.DataSource = dtProyectos;
            //cambiar titulo de la columna
            dataGridView1.Columns["Id_Proyecto"].Visible = false;
            dataGridView1.Columns[1].HeaderText = "Nombre";
            dataGridView1.Columns[2].HeaderText = "Ubicación";
            //QuitarFila();
        }
        private void QuitarFila()
        {
            dataGridView1.CurrentCell = null;
            dataGridView1.Rows[0].Visible = false;
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
        private void LimpiarCampos()
        {
            idproyecto = "";
            txtNombreP.Clear();
            txtUbicacion.Clear();
            BtBorrar.Enabled = false;
        }

        private void BtLimpiar_Click(object sender, EventArgs e)
        {
            if ((txtNombreP.Text != "")||(txtUbicacion.Text != ""))
            {
                LimpiarCampos();
            }
            else
            {
                MessageBox.Show("No hay campos que borrar");
            }
        }

        private void dataGridView1_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            LimpiarCampos();
            int n = e.RowIndex;
            if (n != -1)
            {
                idproyecto = dataGridView1.Rows[n].Cells["Id_Proyecto"].Value.ToString();
                txtNombreP.Text = dataGridView1.Rows[n].Cells["Proyecto_Nombre"].Value.ToString();
                txtUbicacion.Text = dataGridView1.Rows[n].Cells["Proyecto_Ubicacion"].Value.ToString();
            }
            BtBorrar.Enabled = true;
        }
        private void BtBorrar_Click(object sender, EventArgs e)
        {
            if (txtNombreP.Text!="")
            {
                proyecto.EliminarProyecto(int.Parse(idproyecto));
                LimpiarCampos();
                CargarProyectos();
                BtBorrar.Enabled = true;
            }
            else
            {
                MessageBox.Show("Seleccione un proyecto de la lista para eliminar");
            }
        }

        private void dataGridView1_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex >= 0 & e.RowIndex >= 0)
            {
                DataGridViewCell cell = this.dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
                cell.ToolTipText = "Doble clic para modificar proyecto";
            }
        }
    }
}
