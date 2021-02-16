
namespace Cartera.Vista
{
    partial class Clientes
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label8 = new System.Windows.Forms.Label();
            this.PanelSuperior = new System.Windows.Forms.Panel();
            this.BtNuevoCliente = new System.Windows.Forms.Button();
            this.BtBuscarCliente = new System.Windows.Forms.Button();
            this.txtBuscarCliente = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Panel_Registrar_user = new System.Windows.Forms.Panel();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.txtCorreo = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtApellidos = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNombres = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCedula = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.PanelSuperior.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.Panel_Registrar_user.SuspendLayout();
            this.SuspendLayout();
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(20, 73);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(69, 13);
            this.label8.TabIndex = 7;
            this.label8.Text = "Panel Cliente";
            // 
            // PanelSuperior
            // 
            this.PanelSuperior.Controls.Add(this.BtNuevoCliente);
            this.PanelSuperior.Controls.Add(this.BtBuscarCliente);
            this.PanelSuperior.Controls.Add(this.txtBuscarCliente);
            this.PanelSuperior.Controls.Add(this.label1);
            this.PanelSuperior.Dock = System.Windows.Forms.DockStyle.Top;
            this.PanelSuperior.Location = new System.Drawing.Point(0, 0);
            this.PanelSuperior.Name = "PanelSuperior";
            this.PanelSuperior.Size = new System.Drawing.Size(830, 45);
            this.PanelSuperior.TabIndex = 0;
            // 
            // BtNuevoCliente
            // 
            this.BtNuevoCliente.Location = new System.Drawing.Point(619, 12);
            this.BtNuevoCliente.Name = "BtNuevoCliente";
            this.BtNuevoCliente.Size = new System.Drawing.Size(75, 23);
            this.BtNuevoCliente.TabIndex = 3;
            this.BtNuevoCliente.Text = "Nuevo";
            this.BtNuevoCliente.UseVisualStyleBackColor = true;
            this.BtNuevoCliente.Click += new System.EventHandler(this.BtNuevoCliente_Click);
            // 
            // BtBuscarCliente
            // 
            this.BtBuscarCliente.Location = new System.Drawing.Point(519, 12);
            this.BtBuscarCliente.Name = "BtBuscarCliente";
            this.BtBuscarCliente.Size = new System.Drawing.Size(75, 23);
            this.BtBuscarCliente.TabIndex = 2;
            this.BtBuscarCliente.Text = "Buscar";
            this.BtBuscarCliente.UseVisualStyleBackColor = true;
            this.BtBuscarCliente.Click += new System.EventHandler(this.BtBuscarCliente_Click);
            // 
            // txtBuscarCliente
            // 
            this.txtBuscarCliente.Location = new System.Drawing.Point(198, 15);
            this.txtBuscarCliente.Name = "txtBuscarCliente";
            this.txtBuscarCliente.Size = new System.Drawing.Size(281, 20);
            this.txtBuscarCliente.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(113, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre Cliente";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(23, 46);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(800, 480);
            this.dataGridView1.TabIndex = 2;
            // 
            // Panel_Registrar_user
            // 
            this.Panel_Registrar_user.Controls.Add(this.txtDireccion);
            this.Panel_Registrar_user.Controls.Add(this.label6);
            this.Panel_Registrar_user.Controls.Add(this.button1);
            this.Panel_Registrar_user.Controls.Add(this.txtCorreo);
            this.Panel_Registrar_user.Controls.Add(this.label5);
            this.Panel_Registrar_user.Controls.Add(this.txtTelefono);
            this.Panel_Registrar_user.Controls.Add(this.label4);
            this.Panel_Registrar_user.Controls.Add(this.txtApellidos);
            this.Panel_Registrar_user.Controls.Add(this.label3);
            this.Panel_Registrar_user.Controls.Add(this.txtNombres);
            this.Panel_Registrar_user.Controls.Add(this.label2);
            this.Panel_Registrar_user.Controls.Add(this.txtCedula);
            this.Panel_Registrar_user.Controls.Add(this.label7);
            this.Panel_Registrar_user.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Panel_Registrar_user.Location = new System.Drawing.Point(0, 45);
            this.Panel_Registrar_user.Name = "Panel_Registrar_user";
            this.Panel_Registrar_user.Size = new System.Drawing.Size(830, 456);
            this.Panel_Registrar_user.TabIndex = 3;
            this.Panel_Registrar_user.Visible = false;
            // 
            // txtDireccion
            // 
            this.txtDireccion.Location = new System.Drawing.Point(325, 178);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(224, 20);
            this.txtDireccion.TabIndex = 25;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(255, 181);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 13);
            this.label6.TabIndex = 24;
            this.label6.Text = "Direccion";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(388, 221);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 26;
            this.button1.Text = "Guardar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.BtGuardarCliente_Click);
            // 
            // txtCorreo
            // 
            this.txtCorreo.Location = new System.Drawing.Point(325, 151);
            this.txtCorreo.Name = "txtCorreo";
            this.txtCorreo.Size = new System.Drawing.Size(224, 20);
            this.txtCorreo.TabIndex = 23;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(255, 154);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 13);
            this.label5.TabIndex = 22;
            this.label5.Text = "Correo";
            // 
            // txtTelefono
            // 
            this.txtTelefono.Location = new System.Drawing.Point(325, 125);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(224, 20);
            this.txtTelefono.TabIndex = 21;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(255, 128);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 20;
            this.label4.Text = "Telefono";
            // 
            // txtApellidos
            // 
            this.txtApellidos.Location = new System.Drawing.Point(325, 99);
            this.txtApellidos.Name = "txtApellidos";
            this.txtApellidos.Size = new System.Drawing.Size(224, 20);
            this.txtApellidos.TabIndex = 19;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(255, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "Apellidos";
            // 
            // txtNombres
            // 
            this.txtNombres.Location = new System.Drawing.Point(325, 73);
            this.txtNombres.Name = "txtNombres";
            this.txtNombres.Size = new System.Drawing.Size(224, 20);
            this.txtNombres.TabIndex = 17;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(255, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Nombres";
            // 
            // txtCedula
            // 
            this.txtCedula.Location = new System.Drawing.Point(325, 44);
            this.txtCedula.Name = "txtCedula";
            this.txtCedula.Size = new System.Drawing.Size(138, 20);
            this.txtCedula.TabIndex = 15;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(255, 47);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Cedula";
            // 
            // Clientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(830, 501);
            this.Controls.Add(this.Panel_Registrar_user);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.PanelSuperior);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Clientes";
            this.Text = "Clientes";
            this.Load += new System.EventHandler(this.Clientes_Load);
            this.PanelSuperior.ResumeLayout(false);
            this.PanelSuperior.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.Panel_Registrar_user.ResumeLayout(false);
            this.Panel_Registrar_user.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel PanelSuperior;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BtBuscarCliente;
        private System.Windows.Forms.TextBox txtBuscarCliente;
        private System.Windows.Forms.Button BtNuevoCliente;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel Panel_Registrar_user;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtCorreo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtApellidos;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNombres;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCedula;
        private System.Windows.Forms.Label label7;
    }
}