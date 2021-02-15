
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
            this.Panel_Clientes = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.Panel_Registrar_user = new System.Windows.Forms.Panel();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtApellidos = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNombres = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCedula = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.buttonGuardarCliente = new System.Windows.Forms.Button();
            this.PanelSuperior = new System.Windows.Forms.Panel();
            this.BtNuevoCliente = new System.Windows.Forms.Button();
            this.BtBuscarCliente = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Panel_Clientes.SuspendLayout();
            this.Panel_Registrar_user.SuspendLayout();
            this.PanelSuperior.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // Panel_Clientes
            // 
            this.Panel_Clientes.Controls.Add(this.dataGridView1);
            this.Panel_Clientes.Controls.Add(this.label8);
            this.Panel_Clientes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Panel_Clientes.Location = new System.Drawing.Point(0, 0);
            this.Panel_Clientes.Name = "Panel_Clientes";
            this.Panel_Clientes.Size = new System.Drawing.Size(533, 699);
            this.Panel_Clientes.TabIndex = 4;
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
            // Panel_Registrar_user
            // 
            this.Panel_Registrar_user.Controls.Add(this.textBox5);
            this.Panel_Registrar_user.Controls.Add(this.label5);
            this.Panel_Registrar_user.Controls.Add(this.textBox4);
            this.Panel_Registrar_user.Controls.Add(this.label4);
            this.Panel_Registrar_user.Controls.Add(this.txtApellidos);
            this.Panel_Registrar_user.Controls.Add(this.label3);
            this.Panel_Registrar_user.Controls.Add(this.txtNombres);
            this.Panel_Registrar_user.Controls.Add(this.label2);
            this.Panel_Registrar_user.Controls.Add(this.txtCedula);
            this.Panel_Registrar_user.Controls.Add(this.label6);
            this.Panel_Registrar_user.Controls.Add(this.buttonGuardarCliente);
            this.Panel_Registrar_user.Controls.Add(this.Panel_Clientes);
            this.Panel_Registrar_user.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Panel_Registrar_user.Location = new System.Drawing.Point(0, 0);
            this.Panel_Registrar_user.Name = "Panel_Registrar_user";
            this.Panel_Registrar_user.Size = new System.Drawing.Size(533, 699);
            this.Panel_Registrar_user.TabIndex = 5;
            this.Panel_Registrar_user.Visible = false;
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(163, 173);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(224, 20);
            this.textBox5.TabIndex = 20;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(93, 176);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 13);
            this.label5.TabIndex = 19;
            this.label5.Text = "Correo";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(163, 147);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(224, 20);
            this.textBox4.TabIndex = 18;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(93, 150);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "Telefono";
            // 
            // txtApellidos
            // 
            this.txtApellidos.Location = new System.Drawing.Point(163, 121);
            this.txtApellidos.Name = "txtApellidos";
            this.txtApellidos.Size = new System.Drawing.Size(224, 20);
            this.txtApellidos.TabIndex = 16;
            this.txtApellidos.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(93, 124);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Apellidos";
            // 
            // txtNombres
            // 
            this.txtNombres.Location = new System.Drawing.Point(163, 95);
            this.txtNombres.Name = "txtNombres";
            this.txtNombres.Size = new System.Drawing.Size(224, 20);
            this.txtNombres.TabIndex = 14;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(93, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Nombres";
            // 
            // txtCedula
            // 
            this.txtCedula.Location = new System.Drawing.Point(163, 66);
            this.txtCedula.Name = "txtCedula";
            this.txtCedula.Size = new System.Drawing.Size(138, 20);
            this.txtCedula.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(93, 69);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Cedula";
            // 
            // buttonGuardarCliente
            // 
            this.buttonGuardarCliente.Location = new System.Drawing.Point(226, 217);
            this.buttonGuardarCliente.Name = "buttonGuardarCliente";
            this.buttonGuardarCliente.Size = new System.Drawing.Size(75, 23);
            this.buttonGuardarCliente.TabIndex = 21;
            this.buttonGuardarCliente.Text = "Guardar";
            this.buttonGuardarCliente.UseVisualStyleBackColor = true;
            this.buttonGuardarCliente.Click += new System.EventHandler(this.BtGuardarCliente_Click);
            // 
            // PanelSuperior
            // 
            this.PanelSuperior.Controls.Add(this.BtNuevoCliente);
            this.PanelSuperior.Controls.Add(this.BtBuscarCliente);
            this.PanelSuperior.Controls.Add(this.textBox1);
            this.PanelSuperior.Controls.Add(this.label1);
            this.PanelSuperior.Dock = System.Windows.Forms.DockStyle.Top;
            this.PanelSuperior.Location = new System.Drawing.Point(0, 0);
            this.PanelSuperior.Name = "PanelSuperior";
            this.PanelSuperior.Size = new System.Drawing.Size(533, 51);
            this.PanelSuperior.TabIndex = 6;
            // 
            // BtNuevoCliente
            // 
            this.BtNuevoCliente.Location = new System.Drawing.Point(418, 14);
            this.BtNuevoCliente.Name = "BtNuevoCliente";
            this.BtNuevoCliente.Size = new System.Drawing.Size(75, 23);
            this.BtNuevoCliente.TabIndex = 7;
            this.BtNuevoCliente.Text = "Nuevo";
            this.BtNuevoCliente.UseVisualStyleBackColor = true;
            this.BtNuevoCliente.Click += new System.EventHandler(this.BtNuevoCliente_Click);
            // 
            // BtBuscarCliente
            // 
            this.BtBuscarCliente.Location = new System.Drawing.Point(325, 14);
            this.BtBuscarCliente.Name = "BtBuscarCliente";
            this.BtBuscarCliente.Size = new System.Drawing.Size(75, 23);
            this.BtBuscarCliente.TabIndex = 6;
            this.BtBuscarCliente.Text = "Buscar";
            this.BtBuscarCliente.UseVisualStyleBackColor = true;
            this.BtBuscarCliente.Click += new System.EventHandler(this.BtBuscarCliente_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(100, 17);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(204, 20);
            this.textBox1.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Nombre Cliente";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(52, 259);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(421, 150);
            this.dataGridView1.TabIndex = 8;
            // 
            // Clientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(533, 699);
            this.Controls.Add(this.PanelSuperior);
            this.Controls.Add(this.Panel_Registrar_user);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Clientes";
            this.Text = "Clientes";
            this.Load += new System.EventHandler(this.Clientes_Load);
            this.Panel_Clientes.ResumeLayout(false);
            this.Panel_Clientes.PerformLayout();
            this.Panel_Registrar_user.ResumeLayout(false);
            this.Panel_Registrar_user.PerformLayout();
            this.PanelSuperior.ResumeLayout(false);
            this.PanelSuperior.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel Panel_Clientes;
        private System.Windows.Forms.Panel Panel_Registrar_user;
        private System.Windows.Forms.Button buttonGuardarCliente;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtApellidos;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNombres;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCedula;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel PanelSuperior;
        private System.Windows.Forms.Button BtNuevoCliente;
        private System.Windows.Forms.Button BtBuscarCliente;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}