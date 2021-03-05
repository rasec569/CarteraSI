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
        CCliente_Producto CliProd = new CCliente_Producto();

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
            //dataGridView2.Columns["Id_Financiacion"].Visible = false;
            //dataGridView2.Columns[10].HeaderText = "Valor+Financiacion";
            //dataGridView2.Columns[11].HeaderText = "Valor Entrada";
            //dataGridView2.Columns[12].HeaderText = "Valor sin Interes";
            //dataGridView2.Columns[13].HeaderText = "Cuotas sin Interes";
            //dataGridView2.Columns[14].HeaderText = "Valor Cuota Sin interes";
            //dataGridView2.Columns[15].HeaderText = "Valor con Interes";
            //dataGridView2.Columns[16].HeaderText = "Cuotas con Interes";
            //dataGridView2.Columns[17].HeaderText = "Valor Cuota Con Interes";
            //dataGridView2.Columns[18].HeaderText = "Porcentaje Interes";
            //dataGridView2.Columns[19].HeaderText = "Fecha Recaudo";
            dataGridView2.Columns["Fk_Id_Proyecto"].Visible = false;
            dataGridView2.Columns["Fk_Id_Tipo_Producto"].Visible = false;

        }
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
                    int retorno = cartera.crearCartera();
                    if (retorno != 0)
                    {
                        Cartera_id = int.Parse(cartera.UltimoRegistro().Rows[0]["max(Id_Cartera)"].ToString());
                        int retorno2 = cliente.crearCliente(int.Parse(txtCedula.Text), txtNombres.Text, txtApellidos.Text, int.Parse(txtTelefono.Text), txtDireccion.Text, txtCorreo.Text, Cartera_id);
                        if (retorno2 != 0)
                        {
                            if (Producto_id == "")
                            {
                                int retorno3 = producto.crearProducto(txtNombreProducto.Text, txtContrato.Text, ComboFormaPago.Items[ComboFormaPago.SelectedIndex].ToString(), int.Parse(txtValor.Text), DateVenta.Text, txtObeservaciones.Text, int.Parse(comboProyecto.SelectedIndex.ToString()), int.Parse(comboTipoProducto.SelectedIndex.ToString()));
                                if (retorno3 != 0)
                                {
                                    Cliente_id = cliente.ultimoCliente().Rows[0]["max(Id_Cliente)"].ToString();
                                    Producto_id = producto.ultimoProducto().Rows[0]["max(Id_Producto)"].ToString();
                                    int retorno4 = CliProd.InsertCliente_Producto(int.Parse(Cliente_id), int.Parse(Producto_id));
                                    if ((ComboFormaPago.Items[ComboFormaPago.SelectedIndex].ToString() == "Financiación") && (retorno4 != 0))
                                    {
                                        financiacion.crearFinanciacion(int.Parse(txtValorFinanciaciom.Text), int.Parse(txtValorEntrada.Text), int.Parse(txtValorSin.Text), int.Parse(txtValorCon.Text), int.Parse(numCuotaSinInteres.Value.ToString()), int.Parse(txtValorCon.Text), int.Parse(numCuotasInteres.ToString()), int.Parse(txtValorCuotaInteres.Text), int.Parse(numValorInteres.ToString()), DateRecaudo.Text, int.Parse(Producto_id));
                                    }
                                }
                            }
                            else
                            {
                                int retorno4 = CliProd.InsertCliente_Producto(int.Parse(Cliente_id), int.Parse(Producto_id));
                                if ((ComboFormaPago.Items[ComboFormaPago.SelectedIndex].ToString() == "Financiación") && (retorno4 != 0))
                                {
                                    financiacion.crearFinanciacion(int.Parse(txtValorFinanciaciom.Text), int.Parse(txtValorEntrada.Text), int.Parse(txtValorSin.Text), int.Parse(txtValorCon.Text), int.Parse(numCuotaSinInteres.Value.ToString()), int.Parse(txtValorCon.Text), int.Parse(numCuotasInteres.ToString()), int.Parse(txtValorCuotaInteres.Text), int.Parse(numValorInteres.ToString()), DateRecaudo.Text, int.Parse(Producto_id));
                                }
                            }
                        }
                    }
                }
                else
                {
                    cliente.actualizarCliente(int.Parse(Cliente_id), int.Parse(txtCedula.Text), txtNombres.Text, txtApellidos.Text, int.Parse(txtTelefono.Text), txtDireccion.Text, txtCorreo.Text, Cartera_id);
                    if ((Producto_id == "") && (txtNombreProducto.Text != ""))
                    {
                        int retorno = producto.crearProducto(txtNombreProducto.Text, txtContrato.Text, ComboFormaPago.Items[ComboFormaPago.SelectedIndex].ToString(), int.Parse(Convert.ToDouble(txtValor.Text).ToString()), DateVenta.Text, txtObeservaciones.Text, int.Parse(comboProyecto.SelectedIndex.ToString()), int.Parse(comboTipoProducto.SelectedIndex.ToString()));

                        if (retorno != 0)
                        {
                            Producto_id = producto.ultimoProducto().Rows[0]["max(Id_Producto)"].ToString();
                            int retorno2 = CliProd.InsertCliente_Producto(int.Parse(Cliente_id), int.Parse(Producto_id));
                            if ((retorno2 != 0) && (ComboFormaPago.Items[ComboFormaPago.SelectedIndex].ToString() == "Financiación"))
                            {
                                financiacion.crearFinanciacion(int.Parse(txtValorFinanciaciom.Text), int.Parse(txtValorEntrada.Text), int.Parse(txtValorSin.Text), int.Parse(txtValorCon.Text), int.Parse(numCuotaSinInteres.Value.ToString()), int.Parse(txtValorCon.Text), int.Parse(numCuotasInteres.ToString()), int.Parse(txtValorCuotaInteres.Text), int.Parse(numValorInteres.ToString()), DateRecaudo.Text, int.Parse(Producto_id));
                            }
                        }
                    }
                    else if (txtNombreProducto.Text !="")
                    {
                        producto.actualizarProducto(int.Parse(Producto_id), txtNombreProducto.Text, txtContrato.Text, ComboFormaPago.Items[ComboFormaPago.SelectedIndex].ToString(), int.Parse(txtValor.Text), DateVenta.Text, txtObeservaciones.Text, int.Parse(comboProyecto.SelectedIndex.ToString()), int.Parse(comboTipoProducto.SelectedIndex.ToString()));
                        if (ComboFormaPago.Items[ComboFormaPago.SelectedIndex].ToString() == "Financiación")
                        {
                            financiacion.actualizarFinanciacion(int.Parse(Financiacion_id), int.Parse(txtValorFinanciaciom.Text), int.Parse(txtValorEntrada.Text), int.Parse(txtValorSin.Text), int.Parse(txtValorCon.Text), int.Parse(numCuotaSinInteres.Value.ToString()), int.Parse(txtValorCon.Text), int.Parse(numCuotasInteres.ToString()), int.Parse(txtValorCuotaInteres.Text), int.Parse(numValorInteres.ToString()), DateRecaudo.Text, int.Parse(Producto_id));
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
            txtValorSin.Clear();
            txtValorEntrada.Clear();
            txtValorCon.Clear();
            txtObeservaciones.Clear();
            txtValorCuotaInteres.Clear();
            ComboFormaPago.SelectedValue = 0;
            numCuotaSinInteres.ResetText();
            numCuotaSinInteres.ResetText();
            //DateVenta.Clear();
            //DateRecaudo.Clear();
            //comboProyecto.Clear();
            //comboTipoProducto.Clear();
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
            LimpiarUsuario();
            LimpiarProducto();
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
            int n = e.RowIndex;
            if (n != -1)
            {
                Panel_Registrar_user.Visible = true;
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
                    //txtValor.Text = dataGridView2.Rows[n].Cells["Valor_Total"].Value.ToString();
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

                        txtValorSin.Text = dataGridView2.Rows[n].Cells["Valor_Sin_interes"].Value.ToString();
                        txtValorEntrada.Text = dataGridView2.Rows[n].Cells["Valor_Entrada"].Value.ToString();
                        txtValorCon.Text = dataGridView2.Rows[n].Cells["Valor_Con_Interes"].Value.ToString();
                        DateRecaudo.Text = dataGridView2.Rows[n].Cells["Fecha_Recaudo"].Value.ToString();
                        txtValorCuotaInteres.Text = dataGridView2.Rows[n].Cells["Valor_Cuota_Con_Interes"].Value.ToString();
                        txtValorCuotaSin.Text = dataGridView2.Rows[n].Cells["Valor_Cuota_Sin_interes"].Value.ToString();
                        numValorInteres.Text = dataGridView2.Rows[n].Cells["Valor_Interes"].Value.ToString();
                        numCuotaSinInteres.Text = dataGridView2.Rows[n].Cells["Cuotas_Sin_interes"].Value.ToString();
                        numCuotasInteres.Text = dataGridView2.Rows[n].Cells["Cuotas_Con_Interes"].Value.ToString();
                    }

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
        }

        private void ComboFormaPago_SelectedValueChanged(object sender, EventArgs e)
        {
            if (ComboFormaPago.Items[ComboFormaPago.SelectedIndex].ToString() == "Contado")
            {
                Bloquear_Financiado();
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
            double valor = ((Convert.ToDouble(txtValorCon.Text) * (Convert.ToDouble(numValorInteres.Value / 100))) + Convert.ToDouble(txtValorCon.Text)) / Convert.ToDouble(numCuotasInteres.Value);
            txtValorCuotaInteres.Clear();
            txtValorCuotaInteres.Text = valor.ToString();
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
                int val_total;
                    txtValorSin.Clear();
                    txtValorCon.Clear();
                    val_total = Convert.ToInt32(txtValor.Text);
                    double Exectos = 0.3 * val_total;
                    double Con_interes = 0.7 * val_total;
                    txtValorSin.Text = Exectos.ToString();
                    txtValorCon.Text = Con_interes.ToString();
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
            HistorialClientes historial = new HistorialClientes(Cliente_id);
            historial.Show();
        }
    }
}
