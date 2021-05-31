
namespace Cartera.Vista
{
    partial class Carteras
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Carteras));
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button3 = new System.Windows.Forms.Button();
            this.Txtcedula = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.comboEstados = new System.Windows.Forms.ComboBox();
            this.BtPago = new System.Windows.Forms.Button();
            this.BtHistorialPago = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.labelRecaudo = new System.Windows.Forms.Label();
            this.labelDeuda = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.labelTotal = new System.Windows.Forms.Label();
            this.comboProyecto = new System.Windows.Forms.ComboBox();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.dataGridView1);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(12, 65);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(978, 508);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(3, 3);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(975, 505);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            this.dataGridView1.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView1_CellFormatting);
            this.dataGridView1.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellMouseEnter_1);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1002, 68);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(34, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Cedula";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Txtcedula);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(15, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(240, 49);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Cliente";
            // 
            // button3
            // 
            this.button3.Image = ((System.Drawing.Image)(resources.GetObject("button3.Image")));
            this.button3.Location = new System.Drawing.Point(680, 15);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(33, 28);
            this.button3.TabIndex = 6;
            this.toolTip1.SetToolTip(this.button3, "Limpiar");
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Txtcedula
            // 
            this.Txtcedula.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.Txtcedula.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.Txtcedula.Location = new System.Drawing.Point(65, 20);
            this.Txtcedula.Name = "Txtcedula";
            this.Txtcedula.Size = new System.Drawing.Size(125, 20);
            this.Txtcedula.TabIndex = 5;
            this.toolTip1.SetToolTip(this.Txtcedula, "Digite cdulda del cliente");
            // 
            // button1
            // 
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Location = new System.Drawing.Point(196, 14);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(33, 29);
            this.button1.TabIndex = 4;
            this.toolTip1.SetToolTip(this.button1, "Buscar");
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button3);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.comboProyecto);
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.comboEstados);
            this.groupBox2.Controls.Add(this.BtPago);
            this.groupBox2.Controls.Add(this.BtHistorialPago);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(261, 8);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(729, 49);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Cartera";
            // 
            // button2
            // 
            this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
            this.button2.Location = new System.Drawing.Point(644, 15);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(33, 28);
            this.button2.TabIndex = 4;
            this.toolTip1.SetToolTip(this.button2, "Guardar Reporte");
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(378, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Pagos";
            // 
            // comboEstados
            // 
            this.comboEstados.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboEstados.FormattingEnabled = true;
            this.comboEstados.Items.AddRange(new object[] {
            "Todo",
            "Pagado",
            "Menos de 30 días",
            "De 31 a 60 días",
            "De 61 a 90 días",
            "De 91 a 180 días",
            "Mas de 360 días"});
            this.comboEstados.Location = new System.Drawing.Point(426, 20);
            this.comboEstados.Name = "comboEstados";
            this.comboEstados.Size = new System.Drawing.Size(138, 21);
            this.comboEstados.TabIndex = 2;
            this.comboEstados.Text = "seleccione una opción";
            this.toolTip1.SetToolTip(this.comboEstados, "Seleccione un estado");
            this.comboEstados.SelectedValueChanged += new System.EventHandler(this.comboEstados_SelectedValueChanged);
            // 
            // BtPago
            // 
            this.BtPago.Image = ((System.Drawing.Image)(resources.GetObject("BtPago.Image")));
            this.BtPago.Location = new System.Drawing.Point(607, 15);
            this.BtPago.Name = "BtPago";
            this.BtPago.Size = new System.Drawing.Size(33, 28);
            this.BtPago.TabIndex = 0;
            this.toolTip1.SetToolTip(this.BtPago, "Registrar Pagos");
            this.BtPago.UseVisualStyleBackColor = true;
            this.BtPago.Click += new System.EventHandler(this.button1_Click);
            // 
            // BtHistorialPago
            // 
            this.BtHistorialPago.Image = ((System.Drawing.Image)(resources.GetObject("BtHistorialPago.Image")));
            this.BtHistorialPago.Location = new System.Drawing.Point(571, 15);
            this.BtHistorialPago.Name = "BtHistorialPago";
            this.BtHistorialPago.Size = new System.Drawing.Size(33, 28);
            this.BtHistorialPago.TabIndex = 3;
            this.toolTip1.SetToolTip(this.BtHistorialPago, "Historial Pagos");
            this.BtHistorialPago.UseVisualStyleBackColor = true;
            this.BtHistorialPago.Click += new System.EventHandler(this.BtHistorialPago_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.labelTotal);
            this.panel2.Controls.Add(this.labelRecaudo);
            this.panel2.Controls.Add(this.labelDeuda);
            this.panel2.Controls.Add(this.flowLayoutPanel1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1002, 620);
            this.panel2.TabIndex = 1;
            // 
            // labelRecaudo
            // 
            this.labelRecaudo.AutoSize = true;
            this.labelRecaudo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRecaudo.ForeColor = System.Drawing.Color.Green;
            this.labelRecaudo.Location = new System.Drawing.Point(379, 590);
            this.labelRecaudo.Name = "labelRecaudo";
            this.labelRecaudo.Size = new System.Drawing.Size(105, 13);
            this.labelRecaudo.TabIndex = 23;
            this.labelRecaudo.Text = "Valor Recaudado";
            this.toolTip1.SetToolTip(this.labelRecaudo, "Total Aportes a la cartera");
            // 
            // labelDeuda
            // 
            this.labelDeuda.AutoSize = true;
            this.labelDeuda.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDeuda.ForeColor = System.Drawing.Color.Crimson;
            this.labelDeuda.Location = new System.Drawing.Point(622, 590);
            this.labelDeuda.Name = "labelDeuda";
            this.labelDeuda.Size = new System.Drawing.Size(77, 13);
            this.labelDeuda.TabIndex = 21;
            this.labelDeuda.Text = "Valor Deuda";
            this.toolTip1.SetToolTip(this.labelDeuda, "Deuda por pagar a la cartera");
            // 
            // labelTotal
            // 
            this.labelTotal.AutoSize = true;
            this.labelTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTotal.ForeColor = System.Drawing.Color.DodgerBlue;
            this.labelTotal.Location = new System.Drawing.Point(818, 590);
            this.labelTotal.Name = "labelTotal";
            this.labelTotal.Size = new System.Drawing.Size(36, 13);
            this.labelTotal.TabIndex = 27;
            this.labelTotal.Text = "Total";
            this.toolTip1.SetToolTip(this.labelTotal, "Valor total cartera San Isidro");
            // 
            // comboProyecto
            // 
            this.comboProyecto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboProyecto.FormattingEnabled = true;
            this.comboProyecto.Location = new System.Drawing.Point(75, 20);
            this.comboProyecto.Name = "comboProyecto";
            this.comboProyecto.Size = new System.Drawing.Size(295, 21);
            this.comboProyecto.TabIndex = 28;
            this.comboProyecto.Text = "TODOS LOS PROYECTOS";
            this.comboProyecto.SelectedIndexChanged += new System.EventHandler(this.comboProyecto_SelectedIndexChanged);
            this.comboProyecto.MouseClick += new System.Windows.Forms.MouseEventHandler(this.comboProyecto_MouseClick);
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(14, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Proyecto";
            // 
            // Carteras
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1002, 620);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Carteras";
            this.Text = "Carteras";
            this.Load += new System.EventHandler(this.Carteras_Load);
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button BtPago;
        private System.Windows.Forms.ComboBox comboEstados;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BtHistorialPago;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Txtcedula;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label labelRecaudo;
        private System.Windows.Forms.Label labelDeuda;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label labelTotal;
        private System.Windows.Forms.ComboBox comboProyecto;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Label label3;
    }
}