using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using Cartera.Vista;
using Cartera.Vistas;

namespace Cartera.Vista
{
    public partial class Clientes : Form
    {
        bool error = false;
        DataTable DtNombres = new DataTable();
        public static string Cartera_id = "";
        public static string Cliente_id = "";
        public static string Producto_id = "";
        
        public Clientes()
        {
            InitializeComponent();
            autocompletar();
            DateRecaudo.MinDate = new DateTime(2015, 1, 1);
            DateVenta.MinDate = new DateTime(2015, 1, 1);
            DateRecaudo.MaxDate = DateTime.Today;
            DateVenta.MaxDate = DateTime.Today;
        }

        private void Clientes_Load(object sender, EventArgs e)
        {
            CargarClientes();
            DataTable DtProyectos = Conexion.consulta("SELECT * FROM Proyecto");
            comboProyecto.DataSource = DtProyectos;
            comboProyecto.DisplayMember = "Proyecto_Nombre";
            comboProyecto.ValueMember = "Id_Proyecto";
            DataTable DtTipoProducto= Conexion.consulta("SELECT * FROM Tipo_Producto");
            comboTipoProducto.DataSource = DtTipoProducto;
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
                    DataTable DtUsuario = Conexion.consulta("SELECT * FROM Cliente WHERE Nombre =Upper( '" + nom + "')");
                    Cliente_id = DtUsuario.Rows[0]["Id_Cliente"].ToString();
                    txtCedula.Text = DtUsuario.Rows[0]["Cedula"].ToString();
                    txtNombres.Text = DtUsuario.Rows[0]["Nombre"].ToString();
                    txtApellidos.Text = DtUsuario.Rows[0]["Apellido"].ToString();
                    txtTelefono.Text = DtUsuario.Rows[0]["Telefono"].ToString();
                    txtDireccion.Text = DtUsuario.Rows[0]["Direccion"].ToString();
                    txtCorreo.Text = DtUsuario.Rows[0]["Correo"].ToString();
                    Cartera_id = DtUsuario.Rows[0]["Fk_Id_Cartera"].ToString();
                    CargarProducto();
                    Producto_id = "";
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
            dataGridView1.DataSource = Conexion.consulta("Select Id_Cliente, Cedula, Nombre, Apellido, Telefono, Direccion, Correo, Fk_Id_Cartera  from Cliente");
            dataGridView1.Columns["Fk_Id_Cartera"].Visible = false;
        }
        private void CargarProducto()
        {
            dataGridView2.DataSource = Conexion.consulta("SELECT Id_Producto, Nombre_Producto, Numero_contrato, Forma_pago, Valor_Total, Fecha_Venta, Valor_Entrada, Proyecto_Nombre, Nom_Tipo_Producto, Valor_Sin_interes, Cuotas_Sin_interes, Valor_Cuota_Sin_interes, Valor_Con_Interes, Cuotas_Con_Interes, Valor_Cuota_Con_Interes, Valor_Interes, Fecha_Recaudo, Observaciones, Fk_Id_Proyecto, Fk_Id_Tipo_Producto FROM Producto INNER join Proyecto on Id_Proyecto = Fk_Id_Proyecto INNER join Tipo_Producto on Id_Tipo_Producto = Fk_Id_Tipo_Producto WHERE Fk_Id_Cartera =  " + Cartera_id + "");
            dataGridView2.Columns["Id_Producto"].Visible = false;
            dataGridView2.Columns["Fk_Id_Proyecto"].Visible = false;
            dataGridView2.Columns["Fk_Id_Tipo_Producto"].Visible = false;
            dataGridView2.Columns[1].HeaderText = "Producto";
            dataGridView2.Columns[2].HeaderText = "Contrato";
            dataGridView2.Columns[3].HeaderText = "Forma Pago";
            dataGridView2.Columns[4].HeaderText = "Valor Neto";
            dataGridView2.Columns[5].HeaderText = "Fecha Venta";
            dataGridView2.Columns[6].HeaderText = "Valor Entrada";
            dataGridView2.Columns[7].HeaderText = "Proyecto";
            dataGridView2.Columns[8].HeaderText = "Tipo Producto";
            dataGridView2.Columns[9].HeaderText = "Valor sin Interes";
            dataGridView2.Columns[10].HeaderText = "Cuotas sin Interes";
            dataGridView2.Columns[11].HeaderText = "Valor Cuota Sin interes";            
            dataGridView2.Columns[12].HeaderText = "Valor con Interes";
            dataGridView2.Columns[13].HeaderText = "Cuotas con Interes";
            dataGridView2.Columns[14].HeaderText = "Valor Cuota Con Interes";
            dataGridView2.Columns[15].HeaderText = "Porcentaje Interes";
            dataGridView2.Columns[16].HeaderText = "Fecha Recaudo";

        }
        void autocompletar()
        {
            AutoCompleteStringCollection lista = new AutoCompleteStringCollection();
            DtNombres = Conexion.consulta("Select * from Cliente");
            for (int i=0; i<DtNombres.Rows.Count; i++)
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
            if (txtNombres.Text =="")
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
            if ((error != true)&& (ValidarCampos() ==true))
            {
                if (Cliente_id == "")
                {
                    string sql1 = "insert into Cartera(Estado_cartera,Total_Neto_Recaudado,Total_mora,Total_Cartera) values (@Estado_cartera,@Total_Neto_Recaudado,@Total_mora,@Total_Cartera)";
                    SQLiteCommand cmd1 = new SQLiteCommand(sql1, Conexion.instanciaDb());
                    cmd1.Parameters.Add(new SQLiteParameter("@Estado_cartera", "Nueva"));
                    cmd1.Parameters.Add(new SQLiteParameter("@Total_Neto_Recaudado", "0"));
                    cmd1.Parameters.Add(new SQLiteParameter("@Total_mora", "0"));
                    cmd1.Parameters.Add(new SQLiteParameter("@Total_Cartera", "0"));
                    int retorno =cmd1.ExecuteNonQuery();

                    if (retorno != 0)
                    {
                        DataTable DtCartera = Conexion.consulta("SELECT max(Id_Cartera) FROM Cartera ORDER BY Id_Cartera DESC");
                        string sql2 = "insert into Cliente(Cedula,Nombre,Apellido,Telefono, Direccion, Correo, Fk_Id_Cartera) values(@Cedula,upper(@Nombre),upper(@Apellido),@Telefono,@Direccion,@Correo,@Fk_Id_Cartera)";
                        SQLiteCommand cmd2 = new SQLiteCommand(sql2, Conexion.instanciaDb());
                        cmd2.Parameters.Add(new SQLiteParameter("@Cedula", txtCedula.Text));
                        cmd2.Parameters.Add(new SQLiteParameter("@Nombre", txtNombres.Text));
                        cmd2.Parameters.Add(new SQLiteParameter("@Apellido", txtApellidos.Text));
                        cmd2.Parameters.Add(new SQLiteParameter("@Telefono", txtTelefono.Text));
                        cmd2.Parameters.Add(new SQLiteParameter("@Direccion", txtDireccion.Text));
                        cmd2.Parameters.Add(new SQLiteParameter("@Correo", txtCorreo.Text));
                        cmd2.Parameters.Add(new SQLiteParameter("@Fk_Id_Cartera", DtCartera.Rows[0]["max(Id_Cartera)"].ToString()));
                        Cartera_id = DtCartera.Rows[0]["max(Id_Cartera)"].ToString();
                        int retorno2 = cmd2.ExecuteNonQuery();
                        if (retorno2 != 0)
                        {
                            string sql3 = "INSERT INTO Producto(Nombre_Producto, Numero_contrato, Forma_Pago, Valor_Total, Valor_Sin_interes, Valor_Entrada, Cuotas_Sin_interes, Valor_Cuota_Sin_interes, Valor_Con_Interes, Cuotas_Con_Interes, Valor_Cuota_Con_Interes, Valor_Interes, Fecha_Venta, Fecha_Recaudo, Observaciones, Fk_Id_Cartera, Fk_Id_Proyecto, Fk_Id_Tipo_Producto) VALUES(@Nombre_Producto, @Numero_contrato, @Forma_Pago, @Valor_Total, @Valor_Sin_interes, @Valor_Entrada, @Cuotas_Sin_interes , @Valor_Con_Interes, @Cuotas_Con_Interes, @Valor_Interes, @Fecha_Venta, @Fecha_Recaudo, @Observaciones, @Fk_Id_Cartera, @Fk_Id_Proyecto, @Fk_Id_Tipo_Producto)";
                            SQLiteCommand cmd3 = new SQLiteCommand(sql3, Conexion.instanciaDb());
                            cmd3.Parameters.Add(new SQLiteParameter("@Nombre_Producto", txtNombreProducto.Text));
                            cmd3.Parameters.Add(new SQLiteParameter("@Numero_contrato", txtContrato.Text));
                            cmd3.Parameters.Add(new SQLiteParameter("@Forma_Pago", ComboFormaPago.Items[ComboFormaPago.SelectedIndex].ToString()));
                            cmd3.Parameters.Add(new SQLiteParameter("@Valor_Total", txtValor.Text));
                            cmd3.Parameters.Add(new SQLiteParameter("@Valor_Sin_interes", txtValorSin.Text));
                            cmd3.Parameters.Add(new SQLiteParameter("@Valor_Entrada", txtValorEntrada.Text));
                            cmd3.Parameters.Add(new SQLiteParameter("@Cuotas_Sin_interes", Convert.ToString(numCuotaSinInteres.Value)));
                            cmd3.Parameters.Add(new SQLiteParameter("@Valor_Con_Interes", txtValorCon.Text));
                            cmd3.Parameters.Add(new SQLiteParameter("@Cuotas_Con_Interes", Convert.ToString(numCuotaSinInteres.Value)));
                            cmd3.Parameters.Add(new SQLiteParameter("@Valor_Interes", txtValorCuotaInteres.Text));
                            cmd3.Parameters.Add(new SQLiteParameter("@Fecha_Venta", DateVenta.Text));
                            cmd3.Parameters.Add(new SQLiteParameter("@Fecha_Recaudo", DateRecaudo.Text));
                            cmd3.Parameters.Add(new SQLiteParameter("@Observaciones", txtObeservaciones.Text));
                            cmd3.Parameters.Add(new SQLiteParameter("@Fk_Id_Cartera", Cartera_id));
                            cmd3.Parameters.Add(new SQLiteParameter("@Fk_Id_Proyecto", comboProyecto.SelectedIndex.ToString()));
                            cmd3.Parameters.Add(new SQLiteParameter("@Fk_Id_Tipo_Producto", comboTipoProducto.SelectedIndex.ToString()));
                            cmd3.ExecuteNonQuery();
                        }
                    }                        
                }
                //else if(){

               // }
                else
                {
                    string sql2_1 = "UPDATE Cliente SET Cedula=@Cedula, Nombre=@Nombre, Apellido=@Apellido, Telefono=@Telefono, Direccion=@Direccion, Correo=@Correo WHERE Id_Cliente=" + Cliente_id + "";
                    SQLiteCommand cmd2_1 = new SQLiteCommand(sql2_1, Conexion.instanciaDb());
                    cmd2_1.Parameters.Add(new SQLiteParameter("@Cedula", txtCedula.Text));
                    cmd2_1.Parameters.Add(new SQLiteParameter("@Nombre", txtNombres.Text));
                    cmd2_1.Parameters.Add(new SQLiteParameter("@Apellido", txtApellidos.Text));
                    cmd2_1.Parameters.Add(new SQLiteParameter("@Telefono", txtTelefono.Text));
                    cmd2_1.Parameters.Add(new SQLiteParameter("@Direccion", txtDireccion.Text));
                    cmd2_1.Parameters.Add(new SQLiteParameter("@Correo", txtCorreo.Text));
                    cmd2_1.Parameters.Add(new SQLiteParameter("@Fk_Id_Cartera", Cartera_id));
                    cmd2_1.ExecuteNonQuery();

                    if (Producto_id !="")
                    {
                        string sql3_1 = "UPDATE Producto SET Nombre_Producto=@Nombre_Producto , Numero_contrato=@Numero_contrato, Forma_Pago=@Forma_Pago, Valor_Total=@Valor_Total, Valor_Entrada=@Valor_Entrada, Valor_Sin_interes=@Valor_Sin_interes, Cuotas_Sin_interes=@Cuotas_Sin_interes, Valor_Cuota_Sin_interes=@Valor_Cuota_Sin_interes, Valor_Con_Interes=@Valor_Con_Interes, Cuotas_Con_Interes=@Cuotas_Con_Interes, Valor_Cuota_Con_Interes=@Valor_Cuota_Con_Interes, Valor_Interes=@Valor_Interes, Observaciones=@Observaciones, Fecha_Recaudo=@Fecha_Recaudo, Fk_Id_Proyecto=@Fk_Id_Proyecto, Fk_Id_Tipo_Producto=Fk_Id_Tipo_Producto WHERE Id_Producto =" + Producto_id + "";
                        SQLiteCommand cmd3_1 = new SQLiteCommand(sql3_1, Conexion.instanciaDb());
                        cmd3_1.Parameters.Add(new SQLiteParameter("@Nombre_Producto", txtNombreProducto.Text));
                        cmd3_1.Parameters.Add(new SQLiteParameter("@Numero_contrato", txtContrato.Text));
                        cmd3_1.Parameters.Add(new SQLiteParameter("@Forma_Pago", ComboFormaPago.Items[ComboFormaPago.SelectedIndex].ToString()));
                        cmd3_1.Parameters.Add(new SQLiteParameter("@Valor_Total", txtValor.Text));
                        cmd3_1.Parameters.Add(new SQLiteParameter("@Valor_Entrada", txtValorEntrada.Text)); // 
                        cmd3_1.Parameters.Add(new SQLiteParameter("@Valor_Sin_interes", txtValorSin.Text));
                        cmd3_1.Parameters.Add(new SQLiteParameter("@Cuotas_Sin_interes", Convert.ToString(numCuotaSinInteres.Value)));
                        cmd3_1.Parameters.Add(new SQLiteParameter("@Valor_Cuota_Sin_interes", txtValorCuotaSin.Text));
                        cmd3_1.Parameters.Add(new SQLiteParameter("@Valor_Con_Interes", txtValorCon.Text));
                        cmd3_1.Parameters.Add(new SQLiteParameter("@Cuotas_Con_Interes", Convert.ToString(numCuotasInteres.Value)));
                        cmd3_1.Parameters.Add(new SQLiteParameter("@Valor_Cuota_Con_Interes", txtValorCuotaInteres.Text));                        
                        cmd3_1.Parameters.Add(new SQLiteParameter("@Valor_Interes", Convert.ToString(numValorInteres.Value)));
                        cmd3_1.Parameters.Add(new SQLiteParameter("@Fecha_Venta", DateVenta.Text));
                        cmd3_1.Parameters.Add(new SQLiteParameter("@Fecha_Recaudo", DateRecaudo.Text));
                        cmd3_1.Parameters.Add(new SQLiteParameter("@Observaciones", txtObeservaciones.Text));
                        cmd3_1.Parameters.Add(new SQLiteParameter("@Fk_Id_Cartera", Cartera_id));
                        cmd3_1.Parameters.Add(new SQLiteParameter("@Fk_Id_Proyecto", comboProyecto.SelectedIndex.ToString()));
                        cmd3_1.Parameters.Add(new SQLiteParameter("@Fk_Id_Tipo_Producto", comboTipoProducto.SelectedIndex.ToString()));
                        cmd3_1.ExecuteNonQuery();                        
                    }
                }
                
                
                Panel_Registrar_user.Visible = false;
                //Panel_Clientes.Visible = true;
                CargarClientes();
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
            ComboFormaPago.SelectedValue=0;
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
            dataGridView2.Rows.Clear();
            //Panel_Clientes.Visible = false;

        }

        private void txtNombres_TextChanged(object sender, EventArgs e)
        {
            foreach (char caracter in txtNombres.Text)
            {
                if (char.IsDigit(caracter))
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
                if (char.IsDigit(caracter))
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
                Cartera_id = (string)dataGridView1.Rows[n].Cells["Fk_Id_Cartera"].Value.ToString();
                CargarProducto();
            }
        }

        private void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int n = e.RowIndex;
            if ((n != -1) && (n != +1))
            {
                LimpiarProducto();
                Producto_id = dataGridView2.Rows[n].Cells["Id_Producto"].Value.ToString();
                txtNombreProducto.Text = dataGridView2.Rows[n].Cells["Nombre_Producto"].Value.ToString();
                txtContrato.Text = dataGridView2.Rows[n].Cells["Numero_contrato"].Value.ToString();
                txtValor.Text = dataGridView2.Rows[n].Cells["Valor_Total"].Value.ToString();
                txtObeservaciones.Text = dataGridView2.Rows[n].Cells["Observaciones"].Value.ToString();
                DateVenta.Text = dataGridView2.Rows[n].Cells["Fecha_Venta"].Value.ToString();                
                ComboFormaPago.SelectedItem = dataGridView2.Rows[n].Cells["Forma_Pago"].Value.ToString();
                comboProyecto.SelectedIndex = Convert.ToInt32(dataGridView2.Rows[n].Cells["Fk_Id_Proyecto"].Value.ToString());
                comboTipoProducto.SelectedIndex = Convert.ToInt32(dataGridView2.Rows[n].Cells["Fk_Id_Tipo_Producto"].Value.ToString());
                if (dataGridView2.Rows[n].Cells["Forma_Pago"].Value.ToString() == "Contado")
                {
                    Bloquear_Financiado();
                }
                else
                {
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
    }
}
