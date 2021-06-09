
namespace Cartera.Vista
{
    partial class Productos
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBuscarProducto = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label26 = new System.Windows.Forms.Label();
            this.comboProyectos = new System.Windows.Forms.ComboBox();
            this.BtBuscarProducto = new System.Windows.Forms.Button();
            this.labelCantidad = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.labelValor = new System.Windows.Forms.Label();
            this.btTipoProducto = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 71);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(978, 537);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            this.dataGridView1.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellMouseEnter);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nombre";
            // 
            // txtBuscarProducto
            // 
            this.txtBuscarProducto.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtBuscarProducto.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtBuscarProducto.Location = new System.Drawing.Point(62, 19);
            this.txtBuscarProducto.Name = "txtBuscarProducto";
            this.txtBuscarProducto.Size = new System.Drawing.Size(132, 20);
            this.txtBuscarProducto.TabIndex = 2;
            this.toolTip1.SetToolTip(this.txtBuscarProducto, "Busqueda por nombre");
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label26);
            this.groupBox1.Controls.Add(this.comboProyectos);
            this.groupBox1.Controls.Add(this.txtBuscarProducto);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.BtBuscarProducto);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(594, 52);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Buscar";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.Location = new System.Drawing.Point(240, 21);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(57, 13);
            this.label26.TabIndex = 31;
            this.label26.Text = "Proyecto";
            // 
            // comboProyectos
            // 
            this.comboProyectos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboProyectos.FormattingEnabled = true;
            this.comboProyectos.Location = new System.Drawing.Point(301, 18);
            this.comboProyectos.Name = "comboProyectos";
            this.comboProyectos.Size = new System.Drawing.Size(275, 21);
            this.comboProyectos.TabIndex = 32;
            this.comboProyectos.Text = "TODOS LOS PROYECTOS";
            this.comboProyectos.SelectedIndexChanged += new System.EventHandler(this.comboProyectos_SelectedIndexChanged);
            this.comboProyectos.MouseClick += new System.Windows.Forms.MouseEventHandler(this.comboProyectos_MouseClick);
            // 
            // BtBuscarProducto
            // 
            this.BtBuscarProducto.Image = global::Cartera.Properties.Resources.buscar;
            this.BtBuscarProducto.Location = new System.Drawing.Point(201, 13);
            this.BtBuscarProducto.Name = "BtBuscarProducto";
            this.BtBuscarProducto.Size = new System.Drawing.Size(34, 29);
            this.BtBuscarProducto.TabIndex = 3;
            this.toolTip1.SetToolTip(this.BtBuscarProducto, "Buscar");
            this.BtBuscarProducto.UseVisualStyleBackColor = true;
            this.BtBuscarProducto.Click += new System.EventHandler(this.BtBuscarProducto_Click);
            // 
            // labelCantidad
            // 
            this.labelCantidad.AutoSize = true;
            this.labelCantidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCantidad.Location = new System.Drawing.Point(12, 22);
            this.labelCantidad.Name = "labelCantidad";
            this.labelCantidad.Size = new System.Drawing.Size(61, 13);
            this.labelCantidad.TabIndex = 10;
            this.labelCantidad.Text = "Cantidad ";
            this.toolTip1.SetToolTip(this.labelCantidad, "Numero de Productos");
            // 
            // groupBox2
            // 
            this.groupBox2.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.groupBox2.Controls.Add(this.labelValor);
            this.groupBox2.Controls.Add(this.labelCantidad);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(612, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(267, 52);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Productos";
            // 
            // labelValor
            // 
            this.labelValor.AutoSize = true;
            this.labelValor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelValor.Location = new System.Drawing.Point(106, 22);
            this.labelValor.Name = "labelValor";
            this.labelValor.Size = new System.Drawing.Size(36, 13);
            this.labelValor.TabIndex = 12;
            this.labelValor.Text = "Valor";
            this.toolTip1.SetToolTip(this.labelValor, "Valor Total de los Productos");
            // 
            // btTipoProducto
            // 
            this.btTipoProducto.Image = global::Cartera.Properties.Resources.TipoProducto;
            this.btTipoProducto.Location = new System.Drawing.Point(920, 27);
            this.btTipoProducto.Name = "btTipoProducto";
            this.btTipoProducto.Size = new System.Drawing.Size(33, 29);
            this.btTipoProducto.TabIndex = 8;
            this.toolTip1.SetToolTip(this.btTipoProducto, "Tipos Producto");
            this.btTipoProducto.UseVisualStyleBackColor = true;
            this.btTipoProducto.Click += new System.EventHandler(this.btTipoProducto_Click);
            // 
            // button1
            // 
            this.button1.Image = global::Cartera.Properties.Resources.ReporPdf;
            this.button1.Location = new System.Drawing.Point(956, 27);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(31, 29);
            this.button1.TabIndex = 9;
            this.toolTip1.SetToolTip(this.button1, "Guardar Reporte");
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Image = global::Cartera.Properties.Resources.limpiar;
            this.button2.Location = new System.Drawing.Point(884, 27);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(33, 29);
            this.button2.TabIndex = 13;
            this.toolTip1.SetToolTip(this.button2, "Restablecer");
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Productos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1002, 620);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btTipoProducto);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Productos";
            this.Text = "Productos";
            this.Load += new System.EventHandler(this.Productos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBuscarProducto;
        private System.Windows.Forms.Button BtBuscarProducto;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label labelCantidad;
        private System.Windows.Forms.Button btTipoProducto;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label labelValor;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.ComboBox comboProyectos;
        private System.Windows.Forms.Button button2;
    }
}