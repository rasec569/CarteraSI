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
        CProyecto proyecto = new CProyecto();
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
            DtProductos = producto.cargarProductos();
            DtReport = DtProductos.Copy();
            DtReport.Columns.Remove("Id_Producto");
            DtReport.Columns.Remove("Fk_Id_Proyecto");
            DtReport.Columns.Remove("Fk_Id_Tipo_Producto");
            DtReport.Columns.Remove("Id_Financiacion");
            DtReport.Columns.Remove("Observaciones");
            dataGridView1.DataSource = DtProductos;
            FormtearGridView();
            DataTable DtValorProductos = producto.ValorReportProducto();
            Int64 total = Int64.Parse(DtValorProductos.Rows[0]["valor"].ToString());
            labelValor.Text = "TOTAL: $ " + String.Format("{0:N0}", total);
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
            dataGridView1.Columns["Contrato"].Visible = false;
            dataGridView1.Columns[4].DefaultCellStyle.Format = "n0";
            dataGridView1.Columns[5].DefaultCellStyle.Format = "n0";
            dataGridView1.Columns[6].Width = 50;
            dataGridView1.Columns[8].Width = 160;
            dataGridView1.Columns[11].Width = 32;
            dataGridView1.Columns[12].Width = 50;
            dataGridView1.Columns[12].DefaultCellStyle.Format = "n0";
            dataGridView1.Columns[14].Width = 32;
            dataGridView1.Columns[15].Width = 50;
            dataGridView1.Columns[15].DefaultCellStyle.Format = "n0";
            dataGridView1.Columns["Inicial"].Visible = false;
            dataGridView1.Columns["Valor Inicial"].Visible = false;
            dataGridView1.Columns["Valor Saldo"].Visible = false;
            dataGridView1.Columns["Interes"].Visible = false;
            dataGridView1.Columns["Observaciones"].Visible = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }
        void autocompletar()
        {
            AutoCompleteStringCollection lista = new AutoCompleteStringCollection();
            DtProductos = producto.cargarProductos();

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

        private void comboProyectos_MouseClick(object sender, MouseEventArgs e)
        {
            if (comboProyectos.Text == "TODOS LOS PROYECTOS")
            {
                comboProyectos.DataSource = proyecto.listarProyectos();
                comboProyectos.DisplayMember = "Proyecto_Nombre";
                comboProyectos.ValueMember = "Id_Proyecto";
            }

        }

        private void comboProyectos_SelectedIndexChanged(object sender, EventArgs e)
        {
            try

            {
                dataGridView1.DataSource = "";
                DtProductos = producto.cargarProductosProyecto(int.Parse(comboProyectos.SelectedIndex.ToString()));
                DtReport = DtProductos.Copy();
                DtReport.Columns.Remove("Id_Producto");
                DtReport.Columns.Remove("Fk_Id_Proyecto");
                DtReport.Columns.Remove("Fk_Id_Tipo_Producto");
                DtReport.Columns.Remove("Id_Financiacion");
                DtReport.Columns.Remove("Observaciones");
                dataGridView1.DataSource = DtProductos;
                FormtearGridView();
                Int64 total = 0;
                foreach (DataRow row in DtProductos.Rows)
                {
                    total += Convert.ToInt32(row["Valor Total"]);
                }
                labelValor.Text = "TOTAL: $ " + String.Format("{0:N0}", total);
                labelCantidad.Text = "CANTIDAD: " + DtProductos.Rows.Count;
            }
            catch
            {

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            comboProyectos.Text = "TODOS LOS PROYECTOS";
            CargarProducto();
        }

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dataGridView1.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 16, e.RowBounds.Location.Y + 4);
            }
        }
    }
}
