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

    public partial class Proyectos : Form
    {
        string idproyecto = "";
        int idtipo = 0;
        CProducto producto = new CProducto();
        DataTable DtProductos = new DataTable();
        DataTable DtReport = new DataTable();
        CProyecto proyecto = new CProyecto();
        private ReportesPDF reportesPDF;
        public Proyectos()
        {
            reportesPDF = new ReportesPDF();
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
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dataGridView1.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dataGridView1_RowPostPaint);
            //dataGridView1.Columns[2].Width = 270;
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
            panel1.Visible = false;
            idtipo = 0;
            idproyecto = "";
            dataGridView2.DataSource = "";
            dataGridView3.DataSource = "";
            dataGridView4.DataSource = "";
            tabControl1.SelectedIndex = 0;
            CargarProyectos();
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
            int x = dataGridView1.Rows.Count;
            if (n < x-1)
            {
                idproyecto = dataGridView1.Rows[n].Cells["Id_Proyecto"].Value.ToString();
                txtNombreP.Text = dataGridView1.Rows[n].Cells["Proyecto_Nombre"].Value.ToString();
                txtUbicacion.Text = dataGridView1.Rows[n].Cells["Proyecto_Ubicacion"].Value.ToString();
                BtBorrar.Enabled = true;
                panel1.Visible = true;
                CargarProducto();
            }
            else
            {
                MessageBox.Show("Campo no valido");
            }
            
        }
        private void BtBorrar_Click(object sender, EventArgs e)
        {
            if (txtNombreP.Text!="")
            {
                DtProductos = producto.cargarTodoProductosDetalleProyecto(int.Parse(idproyecto));
                if (DtProductos.Rows.Count < 1)
                {
                    proyecto.EliminarProyecto(int.Parse(idproyecto));
                    LimpiarCampos();
                    CargarProyectos();
                    BtBorrar.Enabled = true;
                }
                else
                {
                    MessageBox.Show("No se puede eliminar un proyecto con productos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }                
            }
            else
            {
                MessageBox.Show("Seleccione un proyecto de la lista para eliminar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
        private void CargarProducto()
        {
            try
            {
                if ((txtNombreP.Text != "") || (txtUbicacion.Text != ""))
                {
                    if (idtipo == 2)
                    {
                        DtProductos = producto.cargarTodoProductosDetalleProyecto(int.Parse(idproyecto));
                        dataGridView4.DataSource = DtProductos;
                        FormtearGridView(dataGridView4);
                        this.dataGridView4.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dataGridView4_RowPostPaint);
                    }
                    else
                    {
                        DtProductos = producto.cargarProductosDetalleProyecto(int.Parse(idproyecto), idtipo);
                        if (idtipo == 0)
                        {
                            dataGridView2.DataSource = DtProductos;
                            FormtearGridView(dataGridView2);
                            this.dataGridView2.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dataGridView2_RowPostPaint);
                        }
                        else if (idtipo == 1)
                        {
                            dataGridView3.DataSource = DtProductos;
                            FormtearGridView(dataGridView3);
                            this.dataGridView3.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dataGridView3_RowPostPaint);
                        }
                    }

                    DtReport = DtProductos.Copy();
                    DtReport.Columns.Remove("Id_Producto");
                    Int64 total = 0;
                    Int64 neto = 0;
                    Int64 pagado = 0;
                    foreach (DataRow row in DtProductos.Rows)
                    {
                        total += Convert.ToInt32(row["Valor Final"]);
                        neto += Convert.ToInt32(row["Valor Neto"]);
                        pagado += Convert.ToInt32(row["Pagado"]);
                    }
                    labelValor.Text = "VALOR TOTAL FINAL: $ " + String.Format("{0:N0}", total);
                    labelNeto.Text = "VALOR TOTAL NETO $ " + String.Format("{0:N0}", neto);
                    labelPagado.Text = "VALOR PAGADO $ " + String.Format("{0:N0}", pagado);
                    labelCantidad.Text = "CANTIDAD: " + DtProductos.Rows.Count;
                }                                   
            }
            catch
            {
                MessageBox.Show("Error al cargar productos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }           

        }
        void FormtearGridView(DataGridView Dtg)
        {
            Dtg.Columns["Id_Producto"].Visible = false;
            
            
            if (idtipo == 2)
            {
                Dtg.Columns[1].Width = 70;
                Dtg.Columns[2].Width = 70;
                Dtg.Columns[3].Width = 70;
                Dtg.Columns[4].Width = 170;
                Dtg.Columns[5].Width = 170;
                Dtg.Columns[10].Width = 80;
            }
            else
            {
                Dtg.Columns[1].Width = 70;
                Dtg.Columns[2].Width = 70;
                Dtg.Columns[3].Width = 70;
                Dtg.Columns[4].Width = 200;
                Dtg.Columns[5].Width = 200;
            }
            Dtg.Columns[6].DefaultCellStyle.Format = "n0";
            Dtg.Columns[7].DefaultCellStyle.Format = "n0";
            Dtg.Columns[8].DefaultCellStyle.Format = "n0";
        }        	
        
        private void dataGridView2_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dataGridView2.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 16, e.RowBounds.Location.Y + 4);
            }
        }

        private void dataGridView3_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dataGridView3.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 16, e.RowBounds.Location.Y + 4);
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
            {
                idtipo = 0;
                CargarProducto();
            }
            else if (tabControl1.SelectedIndex == 1)
            {
                idtipo = 1;
                CargarProducto();
            }
            else if (tabControl1.SelectedIndex == 2)
            {
                idtipo = 2;
                CargarProducto();
            }           
        }

        private void dataGridView4_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dataGridView4.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 16, e.RowBounds.Location.Y + 4);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {            
            if (tabControl1.SelectedIndex == 0)
            {
                reportesPDF.TipoProductosProyectos(DtReport, labelValor.Text, labelNeto.Text, labelPagado.Text, labelCantidad.Text, txtNombreP.Text, "LOTES");
            }
            else if (tabControl1.SelectedIndex == 1)
            {
                
                reportesPDF.TipoProductosProyectos(DtReport, labelValor.Text, labelNeto.Text, labelPagado.Text, labelCantidad.Text, txtNombreP.Text, "CASAS");
            }
            else if (tabControl1.SelectedIndex == 2)
            {
                reportesPDF.TodoTipoProductosProyectos(DtReport, labelValor.Text, labelNeto.Text, labelPagado.Text, labelCantidad.Text, txtNombreP.Text);
            }
            else
            {
                MessageBox.Show("Error al generar reporte", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dataGridView1.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 16, e.RowBounds.Location.Y + 4);
            }
        }
        public void exportarDatosExcel(DataGridView datalistado)
        {
            Microsoft.Office.Interop.Excel.Application exportarexcel = new Microsoft.Office.Interop.Excel.Application();
            exportarexcel.Application.Workbooks.Add(true);
            int indicecolumna = 0;
            foreach (DataGridViewColumn columna in datalistado.Columns)
            {
                indicecolumna++;
                exportarexcel.Cells[1, indicecolumna] = columna.Name;
            }
            int indicefila = 0;
            foreach (DataGridViewRow fila in datalistado.Rows)
            {
                indicefila++;
                indicecolumna = 0;
                foreach (DataGridViewColumn columna in datalistado.Columns)
                {
                    indicecolumna++;
                    exportarexcel.Cells[indicefila + 1, indicecolumna] = fila.Cells[columna.Name].Value;
                    exportarexcel.Columns.AutoFit();
                }
            }
            exportarexcel.Visible = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
            {
                exportarDatosExcel(dataGridView2);
            }
            else if (tabControl1.SelectedIndex == 1)
            {
                exportarDatosExcel(dataGridView3);
            }
            else if (tabControl1.SelectedIndex == 2)
            {
                exportarDatosExcel(dataGridView4);
            }
            else
            {
                MessageBox.Show("Error al generar reporte", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
