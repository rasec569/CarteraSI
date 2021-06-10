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
        string productoId = "";
        string productoNom = "";
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
            dataGridView1.Columns["Contrato"].Visible = false;
            dataGridView1.Columns["Fk_Id_Proyecto"].Visible = false;
            dataGridView1.Columns["Fk_Id_Tipo_Producto"].Visible = false;
            formatoGrid1();
        }
        private void Detalle_Load(object sender, EventArgs e)
        {

        }
        private void formatoGrid1()
        {
            dataGridView1.Columns[4].DefaultCellStyle.Format = "n0";
            dataGridView1.Columns[5].DefaultCellStyle.Format = "n0";
            dataGridView1.Columns[6].DefaultCellStyle.Format = "n0";
            dataGridView1.Columns[1].Width = 65;
            dataGridView1.Columns[2].Width = 65;
            dataGridView1.Columns[3].Width = 70;
            dataGridView1.Columns[4].Width = 65;
            dataGridView1.Columns[5].Width = 65;
            dataGridView1.Columns[6].Width = 65;
            dataGridView1.Columns[7].Width = 65;
            dataGridView1.Columns[9].Width = 160;
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            DataGridViewButtonColumn BtPago = new DataGridViewButtonColumn();
            BtPago.Name = "Pagar";
            BtPago.HeaderText = "";
            BtPago.UseColumnTextForButtonValue = true;
            DataGridViewButtonColumn BtHistorial = new DataGridViewButtonColumn();
            BtHistorial.Name = "Historial";
            BtHistorial.HeaderText = "";
            BtHistorial.UseColumnTextForButtonValue = true;
            dataGridView1.Columns.Add(BtPago);
            dataGridView1.Columns.Add(BtHistorial);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
           
            if (e.ColumnIndex>=0 && this.dataGridView1.Columns[e.ColumnIndex].Name=="Pagar" && e.RowIndex >= 0 )
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);
                DataGridViewButtonCell celboton = this.dataGridView1.Rows[e.RowIndex].Cells["Pagar"] as DataGridViewButtonCell;                
                Icon PagarIcon = new Icon(Environment.CurrentDirectory + @"\\img\Pagos.ico");
                e.Graphics.DrawIcon(PagarIcon, e.CellBounds.Left + 3, e.CellBounds.Top + 3);
                this.dataGridView1.Rows[e.RowIndex].Height = PagarIcon.Height + 8;
                this.dataGridView1.Columns[e.ColumnIndex].Width = PagarIcon.Width + 8;
                e.Handled = true;
            }
            else if (e.ColumnIndex >= 0 && this.dataGridView1.Columns[e.ColumnIndex].Name == "Historial" && e.RowIndex >= 0 )
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);
                DataGridViewButtonCell celboton = this.dataGridView1.Rows[e.RowIndex].Cells["Historial"] as DataGridViewButtonCell;
                Icon HistorialIcon = new Icon(Environment.CurrentDirectory + @"\\img\HistorialPagos.ico");
                e.Graphics.DrawIcon(HistorialIcon, e.CellBounds.Left + 3, e.CellBounds.Top + 3);
                this.dataGridView1.Rows[e.RowIndex].Height = HistorialIcon.Height + 8;
                this.dataGridView1.Columns[e.ColumnIndex].Width = HistorialIcon.Width + 8;
                e.Handled = true;
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int x = dataGridView1.Rows.Count;
                int n = e.RowIndex;
                if (n < x-1)
                {
                    productoId = dataGridView1.Rows[n].Cells["Id_Producto"].Value.ToString();
                    productoNom = dataGridView1.Rows[n].Cells["Producto"].Value.ToString();
                    string proyecto = dataGridView1.Rows[n].Cells["Proyecto"].Value.ToString();
                    string neto = dataGridView1.Rows[n].Cells["Valor Neto"].Value.ToString();
                    string valor = dataGridView1.Rows[n].Cells["Valor Final"].Value.ToString();
                    //I suposed you want to handle the event for column at index 1
                    if (e.ColumnIndex == 0)
                    {
                        
                        RegistrarPago Rp = new RegistrarPago(int.Parse(Txtcedula.Text), txtNombre.Text, clienteId.ToString(), carteraId.ToString(), productoId, productoNom);
                        Rp.FormClosed += Pagos_FormClose;
                        Rp.ShowDialog();                        
                    }
                    else if (e.ColumnIndex == 1)
                    {
                        HistorialPagos Hp = new HistorialPagos(Txtcedula.Text, txtNombre.Text, clienteId.ToString(), carteraId.ToString(), productoId, productoNom, proyecto,neto, valor);
                        this.Hide();
                        Hp.MdiParent=this.MdiParent;
                        Hp.ShowDialog();
                    }
                }
                else
                {
                    MessageBox.Show("Campo no valido", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch
            {
                MessageBox.Show("Valor no admitido");
            }
        }
        private void Pagos_FormClose(object sender, FormClosedEventArgs e)
        {
            Form frm = sender as Form;
            if (frm.DialogResult == DialogResult.OK)
            {
                CargarProducto();
            }

        }

        private void Detalle_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
