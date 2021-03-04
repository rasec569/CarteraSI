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
        DataTable DtCartera = new DataTable();
        public Carteras()
        {
            InitializeComponent();
        }
        private void Carteras_Load(object sender, EventArgs e)
        {
            CargarCartera();
        }

        private void CargarCartera()
        {
            DtCartera = cartera.ListarCartera();
            dataGridView1.DataSource = DtCartera;
            dataGridView1.Columns["Id_Cliente"].Visible = false;
            dataGridView1.Columns[1].HeaderText = "Nombre";
            dataGridView1.Columns[2].HeaderText = "Apellido";
            dataGridView1.Columns[3].HeaderText = "Estado Mora";
            dataGridView1.Columns[4].HeaderText = "Recaudado";
            dataGridView1.Columns[5].HeaderText = "Productos";
            dataGridView1.Columns[6].HeaderText = "Valor Mora";
            dataGridView1.Columns[7].HeaderText = "Total Cartera";
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
    }
}
