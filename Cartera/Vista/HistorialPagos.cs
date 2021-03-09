using Cartera.Controlador;
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
    public partial class HistorialPagos : Form
    {
        CCliente cliente = new CCliente();
        bool error = false;
        CPago pago = new CPago();
        CProducto producto = new CProducto();
        string clienteid = "";
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
                dataGridView2.DataSource= pago.ListarPagosCliente(dataGridView1.Rows[n].Cells["Id_Producto"].Value.ToString());
                dataGridView2.Columns["Id_Pagos"].Visible = false;
                dataGridView2.Columns[1].HeaderText = "Tipo Pago";
                dataGridView2.Columns[2].HeaderText = "Numero Cuota";
                dataGridView2.Columns[3].HeaderText = "Fecha Pago";
                dataGridView2.Columns[4].HeaderText = "Referencia de pago";
                dataGridView2.Columns[5].HeaderText = "Valor Pagado";
                dataGridView2.Columns[6].HeaderText = "Descuento";
                dataGridView2.Columns[7].HeaderText = "Valor Descuento";
                dataGridView2.Columns["Fk_Id_Producto"].Visible = false;
                
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
    } 
}
