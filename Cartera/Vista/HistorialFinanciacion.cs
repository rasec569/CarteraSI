using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cartera.Controlador;
using Cartera.Reportes;

namespace Cartera.Vista
{
    public partial class HistorialFinanciacion : Form
    {
        CFinanciacion financiacion = new CFinanciacion();
        CCuota cuota = new CCuota();
        CPago pago = new CPago();
        CProducto producto = new CProducto();
        DataTable DtAcuerdoPago= new DataTable();
        int ProductoId;
        ReportesPDF reportesPDF = new ReportesPDF();
        int Financiacion, Valor_Neto, valorSin, ValorInteres, ValorCuotaInteres, ValorTotal;
        string Refi;
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
            dataGridView1.Columns["Id_Financiacion"].Visible = false;
            dataGridView1.Columns["Valor_Neto"].HeaderText = "Valor Neto";
            dataGridView1.Columns["Valor_Neto"].DefaultCellStyle.Format = "n0";
            dataGridView1.Columns["Valor_Neto"].Width = 70;
            dataGridView1.Columns["Valor_Producto_Financiacion"].HeaderText = "Valor Final";
            dataGridView1.Columns["Valor_Producto_Financiacion"].DefaultCellStyle.Format = "n0";
            dataGridView1.Columns["Valor_Producto_Financiacion"].Width = 70;
            dataGridView1.Columns["Valor_Sin_interes"].HeaderText = "Valor Inicial";
            dataGridView1.Columns["Valor_Sin_interes"].DefaultCellStyle.Format = "n0";
            dataGridView1.Columns["Valor_Sin_interes"].Width = 70;
            dataGridView1.Columns["Valor_Entrada"].HeaderText = "Valor Entrada";
            dataGridView1.Columns["Valor_Entrada"].DefaultCellStyle.Format = "n0";
            dataGridView1.Columns["Valor_Entrada"].Width = 70;
            dataGridView1.Columns["Cuotas_Sin_interes"].HeaderText = "cuotas Inicial";
            dataGridView1.Columns["Cuotas_Sin_interes"].Width = 40;
            dataGridView1.Columns["Valor_Cuota_Sin_interes"].HeaderText = "Valor cuotas Inicial";
            dataGridView1.Columns["Valor_Cuota_Sin_interes"].DefaultCellStyle.Format = "n0";
            dataGridView1.Columns["Valor_Cuota_Sin_interes"].Width = 70;
            dataGridView1.Columns["Valor_Con_Interes"].HeaderText = "Valor Saldo";
            dataGridView1.Columns["Valor_Con_Interes"].DefaultCellStyle.Format = "n0";
            dataGridView1.Columns["Valor_Con_Interes"].Width = 70;
            dataGridView1.Columns["Cuotas_Con_Interes"].HeaderText = "Cuotas Saldo";
            dataGridView1.Columns["Cuotas_Con_Interes"].Width = 40;
            dataGridView1.Columns["Valor_Cuota_Con_Interes"].HeaderText = "Valor cuotas saldo";
            dataGridView1.Columns["Valor_Cuota_Con_Interes"].DefaultCellStyle.Format = "n0";
            dataGridView1.Columns["Valor_Cuota_Con_Interes"].Width = 70;
            dataGridView1.Columns["Valor_Interes"].HeaderText = "Interes";
            dataGridView1.Columns["Valor_Interes"].Width = 40;
            dataGridView1.Columns["Fecha_Recaudo"].HeaderText = "Fecha recaudo";
            dataGridView1.Columns["Estado_Financiacion"].HeaderText = "Estado";
            dataGridView1.Columns["Fecha_Venta"].Visible = false;
            dataGridView1.Columns["Id_Refinanciacion"].Visible = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void dataGridView2_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
                dataGridView2.Columns[1].Width = 70;
                DataGridView dgv = sender as DataGridView;
                int n = e.RowIndex;
                try
                {
                    if (dgv.Columns[e.ColumnIndex].Name == "Estado")  //Si es la columna a evaluar
                    {
                        if (n <= dataGridView2.Rows.Count)
                        {
                            if (e.Value.ToString().Contains("Pagada"))   //Si el valor de la celda contiene la palabra hora Pagada Mora
                            {
                                dataGridView2.Rows[n].DefaultCellStyle.BackColor = Color.Honeydew;
                            }
                            else if (e.Value.ToString().Contains("Mora"))
                            {
                                dataGridView2.Rows[n].DefaultCellStyle.BackColor = Color.AntiqueWhite;
                                //e.CellStyle.ForeColor = Color.Crimson;
                                //e.CellStyle.BackColor = Color.Orange;
                                //e.CellStyle.BackColor = Color.PaleVioletRed;
                                //Thistle-AntiqueWhite
                            }
                        }
                    }
                    //if (dataGridView.Rows[e.RowIndex].Selected)
                    //{
                    //    e.CellStyle.Font = new Font(e.CellStyle.Font, FontStyle.Bold);
                    //    // edit: to change the background color: 
                    //    e.CellStyle.SelectionBackColor = Color.Aqua;
                    //}
                }
                catch
                {

                }                       
        }

        

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int n = e.RowIndex;
                if (n != -1)
                {
                    int id_financiacion = int.Parse(dataGridView1.Rows[n].Cells["Id_Financiacion"].Value.ToString());
                    Financiacion = id_financiacion;
                    CargarFinanciacion(id_financiacion);


                }
            }
            catch
            {
                MessageBox.Show("Error");
            }
        }

        private void CargarFinanciacion(int id_financiacion)
        {
            DataTable DtFinanciacion = financiacion.Financiacion(id_financiacion);
            int Valor_Producto_Neto = int.Parse(DtFinanciacion.Rows[0]["Valor_Neto"].ToString());
            Valor_Neto = Valor_Producto_Neto;
            int Valor_Producto_Financiacion = int.Parse(DtFinanciacion.Rows[0]["Valor_Producto_Financiacion"].ToString());
            ValorTotal = Valor_Producto_Financiacion;
            int valor_entrada = int.Parse(DtFinanciacion.Rows[0]["Valor_Entrada"].ToString());
            int valor_sin_interes = int.Parse(DtFinanciacion.Rows[0]["Valor_Sin_interes"].ToString());
            valorSin = valor_sin_interes;
            int Cuotas_sin_interes = int.Parse(DtFinanciacion.Rows[0]["Cuotas_Sin_interes"].ToString());
            int Valor_cuota_sin_interes = int.Parse(DtFinanciacion.Rows[0]["Valor_Cuota_Sin_interes"].ToString());
            int Valor_con_interes = int.Parse(DtFinanciacion.Rows[0]["Valor_Con_Interes"].ToString());
            int Cuotas_Con_Interes = int.Parse(DtFinanciacion.Rows[0]["Cuotas_Con_Interes"].ToString());
            int Valor_Cuota_Con_Interes = int.Parse(DtFinanciacion.Rows[0]["Valor_Cuota_Con_Interes"].ToString());
            ValorCuotaInteres = Valor_Cuota_Con_Interes;
            int Valor_Interes = int.Parse(DtFinanciacion.Rows[0]["Valor_Interes"].ToString());
            ValorInteres = Valor_Interes;
            string Fecha_Recaudo = DtFinanciacion.Rows[0]["Fecha_Recaudo"].ToString();
            string Fecha_Venta = DtFinanciacion.Rows[0]["Fecha_Venta"].ToString();
            Refi = DtFinanciacion.Rows[0]["Id_Refinanciacion"].ToString();
            DateTime date = DateTime.ParseExact(Fecha_Recaudo, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            DateTime dateI = DateTime.ParseExact(Fecha_Venta, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            string año = date.ToString("yyyy");
            string mes = date.ToString("MM");
            string dia = date.ToString("dd");
            DateTime FechaCuota = new DateTime(Convert.ToInt32(año), Convert.ToInt32(mes), Convert.ToInt32(dia));
            DateTime FechaActual = DateTime.Now;
            DateTime actual = DateTime.ParseExact(DateTime.Now.ToString("yyyy-MM-dd"), "yyyy-MM-dd", CultureInfo.InvariantCulture);
            BtRefinanciar.Visible = true;
            if (Refi == "")
            {
                label11.Text = "Refinanciación: No";
                Refi = "0";
            }
            else
            {
                label11.Text = "Refinanciación: Si";

            }
            if (Valor_Interes == 0)
            {
                BtAmortizacion.Visible = false;
            }
            label1.Text = "Valor final: $ " + String.Format("{0:N0}", Valor_Producto_Financiacion);
            label2.Text = "Valor inicial: $ " + String.Format("{0:N0}", valor_sin_interes);
            label3.Text = "Valor separación: $ " + String.Format("{0:N0}", valor_entrada);
            label4.Text = "N° de cuotas inicial: " + Cuotas_sin_interes;
            label5.Text = "Valor cuotas inicial: $ " + String.Format("{0:N0}", Valor_cuota_sin_interes);
            label6.Text = "Valor saldo: $ " + String.Format("{0:N0}", Valor_con_interes);
            label7.Text = "N° de cuotas saldo: " + String.Format("{0:N0}", Cuotas_Con_Interes);
            label8.Text = "Valor cuotas saldo: $ " + String.Format("{0:N0}", Valor_Cuota_Con_Interes);
            label10.Text = "Valor interes: $ " + Valor_Interes;
            int ValorPagado = 0;
            DataTable dtrecaudo = pago.Tota_Recaudado_Producto(ProductoId.ToString());
            if (dtrecaudo.Rows[0]["sum(Valor_Pagado)"].ToString() != "")
            {
                ValorPagado = int.Parse(dtrecaudo.Rows[0]["sum(Valor_Pagado)"].ToString());

            }
            label9.Text = "Valor pagado: $ " + String.Format("{0:N0}", ValorPagado);
            dataGridView1.Visible = false;
            DtAcuerdoPago = cuota.ListarCuotas(id_financiacion, "Refinanciación", "");
            DtAcuerdoPago.Columns.Remove("Id_Cuota");
            dataGridView2.DataSource = DtAcuerdoPago;
            panel1.Visible = true;
            dataGridView2.Columns[0].Width = 50;
            dataGridView2.Columns[1].Width = 90;
            dataGridView2.Columns[2].Width = 110;
            dataGridView2.Columns[1].DefaultCellStyle.Format = "n2";
            dataGridView2.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void dataGridView1_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex >= 0 & e.RowIndex >= 0)
            {
                DataGridViewCell cell = this.dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
                cell.ToolTipText = "Doble clic para ver detalle de financiación";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //DataTable DtRepor = new DataTable();
            //DtRepor = ((DataTable)dataGridView2.DataSource);

            DataTable Dtdatos = producto.ClienteProducto(ProductoId);

            string cliente = Dtdatos.Rows[0]["Nombre"].ToString() + " " + Dtdatos.Rows[0]["Apellido"].ToString();
            string nomproducto = Dtdatos.Rows[0]["Producto"].ToString();
            string nomproyecto = Dtdatos.Rows[0]["Proyecto"].ToString();
            
            reportesPDF.PagoProgramado(DtAcuerdoPago, cliente, nomproducto, nomproyecto, label1.Text.ToUpper(), label2.Text.ToUpper(), label3.Text.ToUpper(), label4.Text.ToUpper(), label5.Text.ToUpper(), label6.Text.ToUpper(), label7.Text.ToUpper(), label8.Text.ToUpper(), label9.Text.ToUpper());
        }
        
        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            int n = e.RowIndex;
            try
            {
                if (dgv.Columns[e.ColumnIndex].Name == "Estado_Financiacion")  //columna a evaluar
                {

                    if (n != -1)
                    {
                        if (e.Value.ToString().Contains("Activa"))   //Si el valor de la celda contiene la palabra
                        {                            
                            e.CellStyle.ForeColor = Color.DarkGreen;
                            e.CellStyle.BackColor = Color.LightGreen;
                        }
                        else if (e.Value.ToString().Contains("Inactiva"))
                        {
                            e.CellStyle.ForeColor = Color.Crimson;
                            e.CellStyle.BackColor = Color.Orange;
                        }
                    }
                }
            }
            catch
            {

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataTable Dtdatos = producto.ClienteProducto(ProductoId);

            string cliente = Dtdatos.Rows[0]["Nombre"].ToString() + " " + Dtdatos.Rows[0]["Apellido"].ToString();
            string nomproducto = Dtdatos.Rows[0]["Producto"].ToString();
            string nomproyecto = Dtdatos.Rows[0]["Proyecto"].ToString();
            Amortizacion Am =new Amortizacion(Financiacion, Valor_Neto, valorSin, ValorInteres, ValorCuotaInteres, ValorTotal, cliente, nomproducto, nomproyecto);            
            Am.ShowDialog();
        }

        private void Refinanciacion_FormClose(object sender, FormClosedEventArgs e)
        {
            Form frm = sender as Form;
            if (frm.DialogResult == DialogResult.OK)
            {
                CargarFinanciacion(Financiacion);
            }
        }
            private void BtRefinanciar_Click(object sender, EventArgs e)
        {
            Refinanciacion Re = new Refinanciacion(Financiacion, Valor_Neto, valorSin, ValorInteres, ValorCuotaInteres, ValorTotal, int.Parse(Refi));
            Re.FormClosed += Refinanciacion_FormClose;
            Re.ShowDialog();
            
        }
    }
}
