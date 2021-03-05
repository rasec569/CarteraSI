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
        }

        private void BtGuardarTipoPro_Click(object sender, EventArgs e)
        {
            if (Tipo_Productoid == 0)
            {
                tipo_producto.RegistrarTipoProducto(TxtNomTipoPro.Text);
            }
          else             {
                tipo_producto.ActualizarTipoProducto(Tipo_Productoid, TxtNomTipoPro.Text);
                
            }
            ListarTipoProducto();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int n = e.RowIndex;
            if (n != -1)
            {
                Tipo_Productoid = int.Parse( dataGridView1.Rows[n].Cells["Id_Tipo_Producto"].Value.ToString());
                TxtNomTipoPro.Text = dataGridView1.Rows[n].Cells["Nom_Tipo_Producto"].Value.ToString();
            }
        }

        private void Bt_EliminarTipoPro_Click(object sender, EventArgs e)
        {
            tipo_producto.EliminarTipoProducto(Tipo_Productoid);
            ListarTipoProducto();
        }
    }
}
