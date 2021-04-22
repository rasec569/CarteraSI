
namespace Cartera.Vista
{
    partial class RegistrarPago
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegistrarPago));
            this.label3 = new System.Windows.Forms.Label();
            this.comboTipoPago = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtReferencia = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dateFechaPago = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.txtValor = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.comboDescuento = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtValorDescuento = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Btbuscar = new System.Windows.Forms.Button();
            this.Txtcedula = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtCuota = new System.Windows.Forms.TextBox();
            this.txtProducto = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panelProductos = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtConcepto = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.TxtEntidad = new System.Windows.Forms.TextBox();
            this.BtEliminar = new System.Windows.Forms.Button();
            this.BtRegistrarPago = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.panelProductos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(50, 103);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Tipo pago";
            // 
            // comboTipoPago
            // 
            this.comboTipoPago.FormattingEnabled = true;
            this.comboTipoPago.Items.AddRange(new object[] {
            "Entrada",
            "Sin interes",
            "Con interes"});
            this.comboTipoPago.Location = new System.Drawing.Point(127, 99);
            this.comboTipoPago.Name = "comboTipoPago";
            this.comboTipoPago.Size = new System.Drawing.Size(182, 21);
            this.comboTipoPago.TabIndex = 5;
            this.comboTipoPago.Text = "Seleccionar";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(335, 77);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Numero Pago";
            // 
            // txtReferencia
            // 
            this.txtReferencia.Location = new System.Drawing.Point(426, 100);
            this.txtReferencia.Name = "txtReferencia";
            this.txtReferencia.Size = new System.Drawing.Size(125, 20);
            this.txtReferencia.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(50, 178);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Fecha Pago";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // dateFechaPago
            // 
            this.dateFechaPago.CustomFormat = "yyyy-MM-dd";
            this.dateFechaPago.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateFechaPago.Location = new System.Drawing.Point(127, 175);
            this.dateFechaPago.Name = "dateFechaPago";
            this.dateFechaPago.Size = new System.Drawing.Size(182, 20);
            this.dateFechaPago.TabIndex = 10;
            this.dateFechaPago.Value = new System.DateTime(2021, 3, 23, 15, 0, 0, 0);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(335, 178);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(71, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "Valor Pagado";
            // 
            // txtValor
            // 
            this.txtValor.Location = new System.Drawing.Point(426, 175);
            this.txtValor.Name = "txtValor";
            this.txtValor.Size = new System.Drawing.Size(125, 20);
            this.txtValor.TabIndex = 11;
            this.txtValor.Leave += new System.EventHandler(this.txtValor_Leave);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(50, 201);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 13);
            this.label8.TabIndex = 13;
            this.label8.Text = "Descuento";
            // 
            // comboDescuento
            // 
            this.comboDescuento.FormattingEnabled = true;
            this.comboDescuento.Items.AddRange(new object[] {
            "Pago anticipado",
            "Pago oportuno",
            "Oferta expecial",
            "Otros"});
            this.comboDescuento.Location = new System.Drawing.Point(127, 200);
            this.comboDescuento.Name = "comboDescuento";
            this.comboDescuento.Size = new System.Drawing.Size(182, 21);
            this.comboDescuento.TabIndex = 12;
            this.comboDescuento.Text = "Seleccionar";
            this.comboDescuento.SelectedIndexChanged += new System.EventHandler(this.comboDescuento_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(335, 202);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(84, 13);
            this.label9.TabIndex = 15;
            this.label9.Text = "Valor descuento";
            // 
            // txtValorDescuento
            // 
            this.txtValorDescuento.Enabled = false;
            this.txtValorDescuento.Location = new System.Drawing.Point(426, 199);
            this.txtValorDescuento.Name = "txtValorDescuento";
            this.txtValorDescuento.Size = new System.Drawing.Size(125, 20);
            this.txtValorDescuento.TabIndex = 13;
            this.txtValorDescuento.Leave += new System.EventHandler(this.txtValorDescuento_Leave);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Btbuscar);
            this.groupBox1.Controls.Add(this.Txtcedula);
            this.groupBox1.Controls.Add(this.txtNombre);
            this.groupBox1.Location = new System.Drawing.Point(12, 9);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(597, 50);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Cliente";
            // 
            // Btbuscar
            // 
            this.Btbuscar.Image = global::Cartera.Properties.Resources.buscar;
            this.Btbuscar.Location = new System.Drawing.Point(536, 15);
            this.Btbuscar.Name = "Btbuscar";
            this.Btbuscar.Size = new System.Drawing.Size(33, 27);
            this.Btbuscar.TabIndex = 2;
            this.Btbuscar.UseVisualStyleBackColor = true;
            this.Btbuscar.Click += new System.EventHandler(this.Btbuscar_Click);
            // 
            // Txtcedula
            // 
            this.Txtcedula.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.Txtcedula.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.Txtcedula.Enabled = false;
            this.Txtcedula.Location = new System.Drawing.Point(38, 19);
            this.Txtcedula.Name = "Txtcedula";
            this.Txtcedula.Size = new System.Drawing.Size(134, 20);
            this.Txtcedula.TabIndex = 1;
            this.Txtcedula.TextChanged += new System.EventHandler(this.Txtcedula_TextChanged);
            // 
            // txtNombre
            // 
            this.txtNombre.Enabled = false;
            this.txtNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombre.Location = new System.Drawing.Point(191, 19);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(317, 20);
            this.txtNombre.TabIndex = 19;
            // 
            // txtCuota
            // 
            this.txtCuota.Enabled = false;
            this.txtCuota.Location = new System.Drawing.Point(426, 74);
            this.txtCuota.Name = "txtCuota";
            this.txtCuota.Size = new System.Drawing.Size(57, 20);
            this.txtCuota.TabIndex = 4;
            // 
            // txtProducto
            // 
            this.txtProducto.Enabled = false;
            this.txtProducto.Location = new System.Drawing.Point(127, 74);
            this.txtProducto.Name = "txtProducto";
            this.txtProducto.Size = new System.Drawing.Size(182, 20);
            this.txtProducto.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(50, 77);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 22;
            this.label1.Text = "Producto";
            // 
            // panelProductos
            // 
            this.panelProductos.Controls.Add(this.dataGridView1);
            this.panelProductos.Location = new System.Drawing.Point(3, 65);
            this.panelProductos.Name = "panelProductos";
            this.panelProductos.Size = new System.Drawing.Size(615, 200);
            this.panelProductos.TabIndex = 23;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(8, 3);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(598, 194);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            this.dataGridView1.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellMouseEnter);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(335, 103);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 13);
            this.label4.TabIndex = 26;
            this.label4.Text = "Referencia";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(50, 128);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 29;
            this.label2.Text = "Concepto";
            // 
            // txtConcepto
            // 
            this.txtConcepto.Location = new System.Drawing.Point(127, 125);
            this.txtConcepto.Name = "txtConcepto";
            this.txtConcepto.Size = new System.Drawing.Size(424, 20);
            this.txtConcepto.TabIndex = 7;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(50, 153);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(43, 13);
            this.label10.TabIndex = 32;
            this.label10.Text = "Entidad";
            // 
            // TxtEntidad
            // 
            this.TxtEntidad.Location = new System.Drawing.Point(127, 150);
            this.TxtEntidad.Name = "TxtEntidad";
            this.TxtEntidad.Size = new System.Drawing.Size(424, 20);
            this.TxtEntidad.TabIndex = 8;
            // 
            // BtEliminar
            // 
            this.BtEliminar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtEliminar.Image = global::Cartera.Properties.Resources.Eliminar;
            this.BtEliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtEliminar.Location = new System.Drawing.Point(338, 230);
            this.BtEliminar.Name = "BtEliminar";
            this.BtEliminar.Size = new System.Drawing.Size(77, 26);
            this.BtEliminar.TabIndex = 15;
            this.BtEliminar.Text = "Eliminar";
            this.BtEliminar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtEliminar.UseVisualStyleBackColor = true;
            this.BtEliminar.Click += new System.EventHandler(this.BtEliminar_Click);
            // 
            // BtRegistrarPago
            // 
            this.BtRegistrarPago.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtRegistrarPago.Image = global::Cartera.Properties.Resources.Guardar1;
            this.BtRegistrarPago.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtRegistrarPago.Location = new System.Drawing.Point(232, 230);
            this.BtRegistrarPago.Name = "BtRegistrarPago";
            this.BtRegistrarPago.Size = new System.Drawing.Size(77, 26);
            this.BtRegistrarPago.TabIndex = 14;
            this.BtRegistrarPago.Text = "Guardar";
            this.BtRegistrarPago.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtRegistrarPago.UseVisualStyleBackColor = true;
            this.BtRegistrarPago.Click += new System.EventHandler(this.BtRegistrarPago_Click);
            // 
            // RegistrarPago
            // 
            this.AcceptButton = this.Btbuscar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(621, 265);
            this.Controls.Add(this.panelProductos);
            this.Controls.Add(this.BtEliminar);
            this.Controls.Add(this.BtRegistrarPago);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.TxtEntidad);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtConcepto);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtProducto);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtCuota);
            this.Controls.Add(this.txtValorDescuento);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.comboDescuento);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtValor);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dateFechaPago);
            this.Controls.Add(this.txtReferencia);
            this.Controls.Add(this.comboTipoPago);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label4);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RegistrarPago";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Registrar Pago";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.RegistrarPago_FormClosing);
            this.Load += new System.EventHandler(this.RegistrarPago_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panelProductos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboTipoPago;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtReferencia;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dateFechaPago;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtValor;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox comboDescuento;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtValorDescuento;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox Txtcedula;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtCuota;
        private System.Windows.Forms.TextBox txtProducto;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelProductos;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Button Btbuscar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtConcepto;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox TxtEntidad;
        private System.Windows.Forms.Button BtEliminar;
        private System.Windows.Forms.Button BtRegistrarPago;
    }
}