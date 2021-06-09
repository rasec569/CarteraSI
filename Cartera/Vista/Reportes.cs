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
                int total = int.Parse(DtValorVentas.Rows[0]["valor"].ToString()); 
                labelTotalVentas.Text ="TOTAL VENTAS: $" + String.Format("{0:N0}", total);
                labelVentas.Text = "CANTIDAD: " + DtValorVentas.Rows[0]["productos"].ToString();
                dataGridView2.DataSource = DtVentas;
                dataGridView2.Columns[3].DefaultCellStyle.Format = "n0";
            }
            catch
            {
                MessageBox.Show("Sin datos para el reporte");
            }
            
        }
        void CargarRpPagos()
        {
            try
            {            
            DtPagos = pagos.reportPagos(dateInicio.Text, datefin.Text);
            DataTable DtValorPagos = pagos.ValorReportPagos(dateInicio.Text, datefin.Text);
            int total = int.Parse(DtValorPagos.Rows[0]["valor"].ToString());
            labelTotal.Text = "TOTAL INGRESOS: $" + String.Format("{0:N0}", total);
            labelNumero.Text ="CANTIDAD: "+ DtValorPagos.Rows[0]["pagos"].ToString();
            dataGridView1.DataSource = DtPagos;
            dataGridView1.Columns[1].Width = 50;
            dataGridView1.Columns[2].Width = 80;
            dataGridView1.Columns[3].Width = 230;
            }
            catch
            {
                MessageBox.Show("Sin datos para el reporte");
            }
        }    
        void CargarDisoluciones()
        {
            try
            {
                DtDisolucion = cartera.Disoluciones(dateInicio3.Text, datefin3.Text);
                DataTable DtValorDisolucion=cartera.TotalDisoluciones(dateInicio3.Text, datefin3.Text);
                int total = int.Parse(DtValorDisolucion.Rows[0]["Total Devuelto"].ToString());
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
            }
            catch
            {
                MessageBox.Show("Sin datos para el reporte");
            }
        }

        private void BtBuscar_Click(object sender, EventArgs e)
        {
            CargarRpPagos();
            dataGridView1.Columns[5].DefaultCellStyle.Format = "n1";
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
            if (tabControl1.SelectedIndex==1)
            {
                CargarRpVentas();
            }
            else if (tabControl1.SelectedIndex == 2)
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

        }
    }
}
