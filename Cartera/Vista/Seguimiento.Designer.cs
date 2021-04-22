
namespace Cartera.Vista
{
    partial class Seguimiento
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Seguimiento));
            this.GuardarSegui = new System.Windows.Forms.Button();
            this.txtcomentario = new System.Windows.Forms.TextBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.LbConctato = new System.Windows.Forms.Label();
            this.LbPropietario = new System.Windows.Forms.Label();
            this.LbNomProducto = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // GuardarSegui
            // 
            this.GuardarSegui.ForeColor = System.Drawing.SystemColors.ControlText;
            this.GuardarSegui.Image = global::Cartera.Properties.Resources.Guardar1;
            this.GuardarSegui.Location = new System.Drawing.Point(723, 44);
            this.GuardarSegui.Name = "GuardarSegui";
            this.GuardarSegui.Size = new System.Drawing.Size(40, 30);
            this.GuardarSegui.TabIndex = 0;
            this.toolTip1.SetToolTip(this.GuardarSegui, "Guardar Seguimiento");
            this.GuardarSegui.UseVisualStyleBackColor = true;
            this.GuardarSegui.Click += new System.EventHandler(this.GuardarSegui_Click);
            // 
            // txtcomentario
            // 
            this.txtcomentario.Location = new System.Drawing.Point(83, 50);
            this.txtcomentario.Name = "txtcomentario";
            this.txtcomentario.Size = new System.Drawing.Size(512, 20);
            this.txtcomentario.TabIndex = 1;
            this.toolTip1.SetToolTip(this.txtcomentario, "Observaciones  o Comentarios da la comunicación con el Cliente");
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(613, 50);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(104, 20);
            this.dateTimePicker1.TabIndex = 2;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 101);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.Size = new System.Drawing.Size(778, 226);
            this.dataGridView1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Comentario";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.LbConctato);
            this.groupBox1.Controls.Add(this.LbPropietario);
            this.groupBox1.Controls.Add(this.LbNomProducto);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.GuardarSegui);
            this.groupBox1.Controls.Add(this.dateTimePicker1);
            this.groupBox1.Controls.Add(this.txtcomentario);
            this.groupBox1.Location = new System.Drawing.Point(21, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(769, 83);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Producto";
            // 
            // LbConctato
            // 
            this.LbConctato.AutoSize = true;
            this.LbConctato.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LbConctato.Location = new System.Drawing.Point(420, 22);
            this.LbConctato.Name = "LbConctato";
            this.LbConctato.Size = new System.Drawing.Size(58, 13);
            this.LbConctato.TabIndex = 8;
            this.LbConctato.Text = "Contacto";
            this.toolTip1.SetToolTip(this.LbConctato, "Medio de contacto del Cliente");
            // 
            // LbPropietario
            // 
            this.LbPropietario.AutoSize = true;
            this.LbPropietario.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LbPropietario.Location = new System.Drawing.Point(114, 22);
            this.LbPropietario.Name = "LbPropietario";
            this.LbPropietario.Size = new System.Drawing.Size(68, 13);
            this.LbPropietario.TabIndex = 7;
            this.LbPropietario.Text = "Propietario";
            this.toolTip1.SetToolTip(this.LbPropietario, "Nombre del Propietario");
            // 
            // LbNomProducto
            // 
            this.LbNomProducto.AutoSize = true;
            this.LbNomProducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LbNomProducto.Location = new System.Drawing.Point(17, 22);
            this.LbNomProducto.Name = "LbNomProducto";
            this.LbNomProducto.Size = new System.Drawing.Size(58, 13);
            this.LbNomProducto.TabIndex = 6;
            this.LbNomProducto.Text = "Producto";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // Seguimiento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(802, 330);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Seguimiento";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Seguimiento";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button GuardarSegui;
        private System.Windows.Forms.TextBox txtcomentario;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label LbNomProducto;
        private System.Windows.Forms.Label LbPropietario;
        private System.Windows.Forms.Label LbConctato;
    }
}