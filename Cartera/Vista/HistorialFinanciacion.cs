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
    public partial class HistorialFinanciacion : Form
    {
        CFinanciacion financiacion = new CFinanciacion();
        int ProductoId;
        public HistorialFinanciacion()
        {
            InitializeComponent();
        }
        public HistorialFinanciacion(string IdProducto)
        {
            InitializeComponent();
            ProductoId = int.Parse(IdProducto);
        }

        private void HistorialFinanciacion_Load(object sender, EventArgs e)
        {
            cargarHistorialFinanciacion();
        }
        private void cargarHistorialFinanciacion()
        {
            dataGridView1.DataSource = financiacion.HistorialFinanciacion(ProductoId);
            dataGridView1.Columns[0].HeaderText = "Valor Financiación";
            dataGridView1.Columns[0].DefaultCellStyle.Format = "n1";
            dataGridView1.Columns[1].HeaderText = "Valor Inicial";
            dataGridView1.Columns[1].DefaultCellStyle.Format = "n1";
            dataGridView1.Columns[2].HeaderText = "Valor 30";
            dataGridView1.Columns[2].DefaultCellStyle.Format = "n1";
            dataGridView1.Columns[3].HeaderText = "cuotas 30";
            dataGridView1.Columns[4].HeaderText = "Valor cuotas 30";
            dataGridView1.Columns[4].DefaultCellStyle.Format = "n1";
            dataGridView1.Columns[5].HeaderText = "Valor 70";
            dataGridView1.Columns[5].DefaultCellStyle.Format = "n1";
            dataGridView1.Columns[6].HeaderText = "cuotas 70";
            dataGridView1.Columns[7].HeaderText = "Valor cuotas 70";
            dataGridView1.Columns[7].DefaultCellStyle.Format = "n1";
            dataGridView1.Columns[8].HeaderText = "Interes";
            dataGridView1.Columns[9].HeaderText = "Fecha recaudo";
            dataGridView1.Columns[10].HeaderText = "Estado";
        }
    }
}
