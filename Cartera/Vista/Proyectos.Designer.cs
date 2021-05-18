namespace Cartera.Vista
{
    partial class Proyectos
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
            this.components = new System.ComponentModel.Container();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNombreP = new System.Windows.Forms.TextBox();
            this.txtUbicacion = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.BtBorrar = new System.Windows.Forms.Button();
            this.BtLimpiar = new System.Windows.Forms.Button();
            this.BtGuardarProyecto = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(29, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Nombre";
            // 
            // txtNombreP
            // 
            this.txtNombreP.Location = new System.Drawing.Point(92, 28);
            this.txtNombreP.Name = "txtNombreP";
            this.txtNombreP.Size = new System.Drawing.Size(318, 20);
            this.txtNombreP.TabIndex = 14;
            this.toolTip1.SetToolTip(this.txtNombreP, "Nombre del Proyecto");
            // 
            // txtUbicacion
            // 
            this.txtUbicacion.Location = new System.Drawing.Point(472, 21);
            this.txtUbicacion.Name = "txtUbicacion";
            this.txtUbicacion.Size = new System.Drawing.Size(352, 20);
            this.txtUbicacion.TabIndex = 16;
            this.toolTip1.SetToolTip(this.txtUbicacion, "Ubicación del Proyecto");
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(403, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Ubicación";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 75);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(978, 533);
            this.dataGridView1.TabIndex = 20;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick_1);
            this.dataGridView1.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellMouseEnter);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.BtBorrar);
            this.groupBox1.Controls.Add(this.BtLimpiar);
            this.groupBox1.Controls.Add(this.BtGuardarProyecto);
            this.groupBox1.Controls.Add(this.txtUbicacion);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(978, 57);
            this.groupBox1.TabIndex = 22;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Proyecto";
            // 
            // BtBorrar
            // 
            this.BtBorrar.Enabled = false;
            this.BtBorrar.Image = global::Cartera.Properties.Resources.Eliminar;
            this.BtBorrar.Location = new System.Drawing.Point(933, 14);
            this.BtBorrar.Name = "BtBorrar";
            this.BtBorrar.Size = new System.Drawing.Size(39, 33);
            this.BtBorrar.TabIndex = 21;
            this.toolTip1.SetToolTip(this.BtBorrar, "Eliminar");
            this.BtBorrar.UseVisualStyleBackColor = true;
            this.BtBorrar.Click += new System.EventHandler(this.BtBorrar_Click);
            // 
            // BtLimpiar
            // 
            this.BtLimpiar.Image = global::Cartera.Properties.Resources.limpiar;
            this.BtLimpiar.Location = new System.Drawing.Point(882, 14);
            this.BtLimpiar.Name = "BtLimpiar";
            this.BtLimpiar.Size = new System.Drawing.Size(39, 33);
            this.BtLimpiar.TabIndex = 19;
            this.toolTip1.SetToolTip(this.BtLimpiar, "Limpiar");
            this.BtLimpiar.UseVisualStyleBackColor = true;
            this.BtLimpiar.Click += new System.EventHandler(this.BtLimpiar_Click);
            // 
            // BtGuardarProyecto
            // 
            this.BtGuardarProyecto.Image = global::Cartera.Properties.Resources.Guardar1;
            this.BtGuardarProyecto.Location = new System.Drawing.Point(830, 14);
            this.BtGuardarProyecto.Name = "BtGuardarProyecto";
            this.BtGuardarProyecto.Size = new System.Drawing.Size(39, 33);
            this.BtGuardarProyecto.TabIndex = 17;
            this.toolTip1.SetToolTip(this.BtGuardarProyecto, "Guardar");
            this.BtGuardarProyecto.UseVisualStyleBackColor = true;
            this.BtGuardarProyecto.Click += new System.EventHandler(this.BtGuardarProyecto_Click);
            // 
            // Proyectos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1002, 620);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtNombreP);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Proyectos";
            this.Text = "Proyectos";
            this.Load += new System.EventHandler(this.Proyectos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNombreP;
        private System.Windows.Forms.TextBox txtUbicacion;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button BtGuardarProyecto;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Button BtLimpiar;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button BtBorrar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}