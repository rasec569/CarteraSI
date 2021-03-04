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
    public partial class Productos : Form
    {
        CProducto producto = new CProducto();
        DataTable DtProductos = new DataTable();
        public Productos()
        {
            InitializeComponent();
        }

        private void Productos_Load(object sender, EventArgs e)
        {
            CargarProducto();
            autocompletar();
        }
        private void CargarProducto()
        {
            dataGridView1.DataSource = producto.cargarProductos();
            dataGridView1.Columns["Id_Producto"].Visible = false;
            dataGridView1.Columns["Fk_Id_Proyecto"].Visible = false;
            dataGridView1.Columns["Fk_Id_Tipo_Producto"].Visible = false;
            dataGridView1.Columns["Id_Financiacion"].Visible = false;
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

        private void BtBuscarProducto_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = "";
            dataGridView1.DataSource = producto.BuscarProductos(txtBuscarProducto.Text);
            dataGridView1.Columns["Id_Producto"].Visible = false;
            dataGridView1.Columns["Fk_Id_Proyecto"].Visible = false;
            dataGridView1.Columns["Fk_Id_Tipo_Producto"].Visible = false;
            dataGridView1.Columns["Id_Financiacion"].Visible = false;
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
        void autocompletar()
        {
            AutoCompleteStringCollection lista = new AutoCompleteStringCollection();
            DtProductos = producto.cargarProductos();
            for (int i = 0; i < DtProductos.Rows.Count; i++)
            {
                lista.Add(DtProductos.Rows[i]["Nombre_Producto"].ToString());
            }
            txtBuscarProducto.AutoCompleteCustomSource = lista;
        }
    }
}
