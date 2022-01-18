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

namespace Cartera.Vista
{
    public partial class Amortizacion : Form
    {
        CCuota cuota = new CCuota();
        bool cargarbotones= true;
        public Amortizacion()
        {
            InitializeComponent();
        }
        public Amortizacion(int Financiacion, int Valor_Neto, int Valor_Sin, int Valor_Interes,  int Valor_Cuota_Con_Interes)
        {
            //Financiacion,Valor_Neto,valorSin,ValorInteres,ValorCuotaInteres
            InitializeComponent();
            TxtValorNeto.Text = Valor_Neto.ToString();
            TxtValorInicial.Text = Valor_Sin.ToString();
            TxtValorSaldo.Text = (Valor_Neto - Valor_Sin).ToString();
            TxtValorCuotaInteres.Text = Valor_Cuota_Con_Interes.ToString();
            TxtValorNeto.Text = Valor_Neto.ToString();
            TxtValorNeto.Text = Valor_Neto.ToString();

            listarCuotasFinaciadas(Financiacion, Valor_Neto, Valor_Sin, Valor_Interes, Valor_Cuota_Con_Interes);
        }
        public Amortizacion(Int64 cedula, string nombre, string clienteid, string carteraid)
        {
            InitializeComponent();
          
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
        private void listarCuotasFinaciadas(int Financiacion, int Valor_Neto, int Valor_Sin, int Valor_Interes, int Valor_Cuota_Con_Interes)
        {
            DataTable DtCuotasInteres = new DataTable();
            DtCuotasInteres = cuota.ListarCuotasInteres(Financiacion);
            DtCuotasInteres.Columns.Add("Capital", typeof(double));
            DtCuotasInteres.Columns.Add("Interes", typeof(double));
            DtCuotasInteres.Columns.Add("Saldo", typeof(double));
            double saldo = Valor_Neto - Valor_Sin;
            double interes = Math.Round(saldo * (Convert.ToDouble(Valor_Interes) / 100), 0);
            double capital = Math.Round(Valor_Cuota_Con_Interes - interes, 0);
            for (int i = 0; i < DtCuotasInteres.Rows.Count; i++)
            {                
                saldo = Math.Round(saldo - capital, 0);
                if (i != 0)
                {
                    interes = Math.Round(saldo * (Convert.ToDouble(Valor_Interes) / 100), 0);
                    capital = Math.Round(Valor_Cuota_Con_Interes - interes, 0);
                }
                DtCuotasInteres.Rows[i]["Saldo"] = saldo;
                DtCuotasInteres.Rows[i]["Interes"] = interes;
                DtCuotasInteres.Rows[i]["Capital"] = capital;
            }
            dataGridView1.DataSource = DtCuotasInteres;
            dataGridView1.Columns["Tipo"].Visible = false;
            dataGridView1.Columns["Capital"].DefaultCellStyle.Format = "n0";
            dataGridView1.Columns["Interes"].DefaultCellStyle.Format = "n0";
            dataGridView1.Columns["Saldo"].DefaultCellStyle.Format = "n0";
            //
        }
        private void formatoGrid1()
        {
            //dataGridView1.Columns[4].DefaultCellStyle.Format = "n0";
            //dataGridView1.Columns[5].DefaultCellStyle.Format = "n0";
            //dataGridView1.Columns[6].DefaultCellStyle.Format = "n0";
            //dataGridView1.Columns[1].Width = 65;
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
    }
}
