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
using Cartera.Controlador;
using Cartera.Modelo;

namespace Cartera.Vista
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void buttonInicio_Click(object sender, EventArgs e)
        {try
            { if((textUser.Text == "") && (textPass.Text == ""))
                {
                    MessageBox.Show("Los campos estan vacios");
                }
                else if ((textUser.Text == "") || (textPass.Text == ""))
                {
                    if (textUser.Text == "")
                    {
                        MessageBox.Show("EL campo Usuario esta vacio");
                    }
                    else
                    {
                        MessageBox.Show("EL campo Contraseña esta vacio");
                    }
                }
                else
                {
                    CLogin L = new CLogin();
                    DataTable dt = L.ValidaUser(textUser.Text, textPass.Text);
                    if ((textUser.Text == dt.Rows[0]["Nom_Usuario"].ToString()) && (textPass.Text == dt.Rows[0]["Contraseña"].ToString()))
                    //if ((textUser.Text == "admin") && (textPass.Text == "123"))
                    {
                        this.Hide();
                        Principal P = new Principal();
                        P.Show();
                    }                    
                }
            }
            catch
            {
                MessageBox.Show("Los datos son incorrectos");
            }         
        }
    }
}
