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
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].HeaderText = "Valor Neto";
            dataGridView1.Columns[1].DefaultCellStyle.Format = "n0";
            dataGridView1.Columns[1].Width = 80;
            dataGridView1.Columns[2].HeaderText = "Valor Final";
            dataGridView1.Columns[2].DefaultCellStyle.Format = "n0";
            dataGridView1.Columns[2].Width = 80;
            dataGridView1.Columns[3].HeaderText = "Valor Inicial";
            dataGridView1.Columns[3].DefaultCellStyle.Format = "n0";
            dataGridView1.Columns[3].Width = 80;
            dataGridView1.Columns[4].HeaderText = "Valor Entrada";
            dataGridView1.Columns[4].DefaultCellStyle.Format = "n0";
            dataGridView1.Columns[4].Width = 80;
            dataGridView1.Columns[5].HeaderText = "cuotas Inicial";
            dataGridView1.Columns[5].Width = 50;
            dataGridView1.Columns[6].HeaderText = "Valor cuotas Inicial";
            dataGridView1.Columns[6].DefaultCellStyle.Format = "n0";
            dataGridView1.Columns[6].Width = 80;
            dataGridView1.Columns[7].HeaderText = "Valor Saldo";
            dataGridView1.Columns[7].DefaultCellStyle.Format = "n0";
            dataGridView1.Columns[7].Width = 80;
            dataGridView1.Columns[8].HeaderText = "Cuotas Saldo";
            dataGridView1.Columns[8].Width = 50;
            dataGridView1.Columns[9].HeaderText = "Valor cuotas saldo";
            dataGridView1.Columns[9].DefaultCellStyle.Format = "n0";
            dataGridView1.Columns[9].Width = 80;
            dataGridView1.Columns[10].HeaderText = "Interes";
            dataGridView1.Columns[10].Width = 40;
            dataGridView1.Columns[11].HeaderText = "Fecha recaudo";
            dataGridView1.Columns[12].HeaderText = "Estado";
            dataGridView1.Columns[13].Visible = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
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
                    int Valor_Producto_Neto = int.Parse(dataGridView1.Rows[n].Cells["Valor_Neto"].Value.ToString());
                    Valor_Neto = Valor_Producto_Neto;
                    int Valor_Producto_Financiacion = int.Parse(dataGridView1.Rows[n].Cells["Valor_Producto_Financiacion"].Value.ToString());
                    ValorTotal = Valor_Producto_Financiacion;
                    int valor_entrada = int.Parse(dataGridView1.Rows[n].Cells["Valor_Entrada"].Value.ToString());
                    int valor_sin_interes = int.Parse(dataGridView1.Rows[n].Cells["Valor_Sin_interes"].Value.ToString());
                    valorSin = valor_sin_interes;
                    int Cuotas_sin_interes = int.Parse(dataGridView1.Rows[n].Cells["Cuotas_Sin_interes"].Value.ToString());
                    int Valor_cuota_sin_interes = int.Parse(dataGridView1.Rows[n].Cells["Valor_Cuota_Sin_interes"].Value.ToString());
                    int Valor_con_interes = int.Parse(dataGridView1.Rows[n].Cells["Valor_Con_Interes"].Value.ToString());
                    int Cuotas_Con_Interes = int.Parse(dataGridView1.Rows[n].Cells["Cuotas_Con_Interes"].Value.ToString());
                    int Valor_Cuota_Con_Interes = int.Parse(dataGridView1.Rows[n].Cells["Valor_Cuota_Con_Interes"].Value.ToString());
                    ValorCuotaInteres = Valor_Cuota_Con_Interes;
                    int Valor_Interes = int.Parse(dataGridView1.Rows[n].Cells["Valor_Interes"].Value.ToString());
                    ValorInteres= Valor_Interes;
                    string Fecha_Recaudo = dataGridView1.Rows[n].Cells["Fecha_Recaudo"].Value.ToString();
                    string Fecha_Venta = dataGridView1.Rows[n].Cells["Fecha_Venta"].Value.ToString();
                    DateTime date = DateTime.ParseExact(Fecha_Recaudo, "yyyy-MM-dd", CultureInfo.InvariantCulture);
                    DateTime dateI =  DateTime.ParseExact(Fecha_Venta, "yyyy-MM-dd", CultureInfo.InvariantCulture);
                    string año = date.ToString("yyyy");
                    string mes = date.ToString("MM");
                    string dia = date.ToString("dd"); 
                    DateTime FechaCuota = new DateTime( Convert.ToInt32(año), Convert.ToInt32(mes), Convert.ToInt32(dia));
                    DateTime FechaActual = DateTime.Now;
                    DateTime actual = DateTime.ParseExact(DateTime.Now.ToString("yyyy-MM-dd"), "yyyy-MM-dd", CultureInfo.InvariantCulture);
                    label1.Text = "Valor final: $ " + String.Format("{0:N0}", Valor_Producto_Financiacion);
                    label2.Text = "Valor inicial: $ " + String.Format("{0:N0}", valor_sin_interes);
                    label3.Text = "Valor separación: $ " + String.Format("{0:N0}", valor_entrada);
                    label4.Text = "N° de cuotas inicial: " +  Cuotas_sin_interes;
                    label5.Text = "Valor cuotas inicial: $ " + String.Format("{0:N0}", Valor_cuota_sin_interes);
                    label6.Text = "Valor saldo: $ " + String.Format("{0:N0}", Valor_con_interes);
                    label7.Text = "N° de cuotas saldo: " + String.Format("{0:N0}", Cuotas_Con_Interes);
                    label8.Text = "Valor cuotas saldo: $ " + String.Format("{0:N0}", Valor_Cuota_Con_Interes);
                    label10.Text = "Valor interes: $ " + Valor_Interes;
                    if (Valor_Producto_Financiacion >0 /*&& id_financiacion !=  0*/)
                    {
                        DataTable dtCuotas= cuota.ListarCuotas(id_financiacion);
                        DataTable dtrecaudo = pago.Tota_Recaudado_Producto(ProductoId.ToString());
                        int ValorPagado = 0;                        
                        int num_cuota = 0;
                        int contador = 1;
                        int pagado = 0;
                        string Estado = "";
                        pagado = valor_entrada;
                        int result = DateTime.Compare(date, actual);
                        if(dtCuotas.Rows.Count != (Cuotas_Con_Interes + Cuotas_sin_interes + 1))
                        {
                            cuota.EliminarCuotas(id_financiacion);
                            dtCuotas = cuota.ListarCuotas(id_financiacion);
                        }
                        if (dtrecaudo.Rows[0]["sum(Valor_Pagado)"].ToString() != "")
                        {
                            ValorPagado = int.Parse(dtrecaudo.Rows[0]["sum(Valor_Pagado)"].ToString());

                            pagado = valor_entrada;
                            if (pagado <= ValorPagado)
                            {
                                Estado = "Pagada";
                            }
                            else if(result>0)
                            {
                                Estado = "Mora";
                            }
                            else
                            {
                                Estado = "Pendiente";
                            }
                        }
                        else
                        {
                            Estado = "Pendiente";
                        }
                        if (dtCuotas.Rows.Count == 0)
                        {
                            cuota.CrearCuota(num_cuota, valor_entrada, "Valor Separación", dateI.ToString("yyyy-MM-dd"), Estado, id_financiacion);
                        }
                        else
                        {
                            cuota.ActulziarCuota(num_cuota, Estado, id_financiacion, "Valor Separación");
                        }
                        num_cuota++;
                        while (num_cuota <= Cuotas_sin_interes)
                        {
                            DateTime fechacuota = FechaCuota.AddMonths(contador-1);
                            result = DateTime.Compare(fechacuota, FechaActual);
                            pagado = pagado + Valor_cuota_sin_interes;
                            if (pagado <= ValorPagado)
                            {
                                Estado = "Pagada";
                            }
                            else if (result < 0)
                            {
                                Estado = "Mora";
                            }
                            else
                            {
                                Estado = "Pendiente";
                            }
                            if(dtCuotas.Rows.Count == 0 || dtCuotas.Rows.Count<= Cuotas_sin_interes)
                            { 
                            cuota.CrearCuota(num_cuota, Valor_cuota_sin_interes, "Valor Inicial", date.AddMonths(contador - 1).ToString("yyyy-MM-dd"), Estado, id_financiacion);                            
                            }
                            else
                            {
                                cuota.ActulziarCuota(num_cuota, Estado, id_financiacion, "Valor Inicial");
                            }
                            contador++;
                            num_cuota++;
                        }
                        num_cuota = 1;
                        while (num_cuota <= Cuotas_Con_Interes)
                        {
                            DateTime fechacuota = FechaCuota.AddMonths(contador-1);
                            result = DateTime.Compare(fechacuota, FechaActual);
                            pagado = pagado + Valor_Cuota_Con_Interes;
                            if (pagado <= ValorPagado)
                            {
                                Estado = "Pagada";
                            }
                            else if (result.ToString() == "-1")
                            {
                                Estado = "Mora";
                            }
                            else
                            {
                                Estado = "Pendiente";
                            }
                            if (dtCuotas.Rows.Count == 0)
                            {
                                cuota.CrearCuota(num_cuota, Valor_Cuota_Con_Interes, "Valor Saldo", date.AddMonths(contador - 1).ToString("yyyy-MM-dd"), Estado, id_financiacion);
                            }
                            else
                            {
                                
                                cuota.ActulziarCuota(num_cuota, Estado, id_financiacion, "Valor Saldo");
                            }
                            contador++;
                            num_cuota++;
                        }
                        label9.Text = "Valor pagado: $ " + String.Format("{0:N0}", ValorPagado);
                        dataGridView1.Visible = false;
                        DtAcuerdoPago= cuota.ListarCuotas(id_financiacion);
                        dataGridView2.DataSource = DtAcuerdoPago;                     
                        panel1.Visible = true;
                        dataGridView2.Columns[0].Width = 70;
                        dataGridView2.Columns[1].Width = 80;
                        dataGridView2.Columns[1].DefaultCellStyle.Format = "n0";
                        dataGridView2.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    }
                }
            }
            catch
            {
                MessageBox.Show("Error");
            }
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
    }
}
