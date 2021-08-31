using Cartera.Controlador;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cartera.Vista
{
    public partial class GraficoVentas : Form
    {
        CProducto producto = new CProducto();
        CProyecto proyecto = new CProyecto();
        DataTable Dtproyectos = new DataTable();
        public GraficoVentas()
        {
            InitializeComponent();
        }

        private void GraficoVentas_Load(object sender, EventArgs e)
        {
            Grafico();
            Dtproyectos = proyecto.listarProyectos();
            DataRow nueva = Dtproyectos.NewRow();
            nueva["Id_Proyecto"] = 4;
            nueva["Proyecto_Nombre"] = "TODOS LOS PROYECTOS";
            Dtproyectos.Rows.InsertAt(nueva, 0);
            comboProyecto.DataSource = Dtproyectos;
            comboProyecto.DisplayMember = "Proyecto_Nombre";
            comboProyecto.ValueMember = "Id_Proyecto";

        }
        private void Grafico()
        {
            DateTime actual = DateTime.ParseExact(DateTime.Now.ToString("yyyy-MM-dd"), "yyyy-MM-dd", CultureInfo.InvariantCulture);
            try
            {
                DataTable DtVentas = new DataTable();
                if (comboProyecto.Text == "TODOS LOS PROYECTOS")
                {
                    DtVentas = producto.ReportVentas("2018-01-01", actual.ToString("yyyy-MM-dd"));
                }
                else if (comboProyecto.Text == "")
                {
                    DtVentas = producto.ReportVentas("2018-01-01", actual.ToString("yyyy-MM-dd"));
                }
                else
                {
                    DtVentas = producto.ReportVentasProyecto("2018-01-01", actual.ToString("yyyy-MM-dd"), comboProyecto.SelectedValue.ToString());
                }

                ArrayList fechaventa = new ArrayList();
                ArrayList valorventa = new ArrayList();

                for (int i = 0; i < DtVentas.Rows.Count; i++)
                {
                    fechaventa.Add(DtVentas.Rows[i]["Fecha"].ToString());
                    valorventa.Add(DtVentas.Rows[i]["Valor"].ToString());
                }
                    chart3.Series[0].Points.DataBindXY(fechaventa, valorventa);                
            }
            catch (Exception e)
            {
                MessageBox.Show("Error: " + e);
            }
        }

        private void comboProyecto_SelectedIndexChanged(object sender, EventArgs e)
        {
            Grafico();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            chart3.Printing.PrintPreview();
        }
    }
}
