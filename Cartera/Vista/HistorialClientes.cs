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
    public partial class HistorialClientes : Form
    {
        CCliente_Producto cliente_producto = new CCliente_Producto();
        string ClienteId = "";
        public HistorialClientes()
        {
            InitializeComponent();
        }
        public HistorialClientes(string cliente)
        {
            InitializeComponent();
            ClienteId = cliente;
        }

        private void HistorialClientes_Load(object sender, EventArgs e)
        {
            ListarHistorial();
        }
        private void ListarHistorial()
        {
            dataGridView1.DataSource = cliente_producto.HistorialCliente(int.Parse(ClienteId));
            dataGridView1.Columns[3].HeaderText = "Producto";
            dataGridView1.Columns[4].HeaderText = "Estado";
            dataGridView1.Columns[5].HeaderText = "Fecha";
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        

    }
}
