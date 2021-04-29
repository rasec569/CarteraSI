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
    public partial class Carteras : Form 
    {
        CCartera cartera = new CCartera();
        CCliente cliente = new CCliente();
        CProducto producto = new CProducto();
        DataTable DtCartera = new DataTable();
        DataTable DtCliente = new DataTable();
        DataTable DtReporte=new DataTable();
        bool Validarestados = true;
        private ReportesPDF reportesPDF;
        public Carteras()
        {
            InitializeComponent();
            reportesPDF = new ReportesPDF();
        }
        private void Carteras_Load(object sender, EventArgs e)
        {
            CargarCartera();
            autocompletar();
        }

        private void CargarCartera()
        {
            if (Txtcedula.Text == "")
            {
                DtCartera = cartera.ListarCartera();
                DtReporte = DtCartera.Copy();
                DtReporte.Columns.Remove("Id_Cliente");
                DtReporte.Columns.Remove("Id_Cartera");

                //DtReporte.Columns[5].DefaultCellStyle.Format = "n1";
                dataGridView1.DataSource = DtCartera;
            }
            else
            {
                DtCartera = cartera.CarteraCliente(Txtcedula.Text);
                dataGridView1.DataSource = DtCartera;
            }
            DataTable DtValoreCartera = cartera.TotalesCartera();
            int total= int.Parse(DtValoreCartera.Rows[0]["total"].ToString());
            int deuda= int.Parse(DtValoreCartera.Rows[0]["saldo"].ToString());
            int pagado = int.Parse(DtValoreCartera.Rows[0]["recaudo"].ToString());
            labelTotal.Text="TOTAL: $"+ String.Format("{0:N0}", total);
            labelDeuda.Text = "VALOR DEUDA: $" + String.Format("{0:N0}", deuda);
            labelRecaudo.Text = "VALOR RECAUDADO: $" + String.Format("{0:N0}", pagado);

            dataGridView1.Columns["Id_Cliente"].Visible = false;
            dataGridView1.Columns[5].DefaultCellStyle.Format = "n0";
            //dataGridView1.Columns["Id_Producto"].Visible = false;
            dataGridView1.Columns[7].DefaultCellStyle.Format = "n0";
            dataGridView1.Columns[8].DefaultCellStyle.Format = "n0";
            dataGridView1.Columns["Id_Cartera"].Visible = false;            

            if (Validarestados == true)
            {
                actulizarestado();
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RegistrarPago Rp = new RegistrarPago();
            Rp.FormClosed += Pagos_FormClose;
            Rp.ShowDialog();
        }
        private void Pagos_FormClose(object sender, FormClosedEventArgs e)
        {
            Form frm = sender as Form;
            if(frm.DialogResult== DialogResult.OK)
            {
                Validarestados = true;
                CargarCartera();
            }
           
        }
        private void comboEstados_SelectedValueChanged(object sender, EventArgs e)
        {
            string Estados = comboEstados.Items[comboEstados.SelectedIndex].ToString();
            if (Estados == "Menos de 30 días")
            {
                DtCartera.DefaultView.RowFilter = $"Pago LIKE 'Menos de 30 días'";
            }
            else if (Estados == "De 31 a 60 días")
            {
                DtCartera.DefaultView.RowFilter = $"Pago LIKE 'De 31 a 60 días'";
            }
            else if (Estados == "De 61 a 90 días")
            {
                DtCartera.DefaultView.RowFilter = $"Pago LIKE 'De 61 a 90 días'";
            }
            else if (Estados == "De 91 a 180 días")
            {
                DtCartera.DefaultView.RowFilter = $"Pago LIKE 'De 91 a 180 días'";
            }
            else if (Estados == "Mas de 360 días")
            {
                DtCartera.DefaultView.RowFilter = $"Pago LIKE 'Mas de 360 días'";
            }
            else if (Estados == "Pagado")
            {
                DtCartera.DefaultView.RowFilter = $"Pago LIKE 'Pagado'";
            }
            else if(Estados=="Todo")
            {
                CargarCartera();
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int cedula = 0;
            string nombre = "";
            string apellido = "";
            string clienteid = "";
            string carteraid = "";
            try
            {
                int n = e.RowIndex;
                if (n != -1)
                {
                    clienteid = dataGridView1.Rows[n].Cells["Id_Cliente"].Value.ToString();
                    cedula = int.Parse(dataGridView1.Rows[n].Cells["Cedula"].Value.ToString());
                    nombre = dataGridView1.Rows[n].Cells["Nombres"].Value.ToString();
                    apellido = dataGridView1.Rows[n].Cells["Apellidos"].Value.ToString();
                    carteraid = dataGridView1.Rows[n].Cells["Id_Cartera"].Value.ToString();
                    RegistrarPago Rp = new RegistrarPago(cedula, nombre + " " + apellido, clienteid, carteraid);
                    Rp.FormClosed += Pagos_FormClose;
                    Rp.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Valor no admitido"+ex);
            }
        }
        private void actulizarestado()
        {
            for (int i = 0; i < DtCartera.Rows.Count; i++)
            {
                string datoDT = DtCartera.Rows[i]["Id_Cliente"].ToString();
                if(int.Parse(DtCartera.Rows[i]["Recaudado"].ToString())- int.Parse(DtCartera.Rows[i]["Total"].ToString()) == 0)
                {
                    cartera.ActulizarEstados(DtCartera.Rows[i]["Id_Cartera"].ToString(), "Pagado");
                    //dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Aquamarine;
                }
                else
                {
                    DataTable dtproducto = producto.cargarProductosCliente(int.Parse(datoDT));
                    for (int j = 0; j < dtproducto.Rows.Count; j++)
                    {
                        string datoDT2 = dtproducto.Rows[j]["Id_Producto"].ToString();
                        DataTable dtfechas = cartera.BuscarFechaspagos(int.Parse(datoDT2));

                        if (dtproducto.Rows[j]["Forma Pago"].ToString() == "Contado")
                        {
                            for (int h = 0; h < dtfechas.Rows.Count; h++)
                            {
                                if (dtfechas.Rows.Count > 0 && !string.IsNullOrEmpty(dtfechas.Rows[h]["Fecha Pago"].ToString()))
                                {
                                    cartera.ActulizarEstados(DtCartera.Rows[i]["Id_Cartera"].ToString(), "Al Dia");
                                }
                                else
                                {
                                    cartera.ActulizarEstados(DtCartera.Rows[i]["Id_Cartera"].ToString(), "Sin pagos Contado");
                                }
                            }
                        }
                        else
                        {
                            for (int h = 0; h < dtfechas.Rows.Count; h++)
                            {
                                if (dtfechas.Rows.Count > 0 && !string.IsNullOrEmpty(dtfechas.Rows[h]["Fecha_Recaudo"].ToString()))
                                {
                                    string fecha1 = dtfechas.Rows[h]["Fecha_Pago"].ToString();
                                    string fecha2 = dtfechas.Rows[h]["Fecha_Recaudo"].ToString();
                                    DateTime date_1 = DateTime.ParseExact(fecha1, "yyyy-MM-dd", CultureInfo.InvariantCulture);
                                    DateTime date_2 = DateTime.ParseExact(fecha2, "yyyy-MM-dd", CultureInfo.InvariantCulture);
                                    DateTime actual = DateTime.ParseExact(DateTime.Now.ToString("yyyy-MM-dd"), "yyyy-MM-dd", CultureInfo.InvariantCulture);
                                    //var days = int.Parse(((actual - date_2).Days).ToString());
                                    TimeSpan Ultimo = actual.Subtract(date_1);
                                    //MessageBox.Show(" dias:"+ Diff_dates.Days);
                                    var pagos = int.Parse(dtfechas.Rows[h]["Cuotas_Pagadas"].ToString());
                                    //int DiasMora = days- (pagos * 30);
                                    string estado = "";
                                    //switch (DiasMora)
                                    switch (Ultimo.Days)
                                    {
                                        case int n when n <= 30:
                                            estado = "Menos de 30 días";
                                            break;
                                        case int n when n <= 60:
                                            estado = "De 31 a 60 días";
                                            break;
                                        case int n when n <= 90:
                                            estado = "De 61 a 90 días";
                                            break;
                                        case int n when n <= 180:
                                            estado = "De 91 a 180 días";
                                            break;
                                        case int n when n <= 360:
                                            estado = "Mas de 360 días";
                                            break;
                                    }
                                    cartera.ActulizarEstados(DtCartera.Rows[i]["Id_Cartera"].ToString(), estado);
                                }
                                else if (string.IsNullOrEmpty(dtfechas.Rows[h]["Fecha_Pago"].ToString()))
                                {
                                    cartera.ActulizarEstados(DtCartera.Rows[i]["Id_Cartera"].ToString(), "Sin pagos credito");

                                }
                            }
                        }
                    }
                }                
            }
            Validarestados = false;
            CargarCartera();
        }
        private void BtHistorialPago_Click(object sender, EventArgs e)
        {
            HistorialPagos Hp = new HistorialPagos();
            Hp.FormClosed += Pagos_FormClose;
            Hp.ShowDialog();
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            CargarCartera();
        }
        void autocompletar()
        {
            AutoCompleteStringCollection lista = new AutoCompleteStringCollection();
            DtCliente = cliente.cargarClientes();
            for (int i = 0; i < DtCliente.Rows.Count; i++)
            {
                lista.Add(DtCliente.Rows[i]["Cedula"].ToString());
            }
            Txtcedula.AutoCompleteCustomSource = lista;
        }
        private void dataGridView1_CellMouseEnter_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex >= 0 & e.RowIndex >= 0)
            {
                DataGridViewCell cell = this.dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
                cell.ToolTipText = "Doble clic para Registrar pago";
            }

        }
        private void button3_Click(object sender, EventArgs e)
        {
            Txtcedula.Clear();
            CargarCartera();
        }

        private void button2_Click(object sender, EventArgs e)
        {            
            reportesPDF.Cartera(DtReporte, labelTotal.Text, labelRecaudo.Text, labelDeuda.Text);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            int n = e.RowIndex;
            try
            {
                if (dgv.Columns[e.ColumnIndex].Name == "Pago")  //Si es la columna a evaluar
                {
                    
                    if (n != -1)
                    {
                        if (e.Value.ToString().Contains("Pagado"))   //Si el valor de la celda contiene la palabra hora
                        {
                            e.CellStyle.ForeColor = Color.Green;
                        }
                    }
                }
            }
            catch
            {

            }            
        }
    }
}
