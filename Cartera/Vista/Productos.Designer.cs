
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBuscarProducto = new System.Windows.Forms.TextBox();
            this.BtBuscarProducto = new System.Windows.Forms.Button();
            this.btTipoProducto = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 90);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(907, 435);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(160, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Producto";
            // 
            // txtBuscarProducto
            // 
            this.txtBuscarProducto.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtBuscarProducto.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtBuscarProducto.Location = new System.Drawing.Point(240, 36);
            this.txtBuscarProducto.Name = "txtBuscarProducto";
            this.txtBuscarProducto.Size = new System.Drawing.Size(303, 20);
            this.txtBuscarProducto.TabIndex = 2;
            // 
            // BtBuscarProducto
            // 
            this.BtBuscarProducto.Location = new System.Drawing.Point(574, 34);
            this.BtBuscarProducto.Name = "BtBuscarProducto";
            this.BtBuscarProducto.Size = new System.Drawing.Size(75, 23);
            this.BtBuscarProducto.TabIndex = 3;
            this.BtBuscarProducto.Text = "Buscar";
            this.BtBuscarProducto.UseVisualStyleBackColor = true;
            this.BtBuscarProducto.Click += new System.EventHandler(this.BtBuscarProducto_Click);
            // 
            // btTipoProducto
            // 
            this.btTipoProducto.Location = new System.Drawing.Point(665, 34);
            this.btTipoProducto.Name = "btTipoProducto";
            this.btTipoProducto.Size = new System.Drawing.Size(84, 23);
            this.btTipoProducto.TabIndex = 4;
            this.btTipoProducto.Text = "Tipo Producto";
            this.btTipoProducto.UseVisualStyleBackColor = true;
            // 
            // Productos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(931, 537);
            this.Controls.Add(this.btTipoProducto);
            this.Controls.Add(this.BtBuscarProducto);
            this.Controls.Add(this.txtBuscarProducto);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Productos";
            this.Text = "Productos";
            this.Load += new System.EventHandler(this.Productos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBuscarProducto;
        private System.Windows.Forms.Button BtBuscarProducto;
        private System.Windows.Forms.Button btTipoProducto;
    }
}