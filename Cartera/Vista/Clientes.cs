using Cartera.Controlador;
using Cartera.Reportes;
using iTextSharp.text;
using iTextSharp.text.pdf.codec.wmf;
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
        DataTable DtFinanciacion;
        public static int Cartera_id = 0;
        public static int Cliente_id = 0;
        public static int Producto_id = 0;
        public static int Financiacion_id = 0;
        public static double valor = 0;
        string actual = DateTime.ParseExact(DateTime.Now.ToString("yyyy-MM-dd"), "yyyy-MM-dd", CultureInfo.InvariantCulture).ToString();
        DateTime date, date2;
        double val_total;
        int Refi;
        bool load = false;
        bool ValInteresUsuario = false;

        public Clientes()
        {
            reportesPDF = new ReportesPDF();
            InitializeComponent();
            DateRecaudo.MinDate = new DateTime(2015, 1, 1);
            DateVenta.MinDate = new DateTime(2015, 1, 1);
            Cartera_id = 0;
            Cliente_id = 0;
            Producto_id = 0;
            Financiacion_id = 0;
            valor = 0;
            autocompletar();


        }
        private void Clientes_Load(object sender, EventArgs e)
        {

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
                    string cliente = txtBuscarCliente.Text;
                    if (cliente.All(char.IsDigit))
                    {
                        Panel_Registrar_user.Visible = true;

                        dataGridView2.DataSource = "";
                        LimpiarUsuario();
                        LimpiarProducto();
                        DataTable DtUsuario = new DataTable();

                        DtUsuario = this.cliente.BuscarClientesCedula(cliente);
                        Cliente_id = int.Parse(DtUsuario.Rows[0]["Id_Cliente"].ToString());
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
                        dataGridView1.DataSource = "";
                        //Busca en el datatable el valor del txt y busca por 2 criterios
                        DataRow[] PagosCuota = DtCliente.Select(String.Format("Nombres like '{0}' OR Apellidos like '%{1}%'", cliente, cliente));
                        DataTable dt1 = PagosCuota.CopyToDataTable();
                        ////DataView dvData = new DataView(DtCliente); //FUNCIONA SOLO CON UN LIKE 
                        ////dvData.RowFilter = "Nombres like '%" + cliente+ "%'";
                        dataGridView1.DataSource = dt1;
                            formatogrid();
                            dataGridView1.Columns["Id_Cliente"].Visible = false;
                            dataGridView1.Columns["Fk_Id_Cartera"].Visible = false;
                            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            this.dataGridView1.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dataGridView1_RowPostPaint);
                        //}
                    }
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

            dataGridView1.Columns[1].DefaultCellStyle.Format = "n0";
            dataGridView1.Columns[1].Width = 70;
            dataGridView1.Columns[2].Width = 140;
            dataGridView1.Columns[3].Width = 140;
            dataGridView1.Columns[4].Width = 70;
            dataGridView1.Columns[5].Width = 160;
            dataGridView1.Columns[6].Width = 170;
        }
        private void CargarProducto()
        {
            dataGridView2.DataSource = producto.cargarProductosCliente(Cliente_id);
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
            //DataTable distinctTable = DtCliente.DefaultView.ToTable(true, "Nombres");

            for (int i = 0; i < DtCliente.Rows.Count; i++)
            {
                lista.Add(DtCliente.Rows[i]["Nombres"].ToString());
                txtBuscarCliente.AutoCompleteCustomSource = lista;
            }

            for (int i = 0; i < DtCliente.Rows.Count; i++)
            {
                lista.Add(DtCliente.Rows[i]["Cedula"].ToString());                
                txtBuscarCliente.AutoCompleteCustomSource = lista;
            }
            for (int i = 0; i < DtCliente.Rows.Count; i++)
            {
                lista.Add(DtCliente.Rows[i]["Apellidos"].ToString());
                txtBuscarCliente.AutoCompleteCustomSource = lista;
            }
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
            if (Cliente_id == 0)
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
            if (Financiacion_id != 0)
            {
                if (numCuotaSinInteres.Text != DtFinanciacion.Rows[0]["Cuotas_Sin_interes"].ToString() || numCuotasInteres.Text != DtFinanciacion.Rows[0]["Cuotas_Con_Interes"].ToString())
                {
                    MessageBox.Show("Si modifica el numero de cuotas debera moficar los pagos", "Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    //ok = false;
                    //errorProvider1.SetError(this.numCuotaSinInteres, "Numero de cuotas diferente");
                }
                //if (numCuotasInteres.Text != DtFinanciacion.Rows[0]["Cuotas_Con_Interes"].ToString())
                //{
                //    //MessageBox.Show("Si modifica el numero de cuotas debera moficar los pagos", "Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                //    ok = false;
                //    errorProvider1.SetError(this.numCuotasInteres, "Numero de cuotas diferente");
                //}
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
        private void MostrarError(string mensaje)
        {
            MessageBox.Show($"Error inesperado: {mensaje}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void BtGuardarCliente_Click(object sender, EventArgs e)
        {
            try
            {
                if ((error != true) && (ValidarCampos() == true))
                {
                    if (Cliente_id == 0) //nuevo cliente
                    {
                        Cartera_id = NuevaCartera();
                        if(Cartera_id > 0)
                        {
                            Cliente_id = NuevoCliente(txtCedula.Text, txtNombres.Text, txtApellidos.Text, txtTelefono.Text, txtDireccion.Text, txtCorreo.Text, Cartera_id);
                            if(Cliente_id>0)
                            {
                                if (comboEstadoCliente.Text != "Ceder")                                
                                {
                                    Producto_id= NuevoProducto(txtNombreProducto.Text, txtContrato.Text, ComboFormaPago.Text, int.Parse(Convert.ToDouble(txtValor.Text).ToString()), double.Parse(Convert.ToDouble(txtValorTotal.Text).ToString()), DateVenta.Text, txtObeservaciones.Text, int.Parse(comboProyecto.SelectedValue.ToString()), int.Parse(comboTipoProducto.SelectedValue.ToString()));
                                }
                                if(Producto_id > 0)
                                {
                                    int retorno=NuevoClienteProducto(Cliente_id, Producto_id);
                                    if (retorno > 0)
                                    {
                                        if (comboEstadoCliente.Text != "Ceder")
                                        {
                                            if (ComboFormaPago.Text == "Contado")
                                            {
                                                NuevaFinanciacion(double.Parse(Convert.ToDouble(txtValorTotal.Text).ToString()), 0, int.Parse(Convert.ToDouble(txtValor.Text).ToString()), 0, 0, 0, 0, 0, 0, DateVenta.Text, Producto_id.ToString());
                                            }
                                            else
                                            {
                                                NuevaFinanciacion(double.Parse(Convert.ToDouble(txtValorTotal.Text).ToString()), int.Parse(Convert.ToDouble(txtValorEntrada.Text).ToString()), int.Parse(Convert.ToDouble(txtValorSin.Text).ToString()), double.Parse(Convert.ToDouble(txtValorCuotaSin.Text).ToString()), int.Parse(numCuotaSinInteres.Value.ToString()), double.Parse(Convert.ToDouble(txtValorCon.Text).ToString()), int.Parse(numCuotasInteres.Value.ToString()), double.Parse(Convert.ToDouble(txtValorCuotaInteres.Text).ToString()), int.Parse(numValorInteres.Value.ToString()), DateRecaudo.Text, Producto_id.ToString());
                                            }
                                            CrearCuotas();
                                        }
                                        else
                                        {                                        
                                            EditarProducto(Producto_id, txtNombreProducto.Text, txtContrato.Text, ComboFormaPago.Text, int.Parse(Convert.ToDouble(txtValor.Text).ToString()), double.Parse(Convert.ToDouble(txtValorTotal.Text).ToString()), DateVenta.Text, txtObeservaciones.Text, int.Parse(comboProyecto.SelectedValue.ToString()), int.Parse(comboTipoProducto.SelectedValue.ToString()));
                                            ActualizarValoresCartera();
                                        }                                        
                                    }
                                    ActualizarValorTotal(Cliente_id, Cartera_id);
                                }
                            }                           
                        }                        
                    }
                    else
                    {
                        EditarCliente(Cliente_id.ToString(), txtCedula.Text, txtNombres.Text, txtApellidos.Text, txtTelefono.Text, txtDireccion.Text, txtCorreo.Text, Cartera_id);
                        if ((Producto_id == 0)&& (txtNombreProducto.Text != ""))//nuevo producto
                        {
                            if (cartera.BuscarCartera(txtCedula.Text).Rows[0]["Estado_cartera"].ToString() == "Disuelto")
                            {
                                cartera.ActivarEstadoCartera(Cartera_id.ToString(), double.Parse(Convert.ToDouble(txtValorTotal.Text).ToString()));
                            }
                            Producto_id=NuevoProducto(txtNombreProducto.Text, txtContrato.Text, ComboFormaPago.Text, int.Parse(Convert.ToDouble(txtValor.Text).ToString()), double.Parse(Convert.ToDouble(txtValorTotal.Text).ToString()), DateVenta.Text, txtObeservaciones.Text, int.Parse(comboProyecto.SelectedValue.ToString()), int.Parse(comboTipoProducto.SelectedValue.ToString()));
                            if (Producto_id > 0)
                            {
                                ActualizarValorTotal(Cliente_id, Cartera_id);
                                int retorno = NuevoClienteProducto(Cliente_id, Producto_id);
                                if ((retorno != 0) && (ComboFormaPago.Text == "Financiado"))
                                {
                                    NuevaFinanciacion(double.Parse(Convert.ToDouble(txtValorTotal.Text).ToString()), int.Parse(Convert.ToDouble(txtValorEntrada.Text).ToString()), int.Parse(Convert.ToDouble(txtValorSin.Text).ToString()), double.Parse(Convert.ToDouble(txtValorCuotaSin.Text).ToString()), int.Parse(numCuotaSinInteres.Value.ToString()), double.Parse(Convert.ToDouble(txtValorCon.Text).ToString()), int.Parse(numCuotasInteres.Value.ToString()), int.Parse(Convert.ToDouble(txtValorCuotaInteres.Text).ToString()), int.Parse(numValorInteres.Value.ToString()), DateRecaudo.Text, Producto_id.ToString());
                                    CrearCuotas();
                                }
                                else
                                {
                                    NuevaFinanciacion(double.Parse(Convert.ToDouble(txtValorTotal.Text).ToString()), 0, int.Parse(Convert.ToDouble(txtValorTotal.Text).ToString()), double.Parse(Convert.ToDouble(txtValorTotal.Text).ToString()), 1, 0, 0, 0, 0, DateVenta.Text, Producto_id.ToString());
                                    DataTable Dtfinan = financiacion.FinanciacionProducto(Producto_id);
                                    NuevaCuota(1, double.Parse(Convert.ToDouble(txtValorTotal.Text).ToString()), "Valor Contado", DateVenta.Text, "Pendiente", int.Parse(Dtfinan.Rows[0]["Id_Financiacion"].ToString()));
                                }
                            }                            
                        }
                        else//editar Producto
                        {
                            EditarProducto(Producto_id, txtNombreProducto.Text, txtContrato.Text, ComboFormaPago.Text, int.Parse(Convert.ToDouble(txtValor.Text).ToString()), double.Parse(Convert.ToDouble(txtValorTotal.Text).ToString()), DateVenta.Text, txtObeservaciones.Text, int.Parse(comboProyecto.SelectedValue.ToString()), int.Parse(comboTipoProducto.SelectedValue.ToString()));
                            ActualizarValorTotal(Cliente_id, Cartera_id);
                            EditarFinanciacion(Financiacion_id, double.Parse(Convert.ToDouble(txtValorTotal.Text).ToString()), int.Parse(Convert.ToDouble(txtValorEntrada.Text).ToString()), int.Parse(Convert.ToDouble(txtValorSin.Text).ToString()), double.Parse(Convert.ToDouble(txtValorCuotaSin.Text).ToString()), int.Parse(numCuotaSinInteres.Value.ToString()), double.Parse(Convert.ToDouble(txtValorCon.Text).ToString()), int.Parse(numCuotasInteres.Value.ToString()), double.Parse(Convert.ToDouble(txtValorCuotaInteres.Text).ToString()), int.Parse(numValorInteres.Value.ToString()), DateRecaudo.Text, Producto_id);
                            if (checkBox1.Checked == false)
                            {
                                ModificarCuotas();
                            }
                            else
                            {
                                financiacion.InactivarFinanciacion(Financiacion_id);
                                financiacion.CambiarFinanciacion(Financiacion_id, double.Parse(Convert.ToDouble(txtValorTotal.Text).ToString()), int.Parse(Convert.ToDouble(txtValorEntrada.Text).ToString()), int.Parse(Convert.ToDouble(txtValorSin.Text).ToString()), double.Parse(Convert.ToDouble(txtValorCuotaSin.Text).ToString()), int.Parse(numCuotaSinInteres.Value.ToString()), double.Parse(Convert.ToDouble(txtValorCon.Text).ToString()), int.Parse(numCuotasInteres.Value.ToString()), double.Parse(Convert.ToDouble(txtValorCuotaInteres.Text).ToString()), int.Parse(numValorInteres.Value.ToString()), DateRecaudo.Text, Producto_id);
                               
                                
                                CrearCuotas();
                                checkBox1.Checked = false;
                            }
                        }
                    }

                    BtBuscarCliente.Enabled = true;
                    Panel_Registrar_user.Visible = false;
                    BtAmortizacionFinan.Visible = false;
                    BtRefinanciar.Visible = false;
                    CargarClientes();
                    autocompletar();
                }
            }
            catch (Exception ex)
            {
                MostrarError(ex.Message);
            }
        }
        public void CrearCuotas()
        {
            //Validar si la cuota a crea es contado o credito
            int num_cuota = 0;
            int contador = 1;
            string Estado = "Pendiente";
            DataTable Dtfinan = financiacion.FinanciacionProducto(Producto_id);
            date = DateTime.ParseExact(DateVenta.Text, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            date2 = DateTime.ParseExact(DateRecaudo.Text, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            if (ComboFormaPago.Text == "Contado")
            {
                cuota.CrearCuota(1, double.Parse(Convert.ToDouble(txtValorTotal.Text).ToString()), "Valor Contado", date.ToString("yyyy-MM-dd"), Estado, int.Parse(Dtfinan.Rows[0]["Id_Financiacion"].ToString()));
            }
            else
            {
                cuota.CrearCuota(num_cuota, double.Parse(Convert.ToDouble(txtValorEntrada.Text).ToString()), "Valor Separación", date.ToString("yyyy-MM-dd"), Estado, int.Parse(Dtfinan.Rows[0]["Id_Financiacion"].ToString()));
                num_cuota++;

                while (num_cuota <= int.Parse(numCuotaSinInteres.Value.ToString()))
                {
                    cuota.CrearCuota(num_cuota, double.Parse(Convert.ToDouble(txtValorCuotaSin.Text).ToString()), "Valor Inicial", date2.AddMonths(contador - 1).ToString("yyyy-MM-dd"), Estado, int.Parse(Dtfinan.Rows[0]["Id_Financiacion"].ToString()));
                    contador++;
                    num_cuota++;
                }
                num_cuota = 1;
                while (num_cuota <= int.Parse(numCuotasInteres.Value.ToString()))
                {
                    cuota.CrearCuota(num_cuota, double.Parse(Convert.ToDouble(txtValorCuotaInteres.Text).ToString()), "Valor Saldo", date2.AddMonths(contador - 1).ToString("yyyy-MM-dd"), Estado, int.Parse(Dtfinan.Rows[0]["Id_Financiacion"].ToString()));
                    contador++;
                    num_cuota++;
                }
            }
        }
        public void ModificarCuotas()
        {
            if (ComboFormaPago.Text == "Financiado")
            {
                date = DateTime.ParseExact(DateRecaudo.Text, "yyyy-MM-dd", CultureInfo.InvariantCulture);
                string UltimaFecha = "";
                DateTime date2;                
                DataTable DtCuotas = cuota.ListarCuotas(Financiacion_id, "Refinanciación", "");
                //modificar la cuota inicial 0                             
                EditarCuota(int.Parse(DtCuotas.Rows[0]["Id_Cuota"].ToString()), int.Parse(DtCuotas.Rows[0]["Cuota"].ToString()), ValorCuota(0, DtCuotas.Rows[0]["Tipo"].ToString()), DtCuotas.Rows[0]["Tipo"].ToString(), DateVenta.Text, DtCuotas.Rows[0]["Estado"].ToString(), double.Parse(DtCuotas.Rows[0]["Aportado"].ToString().Replace(",", "").Replace('.', ',')));
                // mismo numero de cuotas
                if ((int.Parse(numCuotaSinInteres.Value.ToString()) + int.Parse(numCuotasInteres.Value.ToString()) + 1) == DtCuotas.Rows.Count)
                {
                    for (int i = 0; i < DtCuotas.Rows.Count; i++)
                    {
                        string fechapag = date.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
                        if (i == 0)
                        {
                            EditarCuota(int.Parse(DtCuotas.Rows[i]["Id_Cuota"].ToString()), int.Parse(DtCuotas.Rows[i]["Cuota"].ToString()), ValorCuota(i, DtCuotas.Rows[i]["Tipo"].ToString()), DtCuotas.Rows[i]["Tipo"].ToString(), DateVenta.Text, DtCuotas.Rows[i]["Estado"].ToString(), double.Parse(DtCuotas.Rows[i]["Aportado"].ToString().Replace(",", "").Replace('.', ',')));
                        }
                        else
                        {
                            fechapag = date.AddMonths(i - 1).ToString("yyyy-MM-dd");
                            EditarCuota(int.Parse(DtCuotas.Rows[i]["Id_Cuota"].ToString()), int.Parse(DtCuotas.Rows[i]["Cuota"].ToString()), ValorCuota(i, DtCuotas.Rows[i]["Tipo"].ToString()), DtCuotas.Rows[i]["Tipo"].ToString(), fechapag, DtCuotas.Rows[i]["Estado"].ToString(), double.Parse(DtCuotas.Rows[i]["Aportado"].ToString().Replace(",", "").Replace('.', ',')));
                        }
                    }
                }
                else // Diferenciar en numero de cuotas
                {                       
                    if (int.Parse(numCuotaSinInteres.Text) != int.Parse(DtFinanciacion.Rows[0]["Cuotas_Sin_interes"].ToString()))// Cuotas sin interes son diferentes 
                    {//cuotas sin interes nuevas mayores a antiguas
                        if (int.Parse(numCuotaSinInteres.Text) >= int.Parse(DtFinanciacion.Rows[0]["Cuotas_Sin_interes"].ToString()))
                        {
                            for (int i = 1; i <= int.Parse(numCuotaSinInteres.Text); i++)
                            {   //Modifica las cuotas existentes inicial                                         
                                if (i < DtCuotas.Rows.Count && DtCuotas.Rows[i]["Tipo"].ToString() == "Valor Inicial")
                                {
                                    if (int.Parse(DtCuotas.Rows[i]["Cuota"].ToString()) <= int.Parse(numCuotaSinInteres.Text) && DtCuotas.Rows[i]["Tipo"].ToString() == "Valor Inicial")
                                    {
                                        EditarCuota(int.Parse(DtCuotas.Rows[i]["Id_Cuota"].ToString()), int.Parse(DtCuotas.Rows[i]["Cuota"].ToString()), ValorCuota(i, DtCuotas.Rows[i]["Tipo"].ToString()), DtCuotas.Rows[i]["Tipo"].ToString(), DtCuotas.Rows[i]["Fecha"].ToString(), DtCuotas.Rows[i]["Estado"].ToString(), double.Parse(DtCuotas.Rows[i]["Aportado"].ToString().Replace(",", "").Replace('.', ',')));
                                    }
                                }
                                else //crea las cuotas faltantes
                                {
                                    cuota.CrearCuota(i, double.Parse(Convert.ToDouble(txtValorCuotaSin.Text).ToString()), "Valor Inicial", date.AddMonths(i - 1).ToString("yyyy-MM-dd"), "Pendiente", Financiacion_id);
                                    UltimaFecha = date.AddMonths(i - 1).ToString("yyyy-MM-dd");
                                }
                            }
                        }//cuotas sin interes nuevas menores a antiguas
                        else if (int.Parse(numCuotaSinInteres.Text) <= int.Parse(DtFinanciacion.Rows[0]["Cuotas_Sin_interes"].ToString()))
                        {
                            for (int i = 0; i < DtCuotas.Rows.Count; i++)
                            {   //Modifica las cuotas existentes inicial
                                if (i > 0)
                                {
                                    if (i <= int.Parse(numCuotaSinInteres.Text) && DtCuotas.Rows[i]["Tipo"].ToString() == "Valor Inicial")
                                    {
                                        if (int.Parse(DtCuotas.Rows[i]["Cuota"].ToString()) <= int.Parse(numCuotaSinInteres.Text) && DtCuotas.Rows[i]["Tipo"].ToString() == "Valor Inicial")
                                        {
                                            EditarCuota(int.Parse(DtCuotas.Rows[i]["Id_Cuota"].ToString()), int.Parse(DtCuotas.Rows[i]["Cuota"].ToString()), ValorCuota(i, DtCuotas.Rows[i]["Tipo"].ToString()), DtCuotas.Rows[i]["Tipo"].ToString(), DtCuotas.Rows[i]["Fecha"].ToString(), DtCuotas.Rows[i]["Estado"].ToString(), double.Parse(DtCuotas.Rows[i]["Aportado"].ToString().Replace(",", "").Replace('.', ',')));
                                            UltimaFecha = DtCuotas.Rows[i]["Fecha"].ToString();
                                        }
                                    }
                                    else //elimina las cuotas restantes
                                    {
                                        if (DtCuotas.Rows[i]["Tipo"].ToString() == "Valor Inicial")
                                        {
                                            cuota.EliminarCuota(int.Parse(DtCuotas.Rows[i]["Id_Cuota"].ToString()));
                                        }
                                    }
                                }
                            }
                        }
                    }//cuotas con interes son diferentes 
                    int conta;
                    if (UltimaFecha == "")
                    {
                        conta = 0;
                        UltimaFecha = DateRecaudo.Text;
                        date2 = DateTime.ParseExact(UltimaFecha, "yyyy-MM-dd", CultureInfo.InvariantCulture);
                        if (int.Parse(numCuotaSinInteres.Text) == int.Parse(DtFinanciacion.Rows[0]["Cuotas_Sin_interes"].ToString()))
                        {
                            conta = int.Parse(DtFinanciacion.Rows[0]["Cuotas_Sin_interes"].ToString());
                        }
                    }
                    else
                    {
                        conta = 1;
                        date2 = DateTime.ParseExact(UltimaFecha, "yyyy-MM-dd", CultureInfo.InvariantCulture);
                    }
                    if (int.Parse(numCuotasInteres.Text) != int.Parse(DtFinanciacion.Rows[0]["Cuotas_Con_Interes"].ToString()))
                    {
                        DataTable DtCuotaSaldo = new DataTable();
                        DataRow[] DrCuotaSaldo = DtCuotas.Select(String.Format("Tipo = '{0}'", "Valor Saldo"));
                        if (DrCuotaSaldo.Length > 0)
                        {
                            DtCuotaSaldo = DrCuotaSaldo.CopyToDataTable();
                        }
                        //cuotas con interes nuevas mayores a antiguas
                        if (int.Parse(numCuotasInteres.Text) > int.Parse(DtFinanciacion.Rows[0]["Cuotas_Con_Interes"].ToString()))
                        {
                            for (int i = 0; i < int.Parse(numCuotasInteres.Value.ToString()); i++)
                            {   //Modifica las cuotas existentes saldo                                         
                                if (i < DtCuotaSaldo.Rows.Count)
                                {
                                    EditarCuota(int.Parse(DtCuotaSaldo.Rows[i]["Id_Cuota"].ToString()), int.Parse(DtCuotaSaldo.Rows[i]["Cuota"].ToString()), ValorCuota(i, DtCuotaSaldo.Rows[i]["Tipo"].ToString()), DtCuotaSaldo.Rows[i]["Tipo"].ToString(), date2.AddMonths(conta).ToString("yyyy-MM-dd"), EvaluaEstadoCuotaFecha(Convert.ToDateTime(DtCuotaSaldo.Rows[0]["Fecha"].ToString()), double.Parse(DtCuotaSaldo.Rows[i]["Aportado"].ToString().Replace(",", "").Replace('.', ',')), ValorCuota(i, DtCuotaSaldo.Rows[i]["Tipo"].ToString())), double.Parse(DtCuotaSaldo.Rows[i]["Aportado"].ToString().Replace(",", "").Replace('.', ',')));
                                    conta++;
                                }
                                else
                                {
                                    cuota.CrearCuota(i + 1, double.Parse(Convert.ToDouble(txtValorCuotaInteres.Text).ToString()), "Valor Saldo", date2.AddMonths(conta).ToString("yyyy-MM-dd"), EvaluaEstadoCuotaFecha(Convert.ToDateTime(date2.AddMonths(conta).ToString("yyyy-MM-dd")), 0, double.Parse(Convert.ToDouble(txtValorCuotaInteres.Text).ToString())), Financiacion_id);
                                    conta++;
                                }
                            }
                        }//cuotas con interes nuevas menores a antiguas
                        else if (int.Parse(numCuotasInteres.Text) < int.Parse(DtFinanciacion.Rows[0]["Cuotas_Con_Interes"].ToString()))
                        {
                            for (int i = 0; i < DtCuotaSaldo.Rows.Count; i++)
                            {   //Modifica las cuotas existentes inicial saldo                                               
                                if (i < int.Parse(numCuotasInteres.Text))
                                {
                                    EditarCuota(int.Parse(DtCuotaSaldo.Rows[i]["Id_Cuota"].ToString()), int.Parse(DtCuotaSaldo.Rows[i]["Cuota"].ToString()), ValorCuota(i, DtCuotaSaldo.Rows[i]["Tipo"].ToString()), DtCuotaSaldo.Rows[i]["Tipo"].ToString(), date2.AddMonths(conta).ToString("yyyy-MM-dd"), EvaluaEstadoCuotaFecha(Convert.ToDateTime(DtCuotaSaldo.Rows[0]["Fecha"].ToString()), double.Parse(DtCuotaSaldo.Rows[i]["Aportado"].ToString().Replace(",", "").Replace('.', ',')), ValorCuota(i, DtCuotaSaldo.Rows[i]["Tipo"].ToString())), double.Parse(DtCuotaSaldo.Rows[i]["Aportado"].ToString().Replace(",", "").Replace('.', ',')));
                                    conta++;
                                }
                                else //elimina las cuotas restantes saldo
                                {
                                    cuota.EliminarCuota(int.Parse(DtCuotaSaldo.Rows[i]["Id_Cuota"].ToString()));
                                }
                            }
                        }
                    }
                    else//cuotas con interes iguales antiguas
                    {
                        for (int i = 0; i <= DtCuotas.Rows.Count; i++)
                        {   //Modifica las cuotas existentes Saldo

                            if (i <= int.Parse(numCuotasInteres.Text) && DtCuotas.Rows[i]["Tipo"].ToString() == "Valor Saldo")
                            {
                                if (int.Parse(DtCuotas.Rows[i]["Cuota"].ToString()) <= int.Parse(numCuotasInteres.Text) && DtCuotas.Rows[i]["Tipo"].ToString() == "Valor Saldo")
                                {
                                    EditarCuota(int.Parse(DtCuotas.Rows[i]["Id_Cuota"].ToString()), int.Parse(DtCuotas.Rows[i]["Cuota"].ToString()), ValorCuota(i, DtCuotas.Rows[i]["Tipo"].ToString()), DtCuotas.Rows[i]["Tipo"].ToString(), date2.AddMonths(conta).ToString("yyyy-MM-dd"), DtCuotas.Rows[i]["Estado"].ToString(), double.Parse(DtCuotas.Rows[i]["Aportado"].ToString().Replace(",", "").Replace('.', ',')));
                                    conta++;
                                }
                            }
                        }
                    }
                }
            }            
        }
        private int NuevaCartera() => cartera.crearCartera();
        private int NuevoCliente(string Cedula, string Nombres, string Apellidos, string telefono, string direccion, string correo, int cartera) => 
            cliente.crearCliente(Cedula, Nombres, Apellidos, telefono, direccion, correo, cartera);
        private int NuevoProducto(string Nombre_Producto, string Numero_contrato, string Forma_Pago, int Valor_Neto, double Valor_Total, string Fecha_Venta, string Observaciones, int Fk_Id_Proyecto, int Fk_Id_Tipo_Producto) =>
            producto.crearProducto(txtNombreProducto.Text, txtContrato.Text, ComboFormaPago.Text, int.Parse(Convert.ToDouble(txtValor.Text).ToString()), double.Parse(Convert.ToDouble(txtValorTotal.Text).ToString()), DateVenta.Text, txtObeservaciones.Text, int.Parse(comboProyecto.SelectedValue.ToString()), int.Parse(comboTipoProducto.SelectedValue.ToString()));
        private int NuevoClienteProducto(int cliente, int produto) =>
            cliente_producto.InsertCliente_Producto(cliente.ToString(), produto.ToString());
        private int NuevaFinanciacion(double Valor_Producto_Financiacion, int Valor_Entrada, int Valor_Sin_interes, double Valor_Cuota_Sin_interes, int Cuotas_Sin_interes, double Valor_Con_Interes, int Cuotas_Con_Interes, double Valor_Cuota_Con_Interes, int Valor_Interes, string Fecha_Recaudo, string Fk_Producto) =>
            financiacion.crearFinanciacion(Valor_Producto_Financiacion, Valor_Entrada, Valor_Sin_interes, Valor_Cuota_Sin_interes, Cuotas_Sin_interes, Valor_Con_Interes, Cuotas_Con_Interes, Valor_Cuota_Con_Interes, Valor_Interes, Fecha_Recaudo, Fk_Producto);
        private void NuevaCuota(int numcuota, double valor, string Tipo, string fecha, string Estado, int financiacion) => 
            cuota.CrearCuota(numcuota, valor, Tipo, fecha, Estado, financiacion);
        private void ActualizarValorTotal(int Cliente, int Cartera)=> 
            cartera.ActulizarValorTotal(Cliente, Cartera);
        private int EditarCliente(string Cliente, string Cedula, string Nombre, string Apellido, string Telefono, string Direccion, string Correo, int Cartera) => 
            cliente.actualizarCliente(Cliente, Cedula, Nombre, Apellido, Telefono, Direccion, Correo, Cartera);
        private int EditarProducto(int Producto, string NombreProducto, string Numerocontrato, string FormaPago, int ValorNeto, double ValorTotal, string FechaVenta, string Observaciones, int Proyecto, int TipoProducto) => 
            producto.actualizarProducto(Producto, NombreProducto, Numerocontrato, FormaPago, ValorNeto, ValorTotal, FechaVenta, Observaciones, Proyecto, TipoProducto);
        private int EditarFinanciacion(int Financiacion, double ValorProductoFinanciacion, int ValorEntrada, int ValorSininteres, double ValorCuotaSininteres, int CuotasSininteres, double ValorConInteres, int CuotasConInteres, double ValorCuotaConInteres, int ValorInteres, string FechaRecaudo, int Producto) =>
            financiacion.actualizarFinanciacion(Financiacion, ValorProductoFinanciacion, ValorEntrada, ValorSininteres, ValorCuotaSininteres, CuotasSininteres, ValorConInteres, CuotasConInteres, ValorCuotaConInteres, ValorInteres, FechaRecaudo, Producto);
        private int EditarCuota(int idcuota, int numcuota, double valor, string tipo, string fecha, string Estado, double aporte) =>
            cuota.ModificarCuota(idcuota, numcuota, valor, tipo, fecha, Estado, aporte);
       private string EvaluaEstadoCuotaFecha(DateTime fecha, double Pagado, double Valor)
       {
            string CuoEstado = "Pendiente";

            if (Pagado >= Valor)
            {
                CuoEstado = "Pagada";
            }
            else
            {
                if (fecha <= Convert.ToDateTime(actual))
                {
                    CuoEstado = "Mora";
                }
                else if (fecha > Convert.ToDateTime(actual))
                {
                    CuoEstado = "Abono";
                }
            }
            return CuoEstado;
        }
        public double ValorCuota(int i, string tipo)
        {
            double ValCuota = 0;
            switch (tipo)
            {
                case "Valor Separación":
                    ValCuota = double.Parse(Convert.ToDouble(txtValorEntrada.Text).ToString());
                    break;
                case "Valor Inicial":
                    ValCuota = double.Parse(Convert.ToDouble(txtValorCuotaSin.Text).ToString());
                    break;
                case "Valor Saldo":
                    ValCuota = double.Parse(Convert.ToDouble(txtValorCuotaInteres.Text).ToString());
                    break;
                case "Valor Contado":
                    ValCuota = double.Parse(Convert.ToDouble(txtValorTotal.Text).ToString());
                    break;

            }
            return ValCuota;
        }
        
        private void LimpiarProducto()
        {
            txtNombreProducto.ResetText();
            txtContrato.ResetText();
            txtValor.ResetText();
            txtObeservaciones.ResetText();
            ComboFormaPago.Text = "seleccione una opción";
            comboProyecto.Text = "seleccione una opción";
            comboTipoProducto.Text = "seleccione una opción";
            txtValorTotal.ResetText();
            LimpiarFinanciacion();

            //DateVenta.Clear();
            //DateRecaudo.Clear();            
        }
        private void LimpiarFinanciacion()
        {
            txtValorSin.ResetText();
            txtValorEntrada.ResetText();
            txtValorCon.ResetText();
            txtValorCuotaSin.ResetText();
            txtValorCuotaInteres.ResetText();
            numValorInteres.ResetText();
            numCuotasInteres.ResetText();
            numCuotaSinInteres.ResetText();
        }
        private void LimpiarUsuario()
        {
            txtCedula.ResetText();
            txtNombres.ResetText();
            txtApellidos.ResetText();
            txtTelefono.ResetText();
            txtCorreo.ResetText();
            txtDireccion.ResetText();
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
            Cliente_id = 0;
            Producto_id = 0;
            Financiacion_id = 0;
            dataGridView2.DataSource = 0;
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
                    Cliente_id = int.Parse(dataGridView1.Rows[n].Cells["Id_Cliente"].Value.ToString());
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
                Producto_id = 0;
                Financiacion_id = 0;
                int n = e.RowIndex;
                if (n != -1)
                {
                    LimpiarProducto();
                    Producto_id = int.Parse(dataGridView2.Rows[n].Cells["Id_Producto"].Value.ToString());
                    txtNombreProducto.Text = dataGridView2.Rows[n].Cells["Producto"].Value.ToString();
                    txtContrato.Text = dataGridView2.Rows[n].Cells["Contrato"].Value.ToString();
                    // fotmatear campo valor
                    valor = double.Parse(dataGridView2.Rows[n].Cells["Valor Final"].Value.ToString());
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
                        load = true;
                        DtFinanciacion = financiacion.FinanciacionProducto(Producto_id);
                        Financiacion_id = int.Parse(DtFinanciacion.Rows[0]["Id_Financiacion"].ToString());
                        //txtValorTotal.Text = DtFinanciacion.Rows[0]["Valor_Producto_Financiacion"].ToString();
                        int ValorSin = int.Parse(DtFinanciacion.Rows[0]["Valor_Sin_interes"].ToString());
                        txtValorSin.Text = ValorSin.ToString("N0", CultureInfo.CurrentCulture);
                        int ValorEntr = int.Parse(DtFinanciacion.Rows[0]["Valor_Entrada"].ToString());
                        txtValorEntrada.Text = ValorEntr.ToString("N0", CultureInfo.CurrentCulture);
                        double ValorCon = double.Parse(DtFinanciacion.Rows[0]["Valor_Con_Interes"].ToString());
                        txtValorCon.Text = ValorCon.ToString("N2", CultureInfo.CurrentCulture);
                        DateRecaudo.Text = DtFinanciacion.Rows[0]["Fecha_Recaudo"].ToString();
                        numCuotaSinInteres.Text = DtFinanciacion.Rows[0]["Cuotas_Sin_interes"].ToString();
                        numCuotasInteres.Text = DtFinanciacion.Rows[0]["Cuotas_Con_Interes"].ToString();
                        double valorcuotasin = double.Parse(DtFinanciacion.Rows[0]["Valor_Cuota_Sin_interes"].ToString());
                        txtValorCuotaSin.Text = valorcuotasin.ToString("N2", CultureInfo.CurrentCulture);
                        numValorInteres.Text = DtFinanciacion.Rows[0]["Valor_Interes"].ToString();
                        double valorcuotaint = double.Parse(DtFinanciacion.Rows[0]["Valor_Cuota_Con_Interes"].ToString());
                        txtValorCuotaInteres.Text = valorcuotaint.ToString("N2", CultureInfo.CurrentCulture);
                        ValInteresUsuario = true;
                        if (DtFinanciacion.Rows[0]["Id_Refinanciacion"].ToString() == "")
                        {
                            Refi = 0;
                        }
                        else
                        {
                            Refi = int.Parse(DtFinanciacion.Rows[0]["Id_Refinanciacion"].ToString());
                        }
                        BtRefinanciar.Visible = true;
                        BtAmortizacionFinan.Visible = true;
                    }
                    double total = double.Parse(dataGridView2.Rows[n].Cells["Valor Final"].Value.ToString());
                    txtValorTotal.Text = total.ToString("N2", CultureInfo.CurrentCulture);
                    label24.Visible = true;
                    comboEstadoCliente.Visible = true;
                    dateFechaEstado.Visible = true;                    
                    BTtransferir.Visible = true;
                    load = false;
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
            BtRefinanciar.Visible = false;
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



        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (Producto_id != 0 && Cliente_id != 0)
            {
                HistorialClientes historial = new HistorialClientes(Producto_id.ToString());
                historial.Show();
            }
            else if (Cliente_id == 0)
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
                
                Cliente_id = 0;
                LimpiarUsuario();
            }
            else if (comboEstadoCliente.Text == "Disolver")
            {
                if (MessageBox.Show("¿Está seguro de Disolver el contrato?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    DataTable DtCartera = cartera.CarteraCliente(txtCedula.Text);
                    if (int.Parse(DtCartera.Rows[0]["Items"].ToString()) == 1)
                    {
                        cartera.ActulizarEstadoCartera(Cartera_id.ToString(), "Disuelto", int.Parse(DtCartera.Rows[0]["Cuotas Pact."].ToString()), int.Parse(DtCartera.Rows[0]["Cuotas Pag."].ToString()), int.Parse(DtCartera.Rows[0]["Cuotas Mora"].ToString()), int.Parse(DtCartera.Rows[0]["Meses Mora"].ToString()));
                    }                    
                    cliente_producto.EstadoDisolver(Cliente_id, Producto_id, dateFechaEstado.Text);
                    Panel_Registrar_user.Visible = false;
                    ActualizarValoresCartera();
                    CargarClientes();
                }
            }
        }

        private void ActualizarValoresCartera()
        {
            DataTable ValorTotal =cartera.ActulizarValorTotal(Cliente_id, Cartera_id);
            int ValorRecaudado = cartera.ActulizarValorRecaudado(Cartera_id);
            cartera.ActulizarSaldo(Cartera_id);
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
            if (Producto_id != 0 && Cliente_id != 0 && Financiacion_id != 0)
            {
                HistorialFinanciacion historial = new HistorialFinanciacion(Producto_id.ToString());
                historial.ShowDialog();
            }
            else if (Cliente_id == 0)
            {
                MessageBox.Show("Busque un usuario y seleccione producto", "Accion no permitida ", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else if (Producto_id == 0)
            {
                MessageBox.Show("Seleccione un producto", "Accion no permitida ", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else
            {
                MessageBox.Show("Seleccione un producto con financiación", "Accion no permitida ", MessageBoxButtons.OK, MessageBoxIcon.Stop);
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
        private void txtValor_Leave(object sender, EventArgs e)
        {
            try
            {

                if (!string.IsNullOrEmpty(txtValor.Text))
                {
                    valor = int.Parse(txtValor.Text);
                    txtValor.Text = valor.ToString("N2", CultureInfo.CurrentCulture);
                }
            }
            catch
            {
                MessageBox.Show("Valor no admitido");
                errorProvider1.SetError(txtValorEntrada, "Error");
            }
        }

        //Sin uso actual
        private void txtValorSin_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (char.IsLetter(e.KeyChar))
            //{
            //    error = true;
            //    errorProvider1.SetError(txtValorSin, "No se admiten letras");
            //}
            //else if (char.IsDigit(e.KeyChar))
            //{
            //    error = false;
            //    errorProvider1.Clear();
            //    if (!string.IsNullOrEmpty(txtValorSin.Text))
            //    {
            //        double numero = Convert.ToDouble(txtValorSin.Text);
            //        txtValorSin.Text = numero.ToString("N0");
            //        if (e.KeyChar != (char)Keys.Back)
            //        {
            //            txtValorSin.Select(txtValorSin.Text.Length, 0);
            //        }

            //    }
            //}

        }
        //Sin uso actual
        private void txtValorSin_TextChanged(object sender, EventArgs e)
        {
            //decimal value;

            //if (decimal.TryParse(txtValorSin.Text, NumberStyles.Currency, null, out value))
            //{
            //    error = false;
            //    errorProvider1.Clear();
            //    double numero = Convert.ToDouble(txtValorSin.Text);
            //    txtValorSin.Text = numero.ToString("N0");                
            //}
            //else
            //{
            //    // Notify the user somehow
            //    error = true;
            //    errorProvider1.SetError(txtValorSin, "No se admiten letras");
            //}
            //if (e.KeyChar == (char)Keys.Delete)
            //{

            //}
            //txtValorSin.Select(txtValorSin.Text.Length, 0);

            //foreach (char caracter in numero.ToString())
            //{
            //    if (char.IsLetter(caracter))
            //    {
            //        error = true;
            //        errorProvider1.SetError(txtValorSin, "No se admiten letras");
            //    }
            //    else
            //    {
            //        error = false;
            //        errorProvider1.Clear();
            //    }       
            //}        
        }
        //Da formato de miles y realiza acciones luego de cambiar de componente
        private void txtValor_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            decimal value;

            if (decimal.TryParse(txtValor.Text, NumberStyles.Currency, null, out value))
            {
                double numero = Convert.ToDouble(txtValor.Text);
                txtValor.Text = numero.ToString("N0");
            }
            if (!string.IsNullOrEmpty(txtValor.Text))
            {
                if (ComboFormaPago.Text == "Contado")
                {
                    valor = int.Parse(Convert.ToDouble(txtValor.Text).ToString());
                    txtValorTotal.Text = valor.ToString("N0", CultureInfo.CurrentCulture);
                }
                else
                {
                    txtValorSin.Clear();
                    txtValorCon.Clear();
                    val_total = Convert.ToDouble(txtValor.Text);
                    double Exectos = 0.3 * val_total;
                    double Con_interes = 0.7 * val_total;
                    txtValorSin.Text = String.Format("{0:N0}", Exectos);
                    txtValorCon.Text = String.Format("{0:N2}", Con_interes);
                    //LimpiarFinanciacion();
                }

            }
            else
            {
                // Notify the user somehow
                error = true;
                errorProvider1.SetError(txtValor, "Debe ingresar un valor");
            }

        }
        private void txtValorSin_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            decimal value;

            if (decimal.TryParse(txtValorSin.Text, NumberStyles.Currency, null, out value))
            {
                double numero = Convert.ToDouble(txtValorSin.Text);
                txtValorSin.Text = numero.ToString("N0");
            }
            if (!string.IsNullOrEmpty(txtValorSin.Text))
            {
                if (Convert.ToDouble(txtValor.Text) - Convert.ToDouble(txtValorSin.Text) == 0)
                {
                    numCuotasInteres.Text = "0";
                    txtValorCuotaInteres.Text = "0";
                    numValorInteres.Text = "0";
                    txtValorCon.Text = "0";
                    txtValorCon.Enabled = false;
                    numCuotasInteres.Enabled = false;
                    numValorInteres.Enabled = false;
                    txtValorCuotaInteres.Enabled = false;
                    string valTotal = int.Parse(Convert.ToDouble(txtValorSin.Text).ToString()).ToString();
                    txtValorTotal.Text = String.Format("{0:N2}", Convert.ToDouble(valTotal));
                }
                else
                {
                    txtValorCon.Enabled = true;
                    numCuotasInteres.Enabled = true;
                    numValorInteres.Enabled = true;
                    txtValorCuotaInteres.Enabled = true;
                    txtValorCon.Text = (String.Format("{0:N2}", Convert.ToDouble(txtValor.Text) - Convert.ToDouble(txtValorSin.Text)));
                    txtValorEntrada.ResetText();
                    numCuotaSinInteres.ResetText();
                    txtValorCuotaSin.ResetText();
                    numCuotasInteres.ResetText();
                    txtValorCuotaInteres.ResetText();
                }
            }
            else
            {
                // Notify the user somehow
                error = true;
                errorProvider1.SetError(txtValorSin, "Debe ingresar un valor");
            }
        }
        private void txtValorCon_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            decimal value;

            if (decimal.TryParse(txtValorCon.Text, NumberStyles.Currency, null, out value))
            {
                double numero = Convert.ToDouble(txtValorCon.Text);
                txtValorCon.Text = numero.ToString("N2");
            }
            if (txtValorCon.Text == "0")
            {
                numCuotasInteres.Text = "0";
                txtValorCuotaInteres.Text = "0";
                numValorInteres.Text = "0";
                numCuotasInteres.Enabled = false;
                numValorInteres.Enabled = false;
                txtValorCuotaInteres.Enabled = false;
                string valTotal = double.Parse(Convert.ToDouble(txtValorSin.Text).ToString()).ToString();
                txtValorTotal.Text = String.Format("{0:N2}", Convert.ToDouble(valTotal));
            }
            else
            {
                numCuotasInteres.Enabled = true;
                numValorInteres.Enabled = true;
                txtValorCuotaInteres.Enabled = true;
            }
        }
        private void txtValorEntrada_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            decimal value;

            if (decimal.TryParse(txtValorEntrada.Text, NumberStyles.Currency, null, out value))
            {
                double numero = Convert.ToDouble(txtValorEntrada.Text);
                txtValorEntrada.Text = numero.ToString("N0");
            }
            if (!string.IsNullOrEmpty(txtValorSin.Text) && !string.IsNullOrEmpty(txtValorEntrada.Text))
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
        //Valida que los valores sean numericos
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
        private void txtValorSin_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (char.IsLetter(System.Convert.ToChar(e.KeyValue)))
            {
                if (!string.IsNullOrEmpty(txtValorSin.Text))
                {
                    // Notify the user somehow
                    error = true;
                    errorProvider1.SetError(txtValorSin, "No se admiten letras");
                }
            }
            else
            {
                error = false;
                errorProvider1.Clear();
            }

        }
        private void txtValorCon_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (char.IsLetter(System.Convert.ToChar(e.KeyValue)))
            {
                if (!string.IsNullOrEmpty(txtValorCon.Text))
                {
                    // Notify the user somehow
                    error = true;
                    errorProvider1.SetError(txtValorCon, "No se admiten letras");
                }
            }
            else
            {
                error = false;
                errorProvider1.Clear();
            }
        }
        private void txtValorEntrada_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (char.IsLetter(System.Convert.ToChar(e.KeyValue)))
            {
                if (!string.IsNullOrEmpty(txtValorEntrada.Text))
                {
                    // Notify the user somehow
                    error = true;
                    errorProvider1.SetError(txtValorEntrada, "No se admiten letras");
                }
            }
            else
            {
                error = false;
                errorProvider1.Clear();
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

        }

        private void numCuotaSinInteres_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (load != true)
                {
                    if (ComboFormaPago.Text == "Financiado")
                    {
                        if (txtValorEntrada.Text != "")
                        {
                            double valor30 = (Convert.ToDouble(txtValorSin.Text) - Convert.ToDouble(txtValorEntrada.Text)) / Convert.ToDouble(numCuotaSinInteres.Value);
                            txtValorCuotaSin.Clear();
                            txtValorCuotaSin.Text = String.Format("{0:N2}", valor30);

                        }
                        else
                        {
                            MessageBox.Show("No hay valor inicial");
                        }
                    }
                    load = false;
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
                if (load != true)
                {
                    if (ComboFormaPago.Text == "Financiado")
                    {
                        ActulizarValoresSaldo();
                    }
                    load = false;
                }
            }
            catch
            {
                MessageBox.Show("Digite el valor 70");
            }
        }
        private void numCuotasInteres_MouseClick(object sender, MouseEventArgs e)
        {
            ValInteresUsuario = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            reportesPDF.Clientes(DtReportes);
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
                DtCliente = cliente.cargarClientesProyecto(int.Parse(comboProyectos.SelectedIndex.ToString()) - 1);
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
            limpiar();
        }

        private void limpiar()
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
            Cliente_id = 0;
            Producto_id = 0;
            Financiacion_id = 0;
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

        private void ComboFormaPago_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Producto_id != 0 && Financiacion_id != 0)
            {
                if (ComboFormaPago.Text == "Financiado")
                {
                    //ya convertido
                    financiacion.crearFinanciacion(int.Parse(Convert.ToDouble(txtValorTotal.Text).ToString()), int.Parse(Convert.ToDouble(txtValorEntrada.Text).ToString()), int.Parse(Convert.ToDouble(txtValorSin.Text).ToString()), double.Parse(Convert.ToDouble(txtValorCuotaSin.Text).ToString()), int.Parse(numCuotaSinInteres.Value.ToString()), double.Parse(Convert.ToDouble(txtValorCon.Text).ToString()), int.Parse(numCuotasInteres.Value.ToString()), double.Parse(Convert.ToDouble(txtValorCuotaInteres.Text).ToString()), int.Parse(numValorInteres.Value.ToString()), DateRecaudo.Text, Producto_id.ToString());
                    CrearCuotas();
                }
                else if (ComboFormaPago.Text == "Contado")
                {
                    financiacion.InactivarFinanciacion(Financiacion_id);
                }
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (Financiacion_id != 0)
            {
                Amortizacion Am = new Amortizacion(Financiacion_id, int.Parse(Convert.ToDouble(txtValor.Text).ToString()), int.Parse(Convert.ToDouble(txtValorSin.Text).ToString()), int.Parse(numValorInteres.Value.ToString()), double.Parse(Convert.ToDouble(txtValorCuotaInteres.Text).ToString()), double.Parse(Convert.ToDouble(txtValorTotal.Text).ToString()));
                Am.ShowDialog();
            }
            else
            {
                //Valida el tipo de pago
                if (ComboFormaPago.Text == "Financiado")
                {
                    Amortizacion Am = new Amortizacion(int.Parse(Convert.ToDouble(txtValor.Text).ToString()), int.Parse(Convert.ToDouble(txtValorSin.Text).ToString()), int.Parse(numValorInteres.Value.ToString()), int.Parse(numCuotasInteres.Value.ToString()), int.Parse(Convert.ToDouble(txtValorCuotaInteres.Text).ToString()), double.Parse(Convert.ToDouble(txtValorTotal.Text).ToString()), 0);
                    Am.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Ación no admitida", "Producto pagado a contado", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
        }
        private void ActulizarValoresSaldo()
        {
            double ValConInteres;
            double ValorCuota = ValorCuotaInteres(int.Parse(Convert.ToDouble(txtValor.Text).ToString()), int.Parse(Convert.ToDouble(txtValorSin.Text).ToString()), int.Parse(numValorInteres.Value.ToString()), int.Parse(numCuotasInteres.Value.ToString()));
            if (numCuotasInteres.Value <= 18 || (numCuotasInteres.Value > 18 && ValInteresUsuario == true))
            {
                if (numValorInteres.Value == 0)
                {
                    ValConInteres = Convert.ToDouble(txtValor.Text.ToString()) - Convert.ToDouble(txtValorSin.Text.ToString());
                }
                else
                {
                    ValConInteres = ValorCuota * int.Parse(numCuotasInteres.Value.ToString());
                }
            }
            else
            {
                ValConInteres = ValorCuota * int.Parse(numCuotasInteres.Value.ToString());
            }

            txtValorCuotaInteres.ResetText();
            txtValorCuotaInteres.Text = String.Format("{0:N2}", Math.Round(ValorCuota, 2));
            txtValorCon.ResetText();
            txtValorCon.Text = Math.Round(ValConInteres, 2).ToString("N2", CultureInfo.CurrentCulture);
            double valTotal = double.Parse(Convert.ToDouble(txtValorSin.Text).ToString(), CultureInfo.CurrentCulture) + double.Parse(Convert.ToDouble(txtValorCon.Text).ToString(), CultureInfo.CurrentCulture);
            txtValorTotal.Text = Math.Round(valTotal, 2).ToString();
            txtValorTotal.Text = String.Format("{0:N2}", Convert.ToDouble(txtValorTotal.Text));
        }
        private void numValorInteres_ValueChanged(object sender, EventArgs e)
        {
            ActulizarValoresSaldo();

            if (numValorInteres.Value > 0)
            {
                BtAmortizacionFinan.Enabled = true;
                //ya hallo el valor de la cuota 
                //double ValInteres = ValorCuotaInteres(int.Parse(Convert.ToDouble(txtValor.Text).ToString()), int.Parse(Convert.ToDouble(txtValorSin.Text).ToString()), int.Parse(numValorInteres.Value.ToString()), int.Parse(numCuotasInteres.Value.ToString()));
                //double ValConInteres = ValInteres * int.Parse(numCuotasInteres.Value.ToString());
                //txtValorCon.ResetText();
                //txtValorCon.Text = ValConInteres.ToString("N0", CultureInfo.CurrentCulture);
                //txtValorCuotaInteres.ResetText();
                //txtValorCuotaInteres.Text = ValInteres.ToString("N0", CultureInfo.CurrentCulture);
            }
            else
            {
                BtAmortizacionFinan.Enabled = false;
                //txtValorCon.ResetText();
                //txtValorCon.Text = (int.Parse(Convert.ToDouble(txtValor.Text).ToString()) - int.Parse(Convert.ToDouble(txtValorSin.Text).ToString())).ToString();
            }
        }
        private double ValorCuotaInteres(int ValorNeto, int ValorSin, int ValorInteres, int NumCuotas)
        {
            double saldo = ValorNeto - ValorSin;
            double ValInteres = ValorInteres;
            double ValorCuotaInteres;
            double Interes;

            if (numCuotasInteres.Value <= 18 && ValInteresUsuario != true)
            {
                ValInteres = 0;
                Interes = ValInteres;
                ValorCuotaInteres = saldo / NumCuotas;
            }
            else
            {
                if (numValorInteres.Value == 0 && ValInteresUsuario != true)
                {
                    ValInteres = 1;
                }
                Interes = ValInteres;
                ValInteres = Interes / 100;
                if (numValorInteres.Value == 0)
                {
                    ValorCuotaInteres = saldo / NumCuotas;
                }
                else
                {
                    ValorCuotaInteres = (ValInteres * saldo) / (1 - Math.Pow(1 + ValInteres, -NumCuotas));
                }

            }
            numValorInteres.Text = Interes.ToString();
            return ValorCuotaInteres;
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            if (Financiacion_id != 0)
            {
                Refinanciacion Re = new Refinanciacion(Financiacion_id, int.Parse(Convert.ToDouble(txtValor.Text).ToString()), int.Parse(Convert.ToDouble(txtValorSin.Text).ToString()), int.Parse(numValorInteres.Value.ToString()), double.Parse(Convert.ToDouble(txtValorCuotaInteres.Text).ToString()), double.Parse(Convert.ToDouble(txtValorTotal.Text).ToString()), Refi, (txtNombres.Text + " " + txtApellidos.Text), txtNombreProducto.Text, comboProyecto.Text);
                //Refinanciacion Re = new Refinanciacion(Financiacion_id, int.Parse(Convert.ToDouble(txtValor.Text).ToString()));
                Re.ShowDialog();
            }

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void BTtransferir_Click(object sender, EventArgs e)
        {
            if (Producto_id != 0 && Cliente_id != 0 && Financiacion_id != 0)
            {
                HistorialTransferencia historialT = new HistorialTransferencia(Producto_id.ToString());
                historialT.FormClosed += Traslado_Formclose;
                historialT.ShowDialog();
            }
            else if (Cliente_id == 0)
            {
                MessageBox.Show("Busque un usuario y seleccione producto", "Accion no permitida ", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else if (Producto_id == 0)
            {
                MessageBox.Show("Seleccione un producto", "Accion no permitida ", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else
            {
                MessageBox.Show("Seleccione un producto con financiación", "Accion no permitida ", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void Traslado_Formclose(object sender, FormClosedEventArgs e)
        {
            Form frm = sender as Form;
            if (frm.DialogResult == DialogResult.OK)
            {
                limpiar();
            }
        }

        private void BTActulizarValoresCartera_Click(object sender, EventArgs e)
        {
            if (Cartera_id == 0)
            {
                MessageBox.Show("Seleccione un producto con financiación", "Accion no permitida ", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else
            {
                ActualizarValoresCartera();
            }           

        }
    }
}
