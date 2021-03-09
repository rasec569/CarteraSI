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
    public partial class RegistrarPago : Form
    {
        int productoid = 0;
        int carteraId = 0;
        CProducto producto = new CProducto();
        CCartera cartera = new CCartera();
        CPago pago = new CPago();
        CCliente cliente = new CCliente();
        int clienteId = 0;
        DataTable DtNombres = new DataTable();
        public RegistrarPago()
        {
            InitializeComponent();
            Txtcedula.Enabled = true;
            
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
            Txtcedula.AutoCompleteCustomSource = lista;
        }

        public RegistrarPago(int cedula,string nombre, string clienteid, string carteraid)
        {
            InitializeComponent();
            clienteId = int.Parse(clienteid);
            carteraId = int.Parse(carteraid);
            txtNombre.Text = nombre;
            Txtcedula.Text = cedula.ToString();
            CargarProducto();

        }

        private void RegistrarPago_Load(object sender, EventArgs e)
        {
            autocompletar();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ValidarCampos();
            if (ValidarCampos() == true)
            {
                if (comboDescuento.Text == "Seleccionar")
                {
                    pago.RegistrarPago(comboTipoPago.Text, txtCuota.Text, dateFechaPago.Text, txtReferencia.Text, txtValor.Text, "", "", productoid.ToString());
                }
                else
                {
                    pago.RegistrarPago(comboTipoPago.Text, txtCuota.Text, dateFechaPago.Text, txtReferencia.Text, txtValor.Text, comboDescuento.Text, txtValorDescuento.Text, productoid.ToString());
                }
                cartera.ActulizarValorRecaudado(productoid, carteraId);
                this.Close();
            }
            }
        

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int n = e.RowIndex;
                if (n != -1)
                {

                    panelProductos.Visible = false;
                    productoid = int.Parse(dataGridView1.Rows[n].Cells["Id_Producto"].Value.ToString());

                    txtProducto.Text = dataGridView1.Rows[n].Cells["Nombre_Producto"].Value.ToString();

                    DataTable Dtcuota = pago.ConsultarUltimaCuota(productoid);
                    string num_cuota = Dtcuota.Rows[0]["max(Numero_Cuota)"].ToString();
                    if (num_cuota == "")
                    {
                        txtCuota.Text = "1";
                    }
                    else {
                        txtCuota.Text =(1 + int.Parse(num_cuota)).ToString();
                    }
                }
            }
            catch
            {
                MessageBox.Show("Valor no admitido");
            }
        }

        private void CargarProducto()
        {
            dataGridView1.DataSource = producto.cargarProductosCliente(clienteId);
            dataGridView1.Columns["Id_Producto"].Visible = false;
            dataGridView1.Columns[1].HeaderText = "Producto";
            dataGridView1.Columns[2].HeaderText = "Contrato";
            dataGridView1.Columns[3].HeaderText = "Forma Pago";
            dataGridView1.Columns[4].HeaderText = "Valor Producto";
            dataGridView1.Columns[5].HeaderText = "Fecha Venta";
            dataGridView1.Columns["Observaciones"].Visible = false;
            dataGridView1.Columns[7].HeaderText = "Proyecto";
            dataGridView1.Columns["Nom_Tipo_Producto"].Visible=false;
            dataGridView1.Columns["Fk_Id_Proyecto"].Visible = false;
            dataGridView1.Columns["Fk_Id_Tipo_Producto"].Visible = false;
        }
        private bool ValidarCampos()
        {
            bool ok = true;
            if (txtValor.Text == "")
            {
                ok = false;
                errorProvider1.SetError(txtValor, "Digite Valor del Pago");
            }
            else
            {
                ok = true;
                errorProvider1.Clear();
            }
            if (txtReferencia.Text == "")
            {
                ok = false;
                errorProvider1.SetError(txtReferencia, "Digite Referencia de Pago");
            }
            else
            {
                ok = true;
                errorProvider1.Clear();
            }
            if (comboTipoPago.Text == "Seleccionar")
            {
                ok = false;
                errorProvider1.SetError(comboTipoPago, "Seleccione Tipo de Pago");
            }
            else
            {
                ok = true;
                errorProvider1.Clear();
            }

            if (comboDescuento.Text != "Seleccionar")
            {
                if (txtValorDescuento.Text == "")
                {
                    ok = false;
                    errorProvider1.SetError(txtValorDescuento, "Digite Valor Descuento");
                }
                else
                {
                    ok = true;
                    errorProvider1.Clear();
                }
            }
            return ok;
        }

        private void Txtcedula_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboDescuento_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboDescuento.Text!= "Seleccionar")
            {
                txtValorDescuento.Enabled = true;
            }
        }

        private void Btbuscar_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = "";            
            DataTable dtclientes = cliente.BuscarClientesCedula(Txtcedula.Text);
            clienteId =int.Parse(dtclientes.Rows[0]["Id_Cliente"].ToString());
            txtNombre.Text= dtclientes.Rows[0]["Nombre"].ToString();
            CargarProducto();
           // string clienteid = "";
            //HistorialPagos Hp = new HistorialPagos();
            //Hp.


        }

        private void dataGridView1_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex >= 0 & e.RowIndex >= 0)
            {
                DataGridViewCell cell = this.dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
                cell.ToolTipText = "Doble clic para realziar pago";
            }
        }
    }    
}
