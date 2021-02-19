using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cartera.Vista
{
    public partial class Carteras : Form
    {
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
            dataGridView1.DataSource = Conexion.consulta("SELECT Nombre, Apellido, Estado_cartera, Total_Neto_Recaudado, Total_Mora, Total_Cartera FROM Cartera INNER JOIN Cliente on Fk_Id_Cartera = Id_Cartera;");
            dataGridView1.Columns[0].HeaderText = "Nombre";
            dataGridView1.Columns[1].HeaderText = "Apellido";
            dataGridView1.Columns[2].HeaderText = "Estado";
            dataGridView1.Columns[3].HeaderText = "Recaudado";
            dataGridView1.Columns[4].HeaderText = "Mora";
            dataGridView1.Columns[5].HeaderText = "Total Cartera";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RegistrarPago Rp = new RegistrarPago();
            Rp.Show();
        }
    }
}
