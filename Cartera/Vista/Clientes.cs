using Cartera.Controlador;
using Cartera.Reportes;
using System;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cartera.Vista
{

    public partial class Clientes : Form
    {
        Loading cargando;
        CCartera cartera = new CCartera();
        CCliente cliente = new CCliente();
        CCuota cuota = new CCuota();
        CProducto producto = new CProducto();
        CTipo_Producto tipo_producto = new CTipo_Producto();
        CProyecto proyecto = new CProyecto();
        CFinanciacion financiacion = new CFinanciacion();
        CCliente_Producto cliente_producto = new CCliente_Producto();
        private ReportesPDF reportesPDF;

        bool error = false;
        DataTable DtCliente = new DataTable();
        DataTable DtReportes = new DataTable();
        DataTable Dtproyectos = new DataTable();
        public static int Cartera_id = 0;
        public static string Cliente_id = "";
        public static string Producto_id = "";
        public static string Financiacion_id = "";
        public static int valor = 0;
        string actual = DateTime.ParseExact(DateTime.Now.ToString("yyyy-MM-dd"), "yyyy-MM-dd", CultureInfo.InvariantCulture).ToString();


        public Clientes()
        {
            reportesPDF = new ReportesPDF();
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
        private void Clientes_Load(object sender, EventArgs e)
        {
            autocompletar();
            //CargarClientes();
            Bloquear_Financiado();
            comboProyecto.DataSource = proyecto.listarProyectos();
            comboProyecto.DisplayMember = "Proyecto_Nombre";
            comboProyecto.ValueMember = "Id_Proyecto"; 

            comboTipoProducto.DataSource = tipo_producto.listarTipoProducto();
            comboTipoProducto.DisplayMember = "Nom_Tipo_Producto";
            comboTipoProducto.ValueMember = "Id_Tipo_Producto";

            Dtproyectos = proyecto.listarProyectos();
            DataRow nueva = Dtproyectos.NewRow();
            nueva["Id_Proyecto"] = 4;
            nueva["Proyecto_Nombre"] = "TODOS LOS PROYECTOS";
            Dtproyectos.Rows.InsertAt(nueva, 0);
            comboProyectos.DataSource = Dtproyectos;
            comboProyectos.DisplayMember = "Proyecto_Nombre";
            comboProyectos.ValueMember = "Id_Proyecto";
        }
        private void BtBuscarCliente_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtBuscarCliente.Text != "")
                {
                    Panel_Registrar_user.Visible = true;
                    string cliente = txtBuscarCliente.Text;
                    dataGridView2.DataSource = "";
                    LimpiarUsuario();
                    LimpiarProducto();
                    DataTable DtUsuario = this.cliente.BuscarClientesCedula(cliente);
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
                    comboProyectos.Enabled = false;
                    label26.Enabled = false;
                    button2.Enabled = false;
                    button4.Enabled = false;
                }
                else
                {
                    MessageBox.Show("ingrese una cedula a buscar");
                }
            }
            catch
            {
                MessageBox.Show("error");
            }
        }
        private void CargarClientes()
        {
            DtCliente = cliente.cargarClientes();
            DtReportes = DtCliente.Copy();                        
            DtReportes.Columns.Remove("Id_Cliente");
            DtReportes.Columns.Remove("Fk_Id_Cartera");
            dataGridView1.DataSource = DtCliente;
            formatogrid();
            dataGridView1.Columns["Id_Cliente"].Visible = false;
            dataGridView1.Columns["Fk_Id_Cartera"].Visible = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dataGridView1.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dataGridView1_RowPostPaint);
            

        }
        private void formatogrid()
        {
            dataGridView1.Columns[1].Width = 70;
            dataGridView1.Columns[2].Width = 140;
            dataGridView1.Columns[3].Width = 140;
            dataGridView1.Columns[4].Width = 70;
            dataGridView1.Columns[5].Width = 160;
            dataGridView1.Columns[6].Width = 170;
        }
        private void CargarProducto()
        {
            dataGridView2.DataSource = producto.cargarProductosCliente(int.Parse(Cliente_id));
            dataGridView2.Columns["Id_Producto"].Visible = false;
            dataGridView2.Columns["Observaciones"].Visible = false;
            dataGridView2.Columns["Fk_Id_Proyecto"].Visible = false;
            dataGridView2.Columns["Fk_Id_Tipo_Producto"].Visible = false;
            dataGridView2.Columns[4].DefaultCellStyle.Format = "n0";
            dataGridView2.Columns[5].DefaultCellStyle.Format = "n0";
            dataGridView2.Columns[6].DefaultCellStyle.Format = "n0";
            dataGridView2.Columns[1].Width = 70;
            dataGridView2.Columns[2].Width = 70;
            dataGridView2.Columns[3].Width = 75;
            dataGridView2.Columns[4].Width = 70;
            dataGridView2.Columns[5].Width = 70;
            dataGridView2.Columns[6].Width = 70;
            dataGridView2.Columns[7].Width = 70;
            dataGridView2.Columns[9].Width = 240;
            dataGridView2.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dataGridView2.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dataGridView2_RowPostPaint);
        }        
        void autocompletar()
        {
            AutoCompleteStringCollection lista = new AutoCompleteStringCollection();            

            DtCliente = cliente.cargarClientes();
            for (int i = 0; i < DtCliente.Rows.Count; i++)
            {
                lista.Add(DtCliente.Rows[i]["Cedula"].ToString());
            }
            txtBuscarCliente.AutoCompleteCustomSource = lista;
        }
        private bool ValidarCampos()
        {
            bool ok = true;
            if (txtCedula.Text == "")
            {
                ok = false;
                errorProvider1.SetError(txtCedula, "Digite una cedula");
            }
            if (txtCedula.TextLength > 10)
            {
                ok = false;
                errorProvider1.SetError(txtCedula, "Numero de cedula incorrecta");
            }
            if (txtNombres.Text == "")
            {
                ok = false;
                errorProvider1.SetError(txtNombres, "Digite un nombre");
            }
            if (txtApellidos.Text == "")
            {
                ok = false;
                errorProvider1.SetError(txtApellidos, "Digite un apellido");
            }
            if (txtTelefono.Text == "")
            {
                ok = false;
                errorProvider1.SetError(txtTelefono, "Digite un telefono");
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
                if (ComboFormaPago.Text == "seleccione una opción")
                {
                    ok = false;
                    errorProvider1.SetError(this.ComboFormaPago, "Seleccione forma de pago");
                }
                if (txtValor.Text == "")
                {
                    ok = false;
                    errorProvider1.SetError(txtValor, "Digite el valor del producto");
                }
                if (comboProyecto.Text == "seleccione una opción")
                {
                    ok = false;
                    errorProvider1.SetError(this.comboProyecto, "Seleccione un proyecto");
                }
                if (comboTipoProducto.Text == "seleccione una opción")
                {
                    ok = false;
                    errorProvider1.SetError(this.comboTipoProducto, "Seleccione un tipo producto");
                }
                if (ComboFormaPago.Text == "Financiado")
                {
                    if (txtValorSin.Text == "")
                    {
                        ok = false;
                        errorProvider1.SetError(this.txtValorSin, "Debe ingresar un valor");
                    }
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
                    if (comboEstadoCliente.Text == "Ceder")
                    {
                        //Proceso ceder
                        int rt = cartera.crearCartera();
                        if (rt != 0)
                        {
                            Cartera_id = int.Parse(cartera.UltimoRegistro().Rows[0]["max(Id_Cartera)"].ToString());
                            int rt2 = cliente.crearCliente(txtCedula.Text, txtNombres.Text, txtApellidos.Text, txtTelefono.Text, txtDireccion.Text, txtCorreo.Text, Cartera_id);
                            if (rt2 != 0)
                            {
                                Cliente_id = cliente.ultimoCliente().Rows[0]["max(Id_Cliente)"].ToString();
                                int rt3 = cliente_producto.InsertCliente_Producto(Cliente_id, Producto_id);
                                if (rt3 != 0)
                                {
                                    int rt4 = producto.actualizarProducto(int.Parse(Producto_id), txtNombreProducto.Text, txtContrato.Text, ComboFormaPago.Text, int.Parse(Convert.ToDouble(txtValor.Text).ToString()), int.Parse(Convert.ToDouble(txtValorTotal.Text).ToString()), DateVenta.Text, txtObeservaciones.Text, int.Parse(comboProyecto.SelectedValue.ToString()), int.Parse(comboTipoProducto.SelectedValue.ToString()));
                                    cartera.ActulizarValorTotal(int.Parse(Cliente_id), Cartera_id);
                                    if ((rt4 != 0) && (ComboFormaPago.Text == "Financiado"))
                                    {
                                        //ya convertido
                                        financiacion.crearFinanciacion(int.Parse(Convert.ToDouble(txtValorTotal.Text).ToString()), int.Parse(Convert.ToDouble(txtValorEntrada.Text).ToString()), int.Parse(Convert.ToDouble(txtValorSin.Text).ToString()), int.Parse(Convert.ToDouble(txtValorCuotaSin.Text).ToString()), int.Parse(numCuotaSinInteres.Value.ToString()), int.Parse(Convert.ToDouble(txtValorCon.Text).ToString()), int.Parse(numCuotasInteres.Value.ToString()), int.Parse(Convert.ToDouble(txtValorCuotaInteres.Text).ToString()), int.Parse(numValorInteres.Value.ToString()), DateRecaudo.Text, Producto_id);
                                        CrearCuotas();
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        int retorno = cartera.crearCartera();
                        if (retorno != 0)
                        {
                            Cartera_id = int.Parse(cartera.UltimoRegistro().Rows[0]["max(Id_Cartera)"].ToString());
                            int retorno2 = cliente.crearCliente(txtCedula.Text, txtNombres.Text, txtApellidos.Text, txtTelefono.Text, txtDireccion.Text, txtCorreo.Text, Cartera_id);
                            if (retorno2 != 0)
                            {
                                if (Producto_id == "")
                                {
                                    int retorno3 = producto.crearProducto(txtNombreProducto.Text, txtContrato.Text, ComboFormaPago.Text, int.Parse(Convert.ToDouble(txtValor.Text).ToString()), int.Parse(Convert.ToDouble(txtValorTotal.Text).ToString()), DateVenta.Text, txtObeservaciones.Text, int.Parse(comboProyecto.SelectedValue.ToString()), int.Parse(comboTipoProducto.SelectedValue.ToString()));
                                    if (retorno3 != 0)
                                    {
                                        Cliente_id = cliente.ultimoCliente().Rows[0]["max(Id_Cliente)"].ToString();
                                        Producto_id = producto.ultimoProducto().Rows[0]["max(Id_Producto)"].ToString();
                                        int retorno4 = cliente_producto.InsertCliente_Producto(Cliente_id, Producto_id);
                                        cartera.ActulizarValorTotal(int.Parse(Cliente_id), Cartera_id);
                                        if ((ComboFormaPago.Text == "Financiado") && (retorno4 != 0))
                                        {
                                            //aqui se daña
                                            financiacion.crearFinanciacion(int.Parse(Convert.ToDouble(txtValorTotal.Text).ToString()), int.Parse(Convert.ToDouble(txtValorEntrada.Text).ToString()), int.Parse(Convert.ToDouble(txtValorSin.Text).ToString()), int.Parse(Convert.ToDouble(txtValorCuotaSin.Text).ToString()), int.Parse(numCuotaSinInteres.Value.ToString()), int.Parse(Convert.ToDouble(txtValorCon.Text).ToString()), int.Parse(numCuotasInteres.Value.ToString()), int.Parse(Convert.ToDouble(txtValorCuotaInteres.Text).ToString()), int.Parse(numValorInteres.Value.ToString()), DateRecaudo.Text, Producto_id);
                                            CrearCuotas();
                                            //financiacion.crearFinanciacion(int.Parse(Convert.ToDouble(txtValorTotal.Text).ToString()), int.Parse(Convert.ToDouble(txtValorEntrada.Text).ToString()), int.Parse(Convert.ToDouble(txtValorSin.Text).ToString()), int.Parse(Convert.ToDouble(txtValorCuotaSin.Text).ToString()), int.Parse(numCuotaSinInteres.Value.ToString()), int.Parse(Convert.ToDouble(txtValorCon.Text).ToString()), int.Parse(numCuotasInteres.Value.ToString()), int.Parse(Convert.ToDouble(txtValorCuotaInteres.Text).ToString()), int.Parse(numValorInteres.Value.ToString()), DateRecaudo.Text, Producto_id);
                                        }
                                    }
                                }
                                else
                                {
                                    int retorno4 = cliente_producto.InsertCliente_Producto(Cliente_id, Producto_id);
                                    if ((ComboFormaPago.Text == "Financiado") && (retorno4 != 0))
                                    {
                                        financiacion.crearFinanciacion(int.Parse(Convert.ToDouble(txtValorTotal.Text).ToString()), int.Parse(Convert.ToDouble(txtValorEntrada.Text).ToString()), int.Parse(Convert.ToDouble(txtValorSin.Text).ToString()), int.Parse(Convert.ToDouble(txtValorCuotaSin.Text).ToString()), int.Parse(numCuotaSinInteres.Value.ToString()), int.Parse(Convert.ToDouble(txtValorCon.Text).ToString()), int.Parse(numCuotasInteres.Value.ToString()), int.Parse(Convert.ToDouble(txtValorCuotaInteres.Text).ToString()), int.Parse(numValorInteres.Value.ToString()), DateRecaudo.Text, Producto_id);
                                        CrearCuotas();
                                    }
                                }
                            }
                        }

                    }
                }
                else
                {
                    cliente.actualizarCliente(Cliente_id, txtCedula.Text, txtNombres.Text, txtApellidos.Text, txtTelefono.Text, txtDireccion.Text, txtCorreo.Text, Cartera_id);
                    if ((Producto_id == "") && (txtNombreProducto.Text != ""))
                    {
                        int retorno = producto.crearProducto(txtNombreProducto.Text, txtContrato.Text, ComboFormaPago.Text, int.Parse(Convert.ToDouble(txtValor.Text).ToString()), int.Parse(Convert.ToDouble(txtValorTotal.Text).ToString()), DateVenta.Text, txtObeservaciones.Text, int.Parse(comboProyecto.SelectedValue.ToString()), int.Parse(comboTipoProducto.SelectedValue.ToString()));

                        if (retorno != 0)
                        {
                            Producto_id = producto.ultimoProducto().Rows[0]["max(Id_Producto)"].ToString();
                            cartera.ActulizarValorTotal(int.Parse(Cliente_id), Cartera_id);
                            int retorno2 = cliente_producto.InsertCliente_Producto(Cliente_id, Producto_id);
                            if ((retorno2 != 0) && (ComboFormaPago.Text == "Financiado"))
                            {
                                financiacion.crearFinanciacion(int.Parse(Convert.ToDouble(txtValorTotal.Text).ToString()), int.Parse(Convert.ToDouble(txtValorEntrada.Text).ToString()), int.Parse(Convert.ToDouble(txtValorSin.Text).ToString()), int.Parse(Convert.ToDouble(txtValorCuotaSin.Text).ToString()), int.Parse(numCuotaSinInteres.Value.ToString()), int.Parse(Convert.ToDouble(txtValorCon.Text).ToString()), int.Parse(numCuotasInteres.Value.ToString()), int.Parse(Convert.ToDouble(txtValorCuotaInteres.Text).ToString()), int.Parse(numValorInteres.Value.ToString()), DateRecaudo.Text, Producto_id);
                                CrearCuotas();
                            }
                        }
                    }
                    else if (txtNombreProducto.Text != "")
                    {
                        producto.actualizarProducto(int.Parse(Producto_id), txtNombreProducto.Text, txtContrato.Text, ComboFormaPago.Text, int.Parse(Convert.ToDouble(txtValor.Text).ToString()), int.Parse(Convert.ToDouble(txtValorTotal.Text).ToString()), DateVenta.Text, txtObeservaciones.Text, int.Parse(comboProyecto.SelectedValue.ToString()), int.Parse(comboTipoProducto.SelectedValue.ToString()));
                        cartera.ActulizarValorTotal(int.Parse(Cliente_id), Cartera_id);
                        if ((ComboFormaPago.Text == "Financiado") & (checkBox1.Checked == false))
                        {
                            //aqui
                            financiacion.actualizarFinanciacion(int.Parse(Financiacion_id), int.Parse(Convert.ToDouble(txtValorTotal.Text).ToString()), int.Parse(Convert.ToDouble(txtValorEntrada.Text).ToString()), int.Parse(Convert.ToDouble(txtValorSin.Text).ToString()), int.Parse(Convert.ToDouble(txtValorCuotaSin.Text).ToString()), int.Parse(numCuotaSinInteres.Value.ToString()), int.Parse(Convert.ToDouble(txtValorCon.Text).ToString()), int.Parse(numCuotasInteres.Value.ToString()), int.Parse(Convert.ToDouble(txtValorCuotaInteres.Text).ToString()), int.Parse(numValorInteres.Value.ToString()), DateRecaudo.Text, int.Parse(Producto_id));                            
                        }
                        else
                        {
                            financiacion.InactivarFinanciacion(int.Parse(Financiacion_id));
                            financiacion.CambiarFinanciacion(int.Parse(Financiacion_id), int.Parse(Convert.ToDouble(txtValorTotal.Text).ToString()), int.Parse(Convert.ToDouble(txtValorEntrada.Text).ToString()), int.Parse(Convert.ToDouble(txtValorSin.Text).ToString()), int.Parse(Convert.ToDouble(txtValorCuotaSin.Text).ToString()), int.Parse(numCuotaSinInteres.Value.ToString()), int.Parse(Convert.ToDouble(txtValorCon.Text).ToString()), int.Parse(numCuotasInteres.Value.ToString()), int.Parse(Convert.ToDouble(txtValorCuotaInteres.Text).ToString()), int.Parse(numValorInteres.Value.ToString()), DateRecaudo.Text, int.Parse(Producto_id));
                            CrearCuotas();
                            checkBox1.Checked = false;
                        }
                    }
                }
                BtBuscarCliente.Enabled = true;
                Panel_Registrar_user.Visible = false;
                //Panel_Clientes.Visible = true;
                CargarClientes();
                autocompletar();
            }
        }
        public void CrearCuotas()
        {
            DateTime date = DateTime.ParseExact(DateRecaudo.Text, "yyyy-MM-dd", CultureInfo.InvariantCulture);

            int num_cuota = 0;
            int contador = 1;
            string Estado = "Pendiente";
            DataTable Dtfinan = financiacion.FinanciacionProducto(int.Parse(Producto_id));

            cuota.CrearCuota(num_cuota, int.Parse(Convert.ToDouble(txtValorEntrada.Text).ToString()), "Valor Separación", date.ToString("yyyy-MM-dd"), Estado, int.Parse(Dtfinan.Rows[0]["Id_Financiacion"].ToString()));

            num_cuota++;

            while (num_cuota <= int.Parse(numCuotaSinInteres.Value.ToString()))
            {
                cuota.CrearCuota(num_cuota, int.Parse(Convert.ToDouble(txtValorCuotaSin.Text).ToString()), "Valor Inicial", date.AddMonths(contador - 1).ToString("yyyy-MM-dd"), Estado, int.Parse(Dtfinan.Rows[0]["Id_Financiacion"].ToString()));
                contador++;
                num_cuota++;
            }
            num_cuota = 1;
            while (num_cuota <= int.Parse(numCuotasInteres.Value.ToString()))
            {
                cuota.CrearCuota(num_cuota, int.Parse(Convert.ToDouble(txtValorCuotaInteres.Text).ToString()), "Valor Saldo", date.AddMonths(contador - 1).ToString("yyyy-MM-dd"), Estado, int.Parse(Dtfinan.Rows[0]["Id_Financiacion"].ToString()));
                contador++;
                num_cuota++;
            }
        }
        private void LimpiarProducto()
        {
            txtNombreProducto.Clear();
            txtContrato.Clear();
            txtValor.Clear();
            txtObeservaciones.Clear();
            ComboFormaPago.Text = "seleccione una opción";
            comboProyecto.Text = "seleccione una opción";
            comboTipoProducto.Text = "seleccione una opción";
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
            numValorInteres.Text = "";
            numCuotasInteres.Text = "";
            numCuotaSinInteres.Text = "";
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
            dateFechaEstado.Visible = false;
            comboEstadoCliente.Visible = false;
            LimpiarUsuario();
            LimpiarProducto();
            Bloquear_Financiado();
            BtBuscarCliente.Enabled = false;
            button2.Enabled = false;
            button4.Enabled = false;
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
                    comboProyectos.Enabled = false;
                    label26.Enabled = false;
                    button2.Enabled = false;
                    button4.Enabled = false;
                    Panel_Registrar_user.Visible = true;
                    BtGuardarCliente.Enabled = true;
                    LimpiarUsuario();
                    LimpiarProducto();
                    Cliente_id = dataGridView1.Rows[n].Cells["Id_Cliente"].Value.ToString();
                    txtCedula.Text = dataGridView1.Rows[n].Cells["Cedula"].Value.ToString();
                    txtNombres.Text = dataGridView1.Rows[n].Cells["Nombres"].Value.ToString();
                    txtApellidos.Text = dataGridView1.Rows[n].Cells["Apellidos"].Value.ToString();
                    txtTelefono.Text = dataGridView1.Rows[n].Cells["Telefono"].Value.ToString();
                    txtDireccion.Text = dataGridView1.Rows[n].Cells["Dirección"].Value.ToString();
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
                    txtNombreProducto.Text = dataGridView2.Rows[n].Cells["Producto"].Value.ToString();
                    txtContrato.Text = dataGridView2.Rows[n].Cells["Contrato"].Value.ToString();
                    // fotmatear campo valor
                    valor = int.Parse(dataGridView2.Rows[n].Cells["Valor Final"].Value.ToString());
                    int Neto = int.Parse(dataGridView2.Rows[n].Cells["Valor Neto"].Value.ToString());
                    txtValor.Text = Neto.ToString("N0", CultureInfo.CurrentCulture);
                    txtObeservaciones.Text = dataGridView2.Rows[n].Cells["Observaciones"].Value.ToString();
                    DateVenta.Text = dataGridView2.Rows[n].Cells["Fecha Venta"].Value.ToString();

                    string forma_pago = dataGridView2.Rows[n].Cells["Forma Pago"].Value.ToString();
                    ComboFormaPago.Text = forma_pago;
                    comboProyecto.DataSource = proyecto.listarProyectos();
                    comboProyecto.DisplayMember = "Proyecto_Nombre";
                    comboProyecto.ValueMember = "Id_Proyecto";
                    comboProyecto.SelectedIndex = int.Parse(dataGridView2.Rows[n].Cells["Fk_Id_Proyecto"].Value.ToString());
                    comboTipoProducto.DataSource = tipo_producto.listarTipoProducto();
                    comboTipoProducto.DisplayMember = "Nom_Tipo_Producto";
                    comboTipoProducto.ValueMember = "Id_Tipo_Producto";
                    comboTipoProducto.SelectedIndex = int.Parse(dataGridView2.Rows[n].Cells["Fk_Id_Tipo_Producto"].Value.ToString());
                    if (forma_pago == "Financiado")
                    {
                        DataTable DtFinanciacion = financiacion.FinanciacionProducto(int.Parse(Producto_id));
                        Financiacion_id = DtFinanciacion.Rows[0]["Id_Financiacion"].ToString();
                        //txtValorTotal.Text = DtFinanciacion.Rows[0]["Valor_Producto_Financiacion"].ToString();
                        int ValorSin = int.Parse(DtFinanciacion.Rows[0]["Valor_Sin_interes"].ToString());
                        txtValorSin.Text = ValorSin.ToString("N0", CultureInfo.CurrentCulture);
                        int ValorEntr = int.Parse(DtFinanciacion.Rows[0]["Valor_Entrada"].ToString());
                        txtValorEntrada.Text = ValorEntr.ToString("N0", CultureInfo.CurrentCulture);
                        int ValorCon = int.Parse(DtFinanciacion.Rows[0]["Valor_Con_Interes"].ToString());
                        txtValorCon.Text = ValorCon.ToString("N0", CultureInfo.CurrentCulture);
                        DateRecaudo.Text = DtFinanciacion.Rows[0]["Fecha_Recaudo"].ToString();
                        numCuotaSinInteres.Text = DtFinanciacion.Rows[0]["Cuotas_Sin_interes"].ToString();
                        numCuotasInteres.Text = DtFinanciacion.Rows[0]["Cuotas_Con_Interes"].ToString();
                        int valorcuotasin = int.Parse(DtFinanciacion.Rows[0]["Valor_Cuota_Sin_interes"].ToString());
                        txtValorCuotaSin.Text = valorcuotasin.ToString("N0", CultureInfo.CurrentCulture);
                        numValorInteres.Text = DtFinanciacion.Rows[0]["Valor_Interes"].ToString();
                        int valorcuotaint = int.Parse(DtFinanciacion.Rows[0]["Valor_Cuota_Con_Interes"].ToString());
                        txtValorCuotaInteres.Text = valorcuotaint.ToString("N0", CultureInfo.CurrentCulture);
                    }
                    int total = int.Parse(dataGridView2.Rows[n].Cells["Valor Final"].Value.ToString());
                    txtValorTotal.Text = total.ToString("N0", CultureInfo.CurrentCulture);                   
                    label24.Visible = true;
                    comboEstadoCliente.Visible = true;
                    dateFechaEstado.Visible = true;
                    //txtValorTotal.Text = valor.ToString("N0", CultureInfo.CurrentCulture);
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
            //if para validar campos
            if (!string.IsNullOrEmpty(txtValorSin.Text)  && !string.IsNullOrEmpty(txtValorEntrada.Text))
            {
                double valor30 = (Convert.ToDouble(txtValorSin.Text) - Convert.ToDouble(txtValorEntrada.Text));
                if (valor30 == 0)
                {
                    numCuotaSinInteres.Text = "0";
                    txtValorCuotaSin.Text = "0";
                    txtValorCuotaSin.Enabled = false;
                    numCuotaSinInteres.Enabled = false;
                }
                else
                {
                    txtValorCuotaSin.Enabled = true;
                    numCuotaSinInteres.Enabled = true;
                }
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
            if (txtValorCon.Text=="0")
            {
                numCuotasInteres.Text = "0";                
                txtValorCuotaInteres.Text = "0";
                numValorInteres.Text = "0";
                numCuotasInteres.Enabled = false;
                numValorInteres.Enabled = false;
                txtValorCuotaInteres.Enabled = false;
                string valTotal = int.Parse(Convert.ToDouble(txtValorSin.Text).ToString()).ToString();
                txtValorTotal.Text = String.Format("{0:N0}", Convert.ToDouble(valTotal));
            }
            else
            {
                numCuotasInteres.Enabled = true;
                numValorInteres.Enabled = true;
                txtValorCuotaInteres.Enabled = true;
            }
        }
        private void txtValor_Leave(object sender, EventArgs e)
        {
            //try
            //{
            //    if (ComboFormaPago.Text == "Financiado")
            //    {
            //        txtValorSin.Clear();
            //        txtValorCon.Clear();
            //        val_total = Convert.ToInt32(txtValor.Text);
            //        double Exectos = 0.3 * val_total;
            //        double Con_interes = 0.7 * val_total;
            //        txtValorSin.Text = String.Format("{0:N0}", Exectos);
            //        txtValorCon.Text = String.Format("{0:N0}", Con_interes);
            //    }
            //    else
            //    {
            //        valor = int.Parse(txtValor.Text);
            //        txtValorTotal.Text = valor.ToString("N", CultureInfo.CurrentCulture);
            //    }

            //}
            //catch
            //{
            //    MessageBox.Show("Valor no admitido");
            //    errorProvider1.SetError(txtValorEntrada, "No se admiten letras");
            //}
            try
            {
                if (ComboFormaPago.Text == "Contado")
                {
                    valor = int.Parse(txtValor.Text);
                    txtValorTotal.Text = valor.ToString("N0", CultureInfo.CurrentCulture);
                }
                if (!string.IsNullOrEmpty(txtValor.Text))
                {
                    valor = int.Parse(txtValor.Text);
                    txtValor.Text = valor.ToString("N0", CultureInfo.CurrentCulture);
                }
            }
            catch
            {
                MessageBox.Show("Valor no admitido");
                errorProvider1.SetError(txtValorEntrada, "Error");
            }
        }
        private void txtValor_Enter(object sender, EventArgs e)
        {
            txtValor.Text = "";
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (Producto_id != "" && Cliente_id != "")
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
            if (comboEstadoCliente.Text == "Ceder")
            {
                cliente_producto.EstadoTrasferir(Cliente_id, Producto_id, dateFechaEstado.Text);
                Cliente_id = "";
                LimpiarUsuario();
            }
            else if (comboEstadoCliente.Text == "Disolver")
            {
                if (MessageBox.Show("¿Está seguro de Disolver el contrato?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    DataTable DtCartera = cartera.CarteraCliente(txtCedula.Text);
                    cartera.ActulizarEstados(Cartera_id.ToString(), "Disuelto", int.Parse(DtCartera.Rows[0]["Cuotas Pact."].ToString()), int.Parse(DtCartera.Rows[0]["Cuotas Pag."].ToString()), int.Parse(DtCartera.Rows[0]["Cuotas Mora"].ToString()), int.Parse(DtCartera.Rows[0]["Meses Mora"].ToString()));
                    cliente_producto.EstadoDisolver(Cliente_id, Producto_id, dateFechaEstado.Text);
                    Panel_Registrar_user.Visible = false;                    
                    cartera.ActulizarValorTotal(int.Parse(Cliente_id.ToString()), Cartera_id);
                    cartera.ActulizarValorRecaudado(int.Parse(Cliente_id));
                    cartera.ActulizarSaldo(Cartera_id); 
                    CargarClientes();
                }                    
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
                historial.ShowDialog();
            }
            else if (Cliente_id == "")
            {
                MessageBox.Show("Busque un usuario y seleccione producto");
            }
            else if (Producto_id == "")
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
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            LimpiarFinanciacion();
        }
        private void txtValorSin_Leave(object sender, EventArgs e)
        {
            try
            {
                //if (txtValorSin.Text != "")
                //{
                //    txtValorCon.Text = String.Format("{0:N0}", (val_total - int.Parse(txtValorSin.Text)));
                //}
                if (!string.IsNullOrEmpty(txtValorSin.Text))
                {
                    valor = int.Parse(txtValorSin.Text);
                    txtValorSin.Text = valor.ToString("N0", CultureInfo.CurrentCulture);
                }
            }
            catch
            {

            }                                
        }
        private void numCuotaSinInteres_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (ComboFormaPago.Text == "Financiado")
                {
                    if (txtValorEntrada.Text != "")                        
                    {
                        double valor30= (Convert.ToDouble(txtValorSin.Text) - Convert.ToDouble(txtValorEntrada.Text)) / Convert.ToDouble(numCuotaSinInteres.Value);
                        txtValorCuotaSin.Clear();
                        txtValorCuotaSin.Text = String.Format("{0:N0}", valor30);
                        
                    }
                    else
                    {
                        MessageBox.Show("No hay valor inicial");
                    }
                }

            }
            catch
            {
                MessageBox.Show("Digite el valor 30");
            }                                  
        }

        private void numCuotasInteres_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (ComboFormaPago.Text == "Financiado")
                {
                    double valor70 = Convert.ToDouble(txtValorCon.Text);
                    double cuotas70 = Convert.ToDouble(numCuotasInteres.Value);
                    if (numCuotasInteres.Value <= 18)
                    {
                        numValorInteres.Text = "0";
                    }
                    else
                    {
                        numValorInteres.Text = "1";
                        //double valorinteres = (Convert.ToDouble(txtValorCon.Text) * (Convert.ToDouble(numValorInteres.Value) / 100));
                        //double valorcuota = (valor70 + valorinteres) / cuotas70;
                        //txtValorCuotaInteres.Clear();
                        //txtValorCuotaInteres.Text = String.Format("{0:N0}", valorcuota);
                        //double valorneto = int.Parse(Convert.ToDouble(txtValor.Text).ToString());
                        //txtValorTotal.Text = String.Format("{0:N0}", (valorneto + valorinteres));
                    }

                    double valorcuota = valor70 / cuotas70;
                    txtValorCuotaInteres.Clear();
                    txtValorCuotaInteres.Text = String.Format("{0:N0}", valorcuota);
                    int valTotal = int.Parse(Convert.ToDouble(txtValorSin.Text).ToString()) + int.Parse(Convert.ToDouble(txtValorCon.Text).ToString());
                    txtValorTotal.Text = valTotal.ToString();
                    txtValorTotal.Text = String.Format("{0:N0}", Convert.ToDouble(txtValorTotal.Text));


                }                
            }
            catch
            {
                MessageBox.Show("Digite el valor 70");
            }                       
        }
        private void txtValorEntrada_Leave(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtValorEntrada.Text))
                {
                    int valor;
                    valor = int.Parse(txtValorEntrada.Text);
                    txtValorEntrada.Text = valor.ToString("N0", CultureInfo.CurrentCulture);
                }                
            }
            catch
            {
            }            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            reportesPDF.Clientes(DtReportes);
        }

        private void txtValorSin_TextChanged(object sender, EventArgs e)
        {
            foreach (char caracter in txtValorSin.Text)
            {
                if (char.IsLetter(caracter))
                {
                    error = true;
                    errorProvider1.SetError(txtValorSin, "No se admiten letras");
                }
                else
                {
                    error = false;
                    errorProvider1.Clear();
                }
            }
        }

        private void txtValorCon_Leave(object sender, EventArgs e)
        {
            try
            {   if (!string.IsNullOrEmpty(txtValorCon.Text))
                    {
                        valor = int.Parse(txtValorCon.Text);
                        txtValorCon.Text = valor.ToString("N0", CultureInfo.CurrentCulture);
                    }                               
            }
            catch
            {

            }
        }     

        private void comboProyectos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (int.Parse(comboProyectos.SelectedIndex.ToString()) == 0)
            {
                CargarClientes();
                //
            }
            else
            {
                DtCliente = cliente.cargarClientesProyecto(int.Parse(comboProyectos.SelectedIndex.ToString())-1);
                DtReportes = DtCliente.Copy();
                dataGridView1.DataSource = DtCliente;
                dataGridView1.Columns["Id_Cliente"].Visible = false;
                dataGridView1.Columns["Fk_Id_Cartera"].Visible = false;
                DtReportes.Columns.Remove("Id_Cliente");
                DtReportes.Columns.Remove("Fk_Id_Cartera");
            }

        }

        private void BtLimpiar_Click(object sender, EventArgs e)
        {
            Panel_Registrar_user.Visible = false;
            BtGuardarCliente.Enabled = false;
            dateFechaEstado.Visible = false;
            comboEstadoCliente.Visible = false;
            comboProyectos.Enabled = true;
            label26.Enabled = true;
            comboProyectos.Text = "TODOS LOS PROYECTOS";
            LimpiarUsuario();
            LimpiarProducto();
            Bloquear_Financiado();
            BtBuscarCliente.Enabled = true;
            button2.Enabled = true;
            button4.Enabled = true;
            Cartera_id = 0;
            Cliente_id = "";
            Producto_id = "";
            Financiacion_id = "";
            dataGridView2.DataSource = "";
            CargarClientes();
        }

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dataGridView1.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 16, e.RowBounds.Location.Y + 4);
            }
            
        }

        private void dataGridView2_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            
            using (SolidBrush b = new SolidBrush(dataGridView2.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 16, e.RowBounds.Location.Y + 4);
            }
        }
        public async Task exportarDatosExcel(DataGridView datalistado)
        {
            Mostrar();
            var cargar = new Task(() =>
            {
                Microsoft.Office.Interop.Excel.Application exportarexcel = new Microsoft.Office.Interop.Excel.Application();
                exportarexcel.Application.Workbooks.Add(true);
                int indicecolumna = 0;
                foreach (DataGridViewColumn columna in datalistado.Columns)
                {
                    indicecolumna++;
                    exportarexcel.Cells[1, indicecolumna] = columna.Name;
                }
                int indicefila = 0;
                foreach (DataGridViewRow fila in datalistado.Rows)
                {
                    indicefila++;
                    indicecolumna = 0;
                    foreach (DataGridViewColumn columna in datalistado.Columns)
                    {
                        indicecolumna++;
                        exportarexcel.Cells[indicefila + 1, indicecolumna] = fila.Cells[columna.Name].Value;
                        exportarexcel.Columns.AutoFit();
                    }
                }
                exportarexcel.Visible = true;
            });
            cargar.Start();
            await cargar;
            cerrar();
        }
        public void Mostrar()
        {
            cargando = new Loading();
            cargando.Show();
        }
        public void cerrar()
        {
            if (cargando != null)
                cargando.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            exportarDatosExcel(dataGridView1);
        }
    }
}
