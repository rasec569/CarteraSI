
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
            this.BtLimpiar = new System.Windows.Forms.Button();
            this.BtBorrar = new System.Windows.Forms.Button();
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
            this.GuardarSegui.Location = new System.Drawing.Point(694, 79);
            this.GuardarSegui.Name = "GuardarSegui";
            this.GuardarSegui.Size = new System.Drawing.Size(30, 30);
            this.GuardarSegui.TabIndex = 0;
            this.toolTip1.SetToolTip(this.GuardarSegui, "Guardar Seguimiento");
            this.GuardarSegui.UseVisualStyleBackColor = true;
            this.GuardarSegui.Click += new System.EventHandler(this.GuardarSegui_Click);
            // 
            // txtcomentario
            // 
            this.txtcomentario.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtcomentario.Location = new System.Drawing.Point(20, 70);
            this.txtcomentario.Multiline = true;
            this.txtcomentario.Name = "txtcomentario";
            this.txtcomentario.Size = new System.Drawing.Size(631, 49);
            this.txtcomentario.TabIndex = 1;
            this.toolTip1.SetToolTip(this.txtcomentario, "Observaciones  o Comentarios da la comunicación con el Cliente");
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(648, 0);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(104, 20);
            this.dateTimePicker1.TabIndex = 2;
            this.toolTip1.SetToolTip(this.dateTimePicker1, "Fecha Seguimiento");
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 143);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.Size = new System.Drawing.Size(778, 240);
            this.dataGridView1.TabIndex = 3;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Comentario";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.BtLimpiar);
            this.groupBox1.Controls.Add(this.BtBorrar);
            this.groupBox1.Controls.Add(this.LbConctato);
            this.groupBox1.Controls.Add(this.LbPropietario);
            this.groupBox1.Controls.Add(this.LbNomProducto);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.GuardarSegui);
            this.groupBox1.Controls.Add(this.dateTimePicker1);
            this.groupBox1.Controls.Add(this.txtcomentario);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(21, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(769, 125);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Producto";
            // 
            // BtLimpiar
            // 
            this.BtLimpiar.ForeColor = System.Drawing.SystemColors.ControlText;
            this.BtLimpiar.Image = global::Cartera.Properties.Resources.limpiar;
            this.BtLimpiar.Location = new System.Drawing.Point(657, 79);
            this.BtLimpiar.Name = "BtLimpiar";
            this.BtLimpiar.Size = new System.Drawing.Size(31, 30);
            this.BtLimpiar.TabIndex = 10;
            this.toolTip1.SetToolTip(this.BtLimpiar, "Limpiar");
            this.BtLimpiar.UseVisualStyleBackColor = true;
            this.BtLimpiar.Click += new System.EventHandler(this.BtLimpiar_Click);
            // 
            // BtBorrar
            // 
            this.BtBorrar.Enabled = false;
            this.BtBorrar.ForeColor = System.Drawing.SystemColors.ControlText;
            this.BtBorrar.Image = global::Cartera.Properties.Resources.Eliminar;
            this.BtBorrar.Location = new System.Drawing.Point(730, 79);
            this.BtBorrar.Name = "BtBorrar";
            this.BtBorrar.Size = new System.Drawing.Size(30, 30);
            this.BtBorrar.TabIndex = 9;
            this.toolTip1.SetToolTip(this.BtBorrar, "Eliminar Seguimiento");
            this.BtBorrar.UseVisualStyleBackColor = true;
            this.BtBorrar.Click += new System.EventHandler(this.BtBorrar_Click);
            // 
            // LbConctato
            // 
            this.LbConctato.AutoSize = true;
            this.LbConctato.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LbConctato.Location = new System.Drawing.Point(365, 22);
            this.LbConctato.Name = "LbConctato";
            this.LbConctato.Size = new System.Drawing.Size(58, 13);
            this.LbConctato.TabIndex = 8;
            this.LbConctato.Text = "Contacto";
            this.toolTip1.SetToolTip(this.LbConctato, "Medio de contacto del Cliente");
            // 
            // LbPropietario
            // 
            this.LbPropietario.AutoSize = true;
            this.LbPropietario.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LbPropietario.Location = new System.Drawing.Point(75, 22);
            this.LbPropietario.Name = "LbPropietario";
            this.LbPropietario.Size = new System.Drawing.Size(68, 13);
            this.LbPropietario.TabIndex = 7;
            this.LbPropietario.Text = "Propietario";
            this.toolTip1.SetToolTip(this.LbPropietario, "Nombre del Propietario");
            // 
            // LbNomProducto
            // 
            this.LbNomProducto.AutoSize = true;
            this.LbNomProducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(802, 395);
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
        private System.Windows.Forms.Button BtBorrar;
        private System.Windows.Forms.Button BtLimpiar;
    }
}