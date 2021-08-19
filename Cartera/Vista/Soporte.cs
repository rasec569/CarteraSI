using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cartera.Controlador;

namespace Cartera.Vista
{
    public partial class Soporte : Form
    {
        CUsuario usuario = new CUsuario();
        DataTable dtUsuarios = new DataTable();
        DataTable User = new DataTable();
        string idusuario = "";


        public Soporte()
        {
            InitializeComponent();
            CargarUsuarios();
        }
        public Soporte(DataTable data)
        {
            InitializeComponent();
            User = data;
            CargarUsuarios();
            LbUser.Text = User.Rows[0]["Nom_Usuario"].ToString();
        }

        private void Soporte_Load(object sender, EventArgs e)
        {

        }
        private void CargarUsuarios()
        {
            dtUsuarios = usuario.listarUsuario();
            dataGridView1.DataSource = dtUsuarios;
            dataGridView1.Columns["Id_usuario"].Visible = false;
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (User.Rows[0]["Nom_Usuario"].ToString() != "admin")
            {
                if (e.ColumnIndex == 2 && e.Value != null)
                {
                    e.Value = new string('*', e.Value.ToString().Length);
                }
            }            
        }
        private void BtGuardar_Click(object sender, EventArgs e)
        {
            ValidarCampos();
            if (ValidarCampos() == true)
            {

                usuario.crearUsuario(txtNombreP.Text, txtPass.Text);

                CargarUsuarios();
                LimpiarCampos();
            }
        }
        private bool ValidarCampos()
        {
            bool ok = true;
            if (txtNombreP.Text == "")
            {
                ok = false;
                errorProvider1.SetError(txtNombreP, "Digite Nombre Usuario");
            }
            else
            {
                ok = true;
                errorProvider1.Clear();
            }
            if (txtPass.Text == "")
            {
                ok = false;
                errorProvider1.SetError(txtPass, "Digite una contraseña");
            }
            else
            {
                ok = true;
                errorProvider1.Clear();
            }
            return ok;
        }
        private bool ValidarCamposUpdate()
        {
            bool ok = true;
            if (txtActual.Text == "")
            {
                ok = false;
                errorProvider1.SetError(txtActual, "Digite la actual contraseña");
            }
            else
            {
                ok = true;
                errorProvider1.Clear();
            }
            if (txtNueva.Text == "")
            {
                ok = false;
                errorProvider1.SetError(txtNueva, "Digite una nueva contraseña");
            }
            else
            {
                ok = true;
                errorProvider1.Clear();
            }

            return ok;
        }

        private void LimpiarCampos()
        {
            txtNombreP.Clear();
            txtPass.Clear();
            txtActual.Clear();
            txtNueva.Clear();
            BtGuardar.Enabled = true;
            txtActual.Enabled = true;
            BtBorrar.Enabled = false;
        }
        private void button1_Click(object sender, EventArgs e)
        {      
            if (txtNombreP.Text==""&& txtPass.Text == "")
            {
                ValidarCamposUpdate();
                if (txtActual.Text == User.Rows[0]["Contraseña"].ToString() && ValidarCamposUpdate() == true)
                {
                    usuario.ActulizarContraseña(User.Rows[0]["Id_usuario"].ToString(), txtNueva.Text);
                    errorProvider1.Clear();
                    CargarUsuarios();
                    LimpiarCampos();
                    //User = dtUsuarios;
                }
                else 
                {
                    errorProvider1.SetError(txtActual, "Contraseña actual incorrecta!");
                }

            }
            else if (User.Rows[0]["Nom_Usuario"].ToString() == "admin") {
                if (txtNueva.Text != "")
                {
                    usuario.ActulizarContraseña(idusuario, txtNueva.Text);
                    CargarUsuarios();
                    LimpiarCampos();
                    BtGuardar.Enabled = true;
                    txtActual.Enabled = true;
                }
                else
                {
                    errorProvider1.SetError(txtNueva, "Ingrese una contraseña!");
                }                
            }
            else
            {
                MessageBox.Show("No tiene permiso para cambiar la contraseña");
            }
        }

        private void BtLimpiar_Click(object sender, EventArgs e)
        {
            if ((txtNombreP.Text != "") || (txtPass.Text != "")|| (txtActual.Text != "") || (txtNueva.Text != ""))
            {
                LimpiarCampos();
            }
            else
            {
                MessageBox.Show("No hay campos que borrar");
            }
        }

        private void BtBorrar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Está seguro eliminar el usuario?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                usuario.EliminarUsuario(int.Parse(idusuario));
                CargarUsuarios();
                LimpiarCampos();
            }
        }      

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            LimpiarCampos();
            BtGuardar.Enabled = false;
            txtActual.Enabled = false;            
            int n = e.RowIndex;
            int x = dataGridView1.Rows.Count;
            if (n < x - 1)
            {
                idusuario = dataGridView1.Rows[n].Cells["Id_usuario"].Value.ToString();
                txtNombreP.Text = dataGridView1.Rows[n].Cells["Usuario"].Value.ToString();
                txtPass.Text = dataGridView1.Rows[n].Cells["Pass"].Value.ToString();
                BtBorrar.Enabled = true;
                CargarUsuarios();
            }
            else
            {
                MessageBox.Show("Campo no valido");
            }
        }
    }
}
