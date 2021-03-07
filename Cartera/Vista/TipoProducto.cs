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
    public partial class TipoProducto : Form
    {
        CTipo_Producto tipo_producto = new CTipo_Producto();
        public int Tipo_Productoid = 0;
        public TipoProducto()
        {
            InitializeComponent();
        }

        private void TipoProducto_Load(object sender, EventArgs e)
        {
            ListarTipoProducto();
        }
        private void ListarTipoProducto()
        {
            dataGridView1.DataSource= tipo_producto.listarTipoProducto();
            dataGridView1.Columns["Id_Tipo_Producto"].Visible = false;
            dataGridView1.Columns[1].HeaderText = "Tipo Producto";
            dataGridView1.CurrentCell = null;
            dataGridView1.Rows[0].Visible = false;
        }

        private void BtGuardarTipoPro_Click(object sender, EventArgs e)
        {
            ValidarCampos();
            if (ValidarCampos() == true)
            {
                if (Tipo_Productoid == 0)
                {
                    tipo_producto.RegistrarTipoProducto(TxtNomTipoPro.Text);
                }
                else
                {
                    tipo_producto.ActualizarTipoProducto(Tipo_Productoid, TxtNomTipoPro.Text);

                }
                ListarTipoProducto();
            }
            TxtNomTipoPro.Clear();
            BtLimpiarTp.Enabled = false;
            Bt_EliminarTipoPro.Enabled = false;
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int n = e.RowIndex;
            if (n != -1)
            {
                TxtNomTipoPro.Clear();
                Tipo_Productoid = int.Parse( dataGridView1.Rows[n].Cells["Id_Tipo_Producto"].Value.ToString());
                TxtNomTipoPro.Text = dataGridView1.Rows[n].Cells["Nom_Tipo_Producto"].Value.ToString();
                Bt_EliminarTipoPro.Enabled = true;
                BtLimpiarTp.Enabled = true;
            }
        }

        private void Bt_EliminarTipoPro_Click(object sender, EventArgs e)
        {
            tipo_producto.EliminarTipoProducto(Tipo_Productoid);
            ListarTipoProducto();
            Tipo_Productoid = 0;
            TxtNomTipoPro.Clear();
            Bt_EliminarTipoPro.Enabled = false;
            BtLimpiarTp.Enabled = false;
        }

        private bool ValidarCampos()
        {
            bool ok = true;
            if (TxtNomTipoPro.Text == "")
            {
                ok = false;
                errorProvider1.SetError(TxtNomTipoPro, "Digite Nombre Tipo Producto");
            }
            else
            {
                ok = true;
                errorProvider1.Clear();
            }
            
            return ok;
        }

        private void BtLimpiarTp_Click(object sender, EventArgs e)
        {
            TxtNomTipoPro.Clear();
            Tipo_Productoid = 0;
            Bt_EliminarTipoPro.Enabled = false;
            BtLimpiarTp.Enabled = false;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
