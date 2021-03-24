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
using Cartera.Reportes;

namespace Cartera.Vista
{
    public partial class Productos : Form
    {
        CProducto producto = new CProducto();
        DataTable DtProductos = new DataTable();
        DataTable DtReport = new DataTable();
        private ReportesPDF reportesPDF;
        public Productos()
        {
            InitializeComponent();
            reportesPDF = new ReportesPDF();
        }

        private void Productos_Load(object sender, EventArgs e)
        {
            CargarProducto();
            autocompletar();
        }
        private void CargarProducto()
        {
            dataGridView1.DataSource = producto.cargarProductos();
            FormtearGridView();
            DataTable DtValorProductos = producto.ValorReportProducto();
            int total = int.Parse(DtValorProductos.Rows[0]["valor"].ToString());
            labelValor.Text = "TOTAL: $" + String.Format("{0:N1}", total);
            labelCantidad.Text = "CANTIDAD: " + DtValorProductos.Rows[0]["productos"].ToString();
        }

        private void BtBuscarProducto_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = "";
            dataGridView1.DataSource = producto.BuscarProductos(txtBuscarProducto.Text);
            FormtearGridView();
        }
        void FormtearGridView()
        {
            dataGridView1.Columns["Id_Producto"].Visible = false;
            dataGridView1.Columns["Fk_Id_Proyecto"].Visible = false;
            dataGridView1.Columns["Fk_Id_Tipo_Producto"].Visible = false;
            dataGridView1.Columns["Id_Financiacion"].Visible = false;
            dataGridView1.Columns[4].DefaultCellStyle.Format = "n1";
            dataGridView1.Columns["Inicial"].Visible = false;
            dataGridView1.Columns["Valor 30"].Visible = false;
            dataGridView1.Columns["Cuotas 30"].Visible = false;
            dataGridView1.Columns["Valor Cuota 30"].Visible = false;
            dataGridView1.Columns["Valor 70"].Visible = false;
            dataGridView1.Columns["Cuotas 70"].Visible = false;
            dataGridView1.Columns["Valor Cuota 70"].Visible = false;
            dataGridView1.Columns["Interes"].Visible = false;
            dataGridView1.Columns["Fecha Recaudo"].Visible = false;
        }
        void autocompletar()
        {
            AutoCompleteStringCollection lista = new AutoCompleteStringCollection();
            DtProductos = producto.cargarProductos();
            DtReport = DtProductos.Copy();
            DtReport.Columns.Remove("Id_Producto");
            DtReport.Columns.Remove("Fk_Id_Proyecto");
            DtReport.Columns.Remove("Fk_Id_Tipo_Producto");
            DtReport.Columns.Remove("Id_Financiacion");
            DtReport.Columns.Remove("Observaciones");

            for (int i = 0; i < DtProductos.Rows.Count; i++)
            {
                lista.Add(DtProductos.Rows[i]["Producto"].ToString());
            }
            txtBuscarProducto.AutoCompleteCustomSource = lista;
        }

        private void btTipoProducto_Click(object sender, EventArgs e)
        {
            TipoProducto tipo = new TipoProducto();
            tipo.Show();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string idproducto = "";
            string nombreproducto = "";

            int n = e.RowIndex;
            if (n != -1)
            {
                idproducto = dataGridView1.Rows[n].Cells["Id_Producto"].Value.ToString();
                nombreproducto = dataGridView1.Rows[n].Cells["Producto"].Value.ToString();
                
            }
//BtBorrar.Enabled = true;
            Seguimiento se = new Seguimiento(idproducto, nombreproducto);
            se.Show();
        }

        private void dataGridView1_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex >= 0 & e.RowIndex >= 0)
            {
                DataGridViewCell cell = this.dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
                cell.ToolTipText = "Doble clic para nostrar seguimiento";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            reportesPDF.Productos(DtReport);
        }
    }
}
