
namespace Cartera.Vista
{
    partial class GraficoVentas
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GraficoVentas));
            this.chart3 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label3 = new System.Windows.Forms.Label();
            this.comboProyecto = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.chart3)).BeginInit();
            this.SuspendLayout();
            // 
            // chart3
            // 
            chartArea1.AxisX.IsLabelAutoFit = false;
            chartArea1.AxisX.LabelStyle.Angle = -90;
            chartArea1.AxisX.LabelStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(60)))), ((int)(((byte)(12)))));
            chartArea1.AxisX.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(60)))), ((int)(((byte)(12)))));
            chartArea1.AxisX.MajorGrid.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(60)))), ((int)(((byte)(12)))));
            chartArea1.AxisY.IsLabelAutoFit = false;
            chartArea1.AxisY.LabelStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(60)))), ((int)(((byte)(12)))));
            chartArea1.AxisY.LabelStyle.Format = "{0:N0}";
            chartArea1.AxisY.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(60)))), ((int)(((byte)(12)))));
            chartArea1.AxisY.MajorGrid.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(60)))), ((int)(((byte)(12)))));
            chartArea1.CursorX.IsUserSelectionEnabled = true;
            chartArea1.CursorY.IsUserSelectionEnabled = true;
            chartArea1.Name = "ChartArea1";
            this.chart3.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart3.Legends.Add(legend1);
            this.chart3.Location = new System.Drawing.Point(0, -1);
            this.chart3.Name = "chart3";
            this.chart3.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.SeaGreen;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.SplineArea;
            series1.Legend = "Legend1";
            series1.Name = "Ventas";
            series1.ToolTip = "Seleccione con el click derecho para hacer zoom";
            this.chart3.Series.Add(series1);
            this.chart3.Size = new System.Drawing.Size(917, 477);
            this.chart3.TabIndex = 7;
            this.chart3.Text = "chart3";
            title1.Alignment = System.Drawing.ContentAlignment.TopLeft;
            title1.Font = new System.Drawing.Font("Bernard MT Condensed", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(60)))), ((int)(((byte)(12)))));
            title1.Name = "Title1";
            title1.Text = "Historico Ventas";
            this.chart3.Titles.Add(title1);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(408, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 29;
            this.label3.Text = "Proyecto";
            // 
            // comboProyecto
            // 
            this.comboProyecto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboProyecto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboProyecto.FormattingEnabled = true;
            this.comboProyecto.Location = new System.Drawing.Point(469, 15);
            this.comboProyecto.Name = "comboProyecto";
            this.comboProyecto.Size = new System.Drawing.Size(295, 21);
            this.comboProyecto.TabIndex = 30;
            this.comboProyecto.SelectedIndexChanged += new System.EventHandler(this.comboProyecto_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(806, 74);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 31;
            this.button1.Text = "Imprimir";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // GraficoVentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(916, 474);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboProyecto);
            this.Controls.Add(this.chart3);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GraficoVentas";
            this.Text = "Grafico Ventas";
            this.Load += new System.EventHandler(this.GraficoVentas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboProyecto;
        private System.Windows.Forms.Button button1;
    }
}