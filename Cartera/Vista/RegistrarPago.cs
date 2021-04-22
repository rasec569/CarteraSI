using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
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
        int valortotal = 0;
        int carteraId = 0;
        int pagoId = 0;
        CProducto producto = new CProducto();
        CCartera cartera = new CCartera();
        CPago pago = new CPago();
        CCliente cliente = new CCliente();
        int clienteId = 0;
        DataTable DtNombres = new DataTable();
        bool modificar = false;
        public RegistrarPago()
        {
            InitializeComponent();
            dateFechaPago.Format = DateTimePickerFormat.Custom;
            dateFechaPago.CustomFormat = "yyyy-MM-dd";
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
        public RegistrarPago(string cedula,string nombre, string id_cartera,int id_producto, string producto, int id_pagos, string pago,string tipopago, string referencia, string concepto, string entidad, string fecha, string valor, string descuento, string valordescuento)
        {
            InitializeComponent();
            modificar = true;
            Txtcedula.Text = cedula;
            txtNombre.Text = nombre;
            productoid = id_producto;
            carteraId = int.Parse(id_cartera);
            txtProducto.Text = producto;
            pagoId = id_pagos;
            txtCuota.Text = pago;
            comboTipoPago.Text = tipopago;
            txtReferencia.Text = referencia;
            txtConcepto.Text = concepto;
            TxtEntidad.Text = entidad;
            dateFechaPago.Text = fecha;
            txtValor.Text =  String.Format("{0:N0}", int.Parse(valor));
            if (!string.IsNullOrEmpty(comboDescuento.Text))
            {
                comboDescuento.Text = descuento;
            }
            comboDescuento.Text = "Seleccionar";
            comboDescuento.Enabled = false;
            if (!string.IsNullOrEmpty(txtValorDescuento.Text))
            {
                txtValorDescuento.Text = String.Format("{0:N0}", int.Parse(valordescuento));
                txtValorDescuento.Enabled = false;
            }            
            panelProductos.Visible = false;
            Btbuscar.Enabled = false;
        }

        private void RegistrarPago_Load(object sender, EventArgs e)
        {
            autocompletar();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
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
                    valortotal = int.Parse(dataGridView1.Rows[n].Cells["Valor Total"].Value.ToString());                   
                    txtProducto.Text = dataGridView1.Rows[n].Cells["Producto"].Value.ToString();

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
            dataGridView1.Columns["Observaciones"].Visible = false;
            dataGridView1.Columns["Tipo Producto"].Visible=false;
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
            if (txtReferencia.Text == "")
            {
                ok = false;
                errorProvider1.SetError(txtReferencia, "Digite Referencia de Pago");
            }            
            if (comboTipoPago.Text == "Seleccionar")
            {
                ok = false;
                errorProvider1.SetError(comboTipoPago, "Seleccione Tipo de Pago");
            }
            
            if (comboDescuento.Text != "Seleccionar")
            {
                if (txtValorDescuento.Text == "")
                {
                    ok = false;
                    errorProvider1.SetError(txtValorDescuento, "Digite Valor Descuento");
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
            carteraId= int.Parse(dtclientes.Rows[0]["Fk_Id_Cartera"].ToString());
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

        private void RegistrarPago_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void txtValor_Leave(object sender, EventArgs e)
        {
            try
            {
                
                if (!string.IsNullOrEmpty(txtValor.Text))
                {
                    int valor;
                    valor = int.Parse(txtValor.Text);
                    txtValor.Text = valor.ToString("N0", CultureInfo.CurrentCulture);
                }
            }
            catch
            {
                //MessageBox.Show("Valor no admitido");
                //errorProvider1.SetError(txtValor, "Error");
            }
        }

        private void BtRegistrarPago_Click(object sender, EventArgs e)
        {
            ValidarCampos();
            if (ValidarCampos() == true)
            {
                if (modificar == false)
                {
                    if (comboDescuento.Text == "Seleccionar")
                    {
                        pago.RegistrarPago(comboTipoPago.Text, txtCuota.Text, dateFechaPago.Text, txtConcepto.Text, TxtEntidad.Text, txtReferencia.Text, Convert.ToDouble(txtValor.Text).ToString(), "", "", productoid.ToString());
                    }
                    else
                    {
                        pago.RegistrarPago(comboTipoPago.Text, txtCuota.Text, dateFechaPago.Text, txtConcepto.Text, TxtEntidad.Text, txtReferencia.Text, Convert.ToDouble(txtValor.Text).ToString(), comboDescuento.Text, Convert.ToDouble(txtValorDescuento.Text).ToString(), productoid.ToString());
                        int nuevo = valortotal - int.Parse(Convert.ToDouble(txtValorDescuento.Text).ToString());
                        producto.actualizarValorProducto(productoid, nuevo);
                        cartera.ActulizarValorTotal(int.Parse(clienteId.ToString()), carteraId);
                    }
                }
                else
                {
                    string descuento = "";
                    if (comboDescuento.Text != "Seleccionar")
                    {
                        descuento = comboDescuento.Text;
                        pago.ActulizarPago(pagoId, comboTipoPago.Text, txtCuota.Text, dateFechaPago.Text, txtConcepto.Text, TxtEntidad.Text, txtReferencia.Text, Convert.ToDouble(txtValor.Text).ToString(), descuento, Convert.ToDouble(txtValorDescuento.Text).ToString());
                        modificar = false;
                    }
                    else
                    {
                        pago.ActulizarPago(pagoId, comboTipoPago.Text, txtCuota.Text, dateFechaPago.Text, txtConcepto.Text, TxtEntidad.Text, txtReferencia.Text, Convert.ToDouble(txtValor.Text).ToString(), descuento, Convert.ToDouble(txtValorDescuento.Text).ToString());
                        modificar = false;
                    }
                }
                cartera.ActulizarValorRecaudado(productoid, carteraId);
                cartera.ActulizarSaldo(carteraId);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void BtEliminar_Click(object sender, EventArgs e)
        {
            pago.EliminarPago(pagoId);
            cartera.ActulizarValorRecaudado(productoid, carteraId);
            cartera.ActulizarSaldo(carteraId);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void txtValorDescuento_Leave(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtValorDescuento.Text))
                {
                    int valor;
                    valor = int.Parse(txtValorDescuento.Text);
                    txtValorDescuento.Text = valor.ToString("N0", CultureInfo.CurrentCulture);
                }
            }
            catch
            {
            }   
        }
    }    
}
