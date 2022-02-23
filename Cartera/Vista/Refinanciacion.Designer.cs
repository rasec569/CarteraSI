
namespace Cartera.Vista
{
    partial class Refinanciacion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Refinanciacion));
            this.TxtValorNeto = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.TxtTotal = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.TxtValorCuota = new System.Windows.Forms.TextBox();
            this.TxtValorDeuda = new System.Windows.Forms.TextBox();
            this.TxtValorMora = new System.Windows.Forms.TextBox();
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numCuotasFinan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numValorInteres)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
            this.SuspendLayout();
            // 
            // TxtValorNeto
            // 
            this.TxtValorNeto.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.TxtValorNeto.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.TxtValorNeto.Enabled = false;
            this.TxtValorNeto.Location = new System.Drawing.Point(10, 36);
            this.TxtValorNeto.Name = "TxtValorNeto";
            this.TxtValorNeto.Size = new System.Drawing.Size(102, 20);
            this.TxtValorNeto.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.TxtTotal);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.TxtValorCuota);
            this.groupBox1.Controls.Add(this.TxtValorDeuda);
            this.groupBox1.Controls.Add(this.TxtValorMora);
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
            this.groupBox1.Text = "Refinanciación";
            // 
            // button1
            // 
            this.button1.Image = global::Cartera.Properties.Resources.Guardar1;
            this.button1.Location = new System.Drawing.Point(711, 24);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(31, 32);
            this.button1.TabIndex = 33;
            this.toolTip1.SetToolTip(this.button1, "Guardar Refinanciación");
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // TxtTotal
            // 
            this.TxtTotal.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.TxtTotal.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.TxtTotal.Enabled = false;
            this.TxtTotal.Location = new System.Drawing.Point(599, 36);
            this.TxtTotal.Name = "TxtTotal";
            this.TxtTotal.Size = new System.Drawing.Size(102, 20);
            this.TxtTotal.TabIndex = 38;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(616, 18);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(69, 13);
            this.label7.TabIndex = 37;
            this.label7.Text = "Valor Total";
            // 
            // TxtValorCuota
            // 
            this.TxtValorCuota.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.TxtValorCuota.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.TxtValorCuota.Enabled = false;
            this.TxtValorCuota.Location = new System.Drawing.Point(482, 36);
            this.TxtValorCuota.Name = "TxtValorCuota";
            this.TxtValorCuota.Size = new System.Drawing.Size(102, 20);
            this.TxtValorCuota.TabIndex = 36;
            // 
            // TxtValorDeuda
            // 
            this.TxtValorDeuda.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.TxtValorDeuda.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.TxtValorDeuda.Enabled = false;
            this.TxtValorDeuda.Location = new System.Drawing.Point(243, 36);
            this.TxtValorDeuda.Name = "TxtValorDeuda";
            this.TxtValorDeuda.Size = new System.Drawing.Size(102, 20);
            this.TxtValorDeuda.TabIndex = 35;
            // 
            // TxtValorMora
            // 
            this.TxtValorMora.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.TxtValorMora.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.TxtValorMora.Enabled = false;
            this.TxtValorMora.Location = new System.Drawing.Point(124, 36);
            this.TxtValorMora.Name = "TxtValorMora";
            this.TxtValorMora.Size = new System.Drawing.Size(102, 20);
            this.TxtValorMora.TabIndex = 34;
            // 
            // numCuotasFinan
            // 
            this.numCuotasFinan.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numCuotasFinan.Location = new System.Drawing.Point(358, 36);
            this.numCuotasFinan.Maximum = new decimal(new int[] {
            36,
            0,
            0,
            0});
            this.numCuotasFinan.Name = "numCuotasFinan";
            this.numCuotasFinan.Size = new System.Drawing.Size(50, 20);
            this.numCuotasFinan.TabIndex = 33;
            this.numCuotasFinan.Click += new System.EventHandler(this.numCuotasFinan_Click);
            // 
            // numValorInteres
            // 
            this.numValorInteres.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numValorInteres.Location = new System.Drawing.Point(425, 36);
            this.numValorInteres.Maximum = new decimal(new int[] {
            36,
            0,
            0,
            0});
            this.numValorInteres.Name = "numValorInteres";
            this.numValorInteres.Size = new System.Drawing.Size(44, 20);
            this.numValorInteres.TabIndex = 32;
            this.numValorInteres.Click += new System.EventHandler(this.numValorInteres_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(497, 18);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 13);
            this.label5.TabIndex = 31;
            this.label5.Text = "Valor Cuota";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(418, 18);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 13);
            this.label6.TabIndex = 29;
            this.label6.Text = "% Interes";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(360, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 13);
            this.label4.TabIndex = 27;
            this.label4.Text = "Cuotas";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(258, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 25;
            this.label1.Text = "Valor Deuda";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(134, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 13);
            this.label3.TabIndex = 23;
            this.label3.Text = "Interes Mora";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 18);
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
            this.dataGridView1.Location = new System.Drawing.Point(0, 3);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(738, 275);
            this.dataGridView1.TabIndex = 20;
            this.dataGridView1.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView1_CellFormatting);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(3, 82);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(748, 304);
            this.tabControl1.TabIndex = 22;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dataGridView1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(740, 278);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Cuotas";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dataGridView2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(740, 278);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Amortización";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dataGridView2
            // 
            this.dataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(1, 0);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(738, 278);
            this.dataGridView2.TabIndex = 21;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.dataGridView3);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(740, 278);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Nuevas";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // dataGridView3
            // 
            this.dataGridView3.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView3.Location = new System.Drawing.Point(-1, 0);
            this.dataGridView3.Name = "dataGridView3";
            this.dataGridView3.Size = new System.Drawing.Size(739, 278);
            this.dataGridView3.TabIndex = 22;
            this.dataGridView3.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dataGridView3_DataBindingComplete);
            // 
            // button2
            // 
            this.button2.Image = global::Cartera.Properties.Resources.ReporPdf;
            this.button2.Location = new System.Drawing.Point(711, 24);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(31, 32);
            this.button2.TabIndex = 39;
            this.toolTip1.SetToolTip(this.button2, "Guardar Reporte");
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Visible = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Refinanciacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(753, 384);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Refinanciacion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Detalle Refinanciación";
            this.Load += new System.EventHandler(this.Detalle_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numCuotasFinan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numValorInteres)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
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
        private System.Windows.Forms.TextBox TxtValorCuota;
        private System.Windows.Forms.TextBox TxtValorDeuda;
        private System.Windows.Forms.TextBox TxtValorMora;
        private System.Windows.Forms.TextBox TxtTotal;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.DataGridView dataGridView3;
        private System.Windows.Forms.Button button2;
    }
}