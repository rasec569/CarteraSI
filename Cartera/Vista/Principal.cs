using Cartera.Controlador;
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

namespace Cartera.Vista
{
    public partial class Principal : Form
    {
        DataTable dtsession = new DataTable();
        private Button btnSeleccionado = null;
        public Principal()
        {
            InitializeComponent();
        }
        public Principal(DataTable User)
        {
            InitializeComponent();
            dtsession = User;
            LbUser.Text = User.Rows[0]["Nom_Usuario"].ToString();
        }

        private void Principal_Load(object sender, EventArgs e)
        {           
            //BtCarteras_Click(this, new EventArgs());
            FormularioHijo<Carteras>(dtsession);
            BtCarteras.BackColor = Color.DarkSeaGreen;
            BtCarteras.ForeColor = Color.White;
            BtCarteras.Font = new System.Drawing.Font("Bernard MT Condensed", 16.75F);
        }
        public void ActivateButton(object sender)
        {
            if (sender != null)
            {
                if(btnSeleccionado != (Button)sender)
                {
                    DisableButton();
                    btnSeleccionado = (Button)sender;
                    btnSeleccionado.BackColor = Color.DarkSeaGreen;
                    btnSeleccionado.ForeColor = Color.White;
                    btnSeleccionado.Font= new System.Drawing.Font("Bernard MT Condensed", 16.75F);
                }
            }
        } 
        public void DisableButton()
        {
            foreach(Control previousBtn in PanelMenu.Controls)
            {
                if (previousBtn.GetType() == typeof(Button))
                {
                    previousBtn.BackColor = SystemColors.Control;
                    previousBtn.ForeColor = Color.FromArgb(12, 60, 12);
                    previousBtn.Font = new System.Drawing.Font("Bernard MT Condensed", 15.75F);
                }
            }
        }
        private void AbrirFormularioEnPanel(object FormHijo)
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
        public void FormularioHijo<MiForm>(DataTable user) where MiForm: Form, new()
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
            ActivateButton(sender);
            FormularioHijo<Clientes>(dtsession);
        }
        private void BtProyectos_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            FormularioHijo<Proyectos>(dtsession);        
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
            ActivateButton(sender);
            FormularioHijo<Productos>(dtsession);
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            DisableButton();
            FormularioHijo<Carteras>(dtsession); 
            BtCarteras.BackColor = Color.DarkSeaGreen;
            BtCarteras.ForeColor = Color.White;
            BtCarteras.Font = new System.Drawing.Font("Bernard MT Condensed", 16.75F);
        }    
        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
            ToolTip tt = new ToolTip();
            tt.SetToolTip(this.pictureBox1, "Clic para ver cartera");
        }

        private void BtCarteras_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            FormularioHijo<Carteras>(dtsession);
        }

        private void BtSoporte_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            //FormularioHijo<Soporte>(dtsession);
            AbrirFormularioEnPanel(new Soporte(dtsession));
        }

        private void BtReportes_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            AbrirFormularioEnPanel(new Reportes(dtsession));
            //FormularioHijo<Reportes>(dtsession);
        }

        
    }
}
