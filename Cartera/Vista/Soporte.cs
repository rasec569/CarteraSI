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
    public partial class Soporte : Form
    {
        CUsuario usuario = new CUsuario();
        DataTable dtUsuarios = new DataTable();
        public Soporte()
        {
            InitializeComponent();
            CargarUsuarios();
        }

        private void Soporte_Load(object sender, EventArgs e)
        {

        }
        private void CargarUsuarios()
        {
            dtUsuarios = usuario.listarUsuario();
            dataGridView1.DataSource = dtUsuarios;
            dataGridView1.Columns["Id_usuario"].Visible = false;
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            string user = dtUsuarios.Rows[0]["Usuario"].ToString();
            
            if (e.ColumnIndex == 2 && e.Value != null /*&& user != "admin"*/)
            {
                e.Value = new string('*', e.Value.ToString().Length);
            }
        }
    }
}
