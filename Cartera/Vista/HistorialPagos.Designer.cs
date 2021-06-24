
namespace Cartera.Vista
{
    partial class HistorialPagos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HistorialPagos));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.txtCedula = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btLimpiar = new System.Windows.Forms.Button();
            this.labelFecha = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.BtBuscar = new System.Windows.Forms.Button();
            this.BtImprimir = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.labelTotal = new System.Windows.Forms.Label();
            this.labelPagado = new System.Windows.Forms.Label();
            this.labelDeuda = new System.Windows.Forms.Label();
            this.labelNeto = new System.Windows.Forms.Label();
            this.labelSaldoFecha = new System.Windows.Forms.Label();
            this.TxtDeudaFecha = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.labelmes = new System.Windows.Forms.Label();
            this.labelMeses = new System.Windows.Forms.Label();
            this.labelMora = new System.Windows.Forms.Label();
            this.labelPagadas = new System.Windows.Forms.Label();
            this.labelCuotas = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 70);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1010, 305);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            this.dataGridView1.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellMouseEnter);
            this.dataGridView1.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dataGridView1_RowPostPaint);
            // 
            // txtCedula
            // 
            this.txtCedula.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtCedula.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtCedula.Location = new System.Drawing.Point(71, 23);
            this.txtCedula.Name = "txtCedula";
            this.txtCedula.Size = new System.Drawing.Size(130, 20);
            this.txtCedula.TabIndex = 3;
            this.toolTip1.SetToolTip(this.txtCedula, "Digite la cedula del cliente");
            this.txtCedula.TextChanged += new System.EventHandler(this.txtCedula_TextChanged);
            // 
            // txtNombre
            // 
            this.txtNombre.Enabled = false;
            this.txtNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombre.Location = new System.Drawing.Point(344, 24);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(363, 20);
            this.txtNombre.TabIndex = 4;
            this.toolTip1.SetToolTip(this.txtNombre, "Nombre Cliente");
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btLimpiar);
            this.groupBox1.Controls.Add(this.labelFecha);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.BtBuscar);
            this.groupBox1.Controls.Add(this.BtImprimir);
            this.groupBox1.Controls.Add(this.txtCedula);
            this.groupBox1.Controls.Add(this.txtNombre);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1010, 60);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Cliente";
            // 
            // btLimpiar
            // 
            this.btLimpiar.Enabled = false;
            this.btLimpiar.Image = ((System.Drawing.Image)(resources.GetObject("btLimpiar.Image")));
            this.btLimpiar.Location = new System.Drawing.Point(891, 19);
            this.btLimpiar.Name = "btLimpiar";
            this.btLimpiar.Size = new System.Drawing.Size(33, 30);
            this.btLimpiar.TabIndex = 11;
            this.toolTip1.SetToolTip(this.btLimpiar, "Limpiar");
            this.btLimpiar.UseVisualStyleBackColor = true;
            this.btLimpiar.Click += new System.EventHandler(this.btLimpiar_Click);
            // 
            // labelFecha
            // 
            this.labelFecha.AutoSize = true;
            this.labelFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFecha.Location = new System.Drawing.Point(737, 28);
            this.labelFecha.Name = "labelFecha";
            this.labelFecha.Size = new System.Drawing.Size(46, 13);
            this.labelFecha.TabIndex = 10;
            this.labelFecha.Text = "Fecha:";
            this.toolTip1.SetToolTip(this.labelFecha, "Fecha reporte");
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(277, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Nombre";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Cedula";
            // 
            // BtBuscar
            // 
            this.BtBuscar.Image = ((System.Drawing.Image)(resources.GetObject("BtBuscar.Image")));
            this.BtBuscar.Location = new System.Drawing.Point(214, 20);
            this.BtBuscar.Name = "BtBuscar";
            this.BtBuscar.Size = new System.Drawing.Size(32, 28);
            this.BtBuscar.TabIndex = 7;
            this.toolTip1.SetToolTip(this.BtBuscar, "Buscar");
            this.BtBuscar.UseVisualStyleBackColor = true;
            this.BtBuscar.Click += new System.EventHandler(this.BtBuscar_Click);
            // 
            // BtImprimir
            // 
            this.BtImprimir.Enabled = false;
            this.BtImprimir.Image = global::Cartera.Properties.Resources.ReporPdf;
            this.BtImprimir.Location = new System.Drawing.Point(930, 19);
            this.BtImprimir.Name = "BtImprimir";
            this.BtImprimir.Size = new System.Drawing.Size(34, 30);
            this.BtImprimir.TabIndex = 6;
            this.toolTip1.SetToolTip(this.BtImprimir, "Guardar Reporte");
            this.BtImprimir.UseVisualStyleBackColor = true;
            this.BtImprimir.Click += new System.EventHandler(this.BtImprimir_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // dataGridView2
            // 
            this.dataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(12, 122);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(1010, 253);
            this.dataGridView2.TabIndex = 6;
            this.dataGridView2.Visible = false;
            this.dataGridView2.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellDoubleClick);
            // 
            // labelTotal
            // 
            this.labelTotal.AutoSize = true;
            this.labelTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTotal.ForeColor = System.Drawing.Color.DodgerBlue;
            this.labelTotal.Location = new System.Drawing.Point(845, 396);
            this.labelTotal.Name = "labelTotal";
            this.labelTotal.Size = new System.Drawing.Size(96, 13);
            this.labelTotal.TabIndex = 22;
            this.labelTotal.Text = "VALOR TOTAL:";
            this.toolTip1.SetToolTip(this.labelTotal, "Valor con intereses Producto");
            this.labelTotal.Visible = false;
            // 
            // labelPagado
            // 
            this.labelPagado.AutoSize = true;
            this.labelPagado.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPagado.ForeColor = System.Drawing.Color.Green;
            this.labelPagado.Location = new System.Drawing.Point(448, 396);
            this.labelPagado.Name = "labelPagado";
            this.labelPagado.Size = new System.Drawing.Size(116, 13);
            this.labelPagado.TabIndex = 21;
            this.labelPagado.Text = "VALOR ABONADO:";
            this.toolTip1.SetToolTip(this.labelPagado, "Valor abonado por el Cliente");
            this.labelPagado.Visible = false;
            // 
            // labelDeuda
            // 
            this.labelDeuda.AutoSize = true;
            this.labelDeuda.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDeuda.ForeColor = System.Drawing.Color.Crimson;
            this.labelDeuda.Location = new System.Drawing.Point(650, 396);
            this.labelDeuda.Name = "labelDeuda";
            this.labelDeuda.Size = new System.Drawing.Size(103, 13);
            this.labelDeuda.TabIndex = 20;
            this.labelDeuda.Text = "SALDO AL FINA:";
            this.toolTip1.SetToolTip(this.labelDeuda, "Saldo a pagar por Cliente");
            this.labelDeuda.Visible = false;
            // 
            // labelNeto
            // 
            this.labelNeto.AutoSize = true;
            this.labelNeto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNeto.Location = new System.Drawing.Point(266, 396);
            this.labelNeto.Name = "labelNeto";
            this.labelNeto.Size = new System.Drawing.Size(90, 13);
            this.labelNeto.TabIndex = 23;
            this.labelNeto.Text = "VALOR NETO:";
            this.toolTip1.SetToolTip(this.labelNeto, "Valor Neto Producto");
            this.labelNeto.Visible = false;
            // 
            // labelSaldoFecha
            // 
            this.labelSaldoFecha.AutoSize = true;
            this.labelSaldoFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSaldoFecha.ForeColor = System.Drawing.Color.DarkOrange;
            this.labelSaldoFecha.Location = new System.Drawing.Point(12, 396);
            this.labelSaldoFecha.Name = "labelSaldoFecha";
            this.labelSaldoFecha.Size = new System.Drawing.Size(134, 13);
            this.labelSaldoFecha.TabIndex = 24;
            this.labelSaldoFecha.Text = "SALDO AL LA FECHA:";
            this.toolTip1.SetToolTip(this.labelSaldoFecha, "Valor Neto Producto");
            this.labelSaldoFecha.Visible = false;
            // 
            // TxtDeudaFecha
            // 
            this.TxtDeudaFecha.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.TxtDeudaFecha.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.TxtDeudaFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtDeudaFecha.ForeColor = System.Drawing.Color.DarkOrange;
            this.TxtDeudaFecha.Location = new System.Drawing.Point(148, 393);
            this.TxtDeudaFecha.Name = "TxtDeudaFecha";
            this.TxtDeudaFecha.Size = new System.Drawing.Size(110, 20);
            this.TxtDeudaFecha.TabIndex = 12;
            this.toolTip1.SetToolTip(this.TxtDeudaFecha, "Digite la cedula del cliente");
            this.TxtDeudaFecha.Visible = false;
            this.TxtDeudaFecha.TextChanged += new System.EventHandler(this.TxtDeudaFecha_TextChanged);
            this.TxtDeudaFecha.Leave += new System.EventHandler(this.TxtDeudaFecha_Leave);
            // 
            // button1
            // 
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Location = new System.Drawing.Point(982, 22);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(33, 30);
            this.button1.TabIndex = 12;
            this.toolTip1.SetToolTip(this.button1, "Financiación");
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.labelmes);
            this.groupBox2.Controls.Add(this.labelMeses);
            this.groupBox2.Controls.Add(this.labelMora);
            this.groupBox2.Controls.Add(this.labelPagadas);
            this.groupBox2.Controls.Add(this.labelCuotas);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(12, 70);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1010, 56);
            this.groupBox2.TabIndex = 25;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Estado";
            this.groupBox2.Visible = false;
            // 
            // labelmes
            // 
            this.labelmes.AutoSize = true;
            this.labelmes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelmes.Location = new System.Drawing.Point(224, 27);
            this.labelmes.Name = "labelmes";
            this.labelmes.Size = new System.Drawing.Size(46, 13);
            this.labelmes.TabIndex = 4;
            this.labelmes.Text = "Cuotas";
            // 
            // labelMeses
            // 
            this.labelMeses.AutoSize = true;
            this.labelMeses.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMeses.Location = new System.Drawing.Point(799, 27);
            this.labelMeses.Name = "labelMeses";
            this.labelMeses.Size = new System.Drawing.Size(46, 13);
            this.labelMeses.TabIndex = 3;
            this.labelMeses.Text = "Cuotas";
            // 
            // labelMora
            // 
            this.labelMora.AutoSize = true;
            this.labelMora.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMora.Location = new System.Drawing.Point(613, 27);
            this.labelMora.Name = "labelMora";
            this.labelMora.Size = new System.Drawing.Size(46, 13);
            this.labelMora.TabIndex = 2;
            this.labelMora.Text = "Cuotas";
            // 
            // labelPagadas
            // 
            this.labelPagadas.AutoSize = true;
            this.labelPagadas.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPagadas.Location = new System.Drawing.Point(428, 27);
            this.labelPagadas.Name = "labelPagadas";
            this.labelPagadas.Size = new System.Drawing.Size(46, 13);
            this.labelPagadas.TabIndex = 1;
            this.labelPagadas.Text = "Cuotas";
            // 
            // labelCuotas
            // 
            this.labelCuotas.AutoSize = true;
            this.labelCuotas.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCuotas.Location = new System.Drawing.Point(53, 27);
            this.labelCuotas.Name = "labelCuotas";
            this.labelCuotas.Size = new System.Drawing.Size(46, 13);
            this.labelCuotas.TabIndex = 0;
            this.labelCuotas.Text = "Cuotas";
            // 
            // HistorialPagos
            // 
            this.AcceptButton = this.BtBuscar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1034, 424);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.TxtDeudaFecha);
            this.Controls.Add(this.labelSaldoFecha);
            this.Controls.Add(this.labelNeto);
            this.Controls.Add(this.labelTotal);
            this.Controls.Add(this.labelPagado);
            this.Controls.Add(this.labelDeuda);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.dataGridView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "HistorialPagos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Historial Pagos";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.HistorialPagos_FormClosed);
            this.Load += new System.EventHandler(this.HistorialPagos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox txtCedula;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button BtImprimir;
        private System.Windows.Forms.Label labelFecha;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BtBuscar;
        private System.Windows.Forms.Button btLimpiar;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label labelNeto;
        private System.Windows.Forms.Label labelTotal;
        private System.Windows.Forms.Label labelPagado;
        private System.Windows.Forms.Label labelDeuda;
        private System.Windows.Forms.Label labelSaldoFecha;
        private System.Windows.Forms.TextBox TxtDeudaFecha;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label labelMeses;
        private System.Windows.Forms.Label labelMora;
        private System.Windows.Forms.Label labelPagadas;
        private System.Windows.Forms.Label labelCuotas;
        private System.Windows.Forms.Label labelmes;
        private System.Windows.Forms.Button button1;
    }
}