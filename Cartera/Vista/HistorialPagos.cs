using Cartera.Controlador;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cartera.Vista
{
    public partial class HistorialPagos : Form
    {
        CCliente cliente = new CCliente();
        bool error = false;
        CPago pago = new CPago();
        CProducto producto = new CProducto();
        string clienteid = "";
        public HistorialPagos()
        {
            InitializeComponent();
        }
        public HistorialPagos(string cedula, string nombre, string id_cliente)
        {
            InitializeComponent();
        }
        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void BtImprimir_Click(object sender, EventArgs e)
        {

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
            txtCedula.AutoCompleteCustomSource = lista;
        }


        private void HistorialPagos_Load(object sender, EventArgs e)
        {
            autocompletar();
        }



        private void txtCedula_Enter(object sender, EventArgs e)
        {

        }

        private void BtBuscar_Click(object sender, EventArgs e)
        {
             try
            {

                
                cliente.BuscarClientesCedula(txtCedula.Text);
                DataTable DtUsuario = cliente.BuscarClientesCedula(txtCedula.Text);
                clienteid = DtUsuario.Rows[0]["Id_Cliente"].ToString();
                txtCedula.Text = DtUsuario.Rows[0]["Cedula"].ToString();
                txtNombre.Text = DtUsuario.Rows[0]["Nombre"].ToString() + " " + DtUsuario.Rows[0]["Apellido"].ToString();
                txtFecha.Text = DateTime.Now.ToShortDateString();
                ListarPagosCliente();

            }
            catch
            {
                MessageBox.Show ( "No existe cliente");
                txtCedula.Clear();
            }
            
        }

        private void ListarPagosCliente()
        {
            dataGridView1.DataSource = producto.cargarProductosCliente(int.Parse(clienteid));
           // pago.ListarPagosCliente();
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
    } 
}
