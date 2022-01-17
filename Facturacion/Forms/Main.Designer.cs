namespace Facturacion.Forms
{
    partial class Main
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.adminstracionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnIrUsuarios = new System.Windows.Forms.ToolStripMenuItem();
            this.facturacionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnIrClientes = new System.Windows.Forms.ToolStripMenuItem();
            this.btnIrArticulos = new System.Windows.Forms.ToolStripMenuItem();
            this.btnIrFacturacion = new System.Windows.Forms.ToolStripMenuItem();
            this.btnIrConsultaFacturacion = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.adminstracionToolStripMenuItem,
            this.facturacionToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(284, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // adminstracionToolStripMenuItem
            // 
            this.adminstracionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnIrUsuarios});
            this.adminstracionToolStripMenuItem.Name = "adminstracionToolStripMenuItem";
            this.adminstracionToolStripMenuItem.Size = new System.Drawing.Size(97, 20);
            this.adminstracionToolStripMenuItem.Text = "Adminstracion";
            // 
            // btnIrUsuarios
            // 
            this.btnIrUsuarios.Name = "btnIrUsuarios";
            this.btnIrUsuarios.Size = new System.Drawing.Size(119, 22);
            this.btnIrUsuarios.Text = "Usuarios";
            // 
            // facturacionToolStripMenuItem
            // 
            this.facturacionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnIrClientes,
            this.btnIrArticulos,
            this.btnIrFacturacion,
            this.btnIrConsultaFacturacion});
            this.facturacionToolStripMenuItem.Name = "facturacionToolStripMenuItem";
            this.facturacionToolStripMenuItem.Size = new System.Drawing.Size(81, 20);
            this.facturacionToolStripMenuItem.Text = "Facturacion";
            // 
            // btnIrClientes
            // 
            this.btnIrClientes.Name = "btnIrClientes";
            this.btnIrClientes.Size = new System.Drawing.Size(182, 22);
            this.btnIrClientes.Text = "Clientes";
            this.btnIrClientes.Click += new System.EventHandler(this.btnIrClientes_Click);
            // 
            // btnIrArticulos
            // 
            this.btnIrArticulos.Name = "btnIrArticulos";
            this.btnIrArticulos.Size = new System.Drawing.Size(182, 22);
            this.btnIrArticulos.Text = "Articulos";
            this.btnIrArticulos.Click += new System.EventHandler(this.btnIrArticulos_Click);
            // 
            // btnIrFacturacion
            // 
            this.btnIrFacturacion.Name = "btnIrFacturacion";
            this.btnIrFacturacion.Size = new System.Drawing.Size(182, 22);
            this.btnIrFacturacion.Text = "Facturacion";
            this.btnIrFacturacion.Click += new System.EventHandler(this.btnIrFacturacion_Click);
            // 
            // btnIrConsultaFacturacion
            // 
            this.btnIrConsultaFacturacion.Name = "btnIrConsultaFacturacion";
            this.btnIrConsultaFacturacion.Size = new System.Drawing.Size(182, 22);
            this.btnIrConsultaFacturacion.Text = "Consulta de facturas";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Sistema de Facturacion";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Main_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem adminstracionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem btnIrUsuarios;
        private System.Windows.Forms.ToolStripMenuItem facturacionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem btnIrClientes;
        private System.Windows.Forms.ToolStripMenuItem btnIrArticulos;
        private System.Windows.Forms.ToolStripMenuItem btnIrFacturacion;
        private System.Windows.Forms.ToolStripMenuItem btnIrConsultaFacturacion;
    }
}