
namespace Cartera.Vistas
{
    partial class Principal
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Principal));
            this.PanelMenu = new System.Windows.Forms.Panel();
            this.BtSalir = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.BtReportes = new System.Windows.Forms.Button();
            this.BtProyectos = new System.Windows.Forms.Button();
            this.BtProductos = new System.Windows.Forms.Button();
            this.BtClientes = new System.Windows.Forms.Button();
            this.PanelContenedor = new System.Windows.Forms.Panel();
            this.PanelMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // PanelMenu
            // 
            this.PanelMenu.AutoSize = true;
            this.PanelMenu.BackColor = System.Drawing.Color.LightCyan;
            this.PanelMenu.Controls.Add(this.BtSalir);
            this.PanelMenu.Controls.Add(this.pictureBox1);
            this.PanelMenu.Controls.Add(this.BtReportes);
            this.PanelMenu.Controls.Add(this.BtProyectos);
            this.PanelMenu.Controls.Add(this.BtProductos);
            this.PanelMenu.Controls.Add(this.BtClientes);
            this.PanelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.PanelMenu.Location = new System.Drawing.Point(0, 0);
            this.PanelMenu.Name = "PanelMenu";
            this.PanelMenu.Size = new System.Drawing.Size(203, 501);
            this.PanelMenu.TabIndex = 0;
            // 
            // BtSalir
            // 
            this.BtSalir.Cursor = System.Windows.Forms.Cursors.Default;
            this.BtSalir.FlatAppearance.BorderSize = 0;
            this.BtSalir.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkOliveGreen;
            this.BtSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtSalir.Font = new System.Drawing.Font("Bernard MT Condensed", 15.75F);
            this.BtSalir.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(60)))), ((int)(((byte)(12)))));
            this.BtSalir.Image = ((System.Drawing.Image)(resources.GetObject("BtSalir.Image")));
            this.BtSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtSalir.Location = new System.Drawing.Point(12, 338);
            this.BtSalir.Name = "BtSalir";
            this.BtSalir.Size = new System.Drawing.Size(188, 41);
            this.BtSalir.TabIndex = 8;
            this.BtSalir.Text = "Salir";
            this.BtSalir.UseVisualStyleBackColor = true;
            this.BtSalir.Click += new System.EventHandler(this.BtSalir_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(200, 149);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // BtReportes
            // 
            this.BtReportes.Cursor = System.Windows.Forms.Cursors.Default;
            this.BtReportes.FlatAppearance.BorderSize = 0;
            this.BtReportes.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkOliveGreen;
            this.BtReportes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtReportes.Font = new System.Drawing.Font("Bernard MT Condensed", 15.75F);
            this.BtReportes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(60)))), ((int)(((byte)(12)))));
            this.BtReportes.Image = ((System.Drawing.Image)(resources.GetObject("BtReportes.Image")));
            this.BtReportes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtReportes.Location = new System.Drawing.Point(12, 291);
            this.BtReportes.Name = "BtReportes";
            this.BtReportes.Size = new System.Drawing.Size(188, 41);
            this.BtReportes.TabIndex = 6;
            this.BtReportes.Text = "Reportes";
            this.BtReportes.UseVisualStyleBackColor = true;
            // 
            // BtProyectos
            // 
            this.BtProyectos.Cursor = System.Windows.Forms.Cursors.Default;
            this.BtProyectos.FlatAppearance.BorderSize = 0;
            this.BtProyectos.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkOliveGreen;
            this.BtProyectos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtProyectos.Font = new System.Drawing.Font("Bernard MT Condensed", 15.75F);
            this.BtProyectos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(60)))), ((int)(((byte)(12)))));
            this.BtProyectos.Image = ((System.Drawing.Image)(resources.GetObject("BtProyectos.Image")));
            this.BtProyectos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtProyectos.Location = new System.Drawing.Point(12, 244);
            this.BtProyectos.Name = "BtProyectos";
            this.BtProyectos.Size = new System.Drawing.Size(188, 41);
            this.BtProyectos.TabIndex = 5;
            this.BtProyectos.Text = "Proyectos";
            this.BtProyectos.UseVisualStyleBackColor = true;
            this.BtProyectos.Click += new System.EventHandler(this.BtProyectos_Click);
            // 
            // BtProductos
            // 
            this.BtProductos.Cursor = System.Windows.Forms.Cursors.Default;
            this.BtProductos.FlatAppearance.BorderSize = 0;
            this.BtProductos.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkOliveGreen;
            this.BtProductos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtProductos.Font = new System.Drawing.Font("Bernard MT Condensed", 15.75F);
            this.BtProductos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(60)))), ((int)(((byte)(12)))));
            this.BtProductos.Image = ((System.Drawing.Image)(resources.GetObject("BtProductos.Image")));
            this.BtProductos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtProductos.Location = new System.Drawing.Point(12, 197);
            this.BtProductos.Name = "BtProductos";
            this.BtProductos.Size = new System.Drawing.Size(188, 41);
            this.BtProductos.TabIndex = 4;
            this.BtProductos.Text = "Productos";
            this.BtProductos.UseVisualStyleBackColor = true;
            this.BtProductos.Click += new System.EventHandler(this.BtProductos_Click);
            // 
            // BtClientes
            // 
            this.BtClientes.Cursor = System.Windows.Forms.Cursors.Default;
            this.BtClientes.FlatAppearance.BorderSize = 0;
            this.BtClientes.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkOliveGreen;
            this.BtClientes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtClientes.Font = new System.Drawing.Font("Bernard MT Condensed", 15.75F);
            this.BtClientes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(60)))), ((int)(((byte)(12)))));
            this.BtClientes.Image = ((System.Drawing.Image)(resources.GetObject("BtClientes.Image")));
            this.BtClientes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtClientes.Location = new System.Drawing.Point(12, 150);
            this.BtClientes.Name = "BtClientes";
            this.BtClientes.Size = new System.Drawing.Size(188, 41);
            this.BtClientes.TabIndex = 0;
            this.BtClientes.Text = "Clientes";
            this.BtClientes.UseVisualStyleBackColor = true;
            this.BtClientes.Click += new System.EventHandler(this.BtClientes_Click);
            // 
            // PanelContenedor
            // 
            this.PanelContenedor.AutoSize = true;
            this.PanelContenedor.BackColor = System.Drawing.Color.YellowGreen;
            this.PanelContenedor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PanelContenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelContenedor.Location = new System.Drawing.Point(203, 0);
            this.PanelContenedor.Name = "PanelContenedor";
            this.PanelContenedor.Size = new System.Drawing.Size(830, 501);
            this.PanelContenedor.TabIndex = 1;
            this.PanelContenedor.Paint += new System.Windows.Forms.PaintEventHandler(this.PanelContenedor_Paint);
            // 
            // Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1033, 501);
            this.Controls.Add(this.PanelContenedor);
            this.Controls.Add(this.PanelMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(680, 500);
            this.Name = "Principal";
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cartera";
            this.Load += new System.EventHandler(this.Principal_Load);
            this.PanelMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel PanelMenu;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button BtClientes;
        private System.Windows.Forms.Button BtProductos;
        private System.Windows.Forms.Button BtProyectos;
        private System.Windows.Forms.Button BtSalir;
        private System.Windows.Forms.Button BtReportes;
        private System.Windows.Forms.Panel PanelContenedor;
    }
}

