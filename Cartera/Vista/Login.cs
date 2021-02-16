using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cartera.Vistas
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void buttonInicio_Click(object sender, EventArgs e)
        {
            if ((textUser.Text == "admin") && (textPass.Text == "123"))
            {
                this.Hide();
                Principal P = new Principal();
                P.Show();
            }
            else
            {
                MessageBox.Show("Los datos son incorrectos");
            }
            
        }
    }
}
