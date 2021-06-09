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
    public partial class Detalle : Form
    {
        int clienteId = 0;
        int carteraId = 0;
        CProducto producto = new CProducto();
        public Detalle()
        {
            InitializeComponent();
        }
        public Detalle(int cedula, string nombre, string clienteid, string carteraid)
        {
            InitializeComponent();
            clienteId = int.Parse(clienteid);
            carteraId = int.Parse(carteraid);
            txtNombre.Text = nombre;
            Txtcedula.Text = cedula.ToString();
            CargarProducto();
        }
        private void CargarProducto()
        {
            dataGridView1.DataSource = producto.cargarProductosCliente(clienteId);
            dataGridView1.Columns["Id_Producto"].Visible = false;
            dataGridView1.Columns["Observaciones"].Visible = false;
            dataGridView1.Columns["Tipo Producto"].Visible = false;
            dataGridView1.Columns["Fk_Id_Proyecto"].Visible = false;
            dataGridView1.Columns["Fk_Id_Tipo_Producto"].Visible = false;
            formatoGrid1();
        }
        private void Detalle_Load(object sender, EventArgs e)
        {

        }
        private void formatoGrid1()
        {
            dataGridView1.Columns[5].DefaultCellStyle.Format = "n0";
            dataGridView1.Columns[4].DefaultCellStyle.Format = "n0";
            dataGridView1.Columns[1].Width = 65;
            dataGridView1.Columns[2].Width = 65;
            dataGridView1.Columns[3].Width = 70;
            dataGridView1.Columns[4].Width = 65;
            dataGridView1.Columns[5].Width = 65;
            dataGridView1.Columns[6].Width = 65;
            dataGridView1.Columns[8].Width = 160;

            DataGridViewButtonColumn BtPago = new DataGridViewButtonColumn();
            //BtPago.Name = "Pago";
            BtPago.Name = "Pagar";
            BtPago.UseColumnTextForButtonValue = true;
            DataGridViewButtonColumn BtHistorial = new DataGridViewButtonColumn();
            //BtHistorial.Name = "Historial";
            BtHistorial.Name = "Historial";
            BtHistorial.UseColumnTextForButtonValue = true;
            dataGridView1.Columns.Add(BtPago);
            dataGridView1.Columns.Add(BtHistorial);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex>=0&& this.dataGridView1.Columns[e.ColumnIndex].Name=="Pagar"&& e.RowIndex >= 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);
                DataGridViewButtonCell celboton = this.dataGridView1.Rows[e.RowIndex].Cells["Pagar"] as DataGridViewButtonCell;                
                Icon imgpagar = new Icon(Environment.CurrentDirectory + @"\\img\HistorialPagos.png");
                e.Graphics.DrawIcon(imgpagar, e.CellBounds.Left + 3, e.CellBounds.Top + 3);
                this.dataGridView1.Rows[e.RowIndex].Height = imgpagar.Height + 8;
                this.dataGridView1.Columns[e.ColumnIndex].Width = imgpagar.Width + 8;
                e.Handled = true;
            }
        }
    }
}
