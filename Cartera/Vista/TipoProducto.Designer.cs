
namespace Cartera.Vista
{
    partial class TipoProducto
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
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.BtGuardarTipoPro = new System.Windows.Forms.Button();
            this.TxtNomTipoPro = new System.Windows.Forms.TextBox();
            this.Bt_EliminarTipoPro = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tipo Producto";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 44);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(331, 245);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // BtGuardarTipoPro
            // 
            this.BtGuardarTipoPro.Location = new System.Drawing.Point(238, 15);
            this.BtGuardarTipoPro.Name = "BtGuardarTipoPro";
            this.BtGuardarTipoPro.Size = new System.Drawing.Size(56, 23);
            this.BtGuardarTipoPro.TabIndex = 2;
            this.BtGuardarTipoPro.Text = "Guardar";
            this.BtGuardarTipoPro.UseVisualStyleBackColor = true;
            this.BtGuardarTipoPro.Click += new System.EventHandler(this.BtGuardarTipoPro_Click);
            // 
            // TxtNomTipoPro
            // 
            this.TxtNomTipoPro.Location = new System.Drawing.Point(89, 17);
            this.TxtNomTipoPro.Name = "TxtNomTipoPro";
            this.TxtNomTipoPro.Size = new System.Drawing.Size(143, 20);
            this.TxtNomTipoPro.TabIndex = 3;
            // 
            // Bt_EliminarTipoPro
            // 
            this.Bt_EliminarTipoPro.Location = new System.Drawing.Point(300, 15);
            this.Bt_EliminarTipoPro.Name = "Bt_EliminarTipoPro";
            this.Bt_EliminarTipoPro.Size = new System.Drawing.Size(56, 23);
            this.Bt_EliminarTipoPro.TabIndex = 4;
            this.Bt_EliminarTipoPro.Text = "Eliminar";
            this.Bt_EliminarTipoPro.UseVisualStyleBackColor = true;
            this.Bt_EliminarTipoPro.Click += new System.EventHandler(this.Bt_EliminarTipoPro_Click);
            // 
            // TipoProducto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(358, 450);
            this.Controls.Add(this.Bt_EliminarTipoPro);
            this.Controls.Add(this.TxtNomTipoPro);
            this.Controls.Add(this.BtGuardarTipoPro);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label1);
            this.Name = "TipoProducto";
            this.Text = "TipoProducto";
            this.Load += new System.EventHandler(this.TipoProducto_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button BtGuardarTipoPro;
        private System.Windows.Forms.TextBox TxtNomTipoPro;
        private System.Windows.Forms.Button Bt_EliminarTipoPro;
    }
}