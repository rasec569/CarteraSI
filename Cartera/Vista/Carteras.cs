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

namespace Cartera.Vista
{
    public partial class Carteras : Form 
    {
        CCartera cartera = new CCartera();
        CCliente cliente = new CCliente();
        CProducto producto = new CProducto();
        DataTable DtCartera = new DataTable();
        DataTable DtCliente = new DataTable();
        bool Validarestados = true;
        public Carteras()
        {
            InitializeComponent();
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
                dataGridView1.DataSource = DtCartera;
            }
            else
            {
                DtCartera = cartera.CarteraCliente(Txtcedula.Text);
                dataGridView1.DataSource = DtCartera;
            }

            dataGridView1.Columns["Id_Cliente"].Visible = false;
            dataGridView1.Columns[1].HeaderText = "Cedula";
            dataGridView1.Columns[2].HeaderText = "Nombre";
            dataGridView1.Columns[3].HeaderText = "Apellido";
            dataGridView1.Columns[4].HeaderText = "Estado Mora";
            dataGridView1.Columns[5].HeaderText = "Recaudado";
            dataGridView1.Columns[5].DefaultCellStyle.Format = "n1";
            //dataGridView1.Columns["Id_Producto"].Visible = false;
            dataGridView1.Columns[6].HeaderText = "Producto";
            dataGridView1.Columns[7].HeaderText = "Saldo";
            dataGridView1.Columns[7].DefaultCellStyle.Format = "n1";
            dataGridView1.Columns[8].HeaderText = "Total Cartera";
            dataGridView1.Columns[8].DefaultCellStyle.Format = "n1";
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
                DtCartera.DefaultView.RowFilter = $"Estado_cartera LIKE 'Menos de 30 días'";
            }
            else if (Estados == "De 31 a 60 días")
            {
                DtCartera.DefaultView.RowFilter = $"Estado_cartera LIKE 'De 31 a 60 días'";
            }
            else if (Estados == "De 61 a 90 días")
            {
                DtCartera.DefaultView.RowFilter = $"Estado_cartera LIKE 'De 61 a 90 días'";
            }
            else if (Estados == "De 91 a 180 días")
            {
                DtCartera.DefaultView.RowFilter = $"Estado_cartera LIKE 'De 91 a 180 días'";
            }
            else if (Estados == "Mas de 360 días")
            {
                DtCartera.DefaultView.RowFilter = $"Estado_cartera LIKE 'Mas de 360 días'";
            }
            else
            {
                DtCartera.DefaultView.RowFilter = $"Estado_cartera LIKE 'Nueva'";
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
                    nombre = dataGridView1.Rows[n].Cells["Nombre"].Value.ToString();
                    apellido = dataGridView1.Rows[n].Cells["Apellido"].Value.ToString();
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
                DataTable dtproducto = producto.cargarProductosCliente(int.Parse(datoDT));
                for (int j = 0; j < dtproducto.Rows.Count; j++)
                {
                    string datoDT2 = dtproducto.Rows[j]["Id_Producto"].ToString();
                    DataTable dtfechas = cartera.BuscarFechaspagos(int.Parse(datoDT2));
                    if (dtproducto.Rows[j]["Forma_Pago"].ToString()== "Contado")
                    {
                        for (int h = 0; h < dtfechas.Rows.Count; h++)
                        {
                            if (dtfechas.Rows.Count > 0 && !string.IsNullOrEmpty(dtfechas.Rows[h]["Fecha_Pago"].ToString()))
                            {
                                cartera.ActulizarEstados(DtCartera.Rows[i]["Id_Cartera"].ToString(), "Al dia Contado");
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
                                string fecha2 = dtfechas.Rows[h]["Fecha_Recaudo"].ToString();
                                DateTime date_2 = DateTime.ParseExact(fecha2, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                                DateTime actual = DateTime.ParseExact(DateTime.Now.ToShortDateString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                                var days = int.Parse(((actual - date_2).Days).ToString());
                                var cuotas= int.Parse(dtfechas.Rows[h]["Cuotas_Pagadas"].ToString());
                                int DiasMora = days - (cuotas * 30);
                                string estado="";
                                switch (DiasMora)
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
                                cartera.ActulizarEstados(DtCartera.Rows[i]["Id_Cartera"].ToString(), "Sin pagos");
                                
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

        }
    }
}
