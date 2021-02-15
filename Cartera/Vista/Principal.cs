using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using Cartera.Vista;

namespace Cartera.Vistas
{
    public partial class Principal : Form
    {

        public Principal()
        {
            InitializeComponent();

        }
        private void Principal_Load(object sender, EventArgs e)
        {
            SQLiteConnectionStringBuilder builder = new SQLiteConnectionStringBuilder();
            builder.DataSource = "Cartera San Isidro.db";
            Console.WriteLine(builder.ConnectionString);

        }

        private void FormularioHijo(Object FormHijo)
        {
            if (this.PanelContenedor.Controls.Count > 0)
                this.PanelContenedor.Controls.RemoveAt(0);
            Form fh = FormHijo as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            this.PanelContenedor.Controls.Add(fh);
            this.PanelContenedor.Tag = fh;
            fh.Show();

        }
        private void BtClientes_Click(object sender, EventArgs e)
        {
            FormularioHijo(new Clientes());
        }

        private void BtProyectos_Click(object sender, EventArgs e)
        {
            FormularioHijo(new NuevoUsuario());        
        }
        private void BtSalir_Click(object sender, EventArgs e)
        {
            
            Application.Exit();
        }

        private void PanelContenedor_Paint(object sender, PaintEventArgs e)
        {

        }

        private void BtProductos_Click(object sender, EventArgs e)
        {
            FormularioHijo(new RegistrarPago());
        }
    }
    }
