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
    public partial class RegistrarPago : Form
    {
        DataTable DtNombres = new DataTable();
        public RegistrarPago()
        {
            InitializeComponent();
            
        }

        private void RegistrarPago_Load(object sender, EventArgs e)
        {
            autocompletar();
        }

        private void button1_Click(object sender, EventArgs e)
        {

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
    }
    
}
