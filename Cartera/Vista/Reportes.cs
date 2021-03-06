﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cartera.Controlador;
using Cartera.Reportes;

namespace Cartera.Vista
{
    public partial class Reportes : Form
    {
        Loading cargando;
        CPago pagos = new CPago();
        CProducto producto= new CProducto();
        CCuota cuota = new CCuota();
        CCartera cartera = new CCartera();
        DataTable DtPagos = new DataTable();
        DataTable DtProgramado = new DataTable();
        DataTable DtVentas = new DataTable();
        DataTable DtDisolucion = new DataTable();
        private ReportesPDF reportesPDF;
        public Reportes()
        {
            InitializeComponent();
            reportesPDF = new ReportesPDF();
            DateTime actual = DateTime.ParseExact(DateTime.Now.ToString("yyyy-MM-dd"), "yyyy-MM-dd", CultureInfo.InvariantCulture);
            dateInicio.Text = actual.AddMonths(-1).ToString();
        }        
        private void Reportes_Load(object sender, EventArgs e)
        {
            CargarRpPagos();
            try
            {
                dataGridView1.Columns[6].DefaultCellStyle.Format = "n0";
                dataGridView1.Columns[8].DefaultCellStyle.Format = "n0";
            }
            catch
            {
            }            
        }
        private void limpiarlabel()
        {
            labelTotal.Text = "";
            labelNumero.Text = "";
        }
        private void CargarRpPagos()
        {
            try
            {            
            DtPagos = pagos.reportPagos(dateInicio.Text, datefin.Text);
            DataTable DtValorPagos = pagos.ValorReportPagos(dateInicio.Text, datefin.Text);
            Int64 total = Int64.Parse(DtValorPagos.Rows[0]["valor"].ToString());
            labelTotal.Text = "TOTAL INGRESOS: $" + String.Format("{0:N0}", total);
            labelNumero.Text ="CANTIDAD: "+ DtValorPagos.Rows[0]["pagos"].ToString();
            dataGridView1.DataSource = DtPagos;
            dataGridView1.Columns[1].Width = 50;
            dataGridView1.Columns[2].Width = 80;
            dataGridView1.Columns[3].Width = 230;
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            catch
            {
                MessageBox.Show("Sin datos para el reporte, seleccione un nuevo rango de fechas", "No hay resultados", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private async Task CargarRpProyeccion()
        {
            //tarea temporal para mostrar el loading 
            Mostrar();
            var cargar = new Task(() =>
            {
                actulziarCuotas();
            });
            cargar.Start();
            await cargar;
            cerrar();
            
            DtProgramado = cuota.reportProyeccion(dateInicio.Text, datefin.Text);
            dataGridView4.DataSource = DtProgramado;
            labelNumero.Text = "CANTIDAD: " + DtProgramado.Rows.Count;
            dataGridView4.Columns[0].Width = 55;
            dataGridView4.Columns[1].DefaultCellStyle.Format = "n0";
            dataGridView4.Columns[1].Width = 80;
            dataGridView4.Columns[2].Width = 80;
            dataGridView4.Columns[3].Width = 250;
            dataGridView4.Columns[4].Width = 250;
            dataGridView4.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            Int64 total = 0;
            foreach (DataRow row in DtProgramado.Rows)
            {
                //elimino las , amtes de hacer la operacion suma del total
                total += Convert.ToInt64(row["Valor a Pagar"].ToString().Replace(",", ""));                
            }
            labelTotal.Text = "TOTAL INGRESOS: $ " + String.Format("{0:N0}", total);
        }
        public void Mostrar()
        {
            cargando = new Loading();
            cargando.Show();
        }
        public void cerrar()
        {
            if(cargando != null)
                cargando.Close();
        }
        private void CargarRpVentas()
        {
            try
            {
                DtVentas = producto.ReportVentas(dateInicio.Text, datefin.Text);
                DataTable DtValorVentas = producto.ValorReportVentas(dateInicio.Text, datefin.Text);
                Int64 total = Int64.Parse(DtValorVentas.Rows[0]["valor"].ToString());
                labelTotal.Text = "VALOR VENTAS: $" + String.Format("{0:N0}", total);
                labelNumero.Text = "CANTIDAD: " + DtValorVentas.Rows[0]["productos"].ToString();
                dataGridView2.DataSource = DtVentas;
                dataGridView2.Columns[3].DefaultCellStyle.Format = "n0";
                dataGridView2.Columns["Cedula"].Visible = false;
                dataGridView2.Columns[2].Width = 80;
                dataGridView2.Columns[3].Width = 80;
                dataGridView2.Columns[4].Width = 80;
                dataGridView2.Columns[6].Width = 250;
                dataGridView2.Columns[7].Width = 250;
                dataGridView2.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            catch
            {
                MessageBox.Show("Sin datos para el reporte, seleccione un nuevo rango de fechas", "No hay resultados", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void CargarDisoluciones()
        {
            try
            {
                DtDisolucion = cartera.Disoluciones(dateInicio.Text, datefin.Text);
                DataTable DtValorDisolucion = cartera.TotalDisoluciones(dateInicio.Text, datefin.Text);
                Int64 total = Int64.Parse(DtValorDisolucion.Rows[0]["Total Devuelto"].ToString());
                labelTotal.Text = "VALOR DEVUELTO: $" + String.Format("{0:N0}", total);
                labelNumero.Text = "CANTIDAD: " + DtValorDisolucion.Rows[0]["Cantiad"].ToString();
                dataGridView3.DataSource = DtDisolucion;
                dataGridView3.Columns[1].Width = 130;
                dataGridView3.Columns[2].Width = 130;
                dataGridView3.Columns[5].DefaultCellStyle.Format = "n0";
                dataGridView3.Columns[6].DefaultCellStyle.Format = "n0";
                dataGridView3.Columns[7].DefaultCellStyle.Format = "n0";
                dataGridView3.Columns[8].Width = 50;
                dataGridView3.Columns[9].Width = 50;
                dataGridView3.Columns[10].Width = 50;
                dataGridView3.Columns[11].Width = 50;
                dataGridView3.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            catch
            {
                MessageBox.Show("Sin datos para el reporte, seleccione un nuevo rango de fechas", "No hay resultados", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            limpiarlabel();

             CargarTap();
        }
        private void CargarTap()
        {
            if (tabControl1.SelectedIndex == 0)
            {
                CargarRpPagos();
                groupBox2.Text = "Ingreso Observado";
                dataGridView1.Columns[5].DefaultCellStyle.Format = "n0";
            }
            else if (tabControl1.SelectedIndex == 1)
            {                
                CargarRpProyeccion();
                groupBox2.Text = "Ingreso Programado";
            }
            else if (tabControl1.SelectedIndex == 2)
            {
                CargarRpVentas();
                groupBox2.Text = "Ventas";
            }
            else if (tabControl1.SelectedIndex == 3)
            {
                CargarDisoluciones();
                groupBox2.Text = "Disoluciones";
            }
        }
        //metodo temporal para actuizar el estado de las cuotas 
        private void actulziarCuotas()
        {
            DataTable DtProducto = producto.cargarProductos();
            for (int i = 0; i < DtProducto.Rows.Count; i++)
            {
                string id_producto = DtProducto.Rows[i]["Id_Producto"].ToString();
                int id_financiacion = int.Parse(DtProducto.Rows[i]["Id_Financiacion"].ToString());
                int Valor_Producto_Financiacion = int.Parse(DtProducto.Rows[i]["Valor Total"].ToString());
                int valor_entrada = int.Parse(DtProducto.Rows[i]["Inicial"].ToString());                
                int Cuotas_sin_interes = int.Parse(DtProducto.Rows[i]["Cuotas Inicial"].ToString());
                int Valor_cuota_sin_interes = int.Parse(DtProducto.Rows[i]["Valor Cuota Inicial"].ToString());
                int Cuotas_Con_Interes = int.Parse(DtProducto.Rows[i]["Cuotas Saldo"].ToString());
                int Valor_Cuota_Con_Interes = int.Parse(DtProducto.Rows[i]["Valor Cuota Saldo"].ToString());
                string Fecha_Recaudo = DtProducto.Rows[i]["Fecha Recaudo"].ToString();
                DateTime date = DateTime.ParseExact(Fecha_Recaudo, "yyyy-MM-dd", CultureInfo.InvariantCulture);
                DateTime actual = DateTime.ParseExact(DateTime.Now.ToString("yyyy-MM-dd"), "yyyy-MM-dd", CultureInfo.InvariantCulture);
                if (Valor_Producto_Financiacion > 0 /*&& id_financiacion !=  0*/)
                {
                    DataTable dtCuotas = cuota.ListarCuotas(id_financiacion);
                    DataTable dtrecaudo = pagos.Tota_Recaudado_Producto(id_producto);
                    if (dtCuotas.Rows.Count <= (Cuotas_Con_Interes + Cuotas_sin_interes + 1))
                    {
                        cuota.EliminarCuotas(id_financiacion);
                        dtCuotas = cuota.ListarCuotas(id_financiacion);
                    }
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
            //MessageBox.Show("termino de actulziar");
        }
        private void actulziarCuotas2()
        {
            DataTable DtProducto = producto.cargarProductos();
            for(int i=0; i<DtProducto.Rows.Count; i++)
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
                DataTable dtCuotas = cuota.ListarCuotas(id_financiacion);
                DataTable dtrecaudo = pagos.Tota_Recaudado_Producto(id_producto);
                int num_cuota = 0;
                int contador = 1;
                int pagado = 0;
                int ValorPagado = 0;
                string Estado = "";
                if (dtrecaudo.Rows[0]["sum(Valor_Pagado)"].ToString() != "")
                {
                    ValorPagado = int.Parse(dtrecaudo.Rows[0]["sum(Valor_Pagado)"].ToString());

                    pagado = valor_entrada;
                    if (pagado <= ValorPagado)
                    {
                        Estado = "Pagada";
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
                cuota.ActulziarCuota(num_cuota, Estado, id_financiacion, "Valor Separación");
                num_cuota++;
                while (num_cuota <= Cuotas_sin_interes)
                {
                    pagado = pagado + Valor_cuota_sin_interes;
                    if (pagado <= ValorPagado)
                    {
                        Estado = "Pagada";
                    }
                    else
                    {
                        Estado = "Pendiente";
                    }
                    cuota.ActulziarCuota(num_cuota, Estado, id_financiacion, "Valor Inicial");
                    contador++;
                    num_cuota++;
                }
                num_cuota = 1;
                while (num_cuota <= Cuotas_Con_Interes)
                {
                    pagado = pagado + Valor_Cuota_Con_Interes;
                    if (pagado <= ValorPagado)
                    {
                        Estado = "Pagada";
                    }
                    else
                    {
                        Estado = "Pendiente";
                    }
                    cuota.ActulziarCuota(num_cuota, Estado, id_financiacion, "Valor Saldo");
                    contador++;
                    num_cuota++;
                }
            }
        }
        

        private void BtBuscar_Click(object sender, EventArgs e)
        {
            CargarTap();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string fechas = dateInicio.Text + " A " + datefin.Text;

            if (tabControl1.SelectedIndex == 0)
            {
                reportesPDF.Ingresos(DtPagos, labelTotal.Text, labelNumero.Text, fechas);
            }
            else if (tabControl1.SelectedIndex == 1)
            {
                reportesPDF.Programado(DtProgramado, labelTotal.Text, labelNumero.Text, fechas);
            }
            else if (tabControl1.SelectedIndex == 2)
            {
                reportesPDF.Ventas(DtVentas, labelTotal.Text, labelNumero.Text, fechas);
            }
            else if (tabControl1.SelectedIndex == 3)
            {
                reportesPDF.Disolucion(DtDisolucion, labelTotal.Text, labelNumero.Text, fechas);
            }
            else
            {
                MessageBox.Show("Error al generar reporte", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        
          
        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dataGridView1.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 16, e.RowBounds.Location.Y + 4);
            }
        }
        private void dataGridView4_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dataGridView4.RowHeadersDefaultCellStyle.ForeColor))
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
        private void dataGridView3_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dataGridView3.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 16, e.RowBounds.Location.Y + 4);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            if (tabControl1.SelectedIndex == 0)
            {
                exportarDatosExcel(dataGridView1);
            }
            else if (tabControl1.SelectedIndex == 1)
            {
                exportarDatosExcel(dataGridView4);
            }
            else if (tabControl1.SelectedIndex == 2)
            {
                exportarDatosExcel(dataGridView2);
            }
            else if (tabControl1.SelectedIndex == 3)
            {
                exportarDatosExcel(dataGridView3);
            }
            else
            {
                MessageBox.Show("Error al generar reporte", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
