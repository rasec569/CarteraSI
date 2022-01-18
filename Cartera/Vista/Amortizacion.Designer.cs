
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
            this.TxtValorNeto.Location = new System.Drawing.Point(28, 38);
            this.TxtValorNeto.Name = "TxtValorNeto";
            this.TxtValorNeto.Size = new System.Drawing.Size(102, 20);
            this.TxtValorNeto.TabIndex = 1;
            // 
            // groupBox1
            // 
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
            this.groupBox1.Text = "Cliente";
            // 
            // TxtValorCuotaInteres
            // 
            this.TxtValorCuotaInteres.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.TxtValorCuotaInteres.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.TxtValorCuotaInteres.Enabled = false;
            this.TxtValorCuotaInteres.Location = new System.Drawing.Point(518, 39);
            this.TxtValorCuotaInteres.Name = "TxtValorCuotaInteres";
            this.TxtValorCuotaInteres.Size = new System.Drawing.Size(102, 20);
            this.TxtValorCuotaInteres.TabIndex = 36;
            // 
            // TxtValorSaldo
            // 
            this.TxtValorSaldo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.TxtValorSaldo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.TxtValorSaldo.Enabled = false;
            this.TxtValorSaldo.Location = new System.Drawing.Point(268, 38);
            this.TxtValorSaldo.Name = "TxtValorSaldo";
            this.TxtValorSaldo.Size = new System.Drawing.Size(102, 20);
            this.TxtValorSaldo.TabIndex = 35;
            // 
            // TxtValorInicial
            // 
            this.TxtValorInicial.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.TxtValorInicial.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.TxtValorInicial.Enabled = false;
            this.TxtValorInicial.Location = new System.Drawing.Point(148, 38);
            this.TxtValorInicial.Name = "TxtValorInicial";
            this.TxtValorInicial.Size = new System.Drawing.Size(102, 20);
            this.TxtValorInicial.TabIndex = 34;
            // 
            // numCuotasFinan
            // 
            this.numCuotasFinan.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numCuotasFinan.Location = new System.Drawing.Point(388, 38);
            this.numCuotasFinan.Maximum = new decimal(new int[] {
            36,
            0,
            0,
            0});
            this.numCuotasFinan.Name = "numCuotasFinan";
            this.numCuotasFinan.Size = new System.Drawing.Size(50, 20);
            this.numCuotasFinan.TabIndex = 33;
            // 
            // numValorInteres
            // 
            this.numValorInteres.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numValorInteres.Location = new System.Drawing.Point(456, 39);
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
            this.label5.Location = new System.Drawing.Point(515, 18);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 13);
            this.label5.TabIndex = 31;
            this.label5.Text = "Valor Cuota";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(453, 18);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 13);
            this.label6.TabIndex = 29;
            this.label6.Text = "% Interes";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(383, 18);
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
            this.label2.Location = new System.Drawing.Point(25, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 21;
            this.label2.Text = "Valor lote";
            // 
            // dataGridView1
            // 
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(3, 110);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(748, 267);
            this.dataGridView1.TabIndex = 20;
            this.dataGridView1.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellMouseEnter);
            this.dataGridView1.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dataGridView1_CellPainting);
            this.dataGridView1.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dataGridView1_RowPostPaint);
            // 
            // Amortizacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(753, 380);
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
    }
}