﻿using System;
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
        Loading cargando;
        CProducto producto = new CProducto();
        DataTable DtProductos = new DataTable();
        DataTable DtReport = new DataTable();
        CProyecto proyecto = new CProyecto();
        private ReportesPDF reportesPDF;
        DataTable Dtproyectos = new DataTable();
        public Productos()
        {
            InitializeComponent();
            reportesPDF = new ReportesPDF();
            
        }

        private void Productos_Load(object sender, EventArgs e)
        {
            //CargarProducto();
            autocompletar();
            Dtproyectos = proyecto.listarProyectos();
            DataRow nueva = Dtproyectos.NewRow();
            nueva["Id_Proyecto"] = 4;
            nueva["Proyecto_Nombre"] = "TODOS LOS PROYECTOS";
            Dtproyectos.Rows.InsertAt(nueva, 0);
            comboProyectos.DataSource = Dtproyectos;
            comboProyectos.DisplayMember = "Proyecto_Nombre";
            comboProyectos.ValueMember = "Id_Proyecto";
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
            FormtearTodosGridView();
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
        void FormtearTodosGridView()
        {   
            dataGridView1.Columns["Id_Producto"].Visible = false;
            dataGridView1.Columns["Fk_Id_Proyecto"].Visible = false;
            dataGridView1.Columns["Fk_Id_Tipo_Producto"].Visible = false;
            dataGridView1.Columns["Id_Financiacion"].Visible = false;
            dataGridView1.Columns["Contrato"].Visible = false;
            dataGridView1.Columns["Valor Neto"].DefaultCellStyle.Format = "n0";
            dataGridView1.Columns["Valor Neto"].Width = 80;
            dataGridView1.Columns["Valor Total"].DefaultCellStyle.Format = "n0";
            dataGridView1.Columns["Valor Total"].Width = 80;
            dataGridView1.Columns["Fecha Venta"].Width = 70;
            dataGridView1.Columns["Proyecto"].Width = 160;
            dataGridView1.Columns["Tipo"].Width = 50;
            dataGridView1.Columns["Cuotas Inicial"].Width = 50;
            dataGridView1.Columns["Valor Cuota Inicial"].Width = 80;
            dataGridView1.Columns["Valor Cuota Inicial"].DefaultCellStyle.Format = "n0";
            dataGridView1.Columns["Cuotas Saldo"].Width = 50;
            dataGridView1.Columns["Valor Cuota Saldo"].Width = 80;
            dataGridView1.Columns["Valor Cuota Saldo"].DefaultCellStyle.Format = "n0";
            dataGridView1.Columns["Fecha Recaudo"].Width = 70;
            dataGridView1.Columns["Inicial"].Visible = false;
            dataGridView1.Columns["Valor Inicial"].Visible = false;
            dataGridView1.Columns["Valor Saldo"].Visible = false;
            dataGridView1.Columns["Interes"].Visible = false;
            dataGridView1.Columns["Observaciones"].Visible = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
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
            string tipoproducto = "";

            int n = e.RowIndex;
            if (n != -1)
            {
                idproducto = dataGridView1.Rows[n].Cells["Id_Producto"].Value.ToString();
                nombreproducto = dataGridView1.Rows[n].Cells["Producto"].Value.ToString();
                tipoproducto = dataGridView1.Rows[n].Cells["Tipo"].Value.ToString();
                


            }
//BtBorrar.Enabled = true;
            Seguimiento se = new Seguimiento(idproducto, nombreproducto, tipoproducto);
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

       

        private void comboProyectos_SelectedIndexChanged(object sender, EventArgs e)
        {
            try

            {
                if (comboProyectos.SelectedIndex == 0)
                {
                    CargarProducto();
                }
                else
                {
                    dataGridView1.DataSource = "";
                    DtProductos = producto.cargarProductosProyecto(int.Parse(comboProyectos.SelectedIndex.ToString()) - 1);
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
                        total += Convert.ToInt32(row["Valor Total"].ToString().Replace(",", ""));
                    }
                    labelValor.Text = "TOTAL: $ " + String.Format("{0:N0}", total);
                    labelCantidad.Text = "CANTIDAD: " + DtProductos.Rows.Count;
                }                
            }
            catch/*(Exception ex)*/
            {
                //MessageBox.Show("Error"+ex);

            }
        }

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dataGridView1.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 16, e.RowBounds.Location.Y + 4);
            }
        }
        public async Task exportarDatosExcel(DataGridView datalistado)
        {
            Mostrar();
            var cargar = new Task(() =>
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
            });
            cargar.Start();
            await cargar;
            cerrar();
        }
        public void Mostrar()
        {
            cargando = new Loading();
            cargando.Show();
        }
        public void cerrar()
        {
            if (cargando != null)
                cargando.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            exportarDatosExcel(dataGridView1);
        }
    }
}
