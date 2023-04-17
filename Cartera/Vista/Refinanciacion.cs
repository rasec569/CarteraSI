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
    public partial class Refinanciacion : Form
    {
        CCuota cuota = new CCuota();
        CRefinanciacion refinanciacion= new CRefinanciacion();
        int FilaTotal;
        int Refi, Id_Financiacion;
        string NomCliente, NomProducto, NomProyeco;
        private ReportesPDF reportesPDF;
        //DataTable DtRpAmortizacion = new DataTable();
        DataTable DtRefinanciacion;
        DataTable DtCamio;
        DataTable DtNuevas = new DataTable();
        DataTable DtNuevasCuotas = new DataTable();
        DataTable DtRpRefinaciacion = new DataTable();
        DateTime actual = DateTime.ParseExact(DateTime.Now.ToString("yyyy-MM-dd"), "yyyy-MM-dd", CultureInfo.InvariantCulture);
        decimal pagadofecha = 0;
        public Refinanciacion()
        {
            InitializeComponent();
        }
        private void ListarRefi()
        {
            button1.Visible = false;
            button2.Visible = true;
            numCuotasFinan.Enabled = false;
            numValorInteres.Enabled = false;
        } 
        private void CalcularRefi()
        {
            button1.Visible = true;
            button2.Visible = false;
            numCuotasFinan.Enabled = true;
            numValorInteres.Enabled = true;
        }
        public Refinanciacion(int Financiacion, int Valor_Neto, int Valor_Sin, int Valor_Interes, double Valor_Cuota_Con_Interes, double Valor_Total, int Refinanciacion, string Cliente, string Producto, string Proyeco)
        {
            InitializeComponent();
            reportesPDF = new ReportesPDF();
            TxtValorNeto.Text = Valor_Neto.ToString("N2", CultureInfo.CurrentCulture);
            TxtTotal.Text= Valor_Total.ToString("N2", CultureInfo.CurrentCulture);
            Refi = Refinanciacion;
            if (Refinanciacion != 0)
            {
                DataTable DtRefi = new DataTable();
                DtRefi=refinanciacion.RefinanciacionFinanciacion(Financiacion);
                Refi = int.Parse(DtRefi.Rows[0]["Id_Refinanciacion"].ToString());
                double ValorMora = double.Parse(DtRefi.Rows[0]["Interes Mora"].ToString());
                TxtValorMora.Text = ValorMora.ToString("N2", CultureInfo.CurrentCulture);
                double ValorDeuda = double.Parse(DtRefi.Rows[0]["Valor Deuda"].ToString());
                TxtValorDeuda.Text = ValorDeuda.ToString("N2", CultureInfo.CurrentCulture);
                numCuotasFinan.Text = DtRefi.Rows[0]["# Cuotas"].ToString();
                numValorInteres.Text = DtRefi.Rows[0]["Valor Interes"].ToString();
                double ValorCuota = double.Parse(DtRefi.Rows[0]["Valor Cuota"].ToString());
                TxtValorCuota.Text = ValorCuota.ToString("N2", CultureInfo.CurrentCulture);
                double ValorTotal = double.Parse(DtRefi.Rows[0]["Valor Total"].ToString());
                TxtTotalRefi.Text = ValorTotal.ToString("N2", CultureInfo.CurrentCulture);
                ListarRefi();
                ListarCuotasRefi(Financiacion);
            }
            NomCliente = Cliente; NomProducto = Producto; NomProyeco = Proyeco;
            listarCuotas(Financiacion);
            listarCuotasFinaciadas(Financiacion, Valor_Neto, Valor_Sin, Valor_Interes, Valor_Cuota_Con_Interes, Valor_Total);            
            Id_Financiacion = Financiacion;

        }
        private void Detalle_Load(object sender, EventArgs e)
        {

        }
        private void ListarCuotasRefi(int Financiacion)
        {
            try { 
                DataTable DtCuotasRefi = new DataTable();
                DtCuotasRefi = cuota.ListarCuotas(Financiacion, "","Inactiva");
                DtCuotasRefi.Columns.Remove("Id_Cuota");
                DtCuotasRefi.Columns["Valor"].SetOrdinal(5);
                DtCuotasRefi.Columns.Add("Capital", typeof(string));
                DtCuotasRefi.Columns.Add("Interes", typeof(string));
                DtCuotasRefi.Columns.Add("Saldo", typeof(string));
                decimal ValCuota = decimal.Parse(TxtValorCuota.Text.ToString());
                decimal saldo = decimal.Parse( TxtValorDeuda.Text.ToString());
                decimal interes = saldo * (Convert.ToDecimal(numValorInteres.Value) / 100);
                decimal capital = ValCuota - interes;

                for (int i = 0; i < DtCuotasRefi.Rows.Count; i++)
                {
                    if (DtCuotasRefi.Rows[i]["Tipo"].ToString() == "Refinanciación")
                    {
                        if (i != 0)
                        {

                            interes = saldo * interes;
                            capital = ValCuota - interes;
                        }
                        saldo = saldo - capital;
                        DtCuotasRefi.Rows[i]["Saldo"] = saldo.ToString("N2", CultureInfo.CurrentCulture);
                        DtCuotasRefi.Rows[i]["Interes"] = interes.ToString("N2", CultureInfo.CurrentCulture);
                        DtCuotasRefi.Rows[i]["Capital"] = capital.ToString("N2", CultureInfo.CurrentCulture);
                    }
                }
                DtRpRefinaciacion = DtCuotasRefi.Copy();
                dataGridView3.DataSource = DtCuotasRefi;
                dataGridView3.Columns[0].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al listar cuotas refinanciacion: " + ex, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
}
        private void listarCuotas(int Financiacion)
        {
            try
            {
                DataTable DtCuotas = new DataTable();
                DtCuotas = cuota.ListarCuotas(Financiacion, "Refinanciación", "");
                //DtCuotasPorPagar.Columns.Remove("Id_Cuota");//Provicional
                DtCuotas.Columns["Valor"].SetOrdinal(5);
                //FilaTotal = DtCuotasPorPagar.Rows.Count;
                DtRefinanciacion = DtCuotas.Clone(); //para tener la misma estructura del dt1 y no tener problemas
                DtCamio = DtCuotas.Clone();
                for (int i = 0; i < DtCuotas.Rows.Count; i++)
                {
                    pagadofecha += decimal.Parse(DtCuotas.Rows[i]["Aportado"].ToString().Replace(",", ""), CultureInfo.InvariantCulture);
                    if (DtCuotas.Rows[i]["Estado"].ToString() == "Pagada")
                    {
                        //pagadofecha += decimal.Parse(DtCuotasPorPagar.Rows[i]["Aportado"].ToString().Replace(",", ""));
                        DtRefinanciacion.ImportRow(DtCuotas.Rows[i]); //se copia la  fila del  dt1  en el  DataTable nuevo
                    }
                    else
                    {
                        DtCamio.ImportRow(DtCuotas.Rows[i]); //se copia la  fila del  dt1  en el  DataTable nuevo
                    }
                }
                TxtAportes.Text = Math.Round(Convert.ToDouble(pagadofecha), 2).ToString("N2", CultureInfo.CurrentCulture);
                dataGridView1.DataSource = DtCuotas;
                dataGridView1.Columns[0].Visible = false;
                if (Refi == 0)
                {
                    dataGridView3.DataSource = DtRefinanciacion;
                    dataGridView3.Columns[0].Visible = false;
                }


                //dataGridView1.Columns["Id_Cuota"].Visible = false;
                //dataGridView1.Columns["Capital"].DefaultCellStyle.Format = "n0";
                //dataGridView1.Columns["Interes"].DefaultCellStyle.Format = "n0";
                //dataGridView1.Columns["Saldo"].DefaultCellStyle.Format = "n0";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al listar cuotas: " + ex, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            
        }

        private void listarCuotasFinaciadas(int Financiacion, int Valor_Neto, int Valor_Sin, int Valor_Interes, double Valor_Cuota_Con_Interes, double Total)
        {
            try
            {
                DataTable DtCuotasInteres = new DataTable();
                DtCuotasInteres = cuota.ListarCuotasInteres2(Financiacion);
                DtCuotasInteres.Columns.Add("Capital", typeof(decimal));
                DtCuotasInteres.Columns.Add("Interes", typeof(decimal));
                DtCuotasInteres.Columns.Add("Saldo", typeof(decimal));

                decimal saldo = Valor_Neto - Valor_Sin;
                decimal interes = saldo * (Convert.ToDecimal(Valor_Interes) / 100);
                decimal capital = (decimal)Valor_Cuota_Con_Interes - interes;
                decimal interesfecha = 0;
                //double interes = Math.Round(saldo * (Convert.ToDouble(Valor_Interes) / 100), 1);
                for (int i = 0; i < DtCuotasInteres.Rows.Count; i++)
                {
                    DateTime date = DateTime.ParseExact(DtCuotasInteres.Rows[i]["Fecha Pago"].ToString(), "yyyy-MM-dd", CultureInfo.InvariantCulture);
                    if (i != 0)
                    {

                        interes = saldo * (Convert.ToDecimal(Valor_Interes) / 100);
                        capital = (decimal)Valor_Cuota_Con_Interes - interes;
                    }
                    if (date <= actual)
                    {

                        if (DtCuotasInteres.Rows[i]["Estado"].ToString() == "Mora")
                        {
                            interesfecha += interes;
                        }
                        else if (DtCuotasInteres.Rows[i]["Estado"].ToString() == "Pagada")
                        {
                        }
                        //aqui actuliza el estado de la cuota
                    }
                    saldo = saldo - capital;
                    DtCuotasInteres.Rows[i]["Saldo"] = Math.Round(saldo);
                    DtCuotasInteres.Rows[i]["Interes"] = Math.Round(interes);
                    DtCuotasInteres.Rows[i]["Capital"] = Math.Round(capital);
                }
                if (Refi == 0)
                {
                    TxtValorMora.Text = interesfecha.ToString("N2", CultureInfo.CurrentCulture);
                    TxtValorDeuda.Text = ((Valor_Neto - pagadofecha) + interesfecha).ToString("N2", CultureInfo.CurrentCulture);
                }
                dataGridView2.DataSource = DtCuotasInteres;
                dataGridView2.Columns["Id_Cuota"].Visible = false;

                dataGridView2.Columns["Capital"].DefaultCellStyle.Format = "n2";
                dataGridView2.Columns["Interes"].DefaultCellStyle.Format = "n2";
                dataGridView2.Columns["Saldo"].DefaultCellStyle.Format = "n2";

                //DtRpAmortizacion = DtCuotasInteres.Copy();
                //DtRpAmortizacion.Columns.Remove("Id_Cuota");
            }
            
            catch (Exception ex)
            {
                MessageBox.Show("Error al listar cuotas amortizacion: " + ex, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void CalcularCuotasFinacianciacion(double Valor_Deuda, int Valor_Interes, double Valor_Cuota_Con_Interes, int Numero_CuotasCon_Interes)
        {
            try { 
                if (numCuotasFinan.Value > 0 )
                {                               
                    DtNuevasCuotas = DtRefinanciacion.Clone(); //para tener la misma estructura del dt1 y no tener problemas
                    DtNuevas.Clear();
                    DtNuevas = DtRefinanciacion.Copy();
                    decimal TotalCuotas = 0;
                    decimal TotalInteres = 0;
                    decimal TotalCapital = 0;

                    DtNuevasCuotas.Columns.Add("Capital", typeof(string));
                    DtNuevasCuotas.Columns.Add("Interes", typeof(string));
                    DtNuevasCuotas.Columns.Add("Saldo", typeof(string));
                    string fecha = "";
                    decimal saldo = (decimal)Valor_Deuda;
                    decimal interes = saldo * (Convert.ToDecimal(Valor_Interes) / 100);
                    decimal capital = Convert.ToDecimal(Valor_Cuota_Con_Interes) - interes;
                    //double interes = Math.Round(saldo * (Convert.ToDouble(Valor_Interes) / 100), 1);
                    for (int i = 0; i < Numero_CuotasCon_Interes; i++)
                    {
                        if (i == 0)
                        {
                            fecha = DateRecaudo.Text;
                        }
                        if (i != 0)
                        {
                            interes = saldo * (Convert.ToDecimal(Valor_Interes) / 100);
                            capital = Convert.ToDecimal(Valor_Cuota_Con_Interes) - interes;
                            DateTime daterecaudo = Convert.ToDateTime(DateRecaudo.Text);
                            fecha = daterecaudo.AddMonths(i).ToString("yyyy-MM-dd");
                        }
                        saldo = saldo - capital;
                        DataRow fila = DtNuevasCuotas.NewRow();
                        fila["Cuota"] = i + 1;
                        fila["Valor"] = Valor_Cuota_Con_Interes.ToString("N2", CultureInfo.CurrentCulture);
                        fila["Tipo"] = "Refinanciación";
                        fila["Fecha"] = fecha;
                        fila["Aportado"] = 0;
                        fila["Estado"] = "Pendiente";
                        fila["Saldo"] = saldo.ToString("N2", CultureInfo.CurrentCulture);
                        fila["Interes"] = interes.ToString("N2", CultureInfo.CurrentCulture);
                        fila["Capital"] = capital.ToString("N2", CultureInfo.CurrentCulture);
                        DtNuevasCuotas.Rows.Add(fila);
                        TotalCuotas += Convert.ToDecimal(Valor_Cuota_Con_Interes);
                        TotalInteres += interes;
                        TotalCapital += capital;
                    }
                    DataRow row = DtNuevasCuotas.NewRow();
                    row["Capital"] = TotalCapital.ToString("n2");
                    row["Interes"] = TotalInteres.ToString("n2");
                    row["Estado"] = "Total";
                    row["Valor"] = TotalCuotas.ToString("n2");
                    DtNuevasCuotas.Rows.Add(row);
                
                    //DataRow row = DtCuotasInteres.NewRow();
                    //row["Cuota"] = 0;
                    //row["Valor"] = 0;
                    //row["Capital"] = 0;
                    //row["Interes"] = 0;
                    //row["Saldo"] = 0;
                    DtNuevas.Merge(DtNuevasCuotas);
                    FilaTotal = DtNuevas.Rows.Count;
                    dataGridView3.DataSource = DtNuevas;
                    dataGridView3.Columns[0].Visible = false;
                    dataGridView3.Columns["Valor"].DisplayIndex = 5;
                    dataGridView3.Columns["Cuota"].Width= 45;
                    dataGridView3.Columns["Tipo"].Width = 90;
                    dataGridView3.Columns["Fecha"].Width = 65;
                    //dataGridView3.Columns["Valor"].DefaultCellStyle.Format = "n0";
                    //dataGridView3.Columns["Saldo"].DefaultCellStyle.Format = "n0";
                    //formatoGrid1();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error al calcular cuotas amortizacion: "+ex, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

}
        
        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridView1.Columns.Count > 5)
            {
                dataGridView1.Columns["Cuota"].Width = 50;                
                DataGridView dgv = sender as DataGridView;
                int n = e.RowIndex;
                try
                {
                    if (dgv.Columns[e.ColumnIndex].Name == "Estado")  //Si es la columna a evaluar
                    {
                        if (n <= dataGridView1.Rows.Count)
                        {
                            if (e.Value.ToString().Contains("Pagada"))   //Si el valor de la celda contiene la palabra hora Pagada Mora
                            {
                                dataGridView1.Rows[n].DefaultCellStyle.BackColor = Color.Honeydew;
                            }
                            else if (e.Value.ToString().Contains("Mora"))
                            {
                                dataGridView1.Rows[n].DefaultCellStyle.BackColor = Color.AntiqueWhite;
                                //e.CellStyle.ForeColor = Color.Crimson;
                                //e.CellStyle.BackColor = Color.Orange;
                                //e.CellStyle.BackColor = Color.PaleVioletRed;
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
                catch (Exception ex)
                {
                    
                }
            }            
        }


        private void button1_Click(object sender, EventArgs e)
        {
            try
            {                
                for (int i = 0; i < DtCamio.Rows.Count; i++)
                {
                    cuota.InactivarCuota(int.Parse(DtCamio.Rows[i]["Cuota"].ToString()), "Inactiva", Id_Financiacion, DtCamio.Rows[i]["Tipo"].ToString());
                }
                refinanciacion.crearRefinanciacion(int.Parse(Convert.ToDouble(TxtValorNeto.Text).ToString()), double.Parse(Convert.ToDouble(TxtValorMora.Text).ToString(), CultureInfo.CurrentCulture), double.Parse(Convert.ToDouble(TxtValorDeuda.Text).ToString(), CultureInfo.CurrentCulture   ), int.Parse(numCuotasFinan.Text.ToString()), double.Parse(Convert.ToDouble(TxtValorCuota.Text).ToString()), int.Parse(numValorInteres.Text.ToString()), double.Parse(Convert.ToDouble(TxtTotalRefi.Text).ToString()), double.Parse(Convert.ToDouble(TxtTotal.Text).ToString()), DateTime.Now.ToString("yyyy-MM-dd"), DtosUsuario.NombreUser, Id_Financiacion);
                for (int n = 0; n+1 < DtNuevasCuotas.Rows.Count; n++)
                {
                    int NumCuota = int.Parse(DtNuevasCuotas.Rows[n]["Cuota"].ToString());
                    double ValorCuota = double.Parse(DtNuevasCuotas.Rows[n]["Valor"].ToString().Replace(".", ""));
                    string TipoCuota = DtNuevasCuotas.Rows[n]["Tipo"].ToString();
                    string FechaCuota = DtNuevasCuotas.Rows[n]["Fecha"].ToString();

                    cuota.CrearCuota(NumCuota, ValorCuota, TipoCuota, FechaCuota, "Pendiente", Id_Financiacion);
                }
                DataTable DtTem = refinanciacion.RefinanciacionFinanciacion(Id_Financiacion);
                Refi=int.Parse(DtTem.Rows[0]["Id_Refinanciacion"].ToString());
                ListarCuotasRefi(Id_Financiacion);            
                listarCuotas(Id_Financiacion);
            
                button1.Visible = false;
                button2.Visible = true;
        }
            catch(Exception ex)
            {
                MessageBox.Show("Error al guardar: "+ex, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

}
        private void button2_Click(object sender, EventArgs e)
        {
            reportesPDF.Refinanciacion(DtRpRefinaciacion, NomCliente , NomProducto ,NomProyeco, TxtValorNeto.Text, TxtValorMora.Text, TxtAportes.Text, TxtValorDeuda.Text, TxtValorCuota.Text, numCuotasFinan.Text, numValorInteres.Text, TxtTotalRefi.Text, TxtTotal.Text);
        }
        private void dataGridView3_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            //if (DtNuevas.Rows.Count > 0 )
            //{
            //    dataGridView3.Rows[FilaTotal - 1].DefaultCellStyle.Font = new Font(dataGridView3.Font, FontStyle.Bold);
            //}
            
        }

        private void Refinanciacion_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.DialogResult=DialogResult.OK;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void numValorInteres_Click(object sender, EventArgs e)
        {
            if (numCuotasFinan.Value > 0)
            {
                calcularvalorCuota();
            }           
        }

        private void numCuotasFinan_Click(object sender, EventArgs e)
        {
            numCuotasFinan.Minimum = 1;
            calcularvalorCuota();
        }
        private void calcularvalorCuota()
        {
            try
            {
                double saldo = double.Parse(Convert.ToDouble(TxtValorDeuda.Text).ToString());
                double ValInteres = int.Parse(numValorInteres.Text);
                double ValorCuotaInteres;
                double Interes = 0;
                double NumCuotas = int.Parse(numCuotasFinan.Text);
                int cuotas = int.Parse(numCuotasFinan.Text);
                if (numValorInteres.Value == 0)
                {
                    Interes = ValInteres;
                    ValorCuotaInteres = saldo / NumCuotas;
                }
                else
                {
                    Interes = ValInteres;
                    ValInteres = Interes / 100;
                    ValorCuotaInteres = (ValInteres * saldo) / (1 - Math.Pow(1 + ValInteres, -cuotas));
                }
                TxtTotalRefi.Text = (ValorCuotaInteres * NumCuotas).ToString("n2");
                TxtValorCuota.Text = ValorCuotaInteres.ToString("n2");               
                CalcularCuotasFinacianciacion(double.Parse(Convert.ToDouble(TxtValorDeuda.Text).ToString()), Convert.ToInt16(Interes), ValorCuotaInteres, int.Parse(numCuotasFinan.Text));
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error al calcular valor cuota: "+ex, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            
        }
    }
}
