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
    public partial class Principal : Form
    {

        public Principal()
        {
            InitializeComponent();
        }
        private void Principal_Load(object sender, EventArgs e)
        {
           FormularioHijo<Carteras>();
        }
        public void FormularioHijo<MiForm>() where MiForm: Form, new()
        {
            if (this.PanelContenedor.Controls.Count > 0)
                this.PanelContenedor.Controls.RemoveAt(0);
            Form formulario;
            formulario = PanelContenedor.Controls.OfType<MiForm>().FirstOrDefault();
            if (formulario == null)
            {
                formulario = new MiForm();
                formulario.TopLevel = false;
                formulario.Dock = DockStyle.Fill;
                this.PanelContenedor.Controls.Add(formulario);
                this.PanelContenedor.Tag = formulario;
                formulario.Show();

            }
            else
            {
                formulario.BringToFront();
            }     
        }
        private void BtClientes_Click(object sender, EventArgs e)
        {
            FormularioHijo<Clientes>();
        }
        private void BtProyectos_Click(object sender, EventArgs e)
        {            
            FormularioHijo<Proyectos>();        
        }
        private void BtSalir_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }
        private void PanelContenedor_Paint(object sender, PaintEventArgs e)
        {

        }
        private void BtProductos_Click(object sender, EventArgs e)
        {
            FormularioHijo<Productos>();
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            FormularioHijo<Carteras>();
        }
        public void AbrirCliente()
        {
            FormularioHijo<Clientes>();
        }
    }
}
