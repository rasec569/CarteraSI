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
        string tipo = "";
        bool error = false;
        string  OldNumCuota, OldTipo;
        CProducto producto = new CProducto();
        CCartera cartera = new CCartera();
        CPago pago = new CPago();
        CCliente cliente = new CCliente();
        CCuota cuota=new CCuota();
        CFinanciacion financiacion = new CFinanciacion();
        CRefinanciacion refinanciacion = new CRefinanciacion();
        int clienteId = 0;
        DataTable DtNombres = new DataTable();
        DataTable DtFinanciacion = new DataTable();
        DataTable DtRefi = new DataTable();
        bool modificar = false;
        string TipoPago = "";
        int ValorCuota = 0;
        int ValPagar = 0;
        DateTime actual = DateTime.ParseExact(DateTime.Now.ToString("yyyy-MM-dd"), "yyyy-MM-dd", CultureInfo.InvariantCulture);

        DataTable DtCuotas=new DataTable();
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

        public RegistrarPago(int cedula, string nombre, string clienteid, string carteraid, string producto, string nomProducto, int valproducto)
        {
            InitializeComponent();
            clienteId = int.Parse(clienteid);
            carteraId = int.Parse(carteraid);
            productoid = int.Parse(producto);
            valortotal = valproducto;
            txtNombre.Text = nombre;
            Txtcedula.Text = cedula.ToString();
            txtProducto.Text = nomProducto;
            dateFechaPago.Text = actual.ToString("yyyy-MM-dd"); ;
            CuotaPagar(0);
            tipoproducto();

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
            OldNumCuota= pago;
            txtCuota.Enabled = true;
            comboTipoPago.Text = tipopago;
            OldTipo = tipopago;
            txtReferencia.Text = referencia;
            txtConcepto.Text = concepto;
            TxtEntidad.Text = entidad;
            dateFechaPago.Text = fecha;
            txtValor.Text =  String.Format("{0:N0}", int.Parse(valor));
            DtFinanciacion = financiacion.FinanciacionProducto(productoid);
            TipoCuotaValor(OldTipo);
            tipoproducto();

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
                    valortotal = int.Parse(dataGridView1.Rows[n].Cells["Valor Final"].Value.ToString());                   
                    txtProducto.Text = dataGridView1.Rows[n].Cells["Producto"].Value.ToString();
                    CuotaPagar(0);
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
            dataGridView1.Columns["Tipo Producto"].Visible = false;
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
        private void tipoproducto()
        {
            DataTable DtProducto= producto.BuscarProductos(txtProducto.Text);
            tipo = DtProducto.Rows[0]["Forma Pago"].ToString();
            if (tipo== "Contado")
            {
                label5.Text = "Numero pago";
            }
        }
        private void CuotaPagar(int i)
        {
            try
            {
                panelProductos.Visible = false;
                DtCuotas = cuota.CuotasPorPagar(productoid);
                DtFinanciacion = financiacion.FinanciacionProducto(productoid);
                string tipo = DtCuotas.Rows[i]["Tipo"].ToString();
                switch (tipo)
                {
                    case "Contado":
                        tipo = "Contado";
                        TipoPago = "Inicial";
                        break;
                    case "Valor Separación":
                        tipo = "Separación";
                        TipoPago = "Separación";
                        break;
                    case "Valor Inicial":
                        tipo = "Inicial sin Interes";
                        TipoPago = "Inicial";
                        break;
                    case "Valor Saldo":
                        if (DtCuotas.Rows[i]["Valor_Interes"].ToString() == "0")
                        {
                            tipo = "Saldo sin Interes";
                        }
                        else
                        {
                            tipo = "Saldo con Interes";
                        }
                        TipoPago = "Saldo";
                        break;
                    case "Refinanciación":
                        tipo = "Refinanciación";
                        TipoPago = "Refinanciación";
                        break;
                }
                comboTipoPago.Text = tipo;
                txtCuota.Text = DtCuotas.Rows[i]["Num_Cuota"].ToString();
                int TemAportes = 0;
                if (DtCuotas.Rows[i]["Aporte_Pagos"].ToString() != "")
                {
                    TemAportes = int.Parse(DtCuotas.Rows[i]["Aporte_Pagos"].ToString());
                }
                int TemCuota = int.Parse(DtCuotas.Rows[i]["Valor_Cuota"].ToString()) - TemAportes;
                ValPagar = TemCuota;
                txtValor.Text = TemCuota.ToString("N0", CultureInfo.CurrentCulture);
                comboTipoPago.Text = tipo;
            }
            catch(Exception ex)
            {
                MessageBox.Show("Sin Cuotas a Pagar", ex.Message);
            }
            

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
           
            if (comboDescuento.Text == "Pago anticipado")
            {
                
                txtValorDescuento.Enabled = true;
                txtValorDescuento.Clear();
                int TemAportes = 0;
                int TemValor = 0;
                for (int i = 0; i < DtCuotas.Rows.Count; i++)
                {                    
                    if (DtCuotas.Rows[i]["Aporte_Pagos"].ToString() != "")
                    {
                        TemAportes += int.Parse(DtCuotas.Rows[i]["Aporte_Pagos"].ToString());
                    }
                    if(DtCuotas.Rows[i]["Tipo"].ToString() != "Valor Saldo" && DtCuotas.Rows[i]["Tipo"].ToString() != "Refinanciación" && DtCuotas.Rows[i]["Estado"].ToString() != "Pagado")
                    {
                        TemValor+= int.Parse(DtCuotas.Rows[i]["Valor_Cuota"].ToString());
                    }
                }
                if(DtFinanciacion.Rows[0]["Id_Refinanciacion"].ToString()=="")
                {
                    DataTable DtAlaFecha = DtosUsuario.amortizacionFinanciacion(int.Parse(DtFinanciacion.Rows[0]["Id_Financiacion"].ToString()));
                    txtValor.Text = int.Parse(DtAlaFecha.Rows[0]["saldofecha"].ToString()).ToString("n0");
                }
                else
                {
                    ValPagar = valortotal - TemAportes;
                    txtValor.Text = (valortotal - TemAportes).ToString("N0", CultureInfo.CurrentCulture);
                }
            }
            else if (comboDescuento.Text != "Seleccionar")
            {
                CuotaPagar(0);                
                txtValorDescuento.Enabled = true;
                txtValorDescuento.Clear();
            }
            else
            {
                CuotaPagar(0);
                txtValorDescuento.Enabled = false;
                txtValorDescuento.Clear();
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
        private void TipoCuotaValor(string tipo)
        {
            DtFinanciacion = financiacion.FinanciacionProducto(productoid);
            
            if (DtFinanciacion.Rows[0]["Id_Refinanciacion"].ToString() != "")
            {
                DtRefi = refinanciacion.RefinanciacionFinanciacion(int.Parse(DtFinanciacion.Rows[0]["Id_Financiacion"].ToString()));

            }            
            switch (tipo)
            {
                case "Contado":
                    TipoPago = "Inicial";
                    break;
                case "Entrada":
                    TipoPago = "Separación";
                    break;
                case "Inicial sin Interes":
                    TipoPago = "Inicial";
                    ValorCuota = int.Parse(DtFinanciacion.Rows[0]["Valor_Cuota_Sin_interes"].ToString());
                    break;
                case "Inicial con Interes":
                    TipoPago = "Inicial";
                    ValorCuota = int.Parse(DtFinanciacion.Rows[0]["Valor_Cuota_Sin_interes"].ToString());
                    break;
                case "Saldo sin Interes":
                    TipoPago = "Saldo";
                    ValorCuota = int.Parse(DtFinanciacion.Rows[0]["Valor_Cuota_Con_Interes"].ToString());
                    break;
                case "Saldo con Interes":
                    TipoPago = "Saldo";
                    ValorCuota = int.Parse(DtFinanciacion.Rows[0]["Valor_Cuota_Con_Interes"].ToString());
                    break;
                case "Refinanciación":
                    TipoPago = "Refinanciación";
                    ValorCuota = int.Parse(DtRefi.Rows[0]["Valor_Cuota_Refi"].ToString());
                    break;
            }
        }
        private void BtRegistrarPago_Click(object sender, EventArgs e)
        {
            try
            {
                ValidarCampos();
                if ((error != true) && (ValidarCampos() == true))
                {
                    //TipoCuotaValor(comboTipoPago.Text);

                    int NuevoValor = 0;
                    if (modificar == false)
                    {
                        if (comboDescuento.Text == "Seleccionar")
                        {
                            pago.RegistrarPago(comboTipoPago.Text, txtCuota.Text, dateFechaPago.Text, txtConcepto.Text, TxtEntidad.Text, txtReferencia.Text, Convert.ToDouble(txtValor.Text).ToString(), "", "", productoid.ToString());
                        }
                        else
                        {
                            int TemAportes = 0;
                            if (DtCuotas.Rows[0]["Aporte_Pagos"].ToString() != "")
                            {
                                TemAportes = int.Parse(DtCuotas.Rows[0]["Aporte_Pagos"].ToString());
                            }
                            NuevoValor = valortotal - int.Parse(Convert.ToDouble(txtValorDescuento.Text).ToString());
                            if (comboDescuento.Text == "Pago anticipado")
                            {
                                for (int i = 0; i < DtCuotas.Rows.Count; i++)
                                {
                                    if (i == 0)
                                    {
                                        cuota.ModificarCuota(int.Parse(DtCuotas.Rows[i]["Id_Cuota"].ToString()), int.Parse(DtCuotas.Rows[i]["Num_Cuota"].ToString()), double.Parse(Convert.ToDouble(txtValor.Text).ToString()), DtCuotas.Rows[i]["Tipo"].ToString(), DtCuotas.Rows[i]["Fecha"].ToString(), DtCuotas.Rows[i]["Estado"].ToString(), TemAportes);
                                    }
                                    else
                                    {
                                        cuota.ModificarCuota(int.Parse(DtCuotas.Rows[i]["Id_Cuota"].ToString()), int.Parse(DtCuotas.Rows[i]["Num_Cuota"].ToString()), double.Parse(DtCuotas.Rows[i]["Valor_Cuota"].ToString()), DtCuotas.Rows[i]["Tipo"].ToString(), DtCuotas.Rows[i]["Fecha"].ToString(), "Inactiva", TemAportes);
                                    }
                                }
                            }
                            else
                            {
                                cuota.ModificarCuota(int.Parse(DtCuotas.Rows[0]["Id_Cuota"].ToString()), int.Parse(DtCuotas.Rows[0]["Num_Cuota"].ToString()), (double.Parse(DtCuotas.Rows[0]["Valor_Cuota"].ToString()) - double.Parse(Convert.ToDouble(txtValorDescuento.Text).ToString())), DtCuotas.Rows[0]["Tipo"].ToString(), DtCuotas.Rows[0]["Fecha"].ToString(), DtCuotas.Rows[0]["Estado"].ToString(), TemAportes);
                            }
                            pago.RegistrarPago(comboTipoPago.Text, txtCuota.Text, dateFechaPago.Text, txtConcepto.Text, TxtEntidad.Text, txtReferencia.Text, Convert.ToDouble(txtValor.Text).ToString(), comboDescuento.Text, Convert.ToDouble(txtValorDescuento.Text).ToString(), productoid.ToString());
                            producto.actualizarValorProducto(productoid, NuevoValor);
                            cartera.ActulizarValorTotal(int.Parse(clienteId.ToString()), carteraId);
                            financiacion.actualizarFinanciacion(int.Parse(DtFinanciacion.Rows[0]["Id_Financiacion"].ToString()), NuevoValor, int.Parse(DtFinanciacion.Rows[0]["Valor_Entrada"].ToString()), int.Parse(DtFinanciacion.Rows[0]["Valor_Sin_interes"].ToString()), double.Parse(DtFinanciacion.Rows[0]["Valor_Cuota_Sin_interes"].ToString()), int.Parse(DtFinanciacion.Rows[0]["Cuotas_Sin_interes"].ToString()), double.Parse(DtFinanciacion.Rows[0]["Valor_Con_Interes"].ToString()), int.Parse(DtFinanciacion.Rows[0]["Cuotas_Con_Interes"].ToString()), double.Parse(DtFinanciacion.Rows[0]["Valor_Cuota_Con_Interes"].ToString()), int.Parse(DtFinanciacion.Rows[0]["Valor_Interes"].ToString()), DtFinanciacion.Rows[0]["Fecha_Recaudo"].ToString(), productoid);
                        }
                    }
                    else
                    {
                        int OldValor = 0;
                        string descuento = "";
                        string valordescuento = "";
                        double tempdescuento;
                        if (comboDescuento.Text != "Seleccionar")
                        {
                            descuento = comboDescuento.Text;
                            valordescuento = Convert.ToDouble(txtValorDescuento.Text).ToString();
                            if(valdescuento >= Convert.ToDouble(txtValorDescuento.Text))
                            {
                                tempdescuento = valdescuento - Convert.ToDouble(txtValorDescuento.Text);
                                NuevoValor = valortotal - (int)tempdescuento;
                            }
                            else
                            {
                                tempdescuento = Convert.ToDouble(txtValorDescuento.Text)-valdescuento;
                                NuevoValor = valortotal + (int)tempdescuento;
                            }

                        }
                        else
                        {
                            NuevoValor = valortotal;
                        }
                        pago.ActulizarPago(pagoId, comboTipoPago.Text, txtCuota.Text, dateFechaPago.Text, txtConcepto.Text, TxtEntidad.Text, txtReferencia.Text, Convert.ToDouble(txtValor.Text).ToString(), descuento, valordescuento);
                        DataTable DtBalanceCuotaOLD = cuota.BalanceCuota(int.Parse(OldNumCuota), productoid, TipoPago);
                        if (!DtBalanceCuotaOLD.Rows[0].IsNull("valor"))
                        {
                            OldValor = int.Parse(DtBalanceCuotaOLD.Rows[0]["valor"].ToString());
                        }
                        cuota.ActulziarCuotaRegistroPago(int.Parse(OldNumCuota), OldValor, DtBalanceCuotaOLD.Rows[0]["result"].ToString(), int.Parse(DtFinanciacion.Rows[0]["Id_Financiacion"].ToString()), TipoPago);
                        producto.actualizarValorProducto(productoid, NuevoValor);
                        cartera.ActulizarValorTotal(int.Parse(clienteId.ToString()), carteraId);
                        financiacion.actualizarFinanciacion(int.Parse(DtFinanciacion.Rows[0]["Id_Financiacion"].ToString()), NuevoValor, int.Parse(DtFinanciacion.Rows[0]["Valor_Entrada"].ToString()), int.Parse(DtFinanciacion.Rows[0]["Valor_Sin_interes"].ToString()), double.Parse(DtFinanciacion.Rows[0]["Valor_Cuota_Sin_interes"].ToString()), int.Parse(DtFinanciacion.Rows[0]["Cuotas_Sin_interes"].ToString()), double.Parse(DtFinanciacion.Rows[0]["Valor_Con_Interes"].ToString()), int.Parse(DtFinanciacion.Rows[0]["Cuotas_Con_Interes"].ToString()), double.Parse(DtFinanciacion.Rows[0]["Valor_Cuota_Con_Interes"].ToString()), int.Parse(DtFinanciacion.Rows[0]["Valor_Interes"].ToString()), DtFinanciacion.Rows[0]["Fecha_Recaudo"].ToString(), productoid);
                        modificar = false;
                    } 
                    DataTable DtBalanceCuota = cuota.BalanceCuota(int.Parse(txtCuota.Text), productoid, TipoPago);
                    int valCuota = ValorCuota - int.Parse(DtBalanceCuota.Rows[0]["descuento"].ToString());                    
                    cuota.ActulziarCuotaRegistroPago(int.Parse(txtCuota.Text), int.Parse(DtBalanceCuota.Rows[0]["valor"].ToString()), DtBalanceCuota.Rows[0]["result"].ToString(), int.Parse(DtFinanciacion.Rows[0]["Id_Financiacion"].ToString()), TipoPago);                   
                    cartera.ActulizarValorRecaudado(carteraId);
                    cartera.ActulizarSaldo(carteraId);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error registro"+ex);
            }
            
        }    
        private string EvaluaFechaCuota(DateTime fecha)
        {
            string CuoEstado = "Abono";

            if (fecha <= actual)
            {


            }
            return CuoEstado;
        }
        
            private void BtEliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Está seguro de eliminar el Pago?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                TipoCuotaValor(comboTipoPago.Text);
                pago.EliminarPago(pagoId);
                if (valdescuento != 0)
                {
                    int nuevo = valortotal + valdescuento;
                    producto.actualizarValorProducto(productoid, nuevo);
                    financiacion.actualizarFinanciacion(int.Parse(DtFinanciacion.Rows[0]["Id_Financiacion"].ToString()), nuevo, int.Parse(DtFinanciacion.Rows[0]["Valor_Entrada"].ToString()), int.Parse(DtFinanciacion.Rows[0]["Valor_Sin_interes"].ToString()), double.Parse(DtFinanciacion.Rows[0]["Valor_Cuota_Sin_interes"].ToString()), int.Parse(DtFinanciacion.Rows[0]["Cuotas_Sin_interes"].ToString()), double.Parse(DtFinanciacion.Rows[0]["Valor_Con_Interes"].ToString()), int.Parse(DtFinanciacion.Rows[0]["Cuotas_Con_Interes"].ToString()), double.Parse(DtFinanciacion.Rows[0]["Valor_Cuota_Con_Interes"].ToString()), int.Parse(DtFinanciacion.Rows[0]["Valor_Interes"].ToString()), DtFinanciacion.Rows[0]["Fecha_Recaudo"].ToString(), productoid);
                }
                DataTable DtBalanceCuota = cuota.BalanceCuota(int.Parse(txtCuota.Text), productoid, TipoPago);
                int TemAportes = 0;
                if (!DtBalanceCuota.Rows[0].IsNull("valor"))
                {
                    TemAportes = int.Parse(DtBalanceCuota.Rows[0]["valor"].ToString());
                }
                cuota.ActulziarCuotaRegistroPago(int.Parse(txtCuota.Text), TemAportes, DtBalanceCuota.Rows[0]["result"].ToString(), int.Parse(DtFinanciacion.Rows[0]["Id_Financiacion"].ToString()), TipoPago);
                cartera.ActulizarValorTotal(int.Parse(clienteId.ToString()), carteraId);
                cartera.ActulizarValorRecaudado(carteraId);
                cartera.ActulizarSaldo(carteraId);
                this.DialogResult = DialogResult.OK;
                this.Close();
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


        private void txtValor_Validating(object sender, CancelEventArgs e)
        {
            decimal value;

            if (decimal.TryParse(txtValor.Text, NumberStyles.Currency, null, out value))
            {
                double numero = Convert.ToDouble(txtValor.Text);
                txtValor.Text = numero.ToString("N0");
            }
        }

        private void txtValor_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (char.IsLetter(System.Convert.ToChar(e.KeyValue)))
            {
                if (!string.IsNullOrEmpty(txtValor.Text))
                {
                    // Notify the user somehow
                    error = true;
                    errorProvider1.SetError(txtValor, "No se admiten letras");
                }
            }
            else
            {
                error = false;
                errorProvider1.Clear();
            }
        }

        private void txtValorDescuento_Validating(object sender, CancelEventArgs e)
        {
            decimal value;

            if (decimal.TryParse(txtValorDescuento.Text, NumberStyles.Currency, null, out value))
            {
                double numero = Convert.ToDouble(txtValorDescuento.Text);
                txtValorDescuento.Text = numero.ToString("N0");
            }
            if (!string.IsNullOrEmpty(txtValorDescuento.Text))
            {
                if (Convert.ToDouble(txtValor.Text) - Convert.ToDouble(txtValorDescuento.Text) != 0)
                {
                    txtValor.Text = String.Format("{0:N0}", ValPagar - Convert.ToDouble(txtValorDescuento.Text));
                }
            }

        }

        private void txtValorDescuento_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (char.IsLetter(System.Convert.ToChar(e.KeyValue)))
            {
                if (!string.IsNullOrEmpty(txtValor.Text))
                {
                    // Notify the user somehow
                    error = true;
                    errorProvider1.SetError(txtValor, "No se admiten letras");
                }
            }
            else
            {
                error = false;
                errorProvider1.Clear();
            }
        }
    }    
}
