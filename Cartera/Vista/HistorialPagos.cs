using Cartera.Controlador;
using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cartera.Vista
{
    public partial class HistorialPagos : Form
    {
        CCliente cliente = new CCliente();
        bool error = false;
        CPago pago = new CPago();
        CProducto producto = new CProducto();
        string productoId = "";
        string clienteid = "";
        string Nom_Producto, Nom_Proyecto;
        public HistorialPagos()
        {
            InitializeComponent();
        }
        public HistorialPagos(string cedula, string nombre, string id_cliente)
        {
            InitializeComponent();
        }
        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void BtImprimir_Click(object sender, EventArgs e)
        {
            try
            {
                printPreviewDialog1.Show();
            }
            catch
            {
                printPreviewDialog1.Close();
            }
            //var pagos= pago.ListarPagosCliente(productoId);
            //var rpth = new ReportClass();
            //rpth.SetDataSource(pagos);
        }
        
            
        void autocompletar()
        {
            DataTable DtCliente = new DataTable();
            AutoCompleteStringCollection lista = new AutoCompleteStringCollection();
            DtCliente = cliente.cargarClientes();
            for (int i = 0; i < DtCliente.Rows.Count; i++)
            {
                lista.Add(DtCliente.Rows[i]["Cedula"].ToString());
            }
            txtCedula.AutoCompleteCustomSource = lista;
        }


        private void HistorialPagos_Load(object sender, EventArgs e)
        {
            autocompletar();
        }



        private void txtCedula_Enter(object sender, EventArgs e)
        {

        }

        private void BtBuscar_Click(object sender, EventArgs e)
        {
             try
             {
                ValidarCampos();
                if ((error != true) && (ValidarCampos() == true))
                {
                    cliente.BuscarClientesCedula(txtCedula.Text);
                    DataTable DtUsuario = cliente.BuscarClientesCedula(txtCedula.Text);
                    clienteid = DtUsuario.Rows[0]["Id_Cliente"].ToString();
                    txtCedula.Text = DtUsuario.Rows[0]["Cedula"].ToString();
                    txtNombre.Text = DtUsuario.Rows[0]["Nombre"].ToString() + " " + DtUsuario.Rows[0]["Apellido"].ToString();
                    txtFecha.Text = DateTime.Now.ToShortDateString();
                    ListarPagosCliente();
                    btLimpiar.Enabled = true;
                    BtImprimir.Enabled = true;
                }
             }
            catch
             {
                MessageBox.Show ( "No existe cliente");
                txtCedula.Clear();
             }           
        }
        private bool ValidarCampos()
        {
            bool ok = true;
            if (txtCedula.Text == "")
            {
                ok = false;
                errorProvider1.SetError(txtCedula, "Digite cedula");
            }    
            return ok;
        }
        private void ListarPagosCliente()
        {             
            dataGridView1.DataSource = producto.cargarProductosCliente(int.Parse(clienteid));
            dataGridView1.Columns["Id_Producto"].Visible = false;
            dataGridView1.Columns[1].HeaderText = "Producto";
            dataGridView1.Columns[2].HeaderText = "Contrato";
            dataGridView1.Columns[3].HeaderText = "Forma Pago";
            dataGridView1.Columns[4].HeaderText = "Valor Producto";
            dataGridView1.Columns[5].HeaderText = "Fecha Venta";
            dataGridView1.Columns["Observaciones"].Visible = false;
            dataGridView1.Columns[7].HeaderText = "Proyecto";
            dataGridView1.Columns[8].HeaderText = "Tipo Producto";
            dataGridView1.Columns["Fk_Id_Proyecto"].Visible = false;
            dataGridView1.Columns["Fk_Id_Tipo_Producto"].Visible = false;
            // pago.ListarPagosCliente();
        }

        private void txtCedula_TextChanged(object sender, EventArgs e)
        {
            foreach (char caracter in txtCedula.Text)
            {
                if (char.IsLetter(caracter))
                {
                    error = true;
                    errorProvider1.SetError(txtCedula, "No se admiten letras");
                }
                else
                {
                    error = false;
                    errorProvider1.Clear();
                }
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int n = e.RowIndex;
            if (n != -1)
            {
                // Porcentaje, Numero_Cuota, Fecha_Pago, Referencia_Pago, Valor_Pagado, Descuento, Valor_Descuento, Fk_Id_Producto
                productoId = dataGridView1.Rows[n].Cells["Id_Producto"].Value.ToString();
                DataTable dtpagos= pago.ListarPagosCliente(productoId);
                dataGridView2.DataSource = dtpagos;
                Nom_Producto= dataGridView1.Rows[n].Cells["Nombre_Producto"].Value.ToString();
                Nom_Proyecto = dataGridView1.Rows[n].Cells["Proyecto_Nombre"].Value.ToString();
                dataGridView2.Columns[0].HeaderText = "N° Cuota";
                dataGridView2.Columns[1].HeaderText = "Valor";
                dataGridView2.Columns[2].HeaderText = "Fecha";
                dataGridView2.Columns[3].HeaderText = "Referencia";                
                dataGridView2.Columns[4].HeaderText = "Descuento";
                dataGridView2.Columns[5].HeaderText = "Valor Descuento";
            }
            dataGridView2.Visible = true;
            dataGridView1.Visible = false;
        }

        private void dataGridView1_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex >= 0 & e.RowIndex >= 0)
            {
                DataGridViewCell cell = this.dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
                cell.ToolTipText = "Doble clic para ver pagos";
            }
        }

        private void btLimpiar_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = "";
            dataGridView2.DataSource = "";
            txtCedula.Clear();
            txtNombre.Clear();
            txtFecha.Clear();
            clienteid = "";
        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            string imagen = @"C:\Users\RASEC\Documents\Cartera\CarteraSI\Cartera\img\logo 2 San Isidro.png"; 
            Font Tipotex = new Font("Arial", 12, FontStyle.Bold);
            Font Tipotex1 = new Font("Arial", 12, FontStyle.Regular);
            Font Tipotex2 = new Font("Arial", 11, FontStyle.Regular);
            Image img = Image.FromFile(imagen);
            e.Graphics.DrawImage(img, new Rectangle(30, 20, 50, 50));
            e.Graphics.DrawString("HISTORIAL DE PAGOS URBANIZADORA Y CONSTRUCTORA SAN ISIDRO", Tipotex, Brushes.Black, 100, 30);
            e.Graphics.DrawString("Docuemento N°:", Tipotex1, Brushes.Black, 40, 70);
            e.Graphics.DrawString(txtCedula.Text, Tipotex1, Brushes.Black, 170, 70);
            e.Graphics.DrawString("Nombre:", Tipotex1, Brushes.Black, 280, 70);
            e.Graphics.DrawString(txtNombre.Text, Tipotex1, Brushes.Black, 350, 70);
            e.Graphics.DrawString("Fecha", Tipotex1, Brushes.Black, 660, 70);
            e.Graphics.DrawString(txtFecha.Text, Tipotex1, Brushes.Black, 710, 70);
            e.Graphics.DrawString("Producto:", Tipotex1, Brushes.Black, 40, 100);
            e.Graphics.DrawString(Nom_Producto, Tipotex1, Brushes.Black, 140, 100);
            e.Graphics.DrawString("Proyecto:", Tipotex1, Brushes.Black, 350, 100);
            e.Graphics.DrawString(Nom_Proyecto, Tipotex1, Brushes.Black, 450, 100);
            int left = e.MarginBounds.Left, top = e.MarginBounds.Top+40;
            foreach (DataGridViewColumn col in dataGridView2.Columns)
            {
                e.Graphics.DrawString(col.HeaderText, Tipotex2, Brushes.Black, left, top);
                left += col.Width;
                if (col.Index < dataGridView2.ColumnCount - 1)
                    e.Graphics.DrawLine(Pens.Gray, left - 5, top, left - 5, top + 43 + (dataGridView2.RowCount - 1) * 35);
            }
            left = e.MarginBounds.Left;
            e.Graphics.FillRectangle(Brushes.Black, left,top+40,e.MarginBounds.Right-left, 3);
            top += 43;
            foreach(DataGridViewRow row in dataGridView2.Rows)
            {
                if (row.Index == dataGridView2.RowCount - 1) break;
                left = e.MarginBounds.Left;
                foreach (DataGridViewCell cell in row.Cells)
                {
                    e.Graphics.DrawString(Convert.ToString(cell.Value), Tipotex2, Brushes.Black, left, top + 4);
                    left += cell.OwningColumn.Width;
                }
                top += 35;
                e.Graphics.DrawLine(Pens.Gray, e.MarginBounds.Left, top, e.MarginBounds.Right, top);
                

            }
            e.Graphics.DrawString("El reporte se expide a solicitud del Cliente.", Tipotex1, Brushes.Black, 50, top+30);

            //Bitmap GridBitmap = new Bitmap(this.dataGridView2.Width, this.dataGridView2.Height);
            //dataGridView2.DrawToBitmap(GridBitmap, new Rectangle(0,0, this.dataGridView2.Width, this.dataGridView2.Height));
            //e.Graphics.DrawImage(GridBitmap,50,100);
        }
    } 
}
