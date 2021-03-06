﻿using System;
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
    public partial class Carteras : Form
    {
        Loading cargando;
        CCartera cartera = new CCartera();
        CCliente cliente = new CCliente();
        CProducto producto = new CProducto();
        CProyecto proyecto = new CProyecto();
        CPago pago = new CPago();
        CCuota cuota = new CCuota();
        DataTable DtCartera = new DataTable();
        DataTable DtCliente = new DataTable();
        DataTable DtReporte = new DataTable();
        DateTime fecha_anterior;
        string estadoanterior = "";
        bool Validarestados = true;
        private ReportesPDF reportesPDF;
        public Carteras()
        {
            InitializeComponent();
            reportesPDF = new ReportesPDF();
        }
        private void Carteras_Load(object sender, EventArgs e)
        {
            CargarCartera();
            autocompletar();
            //actulziarCuotas();
        }
        private async Task cargar()
        {
            var cargar = new Task(() =>
            {
                actulziarCuotas();
            });
            //await CargarCartera();
        }

        private void CargarCartera()
        {
            if (Txtcedula.Text == "")
            {
                DtCartera = cartera.ListarCartera();
                DtReporte = DtCartera.Copy();
                DtReporte.Columns.Remove("Id_Cliente");
                DtReporte.Columns.Remove("Id_Cartera");

                //DtReporte.Columns[5].DefaultCellStyle.Format = "n1";
                dataGridView1.DataSource = DtCartera;
            }
            else
            {
                DtCartera = cartera.CarteraCliente(Txtcedula.Text);
                dataGridView1.DataSource = DtCartera;
            }
            DataTable DtValoreCartera = cartera.TotalesCartera();
            Int64 total = Int64.Parse(DtValoreCartera.Rows[0]["total"].ToString());
            Int64 deuda = Int64.Parse(DtValoreCartera.Rows[0]["saldo"].ToString());
            Int64 pagado = Int64.Parse(DtValoreCartera.Rows[0]["recaudo"].ToString());
            labelTotal.Text = "TOTAL: $ " + String.Format("{0:N0}", total);
            labelDeuda.Text = "VALOR DEUDA: $ " + String.Format("{0:N0}", deuda);
            labelRecaudo.Text = "VALOR RECAUDADO: $ " + String.Format("{0:N0}", pagado);
            this.dataGridView1.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dataGridView1_RowPostPaint);

            formatoGrid1();
        }
        private void formatoGrid1()
        {
            //dataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dataGridView1.Columns ["Id_Cliente"].Visible = false;
            dataGridView1.Columns [9].DefaultCellStyle.Format = "n0";
            //dataGridView1.Columns["Id_Producto"].Visible = false;
            dataGridView1.Columns [11].DefaultCellStyle.Format = "n0";
            dataGridView1.Columns [12].DefaultCellStyle.Format = "n0";
            dataGridView1.Columns ["Id_Cartera"].Visible = false;
            dataGridView1.Columns [2].Width = 120;
            dataGridView1.Columns [3].Width = 150;
            dataGridView1.Columns [4].Width = 100;
            dataGridView1.Columns [5].Width = 45;
            dataGridView1.Columns [6].Width = 45;
            dataGridView1.Columns [7].Width = 45;
            dataGridView1.Columns [8].Width = 45;
            dataGridView1.Columns [10].Width = 60;
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //dataGridView1.Columns[3].Width = 230;

            if (Validarestados == true)
            {
                actulizarestado();
            
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RegistrarPago Rp = new RegistrarPago();
            Rp.FormClosed += Pagos_FormClose;
            Rp.ShowDialog();
        }
        private void Pagos_FormClose(object sender, FormClosedEventArgs e)
        {
            Form frm = sender as Form;
            if(frm.DialogResult== DialogResult.OK)
            {
                Validarestados = true;
                CargarCartera();
            }
           
        }
        private void comboEstados_SelectedValueChanged(object sender, EventArgs e)
        {
            string Estados = comboEstados.Items[comboEstados.SelectedIndex].ToString();
            if (Estados == "Menos de 30 días")
            {
                DtCartera.DefaultView.RowFilter = $"Pago LIKE 'Menos de 30 días'";
            }
            else if (Estados == "De 31 a 60 días")
            {
                DtCartera.DefaultView.RowFilter = $"Pago LIKE 'De 31 a 60 días'";
            }
            else if (Estados == "De 61 a 90 días")
            {
                DtCartera.DefaultView.RowFilter = $"Pago LIKE 'De 61 a 90 días'";
            }
            else if (Estados == "De 91 a 180 días")
            {
                DtCartera.DefaultView.RowFilter = $"Pago LIKE 'De 91 a 180 días'";
            }
            else if (Estados == "Mas de 360 días")
            {
                DtCartera.DefaultView.RowFilter = $"Pago LIKE 'Mas de 360 días'";
            }
            else if (Estados == "Pagado")
            {
                DtCartera.DefaultView.RowFilter = $"Pago LIKE 'Pagado'";
            }
            else if(Estados=="Todo")
            {
                CargarCartera();
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int cedula = 0;
            string nombre = "";
            string apellido = "";
            string clienteid = "";
            string carteraid = "";
            try
            {
                int x = dataGridView1.Rows.Count;
                int n = e.RowIndex;
                if (n < x)
                {
                    clienteid = dataGridView1.Rows[n].Cells["Id_Cliente"].Value.ToString();
                    //quitar comas
                    cedula = int.Parse(dataGridView1.Rows[n].Cells["Cedula"].Value.ToString().Replace(",", ""));
                    nombre = dataGridView1.Rows[n].Cells["Nombres"].Value.ToString();
                    apellido = dataGridView1.Rows[n].Cells["Apellidos"].Value.ToString();
                    carteraid = dataGridView1.Rows[n].Cells["Id_Cartera"].Value.ToString();
                    Detalle D = new Detalle(cedula, nombre + " " + apellido, clienteid, carteraid);
                    D.FormClosed += Pagos_FormClose;
                    D.Show();
                }
                else
                {
                    MessageBox.Show("Campo no valido" , "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Valor no admitido"+ex);
            }
        }
        private void actulizarestado()
        {
            for (int i = 0; i < DtCartera.Rows.Count; i++)
            {
                if (DtCartera.Rows[i]["Pago"].ToString() != "Disuelto")
                {
                    string Cliente = DtCartera.Rows[i]["Id_Cliente"].ToString();
                    //error de comas al parecer
                    if (int.Parse(DtCartera.Rows[i]["Recaudado"].ToString().Replace(",", "")) - int.Parse(DtCartera.Rows[i]["Total"].ToString().Replace(",", "")) == 0)
                    {
                        cartera.ActulizarEstados(DtCartera.Rows[i]["Id_Cartera"].ToString(), "Pagado", 0, 0, 0, 0);
                        //dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Aquamarine;
                    }
                    else
                    {
                        DataTable dtproducto = producto.cargarProductosCliente(int.Parse(Cliente));
                        for (int j = 0; j < dtproducto.Rows.Count; j++)
                        {
                            string Producto = dtproducto.Rows[j]["Id_Producto"].ToString();
                            DataTable dtfechas = cartera.BuscarFechaspagos(int.Parse(Producto));
                            int financiacion = int.Parse(dtfechas.Rows[0]["Id_Financiacion"].ToString());

                            if (dtproducto.Rows[j]["Forma Pago"].ToString() == "Contado")
                            {
                                for (int h = 0; h < dtfechas.Rows.Count; h++)
                                {
                                    if (dtfechas.Rows.Count > 0 && !string.IsNullOrEmpty(dtfechas.Rows[h]["Fecha Pago"].ToString()))
                                    {
                                        cartera.ActulizarEstados(DtCartera.Rows[i]["Id_Cartera"].ToString(), "Pagado", 0, 0, 0, 0);
                                    }
                                    else
                                    {
                                        cartera.ActulizarEstados(DtCartera.Rows[i]["Id_Cartera"].ToString(), "Sin pagos Contado", 0, 0, 0, 0);
                                    }
                                }
                            }
                            else
                            {

                                for (int h = 0; h < dtfechas.Rows.Count; h++)
                                {
                                    if (dtfechas.Rows.Count > 0 && !string.IsNullOrEmpty(dtfechas.Rows[h]["Fecha_Recaudo"].ToString()))
                                    {
                                        bool cambio = true;
                                        string fecha1 = dtfechas.Rows[h]["Fecha_Pago"].ToString();
                                        string fecha2 = dtfechas.Rows[h]["Fecha_Recaudo"].ToString();
                                        int cuotas = int.Parse(dtfechas.Rows[h]["Cuotas"].ToString());
                                        DataTable dtcuotas = cuota.CuotasPagadas(financiacion);
                                        int pagos = int.Parse(dtcuotas.Rows[0]["cuotas"].ToString()) - 1;
                                        //DataTable dtcuotas = pago.ConsultarCuotas(int.Parse(Producto), "Inicial%");
                                        //int pagos = 0;
                                        //if (!string.IsNullOrEmpty(dtcuotas.Rows[h]["cuotas"].ToString()) && (int.Parse(dtcuotas.Rows[h]["cuotas"].ToString()) > int.Parse(dtfechas.Rows[h]["Cuotas_Sin_interes"].ToString())))
                                        //{
                                        //    pagos = int.Parse(dtcuotas.Rows[h]["cuotas"].ToString());
                                        //    dtcuotas = pago.ConsultarCuotas(int.Parse(Producto), "Saldo%");
                                        //    if (!string.IsNullOrEmpty(dtcuotas.Rows[h]["cuotas"].ToString()))
                                        //    {
                                        //        pagos = int.Parse(dtfechas.Rows[h]["Cuotas_Sin_interes"].ToString()) + int.Parse(dtcuotas.Rows[h]["cuotas"].ToString());
                                        //    }
                                        //}
                                        //else
                                        //{
                                        //    dtcuotas = pago.ConsultarCuotas(int.Parse(Producto), "%");
                                        //    pagos = int.Parse(dtcuotas.Rows[h]["cuotas"].ToString());
                                        //}
                                        DateTime date_1 = DateTime.ParseExact(fecha1, "yyyy-MM-dd", CultureInfo.InvariantCulture);
                                        DateTime date_2 = DateTime.ParseExact(fecha2, "yyyy-MM-dd", CultureInfo.InvariantCulture);
                                        DateTime actual = DateTime.ParseExact(DateTime.Now.ToString("yyyy-MM-dd"), "yyyy-MM-dd", CultureInfo.InvariantCulture);
                                        TimeSpan Ultimo = actual.Subtract(date_1);
                                        TimeSpan trascurrido = actual.Subtract(date_2);

                                        int dia = int.Parse(trascurrido.Days.ToString());
                                        int meses = dia / 30;
                                        int mes_mora = 0;
                                        int mora = 0;
                                        if (cuotas < meses)
                                        {
                                            mes_mora = meses - pagos;
                                            if (cuotas < pagos)
                                            {
                                                mora = cuotas;
                                            }
                                            else
                                            {
                                                mora = cuotas - pagos;
                                            }
                                        }
                                        else if (meses - pagos <= 0)
                                        {
                                            mora = 0;
                                            mes_mora = 0;
                                        }
                                        else
                                        {
                                            mora = meses - pagos;
                                            mes_mora = meses - pagos;
                                        }
                                        string estado = "";
                                        if (cambio == true)
                                        {
                                            //switch (DiasMora)
                                            switch (Ultimo.Days)
                                            {
                                                case int n when n <= 30:
                                                    estado = "Menos de 30 días";
                                                    break;
                                                case int n when n <= 60:
                                                    estado = "De 31 a 60 días";
                                                    break;
                                                case int n when n <= 90:
                                                    estado = "De 61 a 90 días";
                                                    break;
                                                case int n when n <= 180:
                                                    estado = "De 91 a 180 días";
                                                    break;
                                                case int n when n <= 360:
                                                    estado = "De 181 a 360 días";
                                                    break;
                                                case int n when n >= 360:
                                                    estado = "Mas de 360 días";
                                                    break;
                                            }
                                        }
                                        if (dtproducto.Rows.Count > 1)
                                        {
                                            if (fecha_anterior.ToString() == "01/01/0001 12:00:00 a.m.")
                                            {
                                                fecha_anterior = date_1;
                                                estadoanterior = estado;
                                            }
                                            else
                                            {
                                                int result = DateTime.Compare(date_1, fecha_anterior);
                                                if (result < 0)
                                                {
                                                    cambio = false;
                                                }
                                                else if (result == 0)
                                                {
                                                    cambio = true;
                                                }
                                                else
                                                {
                                                    cambio = true;
                                                }
                                            }
                                        }
                                        cartera.ActulizarEstados(DtCartera.Rows[i]["Id_Cartera"].ToString(), estado, cuotas, mes_mora, pagos, mora);
                                    }
                                    else if (string.IsNullOrEmpty(dtfechas.Rows[h]["Fecha_Pago"].ToString()))
                                    {
                                        cartera.ActulizarEstados(DtCartera.Rows[i]["Id_Cartera"].ToString(), "Sin pagos credito", 0, 0, 0, 0);

                                    }
                                }
                            }
                        }
                    }
                }                           
            }
            Validarestados = false;
            CargarCartera();
        }
        private void BtHistorialPago_Click(object sender, EventArgs e)
        {
            HistorialPagos Hp = new HistorialPagos();
            Hp.FormClosed += Pagos_FormClose;
            Hp.ShowDialog();
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            CargarCartera();
        }
        void autocompletar()
        {
            AutoCompleteStringCollection lista = new AutoCompleteStringCollection();
            DtCliente = cliente.cargarClientes();
            for (int i = 0; i < DtCliente.Rows.Count; i++)
            {
                lista.Add(DtCliente.Rows[i]["Cedula"].ToString());
            }
            Txtcedula.AutoCompleteCustomSource = lista;
        }
        private void dataGridView1_CellMouseEnter_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex >= 0 & e.RowIndex >= 0)
            {
                DataGridViewCell cell = this.dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
                cell.ToolTipText = "Doble clic para Registrar pago";
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            Txtcedula.Clear();
            comboProyecto.Text = "TODOS LOS PROYECTOS";
            comboEstados.Text = "seleccione una opción";
            CargarCartera();
        }

        private void button2_Click(object sender, EventArgs e)
        {            
            reportesPDF.Cartera(DtReporte, labelTotal.Text, labelRecaudo.Text, labelDeuda.Text, comboProyecto.Text);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            int n = e.RowIndex;
            try
            {
                if (dgv.Columns[e.ColumnIndex].Name == "Pago")  //Si es la columna a evaluar
                {
                    
                    if (n != -1)
                    {
                        if (e.Value.ToString().Contains("Pagado"))   //Si el valor de la celda contiene la palabra hora
                        {
                            e.CellStyle.ForeColor = Color.DarkGreen;
                            e.CellStyle.BackColor = Color.LightGreen;
                        }
                        else if (e.Value.ToString().Contains("Mas de 360 días"))
                        {
                            e.CellStyle.ForeColor = Color.Crimson;
                            e.CellStyle.BackColor = Color.Orange;
                            //e.CellStyle.BackColor = Color.PaleVioletRed;
                        }
                        //else if (e.Value.ToString().Contains("De 91 a 180 días"))
                        //{
                        //    e.CellStyle.ForeColor = Color.OrangeRed;
                        //}
                        //else if(e.Value.ToString().Contains("De 61 a 90 días"))
                        //{
                        //    e.CellStyle.ForeColor = Color.Orange;
                        //}
                        //else if (e.Value.ToString().Contains("De 31 a 60 días"))
                        //{
                        //    e.CellStyle.ForeColor = Color.BlueViolet;
                        //}
                        //else if (e.Value.ToString().Contains("Menos de 30 días"))
                        //{
                        //    e.CellStyle.ForeColor = Color.DodgerBlue;
                        //}
                    }
                }
            }
            catch
            {

            }            
        }

        private void comboProyecto_MouseClick(object sender, MouseEventArgs e)
        {
            if (comboProyecto.Text == "TODOS LOS PROYECTOS")
            {
                comboProyecto.DataSource = proyecto.listarProyectos();
                comboProyecto.DisplayMember = "Proyecto_Nombre";
                comboProyecto.ValueMember = "Id_Proyecto";
            }            
            
        }

        private void comboProyecto_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {                
                DtCartera = cartera.ListarCarteraProyecto(int.Parse(comboProyecto.SelectedIndex.ToString()));
                DtReporte = DtCartera.Copy();
                DtReporte.Columns.Remove("Id_Cliente");
                DtReporte.Columns.Remove("Id_Cartera");
                dataGridView1.DataSource = DtCartera;

                Int64 total = 0;
                Int64 deuda = 0;
                Int64 pagado = 0;

                foreach (DataRow row in DtCartera.Rows)
                {
                    //string ensayo = row["Total"].ToString().Trim(new Char[] { ',', ',', ',' });
                    //string resultado = row["Total"].ToString().Replace(",", "");
                    //elimino las , amtes de hacer la operacion suma del total
                    total += Convert.ToInt64(row["Total"].ToString().Replace(",", ""));
                    deuda += Convert.ToInt64(row["Saldo"].ToString().Replace(",", ""));
                    pagado += Convert.ToInt64(row["Recaudado"].ToString().Replace(",", ""));

                }
                labelTotal.Text = "TOTAL: $ " + String.Format("{0:N0}", total);
                labelDeuda.Text = "VALOR DEUDA: $ " + String.Format("{0:N0}", deuda);
                labelRecaudo.Text = "VALOR RECAUDADO: $ " + String.Format("{0:N0}", pagado);
                this.dataGridView1.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dataGridView1_RowPostPaint);
                formatoGrid1();
            }
            catch
            {

            }
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            comboProyecto.Text = "TODOS LOS PROYECTOS";
            CargarCartera();
        }

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dataGridView1.RowHeadersDefaultCellStyle.ForeColor))
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

        private void button4_Click_1(object sender, EventArgs e)
        {
            exportarDatosExcel(dataGridView1);
        }
        private void actulziarCuotas()
        {
            DataTable DtProducto = producto.cargarProductos();
            for (int i = 0; i < DtProducto.Rows.Count; i++)
            {
                string id_producto = DtProducto.Rows[i]["Id_Producto"].ToString();
                int id_financiacion = int.Parse(DtProducto.Rows[i]["Id_Financiacion"].ToString());
                int Valor_Producto_Financiacion = int.Parse(DtProducto.Rows[i]["Valor Total"].ToString());
                int valor_entrada = int.Parse(DtProducto.Rows[i]["Inicial"].ToString());
                int valor_sin_interes = int.Parse(DtProducto.Rows[i]["Valor Inicial"].ToString());
                int Cuotas_sin_interes = int.Parse(DtProducto.Rows[i]["Cuotas Inicial"].ToString());
                int Valor_cuota_sin_interes = int.Parse(DtProducto.Rows[i]["Valor Cuota Inicial"].ToString());
                int Valor_con_interes = int.Parse(DtProducto.Rows[i]["Valor Saldo"].ToString());
                int Cuotas_Con_Interes = int.Parse(DtProducto.Rows[i]["Cuotas Saldo"].ToString());
                int Valor_Cuota_Con_Interes = int.Parse(DtProducto.Rows[i]["Valor Cuota Saldo"].ToString());
                string Fecha_Recaudo = DtProducto.Rows[i]["Fecha Recaudo"].ToString();
                DateTime date = DateTime.ParseExact(Fecha_Recaudo, "yyyy-MM-dd", CultureInfo.InvariantCulture);
                DateTime actual = DateTime.ParseExact(DateTime.Now.ToString("yyyy-MM-dd"), "yyyy-MM-dd", CultureInfo.InvariantCulture);
                if (Valor_Producto_Financiacion > 0 /*&& id_financiacion !=  0*/)
                {
                    DataTable dtCuotas = cuota.ListarCuotas(id_financiacion);
                    DataTable dtrecaudo = pago.Tota_Recaudado_Producto(id_producto);
                    int num_cuota = 0;
                    int contador = 1;
                    int pagado = 0;
                    int ValorPagado = 0;
                    string Estado = "";
                    int result = DateTime.Compare(date, actual);
                    if (dtrecaudo.Rows[0]["sum(Valor_Pagado)"].ToString() != "")
                    {
                        ValorPagado = int.Parse(dtrecaudo.Rows[0]["sum(Valor_Pagado)"].ToString());

                        pagado = valor_entrada;
                        if (pagado <= ValorPagado)
                        {
                            Estado = "Pagada";
                        }
                        else if (result > 0)
                        {
                            Estado = "Mora";
                        }
                        else
                        {
                            Estado = "Pendiente";
                        }
                    }
                    else
                    {
                        Estado = "Pendiente";
                    }
                    if (dtCuotas.Rows.Count == 0)
                    {
                        cuota.CrearCuota(num_cuota, valor_entrada, "Valor Separación", date.ToString("yyyy-MM-dd"), Estado, id_financiacion);
                    }
                    else
                    {
                        cuota.ActulziarCuota(num_cuota, Estado, id_financiacion, "Valor Separación");
                    }
                    num_cuota++;
                    while (num_cuota <= Cuotas_sin_interes)
                    {
                        DateTime fechacuota = date.AddMonths(contador);
                        result = DateTime.Compare(fechacuota, actual);
                        pagado = pagado + Valor_cuota_sin_interes;
                        if (pagado <= ValorPagado)
                        {
                            Estado = "Pagada";
                        }
                        else if (result < 0)
                        {
                            Estado = "Mora";
                        }
                        else
                        {
                            Estado = "Pendiente";
                        }
                        if (dtCuotas.Rows.Count == 0)
                        {
                            cuota.CrearCuota(num_cuota, Valor_cuota_sin_interes, "Valor Inicial", date.AddMonths(contador - 1).ToString("yyyy-MM-dd"), Estado, id_financiacion);
                        }
                        else
                        {
                            cuota.ActulziarCuota(num_cuota, Estado, id_financiacion, "Valor Inicial");
                        }
                        contador++;
                        num_cuota++;
                    }
                    num_cuota = 1;
                    while (num_cuota <= Cuotas_Con_Interes)
                    {
                        DateTime fechacuota = date.AddMonths(contador);
                        result = DateTime.Compare(fechacuota, actual);
                        pagado = pagado + Valor_Cuota_Con_Interes;
                        if (pagado <= ValorPagado)
                        {
                            Estado = "Pagada";
                        }
                        else if (result.ToString() == "-1")
                        {
                            Estado = "Mora";
                        }
                        else
                        {
                            Estado = "Pendiente";
                        }
                        if (dtCuotas.Rows.Count == 0)
                        {
                            cuota.CrearCuota(num_cuota, Valor_Cuota_Con_Interes, "Valor Saldo", date.AddMonths(contador - 1).ToString("yyyy-MM-dd"), Estado, id_financiacion);
                        }
                        else
                        {
                            cuota.ActulziarCuota(num_cuota, Estado, id_financiacion, "Valor Saldo");
                        }
                        contador++;
                        num_cuota++;
                        
                    }
                }
            }
            MessageBox.Show("termino de actulziar");
        }
    }
}
