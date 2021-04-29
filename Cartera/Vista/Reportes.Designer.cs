﻿
namespace Cartera.Vista
{
    partial class Reportes
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.BtBuscar = new System.Windows.Forms.Button();
            this.datefin = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.dateInicio = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.labelNumero = new System.Windows.Forms.Label();
            this.labelTotal = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.BtBuscar2 = new System.Windows.Forms.Button();
            this.datefin2 = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.dateInicio2 = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.BtRP = new System.Windows.Forms.Button();
            this.labelVentas = new System.Windows.Forms.Label();
            this.labelTotalVentas = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(5, 4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(922, 529);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dataGridView1);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(914, 503);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Ingresos";
            this.toolTip1.SetToolTip(this.tabPage1, "Reporte de Ingresos");
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(6, 82);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(901, 412);
            this.dataGridView1.TabIndex = 4;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.BtBuscar);
            this.groupBox1.Controls.Add(this.datefin);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dateInicio);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(26, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(430, 62);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Rango de fechas";
            // 
            // BtBuscar
            // 
            this.BtBuscar.Image = global::Cartera.Properties.Resources.buscar;
            this.BtBuscar.Location = new System.Drawing.Point(372, 23);
            this.BtBuscar.Name = "BtBuscar";
            this.BtBuscar.Size = new System.Drawing.Size(35, 27);
            this.BtBuscar.TabIndex = 7;
            this.toolTip1.SetToolTip(this.BtBuscar, "Buscar Reporte");
            this.BtBuscar.UseVisualStyleBackColor = true;
            this.BtBuscar.Click += new System.EventHandler(this.BtBuscar_Click);
            // 
            // datefin
            // 
            this.datefin.CustomFormat = "yyyy-MM-dd";
            this.datefin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.datefin.Location = new System.Drawing.Point(249, 26);
            this.datefin.Name = "datefin";
            this.datefin.Size = new System.Drawing.Size(100, 20);
            this.datefin.TabIndex = 6;
            this.toolTip1.SetToolTip(this.datefin, "Fecha Final Reporte");
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Inicial";
            // 
            // dateInicio
            // 
            this.dateInicio.CustomFormat = "yyyy-MM-dd";
            this.dateInicio.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateInicio.Location = new System.Drawing.Point(85, 26);
            this.dateInicio.Name = "dateInicio";
            this.dateInicio.Size = new System.Drawing.Size(102, 20);
            this.dateInicio.TabIndex = 5;
            this.toolTip1.SetToolTip(this.dateInicio, "Fecha Inicial Reporte");
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(214, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Final";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.labelNumero);
            this.groupBox2.Controls.Add(this.labelTotal);
            this.groupBox2.Location = new System.Drawing.Point(485, 13);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(405, 62);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Pagos";
            // 
            // button1
            // 
            this.button1.Image = global::Cartera.Properties.Resources.ReporPdf;
            this.button1.Location = new System.Drawing.Point(332, 23);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(35, 27);
            this.button1.TabIndex = 8;
            this.toolTip1.SetToolTip(this.button1, "Guardar Reporte");
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // labelNumero
            // 
            this.labelNumero.AutoSize = true;
            this.labelNumero.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNumero.Location = new System.Drawing.Point(224, 30);
            this.labelNumero.Name = "labelNumero";
            this.labelNumero.Size = new System.Drawing.Size(42, 13);
            this.labelNumero.TabIndex = 11;
            this.labelNumero.Text = "Pagos";
            this.toolTip1.SetToolTip(this.labelNumero, "Numero de Ingresos");
            // 
            // labelTotal
            // 
            this.labelTotal.AutoSize = true;
            this.labelTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTotal.Location = new System.Drawing.Point(24, 32);
            this.labelTotal.Name = "labelTotal";
            this.labelTotal.Size = new System.Drawing.Size(36, 13);
            this.labelTotal.TabIndex = 9;
            this.labelTotal.Text = "Total";
            this.toolTip1.SetToolTip(this.labelTotal, "Valor Total Ingresos");
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dataGridView2);
            this.tabPage2.Controls.Add(this.groupBox3);
            this.tabPage2.Controls.Add(this.groupBox4);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(914, 503);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Ventas";
            this.toolTip1.SetToolTip(this.tabPage2, "Reporte de Ventas");
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dataGridView2
            // 
            this.dataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(6, 82);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(902, 415);
            this.dataGridView2.TabIndex = 15;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.BtBuscar2);
            this.groupBox3.Controls.Add(this.datefin2);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.dateInicio2);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Location = new System.Drawing.Point(26, 13);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(430, 62);
            this.groupBox3.TabIndex = 13;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Rango de fechas";
            // 
            // BtBuscar2
            // 
            this.BtBuscar2.Image = global::Cartera.Properties.Resources.buscar;
            this.BtBuscar2.Location = new System.Drawing.Point(372, 23);
            this.BtBuscar2.Name = "BtBuscar2";
            this.BtBuscar2.Size = new System.Drawing.Size(35, 27);
            this.BtBuscar2.TabIndex = 7;
            this.toolTip1.SetToolTip(this.BtBuscar2, "Buscar Ventas");
            this.BtBuscar2.UseVisualStyleBackColor = true;
            this.BtBuscar2.Click += new System.EventHandler(this.BtBuscar2_Click);
            // 
            // datefin2
            // 
            this.datefin2.CustomFormat = "yyyy-MM-dd";
            this.datefin2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.datefin2.Location = new System.Drawing.Point(249, 26);
            this.datefin2.Name = "datefin2";
            this.datefin2.Size = new System.Drawing.Size(100, 20);
            this.datefin2.TabIndex = 6;
            this.toolTip1.SetToolTip(this.datefin2, "Fecha Final Reporte");
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(41, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Inicial";
            // 
            // dateInicio2
            // 
            this.dateInicio2.CustomFormat = "yyyy-MM-dd";
            this.dateInicio2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateInicio2.Location = new System.Drawing.Point(85, 26);
            this.dateInicio2.Name = "dateInicio2";
            this.dateInicio2.Size = new System.Drawing.Size(102, 20);
            this.dateInicio2.TabIndex = 5;
            this.toolTip1.SetToolTip(this.dateInicio2, "Fecha Inicial Reporte");
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(214, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Final";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.BtRP);
            this.groupBox4.Controls.Add(this.labelVentas);
            this.groupBox4.Controls.Add(this.labelTotalVentas);
            this.groupBox4.Location = new System.Drawing.Point(485, 13);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(405, 62);
            this.groupBox4.TabIndex = 14;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Ventas";
            // 
            // BtRP
            // 
            this.BtRP.Image = global::Cartera.Properties.Resources.ReporPdf;
            this.BtRP.Location = new System.Drawing.Point(332, 23);
            this.BtRP.Name = "BtRP";
            this.BtRP.Size = new System.Drawing.Size(35, 27);
            this.BtRP.TabIndex = 8;
            this.toolTip1.SetToolTip(this.BtRP, "Guardar Reporte");
            this.BtRP.UseVisualStyleBackColor = true;
            this.BtRP.Click += new System.EventHandler(this.BtRP_Click);
            // 
            // labelVentas
            // 
            this.labelVentas.AutoSize = true;
            this.labelVentas.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelVentas.Location = new System.Drawing.Point(224, 30);
            this.labelVentas.Name = "labelVentas";
            this.labelVentas.Size = new System.Drawing.Size(46, 13);
            this.labelVentas.TabIndex = 11;
            this.labelVentas.Text = "Ventas";
            this.toolTip1.SetToolTip(this.labelVentas, "Numero de Ventas");
            // 
            // labelTotalVentas
            // 
            this.labelTotalVentas.AutoSize = true;
            this.labelTotalVentas.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTotalVentas.Location = new System.Drawing.Point(24, 32);
            this.labelTotalVentas.Name = "labelTotalVentas";
            this.labelTotalVentas.Size = new System.Drawing.Size(36, 13);
            this.labelTotalVentas.TabIndex = 9;
            this.labelTotalVentas.Text = "Total";
            this.toolTip1.SetToolTip(this.labelTotalVentas, "Valor Total Ventas");
            // 
            // Reportes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(928, 537);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Reportes";
            this.Text = "Reportes";
            this.Load += new System.EventHandler(this.Reportes_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker datefin;
        private System.Windows.Forms.DateTimePicker dateInicio;
        private System.Windows.Forms.Button BtBuscar;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label labelNumero;
        private System.Windows.Forms.Label labelTotal;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button BtBuscar2;
        private System.Windows.Forms.DateTimePicker datefin2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dateInicio2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button BtRP;
        private System.Windows.Forms.Label labelVentas;
        private System.Windows.Forms.Label labelTotalVentas;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}