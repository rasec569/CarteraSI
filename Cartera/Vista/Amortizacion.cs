﻿using System;
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

namespace Cartera.Vista
{
    public partial class Amortizacion : Form
    {
        CCuota cuota = new CCuota();
        bool cargarbotones= true;
        int FilaTotal;        
        public Amortizacion()
        {
            InitializeComponent();
        }
        public Amortizacion(int Financiacion, int Valor_Neto, int Valor_Sin, int Valor_Interes,  int Valor_Cuota_Con_Interes, int Valor_Total)
        {
            //Financiacion,Valor_Neto,valorSin,ValorInteres,ValorCuotaInteres
            InitializeComponent();
            TxtValorNeto.Text = Valor_Neto.ToString("N0", CultureInfo.CurrentCulture);
            TxtValorInicial.Text = Valor_Sin.ToString("N0", CultureInfo.CurrentCulture);
            TxtValorSaldo.Text = (Valor_Neto - Valor_Sin).ToString("N0", CultureInfo.CurrentCulture);
            TxtValorCuotaInteres.Text = Valor_Cuota_Con_Interes.ToString("N0", CultureInfo.CurrentCulture);
            TxtValorNeto.Text = Valor_Neto.ToString("N0", CultureInfo.CurrentCulture);
            TxtValorNeto.Text = Valor_Neto.ToString("N0", CultureInfo.CurrentCulture);
            numValorInteres.Text = Valor_Interes.ToString();
            TxtTotal.Text = Valor_Total.ToString("N0", CultureInfo.CurrentCulture);

            listarCuotasFinaciadas(Financiacion, Valor_Neto, Valor_Sin, Valor_Interes, Valor_Cuota_Con_Interes, Valor_Total);
        }
        public Amortizacion(int Valor_Neto, int Valor_Sin, int Valor_Interes,int NumCuotas, int Valor_Cuota_Con_Interes, int Valor_Total,int Ensayo)
        {
            InitializeComponent();
            TxtValorNeto.Text = Valor_Neto.ToString("N0", CultureInfo.CurrentCulture);
            TxtValorInicial.Text = Valor_Sin.ToString("N0", CultureInfo.CurrentCulture);
            TxtValorSaldo.Text = (Valor_Neto - Valor_Sin).ToString("N0", CultureInfo.CurrentCulture);
            TxtValorCuotaInteres.Text = Valor_Cuota_Con_Interes.ToString("N0", CultureInfo.CurrentCulture);
            TxtValorNeto.Text = Valor_Neto.ToString("N0", CultureInfo.CurrentCulture);
            TxtValorNeto.Text = Valor_Neto.ToString("N0", CultureInfo.CurrentCulture);
            numValorInteres.Text = Valor_Interes.ToString();
            numCuotasFinan.Text = NumCuotas.ToString();
            TxtTotal.Text = Valor_Total.ToString("N0", CultureInfo.CurrentCulture);

            CalcularCuotasFinaciadas(Valor_Neto, Valor_Sin, Valor_Interes, Valor_Cuota_Con_Interes, NumCuotas);
        }
        private void CargarCuotasInteres()
        {
            //dataGridView1.DataSource = cuota.ListarCuotasInteres(Financiacion);
            //dataGridView1.Columns["Id_Producto"].Visible = false;
            //dataGridView1.Columns["Observaciones"].Visible = false;
            //dataGridView1.Columns["Contrato"].Visible = false;
            //dataGridView1.Columns["Fk_Id_Proyecto"].Visible = false;
            //dataGridView1.Columns["Fk_Id_Tipo_Producto"].Visible = false;
            //formatoGrid1();
        }
        private void Detalle_Load(object sender, EventArgs e)
        {

        }
        private void listarCuotasFinaciadas(int Financiacion, int Valor_Neto, int Valor_Sin, int Valor_Interes, int Valor_Cuota_Con_Interes, int Total)
        {
            DateTime actual = DateTime.ParseExact(DateTime.Now.ToString("yyyy-MM-dd"), "yyyy-MM-dd", CultureInfo.InvariantCulture);
            DataTable DtCuotasInteres = new DataTable();
            DtCuotasInteres = cuota.ListarCuotasInteres2(Financiacion);            
            numCuotasFinan.Text= DtCuotasInteres.Rows.Count.ToString();
            DtCuotasInteres.Columns.Add("Capital", typeof(decimal));
            DtCuotasInteres.Columns.Add("Interes", typeof(decimal));
            DtCuotasInteres.Columns.Add("Saldo", typeof(decimal));

            decimal saldo = Valor_Neto - Valor_Sin;
            decimal interes = saldo * (Convert.ToDecimal(Valor_Interes) / 100);
            decimal capital = Valor_Cuota_Con_Interes - interes;
            decimal pagadofecha = 0;
            decimal deudafecha = 0;
            decimal interesfecha = 0;
            decimal capitalfecha = 0;
            decimal TotalCuotas = 0;
            decimal TotalInteres = 0;
            decimal TotalCapital = 0;
            //double interes = Math.Round(saldo * (Convert.ToDouble(Valor_Interes) / 100), 1);
            for (int i = 0; i < DtCuotasInteres.Rows.Count; i++)
            {
                DateTime date = DateTime.ParseExact(DtCuotasInteres.Rows[i]["Fecha Pactada"].ToString(), "yyyy-MM-dd", CultureInfo.InvariantCulture);
                if (i != 0)
                {
                    
                    interes = saldo * (Convert.ToDecimal(Valor_Interes) / 100);
                    capital = Valor_Cuota_Con_Interes - interes;
                }
                if(date <= actual)
                {
                    
                    if (DtCuotasInteres.Rows[i]["Estado"].ToString() == "Pagada")
                    {
                        pagadofecha += Valor_Cuota_Con_Interes;
                        interesfecha += interes;
                        capitalfecha += capital;
                    }
                    else
                    {
                        deudafecha += Valor_Cuota_Con_Interes;
                    }
                //aqui actuliza el estado de la cuota
                }
                saldo = saldo - capital;
                DtCuotasInteres.Rows[i]["Saldo"] = saldo;
                DtCuotasInteres.Rows[i]["Interes"] = interes;
                DtCuotasInteres.Rows[i]["Capital"] = capital;
                TotalCuotas += Valor_Cuota_Con_Interes;
                TotalInteres += interes;
                TotalCapital += capital;
            }
            DataRow row = DtCuotasInteres.NewRow();
            row["Estado"] = "Total";
            row["Capital"] = TotalCapital;
            row["Interes"] = TotalInteres;
            row["Valor"] = TotalCuotas.ToString("n0");
            DtCuotasInteres.Rows.Add(row);
            FilaTotal = DtCuotasInteres.Rows.Count;

            dataGridView1.DataSource = DtCuotasInteres;
            dataGridView1.Columns["Id_Cuota"].Visible = false;
            dataGridView1.Columns["Capital"].DefaultCellStyle.Format = "n0";
            dataGridView1.Columns["Interes"].DefaultCellStyle.Format = "n0";
            dataGridView1.Columns["Saldo"].DefaultCellStyle.Format = "n0";
            labelPagado.Text = "Abono Capital: " + capitalfecha.ToString("n0");
            labelInteres.Text = "Abono Interes: " + interesfecha.ToString("n0");
            labelSaldo.Text = "Pagado a la fecha: " + pagadofecha.ToString("n0");
            labelDeuda.Text= "Deuda a la fecha: " + deudafecha.ToString("n0");
            formatoGrid1();


        }
        private void CalcularCuotasFinaciadas(int Valor_Neto, int Valor_Sin, int Valor_Interes, int Valor_Cuota_Con_Interes, int Numero_CuotasCon_Interes)
        {
            DataTable DtCuotasInteres = new DataTable();
            DtCuotasInteres.Columns.Add("Cuota", typeof(int));
            DtCuotasInteres.Columns.Add("Valor", typeof(decimal));
            DtCuotasInteres.Columns.Add("Capital", typeof(decimal));
            DtCuotasInteres.Columns.Add("Interes", typeof(decimal));
            DtCuotasInteres.Columns.Add("Saldo", typeof(decimal));

            decimal saldo = Valor_Neto - Valor_Sin;
            decimal interes = saldo * (Convert.ToDecimal(Valor_Interes) / 100);
            decimal capital = Valor_Cuota_Con_Interes - interes;
            //double interes = Math.Round(saldo * (Convert.ToDouble(Valor_Interes) / 100), 1);
            for (int i = 0; i < Numero_CuotasCon_Interes; i++)
            {
                if (i != 0)
                {
                    interes = saldo * (Convert.ToDecimal(Valor_Interes) / 100);
                    capital = Valor_Cuota_Con_Interes - interes;
                }
                saldo = saldo - capital;
                DataRow fila = DtCuotasInteres.NewRow();
                fila["Cuota"] = i+1;
                fila["Valor"] = Valor_Cuota_Con_Interes;
                fila["Saldo"] = saldo;
                fila["Interes"] = interes;
                fila["Capital"] = capital;
                DtCuotasInteres.Rows.Add(fila);
            }
            //DataRow row = DtCuotasInteres.NewRow();
            //row["Cuota"] = 0;
            //row["Valor"] = 0;
            //row["Capital"] = 0;
            //row["Interes"] = 0;
            //row["Saldo"] = 0;
            dataGridView1.DataSource = DtCuotasInteres;
            dataGridView1.Columns["Capital"].DefaultCellStyle.Format = "n0";
            dataGridView1.Columns["Interes"].DefaultCellStyle.Format = "n0";
            dataGridView1.Columns["Saldo"].DefaultCellStyle.Format = "n0";
            
            //

        }
        private void formatoGrid1()
        {
            //dataGridView1.Columns[1].DefaultCellStyle.Format = "n0";
            //dataGridView1.Columns[5].DefaultCellStyle.Format = "n0";
            //dataGridView1.Columns[6].DefaultCellStyle.Format = "n0";            
            
            //dataGridView1.Columns[2].Width = 65;
            //dataGridView1.Columns[3].Width = 70;
            //dataGridView1.Columns[4].Width = 65;
            //dataGridView1.Columns[5].Width = 65;
            //dataGridView1.Columns[6].Width = 65;
            //dataGridView1.Columns[7].Width = 65;
            //dataGridView1.Columns[9].Width = 160;
            //dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;            
            //if (cargarbotones == true)
            //{
            //    this.dataGridView1.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dataGridView1_RowPostPaint);
            //    DataGridViewButtonColumn BtPago = new DataGridViewButtonColumn();
            //    BtPago.Name = "Pagar";
            //    BtPago.HeaderText = "";
            //    BtPago.UseColumnTextForButtonValue = true;
            //    DataGridViewButtonColumn BtHistorial = new DataGridViewButtonColumn();
            //    BtHistorial.Name = "Historial";
            //    BtHistorial.HeaderText = "";
            //    BtHistorial.UseColumnTextForButtonValue = true;
            //    dataGridView1.Columns.Add(BtPago);
            //    dataGridView1.Columns.Add(BtHistorial);                
            //}            
        }

        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            
            //if (e.RowIndex < 0)
            //    return;
            //if (e.ColumnIndex >= 0 && this.dataGridView1.Columns[e.ColumnIndex].Name == "Pagar" && e.RowIndex >= 0)
            //{
            //    e.Paint(e.CellBounds, DataGridViewPaintParts.All);
            //    DataGridViewButtonCell celboton = this.dataGridView1.Rows[e.RowIndex].Cells["Pagar"] as DataGridViewButtonCell;
            //    Icon PagarIcon = new Icon(Environment.CurrentDirectory + @"\\img\Pagos.ico");
            //    e.Graphics.DrawIcon(PagarIcon, e.CellBounds.Left + 3, e.CellBounds.Top + 3);
            //    this.dataGridView1.Rows[e.RowIndex].Height = PagarIcon.Height + 8;
            //    this.dataGridView1.Columns[e.ColumnIndex].Width = PagarIcon.Width + 8;
            //    e.Handled = true;
            //}
            //else if (e.ColumnIndex >= 0 && this.dataGridView1.Columns[e.ColumnIndex].Name == "Historial" && e.RowIndex >= 0)
            //{
            //    e.Paint(e.CellBounds, DataGridViewPaintParts.All);
            //    DataGridViewButtonCell celboton = this.dataGridView1.Rows[e.RowIndex].Cells["Historial"] as DataGridViewButtonCell;
            //    Icon HistorialIcon = new Icon(Environment.CurrentDirectory + @"\\img\HistorialPagos.ico");
            //    e.Graphics.DrawIcon(HistorialIcon, e.CellBounds.Left + 3, e.CellBounds.Top + 3);
            //    this.dataGridView1.Rows[e.RowIndex].Height = HistorialIcon.Height + 8;
            //    this.dataGridView1.Columns[e.ColumnIndex].Width = HistorialIcon.Width + 8;
            //    e.Handled = true;
            //}
        }


        

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            //using (SolidBrush b = new SolidBrush(dataGridView1.RowHeadersDefaultCellStyle.ForeColor))
            //{
            //    e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 16, e.RowBounds.Location.Y + 4);
            //}
            
        }

        private void dataGridView1_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.ColumnIndex >= 0 & e.RowIndex >= 0)
            //{
            //    DataGridViewCell cell = this.dataGridView1.Rows[e.RowIndex].Cells["Pagar"];
            //    cell.ToolTipText = "Clic para registrar pago";
            //    DataGridViewCell cell2 = this.dataGridView1.Rows[e.RowIndex].Cells["Historial"];
            //    cell2.ToolTipText = "Clic para ver historial de pagos";
            //}
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            dataGridView1.Columns[1].Width = 70;
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
                            dataGridView1.Rows[n].DefaultCellStyle.BackColor = Color.LightGreen;
                        }
                        else if (e.Value.ToString().Contains("Mora"))
                        {
                            dataGridView1.Rows[n].DefaultCellStyle.BackColor = Color.DarkOrange;
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
            catch
            {

            }
        }


            private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dataGridView1.Rows[FilaTotal - 1].DefaultCellStyle.Font = new Font(dataGridView1.Font, FontStyle.Bold);
        }
    }
}