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
    public partial class Carteras : Form
    {
        CCartera cartera = new CCartera();
        CCliente cliente = new CCliente();
        DataTable DtCartera = new DataTable();
        DataTable DtCliente = new DataTable();
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
            DtCartera = cartera.ListarCartera();            
            dataGridView1.DataSource = DtCartera;
            dataGridView1.Columns["Id_Cliente"].Visible = false;
            dataGridView1.Columns[1].HeaderText = "Cedula";
            dataGridView1.Columns[2].HeaderText = "Nombre";
            dataGridView1.Columns[3].HeaderText = "Apellido";
            dataGridView1.Columns[4].HeaderText = "Estado Mora";
            dataGridView1.Columns[5].HeaderText = "Recaudado";
            dataGridView1.Columns[6].HeaderText = "Productos";
            dataGridView1.Columns[7].HeaderText = "Valor Mora";
            dataGridView1.Columns[8].HeaderText = "Total Cartera";
            dataGridView1.Columns["Id_Cartera"].Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RegistrarPago Rp = new RegistrarPago();
            Rp.Show();
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
            else if (Estados  == "De 91 a 180 días")
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

        private void comboEstados_SelectedIndexChanged(object sender, EventArgs e)
        {

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
                    //DataTable cartera = (DataTable)(dataGridView1.DataSource);
                    clienteid = dataGridView1.Rows[n].Cells["Id_Cliente"].Value.ToString();
                    cedula = int.Parse(dataGridView1.Rows[n].Cells["Cedula"].Value.ToString());
                    nombre = dataGridView1.Rows[n].Cells["Nombre"].Value.ToString();
                    apellido = dataGridView1.Rows[n].Cells["Apellido"].Value.ToString();
                    carteraid = dataGridView1.Rows[n].Cells["Id_Cartera"].Value.ToString();
                    RegistrarPago Rp = new RegistrarPago( cedula, nombre+" "+apellido, clienteid, carteraid);
                    Rp.Show();
                    //Principal principal = new Principal();
                    //Clientes clientes = new Clientes(cedula);
                    //clientes.MdiParent = this.MdiParent;
                    //clientes.Show();
                    //principal.AbrirCliente();

                }
                // this.Close();
            }
            catch
            {
                MessageBox.Show("Valor no admitido");
            }
        }

        

        private void BtHistorialPago_Click(object sender, EventArgs e)
        {
            HistorialPagos Hp = new HistorialPagos();
            Hp.Show();
        }

      
        //private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        //{
        //    if ((e.ColumnIndex == this.dataGridView1.Columns["Rating"].Index) && e.Value != null)
        //    {
        //        DataGridViewCell cell = this.dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
        //        cell.ToolTipText = "Doble clic para realizar pago";
        //    }
        //}

        private void button1_Click_1(object sender, EventArgs e)
        {
            

        }
        void autocompletar()
        {
            AutoCompleteStringCollection lista = new AutoCompleteStringCollection();
            DtCliente = cliente.cargarClientes();
            for (int i = 0; i < DtCliente.Rows.Count; i++)
            {
                lista.Add(DtCliente.Rows[i]["Nombre"].ToString());
            }
            Txtnombre.AutoCompleteCustomSource = lista;
        }

        private void dataGridView1_CellMouseEnter_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex >= 0 & e.RowIndex >= 0)
            {
                DataGridViewCell cell = this.dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
                cell.ToolTipText = "Doble clic para Registrar pago";

            }

        }
    }
}
