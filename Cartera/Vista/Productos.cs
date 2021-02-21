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
    public partial class Productos : Form
    {
        public Productos()
        {
            InitializeComponent();
        }

        private void Productos_Load(object sender, EventArgs e)
        {
            CargarProducto();
        }
        private void CargarProducto()
        {
            DataTable Dt_Productos = Conexion.consulta("SELECT Id_Producto, Nombre_Producto, Numero_contrato, Forma_pago, Valor_Total, Fecha_Venta, Valor_Entrada, Proyecto_Nombre, Nom_Tipo_Producto, Valor_Sin_interes, Cuotas_Sin_interes, Valor_Cuota_Sin_interes, Valor_Con_Interes, Cuotas_Con_Interes, Valor_Cuota_Con_Interes, Valor_Interes, Fecha_Recaudo, Observaciones, Fk_Id_Proyecto, Fk_Id_Tipo_Producto FROM Producto INNER join Proyecto on Id_Proyecto = Fk_Id_Proyecto INNER join Tipo_Producto on Id_Tipo_Producto = Fk_Id_Tipo_Producto");
            dataGridView1.DataSource = Dt_Productos;
            dataGridView1.Columns["Id_Producto"].Visible = false;
            dataGridView1.Columns["Fk_Id_Proyecto"].Visible = false;
            dataGridView1.Columns["Fk_Id_Tipo_Producto"].Visible = false;
            dataGridView1.Columns[1].HeaderText = "Producto";
            dataGridView1.Columns[2].HeaderText = "Contrato";
            dataGridView1.Columns[3].HeaderText = "Forma Pago";
            dataGridView1.Columns[4].HeaderText = "Valor Neto";
            dataGridView1.Columns[5].HeaderText = "Fecha Venta";
            dataGridView1.Columns[6].HeaderText = "Valor Entrada";
            dataGridView1.Columns["Valor_Entrada"].Visible = false;
            dataGridView1.Columns[7].HeaderText = "Proyecto";
            dataGridView1.Columns[8].HeaderText = "Tipo Producto";
            dataGridView1.Columns[9].HeaderText = "Valor sin Interes";
            dataGridView1.Columns["Valor_Sin_interes"].Visible = false;
            dataGridView1.Columns[10].HeaderText = "Cuotas sin Interes";
            dataGridView1.Columns["Cuotas_Sin_interes"].Visible = false;
            dataGridView1.Columns[11].HeaderText = "Valor Cuota Sin interes";
            dataGridView1.Columns["Valor_Cuota_Sin_interes"].Visible = false;
            dataGridView1.Columns[12].HeaderText = "Valor con Interes";
            dataGridView1.Columns["Valor_Con_Interes"].Visible = false;
            dataGridView1.Columns[13].HeaderText = "Cuotas con Interes";
            dataGridView1.Columns["Cuotas_Con_Interes"].Visible = false;
            dataGridView1.Columns[14].HeaderText = "Valor Cuota Con Interes";
            dataGridView1.Columns["Valor_Cuota_Con_Interes"].Visible = false;
            dataGridView1.Columns[15].HeaderText = "Porcentaje Interes";
            dataGridView1.Columns["Valor_Interes"].Visible = false;
            dataGridView1.Columns[16].HeaderText = "Fecha Recaudo";
            dataGridView1.Columns["Fecha_Recaudo"].Visible = false;

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
