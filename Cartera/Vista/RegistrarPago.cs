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
        int valdescuento = 0;
        bool error = false;
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

        public RegistrarPago(int cedula, string nombre, string clienteid, string carteraid, string producto, string nomProducto)
        {
            InitializeComponent();
            clienteId = int.Parse(clienteid);
            carteraId = int.Parse(carteraid);
            productoid = int.Parse(producto);
            txtNombre.Text = nombre;
            Txtcedula.Text = cedula.ToString();
            txtProducto.Text = nomProducto;
            cargarpagocuota();

        }
        public RegistrarPago(string cedula,string nombre, string id_cartera,int id_producto, string producto, int id_pagos, string pago,string tipopago, string referencia, string concepto, string entidad, string fecha, string valor, string descuento, string valordescuento, string idcliente, int valproducto)
        {
            InitializeComponent();
            modificar = true;
            clienteId = int.Parse(idcliente);
            valortotal = valproducto;
            Txtcedula.Text = cedula;
            txtNombre.Text = nombre;
            productoid = id_producto;
            carteraId = int.Parse(id_cartera);
            txtProducto.Text = producto;
            pagoId = id_pagos;
            txtCuota.Text = pago;
            txtCuota.Enabled = true;
            comboTipoPago.Text = tipopago;
            txtReferencia.Text = referencia;
            txtConcepto.Text = concepto;
            TxtEntidad.Text = entidad;
            dateFechaPago.Text = fecha;
            txtValor.Text =  String.Format("{0:N0}", int.Parse(valor));

            if (string.IsNullOrEmpty(descuento))
            {
                comboDescuento.Text = "Seleccionar";
                comboDescuento.Enabled = false;
            }
            else
            {
                valdescuento = int.Parse(valordescuento);
                comboDescuento.Text = descuento;
                comboDescuento.Enabled = false;
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

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int n = e.RowIndex;
                if (n != -1)
                {
                    productoid = int.Parse(dataGridView1.Rows[n].Cells["Id_Producto"].Value.ToString());
                    valortotal = int.Parse(dataGridView1.Rows[n].Cells["Valor Total"].Value.ToString());                   
                    txtProducto.Text = dataGridView1.Rows[n].Cells["Producto"].Value.ToString();
                    cargarpagocuota();
                }
            }
            catch
            {
                MessageBox.Show("Valor no admitido");
            }
        }
        private void cargarpagocuota()
        {
            panelProductos.Visible = false;
            DataTable Dtcuota = pago.ConsultarUltimaCuota(productoid);
            string num_cuota = Dtcuota.Rows[0]["Numero_Cuota"].ToString();
            if (num_cuota == "")
            {
                txtCuota.Text = "0";
            }
            else
            {
                txtCuota.Text = (1 + int.Parse(num_cuota)).ToString();
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
            formatoGrid1();
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
            txtNombre.Text= dtclientes.Rows[0]["Nombre"].ToString()+" "+dtclientes.Rows[0]["Apellido"].ToString();
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
            if ((error != true) && (ValidarCampos() == true))
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
                    string valordescuento="";
                    if (comboDescuento.Text != "Seleccionar")
                    {
                        descuento = comboDescuento.Text;
                        valordescuento = Convert.ToDouble(txtValorDescuento.Text).ToString();
                    }
                    pago.ActulizarPago(pagoId, comboTipoPago.Text, txtCuota.Text, dateFechaPago.Text, txtConcepto.Text, TxtEntidad.Text, txtReferencia.Text, Convert.ToDouble(txtValor.Text).ToString(), descuento, valordescuento);
                    modificar = false;
                }

                ActulizarCuotas();       
                cartera.ActulizarValorRecaudado( carteraId);
                cartera.ActulizarSaldo(carteraId);
                //actulizar estado Cuota
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }    
        private void ActulizarCuotas()
        {
            CFinanciacion financiacion = new CFinanciacion();
            CCuota cuota = new CCuota();
            DataTable dtfinanciacion = financiacion.FinanciacionProducto(productoid);
            int idfinanciacion = int.Parse(dtfinanciacion.Rows[0]["Id_Financiacion"].ToString());
            int Valor_Producto_Financiacion = int.Parse(dtfinanciacion.Rows[0]["Valor_Producto_Financiacion"].ToString());
            int valor_entrada = int.Parse(dtfinanciacion.Rows[0]["Valor_Entrada"].ToString());
            int valor_sin_interes = int.Parse(dtfinanciacion.Rows[0]["Valor_Sin_interes"].ToString());
            int Cuotas_sin_interes = int.Parse(dtfinanciacion.Rows[0]["Cuotas_Sin_interes"].ToString());
            int Valor_cuota_sin_interes = int.Parse(dtfinanciacion.Rows[0]["Valor_Cuota_Sin_interes"].ToString());
            int Valor_con_interes = int.Parse(dtfinanciacion.Rows[0]["Valor_Con_Interes"].ToString());
            int Cuotas_Con_Interes = int.Parse(dtfinanciacion.Rows[0]["Cuotas_Con_Interes"].ToString());
            int Valor_Cuota_Con_Interes = int.Parse(dtfinanciacion.Rows[0]["Valor_Cuota_Con_Interes"].ToString());
            string Fecha_Recaudo = dtfinanciacion.Rows[0]["Fecha_Recaudo"].ToString();
            DateTime date = DateTime.ParseExact(Fecha_Recaudo, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            DateTime actual = DateTime.ParseExact(DateTime.Now.ToString("yyyy-MM-dd"), "yyyy-MM-dd", CultureInfo.InvariantCulture);
            label1.Text = "Valor final: $ " + String.Format("{0:N0}", Valor_Producto_Financiacion);
            label2.Text = "Valor inicial: $ " + String.Format("{0:N0}", valor_sin_interes);
            label3.Text = "Valor separación: $ " + String.Format("{0:N0}", valor_entrada);
            label4.Text = "N° de cuotas inicial: " + Cuotas_sin_interes;
            label5.Text = "Valor cuotas inicial: $ " + String.Format("{0:N0}", Valor_cuota_sin_interes);
            label6.Text = "Valor saldo: $ " + String.Format("{0:N0}", Valor_con_interes);
            label7.Text = "N° de cuotas saldo: " + String.Format("{0:N0}", Cuotas_Con_Interes);
            label8.Text = "Valor cuotas saldo: $ " + String.Format("{0:N0}", Valor_Cuota_Con_Interes);
            if (Valor_Producto_Financiacion > 0 /*&& id_financiacion !=  0*/)
            {
                DataTable dtCuotas = cuota.ListarCuotas(idfinanciacion);
                DataTable dtrecaudo = pago.Tota_Recaudado_Producto(productoid.ToString());
                int ValorPagado = 0;
                int num_cuota = 0;
                int contador = 1;
                int pagado = 0;
                string Estado = "";
                pagado = valor_entrada;
                int result = DateTime.Compare(date, actual);
                if (dtrecaudo.Rows[0]["sum(Valor_Pagado)"].ToString() != "")
                {
                    ValorPagado = int.Parse(dtrecaudo.Rows[0]["sum(Valor_Pagado)"].ToString());

                    pagado = valor_entrada;
                    if (pagado <= ValorPagado)
                    {
                        Estado = "Pagada";
                    }
                    else if (result > 0)
                    {
                        Estado = "Mora";
                    }
                    else
                    {
                        Estado = "Pendiente";
                    }
                }
                else
                {
                    Estado = "Pendiente";
                }
                if (dtCuotas.Rows.Count != 0)
                {
                    cuota.ActulziarCuota(num_cuota, Estado, idfinanciacion, "Valor Separación");
                }
                num_cuota++;
                while (num_cuota <= Cuotas_sin_interes)
                {
                    DateTime fechacuota = date.AddMonths(contador);
                    result = DateTime.Compare(fechacuota, actual);
                    pagado = pagado + Valor_cuota_sin_interes;
                    if (pagado <= ValorPagado)
                    {
                        Estado = "Pagada";
                    }
                    else if (result < 0)
                    {
                        Estado = "Mora";
                    }
                    else
                    {
                        Estado = "Pendiente";
                    }
                    if (dtCuotas.Rows.Count != 0)
                    {
                        cuota.ActulziarCuota(num_cuota, Estado, idfinanciacion, "Valor Inicial");
                    }
                    contador++;
                    num_cuota++;
                }
                num_cuota = 1;
                while (num_cuota <= Cuotas_Con_Interes)
                {
                    DateTime fechacuota = date.AddMonths(contador);
                    result = DateTime.Compare(fechacuota, actual);
                    pagado = pagado + Valor_Cuota_Con_Interes;
                    if (pagado <= ValorPagado)
                    {
                        Estado = "Pagada";
                    }
                    else if (result.ToString() == "-1")
                    {
                        Estado = "Mora";
                    }
                    else
                    {
                        Estado = "Pendiente";
                    }
                    if (dtCuotas.Rows.Count != 0)
                    {
                        cuota.ActulziarCuota(num_cuota, Estado, idfinanciacion, "Valor Saldo");
                    }
                    contador++;
                    num_cuota++;
                }
            }
        }
            private void BtEliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Está seguro de eliminar el Pago?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {                
                pago.EliminarPago(pagoId);
                if (valdescuento != 0)
                {
                    int nuevo = valortotal + valdescuento;
                    producto.actualizarValorProducto(productoid, nuevo);                    
                }
                cartera.ActulizarValorTotal(int.Parse(clienteId.ToString()), carteraId);
                cartera.ActulizarValorRecaudado(carteraId);
                cartera.ActulizarSaldo(carteraId);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }            
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

        private void txtValor_TextChanged(object sender, EventArgs e)
        {
            foreach (char caracter in txtValor.Text)
            {
                if (char.IsLetter(caracter))
                {
                    error = true;
                    errorProvider1.SetError(txtValor, "No se admiten letras");
                }
                else
                {
                    error = false;
                    errorProvider1.Clear();
                }
            }
        }

        private void txtCuota_TextChanged(object sender, EventArgs e)
        {
            foreach (char caracter in txtCuota.Text)
            {
                if (char.IsLetter(caracter))
                {
                    error = true;
                    errorProvider1.SetError(txtCuota, "No se admiten letras");
                }
                else
                {
                    error = false;
                    errorProvider1.Clear();
                }
            }
        }

        private void txtValorDescuento_TextChanged(object sender, EventArgs e)
        {
            foreach (char caracter in txtValorDescuento.Text)
            {
                if (char.IsLetter(caracter))
                {
                    error = true;
                    errorProvider1.SetError(txtValorDescuento, "No se admiten letras");
                }
                else
                {
                    error = false;
                    errorProvider1.Clear();
                }
            }
        }       
    }    
}
