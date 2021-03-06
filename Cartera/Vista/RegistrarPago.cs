﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
        CProducto producto = new CProducto();
        CPago pago = new CPago();
        int clienteId = 0;
        DataTable DtNombres = new DataTable();
        public RegistrarPago()
        {
            InitializeComponent();
            
        }
        public RegistrarPago(int cedula,string nombre, string clienteid)
        {
            InitializeComponent();
            clienteId = int.Parse(clienteid);
            txtNombre.Text = nombre;
            Txtcedula.Text = cedula.ToString();
            CargarProducto();

        }

        private void RegistrarPago_Load(object sender, EventArgs e)
        {
            autocompletar();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ValidarCampos();
            if (ValidarCampos() == true)
            {
                pago.RegistrarPago(comboDescuento.Text, int.Parse(txtCuota.Text), dateFechaPago.Text, txtReferencia.Text, int.Parse(txtValor.Text), comboDescuento.Text, int.Parse(txtValorDescuento.Text), productoid);
            }
            }
        void autocompletar()
        {
            AutoCompleteStringCollection lista = new AutoCompleteStringCollection();
            DtNombres = Conexion.consulta("Select * from Cliente");
            for (int i = 0; i < DtNombres.Rows.Count; i++)
            {
                lista.Add(DtNombres.Rows[i]["Nombre"].ToString());
            }
            txtNombre.AutoCompleteCustomSource = lista;
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

                    txtProducto.Text = dataGridView1.Rows[n].Cells["Nombre_Producto"].Value.ToString();

                    DataTable Dtcuota = pago.ConsultarUltimaCuota(productoid);
                    if (int.Parse(Dtcuota.Rows[0]["max(Numero_Cuota)"].ToString())==0)
                    {
                        txtCuota.Text = "1";
                    }
                    else {
                        txtCuota.Text = Dtcuota.Rows[0]["max(Numero_Cuota)"].ToString();
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
            dataGridView1.Columns[1].HeaderText = "Producto";
            dataGridView1.Columns[2].HeaderText = "Contrato";
            dataGridView1.Columns[3].HeaderText = "Forma Pago";
            dataGridView1.Columns[4].HeaderText = "Valor Producto";
            dataGridView1.Columns[5].HeaderText = "Fecha Venta";
            dataGridView1.Columns["Observaciones"].Visible = false;
            dataGridView1.Columns[7].HeaderText = "Proyecto";
            dataGridView1.Columns[8].HeaderText = "Tipo Producto";
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
            else
            {
                ok = true;
                errorProvider1.Clear();
            }
            if (txtReferencia.Text == "")
            {
                ok = false;
                errorProvider1.SetError(txtReferencia, "Digite Referencia de Pago");
            }
            else
            {
                ok = true;
                errorProvider1.Clear();
            }
            if (comboDescuento.Text != "Seleccionar")
            {
                if (txtValorDescuento.Text == "")
                {
                    ok = false;
                    errorProvider1.SetError(txtValorDescuento, "Digite Valor Descuento");
                }
                else
                {
                    ok = true;
                    errorProvider1.Clear();
                }
            }
            return ok;
        }
    }    
}
