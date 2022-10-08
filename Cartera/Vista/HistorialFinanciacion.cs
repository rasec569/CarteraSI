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
using Cartera.Modelo;
using Cartera.Reportes;
using Org.BouncyCastle.Utilities;

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
        int Financiacion, Valor_Neto, valorSin, ValorInteres;
        double ValorTotal;
        string cliente, nomproducto, nomproyecto;
        decimal  ValorCuotaInteres, ValorCuotaSinInteres, ValorEntrada;      
        string Refi;

        public HistorialFinanciacion()
        {
            InitializeComponent();
            DataTable Dtdatos = producto.ClienteProducto(ProductoId);

            cliente = Dtdatos.Rows[0]["Nombre"].ToString() + " " + Dtdatos.Rows[0]["Apellido"].ToString();
            nomproducto = Dtdatos.Rows[0]["Producto"].ToString();
            nomproyecto = Dtdatos.Rows[0]["Proyecto"].ToString();
        }
        public HistorialFinanciacion(string IdProducto)
        {
            InitializeComponent();
            ProductoId = int.Parse(IdProducto);
            DataTable Dtdatos = producto.ClienteProducto(ProductoId);

            cliente = Dtdatos.Rows[0]["Nombre"].ToString() + " " + Dtdatos.Rows[0]["Apellido"].ToString();
            nomproducto = Dtdatos.Rows[0]["Producto"].ToString();
            nomproyecto = Dtdatos.Rows[0]["Proyecto"].ToString();
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
            dataGridView1.Columns["Valor_Producto_Financiacion"].DefaultCellStyle.Format = "n2";
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
            dataGridView1.Columns["Valor_Cuota_Sin_interes"].DefaultCellStyle.Format = "n2";
            dataGridView1.Columns["Valor_Cuota_Sin_interes"].Width = 70;
            dataGridView1.Columns["Valor_Con_Interes"].HeaderText = "Valor Saldo";
            dataGridView1.Columns["Valor_Con_Interes"].DefaultCellStyle.Format = "n2";
            dataGridView1.Columns["Valor_Con_Interes"].Width = 70;
            dataGridView1.Columns["Cuotas_Con_Interes"].HeaderText = "Cuotas Saldo";
            dataGridView1.Columns["Cuotas_Con_Interes"].Width = 40;
            dataGridView1.Columns["Valor_Cuota_Con_Interes"].HeaderText = "Valor cuotas saldo";
            dataGridView1.Columns["Valor_Cuota_Con_Interes"].DefaultCellStyle.Format = "n2";
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
                //dataGridView2.Columns[1].Width = 70;
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
                    CargarFinanciacion(Financiacion);
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
            double Valor_Producto_Financiacion = double.Parse(DtFinanciacion.Rows[0]["Valor_Producto_Financiacion"].ToString());
            ValorTotal = Valor_Producto_Financiacion;
            int valor_entrada = int.Parse(DtFinanciacion.Rows[0]["Valor_Entrada"].ToString());
            ValorEntrada = valor_entrada;
            int valor_sin_interes = int.Parse(DtFinanciacion.Rows[0]["Valor_Sin_interes"].ToString());
            valorSin = valor_sin_interes;
            int Cuotas_sin_interes = int.Parse(DtFinanciacion.Rows[0]["Cuotas_Sin_interes"].ToString());
            decimal Valor_cuota_sin_interes = decimal.Parse(DtFinanciacion.Rows[0]["Valor_Cuota_Sin_interes"].ToString());
            ValorCuotaSinInteres = Valor_cuota_sin_interes;
            double Valor_con_interes = double.Parse(DtFinanciacion.Rows[0]["Valor_Con_Interes"].ToString());
            int Cuotas_Con_Interes = int.Parse(DtFinanciacion.Rows[0]["Cuotas_Con_Interes"].ToString());
            decimal Valor_Cuota_Con_Interes = decimal.Parse(DtFinanciacion.Rows[0]["Valor_Cuota_Con_Interes"].ToString());
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
            label1.Text = "Valor final: $ " + String.Format("{0:N2}", Valor_Producto_Financiacion);
            label2.Text = "Valor inicial: $ " + String.Format("{0:N0}", valor_sin_interes);
            label3.Text = "Valor separación: $ " + String.Format("{0:N0}", valor_entrada);
            label4.Text = "N° de cuotas inicial: " + Cuotas_sin_interes;
            label5.Text = "Valor cuotas inicial: $ " + String.Format("{0:N2}", Valor_cuota_sin_interes);
            label6.Text = "Valor saldo: $ " + String.Format("{0:N2}", Valor_con_interes);
            label7.Text = "N° de cuotas saldo: " + String.Format("{0:N0}", Cuotas_Con_Interes);
            label8.Text = "Valor cuotas saldo: $ " + String.Format("{0:N2}", Valor_Cuota_Con_Interes);
            label10.Text = "Valor interes: $ " + Valor_Interes;
            double ValorPagado = 0;
            DataTable dtrecaudo = pago.Tota_Recaudado_Producto(ProductoId.ToString());
            if (dtrecaudo.Rows[0]["sum(Valor_Pagado)"].ToString() != "")
            {
                ValorPagado = double.Parse(dtrecaudo.Rows[0]["sum(Valor_Pagado)"].ToString());

            }
            label9.Text = "Valor pagado: $ " + String.Format("{0:N0}", ValorPagado);
            dataGridView1.Visible = false;
            ListarCuotas(id_financiacion);

        }
        private void ListarCuotas(int finan)
        {
            dataGridView2.Columns.Clear();
            dataGridView2.Refresh();
            //dataGridView2.DataSource = null;
            DtAcuerdoPago = cuota.ListarCuotas(finan, "Refinanciación", "");
            //DtAcuerdoPago.Columns.Remove("Id_Cuota");
            dataGridView2.DataSource = DtAcuerdoPago;
            panel1.Visible = true;
            dataGridView2.Columns["Id_Cuota"].Visible = false;
            dataGridView2.Columns["Cuota"].Width = 50;
            dataGridView2.Columns["Valor"].Width = 80;
            dataGridView2.Columns["Tipo"].Width = 100;
            //dataGridView2.Columns[1].DefaultCellStyle.Format = "n2";
            this.dataGridView2.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dataGridView2_RowPostPaint);
            dataGridView2.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DataGridViewButtonColumn BtValidar = new DataGridViewButtonColumn();
            BtValidar.Name = "Validar";
            BtValidar.HeaderText = "";
            BtValidar.UseColumnTextForButtonValue = true;
            dataGridView2.Columns.Add(BtValidar);
        }

        private void dataGridView1_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex >= 0 & e.RowIndex >= 0)
            {
                DataGridViewCell cell = this.dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
                cell.ToolTipText = "Doble clic para ver detalle de financiación";
            }
        }

        private void dataGridView2_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            if (e.ColumnIndex >= 7 && this.dataGridView2.Columns[e.ColumnIndex].Name == "Validar" && e.RowIndex >= 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);
                DataGridViewButtonCell celboton = this.dataGridView2.Rows[e.RowIndex].Cells["Validar"] as DataGridViewButtonCell;
                Icon ValidaIcon = new Icon(Environment.CurrentDirectory + @"\\img\reload.ico");
                e.Graphics.DrawIcon(ValidaIcon, e.CellBounds.Left + 3, e.CellBounds.Top + 3);
                this.dataGridView2.Rows[e.RowIndex].Height = ValidaIcon.Height + 8;
                this.dataGridView2.Columns[e.ColumnIndex].Width = ValidaIcon.Width + 8;
                e.Handled = true;
            }
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int x = dataGridView2.Rows.Count;
            int n = e.RowIndex;
            if (n < x - 1)
            {
                try
                {
                    int cuotaid = int.Parse(dataGridView2.Rows[n].Cells["Id_Cuota"].Value.ToString());
                    Int64 numero = int.Parse(dataGridView2.Rows[n].Cells["Cuota"].Value.ToString());
                    string Temptipoo = dataGridView2.Rows[n].Cells["Tipo"].Value.ToString();
                    string tipoo= Temptipoo.Substring(6); 
                    string fecha = dataGridView2.Rows[n].Cells["Fecha"].Value.ToString();
                    string estado = dataGridView2.Rows[n].Cells["Estado"].Value.ToString();
                    decimal valor = 0, aportes = 0, descuentos = 0;
                    if (e.ColumnIndex >= 7)
                    {
                        DataTable dt1 = new DataTable();
                        //asigna valor temporal segun tipo
                        if (tipoo == "Inicial")
                        {
                            valor = ValorCuotaSinInteres;
                        }
                        else if (tipoo == "Saldo")
                        {
                            valor = ValorCuotaInteres;
                        }
                        else
                        {
                            valor = ValorEntrada;
                        }
                        DataTable dtpagos = pago.ListarPagosCliente(ProductoId.ToString());
                        if (dtpagos.Rows.Count > 0)
                        {
                            // filtra DtCuotasPagas por los valores de txtCuota.Text y TipoPago                             
                            DataRow[] PagosCuota = dtpagos.Select(String.Format("Cuota = '{0}' AND Tipo like '%{1}%'", numero, tipoo));
                            // si el DataRow no esta vacio
                            if (PagosCuota.Length > 0)
                            {
                                //almacena temporal los valores de DataRow
                                dt1 = PagosCuota.CopyToDataTable();

                                //recore el Dt result suma aportes y descuentos, calcula el valor si el descuento >0
                                for (int i = 0; i < dt1.Rows.Count; i++)
                                {
                                    if (dt1.Rows[i]["Tipo"].ToString() != "Refinanciación")
                                    {
                                        aportes += decimal.Parse(dt1.Rows[i]["Valor"].ToString().Replace(",", ""));
                                        descuentos += decimal.Parse(dt1.Rows[i]["Valor Descuento"].ToString().Replace(",", ""));
                                        valor -= descuentos;
                                    }
                                }
                            }
                        }
                        //modifica los valores de la cuota afectada y validar el estado de la cuota deacuerto a los aportes y fecha
                        cuota.ModificarCuota(cuotaid, (int)numero, (double)valor, Temptipoo, fecha, EvaluaEstadoCuotaFecha(Convert.ToDateTime(fecha), double.Parse(aportes.ToString()), double.Parse(valor.ToString())), (double)aportes);
                        ListarCuotas(Financiacion);
                    }
                }
                catch
                {
                    MessageBox.Show("Error", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("Campo no valido", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private string EvaluaEstadoCuotaFecha(DateTime fecha, double Pagado, double Valor)
        {
            string CuoEstado = "Pendiente";
            string actual = DateTime.ParseExact(DateTime.Now.ToString("yyyy-MM-dd"), "yyyy-MM-dd", CultureInfo.InvariantCulture).ToString();

            if (Pagado >= Valor)
            {
                CuoEstado = "Pagada";
            }
            else
            {
                if (fecha <= Convert.ToDateTime(actual))
                {
                    CuoEstado = "Mora";
                }
                else if (fecha > Convert.ToDateTime(actual))
                {
                    CuoEstado = "Abono";
                }
            }
            return CuoEstado;
        }

        private void dataGridView2_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dataGridView1.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 16, e.RowBounds.Location.Y + 4);
            }
        }

        //private void DatosCliente()
        //{
        //    DataTable Dtdatos = producto.ClienteProducto(ProductoId);

        //    string cliente = Dtdatos.Rows[0]["Nombre"].ToString() + " " + Dtdatos.Rows[0]["Apellido"].ToString();
        //    string nomproducto = Dtdatos.Rows[0]["Producto"].ToString();
        //    string nomproyecto = Dtdatos.Rows[0]["Proyecto"].ToString();
        //}
        private void button1_Click(object sender, EventArgs e)
        {
            DataTable DtRepor = new DataTable();
            DtRepor = DtAcuerdoPago;
            DtRepor.Columns.Remove("Id_Cuota");


            reportesPDF.PagoProgramado(DtRepor, cliente, nomproducto, nomproyecto, label1.Text.ToUpper(), label2.Text.ToUpper(), label3.Text.ToUpper(), label4.Text.ToUpper(), label5.Text.ToUpper(), label6.Text.ToUpper(), label7.Text.ToUpper(), label8.Text.ToUpper(), label9.Text.ToUpper());
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
            
            Amortizacion Am =new Amortizacion(Financiacion, Valor_Neto, valorSin, ValorInteres, double.Parse(ValorCuotaInteres.ToString()), ValorTotal, cliente, nomproducto, nomproyecto);            
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
            Refinanciacion Re = new Refinanciacion(Financiacion, Valor_Neto, valorSin, ValorInteres, double.Parse(ValorCuotaInteres.ToString()), ValorTotal, int.Parse(Refi), cliente, nomproducto, nomproyecto);
            Re.FormClosed += Refinanciacion_FormClose;
            Re.ShowDialog();
            
        }
    }
}
