
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
            this.label4 = new System.Windows.Forms.Label();
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
            this.BtRegistrarPago = new System.Windows.Forms.Button();
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
            this.groupBox1.SuspendLayout();
            this.panelProductos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 108);
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
            this.comboTipoPago.Location = new System.Drawing.Point(94, 105);
            this.comboTipoPago.Name = "comboTipoPago";
            this.comboTipoPago.Size = new System.Drawing.Size(182, 21);
            this.comboTipoPago.TabIndex = 5;
            this.comboTipoPago.Text = "Seleccionar";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(302, 109);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Referencia";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(331, 80);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Cuota #";
            // 
            // txtReferencia
            // 
            this.txtReferencia.Location = new System.Drawing.Point(393, 106);
            this.txtReferencia.Name = "txtReferencia";
            this.txtReferencia.Size = new System.Drawing.Size(125, 20);
            this.txtReferencia.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(17, 132);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Fecha Pago";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // dateFechaPago
            // 
            this.dateFechaPago.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateFechaPago.Location = new System.Drawing.Point(94, 129);
            this.dateFechaPago.Name = "dateFechaPago";
            this.dateFechaPago.Size = new System.Drawing.Size(182, 20);
            this.dateFechaPago.TabIndex = 10;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(302, 132);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(31, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "Valor";
            // 
            // txtValor
            // 
            this.txtValor.Location = new System.Drawing.Point(393, 129);
            this.txtValor.Name = "txtValor";
            this.txtValor.Size = new System.Drawing.Size(125, 20);
            this.txtValor.TabIndex = 12;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(17, 154);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 13);
            this.label8.TabIndex = 13;
            this.label8.Text = "Descuento";
            // 
            // comboDescuento
            // 
            this.comboDescuento.FormattingEnabled = true;
            this.comboDescuento.Items.AddRange(new object[] {
            "Pago oportuno",
            "Oferta expecial",
            "Otros"});
            this.comboDescuento.Location = new System.Drawing.Point(94, 153);
            this.comboDescuento.Name = "comboDescuento";
            this.comboDescuento.Size = new System.Drawing.Size(182, 21);
            this.comboDescuento.TabIndex = 14;
            this.comboDescuento.Text = "Seleccionar";
            this.comboDescuento.SelectedIndexChanged += new System.EventHandler(this.comboDescuento_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(302, 155);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(84, 13);
            this.label9.TabIndex = 15;
            this.label9.Text = "Valor descuento";
            // 
            // txtValorDescuento
            // 
            this.txtValorDescuento.Enabled = false;
            this.txtValorDescuento.Location = new System.Drawing.Point(393, 152);
            this.txtValorDescuento.Name = "txtValorDescuento";
            this.txtValorDescuento.Size = new System.Drawing.Size(125, 20);
            this.txtValorDescuento.TabIndex = 16;
            // 
            // BtRegistrarPago
            // 
            this.BtRegistrarPago.Location = new System.Drawing.Point(236, 193);
            this.BtRegistrarPago.Name = "BtRegistrarPago";
            this.BtRegistrarPago.Size = new System.Drawing.Size(75, 23);
            this.BtRegistrarPago.TabIndex = 17;
            this.BtRegistrarPago.Text = "Guardar";
            this.BtRegistrarPago.UseVisualStyleBackColor = true;
            this.BtRegistrarPago.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Btbuscar);
            this.groupBox1.Controls.Add(this.Txtcedula);
            this.groupBox1.Controls.Add(this.txtNombre);
            this.groupBox1.Location = new System.Drawing.Point(20, 9);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(575, 50);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Cliente";
            // 
            // Btbuscar
            // 
            this.Btbuscar.Location = new System.Drawing.Point(483, 17);
            this.Btbuscar.Name = "Btbuscar";
            this.Btbuscar.Size = new System.Drawing.Size(71, 23);
            this.Btbuscar.TabIndex = 21;
            this.Btbuscar.Text = "Buscar";
            this.Btbuscar.UseVisualStyleBackColor = true;
            this.Btbuscar.Click += new System.EventHandler(this.Btbuscar_Click);
            // 
            // Txtcedula
            // 
            this.Txtcedula.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.Txtcedula.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.Txtcedula.Enabled = false;
            this.Txtcedula.Location = new System.Drawing.Point(8, 19);
            this.Txtcedula.Name = "Txtcedula";
            this.Txtcedula.Size = new System.Drawing.Size(134, 20);
            this.Txtcedula.TabIndex = 20;
            this.Txtcedula.TextChanged += new System.EventHandler(this.Txtcedula_TextChanged);
            // 
            // txtNombre
            // 
            this.txtNombre.Enabled = false;
            this.txtNombre.Location = new System.Drawing.Point(148, 19);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(317, 20);
            this.txtNombre.TabIndex = 19;
            // 
            // txtCuota
            // 
            this.txtCuota.Enabled = false;
            this.txtCuota.Location = new System.Drawing.Point(393, 77);
            this.txtCuota.Name = "txtCuota";
            this.txtCuota.Size = new System.Drawing.Size(57, 20);
            this.txtCuota.TabIndex = 20;
            // 
            // txtProducto
            // 
            this.txtProducto.Enabled = false;
            this.txtProducto.Location = new System.Drawing.Point(94, 81);
            this.txtProducto.Name = "txtProducto";
            this.txtProducto.Size = new System.Drawing.Size(182, 20);
            this.txtProducto.TabIndex = 21;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 84);
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
            this.panelProductos.Size = new System.Drawing.Size(615, 166);
            this.panelProductos.TabIndex = 23;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(8, 3);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(598, 160);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            this.dataGridView1.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellMouseEnter);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // RegistrarPago
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(621, 243);
            this.Controls.Add(this.panelProductos);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtProducto);
            this.Controls.Add(this.txtCuota);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.BtRegistrarPago);
            this.Controls.Add(this.txtValorDescuento);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.comboDescuento);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtValor);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dateFechaPago);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtReferencia);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.comboTipoPago);
            this.Controls.Add(this.label3);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RegistrarPago";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Registrar Pago";
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
        private System.Windows.Forms.Label label4;
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
        private System.Windows.Forms.Button BtRegistrarPago;
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
    }
}