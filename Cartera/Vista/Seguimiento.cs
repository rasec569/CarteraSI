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
    public partial class Seguimiento : Form
    {
        private ReportesPDF reportesPDF;
        string seguimientoId = "";
        DataTable DtRpSeguimiento = new DataTable();
        CSeguimiento seguimiento = new CSeguimiento();
        CProducto producto = new CProducto();
        string productoid = "";
        string Tipo;
        DateTime actual = DateTime.ParseExact(DateTime.Now.ToString("yyyy/MM/dd"), "yyyy/MM/dd", CultureInfo.InvariantCulture);
        
        public Seguimiento()
        {
            InitializeComponent();
            reportesPDF = new ReportesPDF();
        }
        public Seguimiento(string idproducto, string nombreproducto, string tipoproducto)
        {            
            InitializeComponent();
            reportesPDF = new ReportesPDF();
            string nombre = nombreproducto;
            Tipo = tipoproducto;
            LbNomProducto.Text = nombre;
            productoid = idproducto;
            DataTable DtCliente= producto.ClienteProducto(int.Parse(productoid));            
            LbPropietario.Text = "PROPIETARIO: " + DtCliente.Rows[0]["Nombre"].ToString()+" "+ DtCliente.Rows[0]["Apellido"].ToString();
            if (DtCliente.Rows[0]["Correo"].ToString() != "")
            {
                LbConctato.Text = "TELEFONO: " + DtCliente.Rows[0]["Telefono"].ToString() + " EMAIL: " + DtCliente.Rows[0]["Correo"].ToString();
            }
            else
            {
                LbConctato.Text = "TELEFONO: " + DtCliente.Rows[0]["Telefono"].ToString();
            }
            
            CargarSeguimiento();
        }

        public void CargarSeguimiento()
        {
            DataTable DtSeguimiento = seguimiento.CargarSeguimiento(productoid);
            dataGridView1.DataSource = DtSeguimiento;
            DtRpSeguimiento= DtSeguimiento.Copy();
            DtRpSeguimiento.Columns.Remove("Id_Seguimiento"); 
            DtRpSeguimiento.Columns.Remove("Fk_Id_Producto");
            DtRpSeguimiento.Columns[0].ColumnName = "Fecha";
            dataGridView1.Columns["Id_Seguimiento"].Visible = false;
            dataGridView1.Columns[1].HeaderText = "Fecha";
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridView1.Columns[2].HeaderText = "Comentario";
            dataGridView1.Columns["Fk_Id_Producto"].Visible = false;
        }

        private bool ValidarCampos()
        {
            bool ok = true;
            if (txtcomentario .Text == "")
            {
                ok = false;
                errorProvider1.SetError(txtcomentario, "Digite Comentario");
            }
            else
            {
                ok = true;
                errorProvider1.Clear();
            }

            return ok;
        }
        private void GuardarSegui_Click(object sender, EventArgs e)
        {
            ValidarCampos();
            if (ValidarCampos() == true)
            {
                if (seguimientoId == "")
                {
                    seguimiento.GuardarSeguimiento(txtcomentario.Text, dateTimePicker1.Text, productoid);
                }
                else
                {
                    seguimiento.ActualizarSeguimiento(int.Parse(seguimientoId), txtcomentario.Text, dateTimePicker1.Text);
                }              
                CargarSeguimiento();
                LimpiarCampos();
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            LimpiarCampos();
            int n = e.RowIndex;
            if (n != -1)
            {
                seguimientoId = dataGridView1.Rows[n].Cells["Id_Seguimiento"].Value.ToString();
                txtcomentario.Text = dataGridView1.Rows[n].Cells["Comentario"].Value.ToString();
                dateTimePicker1.Text = dataGridView1.Rows[n].Cells["Fecha_Seguimiento"].Value.ToString();
            }
            BtBorrar.Enabled = true;
        }
        private void LimpiarCampos()
        {
            seguimientoId = "";
            txtcomentario.Clear();
            dateTimePicker1.Text = actual.ToString();
            BtBorrar.Enabled = false;
        }

        private void BtBorrar_Click(object sender, EventArgs e)
        {
            if (txtcomentario.Text != "")
            {
                seguimiento.EliminarSeguimiento(int.Parse(seguimientoId));
                LimpiarCampos();
                CargarSeguimiento();
                BtBorrar.Enabled = true;
            }
            else
            {
                MessageBox.Show("Seleccione un Seguimeinto de la lista para eliminar");
            }
        }

        private void BtLimpiar_Click(object sender, EventArgs e)
        {
            if (txtcomentario.Text != "")
            {
                LimpiarCampos();
            }
            else
            {
                MessageBox.Show("No hay campos que borrar");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            reportesPDF.Seguimento(DtRpSeguimiento, Tipo, LbNomProducto.Text, LbPropietario.Text, LbConctato.Text);

        }
    }
}
