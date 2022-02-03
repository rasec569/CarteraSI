
namespace Cartera.Vista
{
    partial class Amortizacion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Amortizacion));
            this.TxtValorNeto = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.TxtTotal = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.TxtValorCuotaInteres = new System.Windows.Forms.TextBox();
            this.TxtValorSaldo = new System.Windows.Forms.TextBox();
            this.TxtValorInicial = new System.Windows.Forms.TextBox();
            this.numCuotasFinan = new System.Windows.Forms.NumericUpDown();
            this.numValorInteres = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.labelSaldo = new System.Windows.Forms.Label();
            this.labelPagado = new System.Windows.Forms.Label();
            this.labelInteres = new System.Windows.Forms.Label();
            this.labelDeuda = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numCuotasFinan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numValorInteres)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // TxtValorNeto
            // 
            this.TxtValorNeto.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.TxtValorNeto.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.TxtValorNeto.Enabled = false;
            this.TxtValorNeto.Location = new System.Drawing.Point(15, 37);
            this.TxtValorNeto.Name = "TxtValorNeto";
            this.TxtValorNeto.Size = new System.Drawing.Size(102, 20);
            this.TxtValorNeto.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.TxtTotal);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.TxtValorCuotaInteres);
            this.groupBox1.Controls.Add(this.TxtValorSaldo);
            this.groupBox1.Controls.Add(this.TxtValorInicial);
            this.groupBox1.Controls.Add(this.numCuotasFinan);
            this.groupBox1.Controls.Add(this.numValorInteres);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.TxtValorNeto);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(3, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(748, 64);
            this.groupBox1.TabIndex = 21;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Financiación";
            // 
            // TxtTotal
            // 
            this.TxtTotal.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.TxtTotal.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.TxtTotal.Enabled = false;
            this.TxtTotal.Location = new System.Drawing.Point(627, 37);
            this.TxtTotal.Name = "TxtTotal";
            this.TxtTotal.Size = new System.Drawing.Size(102, 20);
            this.TxtTotal.TabIndex = 38;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(642, 18);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(69, 13);
            this.label7.TabIndex = 37;
            this.label7.Text = "Valor Total";
            // 
            // TxtValorCuotaInteres
            // 
            this.TxtValorCuotaInteres.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.TxtValorCuotaInteres.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.TxtValorCuotaInteres.Enabled = false;
            this.TxtValorCuotaInteres.Location = new System.Drawing.Point(508, 37);
            this.TxtValorCuotaInteres.Name = "TxtValorCuotaInteres";
            this.TxtValorCuotaInteres.Size = new System.Drawing.Size(102, 20);
            this.TxtValorCuotaInteres.TabIndex = 36;
            // 
            // TxtValorSaldo
            // 
            this.TxtValorSaldo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.TxtValorSaldo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.TxtValorSaldo.Enabled = false;
            this.TxtValorSaldo.Location = new System.Drawing.Point(251, 37);
            this.TxtValorSaldo.Name = "TxtValorSaldo";
            this.TxtValorSaldo.Size = new System.Drawing.Size(102, 20);
            this.TxtValorSaldo.TabIndex = 35;
            // 
            // TxtValorInicial
            // 
            this.TxtValorInicial.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.TxtValorInicial.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.TxtValorInicial.Enabled = false;
            this.TxtValorInicial.Location = new System.Drawing.Point(132, 37);
            this.TxtValorInicial.Name = "TxtValorInicial";
            this.TxtValorInicial.Size = new System.Drawing.Size(102, 20);
            this.TxtValorInicial.TabIndex = 34;
            // 
            // numCuotasFinan
            // 
            this.numCuotasFinan.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numCuotasFinan.Location = new System.Drawing.Point(371, 37);
            this.numCuotasFinan.Maximum = new decimal(new int[] {
            36,
            0,
            0,
            0});
            this.numCuotasFinan.Name = "numCuotasFinan";
            this.numCuotasFinan.Size = new System.Drawing.Size(50, 20);
            this.numCuotasFinan.TabIndex = 33;
            this.numCuotasFinan.ValueChanged += new System.EventHandler(this.numCuotasFinan_ValueChanged);
            this.numCuotasFinan.Click += new System.EventHandler(this.numCuotasFinan_Click);
            // 
            // numValorInteres
            // 
            this.numValorInteres.Enabled = false;
            this.numValorInteres.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numValorInteres.Location = new System.Drawing.Point(443, 37);
            this.numValorInteres.Maximum = new decimal(new int[] {
            36,
            0,
            0,
            0});
            this.numValorInteres.Name = "numValorInteres";
            this.numValorInteres.Size = new System.Drawing.Size(44, 20);
            this.numValorInteres.TabIndex = 32;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(523, 18);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 13);
            this.label5.TabIndex = 31;
            this.label5.Text = "Valor Cuota";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(436, 18);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 13);
            this.label6.TabIndex = 29;
            this.label6.Text = "% Interes";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(373, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 13);
            this.label4.TabIndex = 27;
            this.label4.Text = "Cuotas";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(266, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 25;
            this.label1.Text = "Valor Saldo";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(146, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 13);
            this.label3.TabIndex = 23;
            this.label3.Text = "Valor Inicial";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(36, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 21;
            this.label2.Text = "Valor Neto";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(3, 82);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(748, 274);
            this.dataGridView1.TabIndex = 20;
            this.dataGridView1.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView1_CellFormatting);
            this.dataGridView1.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellMouseEnter);
            this.dataGridView1.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dataGridView1_CellPainting);
            this.dataGridView1.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dataGridView1_DataBindingComplete);
            this.dataGridView1.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dataGridView1_RowPostPaint);
            // 
            // labelSaldo
            // 
            this.labelSaldo.AutoSize = true;
            this.labelSaldo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSaldo.ForeColor = System.Drawing.Color.DodgerBlue;
            this.labelSaldo.Location = new System.Drawing.Point(12, 362);
            this.labelSaldo.Name = "labelSaldo";
            this.labelSaldo.Size = new System.Drawing.Size(111, 13);
            this.labelSaldo.TabIndex = 30;
            this.labelSaldo.Text = "Pagado a la fecha";
            this.toolTip1.SetToolTip(this.labelSaldo, "Valor pagado a la fecha");
            // 
            // labelPagado
            // 
            this.labelPagado.AutoSize = true;
            this.labelPagado.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPagado.ForeColor = System.Drawing.Color.Green;
            this.labelPagado.Location = new System.Drawing.Point(395, 362);
            this.labelPagado.Name = "labelPagado";
            this.labelPagado.Size = new System.Drawing.Size(86, 13);
            this.labelPagado.TabIndex = 29;
            this.labelPagado.Text = "Abono Capital";
            this.toolTip1.SetToolTip(this.labelPagado, "Total Aportes a la cartera");
            // 
            // labelInteres
            // 
            this.labelInteres.AutoSize = true;
            this.labelInteres.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelInteres.ForeColor = System.Drawing.Color.Purple;
            this.labelInteres.Location = new System.Drawing.Point(216, 362);
            this.labelInteres.Name = "labelInteres";
            this.labelInteres.Size = new System.Drawing.Size(86, 13);
            this.labelInteres.TabIndex = 28;
            this.labelInteres.Text = "Abono Interes";
            this.toolTip1.SetToolTip(this.labelInteres, "Deuda por pagar a la cartera");
            // 
            // labelDeuda
            // 
            this.labelDeuda.AutoSize = true;
            this.labelDeuda.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDeuda.ForeColor = System.Drawing.Color.Red;
            this.labelDeuda.Location = new System.Drawing.Point(574, 362);
            this.labelDeuda.Name = "labelDeuda";
            this.labelDeuda.Size = new System.Drawing.Size(105, 13);
            this.labelDeuda.TabIndex = 32;
            this.labelDeuda.Text = "Deuda a la fecha";
            this.toolTip1.SetToolTip(this.labelDeuda, "Total Aportes a la cartera");
            // 
            // Amortizacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(753, 384);
            this.Controls.Add(this.labelDeuda);
            this.Controls.Add(this.labelSaldo);
            this.Controls.Add(this.labelPagado);
            this.Controls.Add(this.labelInteres);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGridView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Amortizacion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Detalle Amortización";
            this.Load += new System.EventHandler(this.Detalle_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numCuotasFinan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numValorInteres)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TxtValorNeto;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numCuotasFinan;
        private System.Windows.Forms.NumericUpDown numValorInteres;
        private System.Windows.Forms.TextBox TxtValorCuotaInteres;
        private System.Windows.Forms.TextBox TxtValorSaldo;
        private System.Windows.Forms.TextBox TxtValorInicial;
        private System.Windows.Forms.TextBox TxtTotal;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label labelSaldo;
        private System.Windows.Forms.Label labelPagado;
        private System.Windows.Forms.Label labelInteres;
        private System.Windows.Forms.Label labelDeuda;
    }
}