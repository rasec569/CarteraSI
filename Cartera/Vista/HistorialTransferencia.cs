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
using Cartera.Reportes;

namespace Cartera.Vista
{
    public partial class HistorialTransferencia : Form
    {
        
        CProducto producto = new CProducto();
        int ProductoId;        
        string cliente, nomproducto, numcontrato;
        

        public HistorialTransferencia()
        {
            InitializeComponent();
            DataTable Dtdatos = producto.ClienteProducto(ProductoId);

            cliente = Dtdatos.Rows[0]["Nombre"].ToString() + " " + Dtdatos.Rows[0]["Apellido"].ToString();
            nomproducto = Dtdatos.Rows[0]["Producto"].ToString();
            numcontrato = Dtdatos.Rows[0]["Contrato"].ToString();
        }
        public HistorialTransferencia(string IdProducto)
        {
            InitializeComponent();
            ProductoId = int.Parse(IdProducto);
            DataTable Dtdatos = producto.ClienteProducto(ProductoId);

            cliente = Dtdatos.Rows[0]["Nombre"].ToString() + " " + Dtdatos.Rows[0]["Apellido"].ToString();
            nomproducto = Dtdatos.Rows[0]["Producto"].ToString();
            numcontrato = Dtdatos.Rows[0]["Contrato"].ToString();
            labelOldContrato.Text = numcontrato;
            labelOldUbicacion.Text = nomproducto;
        }

        private void HistorialTransferencia_Load(object sender, EventArgs e)
        {
            cargarHistorialTransferencia();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable DtProducto = producto.BuscarProductos(nomproducto);
            producto.actualizarProducto(ProductoId, txtNombreProducto.Text, txtContrato.Text, DtProducto.Rows[0]["Forma Pago"].ToString(), int.Parse(DtProducto.Rows[0]["Valor Neto"].ToString()), double.Parse( DtProducto.Rows[0]["Valor Total"].ToString()), DtProducto.Rows[0]["Fecha Venta"].ToString(), DtProducto.Rows[0]["Observaciones"].ToString(), int.Parse(DtProducto.Rows[0]["Fk_Id_Proyecto"].ToString()), int.Parse(DtProducto.Rows[0]["Fk_Id_Tipo_Producto"].ToString()));
            producto.crearTraslado(nomproducto, numcontrato, txtNombreProducto.Text, txtContrato.Text, DateRecaudo.Text, ProductoId);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }


        private void cargarHistorialTransferencia()
        {            
           dataGridView1.DataSource = producto.ListarTraslado(ProductoId);
            //dataGridView1.Columns["Id_Financiacion"].Visible = false;
            //dataGridView1.Columns["Valor_Neto"].HeaderText = "Valor Neto";
            //dataGridView1.Columns["Valor_Neto"].DefaultCellStyle.Format = "n0";
            //dataGridView1.Columns["Valor_Neto"].Width = 70;
            //dataGridView1.Columns["Valor_Producto_Financiacion"].HeaderText = "Valor Final";
            //dataGridView1.Columns["Valor_Producto_Financiacion"].DefaultCellStyle.Format = "n2";
            //dataGridView1.Columns["Valor_Producto_Financiacion"].Width = 70;
            //dataGridView1.Columns["Valor_Sin_interes"].HeaderText = "Valor Inicial";
            //dataGridView1.Columns["Valor_Sin_interes"].DefaultCellStyle.Format = "n0";
            //dataGridView1.Columns["Valor_Sin_interes"].Width = 70;
            //dataGridView1.Columns["Valor_Entrada"].HeaderText = "Valor Entrada";
            //dataGridView1.Columns["Valor_Entrada"].DefaultCellStyle.Format = "n0";
            //dataGridView1.Columns["Valor_Entrada"].Width = 70;
            //dataGridView1.Columns["Cuotas_Sin_interes"].HeaderText = "cuotas Inicial";
            //dataGridView1.Columns["Cuotas_Sin_interes"].Width = 40;
            //dataGridView1.Columns["Valor_Cuota_Sin_interes"].HeaderText = "Valor cuotas Inicial";
            //dataGridView1.Columns["Valor_Cuota_Sin_interes"].DefaultCellStyle.Format = "n2";
            //dataGridView1.Columns["Valor_Cuota_Sin_interes"].Width = 70;
            //dataGridView1.Columns["Valor_Con_Interes"].HeaderText = "Valor Saldo";
            //dataGridView1.Columns["Valor_Con_Interes"].DefaultCellStyle.Format = "n2";
            //dataGridView1.Columns["Valor_Con_Interes"].Width = 70;
            //dataGridView1.Columns["Cuotas_Con_Interes"].HeaderText = "Cuotas Saldo";
            //dataGridView1.Columns["Cuotas_Con_Interes"].Width = 40;
            //dataGridView1.Columns["Valor_Cuota_Con_Interes"].HeaderText = "Valor cuotas saldo";
            //dataGridView1.Columns["Valor_Cuota_Con_Interes"].DefaultCellStyle.Format = "n2";
            //dataGridView1.Columns["Valor_Cuota_Con_Interes"].Width = 70;
            //dataGridView1.Columns["Valor_Interes"].HeaderText = "Interes";
            //dataGridView1.Columns["Valor_Interes"].Width = 40;
            //dataGridView1.Columns["Fecha_Recaudo"].HeaderText = "Fecha recaudo";
            //dataGridView1.Columns["Estado_Financiacion"].HeaderText = "Estado";
            //dataGridView1.Columns["Fecha_Venta"].Visible = false;
            //dataGridView1.Columns["Id_Refinanciacion"].Visible = false;
            //dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }       
               
    }
}
