using Cartera.Controlador;
using Cartera.Reportes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Printing;
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
        string productoId = "";
        string carteraId ="";
        string clienteid = "";
        bool clearall = true;
        string Nom_Producto, Nom_Proyecto;
        int ProductoVal,ValorPagado,ValorDeuda,ValorNeto;
        private ReportesPDF reportesPDF;
        DataTable dtpagos = new DataTable();
        public HistorialPagos()
        {
            InitializeComponent();
            reportesPDF = new ReportesPDF();
            
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
            try
            {
                DataTable dtreporte = new DataTable();
                dtreporte = pago.ReportesPagosCliente(productoId);
                reportesPDF.HistorialPagos(dtreporte, txtCedula.Text,txtNombre.Text, Nom_Producto, Nom_Proyecto, labelNeto.Text, labelTotal.Text, labelDeuda.Text, labelPagado.Text);
                //printPreviewDialog1.Show();
            }
            catch/*(Exception ex)*/
            {
                //printPreviewDialog1.Close();
            }
            //var pagos= pago.ListarPagosCliente(productoId);
            //var rpth = new ReportClass();
            //rpth.SetDataSource(pagos);
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
                ValidarCampos();
                if ((error != true) && (ValidarCampos() == true))
                {
                    clearall = false;
                    limpiar();
                    cliente.BuscarClientesCedula(txtCedula.Text);
                    DataTable DtUsuario = cliente.BuscarClientesCedula(txtCedula.Text);
                    clienteid = DtUsuario.Rows[0]["Id_Cliente"].ToString();
                    carteraId= DtUsuario.Rows[0]["Fk_Id_Cartera"].ToString();
                    txtCedula.Text = DtUsuario.Rows[0]["Cedula"].ToString();
                    txtNombre.Text = DtUsuario.Rows[0]["Nombre"].ToString() + " " + DtUsuario.Rows[0]["Apellido"].ToString();
                    labelFecha.Text="Fecha: "+ DateTime.Now.ToShortDateString(); 
                    ListarProudctosCliente();
                    btLimpiar.Enabled = true;                    
                }
             }
            catch
             {
                MessageBox.Show ( "No existe cliente");
                txtCedula.Clear();
             }           
        }
        private bool ValidarCampos()
        {
            bool ok = true;
            if (txtCedula.Text == "")
            {
                ok = false;
                errorProvider1.SetError(txtCedula, "Digite cedula");
            }    
            return ok;
        }
        private void ListarProudctosCliente()
        {
            dataGridView2.Visible = false;         
            dataGridView1.DataSource = producto.cargarProductosCliente(int.Parse(clienteid));
            dataGridView1.Columns["Id_Producto"].Visible = false;
            dataGridView1.Columns["Observaciones"].Visible = false;
            dataGridView1.Columns["Fk_Id_Proyecto"].Visible = false;
            dataGridView1.Columns["Fk_Id_Tipo_Producto"].Visible = false;
            dataGridView1.Columns[4].DefaultCellStyle.Format = "N0";
            dataGridView1.Columns[5].DefaultCellStyle.Format = "N0";
            // pago.ListarPagosCliente();
        }
        private void limpiar()
        {
            dataGridView1.DataSource = "";
            dataGridView2.DataSource = "";
            btLimpiar.Enabled = false;
            BtImprimir.Enabled = false;
            dataGridView2.Visible = false;
            dataGridView1.Visible = true;
            labelTotal.Visible = false;
            labelPagado.Visible = false;
            labelNeto.Visible = false;
            labelDeuda.Visible = false;
            BtImprimir.Enabled = false;
            txtNombre.Clear();
            clienteid = "";
            if (clearall == true)
            {
                txtCedula.Clear();
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

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int n = e.RowIndex;
                if (n != -1)
                {
                    // Porcentaje, Numero_Cuota, Fecha_Pago, Referencia_Pago, Valor_Pagado, Descuento, Valor_Descuento, Fk_Id_Producto
                    productoId = dataGridView1.Rows[n].Cells["Id_Producto"].Value.ToString();                    
                    Nom_Producto = dataGridView1.Rows[n].Cells["Producto"].Value.ToString();
                    Nom_Proyecto = dataGridView1.Rows[n].Cells["Proyecto"].Value.ToString();
                    ValorNeto = int.Parse(dataGridView1.Rows[n].Cells["Valor Neto"].Value.ToString());
                    ProductoVal = int.Parse(dataGridView1.Rows[n].Cells["Valor Total"].Value.ToString());
                    ListarPagosCliente();
                }
                BtImprimir.Enabled = true;
                dataGridView2.Visible = true;
                dataGridView1.Visible = false;
            }
            catch
            {
                MessageBox.Show("Sin Pagos");
            }            
        }
        private void ListarPagosCliente()
        {
            DataTable dtrecaudo = pago.Tota_Recaudado_Producto(productoId);
            ValorPagado = int.Parse(dtrecaudo.Rows[0]["sum(Valor_Pagado)"].ToString());
            ValorDeuda = ProductoVal - ValorPagado;
            labelDeuda.Visible = true;
            labelPagado.Visible = true;
            labelTotal.Visible = true;
            labelNeto.Visible = true;
            labelDeuda.Text = "SALDO: $" + String.Format("{0:N0}", ValorDeuda);
            labelPagado.Text = "TOTAL ABONADO: $" + String.Format("{0:N0}", ValorPagado);
            labelTotal.Text = "VALOR TOTAL: $" + String.Format("{0:N0}", ProductoVal);
            labelNeto.Text= "VALOR NETO: $" + String.Format("{0:N0}", ProductoVal);
            dtpagos = pago.ListarPagosCliente(productoId);            
            dataGridView2.DataSource = dtpagos;
            dataGridView2.Columns["Id_Pagos"].Visible = false;
            dataGridView2.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView2.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView2.Columns[1].Width = 50;
            dataGridView2.Columns[2].Width = 80;
            dataGridView2.Columns[3].Width = 280;
            dataGridView2.Columns[4].Width = 150;
            dataGridView2.Columns[5].DefaultCellStyle.Format = "N0";
        }

        private void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int n = e.RowIndex;
                if (n != -1)
                {
                    int id_pagos = int.Parse(dataGridView2.Rows[n].Cells["Id_Pagos"].Value.ToString());
                    string pago= dataGridView2.Rows[n].Cells["Pago"].Value.ToString();
                    string tipo = dataGridView2.Rows[n].Cells["Tipo Pago"].Value.ToString();
                    string referencia = dataGridView2.Rows[n].Cells["Referencia"].Value.ToString();
                    string concepto = dataGridView2.Rows[n].Cells["Concepto"].Value.ToString();
                    string valor = dataGridView2.Rows[n].Cells["Valor"].Value.ToString();
                    string fecha = dataGridView2.Rows[n].Cells["Fecha"].Value.ToString();
                    string descuento = dataGridView2.Rows[n].Cells["Descuento"].Value.ToString();
                    string valordescuento = dataGridView2.Rows[n].Cells["Valor Descuento"].Value.ToString();
                    RegistrarPago Rp = new RegistrarPago(txtCedula.Text, txtNombre.Text, carteraId, int.Parse(productoId), Nom_Producto, id_pagos,pago, tipo, referencia, concepto, fecha, valor, descuento,valordescuento);
                    Rp.FormClosed += Pagos_FormClose;
                    Rp.ShowDialog();
                }
            }
            catch
            {
                MessageBox.Show("Sin Pagos");
            }
        }
        private void Pagos_FormClose(object sender, FormClosedEventArgs e)
        {
            Form frm = sender as Form;
            if (frm.DialogResult == DialogResult.OK)
            {
                ListarPagosCliente();
            }

        }

        private void HistorialPagos_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void dataGridView1_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex >= 0 & e.RowIndex >= 0)
            {
                DataGridViewCell cell = this.dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
                cell.ToolTipText = "Doble clic para ver pagos";
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void btLimpiar_Click(object sender, EventArgs e)
        {
            clearall = true;
            limpiar();
        }
        //public static int GetPageCount(PrintDocument printDocument)
        //{
        //    int count = 0;
        //    printDocument.PrintController = new PreviewPrintController();
        //    printDocument.PrintPage += (sender, e) => count++;
        //    printDocument.Print();
        //    return count;
        //}
        //private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        //{
            
        //    string imagen = @"C:\Users\RASEC\Documents\Cartera\CarteraSI\Cartera\img\logo 2 San Isidro.png"; 
        //    Font Tipotex = new Font("Arial", 12, FontStyle.Bold);
        //    Font Tipotex1 = new Font("Arial", 12, FontStyle.Regular);
        //    Font Tipotex2 = new Font("Arial", 11, FontStyle.Regular);
        //    Image img = Image.FromFile(imagen);
        //    e.Graphics.FillRectangle(Brushes.Black, 20, 10, 20, 60);
        //    e.Graphics.DrawImage(img, new Rectangle(20, 10, 70, 70));
        //    e.Graphics.DrawString("HISTORIAL DE PAGOS URBANIZADORA Y CONSTRUCTORA SAN ISIDRO", Tipotex, Brushes.Black, 100, 30);
        //    e.Graphics.DrawString("NIT: 901100097-1", Tipotex, Brushes.Black, 100, 30);
        //    e.Graphics.DrawString("Docuemento N°:", Tipotex1, Brushes.Black, 40, 70);
        //    e.Graphics.DrawString(txtCedula.Text, Tipotex1, Brushes.Black, 170, 70);
        //    e.Graphics.DrawString("Nombre:", Tipotex1, Brushes.Black, 280, 70);
        //    e.Graphics.DrawString(txtNombre.Text, Tipotex1, Brushes.Black, 350, 70);
        //    e.Graphics.DrawString("Fecha", Tipotex1, Brushes.Black, 660, 70);
        //    e.Graphics.DrawString(txtFecha.Text, Tipotex1, Brushes.Black, 710, 70);
        //    e.Graphics.DrawString("Producto:", Tipotex1, Brushes.Black, 40, 100);
        //    e.Graphics.DrawString(Nom_Producto, Tipotex1, Brushes.Black, 140, 100);
        //    e.Graphics.DrawString("Proyecto:", Tipotex1, Brushes.Black, 350, 100);
        //    e.Graphics.DrawString(Nom_Proyecto, Tipotex1, Brushes.Black, 450, 100);
        //    int left = e.MarginBounds.Left, top = e.MarginBounds.Top+40;
        //    foreach (DataGridViewColumn col in dataGridView2.Columns)
        //    {
        //        e.Graphics.DrawString(col.HeaderText, Tipotex2, Brushes.Black, left, top);
        //        left += col.Width;
        //        if (col.Index < dataGridView2.ColumnCount - 1)
        //            e.Graphics.DrawLine(Pens.Gray, left - 5, top, left - 5, top + 43 + (dataGridView2.RowCount - 1) * 35);
        //    }
        //    left = e.MarginBounds.Left;
        //    e.Graphics.FillRectangle(Brushes.Black, left,top+40,e.MarginBounds.Right-left, 3);
        //    top += 43;
        //    foreach(DataGridViewRow row in dataGridView2.Rows)
        //    {
        //        if (row.Index == dataGridView2.RowCount - 1) break;
        //        left = e.MarginBounds.Left;
        //        foreach (DataGridViewCell cell in row.Cells)
        //        {
        //            e.Graphics.DrawString(Convert.ToString(cell.Value), Tipotex2, Brushes.Black, left, top + 4);
        //            left += cell.OwningColumn.Width;
        //        }
        //        top += 35;
        //        e.Graphics.DrawLine(Pens.Gray, e.MarginBounds.Left, top, e.MarginBounds.Right, top);
                

        //    }
        //    e.Graphics.DrawString("El reporte se expide a solicitud del Cliente.", Tipotex1, Brushes.Black, 50, top+30);

        //    //Bitmap GridBitmap = new Bitmap(this.dataGridView2.Width, this.dataGridView2.Height);
        //    //dataGridView2.DrawToBitmap(GridBitmap, new Rectangle(0,0, this.dataGridView2.Width, this.dataGridView2.Height));
        //    //e.Graphics.DrawImage(GridBitmap,50,100);
        //}
    } 
}
