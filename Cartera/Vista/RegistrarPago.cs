using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cartera.Controlador;

namespace Cartera.Vista
{
    public partial class RegistrarPago : Form
    {
        int productoid = 0;
        double valortotal = 0;
        int carteraId = 0;
        int pagoId = 0;
        double valdescuento = 0;
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
        double ValorCuota = 0;
        double ValPagar = 0;
        DateTime actual = DateTime.ParseExact(DateTime.Now.ToString("yyyy-MM-dd"), "yyyy-MM-dd", CultureInfo.InvariantCulture);
        // This is invariant
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
            if (pagoId == 0)
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
        }

        public RegistrarPago(int cedula, string nombre, string clienteid, string carteraid, string producto, string nomProducto, double valproducto)
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
            BtEliminar.Enabled = false;
        }
        public RegistrarPago(string cedula,string nombre, string id_cartera,int id_producto, string producto, int id_pagos, string pago,string tipopago, string referencia, string concepto, string entidad, string fecha, string valor, string descuento, string valordescuento, string idcliente, double valproducto)
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
            txtValor.Text =  String.Format("{0:N2}", double.Parse(valor));
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
                valdescuento = double.Parse(valordescuento);
                comboDescuento.Text = descuento;
                comboDescuento.Enabled = false;
                txtValorDescuento.Text = String.Format("{0:N2}", double.Parse(valordescuento));
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
                    valortotal = double.Parse(dataGridView1.Rows[n].Cells["Valor Final"].Value.ToString());                   
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
                if (DtCuotas.Rows.Count > 0)
                {
                    DtFinanciacion = financiacion.FinanciacionProducto(productoid);
                    string tipo = DtCuotas.Rows[i]["Tipo"].ToString();
                    switch (tipo)
                    {
                        case "Contado":
                            tipo = "Contado";
                            TipoPago = "Contado";
                            break;
                        case "Separación":
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
                    double TemAportes = 0;
                    if (DtCuotas.Rows[i]["Aporte_Pagos"].ToString() != "")
                    {
                        TemAportes = double.Parse(DtCuotas.Rows[i]["Aporte_Pagos"].ToString(), CultureInfo.CurrentCulture);
                    }
                    double TemCuota = double.Parse(DtCuotas.Rows[i]["Valor_Cuota"].ToString(), CultureInfo.CurrentCulture) - TemAportes;
                    ValPagar = TemCuota;
                    txtValor.Text = TemCuota.ToString("N2", CultureInfo.CurrentCulture);
                    comboTipoPago.Text = tipo;
                }
                else
                {
                    MessageBox.Show("Sin Cuotas por Pagar");
                    //this.Close();
                    this.Hide();
                    //this.DialogResult = DialogResult.Cancel;
                    
                }
                
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error al cargar cuotas"+ ex.Message);
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
            if(txtConcepto.Text=="")
            {
                ok = false;
                errorProvider1.SetError(txtConcepto, "Digite un concepto de Pago");
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
            if (pagoId == 0)
            {
                if (comboDescuento.Text == "Pago anticipado")
                {

                    txtValorDescuento.Enabled = true;
                    txtValorDescuento.Clear();
                    double TemAportes = 0;
                    double TemValor = 0;
                    double TotalValorDeuda = 0;
                    for (int i = 0; i < DtCuotas.Rows.Count; i++)
                    {
                        if (DtCuotas.Rows[i]["Aporte_Pagos"].ToString() != "")
                        {
                            TemAportes += double.Parse(DtCuotas.Rows[i]["Aporte_Pagos"].ToString());
                            TotalValorDeuda += double.Parse(DtCuotas.Rows[i]["Valor_Cuota"].ToString()) - double.Parse(DtCuotas.Rows[i]["Aporte_Pagos"].ToString());
                        }
                        else
                        {
                            TotalValorDeuda += double.Parse(DtCuotas.Rows[i]["Valor_Cuota"].ToString());
                        }
                        if (DtCuotas.Rows[i]["Tipo"].ToString() != "Valor Saldo" && DtCuotas.Rows[i]["Tipo"].ToString() != "Refinanciación" && DtCuotas.Rows[i]["Estado"].ToString() != "Pagado")
                        {
                            TemValor += double.Parse(DtCuotas.Rows[i]["Valor_Cuota"].ToString());

                        }

                    }
                    if (DtFinanciacion.Rows[0]["Id_Refinanciacion"].ToString() == "")
                    {
                        DataTable DtAlaFecha = DtosUsuario.amortizacionFinanciacion(int.Parse(DtFinanciacion.Rows[0]["Id_Financiacion"].ToString()));
                        txtValor.Text = double.Parse(DtAlaFecha.Rows[0]["saldofecha"].ToString()).ToString("n2");
                        txtValorDescuento.Text = (TotalValorDeuda - double.Parse(DtAlaFecha.Rows[0]["saldofecha"].ToString())).ToString("n2");
                    }
                    else
                    {
                        ValPagar = valortotal - TemAportes;
                        txtValor.Text = (valortotal - TemAportes).ToString("N2", CultureInfo.CurrentCulture);
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
            //Valida que tenga una refinanciación
                if (DtFinanciacion.Rows[0]["Id_Refinanciacion"].ToString() != "")
                {
                    //Consulta Datatable Refinanciación !cambiar a Double!
                    DtRefi = refinanciacion.RefinanciacionFinanciacion(int.Parse(DtFinanciacion.Rows[0]["Id_Financiacion"].ToString()));
                }   
                //deacuerdo al tipo selecciona la clave de la consulta sql  y en ocaciones almacena el valor de la cuota
                switch (tipo)
                {
                    case "Contado":
                        TipoPago = "Inicial";
                        break;
                    case "Separación":
                        TipoPago = "Separación";
                        break;
                    case "Inicial sin Interes":
                        TipoPago = "Inicial";
                        ValorCuota = double.Parse(DtFinanciacion.Rows[0]["Valor_Cuota_Sin_interes"].ToString());
                        break;
                    case "Inicial con Interes":
                        TipoPago = "Inicial";
                        ValorCuota = double.Parse(DtFinanciacion.Rows[0]["Valor_Cuota_Sin_interes"].ToString());
                        break;
                    case "Saldo sin Interes":
                        TipoPago = "Saldo";
                        ValorCuota = double.Parse(DtFinanciacion.Rows[0]["Valor_Cuota_Con_Interes"].ToString());
                        break;
                    case "Saldo con Interes":
                        TipoPago = "Saldo";
                        ValorCuota = double.Parse(DtFinanciacion.Rows[0]["Valor_Cuota_Con_Interes"].ToString());
                        break;
                    case "Refinanciación":
                        TipoPago = "Refinanciación";
                        ValorCuota = double.Parse(DtRefi.Rows[0]["Valor Cuota"].ToString());
                        break;
            }
        }
        private void BtRegistrarPago_Click(object sender, EventArgs e)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("es-ES");
            try
            {
                var numberFormatInfo = new NumberFormatInfo();
                numberFormatInfo.NumberDecimalSeparator = ",";
                //MessageBox.Show("ensayo "+Convert.ToDouble(txtValor.Text, CultureInfo.CurrentCulture).ToString().Replace(",", ".") + "   "+ double.Parse(Convert.ToDouble(txtValor.Text).ToString(), CultureInfo.CurrentCulture));
                ValidarCampos();
                if ((error != true) && (ValidarCampos() == true))
                {
                    //TipoCuotaValor(comboTipoPago.Text);

                    double NuevoValor = 0;
                    if (modificar == false) //Valida si no es modificacion
                    {
                        //Registra un nuevo pago sin descuentos
                        if (comboDescuento.Text == "Seleccionar")
                        {
                            pago.RegistrarPago(comboTipoPago.Text, txtCuota.Text, dateFechaPago.Text, txtConcepto.Text, TxtEntidad.Text, txtReferencia.Text, Convert.ToDouble(txtValor.Text.Replace(".", ""), CultureInfo.CurrentCulture), "", 0, productoid.ToString());
                        }
                        else//registra pagos con descuento
                        {
                            double TemAportes = 0;
                            if (DtCuotas.Rows[0]["Aporte_Pagos"].ToString() != "") // valida los aportes a la fecha
                            {
                                TemAportes = double.Parse(DtCuotas.Rows[0]["Aporte_Pagos"].ToString());
                            }
                            NuevoValor = valortotal - Convert.ToDouble(double.Parse(txtValorDescuento.Text), CultureInfo.CurrentCulture);
                            if (comboDescuento.Text == "Pago anticipado") //  valida si es pago anticipado 
                            {
                                for (int i = 0; i < DtCuotas.Rows.Count; i++)
                                {
                                    if (i == 0) // modifica la cuota pagada
                                    {
                                        //string temvalor = Convert.ToDouble(txtValor.Text, CultureInfo.CurrentCulture).ToString().Replace(",", ".").Replace(".",");
                                        //double.TryParse(temvalor, NumberStyles.Number, CultureInfo.CreateSpecificCulture("es-CO"), out double price);
                                        cuota.ModificarCuota(int.Parse(DtCuotas.Rows[i]["Id_Cuota"].ToString()), int.Parse(DtCuotas.Rows[i]["Num_Cuota"].ToString()), Convert.ToDouble(txtValor.Text.Replace(".", ""), numberFormatInfo), DtCuotas.Rows[i]["Tipo"].ToString(), DtCuotas.Rows[i]["Fecha"].ToString(), DtCuotas.Rows[i]["Estado"].ToString(), TemAportes);
                                    }
                                    else // inactiva las cuotas restantes
                                    {
                                        cuota.ModificarCuota(int.Parse(DtCuotas.Rows[i]["Id_Cuota"].ToString()), int.Parse(DtCuotas.Rows[i]["Num_Cuota"].ToString()), double.Parse(DtCuotas.Rows[i]["Valor_Cuota"].ToString()), DtCuotas.Rows[i]["Tipo"].ToString(), DtCuotas.Rows[i]["Fecha"].ToString(), "Inactiva", TemAportes);
                                    }
                                }
                            }
                            else // si no es anticipado modifica
                            {
                                cuota.ModificarCuota(int.Parse(DtCuotas.Rows[0]["Id_Cuota"].ToString()), int.Parse(DtCuotas.Rows[0]["Num_Cuota"].ToString()), (double.Parse(DtCuotas.Rows[0]["Valor_Cuota"].ToString()) - double.Parse(Convert.ToDouble(txtValorDescuento.Text).ToString())), DtCuotas.Rows[0]["Tipo"].ToString(), DtCuotas.Rows[0]["Fecha"].ToString(), DtCuotas.Rows[0]["Estado"].ToString(), TemAportes);
                            }
                            pago.RegistrarPago(comboTipoPago.Text, txtCuota.Text, dateFechaPago.Text, txtConcepto.Text, TxtEntidad.Text, txtReferencia.Text, Convert.ToDouble(txtValor.Text.Replace(".", ""), CultureInfo.CurrentCulture), comboDescuento.Text, Convert.ToDouble(txtValorDescuento.Text.Replace(".", ""), numberFormatInfo), productoid.ToString());
                            producto.actualizarValorProducto(productoid, NuevoValor);
                            cartera.ActulizarValorTotal(int.Parse(clienteId.ToString()), carteraId);
                            financiacion.actualizarFinanciacion(int.Parse(DtFinanciacion.Rows[0]["Id_Financiacion"].ToString()), NuevoValor, int.Parse(DtFinanciacion.Rows[0]["Valor_Entrada"].ToString()), int.Parse(DtFinanciacion.Rows[0]["Valor_Sin_interes"].ToString()), double.Parse(DtFinanciacion.Rows[0]["Valor_Cuota_Sin_interes"].ToString()), int.Parse(DtFinanciacion.Rows[0]["Cuotas_Sin_interes"].ToString()), double.Parse(DtFinanciacion.Rows[0]["Valor_Con_Interes"].ToString()), int.Parse(DtFinanciacion.Rows[0]["Cuotas_Con_Interes"].ToString()), double.Parse(DtFinanciacion.Rows[0]["Valor_Cuota_Con_Interes"].ToString()), int.Parse(DtFinanciacion.Rows[0]["Valor_Interes"].ToString()), DtFinanciacion.Rows[0]["Fecha_Recaudo"].ToString(), productoid);
                        }
                    }
                    else //si es modificacion
                    {
                        //double OldValor = 0;
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
                                NuevoValor = valortotal - (double)tempdescuento;
                            }
                            else
                            {
                                tempdescuento = Convert.ToDouble(txtValorDescuento.Text)-valdescuento;
                                NuevoValor = valortotal + (double)tempdescuento;
                            }

                        }
                        else
                        {
                            NuevoValor = valortotal;
                        }
                        pago.ActulizarPago(pagoId, comboTipoPago.Text, txtCuota.Text, dateFechaPago.Text, txtConcepto.Text, TxtEntidad.Text, txtReferencia.Text, Convert.ToDouble(txtValor.Text).ToString().Replace(".","").Replace(",", "."), descuento, valordescuento);
                        (string Estado, double OldValor, double Descuent) = ValidarEstadoCuota(int.Parse(OldNumCuota), productoid, TipoPago);
                        cuota.ActulziarCuotaRegistroPago(int.Parse(OldNumCuota), OldValor, Estado, int.Parse(DtFinanciacion.Rows[0]["Id_Financiacion"].ToString()), TipoPago);
                        producto.actualizarValorProducto(productoid, NuevoValor);
                        cartera.ActulizarValorTotal(int.Parse(clienteId.ToString()), carteraId);
                        financiacion.actualizarFinanciacion(int.Parse(DtFinanciacion.Rows[0]["Id_Financiacion"].ToString()), NuevoValor, int.Parse(DtFinanciacion.Rows[0]["Valor_Entrada"].ToString()), int.Parse(DtFinanciacion.Rows[0]["Valor_Sin_interes"].ToString()), double.Parse(DtFinanciacion.Rows[0]["Valor_Cuota_Sin_interes"].ToString()), int.Parse(DtFinanciacion.Rows[0]["Cuotas_Sin_interes"].ToString()), double.Parse(DtFinanciacion.Rows[0]["Valor_Con_Interes"].ToString()), int.Parse(DtFinanciacion.Rows[0]["Cuotas_Con_Interes"].ToString()), double.Parse(DtFinanciacion.Rows[0]["Valor_Cuota_Con_Interes"].ToString()), int.Parse(DtFinanciacion.Rows[0]["Valor_Interes"].ToString()), DtFinanciacion.Rows[0]["Fecha_Recaudo"].ToString(), productoid);
                        modificar = false;
                    }
                    //cambiar validacion estado
                    (string estado, double Aportes, double Descuento) = ValidarEstadoCuota(int.Parse(txtCuota.Text), productoid, TipoPago);
                    double valCuota = ValorCuota - Descuento;                    
                    cuota.ActulziarCuotaRegistroPago(int.Parse(txtCuota.Text), Aportes, estado, int.Parse(DtFinanciacion.Rows[0]["Id_Financiacion"].ToString()), TipoPago);                   
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
        private string EvaluaEstadoCuotaFecha(DateTime fecha)
        {
            string CuoEstado = "Pendiente";

            if (fecha <= actual)
            {
                CuoEstado = "Mora";
            }
            return CuoEstado;
        }
        
        private void BtEliminar_Click(object sender, EventArgs e)
            //Metodo para accion de boton eliminar un pago registrado
        {
            try { 
                //Validación de Confirmación por el usuario de eliminar
                if (MessageBox.Show("¿Está seguro de eliminar el Pago?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    //Consulta el tipo de Cuota pagada
                    TipoCuotaValor(comboTipoPago.Text);    
                    // Valida si hay valor en descuento
                    if (valdescuento != 0)
                    {
                        //Lista las Cuotas pagadas
                        DataTable DtCuotasPagas = cuota.CuotasPagas(int.Parse(DtFinanciacion.Rows[0]["Id_Financiacion"].ToString()));
                        //valida si el descuento es Pago anticipado
                        if (comboDescuento.Text == "Pago anticipado")
                        {
                            //Valida que no tenga una refinanciación
                            if (DtFinanciacion.Rows[0]["Id_Refinanciacion"].ToString() == "")
                            {   // filtra DtCuotasPagas por los valores de txtCuota.Text y TipoPago                             
                                DataRow[] CuotaPagoAnticipo = DtCuotasPagas.Select(String.Format("Num_Cuota = '{0}' AND Tipo like '%{1}%'", txtCuota.Text, TipoPago));
                                // si el DataRow no esta vacio
                                if (CuotaPagoAnticipo.Length > 0)
                                {
                                    //almacena temporal los valores de DataRow
                                    DataTable dt1 = CuotaPagoAnticipo.CopyToDataTable();
                                    //modifica los valores de la cuota afectada
                                    cuota.ModificarCuota(int.Parse(dt1.Rows[0]["Id_Cuota"].ToString()), int.Parse(dt1.Rows[0]["Num_Cuota"].ToString()), ValorCuota, dt1.Rows[0]["Tipo"].ToString(), dt1.Rows[0]["Fecha"].ToString(), EvaluaEstadoCuotaFecha(Convert.ToDateTime(dt1.Rows[0]["Fecha"].ToString())), double.Parse(dt1.Rows[0]["Aporte_Pagos"].ToString()));
                                }
                                //cuota.ModificarCuota(int.Parse(DTCuotasInactivas.Rows[i]["Id_Cuota"].ToString()), int.Parse(DTCuotasInactivas.Rows[i]["Num_Cuota"].ToString()), double.Parse(DTCuotasInactivas.Rows[i]["Valor_Cuota"].ToString()), DTCuotasInactivas.Rows[i]["Tipo"].ToString(), DTCuotasInactivas.Rows[i]["Fecha"].ToString(), EvaluaEstadoCuotaFecha(Convert.ToDateTime(DTCuotasInactivas.Rows[i]["Fecha"].ToString())), double.Parse(DTCuotasInactivas.Rows[i]["Aporte_Pagos"].ToString()));
                                //Lista las cuotas inactivas que afecto el pago anticipado
                                DataTable DTCuotasInactivas = cuota.ListarCuotasActivarDelect(int.Parse(DtFinanciacion.Rows[0]["Id_Financiacion"].ToString()));
                                for (int i = 0; i < DTCuotasInactivas.Rows.Count; i++)
                                {
                                    //Cambia el estado a activas
                                    cuota.ModificarCuota(int.Parse(DTCuotasInactivas.Rows[i]["Id_Cuota"].ToString()), int.Parse(DTCuotasInactivas.Rows[i]["Num_Cuota"].ToString()), double.Parse(DTCuotasInactivas.Rows[i]["Valor_Cuota"].ToString()), DTCuotasInactivas.Rows[i]["Tipo"].ToString(), DTCuotasInactivas.Rows[i]["Fecha"].ToString(), EvaluaEstadoCuotaFecha(Convert.ToDateTime(DTCuotasInactivas.Rows[i]["Fecha"].ToString())), double.Parse(DTCuotasInactivas.Rows[i]["Aporte_Pagos"].ToString()));
                                }
                            }
                        }
                        //si el descuento comun
                        else
                        {
                            // filtra DtCuotasPagas por los valores de txtCuota.Text y TipoPago   
                            DataRow[] CuotaPagoDescuento = DtCuotasPagas.Select(String.Format("Num_Cuota = '{0}' AND Tipo like '%{1}%'", txtCuota.Text, TipoPago));

                            // si el DataRow no esta vacio
                            if (CuotaPagoDescuento.Length > 0)
                            {
                                //almacena temporal los valores de DataRow
                                DataTable dt1 = CuotaPagoDescuento.CopyToDataTable();
                                //modifica los valores de la cuota afectada
                                cuota.ModificarCuota(int.Parse(dt1.Rows[0]["Id_Cuota"].ToString()), int.Parse(dt1.Rows[0]["Num_Cuota"].ToString()), ValorCuota, dt1.Rows[0]["Tipo"].ToString(), dt1.Rows[0]["Fecha"].ToString(), EvaluaEstadoCuotaFecha(Convert.ToDateTime(dt1.Rows[0]["Fecha"].ToString())), double.Parse(dt1.Rows[0]["Aporte_Pagos"].ToString()));
                            }
                        }
                        //metodo para eliminar el pago
                        pago.EliminarPago(pagoId);
                        //calcula el valor total mas el descueto aplicado
                        double nuevo = valortotal + valdescuento;
                        //modifica el valor del producto con los parametros del nuevo valor y el id del producto
                        producto.actualizarValorProducto(productoid, nuevo);
                        //modifica el valor del total de la financiacion con los parametros del nuevo valor, id financiacion y el id del producto
                        financiacion.actualizarFinanciacion(int.Parse(DtFinanciacion.Rows[0]["Id_Financiacion"].ToString()), nuevo, int.Parse(DtFinanciacion.Rows[0]["Valor_Entrada"].ToString()), int.Parse(DtFinanciacion.Rows[0]["Valor_Sin_interes"].ToString()), double.Parse(DtFinanciacion.Rows[0]["Valor_Cuota_Sin_interes"].ToString()), int.Parse(DtFinanciacion.Rows[0]["Cuotas_Sin_interes"].ToString()), double.Parse(DtFinanciacion.Rows[0]["Valor_Con_Interes"].ToString()), int.Parse(DtFinanciacion.Rows[0]["Cuotas_Con_Interes"].ToString()), double.Parse(DtFinanciacion.Rows[0]["Valor_Cuota_Con_Interes"].ToString()), int.Parse(DtFinanciacion.Rows[0]["Valor_Interes"].ToString()), DtFinanciacion.Rows[0]["Fecha_Recaudo"].ToString(), productoid);
                    }
                    // si no hay descuento
                    else
                    {
                        //metodo para eliminar el pago
                        pago.EliminarPago(pagoId);
                    }
                    //Captura en tres varibles los valores resibidos por el metodo validar estado de la cuota que retorna el mismo numero de variables
                    (string estado,double TemAportes, double Descuento) = ValidarEstadoCuota(int.Parse(txtCuota.Text), productoid, TipoPago);
                    //Pago sin numero de cuota correcta
                    if (estado!= "SinCuota")
                    {
                        //actuliza los valores de la cuota con los datos del metodo validar estado cuota
                        cuota.ActulziarCuotaRegistroPago(int.Parse(txtCuota.Text), TemAportes, estado, int.Parse(DtFinanciacion.Rows[0]["Id_Financiacion"].ToString()), TipoPago);
                    }
                    //actuliza los valor total de la cartera
                    cartera.ActulizarValorTotal(int.Parse(clienteId.ToString()), carteraId);
                    //actuliza los valor Recaudado de la cartera
                    cartera.ActulizarValorRecaudado(carteraId);
                    //actuliza los valor saldo de la cartera
                    cartera.ActulizarSaldo(carteraId);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }            
            } catch(Exception ex)
            {
                MessageBox.Show("Error: " + ex);
            }          
        }
        private (string, double, double) ValidarEstadoCuota(int NumCuota, int producto, string tipo)
        //metodo para validar el estado de las fechas de las cuotas con 3 parametros de entra y los mismo de salida
        {
            //Variable temporar para almacenar el esta de la cuota
            string Estado = "";
            //lista cuota con criterio de busqueda numero de cuota, id producto y tipo
            DataTable DtBalanceCuota = cuota.ValoryAporteCuota(NumCuota, producto, tipo);
            //Variable temporar para almacenar los aportes de la cuota
            double TemAportes = 0;
            //Variable temporar para almacenar el descunto de la cuota
            double Descuento = 0;
            //Valida que el valor de la cuota no sea null
            if (!DtBalanceCuota.Rows[0].IsNull("Valor")) {
                //Variable temporar para almacenar el descunto de la cuota
                double Valor = double.Parse(DtBalanceCuota.Rows[0]["Valor"].ToString());
                //Valida que el valor pagado no sea null
                if (!DtBalanceCuota.Rows[0].IsNull("Pagado"))
                {
                    TemAportes = double.Parse(DtBalanceCuota.Rows[0]["Pagado"].ToString());
                    //Valida que el descuento no sea null
                    if (!DtBalanceCuota.Rows[0].IsNull("descuento"))
                    {
                        Descuento = double.Parse(DtBalanceCuota.Rows[0]["descuento"].ToString());
                    }
                    else
                    {
                        Descuento = 0;
                    }
                }
                else
                {
                    TemAportes = 0;
                }//Valida el estado de la cuota
                if (TemAportes >= Valor)
                {
                    Estado = "Pagada";
                }
                else
                {
                    if (DtBalanceCuota.Rows[0]["Estado"].ToString() == "Vencida")
                    {
                        Estado = "Mora";
                    }
                    else
                    {
                        if (TemAportes > 0)
                        {
                            Estado = "Abono";
                        }
                        else
                        {
                            Estado = "Pendiente";
                        }
                    }
                }
            }
            //el valor de la cuota es null !!no existe!!
            else
            {
                Descuento = 0;
                Estado = "SinCuota";
                TemAportes = 0;
                MessageBox.Show("Pago con numero de cuota incorrecta!!!");
            }
                           
            return (Estado, TemAportes, Descuento);
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
                txtValor.Text = numero.ToString("N2");
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
                txtValorDescuento.Text = numero.ToString("N2");
            }
            if (!string.IsNullOrEmpty(txtValorDescuento.Text))
            {
                if (Convert.ToDouble(txtValor.Text) - Convert.ToDouble(txtValorDescuento.Text) > 0)
                {
                    txtValor.Text = String.Format("{0:N2}", ValPagar - Convert.ToDouble(txtValorDescuento.Text));
                }
                else
                {
                    // Notify the user somehow
                    error = true;
                    errorProvider1.SetError(txtValor, "El valor del descuento no pude ser mayor la cuota");
                }
            }

        }

        private void comboTipoPago_SelectedIndexChanged(object sender, EventArgs e)
        {
            TipoCuotaValor(comboTipoPago.Text);
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
