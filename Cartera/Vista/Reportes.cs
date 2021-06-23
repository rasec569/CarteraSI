using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cartera.Controlador;
using Cartera.Reportes;

namespace Cartera.Vista
{
    public partial class Reportes : Form
    {
        CPago pagos = new CPago();
        CProducto producto= new CProducto();
        CCuota cuota = new CCuota();
        CCartera cartera = new CCartera();
        DataTable DtPagos = new DataTable();
        DataTable DtVentas = new DataTable();
        DataTable DtDisolucion = new DataTable();
        private ReportesPDF reportesPDF;
        public Reportes()
        {
            InitializeComponent();
            reportesPDF = new ReportesPDF();
            DateTime actual = DateTime.ParseExact(DateTime.Now.ToString("yyyy-MM-dd"), "yyyy-MM-dd", CultureInfo.InvariantCulture);
            dateInicio.Text = actual.AddMonths(-1).ToString();
            dateInicio2.Text = actual.AddMonths(-1).ToString();
            dateInicio3.Text = actual.AddMonths(-1).ToString();
            dateInicio4.Text = actual.AddMonths(-1).ToString();
        }        
        private void Reportes_Load(object sender, EventArgs e)
        {
            CargarRpPagos();
            try
            {
                dataGridView1.Columns[6].DefaultCellStyle.Format = "n0";
                dataGridView1.Columns[8].DefaultCellStyle.Format = "n0";
            }
            catch
            {
            }            
        }
        void CargarRpVentas()
        {
            try
            {
                DtVentas = producto.ReportVentas(dateInicio2.Text, datefin2.Text);
                DataTable DtValorVentas = producto.ValorReportVentas(dateInicio2.Text, datefin2.Text);
                Int64 total = Int64.Parse(DtValorVentas.Rows[0]["valor"].ToString()); 
                labelTotalVentas.Text ="TOTAL VENTAS: $" + String.Format("{0:N0}", total);
                labelVentas.Text = "CANTIDAD: " + DtValorVentas.Rows[0]["productos"].ToString();
                dataGridView2.DataSource = DtVentas;
                dataGridView2.Columns[3].DefaultCellStyle.Format = "n0"; 
                dataGridView2.Columns["Cedula"].Visible = false;
                dataGridView2.Columns[2].Width = 80;
                dataGridView2.Columns[3].Width = 80;
                dataGridView2.Columns[4].Width = 80;                
                dataGridView2.Columns[6].Width = 250;
                dataGridView2.Columns[7].Width = 250;
                dataGridView2.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            catch
            {
                MessageBox.Show("Sin datos para el reporte, seleccione un nuevo rango de fechas", "No hay resultados", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }            
        }
        void CargarRpPagos()
        {
            try
            {            
            DtPagos = pagos.reportPagos(dateInicio.Text, datefin.Text);
            DataTable DtValorPagos = pagos.ValorReportPagos(dateInicio.Text, datefin.Text);
            Int64 total = Int64.Parse(DtValorPagos.Rows[0]["valor"].ToString());
            labelTotal.Text = "TOTAL INGRESOS: $" + String.Format("{0:N0}", total);
            labelNumero.Text ="CANTIDAD: "+ DtValorPagos.Rows[0]["pagos"].ToString();
            dataGridView1.DataSource = DtPagos;
            dataGridView1.Columns[1].Width = 50;
            dataGridView1.Columns[2].Width = 80;
            dataGridView1.Columns[3].Width = 230;
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            catch
            {
                MessageBox.Show("Sin datos para el reporte, seleccione un nuevo rango de fechas", "No hay resultados", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }    
        void actulziarCuotas()
        {
            DataTable DtProducto = producto.cargarProductos();
            for(int i=0; i<DtProducto.Rows.Count; i++)
            {
                string id_producto = DtProducto.Rows[i]["Id_Producto"].ToString();
                int id_financiacion = int.Parse(DtProducto.Rows[i]["Id_Financiacion"].ToString());
                int Valor_Producto_Financiacion = int.Parse(DtProducto.Rows[i]["Valor Total"].ToString());
                int valor_entrada = int.Parse(DtProducto.Rows[i]["Inicial"].ToString());
                int valor_sin_interes = int.Parse(DtProducto.Rows[i]["Valor Inicial"].ToString());
                int Cuotas_sin_interes = int.Parse(DtProducto.Rows[i]["Cuotas Inicial"].ToString());
                int Valor_cuota_sin_interes = int.Parse(DtProducto.Rows[i]["Valor Cuota Inicial"].ToString());
                int Valor_con_interes = int.Parse(DtProducto.Rows[i]["Valor Saldo"].ToString());
                int Cuotas_Con_Interes = int.Parse(DtProducto.Rows[i]["Cuotas Saldo"].ToString());
                int Valor_Cuota_Con_Interes = int.Parse(DtProducto.Rows[i]["Valor Cuota Saldo"].ToString());
                string Fecha_Recaudo = DtProducto.Rows[i]["Fecha Recaudo"].ToString();
                DateTime date = DateTime.ParseExact(Fecha_Recaudo, "yyyy-MM-dd", CultureInfo.InvariantCulture);
                if (Valor_Producto_Financiacion > 0 /*&& id_financiacion !=  0*/)
                {
                    DataTable dtCuotas = cuota.ListarCuotas(id_financiacion);
                    DataTable dtrecaudo = pagos.Tota_Recaudado_Producto(id_producto);
                    int ValorPagado = int.Parse(dtrecaudo.Rows[0]["sum(Valor_Pagado)"].ToString());
                    int num_cuota = 1;
                    int pagado = 0;
                    string Estado = "";
                    pagado = valor_entrada;
                    if (pagado <= ValorPagado)
                    {
                        Estado = "Pagada";
                    }
                    else
                    {
                        Estado = "Pendiente";
                    }
                    if (dtCuotas.Rows.Count == 0)
                    {
                        cuota.CrearCuota(num_cuota, valor_entrada, "Valor Separación", date.ToString("yyyy-MM-dd"), Estado, id_financiacion);
                    }
                    else
                    {
                        cuota.ActulziarCuota(num_cuota, Estado, id_financiacion);
                    }
                    num_cuota++;
                    while (num_cuota <= Cuotas_sin_interes + 1)
                    {
                        pagado = pagado + Valor_cuota_sin_interes;
                        if (pagado <= ValorPagado)
                        {
                            Estado = "Pagada";
                        }
                        else
                        {
                            Estado = "Pendiente";
                        }
                        if (dtCuotas.Rows.Count == 0)
                        {
                            cuota.CrearCuota(num_cuota, Valor_cuota_sin_interes, "Valor Inicial", date.AddMonths(num_cuota - 1).ToString("yyyy-MM-dd"), Estado, id_financiacion);
                        }
                        else
                        {
                            cuota.ActulziarCuota(num_cuota, Estado, id_financiacion);
                        }
                        num_cuota++;
                    }
                    while (num_cuota <= Cuotas_sin_interes + Cuotas_Con_Interes + 1)
                    {
                        pagado = pagado + Valor_Cuota_Con_Interes;
                        if (pagado <= ValorPagado)
                        {
                            Estado = "Pagada";
                        }
                        else
                        {
                            Estado = "Pendiente";
                        }
                        if (dtCuotas.Rows.Count == 0)
                        {
                            cuota.CrearCuota(num_cuota, Valor_Cuota_Con_Interes, "Valor Saldo", date.AddMonths(num_cuota - 1).ToString("yyyy-MM-dd"), Estado, id_financiacion);
                        }
                        else
                        {
                            cuota.ActulziarCuota(num_cuota, Estado, id_financiacion);
                        }
                        num_cuota++;
                    }
                }
            }
        }
        void CargarRpProyeccion()
        {
            actulziarCuotas();
            DataTable DtProyeccion = cuota.reportProyeccion(dateInicio4.Text, datefin4.Text);
            dataGridView4.DataSource = DtProyeccion;
            Lbcantidadproye.Text = "CANTIDAD: " + DtProyeccion.Rows.Count;
            dataGridView4.Columns[0].Width = 55;
            dataGridView4.Columns[1].DefaultCellStyle.Format = "n0";
            dataGridView4.Columns[1].Width = 80;
            dataGridView4.Columns[2].Width = 80;
            dataGridView4.Columns[3].Width = 250;
            dataGridView4.Columns[4].Width = 250;
            dataGridView4.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            Int64 total = 0;
            foreach (DataRow row in DtProyeccion.Rows)
            {
                total += Convert.ToInt32(row["Valor a Pagar"]);
            }
            LbTotalProye.Text= "TOTAL: $ " + String.Format("{0:N0}", total);
        }
        void CargarDisoluciones()
        {
            try
            {
                DtDisolucion = cartera.Disoluciones(dateInicio3.Text, datefin3.Text);
                DataTable DtValorDisolucion=cartera.TotalDisoluciones(dateInicio3.Text, datefin3.Text);
                Int64 total = Int64.Parse(DtValorDisolucion.Rows[0]["Total Devuelto"].ToString());
                labelTot.Text = "TOTAL DEVUELTO: $" + String.Format("{0:N0}", total);
                labelCant.Text = "CANTIDAD: " + DtValorDisolucion.Rows[0]["Cantiad"].ToString();
                dataGridView3.DataSource = DtDisolucion;
                dataGridView3.Columns[1].Width = 130;
                dataGridView3.Columns[2].Width = 130;
                dataGridView3.Columns[5].DefaultCellStyle.Format = "n0";
                dataGridView3.Columns[6].DefaultCellStyle.Format = "n0";
                dataGridView3.Columns[7].DefaultCellStyle.Format = "n0";
                dataGridView3.Columns[8].Width = 50;
                dataGridView3.Columns[9].Width = 50;
                dataGridView3.Columns[10].Width = 50;
                dataGridView3.Columns[11].Width = 50;
                dataGridView3.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            catch
            {
                MessageBox.Show("Sin datos para el reporte, seleccione un nuevo rango de fechas", "No hay resultados", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BtBuscar_Click(object sender, EventArgs e)
        {
            CargarRpPagos();
            dataGridView1.Columns[5].DefaultCellStyle.Format = "n0";
        }

        private void BtBuscar2_Click(object sender, EventArgs e)
        {
            CargarRpVentas();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string fechas = dateInicio.Text + " A " + datefin.Text;
            reportesPDF.Ingresos(DtPagos, labelTotal.Text, labelNumero.Text,  fechas);
        }

        private void BtRP_Click(object sender, EventArgs e)
        {
            string fechas = dateInicio2.Text +" A "+datefin2.Text;
            reportesPDF.Ventas(DtVentas, labelTotalVentas.Text, labelVentas.Text, fechas);
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 1)
            {
                CargarRpProyeccion();
            }
            else if (tabControl1.SelectedIndex==2)
            {
                CargarRpVentas();
            }
            else if (tabControl1.SelectedIndex == 3)
            {
                CargarDisoluciones();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CargarDisoluciones();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CargarRpVentas();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            CargarRpProyeccion();
        }

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dataGridView1.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 16, e.RowBounds.Location.Y + 4);
            }
        }

        private void dataGridView4_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dataGridView4.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 16, e.RowBounds.Location.Y + 4);
            }
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
    }
}
