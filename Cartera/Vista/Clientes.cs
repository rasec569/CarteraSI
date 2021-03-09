using Cartera.Controlador;
using System;
using System.Data;
using System.Globalization;
using System.Windows.Forms;

namespace Cartera.Vista
{

    public partial class Clientes : Form
    {
        CCartera cartera = new CCartera();
        CCliente cliente = new CCliente();
        CProducto producto = new CProducto();
        CTipo_Producto tipo_producto = new CTipo_Producto();
        CProyecto proyecto = new CProyecto();
        CFinanciacion financiacion = new CFinanciacion();
        CCliente_Producto cliente_producto = new CCliente_Producto();

        bool error = false;
        DataTable DtNombres = new DataTable();
        public static int Cartera_id = 0;
        public static string Cliente_id = "";
        public static string Producto_id = "";
        public static string Financiacion_id = "";
        public static int valor = 0;



        public Clientes()
        {
            InitializeComponent();
            DateRecaudo.MinDate = new DateTime(2015, 1, 1);
            DateVenta.MinDate = new DateTime(2015, 1, 1);
            DateRecaudo.MaxDate = DateTime.Today;
            DateVenta.MaxDate = DateTime.Today;
            Cartera_id = 0;
            Cliente_id = "";
            Producto_id = "";
            Financiacion_id = "";
            valor = 0;
    }
        public Clientes(int cedula)
        {
            InitializeComponent();
            Panel_Registrar_user.Visible = true;
            dataGridView2.DataSource = "";
            LimpiarUsuario();
            LimpiarProducto();
            DataTable DtUsuario = cliente.BuscarClientesCedula(cedula.ToString());
            Cliente_id = DtUsuario.Rows[0]["Id_Cliente"].ToString();
            txtCedula.Text = DtUsuario.Rows[0]["Cedula"].ToString();
            txtNombres.Text = DtUsuario.Rows[0]["Nombre"].ToString();
            txtApellidos.Text = DtUsuario.Rows[0]["Apellido"].ToString();
            txtTelefono.Text = DtUsuario.Rows[0]["Telefono"].ToString();
            txtDireccion.Text = DtUsuario.Rows[0]["Direccion"].ToString();
            txtCorreo.Text = DtUsuario.Rows[0]["Correo"].ToString();
            Cartera_id = int.Parse(DtUsuario.Rows[0]["Fk_Id_Cartera"].ToString());
            CargarProducto();

        }
        private void Clientes_Load(object sender, EventArgs e)
        {
            autocompletar();
            CargarClientes();
            Bloquear_Financiado();
            comboProyecto.DataSource = proyecto.listarProyectos();
            comboProyecto.DisplayMember = "Proyecto_Nombre";
            comboProyecto.ValueMember = "Id_Proyecto";;

            comboTipoProducto.DataSource = tipo_producto.listarTipoProducto();
            comboTipoProducto.DisplayMember = "Nom_Tipo_Producto";
            comboTipoProducto.ValueMember = "Id_Tipo_Producto";
        }
        private void BtBuscarCliente_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtBuscarCliente.Text != "")
                {
                    Panel_Registrar_user.Visible = true;
                    string nom = txtBuscarCliente.Text;
                    dataGridView2.DataSource = "";
                    LimpiarUsuario();
                    LimpiarProducto();
                    DataTable DtUsuario = cliente.cargarClientes(nom);
                    Cliente_id = DtUsuario.Rows[0]["Id_Cliente"].ToString();
                    txtCedula.Text = DtUsuario.Rows[0]["Cedula"].ToString();
                    txtNombres.Text = DtUsuario.Rows[0]["Nombre"].ToString();
                    txtApellidos.Text = DtUsuario.Rows[0]["Apellido"].ToString();
                    txtTelefono.Text = DtUsuario.Rows[0]["Telefono"].ToString();
                    txtDireccion.Text = DtUsuario.Rows[0]["Direccion"].ToString();
                    txtCorreo.Text = DtUsuario.Rows[0]["Correo"].ToString();
                    Cartera_id = int.Parse(DtUsuario.Rows[0]["Fk_Id_Cartera"].ToString());
                    CargarProducto();
                    BtGuardarCliente.Enabled = true;
                    //if para buscar por nombre o cedula
                    //DataTable DtProdutos = Conexion.consulta("SELECT * FROM Producto INNER join Cartera on Id_Cartera = Fk_Id_Cartera WHERE Id_Cartera = " + car + "");                    
                }
                else
                {
                    MessageBox.Show("ingrese un nombre a buscar");
                }
            }
            catch
            {
                MessageBox.Show("error");
            }

        }
        private void CargarClientes()
        {
            dataGridView1.DataSource = cliente.cargarClientes();
            dataGridView1.Columns["Id_Cliente"].Visible = false;
            dataGridView1.Columns["Fk_Id_Cartera"].Visible = false;
        }
        private void CargarProducto()
        {
            dataGridView2.DataSource = producto.cargarProductosCliente(int.Parse(Cliente_id));
            dataGridView2.Columns["Id_Producto"].Visible = false;
            dataGridView2.Columns[1].HeaderText = "Producto";
            dataGridView2.Columns[2].HeaderText = "Contrato";
            dataGridView2.Columns[3].HeaderText = "Forma Pago";
            dataGridView2.Columns[4].HeaderText = "Valor Producto";
            dataGridView2.Columns[5].HeaderText = "Fecha Venta";
            dataGridView2.Columns["Observaciones"].Visible = false;
            dataGridView2.Columns[7].HeaderText = "Proyecto";
            dataGridView2.Columns[8].HeaderText = "Tipo Producto";
            dataGridView2.Columns["Fk_Id_Proyecto"].Visible = false;
            dataGridView2.Columns["Fk_Id_Tipo_Producto"].Visible = false;        }
        void autocompletar()
        {
            AutoCompleteStringCollection lista = new AutoCompleteStringCollection();
            //if para buscar por nombre o cedula
            DtNombres = cliente.cargarClientes();
            for (int i = 0; i < DtNombres.Rows.Count; i++)
            {
                lista.Add(DtNombres.Rows[i]["Nombre"].ToString());
            }
            txtBuscarCliente.AutoCompleteCustomSource = lista;
        }

        private bool ValidarCampos()
        {
            bool ok = true;
            if (txtCedula.Text == "")
            {
                ok = false;
                errorProvider1.SetError(txtCedula, "Digite cedula");
            }
            if (txtNombres.Text == "")
            {
                ok = false;
                errorProvider1.SetError(txtNombres, "Digite nombre");
            }
            if (txtApellidos.Text == "")
            {
                ok = false;
                errorProvider1.SetError(txtApellidos, "Digite apellido");
            }
            if (txtTelefono.Text == "")
            {
                ok = false;
                errorProvider1.SetError(txtTelefono, "Digite telefono");
            }
            if (Cliente_id == "")
            {
                if (txtNombreProducto.Text == "")
                {
                    ok = false;
                    errorProvider1.SetError(txtNombreProducto, "Digite nombre del producto");
                }
                if (txtContrato.Text == "")
                {
                    ok = false;
                    errorProvider1.SetError(txtContrato, "Digite referencia contrato");
                }
                if (ComboFormaPago.Text == "")
                {
                    ok = false;
                    errorProvider1.SetError(ComboFormaPago, "Seleccione forma de pago");
                }
                if (txtValor.Text == "")
                {
                    ok = false;
                    errorProvider1.SetError(txtValor, "Digite el valor del producto");
                }
            }

            return ok;
        }
        private void ValidarInsert(int retorno)
        {
            if (retorno == 0)
            {
                throw new Exception("Algo fallo");
            }
        }
        private void BtGuardarCliente_Click(object sender, EventArgs e)
        {
            ValidarCampos();
            if ((error != true) && (ValidarCampos() == true))
            {
                if (Cliente_id == "")
                {
                    if (comboEstadoCliente.Text == "Trasferir")
                    {
                        int rt = cartera.crearCartera();
                        if(rt != 0)
                        {
                            Cartera_id = int.Parse(cartera.UltimoRegistro().Rows[0]["max(Id_Cartera)"].ToString());
                            int rt2 = cliente.crearCliente(int.Parse(txtCedula.Text), txtNombres.Text, txtApellidos.Text, txtTelefono.Text, txtDireccion.Text, txtCorreo.Text, Cartera_id);
                            if (rt2 != 0)
                            {
                                Cliente_id = cliente.ultimoCliente().Rows[0]["max(Id_Cliente)"].ToString();
                                int rt3 = cliente_producto.InsertCliente_Producto(Cliente_id, Producto_id);
                                if (rt3 != 0) 
                                {
                                    int rt4 = producto.actualizarProducto(int.Parse(Producto_id), txtNombreProducto.Text, txtContrato.Text, ComboFormaPago.Items[ComboFormaPago.SelectedIndex].ToString(), int.Parse(Convert.ToDouble(txtValor.Text).ToString()), DateVenta.Text, txtObeservaciones.Text, int.Parse(comboProyecto.SelectedIndex.ToString()), int.Parse(comboTipoProducto.SelectedIndex.ToString()));
                                    cartera.ActulizarValorTotal(int.Parse(Cliente_id), Cartera_id);
                                    if ((rt4 != 0) && (ComboFormaPago.Items[ComboFormaPago.SelectedIndex].ToString() == "Financiado"))
                                    {
                                        financiacion.crearFinanciacion(txtValorTotal.Text, txtValorEntrada.Text, txtValorSin.Text, txtValorCuotaSin.Text, numCuotaSinInteres.Value.ToString(), txtValorCon.Text, numCuotasInteres.Value.ToString(), txtValorCuotaInteres.Text, numValorInteres.Value.ToString(), DateRecaudo.Text, Producto_id);
                                    }
                                }                                
                            }
                        }
                    }
                    else if(comboEstadoCliente.Text == "Disolución")
                    {

                    }
                    else { 
                    int retorno = cartera.crearCartera();
                        if (retorno != 0)
                        {
                            Cartera_id = int.Parse(cartera.UltimoRegistro().Rows[0]["max(Id_Cartera)"].ToString());
                            int retorno2 = cliente.crearCliente(int.Parse(txtCedula.Text), txtNombres.Text, txtApellidos.Text, txtTelefono.Text, txtDireccion.Text, txtCorreo.Text, Cartera_id);
                            if (retorno2 != 0)
                            {
                                if (Producto_id == "")
                                {                                                 
                                        int retorno3 = producto.crearProducto(txtNombreProducto.Text, txtContrato.Text, ComboFormaPago.Items[ComboFormaPago.SelectedIndex].ToString(), int.Parse(Convert.ToDouble(txtValor.Text).ToString()), DateVenta.Text, txtObeservaciones.Text, int.Parse(comboProyecto.SelectedIndex.ToString()), int.Parse(comboTipoProducto.SelectedIndex.ToString()));
                                    if (retorno3 != 0)
                                    {
                                        Cliente_id = cliente.ultimoCliente().Rows[0]["max(Id_Cliente)"].ToString();
                                        Producto_id = producto.ultimoProducto().Rows[0]["max(Id_Producto)"].ToString();                                    
                                        int retorno4 = cliente_producto.InsertCliente_Producto(Cliente_id, Producto_id);
                                        cartera.ActulizarValorTotal(int.Parse(Cliente_id), Cartera_id);
                                        if ((ComboFormaPago.Text == "Financiado") && (retorno4 != 0))
                                        {
                                            financiacion.crearFinanciacion(txtValorTotal.Text, txtValorEntrada.Text, txtValorSin.Text, txtValorCuotaSin.Text, numCuotaSinInteres.Value.ToString(), txtValorCon.Text, numCuotasInteres.Value.ToString(), txtValorCuotaInteres.Text, numValorInteres.Value.ToString(), DateRecaudo.Text, Producto_id);                                            
                                        }    
                                    }
                                }
                                else
                                {
                                    int retorno4 = cliente_producto.InsertCliente_Producto(Cliente_id, Producto_id);
                                    if ((ComboFormaPago.Items[ComboFormaPago.SelectedIndex].ToString() == "Financiado") && (retorno4 != 0))
                                    {
                                            financiacion.crearFinanciacion(txtValorTotal.Text, txtValorEntrada.Text, txtValorSin.Text, txtValorCuotaSin.Text, numCuotaSinInteres.Value.ToString(), txtValorCon.Text, numCuotasInteres.Value.ToString(), txtValorCuotaInteres.Text, numValorInteres.Value.ToString(), DateRecaudo.Text, Producto_id);
                                    }
                                }
                            }
                        } 

                    }                    
                }
                else
                {
                    cliente.actualizarCliente(int.Parse(Cliente_id), int.Parse(txtCedula.Text), txtNombres.Text, txtApellidos.Text, txtTelefono.Text, txtDireccion.Text, txtCorreo.Text, Cartera_id);
                    if ((Producto_id == "") && (txtNombreProducto.Text != ""))
                    {
                        int retorno = producto.crearProducto(txtNombreProducto.Text, txtContrato.Text, ComboFormaPago.Items[ComboFormaPago.SelectedIndex].ToString(), int.Parse(Convert.ToDouble(txtValor.Text).ToString()), DateVenta.Text, txtObeservaciones.Text, int.Parse(comboProyecto.SelectedIndex.ToString()), int.Parse(comboTipoProducto.SelectedIndex.ToString()));

                        if (retorno != 0)
                        {
                            Producto_id = producto.ultimoProducto().Rows[0]["max(Id_Producto)"].ToString();
                            cartera.ActulizarValorTotal(int.Parse(Cliente_id), Cartera_id);
                            int retorno2 = cliente_producto.InsertCliente_Producto(Cliente_id, Producto_id);
                            if ((retorno2 != 0) && (ComboFormaPago.Items[ComboFormaPago.SelectedIndex].ToString() == "Financiado"))
                            {
                                financiacion.crearFinanciacion(txtValorTotal.Text, txtValorEntrada.Text, txtValorSin.Text, txtValorCuotaSin.Text, numCuotaSinInteres.Value.ToString(), txtValorCon.Text, numCuotasInteres.Value.ToString(), txtValorCuotaInteres.Text, numValorInteres.Value.ToString(), DateRecaudo.Text, Producto_id);
                            }
                        }
                    }
                    else if (txtNombreProducto.Text !="")
                    {
                        producto.actualizarProducto(int.Parse(Producto_id), txtNombreProducto.Text, txtContrato.Text, ComboFormaPago.Items[ComboFormaPago.SelectedIndex].ToString(), int.Parse(Convert.ToDouble(txtValor.Text).ToString()), DateVenta.Text, txtObeservaciones.Text, int.Parse(comboProyecto.SelectedIndex.ToString()), int.Parse(comboTipoProducto.SelectedIndex.ToString()));
                        cartera.ActulizarValorTotal(int.Parse(Cliente_id), Cartera_id);
                        if (ComboFormaPago.Items[ComboFormaPago.SelectedIndex].ToString() == "Financiado")
                        {
                            financiacion.actualizarFinanciacion(Financiacion_id, txtValorTotal.Text, txtValorEntrada.Text, (Convert.ToDouble(txtValor.Text).ToString()).ToString(), txtValorCon.Text, numCuotaSinInteres.Value.ToString(), txtValorCon.Text, numCuotasInteres.ToString(), txtValorCuotaInteres.Text, numValorInteres.ToString(), DateRecaudo.Text, int.Parse(Producto_id));
                        }
                    }
                }
                
                Panel_Registrar_user.Visible = false;
                //Panel_Clientes.Visible = true;
                CargarClientes();
                autocompletar();
            }
        }
        private void LimpiarProducto()
        {
            txtNombreProducto.Clear();
            txtContrato.Clear();
            txtValor.Clear();
            txtObeservaciones.Clear();
            ComboFormaPago.SelectedValue = 0;
            comboProyecto.SelectedValue = 0;
            comboTipoProducto.SelectedValue = 0;
            txtValorTotal.Clear();
            LimpiarFinanciacion();

            //DateVenta.Clear();
            //DateRecaudo.Clear();            
        }
        private void LimpiarFinanciacion()
        {
            txtValorSin.Clear();
            txtValorEntrada.Clear();
            txtValorCon.Clear();
            txtValorCuotaSin.Clear();
            txtValorCuotaInteres.Clear();
            numValorInteres.ResetText();
            numCuotasInteres.ResetText();
            numCuotaSinInteres.ResetText();
        }
        private void LimpiarUsuario()
        {
            txtCedula.Clear();
            txtNombres.Clear();
            txtApellidos.Clear();
            txtTelefono.Clear();
            txtCorreo.Clear();
            txtDireccion.Clear();
        }
        private void BtNuevoCliente_Click(object sender, EventArgs e)
        {
            Panel_Registrar_user.Visible = true;
            BtGuardarCliente.Enabled = true;
            LimpiarUsuario();
            LimpiarProducto();
            Cartera_id = 0;
            Cliente_id = "";
            Producto_id = "";
            Financiacion_id = "";
            dataGridView2.DataSource = "";
            //Panel_Clientes.Visible = false

        }

        private void txtNombres_TextChanged(object sender, EventArgs e)
        {
            foreach (char caracter in txtNombres.Text)
            {
                if (char.IsNumber(caracter))
                {
                    error = true;
                    errorProvider1.SetError(txtNombres, "No se admiten numeros");
                }
                else
                {
                    error = false;
                    errorProvider1.Clear();
                }
            }

        }

        private void txtApellidos_TextChanged(object sender, EventArgs e)
        {
            foreach (char caracter in txtApellidos.Text)
            {
                if (char.IsNumber(caracter))
                {
                    error = true;
                    errorProvider1.SetError(txtApellidos, "No se admiten numeros");
                }
                else
                {
                    error = false;
                    errorProvider1.Clear();
                }
            }
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

        private void txtTelefono_TextChanged(object sender, EventArgs e)
        {
            foreach (char caracter in txtTelefono.Text)
            {
                if (char.IsLetter(caracter))
                {
                    error = true;
                    errorProvider1.SetError(txtTelefono, "No se admiten letras");
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
            try
            {
                int n = e.RowIndex;
                if (n != -1)
                {
                    Panel_Registrar_user.Visible = true;
                    BtGuardarCliente.Enabled = true;
                    LimpiarUsuario();
                    LimpiarProducto();
                    Cliente_id = dataGridView1.Rows[n].Cells["Id_Cliente"].Value.ToString();
                    txtCedula.Text = dataGridView1.Rows[n].Cells["Cedula"].Value.ToString();
                    txtNombres.Text = dataGridView1.Rows[n].Cells["Nombre"].Value.ToString();
                    txtApellidos.Text = dataGridView1.Rows[n].Cells["Apellido"].Value.ToString();
                    txtTelefono.Text = dataGridView1.Rows[n].Cells["Telefono"].Value.ToString();
                    txtDireccion.Text = dataGridView1.Rows[n].Cells["Direccion"].Value.ToString();
                    txtCorreo.Text = (string)dataGridView1.Rows[n].Cells["Correo"].Value.ToString();
                    Cartera_id = int.Parse(dataGridView1.Rows[n].Cells["Fk_Id_Cartera"].Value.ToString());
                    CargarProducto();
                }
            }
            catch
            {
                MessageBox.Show("Valor no admitido");
                Panel_Registrar_user.Visible = false;
                BtGuardarCliente.Enabled = false;
            }
            
        }

        private void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int n = e.RowIndex;
                if (n != -1)
                {
                    LimpiarProducto();
                    Producto_id = dataGridView2.Rows[n].Cells["Id_Producto"].Value.ToString();
                    txtNombreProducto.Text = dataGridView2.Rows[n].Cells["Nombre_Producto"].Value.ToString();
                    txtContrato.Text = dataGridView2.Rows[n].Cells["Numero_contrato"].Value.ToString();
                    // fotmatear campo valor
                    valor = int.Parse( dataGridView2.Rows[n].Cells["Valor_Producto"].Value.ToString());
                    txtValor.Text = valor.ToString("N", CultureInfo.CurrentCulture);
                    txtObeservaciones.Text = dataGridView2.Rows[n].Cells["Observaciones"].Value.ToString();
                    DateVenta.Text = dataGridView2.Rows[n].Cells["Fecha_Venta"].Value.ToString();
                    ComboFormaPago.SelectedItem = dataGridView2.Rows[n].Cells["Forma_Pago"].Value.ToString();
                    comboProyecto.SelectedIndex = int.Parse(dataGridView2.Rows[n].Cells["Fk_Id_Proyecto"].Value.ToString());
                    comboTipoProducto.SelectedIndex = int.Parse(dataGridView2.Rows[n].Cells["Fk_Id_Tipo_Producto"].Value.ToString());
                    if (dataGridView2.Rows[n].Cells["Forma_Pago"].Value.ToString() == "Contado")
                    {
                        Bloquear_Financiado();
                    }
                    else
                    {
                        //hacer consulta para traer la financiacion
                        DataTable DtFinanciacion = financiacion.FinanciacionProducto(int.Parse(Producto_id));
                        Financiacion_id= DtFinanciacion.Rows[0]["Id_Financiacion"].ToString();
                        txtValorTotal.Text = DtFinanciacion.Rows[0]["Valor_Producto_Financiacion"].ToString();
                        txtValorSin.Text = DtFinanciacion.Rows[0]["Valor_Sin_interes"].ToString();
                        txtValorEntrada.Text = DtFinanciacion.Rows[0]["Valor_Entrada"].ToString();
                        txtValorCon.Text = DtFinanciacion.Rows[0]["Valor_Con_Interes"].ToString();
                        DateRecaudo.Text = DtFinanciacion.Rows[0]["Fecha_Recaudo"].ToString();
                        numCuotaSinInteres.Text = DtFinanciacion.Rows[0]["Cuotas_Sin_interes"].ToString();
                        numCuotasInteres.Text = DtFinanciacion.Rows[0]["Cuotas_Con_Interes"].ToString();
                        txtValorCuotaSin.Text = DtFinanciacion.Rows[0]["Valor_Cuota_Sin_interes"].ToString();
                        numValorInteres.Text = DtFinanciacion.Rows[0]["Valor_Interes"].ToString();
                        txtValorCuotaInteres.Text = DtFinanciacion.Rows[0]["Valor_Cuota_Con_Interes"].ToString();
                    }
                    label24.Visible = true;
                    comboEstadoCliente.Visible = true;
                    dateFechaEstado.Visible = true;

                }
            }
            catch
            {
                MessageBox.Show("Valor no admitido");
            }

        }
        private void Bloquear_Financiado()
        {
            txtValorSin.Enabled = false;
            txtValorEntrada.Enabled = false;
            txtValorCon.Enabled = false;
            DateRecaudo.Enabled = false;
            txtValorCuotaInteres.Enabled = false;
            txtValorCuotaSin.Enabled = false;
            numValorInteres.Enabled = false;
            numCuotaSinInteres.Enabled = false;
            numCuotasInteres.Enabled = false;
            checkBox1.Enabled = false;
        }
        private void Habilitar_Financiado()
        {
            txtValorSin.Enabled = true;
            txtValorEntrada.Enabled = true;
            txtValorCon.Enabled = true;
            DateRecaudo.Enabled = true;
            txtValorCuotaInteres.Enabled = true;
            txtValorCuotaSin.Enabled = true;
            numValorInteres.Enabled = true;
            numCuotaSinInteres.Enabled = true;
            numCuotasInteres.Enabled = true;
            checkBox1.Enabled = true;
        }

        private void ComboFormaPago_SelectedValueChanged(object sender, EventArgs e)
        {
            if (ComboFormaPago.Items[ComboFormaPago.SelectedIndex].ToString() == "Contado")
            {
                Bloquear_Financiado();
                LimpiarFinanciacion();


            }
            else if (ComboFormaPago.Items[ComboFormaPago.SelectedIndex].ToString() == "Financiado")
            {
                Habilitar_Financiado();
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
        private void txtValorEntrada_TextChanged(object sender, EventArgs e)
        {
            foreach (char caracter in txtValorEntrada.Text)
            {
                if (char.IsLetter(caracter))
                {
                    error = true;
                    errorProvider1.SetError(txtValorEntrada, "No se admiten letras");
                }
                else
                {
                    error = false;
                    errorProvider1.Clear();
                }
            }
        }
        private void txtValorEntrada_Leave(object sender, EventArgs e)
        {
            try
            {
                double Valor = (Convert.ToDouble(txtValor.Text) * 0.3) - Convert.ToDouble(txtValorEntrada.Text);
                txtValorSin.Clear();
                txtValorSin.Text = Valor.ToString();
            }
            catch
            {
                MessageBox.Show("Error aqui Valor no admitido");
            }
        }

        private void numCuotaSinInteres_Click(object sender, EventArgs e)
        {
            double valor = (Convert.ToDouble(txtValorSin.Text) / Convert.ToDouble(numCuotaSinInteres.Value));
            txtValorCuotaSin.Clear();
            txtValorCuotaSin.Text = valor.ToString();
        }

        private void numCuotasInteres_Click(object sender, EventArgs e)
        {         
            MessageBox.Show(numValorInteres.Value.ToString());
            if (numCuotasInteres.Value <= 18)
            {
                numValorInteres.Text = "0";
                double valor70 = Convert.ToDouble(txtValorCon.Text);
                double cuotas70 = Convert.ToDouble(numCuotasInteres.Value);                              
                double valorcuota = valor70 / cuotas70;
                txtValorCuotaInteres.Clear();
                txtValorCuotaInteres.Text = valorcuota.ToString();
                txtValorTotal.Text = txtValor.Text;
                txtValorTotal.Text = (int.Parse(Convert.ToDouble(txtValor.Text).ToString())).ToString();
            }
            else
            {
                numValorInteres.Text = "1";
                double valor70 = Convert.ToDouble(txtValorCon.Text);
                double cuotas70 = Convert.ToDouble(numCuotasInteres.Value);
                double valorinteres= (Convert.ToDouble(txtValorCon.Text) * (Convert.ToDouble(numValorInteres.Value) / 100));
                double valorcuota = (valor70+ valorinteres) / cuotas70;
                txtValorCuotaInteres.Clear();
                txtValorCuotaInteres.Text = valorcuota.ToString();
                double valorneto = int.Parse(Convert.ToDouble(txtValor.Text).ToString());
                txtValorTotal.Text = (valorneto + valorinteres).ToString();
            }
        }

        private void txtValorCon_TextChanged(object sender, EventArgs e)
        {
            foreach (char caracter in txtValorCon.Text)
            {
                if (char.IsLetter(caracter))
                {
                    error = true;
                    errorProvider1.SetError(txtValorCon, "No se admiten letras");
                }
                else
                {
                    error = false;
                    errorProvider1.Clear();
                }
            }
        }
        private void txtValor_Leave(object sender, EventArgs e)
        {
            
            try
            {
                if (ComboFormaPago.Text=="Financiado"){
                    int val_total;
                    txtValorSin.Clear();
                    txtValorCon.Clear();
                    val_total = Convert.ToInt32(txtValor.Text);
                    double Exectos = 0.3 * val_total;
                    double Con_interes = 0.7 * val_total;
                    txtValorSin.Text = Exectos.ToString();
                    txtValorCon.Text = Con_interes.ToString();
                }
                else
                {
                    txtValorTotal.Text= txtValor.Text;
                }
                
            }
            catch
            {
                MessageBox.Show("Valor no admitido");
                errorProvider1.SetError(txtValorEntrada, "No se admiten letras");
            }
            if (!string.IsNullOrEmpty(txtValor.Text))
            {
                valor = int.Parse(txtValor.Text);
                txtValor.Text = valor.ToString("N", CultureInfo.CurrentCulture);
            }
        }
        private void txtValor_Enter(object sender, EventArgs e)
        {
            txtValor.Text = "";
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (Producto_id != ""&& Cliente_id!="")
            {
                HistorialClientes historial = new HistorialClientes(Producto_id);
                historial.Show();
            }
            else if (Cliente_id == "")
            {                
                MessageBox.Show("Busque un usuario y seleccione producto");
            }
            else 
            {
                MessageBox.Show("Seleccione un producto");
            }
        }
        private void comboEstadoCliente_SelectedValueChanged(object sender, EventArgs e)
        {
            if (comboEstadoCliente.Text == "Trasferir")
            {
                cliente_producto.EstadoTrasferir(Cliente_id, Producto_id, dateFechaEstado.Text);
                Cliente_id = "";
                LimpiarUsuario();                
            }
            else if (comboEstadoCliente.Text == "Disolver")
            {
                cliente_producto.EstadoDisolver(Cliente_id, Producto_id, dateFechaEstado.Text);
                Panel_Registrar_user.Visible = false;
                CargarClientes();
            }          

        }

        private void dataGridView2_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex >= 0 & e.RowIndex >= 0)
            {
                DataGridViewCell cell = this.dataGridView2.Rows[e.RowIndex].Cells[e.ColumnIndex];
                cell.ToolTipText = "Doble clic para modificar producto";
            }
        }

        private void dataGridView1_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex >= 0 & e.RowIndex >= 0)
            {
                DataGridViewCell cell = this.dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
                cell.ToolTipText = "Doble clic para ver productos";
            }
        }

        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
            ToolTip tt = new ToolTip();
            tt.SetToolTip(this.pictureBox1, "Clic para ver historial cliente");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Producto_id != "" && Cliente_id != "" && Financiacion_id != "")
            {
                HistorialFinanciacion historial = new HistorialFinanciacion(Producto_id);
                historial.Show();
            }
            else if (Cliente_id == "")
            {
                MessageBox.Show("Busque un usuario y seleccione producto");
            }
            else if(Producto_id == "")
            {
                MessageBox.Show("Seleccione un producto");
            }
            else
            {
                MessageBox.Show("Seleccione un producto con financiación");
            }
        }

        private void BtHistorialFinan_MouseHover(object sender, EventArgs e)
        {
            ToolTip tt = new ToolTip();
            tt.SetToolTip(this.BtHistorialFinan, "Clic para ver historial financiación");
        }
    }
}
