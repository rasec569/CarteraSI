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
        public Carteras()
        {
            InitializeComponent();
        }
        private void Carteras_Load(object sender, EventArgs e)
        {
            CargarProducto();
        }

        private void CargarProducto()
        {
            dataGridView1.DataSource = cartera.ListarCartera();
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboEstados_SelectedValueChanged(object sender, EventArgs e)
        {
            string Estados = comboEstados.Items[comboEstados.SelectedIndex].ToString();
            if (comboEstados.Items[comboEstados.SelectedIndex].ToString() == "Menos de 30 dias")
            {
                DataTable Dt_Estado= Conexion.consulta("SELECT Id_Cliente, Nombre, Apellido, Estado_cartera, Total_Neto_Recaudado, count(Id_Producto) as productos, Total_Mora, Total_Cartera FROM Cartera INNER JOIN Cliente on Fk_Id_Cartera = Id_Cartera INNER JOIN Producto on Fk_Id_CarteraP = Id_Cartera WHERE Estado_cartera = " + Estados + " GROUP by Id_Cliente ; ");

                llenarGrid(Dt_Estado);
                    //Bloquear_Financiado();
            }
            else if (comboEstados.Items[comboEstados.SelectedIndex].ToString() == "Financiado")
            {
                //Habilitar_Financiado();
            }
        }
        private void llenarGrid(DataTable estados)
        {
            dataGridView1.DataSource = estados;
            dataGridView1.Columns["Id_Cliente"].Visible = false;
            dataGridView1.Columns[1].HeaderText = "Nombre";
            dataGridView1.Columns[2].HeaderText = "Apellido";
            dataGridView1.Columns[3].HeaderText = "Estado Mora";
            dataGridView1.Columns[4].HeaderText = "Recaudado";
            dataGridView1.Columns[5].HeaderText = "Productos";
            dataGridView1.Columns[6].HeaderText = "Valor Mora";
            dataGridView1.Columns[7].HeaderText = "Total Cartera";
        }
    }
}
